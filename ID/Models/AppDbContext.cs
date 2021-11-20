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
        //public DbSet<CartOrder> CartOrders { get; set; }
      
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Cart>().ToTable("Carts");
            builder.Entity<Package>().ToTable("Packages");
            builder.Entity<Volunteers>().ToTable("Volunteer");
            builder.Entity<Supplier>().ToTable("Suppliers");
            builder.Entity<Order>().ToTable("Orders");
            builder.Entity<OrderDetail>().ToTable("OrderDetails");
            builder.Entity<Organisation>().ToTable("Organisations");


            //builder.Entity<CartOrder>().ToTable("CartOrders");

            base.OnModelCreating(builder);

            //builder.Entity<CartOrder>()
            //     .HasKey(c => new
            //     {
            //         c.CartId,
            //         c.OrderId
            //     });
        }

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
        
    }
}