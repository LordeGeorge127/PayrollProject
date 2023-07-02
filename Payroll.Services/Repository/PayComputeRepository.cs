using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class PayComputeRepository : IpayComputeRepository
    {
        private decimal contractualEarnings;
        private decimal overtimeHours;
        private readonly ApplicationDbContext _context;

        public PayComputeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public decimal ContractualEarnings(decimal contractualHours, decimal hoursWorked, decimal hourlyRate)
        {
            if (hoursWorked < contractualHours)
            {
                contractualEarnings = hoursWorked * hourlyRate;
            }
            else
            {
                contractualEarnings = contractualHours * hourlyRate;
            }
            return contractualEarnings;
        }

        public async Task CreateAsync(PaymentRecord paymentRecord)
        {
            await _context.PaymentRecords.AddAsync(paymentRecord);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<PaymentRecord> GetAll() => _context.PaymentRecords.OrderBy(p => p.EmployeeID);
       

        public IEnumerable<SelectListItem> GetAllTaxYear()
        {
            var allTaxYear = _context.TaxYears.Select(taxtyears => new SelectListItem()
            {
                Text = taxtyears.YearOfTax,
                Value = taxtyears.Id.ToString()

            }) ;
            return allTaxYear ;
            

        }

        public PaymentRecord GetById(int id)=> _context.PaymentRecords.Where(p => p.Id == id).FirstOrDefault();


        public decimal NetPay(decimal totalEarnings, decimal totalDeductions) => totalEarnings - totalDeductions;


        public decimal OvertimeEarnings(decimal overtimeRate, decimal overtimeHours) => overtimeRate * overtimeHours;
       

        public decimal OvertimeHours(decimal hoursWorked, decimal contractualHours)
        {
            if (hoursWorked<=contractualHours)
            {
                overtimeHours = 0.00m;
            }
            else if(hoursWorked > contractualHours){
                overtimeHours = hoursWorked - contractualHours;
            }
            return overtimeHours;
        }

        public decimal OvertimeRate(decimal hourlyRate) => hourlyRate * 1.5m;


        public decimal TotalDeductions(decimal tax, decimal NHIFC, decimal studentLoanRepayment, decimal unionFees) =>
            tax + NHIFC + studentLoanRepayment + unionFees;
      

        public decimal TotalEarnings(decimal overtimeEarnings, decimal contractualEarnings)
       => overtimeEarnings + contractualEarnings;
    }
}
