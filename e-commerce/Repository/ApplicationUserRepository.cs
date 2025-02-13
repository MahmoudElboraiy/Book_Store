using e_commerce.Data;
using e_commerce.Models;

namespace e_commerce.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db):base(db) 
        {
            _db = db;
        }
        public void Update(ApplicationUser applicationUser)
        {
           _db.ApplicationUsers.Update(applicationUser);
        }
    }
}
