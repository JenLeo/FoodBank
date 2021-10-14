using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ID.Migrations
{
    public partial class modelchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.AddColumn<string>(
                name: "PackagesPackageID",
                table: "Package1",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Package1_PackagesPackageID",
                table: "Package1",
                column: "PackagesPackageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Package1_Package1_PackagesPackageID",
                table: "Package1",
                column: "PackagesPackageID",
                principalTable: "Package1",
                principalColumn: "PackageID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Package1_Package1_PackagesPackageID",
                table: "Package1");

            migrationBuilder.DropIndex(
                name: "IX_Package1_PackagesPackageID",
                table: "Package1");

            migrationBuilder.DropColumn(
                name: "PackagesPackageID",
                table: "Package1");

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    ItemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CartId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PackageId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackagesPackageID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Package1_PackagesPackageID",
                        column: x => x.PackagesPackageID,
                        principalTable: "Package1",
                        principalColumn: "PackageID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_PackagesPackageID",
                table: "ShoppingCartItems",
                column: "PackagesPackageID");
        }
    }
}
