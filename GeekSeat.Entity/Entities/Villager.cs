using GeekSeat.Entity.Infrastructures;

namespace GeekSeat.Entity.Entities
{
    public class Villager : IBirthYear
    {
        public int AgeOfDeath { get; set; }
        public int YearOfDeath { get; set; }
        public int BirthYear
        {
            get
            {
                var birthYear = YearOfDeath - AgeOfDeath;
                return birthYear <= 0 ? -1 : birthYear;
            }
        }

        public Villager()
        {

        }

        public Villager(int ageOfDeath, int yearOfDeath)
        {
            AgeOfDeath = ageOfDeath;
            YearOfDeath = yearOfDeath;
        }
    }
}
