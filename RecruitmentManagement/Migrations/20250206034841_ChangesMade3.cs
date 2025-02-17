using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentManagement.Migrations
{
    /// <inheritdoc />
    public partial class ChangesMade3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Positions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "reviewer_id",
                table: "Positions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "status_id",
                table: "Positions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Positions_reviewer_id",
                table: "Positions",
                column: "reviewer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Users_reviewer_id",
                table: "Positions",
                column: "reviewer_id",
                principalTable: "Users",
                principalColumn: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Users_reviewer_id",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Positions_reviewer_id",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "description",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "reviewer_id",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "status_id",
                table: "Positions");
        }
    }
}
