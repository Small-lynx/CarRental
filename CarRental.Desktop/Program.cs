using CarRental.BL;
using CarRental.Storage.InMemory;
using CarRental.Storage.SQL;
using Serilog;
using Serilog.Extensions.Logging;
using System.Configuration;

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

            var logger = new LoggerConfiguration()
            .MinimumLevel.Debug() // Уровень логирования
            .WriteTo.Seq("http://localhost:5341", apiKey: "false") // URL вашего Seq сервера
            .CreateLogger();
            var micLogger = new SerilogLoggerFactory(logger)
                .CreateLogger(nameof(CarRental.Desktop.Program));

            var connectionString = ConfigurationManager.ConnectionStrings["CarRentalConnectionString"]?.ConnectionString;

            var storage = new CarRentalStorage(connectionString, micLogger);
            var manager = new CarManeger(storage, micLogger);
            Application.Run(new MainForm(manager));
        }
    }
}