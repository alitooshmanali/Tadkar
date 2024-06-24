using Tadkar.Core.Exceptions;

namespace Tadkar.Core
{
    public abstract class Entity
    {
        private bool _canBeDeleted;

        protected Entity() { }


        public bool CanBeDeleted() => _canBeDeleted;

        protected void MarkAsDeleted() => _canBeDeleted = true;

        protected static void CheckRule(IBusinessRule rule)
        {
            if (!rule.IsBroken())
                return;

            throw new DomainException(rule.Message);
        }

    }
}
