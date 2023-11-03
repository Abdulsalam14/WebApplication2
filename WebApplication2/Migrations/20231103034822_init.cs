using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Discount", "ImagePath", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Product1 Description", 20, "images\\product-1-1.jpg", "Product1", 10 },
                    { 2, "Product2 Description", 35, "images\\product-2-1.jpg", "Product2", 20 },
                    { 3, "Product3 Description", 0, "images\\product-3-1.jpg", "Product3", 30 },
                    { 4, "Product4 Description", 5, "images\\product-4-1.jpg", "Product4", 40 },
                    { 5, "Product5 Description", 15, "images\\product-5-1.jpg", "Product5", 50 },
                    { 6, "Product6 Description", 10, "images\\product-6-1.jpg", "Product6", 20 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
