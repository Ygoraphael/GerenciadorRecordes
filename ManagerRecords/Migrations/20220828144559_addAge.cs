using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagerRecords.Migrations
{
    public partial class addAge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Recordes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Recordes");
        }
    }
}
