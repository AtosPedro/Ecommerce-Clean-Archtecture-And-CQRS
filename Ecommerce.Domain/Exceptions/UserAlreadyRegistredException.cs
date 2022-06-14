using System.Runtime.Serialization;

namespace Ecommerce.Domain.Exceptions
{
    [Serializable]
    public class UserAlreadyRegistredException : Exception
    {
        public UserAlreadyRegistredException(string message = "O usuário já foi cadastrado") : base(message) {}
        protected UserAlreadyRegistredException(SerializationInfo info, StreamingContext ctxt) : base(info, ctxt) { }
    }
}
