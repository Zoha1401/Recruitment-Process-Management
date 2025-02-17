using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentManagement.Migrations
{
    /// <inheritdoc />
    public partial class InterviewCandidate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "InterviewTypes",
                newName: "InterviewTypeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Candidates",
                newName: "CandidateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InterviewTypeId",
                table: "InterviewTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CandidateId",
                table: "Candidates",
                newName: "Id");
        }
    }
}
