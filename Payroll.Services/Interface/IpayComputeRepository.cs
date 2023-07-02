using Microsoft.AspNetCore.Mvc.Rendering;
using Payroll.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Services.Interface
{
    public interface IpayComputeRepository
    {
        Task CreateAsync(PaymentRecord paymentRecord);
        PaymentRecord GetById(int id);
        IEnumerable<PaymentRecord> GetAll();
        IEnumerable<SelectListItem> GetAllTaxYear();
        decimal OvertimeHours(decimal hoursWorked, decimal contractualHours);
        decimal ContractualEarnings(decimal contractualHours, decimal hoursWorked, decimal HourlRate);
        decimal OvertimeRate(decimal hourlyRate);
        decimal OvertimeEarnings(decimal overtimeRate, decimal overtimeHours);
        decimal TotalEarnings(decimal overtieEarnings, decimal contractualEarnings);
        decimal TotalDeductions(decimal tax, decimal NHIFC, decimal studentLoanRepayment, decimal UnionFees);
        decimal NetPay(decimal totalEarnings, decimal totalDeductions);
    }
}
