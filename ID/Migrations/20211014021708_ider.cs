using Microsoft.EntityFrameworkCore.Migrations;

namespace ID.Migrations
{
    public partial class ider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PackagePrice",
                table: "Package1",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AddColumn<string>(
                name: "PackagesPackageID",
                table: "Carts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    CartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    PackageID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.CartItemId);
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Package1_PackagesPackageID",
                table: "Carts");

            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropIndex(
                name: "IX_Carts_PackagesPackageID",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "PackagesPackageID",
                table: "Carts");

            migrationBuilder.AlterColumn<decimal>(
                name: "PackagePrice",
                table: "Package1",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
