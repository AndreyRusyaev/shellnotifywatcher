using System;

using ShellSpy;

namespace WatcherSample
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            string? sourcePath = args.Length > 0 ? args[0] : Environment.GetEnvironmentVariable("SYSTEMDRIVE");

            using ShellNotifyWatcher watcher = new ShellNotifyWatcher
            {
                Path = sourcePath,
                Recursive = true,
                IncludeShellNotifications = true,
                EventFilters = ShellEventFilters.AllEvents
            };

            // Shell item events
            watcher.ItemChanged += (obj, e) => Console.WriteLine("{0} {1} '{2}'", e.ChangeType, e.ItemType, e.Path);
            watcher.ItemRenamed += (obj, e) => Console.WriteLine("{0} {1} '{2}' -> '{3}'", e.ChangeType, e.ItemType, e.OldPath, e.NewPath);
            watcher.DriveChanged += (obj, e) => Console.WriteLine("{0} '{1}'", e.ChangeType, e.Path);
            watcher.ShareChanged += (obj, e) => Console.WriteLine("ShareStatusChanged: {0} '{1}'", e.Status, e.Path);

            // Global events
            watcher.FreespaceChanged += (obj, e) => Console.WriteLine("FreespaceChanged Drives: [{0}]", string.Join(", ", e.Drives));
            watcher.ServerDisconnected += (obj, e) => Console.WriteLine("ServerDisconnected");
            watcher.FileTypeAssociationChanged += (obj, e) => Console.WriteLine("FileTypeAssociationChanged");
            watcher.SystemImageListChanged += (obj, e) => Console.WriteLine("SystemImageListChanged ImageIndex: {0}", e.ImageIndex);
            watcher.ExtendedEventOccurred += (obj, e) => Console.WriteLine("ExtendedEventOccurred EventId: {0}", e.EventId);

            watcher.EnableRaisingEvents = true;

            Console.WriteLine("Listening for shell notifications.");
            Console.WriteLine("Path: '{0}'", watcher.Path);
            Console.WriteLine("Recursive: {0}", watcher.Recursive);
            Console.WriteLine("Events: {0}", watcher.EventFilters);
            Console.WriteLine("Try to add/remove a file in the Windows Explorer (explorer.exe) and see what happens.");

            while (true)
            {
                Console.WriteLine("Press 'Esc' or 'q' key to exit ...");

                var key = Console.ReadKey();
                if(key.Key == ConsoleKey.Escape || key.Key == ConsoleKey.Q)
                {
                    break;
                }
                Console.WriteLine();
            }
        }
    }
}
