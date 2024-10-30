using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ViMusic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseScheme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Songs",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Songs");
        }
    }
}
