using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // get the cars category id 
               builder.HasData(
                new Product
                {
                     Id=1,
                    Title="مرسيدس",
                    CreationDate=DateTime.Now,
                     CategoryID=1,
                },
                new Product
                {
                    Id = 2,
                    Title = "اودي",
                    TitleEN= "Audi",
                    CreationDate = DateTime.Now,
                    CategoryID = 1,
                }
                );
        }
    }
}
