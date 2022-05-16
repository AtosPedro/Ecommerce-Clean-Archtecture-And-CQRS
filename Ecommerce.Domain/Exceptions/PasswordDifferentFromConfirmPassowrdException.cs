using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Exceptions
{
    public class PasswordConfirmationException : Exception
    {
        private const string _message = "A senha não é igual a confirmação da senha";
        public PasswordConfirmationException(string message = _message) : base(message) { }
    }
}
