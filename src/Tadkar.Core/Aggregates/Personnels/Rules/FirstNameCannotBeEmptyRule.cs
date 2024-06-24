using Tadkar.Core.Properties;

namespace Tadkar.Core.Aggregates.Personnels.Rules
{
    internal class FirstNameCannotBeEmptyRule : IBusinessRule
    {
        private readonly string firstName;

        public FirstNameCannotBeEmptyRule(string firstName)
        {
            this.firstName = firstName;
        }

        public string Message => CoreResources.FirstNameCannotBeEmpty;

        public bool IsBroken()
        {
            return string.IsNullOrWhiteSpace(firstName);
        }
    }
}
