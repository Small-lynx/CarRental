using CarRental.BL;
using CarRental.Storage.InMemory;

namespace CarRental.Desktop
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var storage = new CarInMemoryStorage();
            var manager = new CarManeger(storage);
            Application.Run(new MainForm(manager));
        }
    }
}