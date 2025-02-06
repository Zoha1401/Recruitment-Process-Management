using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentManagement.Migrations
{
    /// <inheritdoc />
    public partial class RemovedRequirements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PositionSkill_Positions_position_id",
                table: "PositionSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionSkill_Skills_skill_id",
                table: "PositionSkill");

            migrationBuilder.DropTable(
                name: "PositionJobRequirement");

            migrationBuilder.DropTable(
                name: "JobRequirements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PositionSkill",
                table: "PositionSkill");

            migrationBuilder.RenameTable(
                name: "PositionSkill",
                newName: "PositionSkills");

            migrationBuilder.RenameIndex(
                name: "IX_PositionSkill_skill_id",
                table: "PositionSkills",
                newName: "IX_PositionSkills_skill_id");

            migrationBuilder.RenameIndex(
                name: "IX_PositionSkill_position_id",
                table: "PositionSkills",
                newName: "IX_PositionSkills_position_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PositionSkills",
                table: "PositionSkills",
                column: "position_skill_id");

            migrationBuilder.AddForeignKey(
                name: "FK_PositionSkills_Positions_position_id",
                table: "PositionSkills",
                column: "position_id",
                principalTable: "Positions",
                principalColumn: "position_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionSkills_Skills_skill_id",
                table: "PositionSkills",
                column: "skill_id",
                principalTable: "Skills",
                principalColumn: "skill_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PositionSkills_Positions_position_id",
                table: "PositionSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionSkills_Skills_skill_id",
                table: "PositionSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PositionSkills",
                table: "PositionSkills");

            migrationBuilder.RenameTable(
                name: "PositionSkills",
                newName: "PositionSkill");

            migrationBuilder.RenameIndex(
                name: "IX_PositionSkills_skill_id",
                table: "PositionSkill",
                newName: "IX_PositionSkill_skill_id");

            migrationBuilder.RenameIndex(
                name: "IX_PositionSkills_position_id",
                table: "PositionSkill",
                newName: "IX_PositionSkill_position_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PositionSkill",
                table: "PositionSkill",
                column: "position_skill_id");

            migrationBuilder.CreateTable(
                name: "JobRequirements",
                columns: table => new
                {
                    job_requirement_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    job_requirement_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobRequirements", x => x.job_requirement_id);
                });

            migrationBuilder.CreateTable(
                name: "PositionJobRequirement",
                columns: table => new
                {
                    positon_job_requirement_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    position_id = table.Column<int>(type: "int", nullable: false),
                    requirement_id = table.Column<int>(type: "int", nullable: false),
                    comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionJobRequirement", x => x.positon_job_requirement_id);
                    table.ForeignKey(
                        name: "FK_PositionJobRequirement_JobRequirements_requirement_id",
                        column: x => x.requirement_id,
                        principalTable: "JobRequirements",
                        principalColumn: "job_requirement_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PositionJobRequirement_Positions_position_id",
                        column: x => x.position_id,
                        principalTable: "Positions",
                        principalColumn: "position_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PositionJobRequirement_position_id",
                table: "PositionJobRequirement",
                column: "position_id");

            migrationBuilder.CreateIndex(
                name: "IX_PositionJobRequirement_requirement_id",
                table: "PositionJobRequirement",
                column: "requirement_id");

            migrationBuilder.AddForeignKey(
                name: "FK_PositionSkill_Positions_position_id",
                table: "PositionSkill",
                column: "position_id",
                principalTable: "Positions",
                principalColumn: "position_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionSkill_Skills_skill_id",
                table: "PositionSkill",
                column: "skill_id",
                principalTable: "Skills",
                principalColumn: "skill_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
