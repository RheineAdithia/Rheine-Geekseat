using GeekSeat.Entity.Entities;
using GeekSeat.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeekSeat.Main
{
    public class Program
    {
        #region Members
        private static List<Villager> _villagers = new List<Villager>();
        #endregion

        #region Main
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Adventurer! You're on a quest to kill the witch!");
            PopulateVillager();
            CalculateAverage();
        }
        #endregion

        #region Upper Layer
        private static void PopulateVillager()
        {
            Console.WriteLine("Let's populate the the villager first shall we?");
            var i = 1;
            string isFinish;
            do
            {
                Console.WriteLine();
                Console.WriteLine($"Villager {i} :");

                var ageOfDeath = RequestNumberFromUser("Age of Death :");
                var yearOfDeath = RequestNumberFromUser("Year of Death :");
                _villagers.Add(new(ageOfDeath, yearOfDeath));
                i++;

                Console.Write($"Is that all the villager in this village (Y/N) :");
                isFinish = Console.ReadLine();
            } while (!isFinish.Equals("Y", StringComparison.OrdinalIgnoreCase));
        }

        private static void CalculateAverage()
        {
            Console.WriteLine();
            var service = new WitchService();

            if (_villagers.Any())
            {
                var avg = service.CalculateAverageDeath(_villagers);
                Console.WriteLine($"The average death in this village is {avg:N2} people.");
            }
            else
            {
                Console.WriteLine($"There is no death in this village.");
            }

            Console.ReadLine();
        }
        #endregion

        #region Private Methods
        private static int RequestNumberFromUser(string message)
        {
            int? value;
            do
            {
                Console.Write(message);
                value = TryToParseValue();
            } while (value == null);

            return value.Value;
        }

        private static int? TryToParseValue()
        {
            var userInput = Console.ReadLine();

            try
            {
                return int.Parse(userInput);
            }
            catch (FormatException)
            {
                Console.WriteLine($"I'm pretty sure \"{userInput}\" is not a valid age!");
                return null;
            }
        }
        #endregion
    }
}
