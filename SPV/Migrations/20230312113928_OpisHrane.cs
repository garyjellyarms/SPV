using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPV.Migrations
{
    /// <inheritdoc />
    public partial class OpisHrane : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OpisHrane",
                table: "Foods",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpisHrane",
                table: "Foods");
        }
    }
}
