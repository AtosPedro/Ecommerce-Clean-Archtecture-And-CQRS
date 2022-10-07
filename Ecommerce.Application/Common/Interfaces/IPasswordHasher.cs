namespace Ecommerce.Application.Common.Interfaces
{
    public interface IPasswordHasher
    {
        string ComputeHash(string password, string salt, string pepper, int iteration);
        string GenerateSalt();
        string GetPepper();
        int GetIterations();
    }
}
