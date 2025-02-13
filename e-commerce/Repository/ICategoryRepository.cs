using e_commerce.Models;
using System.Linq.Expressions;

namespace e_commerce.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);
    }
}
