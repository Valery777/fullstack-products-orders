using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotNetProductApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "חלב וגבינות");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "טואלטיקה");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "בשר");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "ירקות ופירות" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Price" },
                values: new object[] { "קוטג", 4.5m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Price" },
                values: new object[] { "חלב 3%", 5m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Name", "Price" },
                values: new object[] { 1, "שמנת חמוצה", 3.5m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Name", "Price" },
                values: new object[] { 2, "קרמים", 142.6m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Name", "Price" },
                values: new object[,]
                {
                    { 5, 2, "פרסטו ג'ל", 25.99m },
                    { 6, 2, "טיפול וטיפוח השיער", 33.99m },
                    { 7, 2, "קרם צ'רידה", 51.99m },
                    { 8, 3, "שוקים", 12.99m },
                    { 9, 3, "סלמון", 75.99m },
                    { 10, 4, "בצל", 3.99m },
                    { 11, 4, "מנגו", 19.40m },
                    { 12, 4, "אגבניות", 7.59m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Electronics");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Books");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Clothing");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Price" },
                values: new object[] { "Laptop", 999.99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Price" },
                values: new object[] { "Smartphone", 599.99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Name", "Price" },
                values: new object[] { 2, "C# Programming", 49.99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Name", "Price" },
                values: new object[] { 3, "T-Shirt", 19.99m });
        }
    }
}
