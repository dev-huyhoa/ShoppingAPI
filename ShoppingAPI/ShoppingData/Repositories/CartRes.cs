using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using ShoppingContext.Model;
using ShoppingData.Interfaces;
using ShoppingShare.ViewModel;
using ShoppingShare.ViewModel.Cart;
using ShoppingShare.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
                    _db.Carts.Add(cart);
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
                _db.CartItems.Add(cartItem);
                _db.SaveChanges(); 
            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }

        public CartViewModel GetActiveCartOfUser(Guid customerId)
        {
            var cart = new CartViewModel();
            try
            {
                var result = (from x in _db.Carts
                              where x.CustomerId == customerId
                              select x).ToList();
                int count = result.Count;
                if(count == 0)
                {
                    return cart;
                }

                var querry = (from x in _db.Carts
                              where x.CustomerId == customerId && x.Ordered == false
                              select x).FirstOrDefault();

                if (querry == null)
                {
                    return cart;
                }


                var cartItem = (from x in _db.CartItems
                                where x.IdCart == querry.IdCart
                                select x).ToList();

                foreach (var item in cartItem)
                {
                    CartItemViewModel itemCart = new()
                    {
                        Id = item.CartItemId,
                        Product = GetProduct(item.ProductId)
                    };
                    
                    cart.CartItems.Add(itemCart);
                }
                cart.Id = querry.IdCart;
                cart.Customer = GetCustomer(customerId);
                cart.Ordered = false;
                cart.OrderedOn = querry.OrderedOn;

            }
            catch (Exception)
            {

                throw;
            }
            return cart;
        }

        public ProductCategory GetProduct(Guid productId)
        {
            var product = new ProductCategory();
            try
            {
                var result = (from x in _db.Products
                              where x.IdProduct == productId
                              select x).FirstOrDefault();
                    product.Id = result.IdProduct;
                    product.Title = result.Title;
                    product.Description = result.Description;
                    product.Price = result.Price;
                    product.Quantity = result.Quantity;
                    product.ImageName = "";
                    product.Discount = result.Discount;
                    var categoryId = result.CategoryId;
                    product.Category = GetProductCategory(categoryId);
              
            }
            catch (Exception)
            {

                throw;
            }
            return product;
        }
        public CusVMD GetCustomer(Guid customerId)
        {
            var customer = new CusVMD();
            try
            {
                var result = (from x in _db.Customers
                              where x.IdCustomer == customerId
                              select x).FirstOrDefault();
                customer.Id = result.IdCustomer;
                customer.LastName = result.NameCustomer;
                customer.Email = result.Email;
                customer.Mobile = result.Phone;
                customer.Address = result.Phone;
            }
            catch (Exception)
            {

                throw;
            }
            return customer;
        }
        public CategoryViewModel GetProductCategory(int id)
        {
            var productCategory = new CategoryViewModel();

            try
            {
                var result = (from x in _db.Categories
                              where x.IdCategory == id
                              select x).ToList();
                foreach (var item in result)
                {
                    productCategory.IdCategory = item.IdCategory;
                    productCategory.Title = item.Title;
                    productCategory.SubCategory = item.SubCategory;
                    productCategory.TitleEN = item.TitleEN;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return productCategory;
        }

        public List<CartViewModel> GetAllPreviousCartsOfUser(Guid idCustomer)
        {
            var carts = new List<CartViewModel>();
            try
            {
                var result = (from x in _db.Carts
                              where x.CustomerId == idCustomer && x.Ordered == true
                              select x).ToList();
                if (result != null)
                {
                    foreach (var item in result)
                    {
                        carts.Add(GetCart(item.IdCart));
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return carts;
        }

        public CartViewModel GetCart(Guid cartId)
        {
            var cart = new CartViewModel();

            try
            {
                var result = (from x in _db.CartItems
                              where x.IdCart == cartId
                              select x).FirstOrDefault();
             
                    CartItemViewModel item = new()
                    {
                        Id = result.CartItemId,
                        Product = GetProduct(result.ProductId)
                    };
                    cart.CartItems.Add(item);

                var querry = (from x in _db.Carts
                              where x.IdCart == cartId
                              select x).FirstOrDefault();
                cart.Id = querry.IdCart;
                cart.Customer = GetCustomer(querry.CustomerId);
                cart.Ordered = querry.Ordered;
                cart.OrderedOn = querry.OrderedOn;
            }
            catch (Exception)
            {
                throw;
            }
            return cart;
        }
    }
}
