﻿// <auto-generated />
using System;
using ID;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ID.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ID.Models.Cart", b =>
                {
                    b.Property<string>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("PackageId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ShoppingCartId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CartId");

                    b.HasIndex("PackageId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("ID.Models.Order", b =>
                {
                    b.Property<string>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganisationChoice")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("OrganisationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderId");

                    b.HasIndex("OrganisationId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ID.Models.OrderDetail", b =>
                {
                    b.Property<string>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OrderId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PackageId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("OrderId");

                    b.HasIndex("PackageId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("ID.Models.Organisation", b =>
                {
                    b.Property<string>("OrganisationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OrganisationAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganisationName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pic")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrganisationId");

                    b.ToTable("Organisations");
                });

            modelBuilder.Entity("ID.Models.Package", b =>
                {
                    b.Property<string>("PackageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PackageDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PackageNameId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PackagePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PackageType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PackageId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("ID.Models.PackageNav", b =>
                {
                    b.Property<string>("PackageId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SupplierId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PackageId", "SupplierId");

                    b.HasIndex("SupplierId");

                    b.ToTable("PackageNavs");
                });

            modelBuilder.Entity("ID.Models.Supplier", b =>
                {
                    b.Property<string>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PackageId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Pic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierId");

                    b.HasIndex("PackageId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("ID.Models.Volunteers", b =>
                {
                    b.Property<string>("VolunteerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("VolFName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VolLName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VolunteerId");

                    b.ToTable("Volunteer");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ID.Models.Cart", b =>
                {
                    b.HasOne("ID.Models.Package", "Package")
                        .WithMany()
                        .HasForeignKey("PackageId");

                    b.Navigation("Package");
                });

            modelBuilder.Entity("ID.Models.Order", b =>
                {
                    b.HasOne("ID.Models.Organisation", "Organisation")
                        .WithMany()
                        .HasForeignKey("OrganisationId");

                    b.Navigation("Organisation");
                });

            modelBuilder.Entity("ID.Models.OrderDetail", b =>
                {
                    b.HasOne("ID.Models.Order", "Order")
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderId");

                    b.HasOne("ID.Models.Package", "Packages")
                        .WithMany()
                        .HasForeignKey("PackageId");

                    b.Navigation("Order");

                    b.Navigation("Packages");
                });

            modelBuilder.Entity("ID.Models.Package", b =>
                {
                    b.HasOne("ID.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("ID.Models.PackageNav", b =>
                {
                    b.HasOne("ID.Models.Package", "Package")
                        .WithMany()
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ID.Models.Supplier", "Supplier")
                        .WithMany("Packagenav")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Package");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("ID.Models.Supplier", b =>
                {
                    b.HasOne("ID.Models.Package", null)
                        .WithMany("Suppliers")
                        .HasForeignKey("PackageId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ID.Models.Order", b =>
                {
                    b.Navigation("OrderLines");
                });

            modelBuilder.Entity("ID.Models.Package", b =>
                {
                    b.Navigation("Suppliers");
                });

            modelBuilder.Entity("ID.Models.Supplier", b =>
                {
                    b.Navigation("Packagenav");
                });
#pragma warning restore 612, 618
        }
    }
}
