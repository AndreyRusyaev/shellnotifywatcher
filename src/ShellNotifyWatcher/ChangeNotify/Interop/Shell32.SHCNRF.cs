namespace ShellSpy.ChangeNotify.Interop
{
    internal static partial class Shell32
    {
        public enum SHCNRF
        {
            SHCNRF_InterruptLevel = 0x0001,
            SHCNRF_ShellLevel = 0x0002,
            SHCNRF_RecursiveInterrupt = 0x1000,
            SHCNRF_NewDelivery = 0x8000,
        }
    }
}
