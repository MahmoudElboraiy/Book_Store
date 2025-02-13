using e_commerce.Models;

namespace e_commerce.Repository
{
    public interface IApplicationUserRepository:IRepository<ApplicationUser>
    {
        void Update(ApplicationUser applicationUser);
    }
}
