using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentManagement.Migrations
{
    /// <inheritdoc />
    public partial class DBCOntext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_InterviewType_InterviewTypeId",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionInterview_InterviewType_interview_type_id",
                table: "PositionInterview");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionInterview_Positions_position_id",
                table: "PositionInterview");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PositionInterview",
                table: "PositionInterview");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InterviewType",
                table: "InterviewType");

            migrationBuilder.RenameTable(
                name: "PositionInterview",
                newName: "PositionInterviews");

            migrationBuilder.RenameTable(
                name: "InterviewType",
                newName: "InterviewTypes");

            migrationBuilder.RenameIndex(
                name: "IX_PositionInterview_position_id",
                table: "PositionInterviews",
                newName: "IX_PositionInterviews_position_id");

            migrationBuilder.RenameIndex(
                name: "IX_PositionInterview_interview_type_id",
                table: "PositionInterviews",
                newName: "IX_PositionInterviews_interview_type_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PositionInterviews",
                table: "PositionInterviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InterviewTypes",
                table: "InterviewTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_InterviewTypes_InterviewTypeId",
                table: "Interviews",
                column: "InterviewTypeId",
                principalTable: "InterviewTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionInterviews_InterviewTypes_interview_type_id",
                table: "PositionInterviews",
                column: "interview_type_id",
                principalTable: "InterviewTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionInterviews_Positions_position_id",
                table: "PositionInterviews",
                column: "position_id",
                principalTable: "Positions",
                principalColumn: "position_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_InterviewTypes_InterviewTypeId",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionInterviews_InterviewTypes_interview_type_id",
                table: "PositionInterviews");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionInterviews_Positions_position_id",
                table: "PositionInterviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PositionInterviews",
                table: "PositionInterviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InterviewTypes",
                table: "InterviewTypes");

            migrationBuilder.RenameTable(
                name: "PositionInterviews",
                newName: "PositionInterview");

            migrationBuilder.RenameTable(
                name: "InterviewTypes",
                newName: "InterviewType");

            migrationBuilder.RenameIndex(
                name: "IX_PositionInterviews_position_id",
                table: "PositionInterview",
                newName: "IX_PositionInterview_position_id");

            migrationBuilder.RenameIndex(
                name: "IX_PositionInterviews_interview_type_id",
                table: "PositionInterview",
                newName: "IX_PositionInterview_interview_type_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PositionInterview",
                table: "PositionInterview",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InterviewType",
                table: "InterviewType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_InterviewType_InterviewTypeId",
                table: "Interviews",
                column: "InterviewTypeId",
                principalTable: "InterviewType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionInterview_InterviewType_interview_type_id",
                table: "PositionInterview",
                column: "interview_type_id",
                principalTable: "InterviewType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionInterview_Positions_position_id",
                table: "PositionInterview",
                column: "position_id",
                principalTable: "Positions",
                principalColumn: "position_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
