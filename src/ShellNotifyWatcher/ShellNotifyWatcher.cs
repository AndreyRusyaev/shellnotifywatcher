using System;
using System.Runtime.InteropServices;
using System.Threading;

using ShellSpy.Common;
using ShellSpy.ChangeNotify;
using ShellSpy.ChangeNotify.Interop;
using ShellSpy.Extensions;
using ShellSpy.NativeWindows;

namespace ShellSpy
{
    /// <summary>
    /// Implements shell notifications watcher (SHChangeNotify & SHCNE_ events).
    /// </summary>
    public sealed class ShellNotifyWatcher : IDisposable
    {
        private string? path;

        private ItemIdList? itemIdList;

        private bool enableRaisingEvents;

        private CancellationTokenSource? cancellationTokenSource;

        private Thread? messageLoopThread;

        public ShellNotifyWatcher()
        {
            IncludeShellNotifications = true;
            EventFilters = ShellEventFilters.AllEvents;
        }

        public event EventHandler<ShellItemChangedEventArgs>? ItemChanged;

        public event EventHandler<ShellItemRenamedEventArgs>? ItemRenamed;

        public event EventHandler<DriveChangedEventArgs>? DriveChanged;

        public event EventHandler<ShareStatusChangedEventArgs>? ShareChanged;

        public event EventHandler<FreespaceChangedEventArgs>? FreespaceChanged;

        public event EventHandler<ShellNotifyEventArgs>? FileTypeAssociationChanged;

        public event EventHandler<ShellNotifyEventArgs>? ServerDisconnected;

        public event EventHandler<SystemImageListChangedEventArgs>? SystemImageListChanged;

        public event EventHandler<ShellExtendedEventNotifyEventArgs>? ExtendedEventOccurred;

        public event EventHandler<ShellNotifyEventArgs>? UnrecognizedEventOccurred;

        public string? Path
        {
            get { return path; }
            set
            {
                path = value;

                if (path != null)
                {
                    itemIdList = ItemIdList.FromAbsoluteParsingName(path);
                }
                else
                {
                    itemIdList = null;
                }
            }
        }

        public ItemIdList? ItemIdList
        {
            get
            {
                return itemIdList;
            }
            set
            {
                itemIdList = value;

                if (itemIdList != null)
                {
                    path = itemIdList.ToAbsoluteParsingName();
                }
                else
                {
                    path = null;
                }
            }
        }

        public bool Recursive { get; set; }

        public bool IncludeShellNotifications { get; set; }

        public ShellEventFilters EventFilters { get; set; }

        public bool EnableRaisingEvents
        {
            get
            {
                return enableRaisingEvents;
            }

            set
            {
                if (enableRaisingEvents == value)
                {
                    return;
                }

                enableRaisingEvents = value;

                if (enableRaisingEvents)
                {
                    StartListen();
                }
                else
                {
                    StopListen();
                }
            }
        }

        public void StartListen()
        {
            if (cancellationTokenSource != null)
            {
                throw new InvalidOperationException("Events listening already started");
            }

            cancellationTokenSource = new CancellationTokenSource();

            var thread = new Thread(() => { RunMessageLoop(cancellationTokenSource.Token); })
            {
                Name = GetType().Name + " MessageLoop",
                IsBackground = true
            };
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

            messageLoopThread = thread;
        }

        public void StopListen()
        {
            cancellationTokenSource?.Cancel();
            cancellationTokenSource = null;

            messageLoopThread?.Join();
            messageLoopThread = null;
        }

        public void Dispose()
        {
            StopListen();

            cancellationTokenSource?.Dispose();
        }

        private void RunMessageLoop(CancellationToken cancellationToken)
        {
            using var notifyWindow = 
                new ShellChangeNotifyWindow(ItemIdList, Recursive, IncludeShellNotifications, ToSHCNE(EventFilters));

            notifyWindow.ShellChanged += OnShellChanged;

            MessageLoop.Run(cancellationToken);
        }

        private void OnShellChanged(object sender, ShellChangeNotifyEventArgs eventArgs)
        {
            OnShellChanged(eventArgs.Event, eventArgs.Pidl1, eventArgs.Pidl2);
        }

        private void OnShellChanged(Shell32.SHCNE @event, IntPtr pidl1, IntPtr pidl2)
        {
            if (@event.IsOneOf(Shell32.SHCNE.SHCNE_CREATE,
                               Shell32.SHCNE.SHCNE_MKDIR,
                               Shell32.SHCNE.SHCNE_UPDATEITEM,
                               Shell32.SHCNE.SHCNE_UPDATEDIR,
                               Shell32.SHCNE.SHCNE_DELETE,
                               Shell32.SHCNE.SHCNE_RMDIR,
                               Shell32.SHCNE.SHCNE_RENAMEITEM,
                               Shell32.SHCNE.SHCNE_RENAMEFOLDER,
                               Shell32.SHCNE.SHCNE_ATTRIBUTES))
            {
                ShellItemChangeType itemChangeType;
                ShellItemType itemType;

                switch (@event)
                {
                    case Shell32.SHCNE.SHCNE_CREATE:
                        itemChangeType = ShellItemChangeType.Created;
                        itemType = ShellItemType.Item;
                        break;
                    case Shell32.SHCNE.SHCNE_MKDIR:
                        itemChangeType = ShellItemChangeType.Created;
                        itemType = ShellItemType.Directory;
                        break;

                    case Shell32.SHCNE.SHCNE_UPDATEITEM:
                        itemChangeType = ShellItemChangeType.Updated;
                        itemType = ShellItemType.Item;
                        break;
                    case Shell32.SHCNE.SHCNE_UPDATEDIR:
                        itemChangeType = ShellItemChangeType.Updated;
                        itemType = ShellItemType.Directory;
                        break;

                    case Shell32.SHCNE.SHCNE_DELETE:
                        itemChangeType = ShellItemChangeType.Deleted;
                        itemType = ShellItemType.Item;
                        break;
                    case Shell32.SHCNE.SHCNE_RMDIR:
                        itemChangeType = ShellItemChangeType.Deleted;
                        itemType = ShellItemType.Directory;
                        break;

                    case Shell32.SHCNE.SHCNE_RENAMEITEM:
                        itemChangeType = ShellItemChangeType.Renamed;
                        itemType = ShellItemType.Item;
                        break;
                    case Shell32.SHCNE.SHCNE_RENAMEFOLDER:
                        itemChangeType = ShellItemChangeType.Renamed;
                        itemType = ShellItemType.Directory;
                        break;

                    case Shell32.SHCNE.SHCNE_ATTRIBUTES:
                        itemChangeType = ShellItemChangeType.AttributesUpdated;
                        itemType = ShellItemType.Item;
                        break;

                    default:
                        throw new NotSupportedException();
                }

                if (itemChangeType == ShellItemChangeType.Renamed)
                {
                    ItemRenamed?.Invoke(
                        this,
                        new ShellItemRenamedEventArgs(
                            itemType,
                            ItemIdList.FromPidl(pidl1),
                            ItemIdList.FromPidl(pidl2)));
                }
                else
                {
                    ItemChanged?.Invoke(
                            this,
                            new ShellItemChangedEventArgs(
                                itemType,
                                ItemIdList.FromPidl(pidl1),
                                itemChangeType));
                }
            }
            else if (@event.IsOneOf(Shell32.SHCNE.SHCNE_DRIVEADD,
                                    Shell32.SHCNE.SHCNE_DRIVEREMOVED,
                                    Shell32.SHCNE.SHCNE_MEDIAINSERTED,
                                    Shell32.SHCNE.SHCNE_MEDIAREMOVED))
            {
                DriveChangeType driveChangeType;

                switch (@event)
                {
                    case Shell32.SHCNE.SHCNE_DRIVEADD:
                        driveChangeType = DriveChangeType.DriveAdded;
                        break;
                    case Shell32.SHCNE.SHCNE_DRIVEREMOVED:
                        driveChangeType = DriveChangeType.DriveRemoved;
                        break;

                    case Shell32.SHCNE.SHCNE_MEDIAINSERTED:
                        driveChangeType = DriveChangeType.MediaInserted;
                        break;
                    case Shell32.SHCNE.SHCNE_MEDIAREMOVED:
                        driveChangeType = DriveChangeType.MediaRemoved;
                        break;

                    default:
                        throw new NotSupportedException();
                }

                DriveChanged?.Invoke(
                    this,
                    new DriveChangedEventArgs(ItemIdList.FromPidl(pidl1), driveChangeType));
            }
            else if (@event.IsOneOf(Shell32.SHCNE.SHCNE_NETSHARE, Shell32.SHCNE.SHCNE_NETUNSHARE))
            {
                ShareStatus shareChangeType;
                switch (@event)
                {
                    case Shell32.SHCNE.SHCNE_NETSHARE:
                        shareChangeType = ShareStatus.Shared;
                        break;
                    case Shell32.SHCNE.SHCNE_NETUNSHARE:
                        shareChangeType = ShareStatus.Unshared;
                        break;

                    default:
                        throw new NotSupportedException();
                }

                ShareChanged?.Invoke(
                    this,
                    new ShareStatusChangedEventArgs(ItemIdList.FromPidl(pidl1), shareChangeType));
            }
            else if (@event == Shell32.SHCNE.SHCNE_SERVERDISCONNECT)
            {
                ServerDisconnected?.Invoke(this, new ShellNotifyEventArgs());
            }
            else if (@event == Shell32.SHCNE.SHCNE_ASSOCCHANGED)
            {
                FileTypeAssociationChanged?.Invoke(this, new ShellNotifyEventArgs());
            }
            else if (@event == Shell32.SHCNE.SHCNE_FREESPACE)
            {
                var dwordAsIdList = Marshal.PtrToStructure<Shell32.SHChangeDWORDAsIDList>(pidl1);

                FreespaceChanged?.Invoke(
                    this,
                    new FreespaceChangedEventArgs(dwordAsIdList.dwItem1));
            }
            else if (@event == Shell32.SHCNE.SHCNE_UPDATEIMAGE)
            {
                var dwordAsIdList = Marshal.PtrToStructure<Shell32.SHChangeDWORDAsIDList>(pidl1);

                SystemImageListChanged?.Invoke(
                    this,
                    new SystemImageListChangedEventArgs(dwordAsIdList.dwItem1));
            }
            else if (@event == Shell32.SHCNE.SHCNE_EXTENDED_EVENT)
            {
                var dwordAsIdList = Marshal.PtrToStructure<Shell32.SHChangeDWORDAsIDList>(pidl1);

                ExtendedEventOccurred?.Invoke(
                    this,
                    new ShellExtendedEventNotifyEventArgs(dwordAsIdList.dwItem1));
            }
            else
            {
                UnrecognizedEventOccurred?.Invoke(
                    this,
                    new ShellNotifyEventArgs());
            }
        }

        private Shell32.SHCNE ToSHCNE(ShellEventFilters notifyFilters)
        {
            Shell32.SHCNE shcne = 0;

            if (notifyFilters.HasFlag(ShellEventFilters.AllEvents))
            {
                shcne = Shell32.SHCNE.SHCNE_ALLEVENTS;
            }
            else
            {
                if (notifyFilters.HasFlag(ShellEventFilters.ItemEvents))
                {
                    shcne |= Shell32.SHCNE.SHCNE_CREATE
                        | Shell32.SHCNE.SHCNE_DELETE
                        | Shell32.SHCNE.SHCNE_UPDATEITEM
                        | Shell32.SHCNE.SHCNE_RENAMEITEM;
                }

                if (notifyFilters.HasFlag(ShellEventFilters.ItemAttributesChanged))
                {
                    shcne |= Shell32.SHCNE.SHCNE_ATTRIBUTES;
                }

                if (notifyFilters.HasFlag(ShellEventFilters.FolderEvents))
                {
                    shcne |= Shell32.SHCNE.SHCNE_MKDIR
                        | Shell32.SHCNE.SHCNE_RMDIR
                        | Shell32.SHCNE.SHCNE_UPDATEDIR
                        | Shell32.SHCNE.SHCNE_RENAMEFOLDER;
                }

                if (notifyFilters.HasFlag(ShellEventFilters.DriveEvents))
                {
                    shcne |= Shell32.SHCNE.SHCNE_MEDIAINSERTED
                        | Shell32.SHCNE.SHCNE_MEDIAREMOVED
                        | Shell32.SHCNE.SHCNE_DRIVEREMOVED
                        | Shell32.SHCNE.SHCNE_DRIVEADD;
                }

                if (notifyFilters.HasFlag(ShellEventFilters.ShareStatusChanged))
                {
                    shcne |= Shell32.SHCNE.SHCNE_NETSHARE
                        | Shell32.SHCNE.SHCNE_NETUNSHARE;
                }

                if (notifyFilters.HasFlag(ShellEventFilters.FreespaceChanged))
                {
                    shcne |= Shell32.SHCNE.SHCNE_FREESPACE;
                }

                if (notifyFilters.HasFlag(ShellEventFilters.AssocChanged))
                {
                    shcne |= Shell32.SHCNE.SHCNE_ASSOCCHANGED;
                }

                if (notifyFilters.HasFlag(ShellEventFilters.SystemImageListChanged))
                {
                    shcne |= Shell32.SHCNE.SHCNE_UPDATEIMAGE;
                }

                if (notifyFilters.HasFlag(ShellEventFilters.ExtendedEvents))
                {
                    shcne |= Shell32.SHCNE.SHCNE_EXTENDED_EVENT;
                }
            }

            return shcne;
        }
    }
}
