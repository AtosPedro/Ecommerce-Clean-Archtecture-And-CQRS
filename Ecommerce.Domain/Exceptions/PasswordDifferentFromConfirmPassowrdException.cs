using System.Runtime.Serialization;

namespace Ecommerce.Domain.Exceptions
{
    [Serializable]
    public class PasswordConfirmationException : Exception
    {
        public PasswordConfirmationException(string message = "A senha não é igual a confirmação da senha") : base(message) { }
        protected PasswordConfirmationException(SerializationInfo info, StreamingContext ctxt) : base(info, ctxt) { }
    }
}
