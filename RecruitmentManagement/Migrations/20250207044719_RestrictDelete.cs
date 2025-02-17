using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentManagement.Migrations
{
    /// <inheritdoc />
    public partial class RestrictDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterviewerInterviews_Interviews_InterviewId",
                table: "InterviewerInterviews");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewerInterviews_Users_InterviewerId",
                table: "InterviewerInterviews");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionCandidates_Candidates_candidate_id",
                table: "PositionCandidates");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionCandidates_Positions_position_id",
                table: "PositionCandidates");

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "CandidateStatus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "CandidateStatus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CandidateStatus_UserId",
                table: "CandidateStatus",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateStatus_Users_UserId",
                table: "CandidateStatus",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewerInterviews_Interviews_InterviewId",
                table: "InterviewerInterviews",
                column: "InterviewId",
                principalTable: "Interviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewerInterviews_Users_InterviewerId",
                table: "InterviewerInterviews",
                column: "InterviewerId",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionCandidates_Candidates_candidate_id",
                table: "PositionCandidates",
                column: "candidate_id",
                principalTable: "Candidates",
                principalColumn: "CandidateId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionCandidates_Positions_position_id",
                table: "PositionCandidates",
                column: "position_id",
                principalTable: "Positions",
                principalColumn: "position_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateStatus_Users_UserId",
                table: "CandidateStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewerInterviews_Interviews_InterviewId",
                table: "InterviewerInterviews");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewerInterviews_Users_InterviewerId",
                table: "InterviewerInterviews");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionCandidates_Candidates_candidate_id",
                table: "PositionCandidates");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionCandidates_Positions_position_id",
                table: "PositionCandidates");

            migrationBuilder.DropIndex(
                name: "IX_CandidateStatus_UserId",
                table: "CandidateStatus");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "CandidateStatus");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CandidateStatus");

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewerInterviews_Interviews_InterviewId",
                table: "InterviewerInterviews",
                column: "InterviewId",
                principalTable: "Interviews",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewerInterviews_Users_InterviewerId",
                table: "InterviewerInterviews",
                column: "InterviewerId",
                principalTable: "Users",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_PositionCandidates_Candidates_candidate_id",
                table: "PositionCandidates",
                column: "candidate_id",
                principalTable: "Candidates",
                principalColumn: "CandidateId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionCandidates_Positions_position_id",
                table: "PositionCandidates",
                column: "position_id",
                principalTable: "Positions",
                principalColumn: "position_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
