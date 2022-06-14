using System.Runtime.Serialization;

namespace Ecommerce.Domain.Exceptions
{
    [Serializable]
    public class InvalidIdException : Exception
    {
        public InvalidIdException(string message) : base(message) { }
        protected InvalidIdException(SerializationInfo info, StreamingContext ctxt) : base(info, ctxt) { }
    }
}
