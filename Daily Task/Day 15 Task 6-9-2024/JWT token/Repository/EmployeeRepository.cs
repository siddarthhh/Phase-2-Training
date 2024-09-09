using ApiEx.Interface;
using ApiEx.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiEx.Repository
{
    public class EmployeeRepository : IEmployee
    {
        private readonly CompanyDbContext _context;

        public EmployeeRepository (CompanyDbContext context)
        {
            _context = context;
        }

        public async Task AddEmployee(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

        }

        

        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            return await _context.Employees.Include(c=>c.company).ToListAsync();
        }
        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(o => o.EmpId == id);
        }

        public async Task UpdateEmployee(Employee employee)
        {
            var existingEmployee = await _context.Employees.FindAsync(employee.EmpId);

            if (existingEmployee == null)
            {
                throw new Exception("Employee not found.");
            }

            _context.Entry(existingEmployee).CurrentValues.SetValues(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployee(int id)
        {
            var employee =  await _context.Employees.FindAsync(id) ?? new Employee();

            if (employee == null)
            {
                throw new Exception("Employee not found.");
            }

            _context.Employees.Remove(employee);

            await _context.SaveChangesAsync();
        }



    }
}
