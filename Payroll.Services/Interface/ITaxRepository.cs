﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Services.Interface
{
    public interface ITaxRepository
    {
        decimal TaxAmount(decimal totalAmount);
    }
}
