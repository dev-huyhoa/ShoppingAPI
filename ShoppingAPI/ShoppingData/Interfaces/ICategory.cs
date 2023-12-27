using ShoppingContext.Model;
using ShoppingShare.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingData.Interfaces
{
    public interface ICategory
    {
        Response GetCategory();
        Response CreateCategory(CreateUpdateCategoryViewModel input);
        Response UpdateCategory(CreateUpdateCategoryViewModel input);
        Response DeleteCategory(int IdCategory);
        Response GetCategoryById(int IdCategory);

    }
}
