using Payroll.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Services.Repository
{
    public class TaxRepository : ITaxRepository
    {
        private decimal taxRate;
        private decimal tax;

        public TaxRepository(Appl)
        {
            
        }
        public decimal TaxAmount(decimal totalAmount)
        {
            if (totalAmount <= 1042)
            {
                //tax Freee Rate
                taxRate = .0m;
                tax = totalAmount * taxRate;
            }else if (totalAmount > 1042 && totalAmount < 3125)
            {
                //Basic tax rate
                taxRate = .2m;
                //incomeTax 
                tax = (1042 * .0m) + ((totalAmount - 1042) * taxRate);

            }else if(totalAmount > 3125 && totalAmount <= 12500)
            {
                //higher tax rate will apply40%
                taxRate = .40m;
                //income tax
                tax = (1042 * .0m) + ((3125-1042) * .20m) + ((totalAmount - 3125) * taxRate);
            }else if (totalAmount > 12500)
            {
                taxRate = .45m;
                tax = (1042* .0m) + ((3125-1042) * .20m) +
                    ((12500_3125) * .40m) +((totalAmount - 12500) * taxRate);
            }
             return tax; 
        }
    }
}
