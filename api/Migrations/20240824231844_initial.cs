using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Photo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "Country", "Description", "Photo", "Price" },
                values: new object[,]
                {
                    { 1, "123 Elm St", "USA", "A cozy family home.", null, 250000.0 },
                    { 2, "456 Oak St", "USA", "Spacious with a large backyard.", null, 350000.0 },
                    { 3, "789 Pine St", "USA", "Modern design, close to downtown.", null, 500000.0 },
                    { 4, "101 Maple St", "Canada", "Quaint and charming cottage.", null, 200000.0 },
                    { 5, "202 Birch St", "Canada", "Recently renovated with high-end finishes.", null, 450000.0 },
                    { 6, "303 Cedar St", "UK", "Historic home with original features.", null, 600000.0 },
                    { 7, "404 Willow St", "UK", "Contemporary design, energy efficient.", null, 400000.0 },
                    { 8, "505 Ash St", "Australia", "Beachside property with stunning views.", null, 750000.0 },
                    { 9, "606 Cherry St", "Australia", "Ideal for families, near schools and parks.", null, 300000.0 },
                    { 10, "707 Fir St", "Germany", "Traditional German house, well-maintained.", null, 350000.0 },
                    { 11, "808 Spruce St", "Germany", "Modern apartment in a vibrant area.", null, 500000.0 },
                    { 12, "909 Poplar St", "France", "Elegant home with classic French architecture.", null, 650000.0 },
                    { 13, "1010 Linden St", "France", "Charming property with a beautiful garden.", null, 300000.0 },
                    { 14, "1111 Sequoia St", "Italy", "Rustic villa in the countryside.", null, 550000.0 },
                    { 15, "1212 Redwood St", "Italy", "Modern apartment with city views.", null, 400000.0 },
                    { 16, "1313 Oakwood St", "Spain", "Luxury home with a private pool.", null, 700000.0 },
                    { 17, "1414 Pinewood St", "Spain", "Cozy apartment in a historic building.", null, 250000.0 },
                    { 18, "1515 Maplewood St", "Japan", "Traditional house with a serene garden.", null, 450000.0 },
                    { 19, "1616 Cherrywood St", "Japan", "Modern loft in a bustling area.", null, 300000.0 },
                    { 20, "1717 Willowwood St", "South Korea", "Stylish home with advanced features.", null, 500000.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Houses");
        }
    }
}
