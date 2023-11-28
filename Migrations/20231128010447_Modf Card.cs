using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCGInventory.Migrations
{
    /// <inheritdoc />
    public partial class ModfCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Card");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Card",
                newName: "Company");

            migrationBuilder.AlterColumn<string>(
                name: "Set",
                table: "Card",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Company",
                table: "Card",
                newName: "Description");

            migrationBuilder.AlterColumn<int>(
                name: "Set",
                table: "Card",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Card",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
