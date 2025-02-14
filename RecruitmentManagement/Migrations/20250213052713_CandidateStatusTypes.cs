using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentManagement.Migrations
{
    /// <inheritdoc />
    public partial class CandidateStatusTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateStatuses_CandidateStatusType_status_id",
                table: "CandidateStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidateStatusType",
                table: "CandidateStatusType");

            migrationBuilder.RenameTable(
                name: "CandidateStatusType",
                newName: "CandidateStatusTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidateStatusTypes",
                table: "CandidateStatusTypes",
                column: "candiate_status_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateStatuses_CandidateStatusTypes_status_id",
                table: "CandidateStatuses",
                column: "status_id",
                principalTable: "CandidateStatusTypes",
                principalColumn: "candiate_status_type_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateStatuses_CandidateStatusTypes_status_id",
                table: "CandidateStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidateStatusTypes",
                table: "CandidateStatusTypes");

            migrationBuilder.RenameTable(
                name: "CandidateStatusTypes",
                newName: "CandidateStatusType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidateStatusType",
                table: "CandidateStatusType",
                column: "candiate_status_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateStatuses_CandidateStatusType_status_id",
                table: "CandidateStatuses",
                column: "status_id",
                principalTable: "CandidateStatusType",
                principalColumn: "candiate_status_type_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
