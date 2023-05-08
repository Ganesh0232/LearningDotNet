using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserStories.Migrations
{
    /// <inheritdoc />
    public partial class Phonedatatypechangedfrominttolong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "phoneNumber",
                table: "RegisterModel",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "phoneNumber",
                table: "RegisterModel",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
