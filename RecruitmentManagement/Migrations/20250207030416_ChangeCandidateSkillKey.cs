using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentManagement.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCandidateSkillKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSkills_Candidates_candidate_id",
                table: "CandidateSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSkills_Skills_skill_id",
                table: "CandidateSkills");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSkills_Candidates_candidate_id",
                table: "CandidateSkills",
                column: "candidate_id",
                principalTable: "Candidates",
                principalColumn: "CandidateId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSkills_Skills_skill_id",
                table: "CandidateSkills",
                column: "skill_id",
                principalTable: "Skills",
                principalColumn: "skill_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSkills_Candidates_candidate_id",
                table: "CandidateSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSkills_Skills_skill_id",
                table: "CandidateSkills");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSkills_Candidates_candidate_id",
                table: "CandidateSkills",
                column: "candidate_id",
                principalTable: "Candidates",
                principalColumn: "CandidateId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSkills_Skills_skill_id",
                table: "CandidateSkills",
                column: "skill_id",
                principalTable: "Skills",
                principalColumn: "skill_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
