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
        public DbSet<Person> Persons { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfigurations());
            modelBuilder.ApplyConfiguration(new CategoryConfigratons());
            //modelBuilder.ApplyConfiguration(new ProductSeed(new int[] { 1,2}));
            //modelBuilder.ApplyConfiguration(new CategorySeed(new int[] { 1,2}));

            modelBuilder.Entity<Person>().HasKey(x=>x.Id);
            modelBuilder.Entity<Person>().Property(x => x.Id).UseIdentityColumn();
            modelBuilder.Entity<Person>().Property(x => x.Name).HasMaxLength(100);
            modelBuilder.Entity<Person>().Property(x => x.SurName).HasMaxLength(100);



        }



    }
}
