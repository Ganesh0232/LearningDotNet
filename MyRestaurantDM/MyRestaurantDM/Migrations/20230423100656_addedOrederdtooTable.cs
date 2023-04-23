using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyRestaurantDM.Migrations
{
    /// <inheritdoc />
    public partial class addedOrederdtooTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Regions",
                table: "Regions");

            migrationBuilder.RenameTable(
                name: "Regions",
                newName: "OrdersDM");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdersDM",
                table: "OrdersDM",
                column: "OrderId");

            migrationBuilder.CreateTable(
                name: "Ordereddto",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bill = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordereddto", x => x.CustomerId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ordereddto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdersDM",
                table: "OrdersDM");

            migrationBuilder.RenameTable(
                name: "OrdersDM",
                newName: "Regions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Regions",
                table: "Regions",
                column: "OrderId");
        }
    }
}
