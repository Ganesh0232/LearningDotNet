using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyRestaurantDM.Migrations
{
    /// <inheritdoc />
    public partial class Moneypropertyadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemCount",
                table: "ItemsDM",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemPrice",
                table: "ItemsDM",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemCount",
                table: "ItemsDM");

            migrationBuilder.DropColumn(
                name: "ItemPrice",
                table: "ItemsDM");
        }
    }
}
