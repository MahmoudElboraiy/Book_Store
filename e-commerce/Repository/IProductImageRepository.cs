using e_commerce.Models;

namespace e_commerce.Repository
{
    public interface IProductImageRepository:IRepository<ProductImage>
    {
        void Update(ProductImage obj);
    }
}
