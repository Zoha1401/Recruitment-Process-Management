using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentManagement.Migrations
{
    /// <inheritdoc />
    public partial class PostionStatusType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PositionJobRequirement_JobRequirement_requirement_id",
                table: "PositionJobRequirement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobRequirement",
                table: "JobRequirement");

            migrationBuilder.RenameTable(
                name: "JobRequirement",
                newName: "JobRequirements");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobRequirements",
                table: "JobRequirements",
                column: "job_requirement_id");

            migrationBuilder.AddForeignKey(
                name: "FK_PositionJobRequirement_JobRequirements_requirement_id",
                table: "PositionJobRequirement",
                column: "requirement_id",
                principalTable: "JobRequirements",
                principalColumn: "job_requirement_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PositionJobRequirement_JobRequirements_requirement_id",
                table: "PositionJobRequirement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobRequirements",
                table: "JobRequirements");

            migrationBuilder.RenameTable(
                name: "JobRequirements",
                newName: "JobRequirement");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobRequirement",
                table: "JobRequirement",
                column: "job_requirement_id");

            migrationBuilder.AddForeignKey(
                name: "FK_PositionJobRequirement_JobRequirement_requirement_id",
                table: "PositionJobRequirement",
                column: "requirement_id",
                principalTable: "JobRequirement",
                principalColumn: "job_requirement_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
