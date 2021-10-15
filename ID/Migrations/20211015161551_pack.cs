using Microsoft.EntityFrameworkCore.Migrations;

namespace ID.Migrations
{
    public partial class pack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Package1_PackagesPackageID",
                table: "Carts");

            migrationBuilder.DropTable(
                name: "Package1");

            migrationBuilder.RenameColumn(
                name: "PackagesPackageID",
                table: "Carts",
                newName: "PackageId");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_PackagesPackageID",
                table: "Carts",
                newName: "IX_Carts_PackageId");

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    PackageId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PackageNameId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackageDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackageType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackagePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pic = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.PackageId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Packages_PackageId",
                table: "Carts",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "PackageId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Packages_PackageId",
                table: "Carts");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.RenameColumn(
                name: "PackageId",
                table: "Carts",
                newName: "PackagesPackageID");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_PackageId",
                table: "Carts",
                newName: "IX_Carts_PackagesPackageID");

            migrationBuilder.CreateTable(
                name: "Package1",
                columns: table => new
                {
                    PackageID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PackageDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackageNameId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackagePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PackageType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pic = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package1", x => x.PackageID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Package1_PackagesPackageID",
                table: "Carts",
                column: "PackagesPackageID",
                principalTable: "Package1",
                principalColumn: "PackageID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
