using e_commerce.Data;
using e_commerce.Models;

namespace e_commerce.Repository
{
    public class CompanyRepository:Repository<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext _db;

        public CompanyRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public void Update(Company company)
        {
            _db.Companies.Update(company);
        }
    }
}
