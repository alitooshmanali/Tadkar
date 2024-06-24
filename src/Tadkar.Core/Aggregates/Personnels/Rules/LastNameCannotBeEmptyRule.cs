using Tadkar.Core.Properties;

namespace Tadkar.Core.Aggregates.Personnels.Rules
{
    internal class LastNameCannotBeEmptyRule : IBusinessRule
    {
        private readonly string lastName;

        public LastNameCannotBeEmptyRule(string lastName)
        {
            this.lastName = lastName;
        }

        public string Message => CoreResources.LastNameCannotBeEmpty;

        public bool IsBroken()
        {
            return string.IsNullOrWhiteSpace(lastName);
        }
    }
}
