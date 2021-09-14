using miniShop.DataAccess.Repositories;
using miniShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniShop.Business
{
    public interface ICategoryService
    {
        IList<Category> GetCategories();

    }
}
