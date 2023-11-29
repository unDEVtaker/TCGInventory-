using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCGInventory.Migrations
{
    /// <inheritdoc />
    public partial class RelacionentreCardyCardEx3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "CardExpansion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "CardExpansion",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
