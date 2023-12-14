﻿using Microsoft.AspNetCore.Http;
using ShoppingShare.ViewModel;
using ShoppingShare.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingData.Interfaces
{
    public interface IProduct
    {
        Response GetProduct();
        //Response GetProduct();
        //Response GetProduct();

        Response CreateProduct(ProductViewModel input, ICollection<IFormFile> files);
    }
}