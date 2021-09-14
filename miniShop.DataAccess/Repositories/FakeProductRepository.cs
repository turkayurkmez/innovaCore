using miniShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace miniShop.DataAccess.Repositories
{
   public class FakeProductRepository : IProductRepostiory
    {

        List<Product> fakeList = new List<Product>
           {
               new Product{ Id=1, Name ="Product A", Price=100, ImageUrl="https://cdn.dsmcdn.com//ty25/product/media/images/20201124/22/31552537/111694429/1/1_org.jpg", Description="Product Desc.", Discount=0.10, CategoryId=2},

               new Product{ Id=2, Name ="Product b", Price=100, ImageUrl="https://cdn.dsmcdn.com//ty25/product/media/images/20201124/22/31552537/111694429/1/1_org.jpg", Description="Product Desc.", Discount=0.15, CategoryId = 1},

               new Product { Id = 3, Name = "Product c", Price = 100, ImageUrl = "https://cdn.dsmcdn.com//ty25/product/media/images/20201124/22/31552537/111694429/1/1_org.jpg", Description = "Product Desc.", Discount = 0.18, CategoryId = 1 },


               new Product { Id = 4, Name = "Product d", Price = 100, ImageUrl = "https://cdn.dsmcdn.com//ty25/product/media/images/20201124/22/31552537/111694429/1/1_org.jpg", Description = "Product Desc.", Discount = 0.30, CategoryId = 2 },


               new Product { Id = 5, Name = "Product e", Price = 100, ImageUrl = "https://cdn.dsmcdn.com//ty25/product/media/images/20201124/22/31552537/111694429/1/1_org.jpg", Description = "Product Desc.", Discount = 0.10, CategoryId = 1 },

           };
        public int Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> GetProductsByName(string name)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> SelectAll()
        {
            return fakeList.AsQueryable();
        }

        public IQueryable<Product> SelectWithCriteria(Expression<Func<Product, bool>> predicate)
        {
            return fakeList.AsQueryable().Where(predicate);
        }

        public Product Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
