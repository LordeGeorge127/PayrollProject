using Microsoft.EntityFrameworkCore;
using Payroll.Entity;
using Payroll.Persistence;
using Payroll.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Services.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Employee newEmployee)
        {
            await _context.Employees.AddAsync(newEmployee);
           await  _context.SaveChangesAsync();
        }
        public Employee GetById(int employeeId) => _context.Employees.Where(e => e.Id == employeeId).FirstOrDefault();


        public async Task DeleteAsync(int employeeId)
        {
            var employee =GetById(employeeId);
            _context.Remove(employee);
            await _context.SaveChangesAsync();  
        }

        public IEnumerable<Employee> GetAll() => _context.Employees;
        public async Task UpdateAsync(Employee employee)
        {
             _context.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id)
        {
           var employee = GetById(id);
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }

        public decimal UnionFees(int id)
        {
            throw new NotImplementedException();
        }

        public decimal StudentLoanRepaymentAmount(int id, decimal totalAmount)
        {
            throw new NotImplementedException();
        }
    }

   

        
}
