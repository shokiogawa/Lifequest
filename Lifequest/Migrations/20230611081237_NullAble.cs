using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lifequest.Migrations
{
    public partial class NullAble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "code",
                table: "banks",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<ushort>(
                name: "branch_number",
                table: "banks",
                type: "smallint unsigned",
                nullable: true,
                oldClrType: typeof(ushort),
                oldType: "smallint unsigned");

            migrationBuilder.AlterColumn<string>(
                name: "branch_name",
                table: "banks",
                type: "VARCHAR(16)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(16)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<uint>(
                name: "account_number",
                table: "banks",
                type: "int unsigned",
                nullable: true,
                oldClrType: typeof(uint),
                oldType: "int unsigned");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "banks",
                keyColumn: "code",
                keyValue: null,
                column: "code",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "code",
                table: "banks",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<ushort>(
                name: "branch_number",
                table: "banks",
                type: "smallint unsigned",
                nullable: false,
                defaultValue: (ushort)0,
                oldClrType: typeof(ushort),
                oldType: "smallint unsigned",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "banks",
                keyColumn: "branch_name",
                keyValue: null,
                column: "branch_name",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "branch_name",
                table: "banks",
                type: "VARCHAR(16)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(16)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<uint>(
                name: "account_number",
                table: "banks",
                type: "int unsigned",
                nullable: false,
                defaultValue: 0u,
                oldClrType: typeof(uint),
                oldType: "int unsigned",
                oldNullable: true);
        }
    }
}
