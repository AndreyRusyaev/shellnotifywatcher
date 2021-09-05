# Shell Notifications Watcher

Managed C# wrapper for SHChangeNotify and SHCNE_ events.

```cs
using ShellNotifyWatcher watcher = new ShellNotifyWatcher
{
    Path = "C:\\",
    Recursive = true,
    EventFilters = ShellEventFilters.AllEvents
};

// Item/Folder events
watcher.ItemChanged += (obj, e) => Console.WriteLine("{0} {1} {2}", e.ChangeType, e.ItemType, e.Path);
watcher.ItemRenamed += (obj, e) => Console.WriteLine("{0} {1} {2} -> {3}", e.ChangeType, e.ItemType, e.OldPath, e.NewPath);
watcher.DriveChanged += (obj, e) => Console.WriteLine("{0} {1}", e.ChangeType, e.Path);
watcher.ShareChanged += (obj, e) => Console.WriteLine("ShareStatusChanged: {0} {1}", e.Status, e.Path);

// Global events
watcher.FreespaceChanged += (obj, e) => Console.WriteLine("FreespaceChanged Drives: {0}", string.Join(", ", e.Drives));
watcher.ServerDisconnected += (obj, e) => Console.WriteLine("ServerDisconnected");
watcher.FileTypeAssociationChanged += (obj, e) => Console.WriteLine("FileTypeAssociationChanged");
watcher.SystemImageListChanged += (obj, e) => Console.WriteLine("SystemImageListChanged ImageIndex: {0}", e.ImageIndex);
watcher.ExtendedEventOccurred += (obj, e) => Console.WriteLine("ExtendedEventOccurred EventId: {0}", e.EventId);

watcher.EnableRaisingEvents = true;
```
