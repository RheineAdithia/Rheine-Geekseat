using GeekSeat.Entity.Infrastructures;
using System.Collections.Generic;

namespace GeekSeat.Service.Infrasturctures
{
    public interface IWitchService
    {
        /// <summary>
        /// Calculate the sum of fibonaci sequence
        /// </summary>
        /// <param name="iteration">iteration of fibonaci sequence</param>
        /// <returns>Sum value of all the fibonaci sequence</returns>
        public int GetFibonaciSumAt(int iteration);

        /// <summary>
        /// Calculate the average death of all the dead villagers
        /// </summary>
        /// <typeparam name="T">Needs to be the interface of IVillager</typeparam>
        /// <param name="villagers">The dead villagers</param>
        /// <returns>Average value from the dead villagers</returns>
        public double CalculateAverageDeath<T>(List<T> villagers)
            where T : IBirthYear;
    }
}
