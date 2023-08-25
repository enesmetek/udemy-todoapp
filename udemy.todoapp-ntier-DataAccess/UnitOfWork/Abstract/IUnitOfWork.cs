using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using udemy.todoapp_ntier_DataAccess.Repositories.Abstract;

namespace udemy.todoapp_ntier_DataAccess.UnitOfWork.Abstract
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> GetRepository<T>() where T : class, new();

        Task SaveChanges();
    }
}
