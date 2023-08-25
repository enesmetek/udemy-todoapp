using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using udemy.todoapp_ntier_DataAccess.Context;
using udemy.todoapp_ntier_DataAccess.Repositories.Abstract;
using udemy.todoapp_ntier_DataAccess.Repositories.Concrete;
using udemy.todoapp_ntier_DataAccess.UnitOfWork.Abstract;

namespace udemy.todoapp_ntier_DataAccess.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ToDoContext _context;

        public UnitOfWork(ToDoContext context)
        {
            _context = context;
        }

        public IGenericRepository<T> GetRepository<T>() where T : class, new()
        {
            return new GenericRepository<T>(_context);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
