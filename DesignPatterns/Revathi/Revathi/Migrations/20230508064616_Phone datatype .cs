using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserStories.Migrations
{
    /// <inheritdoc />
    public partial class Phonedatatype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegisterModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    phoneNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterModel", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegisterModel");
        }
    }
}
