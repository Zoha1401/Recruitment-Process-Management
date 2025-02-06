using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentManagement.Migrations
{
    /// <inheritdoc />
    public partial class InterviewerInterview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterviewerInterview_Interviews_InterviewId",
                table: "InterviewerInterview");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewerInterview_Users_InterviewerId",
                table: "InterviewerInterview");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewFeedback_InterviewerInterview_InterviewerInterviewId",
                table: "InterviewFeedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_InterviewTypes_InterviewTypeId",
                table: "Interviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InterviewerInterview",
                table: "InterviewerInterview");

            migrationBuilder.RenameTable(
                name: "InterviewerInterview",
                newName: "InterviewerInterviews");

            migrationBuilder.RenameColumn(
                name: "InterviewTypeId",
                table: "InterviewTypes",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_InterviewerInterview_InterviewId",
                table: "InterviewerInterviews",
                newName: "IX_InterviewerInterviews_InterviewId");

            migrationBuilder.RenameIndex(
                name: "IX_InterviewerInterview_InterviewerId",
                table: "InterviewerInterviews",
                newName: "IX_InterviewerInterviews_InterviewerId");

            migrationBuilder.AddColumn<int>(
                name: "InterviewTypeId1",
                table: "Interviews",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InterviewerInterviews",
                table: "InterviewerInterviews",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_InterviewTypeId1",
                table: "Interviews",
                column: "InterviewTypeId1");

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
                name: "FK_InterviewFeedback_InterviewerInterviews_InterviewerInterviewId",
                table: "InterviewFeedback",
                column: "InterviewerInterviewId",
                principalTable: "InterviewerInterviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_InterviewTypes_InterviewTypeId",
                table: "Interviews",
                column: "InterviewTypeId",
                principalTable: "InterviewTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_InterviewTypes_InterviewTypeId1",
                table: "Interviews",
                column: "InterviewTypeId1",
                principalTable: "InterviewTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterviewerInterviews_Interviews_InterviewId",
                table: "InterviewerInterviews");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewerInterviews_Users_InterviewerId",
                table: "InterviewerInterviews");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewFeedback_InterviewerInterviews_InterviewerInterviewId",
                table: "InterviewFeedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_InterviewTypes_InterviewTypeId",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_InterviewTypes_InterviewTypeId1",
                table: "Interviews");

            migrationBuilder.DropIndex(
                name: "IX_Interviews_InterviewTypeId1",
                table: "Interviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InterviewerInterviews",
                table: "InterviewerInterviews");

            migrationBuilder.DropColumn(
                name: "InterviewTypeId1",
                table: "Interviews");

            migrationBuilder.RenameTable(
                name: "InterviewerInterviews",
                newName: "InterviewerInterview");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "InterviewTypes",
                newName: "InterviewTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_InterviewerInterviews_InterviewId",
                table: "InterviewerInterview",
                newName: "IX_InterviewerInterview_InterviewId");

            migrationBuilder.RenameIndex(
                name: "IX_InterviewerInterviews_InterviewerId",
                table: "InterviewerInterview",
                newName: "IX_InterviewerInterview_InterviewerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InterviewerInterview",
                table: "InterviewerInterview",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewerInterview_Interviews_InterviewId",
                table: "InterviewerInterview",
                column: "InterviewId",
                principalTable: "Interviews",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewerInterview_Users_InterviewerId",
                table: "InterviewerInterview",
                column: "InterviewerId",
                principalTable: "Users",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewFeedback_InterviewerInterview_InterviewerInterviewId",
                table: "InterviewFeedback",
                column: "InterviewerInterviewId",
                principalTable: "InterviewerInterview",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_InterviewTypes_InterviewTypeId",
                table: "Interviews",
                column: "InterviewTypeId",
                principalTable: "InterviewTypes",
                principalColumn: "InterviewTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
