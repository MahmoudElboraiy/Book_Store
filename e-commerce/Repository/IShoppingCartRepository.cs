using e_commerce.Models;

namespace e_commerce.Repository
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        void Update(ShoppingCart shoppingCart); 
    }
}
