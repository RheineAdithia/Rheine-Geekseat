using GeekSeat.Entity.Infrastructures;
using GeekSeat.Service.Infrasturctures;
using System.Collections.Generic;
using System.Linq;

namespace GeekSeat.Service.Services
{
    public class WitchService : IWitchService
    {
        #region Inheritance
        /// <summary>
        /// Calculate the average death of all the dead villagers
        /// </summary>
        /// <typeparam name="T">Needs to be the interface of IVillager</typeparam>
        /// <param name="villagers">The dead villagers</param>
        /// <returns>Average value from the dead villagers</returns>
        public double CalculateAverageDeath<T>(List<T> villagers) where T : IBirthYear
        {
            if (villagers.Count() == 0)
            {
                return -1;
            }

            double sum = 0;
            foreach (var item in villagers)
            {
                sum += GetFibonaciSumAt(item.BirthYear);
            }

            return sum / villagers.Count();
        }

        /// <summary>
        /// Calculate the sum of fibonaci sequence
        /// </summary>
        /// <param name="iteration">iteration of fibonaci sequence</param>
        /// <returns>Sum value of all the fibonaci sequence</returns>
        public int GetFibonaciSumAt(int iteration)
        {
            if (iteration <= 0)
            {
                return -1;
            }

            var sum = 0;
            foreach (var item in GetFibonaciSequence(iteration))
            {
                sum += item;
            }

            return sum;
        } 
        #endregion

        #region Private Methods
        private IEnumerable<int> GetFibonaciSequence(int sequence)
        {
            var firstnum = 1;
            var secondnum = 1;
            int thirdnum;

            for (int i = 0; i < sequence; i++)
            {
                if (i == 0)
                {
                    yield return firstnum;
                }
                else if (i == 1)
                {
                    yield return secondnum;
                }
                else
                {
                    thirdnum = firstnum + secondnum;
                    firstnum = secondnum;
                    secondnum = thirdnum;

                    yield return thirdnum;
                }
            }
        } 
        #endregion
    }
}
