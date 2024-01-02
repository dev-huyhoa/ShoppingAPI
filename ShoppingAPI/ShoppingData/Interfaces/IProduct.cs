using Microsoft.AspNetCore.Http;
using ShoppingContext.Model;
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
        Response UpdateProductImg(ProductViewModel input, ICollection<IFormFile> files);
        Response GetProductImg(Guid idProduct);
        Response DeleteProduct(Guid idProduct);

        //cus
        List<ProductCategory> GetProductCategories(int idCategory);
        ProductCategory GetProductById(Guid id);
        List<ProductCategory> GetProducts(int idCategory);
    }
}
