using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentManagement.Migrations
{
    /// <inheritdoc />
    public partial class CandidateLinkedWithUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "password",
                table: "Candidates");

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "Candidates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_user_id",
                table: "Candidates",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Users_user_id",
                table: "Candidates",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Users_user_id",
                table: "Candidates");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_user_id",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "Candidates");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
