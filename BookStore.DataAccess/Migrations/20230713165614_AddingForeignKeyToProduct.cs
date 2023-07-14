using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class AddingForeignKeyToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "MyProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "MyProducts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "MyProducts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "ImageUrl" },
                values: new object[] { 1, "" });

            migrationBuilder.UpdateData(
                table: "MyProducts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "ImageUrl" },
                values: new object[] { 2, "" });

            migrationBuilder.UpdateData(
                table: "MyProducts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "ImageUrl" },
                values: new object[] { 3, "" });

            migrationBuilder.UpdateData(
                table: "MyProducts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "ImageUrl" },
                values: new object[] { 4, "" });

            migrationBuilder.UpdateData(
                table: "MyProducts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "ImageUrl" },
                values: new object[] { 5, "" });

            migrationBuilder.UpdateData(
                table: "MyProducts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "ImageUrl" },
                values: new object[] { 1, "" });

            migrationBuilder.CreateIndex(
                name: "IX_MyProducts_CategoryId",
                table: "MyProducts",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_MyProducts_MyCategories_CategoryId",
                table: "MyProducts",
                column: "CategoryId",
                principalTable: "MyCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyProducts_MyCategories_CategoryId",
                table: "MyProducts");

            migrationBuilder.DropIndex(
                name: "IX_MyProducts_CategoryId",
                table: "MyProducts");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "MyProducts");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "MyProducts");
        }
    }
}
