using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentManagement.Migrations
{
    /// <inheritdoc />
    public partial class PositionUpdate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Positions_PositionStatusTypes_PositionStatusTypeId",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Positions_PositionStatusTypeId",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "PositionStatusTypeId",
                table: "Positions");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_status_id",
                table: "Positions",
                column: "status_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_PositionStatusTypes_status_id",
                table: "Positions",
                column: "status_id",
                principalTable: "PositionStatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Positions_PositionStatusTypes_status_id",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Positions_status_id",
                table: "Positions");

            migrationBuilder.AddColumn<int>(
                name: "PositionStatusTypeId",
                table: "Positions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Positions_PositionStatusTypeId",
                table: "Positions",
                column: "PositionStatusTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_PositionStatusTypes_PositionStatusTypeId",
                table: "Positions",
                column: "PositionStatusTypeId",
                principalTable: "PositionStatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
