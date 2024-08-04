using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lifequest.Migrations
{
    public partial class AddExpenseAndIncomeCategorySeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "expense_and_income_large_category_master",
                columns: new[] { "id", "deleted_at", "large_category_name" },
                values: new object[,]
                {
                    { 1u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "食費" },
                    { 2u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "日用雑貨" },
                    { 3u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "交通" },
                    { 4u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "交際費" },
                    { 5u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "エンタメ" },
                    { 6u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "教育・教養" },
                    { 7u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "美容・服" },
                    { 8u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "医療・保険" },
                    { 9u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "通信" },
                    { 10u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "水道・光熱費" },
                    { 11u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "住まい" },
                    { 12u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "車" },
                    { 13u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "税金" },
                    { 14u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "大型出費" },
                    { 15u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "その他" }
                });

            migrationBuilder.InsertData(
                table: "expense_and_income_small_category_master",
                columns: new[] { "id", "deleted_at", "expense_and_income_large_category_id", "small_category_name" },
                values: new object[,]
                {
                    { 1u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1u, "食料品" },
                    { 2u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1u, "カフェ" },
                    { 3u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1u, "朝ご飯" },
                    { 4u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1u, "昼ご飯" },
                    { 5u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1u, "晩ご飯" },
                    { 6u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1u, "その他" },
                    { 7u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2u, "消耗品" },
                    { 8u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2u, "子ども関連" },
                    { 9u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2u, "ペット関連" },
                    { 10u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2u, "タバコ" },
                    { 11u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2u, "その他" },
                    { 12u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3u, "電車" },
                    { 13u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3u, "タクシー" },
                    { 14u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3u, "バス" },
                    { 15u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3u, "飛行機" },
                    { 16u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3u, "その他" },
                    { 17u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4u, "飲み会" },
                    { 18u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4u, "プレゼント" },
                    { 19u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4u, "ご祝儀・香典" },
                    { 20u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4u, "その他" },
                    { 21u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5u, "レジャー" },
                    { 22u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5u, "イベント" },
                    { 23u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5u, "映画・動画" },
                    { 24u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5u, "音楽" },
                    { 25u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5u, "漫画" },
                    { 26u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5u, "書籍" },
                    { 27u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5u, "ゲーム" },
                    { 28u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5u, "その他" },
                    { 29u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6u, "習い事" },
                    { 30u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6u, "新聞" },
                    { 31u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6u, "参考書" },
                    { 32u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6u, "受験料" },
                    { 33u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6u, "学費" },
                    { 34u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6u, "学質保険" },
                    { 35u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6u, "塾" },
                    { 36u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6u, "その他" },
                    { 37u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7u, "洋服" },
                    { 38u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7u, "アクセサリー・小物" },
                    { 39u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7u, "下着" },
                    { 40u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7u, "ジム・健康" },
                    { 41u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7u, "美容院" },
                    { 42u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7u, "コスメ" },
                    { 43u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7u, "エスト・メイル" },
                    { 44u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7u, "クリーニング" },
                    { 45u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7u, "その他" },
                    { 46u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14u, "旅行" },
                    { 47u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14u, "結婚" },
                    { 48u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14u, "その他" },
                    { 49u, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15u, "その他" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "expense_and_income_large_category_master",
                keyColumn: "id",
                keyValue: 1u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_large_category_master",
                keyColumn: "id",
                keyValue: 2u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_large_category_master",
                keyColumn: "id",
                keyValue: 3u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_large_category_master",
                keyColumn: "id",
                keyValue: 4u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_large_category_master",
                keyColumn: "id",
                keyValue: 5u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_large_category_master",
                keyColumn: "id",
                keyValue: 6u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_large_category_master",
                keyColumn: "id",
                keyValue: 7u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_large_category_master",
                keyColumn: "id",
                keyValue: 8u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_large_category_master",
                keyColumn: "id",
                keyValue: 9u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_large_category_master",
                keyColumn: "id",
                keyValue: 10u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_large_category_master",
                keyColumn: "id",
                keyValue: 11u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_large_category_master",
                keyColumn: "id",
                keyValue: 12u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_large_category_master",
                keyColumn: "id",
                keyValue: 13u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_large_category_master",
                keyColumn: "id",
                keyValue: 14u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_large_category_master",
                keyColumn: "id",
                keyValue: 15u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 1u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 2u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 3u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 4u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 5u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 6u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 7u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 8u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 9u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 10u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 11u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 12u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 13u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 14u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 15u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 16u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 17u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 18u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 19u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 20u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 21u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 22u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 23u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 24u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 25u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 26u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 27u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 28u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 29u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 30u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 31u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 32u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 33u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 34u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 35u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 36u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 37u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 38u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 39u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 40u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 41u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 42u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 43u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 44u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 45u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 46u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 47u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 48u);

            migrationBuilder.DeleteData(
                table: "expense_and_income_small_category_master",
                keyColumn: "id",
                keyValue: 49u);
        }
    }
}
