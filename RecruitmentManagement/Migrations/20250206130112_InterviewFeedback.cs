using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentManagement.Migrations
{
    /// <inheritdoc />
    public partial class InterviewFeedback : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterviewFeedback_InterviewerInterviews_InterviewerInterviewId",
                table: "InterviewFeedback");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewFeedback_Interviews_InterviewId",
                table: "InterviewFeedback");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewFeedback_PositionCandidates_PositionCandidateId",
                table: "InterviewFeedback");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewFeedback_Skills_SkillId",
                table: "InterviewFeedback");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InterviewFeedback",
                table: "InterviewFeedback");

            migrationBuilder.RenameTable(
                name: "InterviewFeedback",
                newName: "InterviewFeedbacks");

            migrationBuilder.RenameIndex(
                name: "IX_InterviewFeedback_SkillId",
                table: "InterviewFeedbacks",
                newName: "IX_InterviewFeedbacks_SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_InterviewFeedback_PositionCandidateId",
                table: "InterviewFeedbacks",
                newName: "IX_InterviewFeedbacks_PositionCandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_InterviewFeedback_InterviewId",
                table: "InterviewFeedbacks",
                newName: "IX_InterviewFeedbacks_InterviewId");

            migrationBuilder.RenameIndex(
                name: "IX_InterviewFeedback_InterviewerInterviewId",
                table: "InterviewFeedbacks",
                newName: "IX_InterviewFeedbacks_InterviewerInterviewId");

            migrationBuilder.AddColumn<string>(
                name: "comments",
                table: "PositionCandidates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InterviewFeedbacks",
                table: "InterviewFeedbacks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewFeedbacks_InterviewerInterviews_InterviewerInterviewId",
                table: "InterviewFeedbacks",
                column: "InterviewerInterviewId",
                principalTable: "InterviewerInterviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewFeedbacks_Interviews_InterviewId",
                table: "InterviewFeedbacks",
                column: "InterviewId",
                principalTable: "Interviews",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewFeedbacks_PositionCandidates_PositionCandidateId",
                table: "InterviewFeedbacks",
                column: "PositionCandidateId",
                principalTable: "PositionCandidates",
                principalColumn: "position_candidate_id");

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewFeedbacks_Skills_SkillId",
                table: "InterviewFeedbacks",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "skill_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterviewFeedbacks_InterviewerInterviews_InterviewerInterviewId",
                table: "InterviewFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewFeedbacks_Interviews_InterviewId",
                table: "InterviewFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewFeedbacks_PositionCandidates_PositionCandidateId",
                table: "InterviewFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewFeedbacks_Skills_SkillId",
                table: "InterviewFeedbacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InterviewFeedbacks",
                table: "InterviewFeedbacks");

            migrationBuilder.DropColumn(
                name: "comments",
                table: "PositionCandidates");

            migrationBuilder.RenameTable(
                name: "InterviewFeedbacks",
                newName: "InterviewFeedback");

            migrationBuilder.RenameIndex(
                name: "IX_InterviewFeedbacks_SkillId",
                table: "InterviewFeedback",
                newName: "IX_InterviewFeedback_SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_InterviewFeedbacks_PositionCandidateId",
                table: "InterviewFeedback",
                newName: "IX_InterviewFeedback_PositionCandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_InterviewFeedbacks_InterviewId",
                table: "InterviewFeedback",
                newName: "IX_InterviewFeedback_InterviewId");

            migrationBuilder.RenameIndex(
                name: "IX_InterviewFeedbacks_InterviewerInterviewId",
                table: "InterviewFeedback",
                newName: "IX_InterviewFeedback_InterviewerInterviewId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InterviewFeedback",
                table: "InterviewFeedback",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewFeedback_InterviewerInterviews_InterviewerInterviewId",
                table: "InterviewFeedback",
                column: "InterviewerInterviewId",
                principalTable: "InterviewerInterviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewFeedback_Interviews_InterviewId",
                table: "InterviewFeedback",
                column: "InterviewId",
                principalTable: "Interviews",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewFeedback_PositionCandidates_PositionCandidateId",
                table: "InterviewFeedback",
                column: "PositionCandidateId",
                principalTable: "PositionCandidates",
                principalColumn: "position_candidate_id");

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewFeedback_Skills_SkillId",
                table: "InterviewFeedback",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "skill_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
