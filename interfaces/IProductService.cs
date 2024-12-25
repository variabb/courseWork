using ProductEntityNamespace;

namespace IProductServiceNamespace
{
    public interface IProductService
    {
        IEnumerable<ProductEntity?> GetAllProducts(); //* Отримати всі товари
        ProductEntity? GetProductById(int productId); //* Отримати товар за ID
        void AddProduct(ProductEntity product); //* Додати товар
        void UpdateProduct(ProductEntity product); //* Оновити товар
        void DeleteProduct(int productId); //* Видалити товар
    }
}
