using miniShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace miniShop.DataAccess.Repositories
{
   public interface IRepository<T> where T: IEntity, new()  
    {
        int Add(T entity);
        IQueryable<T> SelectAll();
        IQueryable<T> SelectWithCriteria(Expression<Func<T, bool>> predicate);

        T GetById(int id);

        T Update(T entity);
        void Delete(int id);
        void Delete(T entity);


    }
}
