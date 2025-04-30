using CarRental.BL;
using CarRental.BL.Contract;
using CarRental.BL.Contract.Model;
using CarRental.Storage.Contract;
using CarRental.Storage.SQL;

namespace CarRental.Beb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CarRental.Storage.SQL.CarRentalContext;Integrated Security=True;";

            builder.Services.AddScoped<IStorage<Car>>(provider =>
        new CarRentalStorage(connectionString, null));
            builder.Services.AddScoped<ICarManeger>(provider =>
        new CarManeger(provider.GetRequiredService<IStorage<Car>>(), null));
            builder.Services.AddControllersWithViews();
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
