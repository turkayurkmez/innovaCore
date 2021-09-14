using miniShop.DataAccess.Repositories;
using miniShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniShop.Business
{
    public class CategoryService : ICategoryService
    {
        private IRepository<Category> repository;

        public CategoryService(IRepository<Category> repository )
        {
            this.repository = repository;
        }
        public IList<Category> GetCategories()
        {
            return repository.SelectAll().ToList();
        }
    }
}
