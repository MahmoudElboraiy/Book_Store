using e_commerce.Data;
using e_commerce.Models;

namespace e_commerce.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext db;

        public CategoryRepository(ApplicationDbContext _db) : base(_db)
        {
            db = _db;
        }

        public void Update(Category category)
        {
            db.Categories.Update(category);
        }
    }
}
