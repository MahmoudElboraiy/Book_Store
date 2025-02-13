using e_commerce.Models;

namespace e_commerce.Repository
{
    public interface IOrderDetailRepository:IRepository<OrderDetail>
    {
        void Update (OrderDetail orderDetail);
    }
}
