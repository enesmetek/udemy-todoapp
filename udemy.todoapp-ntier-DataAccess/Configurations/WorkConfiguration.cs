using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using udemy.todoapp_ntier_Entities.Concrete;

namespace udemy.todoapp_ntier_DataAccess.Configurations
{
    public class WorkConfiguration : IEntityTypeConfiguration<Work>
    {
        public void Configure(EntityTypeBuilder<Work> builder)
        {
            //Bu kısmı tanımlamasak da Default Convention sayesinde isimlendirmeden dolayı ID direkt olarak primary key oluyor. Doğru mu?
            builder.HasKey(x => x.ID);

            builder.Property(x => x.Definition).HasMaxLength(500);
            builder.Property(x => x.Definition).IsRequired(true);

            builder.Property(x => x.IsCompleted).IsRequired(true); 
        }
    }
}
