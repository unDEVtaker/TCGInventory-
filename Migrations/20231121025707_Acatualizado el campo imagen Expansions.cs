using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCGInventory.Migrations
{
    /// <inheritdoc />
    public partial class AcatualizadoelcampoimagenExpansions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "CardExpansion",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "CardExpansion");
        }
    }
}
