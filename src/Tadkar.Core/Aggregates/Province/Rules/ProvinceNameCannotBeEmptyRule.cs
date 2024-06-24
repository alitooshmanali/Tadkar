using Tadkar.Core.Properties;

namespace Tadkar.Core.Aggregates.Province.Rules
{
    internal class ProvinceNameCannotBeEmptyRule : IBusinessRule
    {
        private readonly string name;

        public ProvinceNameCannotBeEmptyRule(string name)
        {
            this.name = name;
        }

        public string Message => CoreResources.ProvinceNameCannotBeEmpty;

        public bool IsBroken()
        {
            return string.IsNullOrWhiteSpace(name);
        }
    }
}
