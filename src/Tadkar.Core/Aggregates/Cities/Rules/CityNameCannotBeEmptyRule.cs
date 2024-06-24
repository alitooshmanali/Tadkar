using Tadkar.Core.Properties;

namespace Tadkar.Core.Aggregates.Cities.Rules
{
    internal class CityNameCannotBeEmptyRule : IBusinessRule
    {
        private readonly string name;

        public CityNameCannotBeEmptyRule(string name)
        {
            this.name = name;
        }

        public string Message => CoreResources.CityNameCannotBeEmpty;

        public bool IsBroken()
        {
            return string.IsNullOrWhiteSpace(name);
        }
    }
}
