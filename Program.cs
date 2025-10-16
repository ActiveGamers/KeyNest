using KeyNest;
using SQLitePCL;

namespace KeyNest
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Initialize SQLitePCL.raw
            Batteries.Init();

            ApplicationConfiguration.Initialize();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}