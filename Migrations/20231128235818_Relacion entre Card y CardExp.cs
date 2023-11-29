using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCGInventory.Migrations
{
    /// <inheritdoc />
    public partial class RelacionentreCardyCardExp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CardId",
                table: "CardExpansion",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CardExpansion_CardId",
                table: "CardExpansion",
                column: "CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_CardExpansion_Card_CardId",
                table: "CardExpansion",
                column: "CardId",
                principalTable: "Card",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardExpansion_Card_CardId",
                table: "CardExpansion");

            migrationBuilder.DropIndex(
                name: "IX_CardExpansion_CardId",
                table: "CardExpansion");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "CardExpansion");
        }
    }
}
