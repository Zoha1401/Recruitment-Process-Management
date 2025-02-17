using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentManagement.Migrations
{
    /// <inheritdoc />
    public partial class Candidate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSkill_Candidate_CandidateId",
                table: "CandidateSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_Candidate_CandidateId",
                table: "Notification");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionCandidate_Candidate_candidate_id",
                table: "PositionCandidate");

            migrationBuilder.DropForeignKey(
                name: "FK_ShortlistCandidate_Candidate_CandidateId",
                table: "ShortlistCandidate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Candidate",
                table: "Candidate");

            migrationBuilder.RenameTable(
                name: "Candidate",
                newName: "Candidates");

            migrationBuilder.RenameColumn(
                name: "job_requirement_namw",
                table: "JobRequirement",
                newName: "job_requirement_name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Candidates",
                table: "Candidates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSkill_Candidates_CandidateId",
                table: "CandidateSkill",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_Candidates_CandidateId",
                table: "Notification",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionCandidate_Candidates_candidate_id",
                table: "PositionCandidate",
                column: "candidate_id",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShortlistCandidate_Candidates_CandidateId",
                table: "ShortlistCandidate",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSkill_Candidates_CandidateId",
                table: "CandidateSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_Candidates_CandidateId",
                table: "Notification");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionCandidate_Candidates_candidate_id",
                table: "PositionCandidate");

            migrationBuilder.DropForeignKey(
                name: "FK_ShortlistCandidate_Candidates_CandidateId",
                table: "ShortlistCandidate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Candidates",
                table: "Candidates");

            migrationBuilder.RenameTable(
                name: "Candidates",
                newName: "Candidate");

            migrationBuilder.RenameColumn(
                name: "job_requirement_name",
                table: "JobRequirement",
                newName: "job_requirement_namw");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Candidate",
                table: "Candidate",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSkill_Candidate_CandidateId",
                table: "CandidateSkill",
                column: "CandidateId",
                principalTable: "Candidate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_Candidate_CandidateId",
                table: "Notification",
                column: "CandidateId",
                principalTable: "Candidate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionCandidate_Candidate_candidate_id",
                table: "PositionCandidate",
                column: "candidate_id",
                principalTable: "Candidate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShortlistCandidate_Candidate_CandidateId",
                table: "ShortlistCandidate",
                column: "CandidateId",
                principalTable: "Candidate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
