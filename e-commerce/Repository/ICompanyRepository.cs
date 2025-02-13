using e_commerce.Models;

namespace e_commerce.Repository
{
    public interface ICompanyRepository :IRepository<Company>
    {
        void Update (Company company);
    }
}
