using Microsoft.EntityFrameworkCore.Migrations;

namespace MemShop.Data.Migrations
{
    public partial class CreateCustomerTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CustomerTypes",
                columns: new[] { "Id", "Description", "Label" },
                values: new object[,]
                {
                    { 1, "30% discount and gain 100 loyalty points", "Gold" },
                    { 2, "20% discount and gain 20 loyalty points", "Student" },
                    { 3, "25% discount and gain 30 loyalty points", "Senior" },
                    { 4, null, "Anonymous" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerTypes");
        }
    }
}
