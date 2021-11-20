using Microsoft.EntityFrameworkCore.Migrations;

namespace ID.Migrations
{
    public partial class top : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CartOrderId",
                table: "CartOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "CartOrders",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartOrderId",
                table: "CartOrders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "CartOrders");
        }
    }
}
