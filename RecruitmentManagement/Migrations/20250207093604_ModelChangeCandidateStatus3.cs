using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentManagement.Migrations
{
    /// <inheritdoc />
    public partial class ModelChangeCandidateStatus3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateStatuses_Users_UserId",
                table: "CandidateStatuses");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "CandidateStatuses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateStatuses_Users_UserId",
                table: "CandidateStatuses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateStatuses_Users_UserId",
                table: "CandidateStatuses");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "CandidateStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateStatuses_Users_UserId",
                table: "CandidateStatuses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
