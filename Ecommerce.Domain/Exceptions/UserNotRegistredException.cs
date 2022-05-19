namespace Ecommerce.Domain.Exceptions
{
    public class UserNotRegistredException : Exception
    {
        private const string _message = "O usuário não foi cadastrado";
        public UserNotRegistredException(string message = _message) : base(message) {}
    }
}
