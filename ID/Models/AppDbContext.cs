using ID.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.IO;
using System.Configuration;

namespace ID
{
    public partial class AppDbContext : IdentityDbContext
    {


        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base()
        {

        }


        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Package> Packages { get; set; }

        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<Volunteers> Volunteer { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();

                var ConnectionString = configuration.GetConnectionString("AzureConnection");
                _ = optionsBuilder.UseSqlServer(ConnectionString);


            }
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Packages>(entity =>
        //    {
        //        entity.Property(e => e.PackageID).ValueGeneratedNever();

        //        entity.HasOne(d => d.Cart)
        //            .WithMany(p => p.Packages)
        //            .HasForeignKey(d => d.car)
        //            .HasConstraintName("FK_Patients_Sex");
        //    });


        //    modelBuilder.Entity<Cart>(entity =>
        //    {
        //        entity.Property(e => e.TypeId).ValueGeneratedNever();
        //    });

        //    OnModelCreating(modelBuilder);
        //}
    }
}