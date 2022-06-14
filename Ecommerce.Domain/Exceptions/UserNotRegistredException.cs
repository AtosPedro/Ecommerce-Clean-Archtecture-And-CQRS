using System.Runtime.Serialization;

namespace Ecommerce.Domain.Exceptions
{
    [Serializable]
    public class UserNotRegistredException : Exception
    {
        public UserNotRegistredException(string message = "O usuário não foi cadastrado") : base(message) {}
        protected UserNotRegistredException(SerializationInfo info, StreamingContext ctxt) : base(info, ctxt) { }
    }
}
