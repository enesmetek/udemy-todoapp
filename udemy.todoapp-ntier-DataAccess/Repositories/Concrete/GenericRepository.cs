using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using udemy.todoapp_ntier_DataAccess.Context;
using udemy.todoapp_ntier_DataAccess.Repositories.Abstract;
using udemy.todoapp_ntier_Entities.Concrete;

namespace udemy.todoapp_ntier_DataAccess.Repositories.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ToDoContext _context;

        public GenericRepository(ToDoContext context)
        {
            _context = context;
        }


        public async Task Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
            var updatedEntity = _context.Set<T>().Find(entity.ID);
            _context.Entry(updatedEntity).CurrentValues.SetValues(entity);
            
            //_context.Set<T>().Update(entity);
        }

        public void Remove(object id)
        {
            var deletedEntity = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(deletedEntity);
        }

        public async Task<T> GetByID(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            return asNoTracking ? _context.Set<T>().SingleOrDefaultAsync(filter) : _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<List<T>> GetAll()
        {
             return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public IQueryable<T> GetQuery()
        {
            return _context.Set<T>().AsQueryable();
        }
    }
}
