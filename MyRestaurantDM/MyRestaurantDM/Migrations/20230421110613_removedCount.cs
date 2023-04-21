using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyRestaurantDM.Migrations
{
    /// <inheritdoc />
    public partial class removedCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "ItemsDM");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "ItemsDM",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
