﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UdemiyNLayerProject.Core.Models;
using UdemiyNLayerProject.Data.Configurations;
using UdemiyNLayerProject.Data.Seeds;

namespace UdemiyNLayerProject.Data
{
     public  class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfigurations());
            modelBuilder.ApplyConfiguration(new CategoryConfigratons());
            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] { 1,2}));
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] { 1,2}));

        }



    }
}
