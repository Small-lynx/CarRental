namespace CarRental.BL.Contract.Model;
/// <summary>
/// Данные машины
/// </summary>
/// <param name="CarMake">Марка машины</param>
/// <param name="StateNumber">Гос номер</param>
/// <param name="Mileage">Пробег</param>
/// <param name="AvgFuelConsumption">Средний расход топлива за час</param>
/// <param name="FuelVolume">Текущий объем топлива</param>
/// <param name="RentalCost">Стоимость аренды (за минуту)</param>
public record CarRequest(string CarMake, string StateNumber, decimal Mileage, decimal AvgFuelConsumption, decimal FuelVolume, decimal RentalCost) { }