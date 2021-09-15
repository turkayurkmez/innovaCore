using miniShop.DataAccess.Repositories;
using miniShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniShop.Business
{
    public class ProductService : IProductService
    {
        private IProductRepostiory productRepostiory;

        public ProductService(IProductRepostiory productRepostiory)
        {
            this.productRepostiory = productRepostiory;
        }

        public Product GetProduct(int id)
        {
            return productRepostiory.GetById(id);
        }

        public List<Product> GetProducts()
        {
            return productRepostiory.SelectAll().ToList();
        }

        public List<Product> GetProductsByCategoryId(int categoryId)
        {
            return productRepostiory.SelectWithCriteria(x => x.CategoryId == categoryId).ToList();
        }
    }
}
