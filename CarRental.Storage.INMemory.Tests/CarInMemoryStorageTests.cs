using CarRental.BL.Contract.Model;
using CarRental.Storage.Contract;
using FluentAssertions;
using Moq;
using Xunit;

namespace CarRental.Storage.InMemory.Tests
{
    public class CarInMemoryStorageTests
    {
        private readonly IStorage<Car> storage;
        private readonly Mock<Microsoft.Extensions.Logging.ILogger> logger;
        public CarInMemoryStorageTests() 
        {
            storage = new CarInMemoryStorage(logger.Object);
        }

        /// <summary>
        /// Не найдена сущность <see cref="Car"/>
        /// </summary>
        [Fact]
        public async Task GetReturnNull()
        {
            // Act
            var result = await storage.Get(Guid.NewGuid(), CancellationToken.None);
            // Assert
            result.Should().BeNull();
        }

        /// <summary>
        /// Добавление и возврат сущности <see cref="Car"/>
        /// </summary>
        [Fact]
        public async Task AddAndGetReturnCar()
        {
            //Arage
            var car = CreateTestCar();
            // Act
            await storage.Add(car, CancellationToken.None);
            var result = await storage.Get(car.Id, CancellationToken.None);
            // Assert
            result.Should().NotBeNull()
                .And.BeEquivalentTo(car);
        }

        /// <summary>
        /// Возвращение коллекции сущностей <see cref="Car"/>
        /// </summary>
        [Fact]
        public async Task GetAllReturnCar()
        {
            //Arage
            var car = CreateTestCar();
            await storage.Add(car, CancellationToken.None);
            // Act
            var result = await storage.GetAll(CancellationToken.None);
            // Assert
            result.Should().NotBeEmpty()
                .And.ContainSingle(x => x.Id == car.Id);
        }

        /// <summary>
        /// Удаление несущесвуюшей сущности <see cref="Car"/>
        /// </summary>
        [Fact]
        public async Task DeleteNonExistentCar()
        {
            // Act
            Func<Task> result = () => storage.Delete(Guid.NewGuid(), CancellationToken.None);
            // Assert
            await result.Should().ThrowAsync<InvalidOperationException>();
        }

        /// <summary>
        /// Удаление сущности <see cref="Car"/>
        /// </summary>
        [Fact]
        public async Task DeletetCar()
        {
            //Arage
            var car = CreateTestCar();
            await storage.Add(car, CancellationToken.None);
            // Act
            Func<Task> act = () => storage.Delete(car.Id, CancellationToken.None);
            // Assert
            await act.Should().NotThrowAsync();
            var result = await storage.Get(car.Id,CancellationToken.None);
            result.Should().BeNull();
        }

        /// <summary>
        /// Изменение несущесвуюшей сущности <see cref="Car"/>
        /// </summary>
        [Fact]
        public async Task EditNonExistentCar()
        {
            // Act
            Func<Task> result = () => storage.Edit(Guid.NewGuid(), new Car(), CancellationToken.None);
            // Assert
            await result.Should().ThrowAsync<InvalidOperationException>();
        }

        /// <summary>
        /// Изменение сущности <see cref="Car"/>
        /// </summary>
        [Fact]
        public async Task EditCar()
        {
            //Arage
            var car = CreateTestCar();
            var newCar = new Car(){ Id = Guid.NewGuid() };
            await storage.Add(car, CancellationToken.None);
            // Act
            Func<Task> act = () => storage.Edit(car.Id, newCar, CancellationToken.None);
            // Assert
            await act.Should().NotThrowAsync();
            var result = await storage.Get(newCar.Id, CancellationToken.None);
            result.Should().NotBeNull()
                .And.BeEquivalentTo(newCar);
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
