using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using udemy.todoapp_ntier_DataAccess.Configurations;
using udemy.todoapp_ntier_Entities.Concrete;

namespace udemy.todoapp_ntier_DataAccess.Context
{
    public class ToDoContext : DbContext
    {
        //Buradaki olayın mantığı nedir, neden yapılır? 
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {

        }

        public DbSet<Work> Works { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WorkConfiguration());
        }
    }
}