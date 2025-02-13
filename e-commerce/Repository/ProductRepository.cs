using e_commerce.Data;
using e_commerce.Models;

namespace e_commerce.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext db;

        public ProductRepository(ApplicationDbContext _db):base(_db)
        {
            db = _db;
        }
        public void Update(Product product)
        {
            var productFromDB = db.Products.FirstOrDefault(u => u.Id == product.Id);
            if (productFromDB != null)
            {
                productFromDB.Title = product.Title;
                productFromDB.Description = product.Description;
                productFromDB.Price = product.Price;
                productFromDB.CategoryId = product.CategoryId;
                productFromDB.Price50 = product.Price50;
                productFromDB.Price100 = product.Price100;
                productFromDB.Author = product.Author;
                productFromDB.ISBN = product.ISBN;
                productFromDB.ListPrice = product.ListPrice;
                productFromDB.ProductImages = product.ProductImages;
                //if (product.ImageUrl != null)
                //{
                //    productFromDB.ImageUrl = product.ImageUrl;
                //}
            }

        }
    }
}
