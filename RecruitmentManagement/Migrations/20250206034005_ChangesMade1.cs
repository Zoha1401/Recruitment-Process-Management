using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentManagement.Migrations
{
    /// <inheritdoc />
    public partial class ChangesMade1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interview_PositionCandidates_PositionCandidateId",
                table: "Interview");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewerInterview_Interview_InterviewId",
                table: "InterviewerInterview");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewFeedback_Interview_InterviewId",
                table: "InterviewFeedback");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Interview",
                table: "Interview");

            migrationBuilder.RenameTable(
                name: "Interview",
                newName: "Interviews");

            migrationBuilder.RenameIndex(
                name: "IX_Interview_PositionCandidateId",
                table: "Interviews",
                newName: "IX_Interviews_PositionCandidateId");

            migrationBuilder.AlterColumn<bool>(
                name: "comments",
                table: "PositionCandidates",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Interviews",
                table: "Interviews",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewerInterview_Interviews_InterviewId",
                table: "InterviewerInterview",
                column: "InterviewId",
                principalTable: "Interviews",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewFeedback_Interviews_InterviewId",
                table: "InterviewFeedback",
                column: "InterviewId",
                principalTable: "Interviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_PositionCandidates_PositionCandidateId",
                table: "Interviews",
                column: "PositionCandidateId",
                principalTable: "PositionCandidates",
                principalColumn: "position_candidate_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterviewerInterview_Interviews_InterviewId",
                table: "InterviewerInterview");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewFeedback_Interviews_InterviewId",
                table: "InterviewFeedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_PositionCandidates_PositionCandidateId",
                table: "Interviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Interviews",
                table: "Interviews");

            migrationBuilder.RenameTable(
                name: "Interviews",
                newName: "Interview");

            migrationBuilder.RenameIndex(
                name: "IX_Interviews_PositionCandidateId",
                table: "Interview",
                newName: "IX_Interview_PositionCandidateId");

            migrationBuilder.AlterColumn<string>(
                name: "comments",
                table: "PositionCandidates",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Interview",
                table: "Interview",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Interview_PositionCandidates_PositionCandidateId",
                table: "Interview",
                column: "PositionCandidateId",
                principalTable: "PositionCandidates",
                principalColumn: "position_candidate_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewerInterview_Interview_InterviewId",
                table: "InterviewerInterview",
                column: "InterviewId",
                principalTable: "Interview",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewFeedback_Interview_InterviewId",
                table: "InterviewFeedback",
                column: "InterviewId",
                principalTable: "Interview",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
