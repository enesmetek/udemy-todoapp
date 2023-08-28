using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using udemy.todoapp_ntier_Entities.Concrete;

namespace udemy.todoapp_ntier_DataAccess.Repositories.Abstract
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task Create(T entity);

        void Update(T entity, T unchanged);

        void Remove(T entity);

        Task<T> GetByID(object id);

        Task<List<T>> GetAll();   
        
        Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false);

        IQueryable<T> GetQuery();
    }
}
