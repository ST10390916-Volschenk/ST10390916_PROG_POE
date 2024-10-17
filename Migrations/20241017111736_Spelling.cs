using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ST10390916_PROG_POE.Migrations
{
    /// <inheritdoc />
    public partial class Spelling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RatePerHourr",
                table: "claims",
                newName: "RatePerHour");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RatePerHour",
                table: "claims",
                newName: "RatePerHourr");
        }
    }
}
