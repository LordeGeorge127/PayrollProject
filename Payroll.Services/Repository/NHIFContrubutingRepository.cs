using Payroll.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Services.Repository
{
    public class NHIFContrubutingRepository : INHIFContrubutingRepository
    {
        private decimal NHIFRate;
        private decimal NHIFCAmount;
        public decimal NHIFContribution(decimal totalAmount)
        {
            if (totalAmount < 719)
            {
                //Lower earning Limit Rate & below Primary threshold
                NHIFRate = .0m;
                NHIFCAmount = 0m;
            }else if (totalAmount >= 719 && totalAmount <= 4167)
            {
                //between primary threshhold and upperearnings limit
                NHIFRate = .12m;
                NHIFCAmount = ((totalAmount - 719) * NHIFRate);

            }
            else if (totalAmount > 4167)
            {
                //above upper earning limit
                NHIFRate = .02m;
                NHIFCAmount = ((4167 - 719) * .12m) + ((totalAmount - 4167) * NHIFRate);
            }
            return NHIFCAmount;
        }
    }
}
