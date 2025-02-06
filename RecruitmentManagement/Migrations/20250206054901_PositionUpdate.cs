using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentManagement.Migrations
{
    /// <inheritdoc />
    public partial class PositionUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Positions_PositionStatusTypes_PositionStatusTypeId",
                table: "Positions");

            migrationBuilder.AlterColumn<int>(
                name: "PositionStatusTypeId",
                table: "Positions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_PositionStatusTypes_PositionStatusTypeId",
                table: "Positions",
                column: "PositionStatusTypeId",
                principalTable: "PositionStatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Positions_PositionStatusTypes_PositionStatusTypeId",
                table: "Positions");

            migrationBuilder.AlterColumn<int>(
                name: "PositionStatusTypeId",
                table: "Positions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_PositionStatusTypes_PositionStatusTypeId",
                table: "Positions",
                column: "PositionStatusTypeId",
                principalTable: "PositionStatusTypes",
                principalColumn: "Id");
        }
    }
}
