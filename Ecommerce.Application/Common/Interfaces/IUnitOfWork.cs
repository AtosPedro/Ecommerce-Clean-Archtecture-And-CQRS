namespace Ecommerce.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        public Task<int> Commit();
        public Task<bool> RollBack();
        public void Dispose();
    }
}
