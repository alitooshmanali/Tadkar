using System.ComponentModel.DataAnnotations;
using Tadkar.Core.Aggregates.Cities;
using Tadkar.Core.Aggregates.Province.Rules;

namespace Tadkar.Core.Aggregates.Province
{
    public class Province: Entity
    {
        private Province() { }

        [Key]
        public int Id { get; set; }

        public string Name { get; private set; }

        public static Province Create(string name)
        {
            var province = new Province();

            CheckRule(new ProvinceNameCannotBeEmptyRule(name));

            province.Name = name;

            return province;
        }

        public void ChangeName(string name)
        {
            if(Name == name)
                return;

            CheckRule(new ProvinceNameCannotBeEmptyRule(name));

            Name = name;
        }


        public virtual ICollection<City> Cities { get; set; } = new List<City>();
    }
}
