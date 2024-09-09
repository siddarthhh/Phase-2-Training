using ApiEx.Interface;
using ApiEx.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiEx.Service
{
    public class EmployeeService
    {
        private readonly IEmployee _emp;
        
        public EmployeeService (IEmployee emp)
        {
            _emp = emp;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            return await _emp.GetAllEmployee();       
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _emp.GetEmployeeById(id);
        }
        public async Task AddEmployee(Employee employee)
        {
            await _emp.AddEmployee(employee);
        }

        public async Task UpdateEmployee(Employee employee)
        {
            await _emp.UpdateEmployee(employee);
        }
        public async Task DeleteEmployee(int id)
        {
          await _emp.DeleteEmployee(id);
        }
    }
}
