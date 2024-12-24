using ProductEntityNamespace;

namespace IProductRepositoryNamespace
{
    public interface IProductRepository
    {
        int Create(ProductEntity product); //* product — це об'єкт типу ProductEntity
        IEnumerable<ProductEntity?> GetAll(); //* Метод повертає колекцію об'єктів типу ProductEntity, що дозволяє отримати список усіх продуктів.
        ProductEntity? Read(int ProductId); //* Повертає продукт за його унікальним ідентифікатором
        void Update(ProductEntity product); //* Оновлює існуючий продукт. Параметр product — це об'єкт ProductEntity з новими даними для продукту.
        void Delete(int ProductId); //* Видаляє продукт за його унікальним ідентифікатором ProductId
        bool IsProductExistById(int ProductId);
    }
}