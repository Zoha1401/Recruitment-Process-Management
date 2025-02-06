using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentManagement.Migrations
{
    /// <inheritdoc />
    public partial class PositionSkills4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PositionSkills",
                table: "PositionSkills");

            migrationBuilder.DropIndex(
                name: "IX_PositionSkills_position_id",
                table: "PositionSkills");

            migrationBuilder.DropColumn(
                name: "position_skill_id",
                table: "PositionSkills");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PositionSkills",
                table: "PositionSkills",
                columns: new[] { "position_id", "skill_id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PositionSkills",
                table: "PositionSkills");

            migrationBuilder.AddColumn<int>(
                name: "position_skill_id",
                table: "PositionSkills",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PositionSkills",
                table: "PositionSkills",
                column: "position_skill_id");

            migrationBuilder.CreateIndex(
                name: "IX_PositionSkills_position_id",
                table: "PositionSkills",
                column: "position_id");
        }
    }
}
