namespace ShellSpy;

public sealed class ShellExtendedEventNotifyEventArgs(ShellExtendedEventType eventId) : ShellNotifyEventArgs
{
    public ShellExtendedEventType EventId { get; } = eventId;
}
