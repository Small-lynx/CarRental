using CarRental.Beb.Models;
using CarRental.BL;
using CarRental.BL.Contract;
using CarRental.BL.Contract.Model;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Data.Entity;
using System.Diagnostics;

namespace CarRental.Beb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarManeger carManeger;

        public HomeController(ILogger<HomeController> logger, ICarManeger carManeger)
        {
            _logger = logger;
            this.carManeger = carManeger;
        }

        public async Task<IActionResult> Index()
        {
            var cars = await carManeger.GetCars(CancellationToken.None);
            var statistic = await carManeger.GetStatistic(CancellationToken.None);
            var model = new Tuple<IEnumerable<Car>, CarStatustic>(cars, statistic);
            return View(model);
        }

        [HttpGet("edit")]
        public IActionResult Edit()
        {
            return View(new Car());
        }

        [HttpGet("edit/{id?}")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            Car? car = null;
            if (id.HasValue)
            {
                car = await carManeger.GetCar((Guid)id, CancellationToken.None);
                if (car == null)
                {
                    return NotFound();
                }
            }
            return View(car ?? new Car());
        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit(Car car)
        {
            if (ModelState.IsValid)
            {
                if (car.Id == Guid.Empty) // Новый объект
                {
                    await carManeger.Add(new CarRequest(car.CarMake,
                    car.StateNumber,
                    car.Mileage,
                    car.AvgFuelConsumption,
                    car.FuelVolume,
                    car.RentalCost),
                    CancellationToken.None);
                    return RedirectToAction("Index");
                }
                else // Существующий объект
                {
                    await carManeger.Edit(car.Id, new CarRequest(car.CarMake,
                    car.StateNumber,
                    car.Mileage,
                    car.AvgFuelConsumption,
                    car.FuelVolume,
                    car.RentalCost),
                    CancellationToken.None);
                }
                return RedirectToAction("Index");
            }
            return View(car);  
        }

        [HttpPost("delete/{id?}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await carManeger.Delete(id, CancellationToken.None);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
