using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentManagement.Migrations
{
    /// <inheritdoc />
    public partial class DTOsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isRequired",
                table: "PositionSkills");

            migrationBuilder.AddColumn<string>(
                name: "Required",
                table: "PositionSkills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Required",
                table: "PositionSkills");

            migrationBuilder.AddColumn<bool>(
                name: "isRequired",
                table: "PositionSkills",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
