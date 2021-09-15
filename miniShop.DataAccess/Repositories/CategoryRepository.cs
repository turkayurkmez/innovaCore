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
    public class CategoryRepository : ICategoryRepository
    {
        private InnovaShopDbContext dbContext;

        public CategoryRepository(InnovaShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public int Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Category> SelectAll()
        {
            return dbContext.Categories;
        }

        public IQueryable<Category> SelectWithCriteria(Expression<Func<Category, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Category Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
