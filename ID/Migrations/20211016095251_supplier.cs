using Microsoft.EntityFrameworkCore.Migrations;

namespace ID.Migrations
{
    public partial class supplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Suppliers_SupplierID",
                table: "Packages");

            migrationBuilder.RenameColumn(
                name: "SupplierID",
                table: "Suppliers",
                newName: "SupplierId");

            migrationBuilder.RenameColumn(
                name: "SupplierID",
                table: "Packages",
                newName: "SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_SupplierID",
                table: "Packages",
                newName: "IX_Packages_SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Suppliers_SupplierId",
                table: "Packages",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Suppliers_SupplierId",
                table: "Packages");

            migrationBuilder.RenameColumn(
                name: "SupplierId",
                table: "Suppliers",
                newName: "SupplierID");

            migrationBuilder.RenameColumn(
                name: "SupplierId",
                table: "Packages",
                newName: "SupplierID");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_SupplierId",
                table: "Packages",
                newName: "IX_Packages_SupplierID");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Suppliers_SupplierID",
                table: "Packages",
                column: "SupplierID",
                principalTable: "Suppliers",
                principalColumn: "SupplierID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
