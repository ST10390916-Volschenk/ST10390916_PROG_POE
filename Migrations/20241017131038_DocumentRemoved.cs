﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ST10390916_PROG_POE.Migrations
{
    /// <inheritdoc />
    public partial class DocumentRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClaimDocument",
                table: "claims");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ClaimDocument",
                table: "claims",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
