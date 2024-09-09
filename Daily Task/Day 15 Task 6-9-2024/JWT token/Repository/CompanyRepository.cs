using ApiEx.Interface;
using ApiEx.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiEx.Repository
{
    public class CompanyRepository : ICompany
    {
        private readonly CompanyDbContext? _context;

        public CompanyRepository(CompanyDbContext? context)
        {
            _context = context;
        }

        public async Task AddCompany(Company company)
        {
            await _context.AddAsync(company);
            await _context.SaveChangesAsync() ;
        }

        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            return await _context.Companies.ToListAsync();
        }
        public async Task<Company> GetCompanyById(int id)
        {
            return await _context.Companies.FirstOrDefaultAsync(o => o.CompanyId == id);
        }

    }
}
