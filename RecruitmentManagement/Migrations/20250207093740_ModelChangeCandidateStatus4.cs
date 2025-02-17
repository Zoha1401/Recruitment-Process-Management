using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentManagement.Migrations
{
    /// <inheritdoc />
    public partial class ModelChangeCandidateStatus4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateStatuses_PositionCandidates_PositionCandidateId",
                table: "CandidateStatuses");

            migrationBuilder.DropIndex(
                name: "IX_CandidateStatuses_PositionCandidateId",
                table: "CandidateStatuses");

            migrationBuilder.DropColumn(
                name: "PositionCandidateId",
                table: "CandidateStatuses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PositionCandidateId",
                table: "CandidateStatuses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CandidateStatuses_PositionCandidateId",
                table: "CandidateStatuses",
                column: "PositionCandidateId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateStatuses_PositionCandidates_PositionCandidateId",
                table: "CandidateStatuses",
                column: "PositionCandidateId",
                principalTable: "PositionCandidates",
                principalColumn: "position_candidate_id");
        }
    }
}
