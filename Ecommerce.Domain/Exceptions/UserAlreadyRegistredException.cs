namespace Ecommerce.Domain.Exceptions
{
    public class UserAlreadyRegistredException : Exception
    {
        private const string _message = "O usuário já foi cadastrado";
        public UserAlreadyRegistredException(string message = _message) : base(message) {}
    }
}
