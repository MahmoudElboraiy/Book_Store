using e_commerce.Data;
using e_commerce.Migrations;
using e_commerce.Models;

namespace e_commerce.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly ApplicationDbContext _db;

        public ShoppingCartRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
        public void Update(ShoppingCart shoppingCart)
        {
           _db.ShoppingCarts.Update(shoppingCart);
        }
    }
}
