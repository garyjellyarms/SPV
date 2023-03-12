using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPV.Migrations
{
    /// <inheritdoc />
    public partial class Groups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Foods",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_GroupId",
                table: "User",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_GroupId",
                table: "Foods",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Groups_GroupId",
                table: "Foods",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Groups_GroupId",
                table: "User",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Groups_GroupId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Groups_GroupId",
                table: "User");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_User_GroupId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Foods_GroupId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Foods");
        }
    }
}
