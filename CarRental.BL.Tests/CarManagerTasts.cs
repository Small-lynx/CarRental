using CarRental.BL.Contract;
using CarRental.BL.Contract.Model;
using CarRental.Storage.Contract;
using Castle.Core.Logging;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using Xunit.Sdk;

namespace CarRental.BL.Tests
{
    public class CarManagerTasts
    {
        private readonly ICarManeger maneger;
        private readonly Mock<IStorage<Car>> storage;
        private readonly Mock<Microsoft.Extensions.Logging.ILogger> logger;

        public CarManagerTasts() 
        {
            storage = new();
            logger = new();
            maneger = new CarManeger(storage.Object, logger.Object);
        }

        /// <summary>
        /// Возвращение пустой коллекции сущностей <see cref="Car"/>
        /// </summary>
        [Fact]
        public async Task GetReturnEmpty()
        {
            // Arrange
            storage.Setup(x => x.GetAll(It.IsAny<CancellationToken>()))
                .ReturnsAsync([]);
            // Act
            var result = await maneger.GetCars(CancellationToken.None);
            // Assert
            result.Should().BeEmpty();
            storage.Verify(x => x.GetAll(It.IsAny<CancellationToken>()), Times.Once);
        }

        /// <summary>
        /// Возвращение коллекции сущностей <see cref="Car"/>
        /// </summary>
        [Fact]
        public async Task GetReturnCars()
        {
            // Arrange
            var car = CreateTestCar();
            storage.Setup(x => x.GetAll(It.IsAny<CancellationToken>()))
                .ReturnsAsync([car]);
            // Act
            var result = await maneger.GetCars(CancellationToken.None);
            // Assert
            result.Should().NotBeEmpty()
                .And.HaveCount(1)
                .And.ContainSingle(x => x.Id == car.Id);
            storage.Verify(x => x.GetAll(It.IsAny<CancellationToken>()), Times.Once);
        }

        /// <summary>
        /// Добавление сущности <see cref="Car"/>
        /// </summary>
        [Fact]
        public async Task AddCar()
        {
            // Arrange
            var car = CreateTestCar();
            var carList = new List<Car>();
            storage.Setup(x => x.Add(It.IsAny<Car>(), It.IsAny<CancellationToken>()))
                .Callback<Car, CancellationToken>((item, token) => { carList.Add(car); })
                .Returns(Task.CompletedTask);
            storage
                .Setup(x => x.GetAll(It.IsAny<CancellationToken>()))
                .ReturnsAsync(carList);
            // Act
            await maneger.Add(new CarRequest(
                car.CarMake,
                car.StateNumber,
                car.Mileage,
                car.AvgFuelConsumption,
                car.FuelVolume,
                car.RentalCost), CancellationToken.None);
            var result = await maneger.GetCars(CancellationToken.None);
            // Assert
            result.Should().NotBeEmpty()
               .And.HaveCount(1)
               .And.ContainSingle(x => x.Id == car.Id);
            storage.Verify(x => x.Add(It.IsAny<Car>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        /// <summary>
        /// Удаление несущесвуюшей сущности <see cref="Car"/>
        /// </summary>
        [Fact]
        public async Task DeleteNonExistentCar()
        {
            // Arrange
            var id = Guid.NewGuid();
            // Act
            Func<Task> result = () => maneger.Delete(id, CancellationToken.None);
            // Assert
            await result.Should().ThrowAsync<InvalidOperationException>();
        }

        /// <summary>
        /// Изменение несущесвуюшей сущности <see cref="Car"/>
        /// </summary>
        [Fact]
        public async Task EditNonExistentCar()
        {
            var car = CreateTestCar();
            // Act
            Func<Task> result = () => maneger.Edit(Guid.NewGuid(), new CarRequest(
                car.CarMake,
                car.StateNumber,
                car.Mileage,
                car.AvgFuelConsumption,
                car.FuelVolume,
                car.RentalCost), CancellationToken.None);
            // Assert
            await result.Should().ThrowAsync<InvalidOperationException>();
        }

        /// <summary>
        /// Изменение сущности <see cref="Car"/> c невалидными данными
        /// </summary>
        [Fact]
        public async Task EditInvalidtCar()
        {
            var car = CreateTestCar();
            // Act
            Func<Task> result = () => maneger.Edit(Guid.NewGuid(), new CarRequest(string.Empty, string.Empty, 0, 0, 0, 0), CancellationToken.None);
            // Assert
            await result.Should().ThrowAsync<ArgumentException>();
        }

        /// <summary>
        /// Изменение сущности <see cref="Car"/>
        /// </summary>
        [Fact]
        public async Task EditCar()
        {
            // Arrange
            var car = CreateTestCar();
            var carEdit = CreateTestCar();
            carEdit.CarMake = "Лада";
            var carList = new List<Car>();
            storage.Setup(x => x.Add(It.IsAny<Car>(), It.IsAny<CancellationToken>()))
                .Callback<Car, CancellationToken>((item, token) => { carList.Add(car); })
                .Returns(Task.CompletedTask);
            storage.Setup(x => x.Edit(It.Is<Guid>(y => y == car.Id), It.IsAny<Car>(), It.IsAny<CancellationToken>()))
                .Callback<Guid, Car, CancellationToken>((id, item, token) =>
                {
                    carList[carList.IndexOf(carList.First(x => x.Id == id))] = item;
                })
                .Returns(Task.CompletedTask);
            storage.Setup(x => x.GetAll(It.IsAny<CancellationToken>()))
                .ReturnsAsync(carList);
            // Act
            await maneger.Add(new CarRequest(
                car.CarMake,
                car.StateNumber,
                car.Mileage,
                car.AvgFuelConsumption,
                car.FuelVolume,
                car.RentalCost), CancellationToken.None);
            await maneger.Edit(car.Id, (new CarRequest(
                carEdit.CarMake,
                carEdit.StateNumber,
                carEdit.Mileage,
                carEdit.AvgFuelConsumption,
                carEdit.FuelVolume,
                carEdit.RentalCost)), CancellationToken.None);
            var result = await maneger.GetCars(CancellationToken.None);
            // Assert
            result.Should().NotBeEmpty()
               .And.HaveCount(1)
               .And.ContainSingle(x => x.Id == car.Id && x.CarMake == carEdit.CarMake);
            storage.Verify(x => x.Edit(It.Is<Guid>(y => y == car.Id), It.IsAny<Car>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        /// <summary>
        /// Возврат статистики <see cref="CarStatustic"/>
        /// </summary>
        [Fact]
        public async Task GetStaticticCar()
        {
            // Arrange
            storage.Setup(x => x.GetAll(It.IsAny<CancellationToken>()))
                .ReturnsAsync([]);
            // Act
            var result = await maneger.GetStatistic(CancellationToken.None);
            // Assert
            result.Should().NotBeNull()
                .And.BeOfType<CarStatustic>();
        }
        /// <summary>
        /// Создание тестовой сущности <see cref="Car"/>
        /// </summary>
        private static Car CreateTestCar()
        {
            var car = new Car()
            {
                Id = Guid.NewGuid(),
                CarMake = "Хёндай крета",
                StateNumber = "A123AE95",
                Mileage = 2580,
                AvgFuelConsumption = 3.8m,
                FuelVolume = 15.5m,
                RentalCost = 11.48m,
            };
            return car;
        }
    }
}
