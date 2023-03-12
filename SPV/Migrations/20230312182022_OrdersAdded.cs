using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPV.Migrations
{
    /// <inheritdoc />
    public partial class OrdersAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Groups_GroupId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Groups_GroupId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_GroupId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Foods_GroupId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Foods");

            migrationBuilder.AddColumn<Guid>(
                name: "GroupGuid",
                table: "User",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GroupGuid",
                table: "Foods",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "Guid");

            migrationBuilder.CreateIndex(
                name: "IX_User_GroupGuid",
                table: "User",
                column: "GroupGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_GroupGuid",
                table: "Foods",
                column: "GroupGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Groups_GroupGuid",
                table: "Foods",
                column: "GroupGuid",
                principalTable: "Groups",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Groups_GroupGuid",
                table: "User",
                column: "GroupGuid",
                principalTable: "Groups",
                principalColumn: "Guid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Groups_GroupGuid",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Groups_GroupGuid",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_GroupGuid",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Foods_GroupGuid",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "GroupGuid",
                table: "User");

            migrationBuilder.DropColumn(
                name: "GroupGuid",
                table: "Foods");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Foods",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "Id");

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
    }
}
