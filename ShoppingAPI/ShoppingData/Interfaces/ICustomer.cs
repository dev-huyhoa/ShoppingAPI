﻿using ShoppingShare.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingData.Interfaces
{
    public interface ICustomer
    {
        Response GetCustomer();
        Response CreateCustomer(CreateCustomerViewModel input);
        Response UpdateCustomer(CreateCustomerViewModel input);
    }
}
