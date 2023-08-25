using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using udemy.todoapp_ntier_Business.Services.Abstract;
using udemy.todoapp_ntier_Business.Services.Concrete;
using udemy.todoapp_ntier_DataAccess.Context;
using udemy.todoapp_ntier_DataAccess.UnitOfWork.Abstract;
using udemy.todoapp_ntier_DataAccess.UnitOfWork.Concrete;

namespace udemy.todoapp_ntier_Business.DependencyResolver.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<ToDoContext>(options =>
            {
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ToDoDB;Integrated Security=true;");
                options.LogTo(Console.WriteLine, LogLevel.Information);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IWorkService, WorkService>();
        }
    }
}