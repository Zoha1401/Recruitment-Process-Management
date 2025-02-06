using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentManagement.Migrations
{
    /// <inheritdoc />
    public partial class Positions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Position_PositionStatusTypes_PositionStatusTypeId",
                table: "Position");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionCandidate_Position_position_id",
                table: "PositionCandidate");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionJobRequirement_Position_position_id",
                table: "PositionJobRequirement");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionSkill_Position_position_id",
                table: "PositionSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Position",
                table: "Position");

            migrationBuilder.RenameTable(
                name: "Position",
                newName: "Positions");

            migrationBuilder.RenameIndex(
                name: "IX_Position_PositionStatusTypeId",
                table: "Positions",
                newName: "IX_Positions_PositionStatusTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Positions",
                table: "Positions",
                column: "position_id");

            migrationBuilder.AddForeignKey(
                name: "FK_PositionCandidate_Positions_position_id",
                table: "PositionCandidate",
                column: "position_id",
                principalTable: "Positions",
                principalColumn: "position_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionJobRequirement_Positions_position_id",
                table: "PositionJobRequirement",
                column: "position_id",
                principalTable: "Positions",
                principalColumn: "position_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_PositionStatusTypes_PositionStatusTypeId",
                table: "Positions",
                column: "PositionStatusTypeId",
                principalTable: "PositionStatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PositionSkill_Positions_position_id",
                table: "PositionSkill",
                column: "position_id",
                principalTable: "Positions",
                principalColumn: "position_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PositionCandidate_Positions_position_id",
                table: "PositionCandidate");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionJobRequirement_Positions_position_id",
                table: "PositionJobRequirement");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_PositionStatusTypes_PositionStatusTypeId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionSkill_Positions_position_id",
                table: "PositionSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Positions",
                table: "Positions");

            migrationBuilder.RenameTable(
                name: "Positions",
                newName: "Position");

            migrationBuilder.RenameIndex(
                name: "IX_Positions_PositionStatusTypeId",
                table: "Position",
                newName: "IX_Position_PositionStatusTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Position",
                table: "Position",
                column: "position_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Position_PositionStatusTypes_PositionStatusTypeId",
                table: "Position",
                column: "PositionStatusTypeId",
                principalTable: "PositionStatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PositionCandidate_Position_position_id",
                table: "PositionCandidate",
                column: "position_id",
                principalTable: "Position",
                principalColumn: "position_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionJobRequirement_Position_position_id",
                table: "PositionJobRequirement",
                column: "position_id",
                principalTable: "Position",
                principalColumn: "position_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionSkill_Position_position_id",
                table: "PositionSkill",
                column: "position_id",
                principalTable: "Position",
                principalColumn: "position_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
