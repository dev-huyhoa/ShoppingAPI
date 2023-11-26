using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingContext.Model
{
    public class Review
    {
        public Guid IdReview { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public bool IsDelete { get; set; }
    }
}
