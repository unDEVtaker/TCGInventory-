using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCGInventory.Migrations
{
    /// <inheritdoc />
    public partial class ModificacionmodeloCarddeletcompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardCardExpansion");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "Card");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "Card",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CardCardExpansion",
                columns: table => new
                {
                    CardExpansionsId = table.Column<int>(type: "INTEGER", nullable: false),
                    CardsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardCardExpansion", x => new { x.CardExpansionsId, x.CardsId });
                    table.ForeignKey(
                        name: "FK_CardCardExpansion_CardExpansion_CardExpansionsId",
                        column: x => x.CardExpansionsId,
                        principalTable: "CardExpansion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardCardExpansion_Card_CardsId",
                        column: x => x.CardsId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardCardExpansion_CardsId",
                table: "CardCardExpansion",
                column: "CardsId");
        }
    }
}
