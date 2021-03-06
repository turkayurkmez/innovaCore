using miniShop.EFCore;
using miniShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace miniShop.DataAccess.Repositories
{
    public class ProductRepository : IProductRepostiory
    {
        private InnovaShopDbContext dbContext;

        public ProductRepository(InnovaShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
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
            return dbContext.Products.Find(id);
        }

        public IQueryable<Product> GetProductsByName(string name)
        {
            return SelectWithCriteria(p => p.Name.Contains(name));
        }

        public IQueryable<Product> SelectAll()
        {
            return dbContext.Products;
        }

        public IQueryable<Product> SelectWithCriteria(Expression<Func<Product, bool>> predicate)
        {
            return dbContext.Products.Where(predicate);
        }

        public Product Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
