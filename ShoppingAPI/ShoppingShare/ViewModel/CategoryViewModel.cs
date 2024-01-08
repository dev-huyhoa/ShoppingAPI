using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingShare.ViewModel
{
    public class CategoryViewModel
    {
        public int IdCategory { get; set; }
        public string Title { get; set; }
        public bool IsDelete { get; set; }
        public string SubCategory { get; set; }
        public string TitleEN { get; set; }
    }
}
