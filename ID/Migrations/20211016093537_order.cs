using Microsoft.EntityFrameworkCore.Migrations;

namespace ID.Migrations
{
    public partial class order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VolunteerId",
                table: "Volunteer",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "SupplierID",
                table: "Packages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrganisationChoice",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OrganisationID",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Volunteer",
                table: "Volunteer",
                column: "VolunteerId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_SupplierID",
                table: "Packages",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrganisationID",
                table: "Orders",
                column: "OrganisationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Organisations_OrganisationID",
                table: "Orders",
                column: "OrganisationID",
                principalTable: "Organisations",
                principalColumn: "OrganisationID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Suppliers_SupplierID",
                table: "Packages",
                column: "SupplierID",
                principalTable: "Suppliers",
                principalColumn: "SupplierID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Organisations_OrganisationID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Suppliers_SupplierID",
                table: "Packages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Volunteer",
                table: "Volunteer");

            migrationBuilder.DropIndex(
                name: "IX_Packages_SupplierID",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrganisationID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SupplierID",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "OrganisationChoice",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrganisationID",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "VolunteerId",
                table: "Volunteer",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
