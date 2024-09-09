using ApiEx.Interface;
using ApiEx.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiEx.Service
{
    public class CompanyService
    {
        private readonly ICompany _com;

        public CompanyService(ICompany com)
        {
            _com = com;
        }

        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            return await _com.GetAllCompanies();
        }

        public async Task<Company> GetCompanyById(int id)
        {
            return await _com.GetCompanyById(id);
        }
        public async Task AddCompany(Company company)
        {
            await _com.AddCompany(company);
        }
    }
}
