using ShoppingContext.Model;
using ShoppingData.Interfaces;
using ShoppingShare.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingData.Repositories
{
    public class CartRes: ICart
    {
        private readonly ShopContext _db;
        private Response res;
        public CartRes(ShopContext db)
        {
            _db = db;
            res = new Response();
        }

        public bool InsertCartItem(Guid customerId, Guid productId)
        {
            try
            {
                var querry = (from x in _db.Carts
                             where x.CustomerId == customerId && x.Ordered == false
                             select x).ToList();
                int count = querry.Count;
                if (count == 0)
                {
                    Cart cart = new Cart();
                    cart.IdCart = new Guid();
                    cart.CustomerId = customerId;
                    cart.Ordered = false;
                    _db.SaveChanges();
                }
                var sql = (from x in _db.Carts
                          where x.CustomerId == customerId && x.Ordered == false
                          select x).FirstOrDefault();
                Guid idCart = sql.IdCart;

                CartItem cartItem = new CartItem();
                cartItem.CartItemId = new Guid();
                cartItem.IdCart = idCart;
                cartItem.ProductId = productId; 
                _db.SaveChanges(); 
            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }
    }
}
