using GeekSeat.Entity.Entities;
using GeekSeat.Service.Infrasturctures;
using GeekSeat.Service.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace GeekSeat.Test
{
    public class SuperAwesomeTest
    {
        private IWitchService _witchService;

        [SetUp]
        public void Setup()
        {
            _witchService = new WitchService();
        }

        [Test]
        public void TestVillagerEntity()
        {
            var villager = new Villager(10, 12);
            Assert.AreEqual(2, villager.BirthYear);
            var peopleKilled = _witchService.GetFibonaciSumAt(villager.BirthYear);
            Assert.AreEqual(2, peopleKilled);

            villager = new Villager(13, 17);
            Assert.AreEqual(4, villager.BirthYear);
            peopleKilled = _witchService.GetFibonaciSumAt(villager.BirthYear);
            Assert.AreEqual(7, peopleKilled);

            villager = new Villager(10, 9);
            Assert.AreEqual(-1, villager.BirthYear);
            peopleKilled = _witchService.GetFibonaciSumAt(villager.BirthYear);
            Assert.AreEqual(-1, peopleKilled);

            villager = new Villager(10, 10);
            Assert.AreEqual(-1, villager.BirthYear);
            peopleKilled = _witchService.GetFibonaciSumAt(villager.BirthYear);
            Assert.AreEqual(-1, peopleKilled);
        }

        [Test]
        public void TestFibonnaciGenerator()
        {
            var validTest = _witchService.GetFibonaciSumAt(1);
            Assert.AreEqual(1, validTest);

            validTest = _witchService.GetFibonaciSumAt(2);
            Assert.AreEqual(2, validTest);

            validTest = _witchService.GetFibonaciSumAt(3);
            Assert.AreEqual(4, validTest);

            validTest = _witchService.GetFibonaciSumAt(4);
            Assert.AreEqual(7, validTest);

            validTest = _witchService.GetFibonaciSumAt(5);
            Assert.AreEqual(12, validTest);

            validTest = _witchService.GetFibonaciSumAt(10);
            Assert.AreEqual(143, validTest);

            var invalidTest = _witchService.GetFibonaciSumAt(-1);
            Assert.AreEqual(-1, invalidTest);
        }

        [Test]
        public void LetsDefeatTheWitchTest()
        {
            var villagers = new List<Villager>
            {
                new Villager(10, 12),
                new Villager(13, 17)
            };

            var average = _witchService.CalculateAverageDeath(villagers);
            Assert.AreEqual(4.5, average);

            villagers = new List<Villager>
            {
                new Villager(11, 10),
                new Villager(13, 17)
            };

            average = _witchService.CalculateAverageDeath(villagers);
            Assert.AreEqual(3, average);

            villagers = new List<Villager>
            {
                new Villager(10, 12),
                new Villager(10, 12),
                new Villager(13, 17)
            };

            average = _witchService.CalculateAverageDeath(villagers);
            Assert.AreEqual(3.6666, average, 0.0001);

            villagers = new List<Villager>
            {
                new Villager(13, 10),
                new Villager(13, 10),
                new Villager(13, 10)
            };
            average = _witchService.CalculateAverageDeath(villagers);
            Assert.AreEqual(-1, average);
        }
    }
}