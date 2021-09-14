using miniShop.DataAccess.Repositories;
using miniShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniShop.Business
{
    public class FakeProductService : IProductService
    {
        private IProductRepostiory productRepostiory;

        public FakeProductService(IProductRepostiory productRepostiory)
        {
            this.productRepostiory = productRepostiory;
        }
        public List<Product> GetProducts()
        {
            return productRepostiory.SelectAll().ToList();
        }
    }
}
