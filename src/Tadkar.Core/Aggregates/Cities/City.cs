using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tadkar.Core.Aggregates.Cities.Rules;
using Tadkar.Core.Aggregates.Personnels;

namespace Tadkar.Core.Aggregates.Cities
{
    public class City: Entity
    {
        private City() { }

        [Key]
        public int Id { get; private set; }

        public string Name { get; private set; }

        public int Province_Id { get; set; }


        public static City Create(string name)
        {
            var city = new City();

            CheckRule(new CityNameCannotBeEmptyRule(name));

            city.Name = name;

            return city;
        }

        public void ChnageName(string name)
        {
            if (Name == name)
                return;

            CheckRule(new CityNameCannotBeEmptyRule(name));

            Name = name;
        }


        [ForeignKey("Province_Id")]
        public virtual Province.Province Province { get; set; }

        public virtual ICollection<Personnel> Personnels { get; set; } = new List<Personnel>();
    }
}
