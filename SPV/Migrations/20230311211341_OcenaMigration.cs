using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPV.Migrations
{
    /// <inheritdoc />
    public partial class OcenaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ocena",
                table: "Restaurants",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ocena",
                table: "Restaurants");
        }
    }
}
