using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using ShoppingContext.Model;
using ShoppingData.Interfaces;
using ShoppingShare.Ultilities;
using ShoppingShare.ViewModel;
using ShoppingShare.ViewModel.Product;
using System.Data.Common;
using System.Security.Cryptography.Xml;

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
                               select x).ToList();
              
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

        public Response GetProductImg(Guid idProduct)
        {
            try
            {
                var productImg = (from x in _db.ProductImages
                               where x.IsDelete == false && x.ProductId == idProduct
                               select x).ToList();

                res.Data = productImg;
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
                product.PriceSale = input.Price;
                product.Description = input.Description;
                product.CategoryId = input.CategoryId;
                _db.Products.Add(product);
                _db.SaveChanges();

                ProductImage productImage = new ProductImage();
                foreach (var file in files)
                {
                    productImage.IdProductImage = new Guid();
                    productImage.ProductId = product.IdProduct;
                    productImage.imageUrl = Ultility.WriteFile(file, "Product", productImage.IdProductImage.ToString());
                    _db.ProductImages.Add(productImage);
                    _db.SaveChanges();
                }            
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

        public Response UpdateProductImg(ProductViewModel input, ICollection<IFormFile> files)
        {
            try
            {
                var result = (from x in _db.Products
                              where x.IdProduct == input.IdProduct
                              select x).FirstOrDefault();   
                if (result != null)
                {
                    result.IdProduct = input.IdProduct;
                    result.Title = input.Title;
                    result.Price = input.Price;
                    result.PriceSale = input.PriceSale;
                    result.Description = input.Description;
                    result.CategoryId = input.CategoryId;
                    _db.SaveChanges();
                }

                if (files.Count > 0)
                {
                    var productImg = (from x in _db.ProductImages
                                      where x.ProductId == input.IdProduct
                                      select x).ToList();
                    _db.ProductImages.RemoveRange(productImg);
                    _db.SaveChanges();

                    ProductImage productImage = new ProductImage();
                    foreach (var file in files)
                    {
                        productImage.IdProductImage = new Guid();
                        productImage.ProductId = result.IdProduct;
                        productImage.imageUrl = Ultility.WriteFile(file, "Product", productImage.IdProductImage.ToString());
                        _db.ProductImages.Add(productImage);
                        _db.SaveChanges();
                    }
                }
               
                res.Message = "Sửa thành công ";
                res.Success = true;
            }
            catch (Exception ex)
            {
                res.Message = "Thêm mới thất bại !";
                res.Success = false;
            }
            return res;
        }

        public Response DeleteProduct(Guid idProduct)
        {
            try
            {
                var product = (from x in _db.Products
                                  where x.IdProduct == idProduct
                                  select x).FirstOrDefault();

                var productImg = (from x in _db.ProductImages
                                  where x.ProductId == idProduct
                                  select x).ToList();



                if (product != null)
                {
                    foreach (var img in productImg)
                    {
                        img.IsDelete = true;
                    }
                    product.IsDelete = true;
                    res.Success = true;
                    res.Message = "Xóa thành công!";
                    _db.SaveChanges();
                }
                else
                {
                    res.Message = "Không tìm thấy sản phẩm !";
                    res.Success = false;
                }
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = ex.Message;
            }
            return res;
        }



        #region Customer
        public List<ProductCategory> GetProductCategories(int idCategory)
        {
            var products = new List<ProductCategory>();
            try
            {

                var result = (from x in _db.Products
                              where x.IsDelete == false && x.CategoryId == idCategory
                              select x).ToList();
                foreach (var item in result)
                {
                    var productItem = new ProductCategory();
                    productItem.Id = item.IdProduct;
                    productItem.Title = item.Title;
                    productItem.Description = item.Description;
                    productItem.Price = item.Price;
                    productItem.PriceSale = item.PriceSale;
                    productItem.Quantity = item.Quantity;
                    productItem.Discount = item.Discount;
                    productItem.Category = GetProductCategory(idCategory);
                    products.Add(productItem);
                }
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = ex.Message;
            }
            return products;

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

        public ProductCategory GetProductById(Guid id)
        {
            var product = new ProductCategory();
            try
            {
                var result = (from x in _db.Products
                              where x.IdProduct == id
                              select x).FirstOrDefault();
                product.Id = result.IdProduct;
                product.Title = result.Title;
                product.Description = result.Description;
                product.Quantity = result.Quantity;
                product.Price = result.Price;
                product.PriceSale = result.PriceSale;
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

        public List<ProductCategory> GetProducts(int idCategory)
        {
            var products = new List<ProductCategory>();
            try
            {
                var result = (from x in _db.Products
                              where x.CategoryId == idCategory
                              select x).ToList();

                foreach (var item in result)
                {
                    var product = new ProductCategory();
                    product.Id = item.IdProduct;
                    product.Title = item.Title;
                    product.Description = item.Description;
                    product.Quantity = item.Quantity;
                    product.Price = item.Price;
                    product.PriceSale = item.PriceSale;
                    product.Discount = item.Discount;
                    var categoryId = item.CategoryId;
                    product.Category = GetProductCategory(categoryId);
                    products.Add(product);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return products;
        }


        #endregion
    }
}
