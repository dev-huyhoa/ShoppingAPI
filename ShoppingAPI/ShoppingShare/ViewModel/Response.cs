﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingShare.ViewModel
{
    public class Response
    {
        public object Data {  get; set; }
        public string Messsage { get; set; }
        public bool Success { get; set; }
        public string Description { get; set; }
    }
}
