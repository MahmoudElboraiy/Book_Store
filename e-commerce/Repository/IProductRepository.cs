using e_commerce.Models;

namespace e_commerce.Repository
{
    public interface IProductRepository:IRepository<Product>
    {
        void Update(Product product);
    }
}
