using System.Runtime.Serialization;

namespace Ecommerce.Domain.Exceptions
{
    [Serializable]
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message) : base(message) { }
        protected EntityNotFoundException(SerializationInfo info, StreamingContext ctxt) : base(info, ctxt) { }
    }
}
