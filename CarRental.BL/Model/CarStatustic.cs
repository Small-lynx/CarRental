using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BL.Model
{
    /// <summary>
    /// Статистика проката
    /// </summary>
    /// <param name="countRent">Кол-во автомобилей в прокате</param>
    /// <param name="countFuel">Кол-во автомобилей с критическим уровнем топлива</param>
    public record CarStatustic(int countRent, int countFuel)
    {
    }
}
