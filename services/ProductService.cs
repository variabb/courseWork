using ProductEntityNamespace;
using IProductServiceNamespace;
using IProductRepositoryNamespace;

namespace ProductServiceNamespace
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<ProductEntity?> GetAllProducts()
        {
            return _productRepository.GetAll();
        }

        public ProductEntity? GetProductById(int productId)
        {
            return _productRepository.Read(productId);
        }

        public void AddProduct(ProductEntity product)
        {
            _productRepository.Create(product);
        }

        public void UpdateProduct(ProductEntity product)
        {
            _productRepository.Update(product);
        }

        public void DeleteProduct(int productId)
        {
            _productRepository.Delete(productId);
        }
    }
}
