using ShoppingShare.ViewModel.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingData.Interfaces
{
    public interface ICart
    {
        bool InsertCartItem(Guid customerId, Guid productId);
        CartViewModel GetActiveCartOfUser(Guid customerId);
        List<CartViewModel> GetAllPreviousCartsOfUser(Guid idCustomer);
    }
}
