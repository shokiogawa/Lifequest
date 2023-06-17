using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lifequest.Migrations
{
    public partial class FixedCostsAddExpense : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<uint>(
                name: "expense",
                table: "fixed_costs",
                type: "int unsigned",
                nullable: false,
                defaultValue: 0u);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "expense",
                table: "fixed_costs");
        }
    }
}
