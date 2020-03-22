using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Text;
using UdemiyNLayerProject.Core.Models;

namespace UdemiyNLayerProject.Data.Seeds
{
    class ProductSeed : IEntityTypeConfiguration<Product>
    {

        private readonly int[] _ids;

        public ProductSeed(int[] ids)
        {
            _ids=ids;

        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, Name = "Pilot kalem", Price = 12.05m, Stock = 1000, CategoryId = _ids[1] },

                new Product { Id = 2, Name = "kurşun kalem kalem", Price = 12.05m, Stock = 1000, CategoryId = _ids[1] },
                new Product { Id = 3, Name = "silgi kalem", Price = 20.05m, Stock = 1000, CategoryId = _ids[1] },
                new Product { Id = 4, Name = "faber silgi kalem", Price = 12.05m, Stock = 1000, CategoryId = _ids[1] },


                 new Product { Id = 5, Name = "kitap deferi", Price = 12.05m, Stock = 1000, CategoryId = _ids[2] },
                new Product { Id = 6, Name = "güzel yazı Defteri", Price = 20.05m, Stock = 1000, CategoryId = _ids[2] },
                new Product { Id = 7, Name = "defter kalem", Price = 12.05m, Stock = 1000, CategoryId = _ids[2] }
                
                );
        }
    }

    
}
