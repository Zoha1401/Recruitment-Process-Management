using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentManagement.Migrations
{
    /// <inheritdoc />
    public partial class DocumentShortlistCandidate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_ShortlistCandidates_ShortlistCandidateId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "shortlist_id",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "ShortlistCandidateId",
                table: "Documents",
                newName: "shortlist_candidate_id");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_ShortlistCandidateId",
                table: "Documents",
                newName: "IX_Documents_shortlist_candidate_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_ShortlistCandidates_shortlist_candidate_id",
                table: "Documents",
                column: "shortlist_candidate_id",
                principalTable: "ShortlistCandidates",
                principalColumn: "shortlist_candidate_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_ShortlistCandidates_shortlist_candidate_id",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "shortlist_candidate_id",
                table: "Documents",
                newName: "ShortlistCandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_shortlist_candidate_id",
                table: "Documents",
                newName: "IX_Documents_ShortlistCandidateId");

            migrationBuilder.AddColumn<int>(
                name: "shortlist_id",
                table: "Documents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_ShortlistCandidates_ShortlistCandidateId",
                table: "Documents",
                column: "ShortlistCandidateId",
                principalTable: "ShortlistCandidates",
                principalColumn: "shortlist_candidate_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
