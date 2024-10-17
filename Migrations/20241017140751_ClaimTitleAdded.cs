using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ST10390916_PROG_POE.Migrations
{
    /// <inheritdoc />
    public partial class ClaimTitleAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClaimTitle",
                table: "claims",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClaimTitle",
                table: "claims");
        }
    }
}
