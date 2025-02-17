using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentManagement.Migrations
{
    /// <inheritdoc />
    public partial class PositionStatusType1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PositionStatusTypeId",
                table: "Position",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PositionStatusTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionStatusTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Position_PositionStatusTypeId",
                table: "Position",
                column: "PositionStatusTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Position_PositionStatusTypes_PositionStatusTypeId",
                table: "Position",
                column: "PositionStatusTypeId",
                principalTable: "PositionStatusTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Position_PositionStatusTypes_PositionStatusTypeId",
                table: "Position");

            migrationBuilder.DropTable(
                name: "PositionStatusTypes");

            migrationBuilder.DropIndex(
                name: "IX_Position_PositionStatusTypeId",
                table: "Position");

            migrationBuilder.DropColumn(
                name: "PositionStatusTypeId",
                table: "Position");
        }
    }
}
