using ProductEntityNamespace;
using IProductRepositoryNamespace;
using dataBase;


namespace ProductRepositoryNamespace
{
    public class ProductRepository : IProductRepository
    {
        private DbContext _dbContext; 

       public ProductRepository(DbContext dbContext)
        {
            _dbContext = dbContext; 
        }


        public int Create(ProductEntity product)
        {
            product.ProductId = _dbContext.Products.Count;
            _dbContext.Products.Add(product);
            return product.ProductId; // Повертаємо ID нового продукту
        }

        public IEnumerable<ProductEntity?> GetAll()
        {
            return _dbContext.Products!;
        }


        public ProductEntity? Read(int productId)
        {
             return _dbContext.Products.FirstOrDefault(prod => prod?.ProductId == productId);
        }

      
        public void Update(ProductEntity product)
        {

            if (IsProductExistById(product.ProductId)) {
                _dbContext.Products[product.ProductId] = product; // Оновлюємо товар
            }
        }

      
        public void Delete(int productId)
        {
            var product = Read(productId);
            if(IsProductExistById(productId)){
                 _dbContext.Products.Remove(product);
            }
        }

     
       
        public bool IsProductExistById(int productId)
        {
            return _dbContext.Products.Any(prod => prod?.ProductId == productId); // Перевіряє, чи є елемент із заданим ID
        }
    }
}
