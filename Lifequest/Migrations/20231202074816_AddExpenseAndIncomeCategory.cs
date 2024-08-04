using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lifequest.Migrations
{
    public partial class AddExpenseAndIncomeCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "fixed_costs",
                type: "VARCHAR(128)",
                nullable: false,
                comment: "固定費",
                oldClrType: typeof(string),
                oldType: "VARCHAR(128)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<uint>(
                name: "expense",
                table: "fixed_costs",
                type: "int unsigned",
                nullable: false,
                comment: "支出",
                oldClrType: typeof(uint),
                oldType: "int unsigned");

            migrationBuilder.CreateTable(
                name: "expense_and_income_large_category_master",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    large_category_name = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    deleted_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expense_and_income_large_category_master", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "expense_and_income_small_category_master",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    expense_and_income_large_category_id = table.Column<uint>(type: "int unsigned", nullable: false),
                    small_category_name = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    deleted_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expense_and_income_small_category_master", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "expense_and_incomes",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    family_id = table.Column<uint>(type: "int unsigned", nullable: false),
                    family_member_id = table.Column<uint>(type: "int unsigned", nullable: false),
                    expense_and_income_large_category_id = table.Column<uint>(type: "int unsigned", nullable: false),
                    expense_and_income_small_category_id = table.Column<uint>(type: "int unsigned", nullable: false),
                    amount = table.Column<uint>(type: "int unsigned", nullable: false),
                    large_category_name = table.Column<string>(type: "VARCHAR(32)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    small_category_name = table.Column<string>(type: "VARCHAR(32)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    target_date = table.Column<DateOnly>(type: "date", nullable: false),
                    memo = table.Column<string>(type: "VARCHAR(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    deleted_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expense_and_incomes", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "expense_and_income_large_category_master");

            migrationBuilder.DropTable(
                name: "expense_and_income_small_category_master");

            migrationBuilder.DropTable(
                name: "expense_and_incomes");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "fixed_costs",
                type: "VARCHAR(128)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(128)",
                oldComment: "固定費")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<uint>(
                name: "expense",
                table: "fixed_costs",
                type: "int unsigned",
                nullable: false,
                oldClrType: typeof(uint),
                oldType: "int unsigned",
                oldComment: "支出");
        }
    }
}
