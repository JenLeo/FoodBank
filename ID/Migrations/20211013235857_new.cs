using Microsoft.EntityFrameworkCore.Migrations;

namespace ID.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Package1_PackagesPackageID",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Package1_Carts_CartTypeId",
                table: "Package1");

            migrationBuilder.DropForeignKey(
                name: "FK_Package1_Package1_PackagesPackageID",
                table: "Package1");

            migrationBuilder.DropIndex(
                name: "IX_Package1_CartTypeId",
                table: "Package1");

            migrationBuilder.DropIndex(
                name: "IX_Package1_PackagesPackageID",
                table: "Package1");

            migrationBuilder.DropIndex(
                name: "IX_Carts_PackagesPackageID",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "CartTypeId",
                table: "Package1");

            migrationBuilder.DropColumn(
                name: "PackagesPackageID",
                table: "Package1");

            migrationBuilder.DropColumn(
                name: "PackagesPackageID",
                table: "Carts");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "OrderDetails",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Count",
                table: "Carts",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartTypeId",
                table: "Package1",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PackagesPackageID",
                table: "Package1",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Count",
                table: "Carts",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "PackagesPackageID",
                table: "Carts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Package1_CartTypeId",
                table: "Package1",
                column: "CartTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Package1_PackagesPackageID",
                table: "Package1",
                column: "PackagesPackageID");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_PackagesPackageID",
                table: "Carts",
                column: "PackagesPackageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Package1_PackagesPackageID",
                table: "Carts",
                column: "PackagesPackageID",
                principalTable: "Package1",
                principalColumn: "PackageID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Package1_Carts_CartTypeId",
                table: "Package1",
                column: "CartTypeId",
                principalTable: "Carts",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Package1_Package1_PackagesPackageID",
                table: "Package1",
                column: "PackagesPackageID",
                principalTable: "Package1",
                principalColumn: "PackageID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
