using dataBase;
using ProductEntityNamespace;
using IDatabaseSeederNamespace;

namespace DatabaseSeederNamespace
{
    public class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly DbContext _dbContext;

        public DatabaseSeeder(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            _dbContext.Products.AddRange(new List<ProductEntity>
            {
                new ProductEntity { ProductId = 0, ProductName = "Ноутбук", Price = 25000, Quantity = 10 },
                new ProductEntity { ProductId = 1, ProductName = "Смартфон", Price = 15000, Quantity = 20 },
                new ProductEntity { ProductId = 2, ProductName = "Навушники", Price = 2000, Quantity = 50 },
                new ProductEntity { ProductId = 3, ProductName = "Монітор", Price = 8000, Quantity = 15 }
            });
        }
    }
}
