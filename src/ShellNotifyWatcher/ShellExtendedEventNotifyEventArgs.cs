namespace ShellSpy
{
    public sealed class ShellExtendedEventNotifyEventArgs : ShellNotifyEventArgs
    {
        public ShellExtendedEventNotifyEventArgs(int eventId)
        {
            EventId = eventId;
        }

        public int EventId { get; }
    }
}
