using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mvc_WebApp_Level2.Migrations
{
    /// <inheritdoc />
    public partial class add_MaxDegreeField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxDegree",
                table: "courses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxDegree",
                table: "courses");
        }
    }
}
