using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UdemiyNLayerProject.Core.Models;

namespace UdemiyNLayerProject.Data.Seeds
{
    class CategorySeed : IEntityTypeConfiguration<Category>
    {

        private readonly int[] _ids;

        public CategorySeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Category> builder)
        {
                 builder.HasData(new Category { Id = _ids[0], Name = "Kalemler" },
                 builder.HasData(new Category { Id = _ids[0], Name = "Silgiler" },
                  builder.HasData(new Category { Id = _ids[0], Name = "Defterler" }



                );
        }
    }
}
