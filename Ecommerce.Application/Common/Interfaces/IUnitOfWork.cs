namespace Ecommerce.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> Commit();
        Task<bool> RollBack();
        void Dispose();
    }
}
