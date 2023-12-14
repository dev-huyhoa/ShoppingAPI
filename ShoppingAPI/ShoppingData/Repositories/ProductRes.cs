using Microsoft.AspNetCore.Http;
using ShoppingContext.Model;
using ShoppingData.Interfaces;
using ShoppingShare.Ultilities;
using ShoppingShare.ViewModel;
using ShoppingShare.ViewModel.Employee;
using ShoppingShare.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingData.Repositories
{
    public class ProductRes : IProduct
    {
        private readonly ShopContext _db;
        private Response res;
        public ProductRes(ShopContext db)
        {
            _db = db;
            res = new Response();
        }


        public Response GetProduct()
        {
            try
            {
                var product = (from x in _db.Products
                               where x.IsDelete == false
                               select new
                               {
                                   Product = x,
                                   SizeList = (from y in _db.ProductSize
                                               where y.ProductId == x.IdProduct
                                               select y.SizeId).ToList(),

                                   ImageUrls = (from pd in _db.ProductImages
                                                where pd.ProductId == x.IdProduct
                                               select pd.imageUrl).ToList()      
                               }).ToList();
                res.Data = product;
                res.Success = true;
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = ex.Message;    
            }
            return res;
        }

        public Response CreateProductDetail(ProductDetailViewModel input)
        {
            try
            {
                ProductSize productSize = new ProductSize();
                productSize.IdProductSize = new Guid();
                productSize.ProductId = input.ProductId;
                productSize.Quantity = input.Quantity;
                _db.ProductSize.Add(productSize);
                _db.SaveChanges();
                res.Message = "Thêm mới thành công ";
                res.Success = true;
            }
            catch (Exception)
            {
                res.Message = "Thêm mới thất bại ";
                res.Success = false;
            }
            return res;
        }
        public Response CreateProduct(ProductViewModel input, ICollection<IFormFile> files)
        {
            try
            {
                Product product = new Product();
                product.IdProduct = new Guid();
                product.Title = input.Title;
                product.Price = input.Price;
                product.PriceSale =  (input.Price * 5)/100;
                product.Description = input.Description;
                product.CategoryId = input.CategoryId;
                _db.Products.Add(product);

                ProductImage productImage = new ProductImage();
                foreach (var file in files)
                {
                    productImage.IdProductImage = new Guid();
                    productImage.IdProductImage = product.IdProduct;
                    productImage.imageUrl = Ultility.WriteFile(file, "Product", productImage.IdProductImage.ToString());
                    _db.ProductImages.Add(productImage);
                    _db.SaveChanges();
                }            
                _db.SaveChanges();
                res.Message = "Thêm mới thành công ";
                res.Success = true;
            }
            catch (Exception ex)
            {
                res.Message = "Thêm mới thất bại !";
                res.Success = false;
            }
            return res;
        }
        public Response GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
