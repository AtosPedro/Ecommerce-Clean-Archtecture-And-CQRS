using Ecommerce.Application.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace Ecommerce.Infrastructure.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        private readonly IConfiguration _configuration;
        public PasswordHasher(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ComputeHash(string password, string salt, string pepper, int iteration)
        {
            if (iteration <=0)
                return password;

            using var sha256 = SHA256.Create();
            var passwordSaltPepper = $"{password}{salt}{pepper}";
            var byteValue = Encoding.UTF8.GetBytes(passwordSaltPepper);
            var byteHash = sha256.ComputeHash(byteValue);
            var hash = Convert.ToBase64String(byteHash);
            return ComputeHash(hash, salt, pepper, iteration - 1);
        }

        public string GenerateSalt()
        {
            using var rng = RandomNumberGenerator.Create();
            var byteSalt = new byte[16];
            rng.GetBytes(byteSalt);
            var salt = Convert.ToBase64String(byteSalt);
            return salt;
        }

        public string GetPepper()
        {
            string pepper = _configuration.GetValue<string>("PepperHash");
            return pepper;
        }
        
        public int GetIterations()
        {
            int iteration = _configuration.GetValue<int>("PasswordIterations");
            return iteration;
        }

    }
}
