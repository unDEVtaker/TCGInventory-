using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCGInventory.Migrations
{
    /// <inheritdoc />
    public partial class RelacionentreCardyCardEx4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "CardExpansionId",
                table: "Card",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Card_CardExpansionId",
                table: "Card",
                column: "CardExpansionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Card_CardExpansion_CardExpansionId",
                table: "Card",
                column: "CardExpansionId",
                principalTable: "CardExpansion",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Card_CardExpansion_CardExpansionId",
                table: "Card");

            migrationBuilder.DropIndex(
                name: "IX_Card_CardExpansionId",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "CardExpansionId",
                table: "Card");

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
    }
}
