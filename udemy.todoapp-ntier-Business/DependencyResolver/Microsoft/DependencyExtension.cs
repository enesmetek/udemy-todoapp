using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using udemy.todoapp_ntier_Business.Mappings.AutoMapper;
using udemy.todoapp_ntier_Business.Services.Abstract;
using udemy.todoapp_ntier_Business.Services.Concrete;
using udemy.todoapp_ntier_Business.ValidationRules;
using udemy.todoapp_ntier_DataAccess.Context;
using udemy.todoapp_ntier_DataAccess.UnitOfWork.Abstract;
using udemy.todoapp_ntier_DataAccess.UnitOfWork.Concrete;
using udemy.todoapp_ntier_DTO.WorkDTOs;

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

            var configuration = new MapperConfiguration(options =>
            {
                options.AddProfile(new WorkProfile());
            });

            var mapper = configuration.CreateMapper();

            services.AddSingleton(mapper);

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IWorkService, WorkService>();

            services.AddTransient<IValidator<WorkCreateDTO>, WorkCreateDTOValidator>();
            services.AddTransient<IValidator<WorkUpdateDTO>, WorkUpdateDTOValidator>();

        }
    }
}