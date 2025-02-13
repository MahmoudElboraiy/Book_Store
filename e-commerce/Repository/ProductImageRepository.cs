using e_commerce.Data;
using e_commerce.Models;

namespace e_commerce.Repository
{
    public class ProductImageRepository : Repository<ProductImage>, IProductImageRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductImageRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
        public void Update(ProductImage obj)
        {
            _db.ProductImages.Update(obj);
        }
    }
}
