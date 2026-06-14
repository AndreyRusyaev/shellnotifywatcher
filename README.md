# Shell Notifications Watcher

Managed C# wrapper for SHChangeNotify and SHCNE_ events.

[![NuGet Downloads](https://img.shields.io/nuget/dt/shellnotifywatcher)](https://www.nuget.org/packages/shellnotifywatcher)
[![NuGet Version](https://img.shields.io/nuget/v/shellnotifywatcher)](https://www.nuget.org/packages/shellnotifywatcher)

```cs
using var watcher = new ShellNotifyWatcher
{
    Path = "C:\\",
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
```

## Sample

```
dotnet run --project src/WatcherSample/WatcherSample.csproj
```

```sh
Listening for shell notifications.
Path: 'C:'
Recursive: True
Events: AllEvents
Try to add/remove a file in the Windows Explorer (explorer.exe) and see what happens.
Press 'Esc' or 'q' key to exit ...
Created Item 'C:\Temp\New Text Document.txt'
ExtendedEventOccurred EventId: 15
Updated Item 'C:\Temp'
Deleted Item 'C:\Users\User\AppData\Roaming\Microsoft\Windows\Recent\New Text Document.txt.lnk'
Created Item 'C:\Users\User\AppData\Roaming\Microsoft\Windows\Recent\New Text Document.txt.lnk'
Created Item 'New Text Document.txt'
Created Item 'New Text Document.txt'
Created Item 'New Text Document.txt'
FreespaceChanged Drives: [C:\]
Updated Directory 'C:\Users\User\AppData\Roaming\Microsoft\Windows\Recent'
q
```
