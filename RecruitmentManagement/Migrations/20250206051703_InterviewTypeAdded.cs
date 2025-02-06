using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentManagement.Migrations
{
    /// <inheritdoc />
    public partial class InterviewTypeAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterviewFeedback_Interviews_InterviewId",
                table: "InterviewFeedback");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Interviews");

            migrationBuilder.AddColumn<int>(
                name: "InterviewTypeId",
                table: "Interviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecruiterId",
                table: "Interviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Interviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "InterviewId",
                table: "InterviewFeedback",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "InterviewInterviewerId",
                table: "InterviewFeedback",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InterviewerInterviewId",
                table: "InterviewFeedback",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "InterviewType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    interview_type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PositionInterview",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    position_id = table.Column<int>(type: "int", nullable: false),
                    NoOfInterviews = table.Column<int>(type: "int", nullable: false),
                    interview_type_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionInterview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PositionInterview_InterviewType_interview_type_id",
                        column: x => x.interview_type_id,
                        principalTable: "InterviewType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PositionInterview_Positions_position_id",
                        column: x => x.position_id,
                        principalTable: "Positions",
                        principalColumn: "position_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_InterviewTypeId",
                table: "Interviews",
                column: "InterviewTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_RecruiterId",
                table: "Interviews",
                column: "RecruiterId");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewFeedback_InterviewerInterviewId",
                table: "InterviewFeedback",
                column: "InterviewerInterviewId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionInterview_interview_type_id",
                table: "PositionInterview",
                column: "interview_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_PositionInterview_position_id",
                table: "PositionInterview",
                column: "position_id");

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewFeedback_InterviewerInterview_InterviewerInterviewId",
                table: "InterviewFeedback",
                column: "InterviewerInterviewId",
                principalTable: "InterviewerInterview",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewFeedback_Interviews_InterviewId",
                table: "InterviewFeedback",
                column: "InterviewId",
                principalTable: "Interviews",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_InterviewType_InterviewTypeId",
                table: "Interviews",
                column: "InterviewTypeId",
                principalTable: "InterviewType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Users_RecruiterId",
                table: "Interviews",
                column: "RecruiterId",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterviewFeedback_InterviewerInterview_InterviewerInterviewId",
                table: "InterviewFeedback");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewFeedback_Interviews_InterviewId",
                table: "InterviewFeedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_InterviewType_InterviewTypeId",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Users_RecruiterId",
                table: "Interviews");

            migrationBuilder.DropTable(
                name: "PositionInterview");

            migrationBuilder.DropTable(
                name: "InterviewType");

            migrationBuilder.DropIndex(
                name: "IX_Interviews_InterviewTypeId",
                table: "Interviews");

            migrationBuilder.DropIndex(
                name: "IX_Interviews_RecruiterId",
                table: "Interviews");

            migrationBuilder.DropIndex(
                name: "IX_InterviewFeedback_InterviewerInterviewId",
                table: "InterviewFeedback");

            migrationBuilder.DropColumn(
                name: "InterviewTypeId",
                table: "Interviews");

            migrationBuilder.DropColumn(
                name: "RecruiterId",
                table: "Interviews");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Interviews");

            migrationBuilder.DropColumn(
                name: "InterviewInterviewerId",
                table: "InterviewFeedback");

            migrationBuilder.DropColumn(
                name: "InterviewerInterviewId",
                table: "InterviewFeedback");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Interviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "InterviewId",
                table: "InterviewFeedback",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewFeedback_Interviews_InterviewId",
                table: "InterviewFeedback",
                column: "InterviewId",
                principalTable: "Interviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
