namespace Ecommerce.Domain.Exceptions
{
    public class MaterialWithoutSupplierException : Exception
    {
        private const string _message = "O produto não possui um fornecedor";
        public MaterialWithoutSupplierException(string message = _message) : base (message){}
    }
}
