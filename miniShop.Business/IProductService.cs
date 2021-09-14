using miniShop.Models;
using System.Collections.Generic;

namespace miniShop.Business
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}