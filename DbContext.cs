using UserEntityNamespace;
using ProductEntityNamespace;
using OrderEntityNamespace;

namespace dataBase {
    public class DbContext {
        public List<UserEntity?> Users { get; set; }
        public List<ProductEntity?> Products { get; set; }

        public List<OrderEntity?> Orders { get; set; }
    
    public DbContext() {
            Users = new List<UserEntity?>();
            Products = new List<ProductEntity?>();
            Orders = new List<OrderEntity?>();
        }

    } 
    }