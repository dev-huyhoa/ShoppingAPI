﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingContext.Model
{
    public class ProductSize
    {
        public Guid IdProductSize { get; set; }
        public int SizeId { get; set; }
        public Size Size { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public bool IsDelete { get; set; }
    }
}
