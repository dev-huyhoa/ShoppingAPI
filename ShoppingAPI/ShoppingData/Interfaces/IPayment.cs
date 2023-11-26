﻿using ShoppingShare.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingData.Interfaces
{
    public interface IPayment
    {
        Response GetPayment();
        Response CreatePayment(CreatePaymentViewModel input);
    }
}
