using Microsoft.EntityFrameworkCore.Migrations;

namespace ID.Migrations
{
    public partial class deletecol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "PackageID",
                table: "Carts");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "Carts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "CartId",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "PackagesPackageID",
                table: "Carts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "TypeId");

            migrationBuilder.CreateTable(
                name: "Package1",
                columns: table => new
                {
                    PackageID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PackageType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackageNameId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackageDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackagePrice = table.Column<int>(type: "int", nullable: false),
                    Pic = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package1", x => x.PackageID);
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
                name: "Package1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_PackagesPackageID",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "PackagesPackageID",
                table: "Carts");

            migrationBuilder.AlterColumn<string>(
                name: "CartId",
                table: "Carts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "Carts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "PackageID",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "CartId");
        }
    }
}
