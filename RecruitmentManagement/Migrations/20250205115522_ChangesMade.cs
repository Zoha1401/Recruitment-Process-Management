using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentManagement.Migrations
{
    /// <inheritdoc />
    public partial class ChangesMade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSkill_Candidates_CandidateId",
                table: "CandidateSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSkill_Skills_SkillId",
                table: "CandidateSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateStatus_PositionCandidate_PositionCandidateId",
                table: "CandidateStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_Interview_PositionCandidate_PositionCandidateId",
                table: "Interview");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewFeedback_PositionCandidate_PositionCandidateId",
                table: "InterviewFeedback");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionCandidate_Candidates_candidate_id",
                table: "PositionCandidate");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionCandidate_Positions_position_id",
                table: "PositionCandidate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PositionCandidate",
                table: "PositionCandidate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidateSkill",
                table: "CandidateSkill");

            migrationBuilder.RenameTable(
                name: "PositionCandidate",
                newName: "PositionCandidates");

            migrationBuilder.RenameTable(
                name: "CandidateSkill",
                newName: "CandidateSkills");

            migrationBuilder.RenameIndex(
                name: "IX_PositionCandidate_position_id",
                table: "PositionCandidates",
                newName: "IX_PositionCandidates_position_id");

            migrationBuilder.RenameIndex(
                name: "IX_PositionCandidate_candidate_id",
                table: "PositionCandidates",
                newName: "IX_PositionCandidates_candidate_id");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateSkill_SkillId",
                table: "CandidateSkills",
                newName: "IX_CandidateSkills_SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateSkill_CandidateId",
                table: "CandidateSkills",
                newName: "IX_CandidateSkills_CandidateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PositionCandidates",
                table: "PositionCandidates",
                column: "position_candidate_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidateSkills",
                table: "CandidateSkills",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSkills_Candidates_CandidateId",
                table: "CandidateSkills",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSkills_Skills_SkillId",
                table: "CandidateSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "skill_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateStatus_PositionCandidates_PositionCandidateId",
                table: "CandidateStatus",
                column: "PositionCandidateId",
                principalTable: "PositionCandidates",
                principalColumn: "position_candidate_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interview_PositionCandidates_PositionCandidateId",
                table: "Interview",
                column: "PositionCandidateId",
                principalTable: "PositionCandidates",
                principalColumn: "position_candidate_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewFeedback_PositionCandidates_PositionCandidateId",
                table: "InterviewFeedback",
                column: "PositionCandidateId",
                principalTable: "PositionCandidates",
                principalColumn: "position_candidate_id");

            migrationBuilder.AddForeignKey(
                name: "FK_PositionCandidates_Candidates_candidate_id",
                table: "PositionCandidates",
                column: "candidate_id",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionCandidates_Positions_position_id",
                table: "PositionCandidates",
                column: "position_id",
                principalTable: "Positions",
                principalColumn: "position_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSkills_Candidates_CandidateId",
                table: "CandidateSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSkills_Skills_SkillId",
                table: "CandidateSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateStatus_PositionCandidates_PositionCandidateId",
                table: "CandidateStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_Interview_PositionCandidates_PositionCandidateId",
                table: "Interview");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewFeedback_PositionCandidates_PositionCandidateId",
                table: "InterviewFeedback");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionCandidates_Candidates_candidate_id",
                table: "PositionCandidates");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionCandidates_Positions_position_id",
                table: "PositionCandidates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PositionCandidates",
                table: "PositionCandidates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidateSkills",
                table: "CandidateSkills");

            migrationBuilder.RenameTable(
                name: "PositionCandidates",
                newName: "PositionCandidate");

            migrationBuilder.RenameTable(
                name: "CandidateSkills",
                newName: "CandidateSkill");

            migrationBuilder.RenameIndex(
                name: "IX_PositionCandidates_position_id",
                table: "PositionCandidate",
                newName: "IX_PositionCandidate_position_id");

            migrationBuilder.RenameIndex(
                name: "IX_PositionCandidates_candidate_id",
                table: "PositionCandidate",
                newName: "IX_PositionCandidate_candidate_id");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateSkills_SkillId",
                table: "CandidateSkill",
                newName: "IX_CandidateSkill_SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateSkills_CandidateId",
                table: "CandidateSkill",
                newName: "IX_CandidateSkill_CandidateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PositionCandidate",
                table: "PositionCandidate",
                column: "position_candidate_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidateSkill",
                table: "CandidateSkill",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSkill_Candidates_CandidateId",
                table: "CandidateSkill",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSkill_Skills_SkillId",
                table: "CandidateSkill",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "skill_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateStatus_PositionCandidate_PositionCandidateId",
                table: "CandidateStatus",
                column: "PositionCandidateId",
                principalTable: "PositionCandidate",
                principalColumn: "position_candidate_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interview_PositionCandidate_PositionCandidateId",
                table: "Interview",
                column: "PositionCandidateId",
                principalTable: "PositionCandidate",
                principalColumn: "position_candidate_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewFeedback_PositionCandidate_PositionCandidateId",
                table: "InterviewFeedback",
                column: "PositionCandidateId",
                principalTable: "PositionCandidate",
                principalColumn: "position_candidate_id");

            migrationBuilder.AddForeignKey(
                name: "FK_PositionCandidate_Candidates_candidate_id",
                table: "PositionCandidate",
                column: "candidate_id",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionCandidate_Positions_position_id",
                table: "PositionCandidate",
                column: "position_id",
                principalTable: "Positions",
                principalColumn: "position_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
