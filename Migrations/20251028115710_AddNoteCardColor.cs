using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublicNotes.Migrations
{
    /// <inheritdoc />
    public partial class AddNoteCardColor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CardColor",
                table: "Notes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardColor",
                table: "Notes");
        }
    }
}
