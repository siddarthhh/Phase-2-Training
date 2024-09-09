using ApiEx.Models;

namespace ApiEx.Interface
{
    public interface ICompany
    {
        Task<IEnumerable<Company>> GetAllCompanies();
        Task<Company> GetCompanyById(int id);

        Task AddCompany(Company company);


    }
}
