using System.Runtime.Serialization;

namespace Tadkar.Core.Exceptions
{
    [Serializable]
    public class DomainException : ApplicationException
    {
        public DomainException(string message)
            : base(message)
        {
        }

        protected DomainException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
