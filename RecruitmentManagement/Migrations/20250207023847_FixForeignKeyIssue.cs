using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentManagement.Migrations
{
    /// <inheritdoc />
    public partial class FixForeignKeyIssue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InterviewInterviewerId",
                table: "InterviewFeedbacks");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "InterviewerInterviews",
                newName: "InterviewerInterviewId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InterviewerInterviewId",
                table: "InterviewerInterviews",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "InterviewInterviewerId",
                table: "InterviewFeedbacks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
