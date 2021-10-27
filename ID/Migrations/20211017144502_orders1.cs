using Microsoft.EntityFrameworkCore.Migrations;

namespace ID.Migrations
{
    public partial class orders1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Organisations_OrganisationID",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "OrganisationID",
                table: "Organisations",
                newName: "OrganisationId");

            migrationBuilder.RenameColumn(
                name: "OrganisationID",
                table: "Orders",
                newName: "OrganisationId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_OrganisationID",
                table: "Orders",
                newName: "IX_Orders_OrganisationId");

            migrationBuilder.AlterColumn<string>(
                name: "OrganisationChoice",
                table: "Orders",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "OrderStatus",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Organisations_OrganisationId",
                table: "Orders",
                column: "OrganisationId",
                principalTable: "Organisations",
                principalColumn: "OrganisationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Organisations_OrganisationId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "OrganisationId",
                table: "Organisations",
                newName: "OrganisationID");

            migrationBuilder.RenameColumn(
                name: "OrganisationId",
                table: "Orders",
                newName: "OrganisationID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_OrganisationId",
                table: "Orders",
                newName: "IX_Orders_OrganisationID");

            migrationBuilder.AlterColumn<string>(
                name: "OrganisationChoice",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Organisations_OrganisationID",
                table: "Orders",
                column: "OrganisationID",
                principalTable: "Organisations",
                principalColumn: "OrganisationID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
