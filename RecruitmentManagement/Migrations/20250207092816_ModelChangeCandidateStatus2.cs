using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentManagement.Migrations
{
    /// <inheritdoc />
    public partial class ModelChangeCandidateStatus2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateStatus_CandidateStatusType_status_id",
                table: "CandidateStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateStatus_Candidates_CandidateId",
                table: "CandidateStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateStatus_PositionCandidates_PositionCandidateId",
                table: "CandidateStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateStatus_Positions_PositionId",
                table: "CandidateStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateStatus_Users_UserId",
                table: "CandidateStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidateStatus",
                table: "CandidateStatus");

            migrationBuilder.RenameTable(
                name: "CandidateStatus",
                newName: "CandidateStatuses");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateStatus_UserId",
                table: "CandidateStatuses",
                newName: "IX_CandidateStatuses_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateStatus_status_id",
                table: "CandidateStatuses",
                newName: "IX_CandidateStatuses_status_id");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateStatus_PositionId",
                table: "CandidateStatuses",
                newName: "IX_CandidateStatuses_PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateStatus_PositionCandidateId",
                table: "CandidateStatuses",
                newName: "IX_CandidateStatuses_PositionCandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateStatus_CandidateId",
                table: "CandidateStatuses",
                newName: "IX_CandidateStatuses_CandidateId");

            migrationBuilder.AlterColumn<int>(
                name: "updated_by",
                table: "CandidateStatuses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidateStatuses",
                table: "CandidateStatuses",
                column: "candidate_status_id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateStatuses_CandidateStatusType_status_id",
                table: "CandidateStatuses",
                column: "status_id",
                principalTable: "CandidateStatusType",
                principalColumn: "candiate_status_type_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateStatuses_Candidates_CandidateId",
                table: "CandidateStatuses",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "candidate_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateStatuses_PositionCandidates_PositionCandidateId",
                table: "CandidateStatuses",
                column: "PositionCandidateId",
                principalTable: "PositionCandidates",
                principalColumn: "position_candidate_id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateStatuses_Positions_PositionId",
                table: "CandidateStatuses",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "position_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateStatuses_Users_UserId",
                table: "CandidateStatuses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateStatuses_CandidateStatusType_status_id",
                table: "CandidateStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateStatuses_Candidates_CandidateId",
                table: "CandidateStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateStatuses_PositionCandidates_PositionCandidateId",
                table: "CandidateStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateStatuses_Positions_PositionId",
                table: "CandidateStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateStatuses_Users_UserId",
                table: "CandidateStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidateStatuses",
                table: "CandidateStatuses");

            migrationBuilder.RenameTable(
                name: "CandidateStatuses",
                newName: "CandidateStatus");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateStatuses_UserId",
                table: "CandidateStatus",
                newName: "IX_CandidateStatus_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateStatuses_status_id",
                table: "CandidateStatus",
                newName: "IX_CandidateStatus_status_id");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateStatuses_PositionId",
                table: "CandidateStatus",
                newName: "IX_CandidateStatus_PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateStatuses_PositionCandidateId",
                table: "CandidateStatus",
                newName: "IX_CandidateStatus_PositionCandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateStatuses_CandidateId",
                table: "CandidateStatus",
                newName: "IX_CandidateStatus_CandidateId");

            migrationBuilder.AlterColumn<int>(
                name: "updated_by",
                table: "CandidateStatus",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidateStatus",
                table: "CandidateStatus",
                column: "candidate_status_id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateStatus_CandidateStatusType_status_id",
                table: "CandidateStatus",
                column: "status_id",
                principalTable: "CandidateStatusType",
                principalColumn: "candiate_status_type_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateStatus_Candidates_CandidateId",
                table: "CandidateStatus",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "candidate_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateStatus_PositionCandidates_PositionCandidateId",
                table: "CandidateStatus",
                column: "PositionCandidateId",
                principalTable: "PositionCandidates",
                principalColumn: "position_candidate_id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateStatus_Positions_PositionId",
                table: "CandidateStatus",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "position_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateStatus_Users_UserId",
                table: "CandidateStatus",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
