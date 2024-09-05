namespace ShellSpy
{
    public sealed class ShellExtendedEventNotifyEventArgs : ShellNotifyEventArgs
    {
        public ShellExtendedEventNotifyEventArgs(ShellExtendedEventType eventId)
        {
            EventId = eventId;
        }

        public ShellExtendedEventType EventId { get; }
    }
}
