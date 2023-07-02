using Microsoft.AspNetCore.Mvc.Routing;
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
        private decimal HELB;
        private decimal fee;

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
            var employee = GetById(id);
            //if (employee.UnionMember == UnionMember.Yes)
            //{
            //    fee = 10m;
            //}
            //else
            //{
            //    fee = 0m;
            //};return fee;
            var fee= employee.UnionMember == UnionMember.Yes ? 10m : 0;
            return fee;
        }

        public decimal StudentLoanRepaymentAmount(int id, decimal totalAmount)
        {
            var employee = GetById(id);
            if (employee.StudentLoan == StudentLoan.Yes && totalAmount > 1750 && totalAmount < 2000)
            {
                HELB = 15m;
            }
            else if (employee.StudentLoan == StudentLoan.Yes && totalAmount >= 2000 && totalAmount < 2250)
            {
                HELB = 38m;
            }
            else if (employee.StudentLoan == StudentLoan.Yes && totalAmount >= 2250 && totalAmount < 2500)
            {
                HELB = 60m;
            }
            else if (employee.StudentLoan == StudentLoan.Yes && totalAmount >= 2500 )
            {
                HELB = 83m;
            }
            else
            {
                HELB = 0m;
            }
            return HELB;
        }
    }

   

        
}
