﻿using ShoppingContext.Model;
using ShoppingShare.ViewModel;
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
        Response DeleteCustomer(Guid IdCustomer);
        Response SendPassCus(string email, string subject);
        Response GetListCusDeleted();

        string CustomerLogin(string email, string password);
    }
}
