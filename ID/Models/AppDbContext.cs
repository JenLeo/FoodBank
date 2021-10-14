using ID.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;


namespace ID
{
    public partial class AppDbContext : IdentityDbContext  {

        private const string connectionString = "Server=tcp:jfoodsource.database.windows.net,1433;Initial Catalog=JFood;Persist Security Info=False;User ID=JFood;Password=Jbank123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
           
        }


        public DbSet<Supplier> Suppliers { get; set; }
   
        public DbSet<Cart> Carts { get; set; }
      
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Packages> Package1 { get; set; }
      
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
    }
}

