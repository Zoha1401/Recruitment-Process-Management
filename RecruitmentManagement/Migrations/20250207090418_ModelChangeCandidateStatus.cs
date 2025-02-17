using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentManagement.Migrations
{
    /// <inheritdoc />
    public partial class ModelChangeCandidateStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateStatus_PositionCandidates_position_candidate_id",
                table: "CandidateStatus");

            migrationBuilder.RenameColumn(
                name: "position_candidate_id",
                table: "CandidateStatus",
                newName: "PositionCandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateStatus_position_candidate_id",
                table: "CandidateStatus",
                newName: "IX_CandidateStatus_PositionCandidateId");

            migrationBuilder.AlterColumn<int>(
                name: "PositionCandidateId",
                table: "CandidateStatus",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CandidateId",
                table: "CandidateStatus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "CandidateStatus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CandidateStatus_CandidateId",
                table: "CandidateStatus",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateStatus_PositionId",
                table: "CandidateStatus",
                column: "PositionId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateStatus_Candidates_CandidateId",
                table: "CandidateStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateStatus_PositionCandidates_PositionCandidateId",
                table: "CandidateStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateStatus_Positions_PositionId",
                table: "CandidateStatus");

            migrationBuilder.DropIndex(
                name: "IX_CandidateStatus_CandidateId",
                table: "CandidateStatus");

            migrationBuilder.DropIndex(
                name: "IX_CandidateStatus_PositionId",
                table: "CandidateStatus");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "CandidateStatus");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "CandidateStatus");

            migrationBuilder.RenameColumn(
                name: "PositionCandidateId",
                table: "CandidateStatus",
                newName: "position_candidate_id");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateStatus_PositionCandidateId",
                table: "CandidateStatus",
                newName: "IX_CandidateStatus_position_candidate_id");

            migrationBuilder.AlterColumn<int>(
                name: "position_candidate_id",
                table: "CandidateStatus",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateStatus_PositionCandidates_position_candidate_id",
                table: "CandidateStatus",
                column: "position_candidate_id",
                principalTable: "PositionCandidates",
                principalColumn: "position_candidate_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
