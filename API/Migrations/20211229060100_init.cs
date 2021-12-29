using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoriesTable",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoriesTable", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "productsTable",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productsTable", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_productsTable_categoriesTable_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categoriesTable",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categoriesTable",
                columns: new[] { "CategoryId", "Description", "name" },
                values: new object[] { 1, "Windows 11", "Dell" });

            migrationBuilder.InsertData(
                table: "categoriesTable",
                columns: new[] { "CategoryId", "Description", "name" },
                values: new object[] { 2, "Mac OS", "MacBook" });

            migrationBuilder.InsertData(
                table: "productsTable",
                columns: new[] { "ProductId", "CategoryId", "Quantity", "name", "price" },
                values: new object[] { 1, 1, 5000, " Dell", 4567654.0 });

            migrationBuilder.InsertData(
                table: "productsTable",
                columns: new[] { "ProductId", "CategoryId", "Quantity", "name", "price" },
                values: new object[] { 2, 2, 1000, "MacBook", 984453.0 });

            migrationBuilder.CreateIndex(
                name: "IX_productsTable_CategoryId",
                table: "productsTable",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productsTable");

            migrationBuilder.DropTable(
                name: "categoriesTable");
        }
    }
}
