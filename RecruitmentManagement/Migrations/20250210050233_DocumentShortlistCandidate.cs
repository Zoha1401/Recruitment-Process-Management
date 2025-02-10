using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentManagement.Migrations
{
    /// <inheritdoc />
    public partial class DocumentShortlistCandidate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PositionSkills_Positions_position_id",
                table: "PositionSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionSkills_Skills_skill_id",
                table: "PositionSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_ShortlistCandidate_Candidates_CandidateId",
                table: "ShortlistCandidate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShortlistCandidate",
                table: "ShortlistCandidate");

            migrationBuilder.RenameTable(
                name: "ShortlistCandidate",
                newName: "ShortlistCandidates");

            migrationBuilder.RenameColumn(
                name: "JoiningDate",
                table: "ShortlistCandidates",
                newName: "joining_date");

            migrationBuilder.RenameColumn(
                name: "CandidateId",
                table: "ShortlistCandidates",
                newName: "canidate_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ShortlistCandidates",
                newName: "shortlist_candidate_id");

            migrationBuilder.RenameIndex(
                name: "IX_ShortlistCandidate_CandidateId",
                table: "ShortlistCandidates",
                newName: "IX_ShortlistCandidates_canidate_id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "joining_date",
                table: "ShortlistCandidates",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "position_id",
                table: "ShortlistCandidates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShortlistCandidates",
                table: "ShortlistCandidates",
                column: "shortlist_candidate_id");

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    document_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    document_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shortlist_id = table.Column<int>(type: "int", nullable: false),
                    ShortlistCandidateId = table.Column<int>(type: "int", nullable: false),
                    document_status_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.document_id);
                    table.ForeignKey(
                        name: "FK_Documents_ShortlistCandidates_ShortlistCandidateId",
                        column: x => x.ShortlistCandidateId,
                        principalTable: "ShortlistCandidates",
                        principalColumn: "shortlist_candidate_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentStatusTypes",
                columns: table => new
                {
                    document_status_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentStatusTypes", x => x.document_status_type_id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentStatuses",
                columns: table => new
                {
                    document_status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    document_status_type_id = table.Column<int>(type: "int", nullable: false),
                    document_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentStatuses", x => x.document_status_id);
                    table.ForeignKey(
                        name: "FK_DocumentStatuses_DocumentStatusTypes_document_status_type_id",
                        column: x => x.document_status_type_id,
                        principalTable: "DocumentStatusTypes",
                        principalColumn: "document_status_type_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentStatuses_Documents_document_id",
                        column: x => x.document_id,
                        principalTable: "Documents",
                        principalColumn: "document_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShortlistCandidates_position_id",
                table: "ShortlistCandidates",
                column: "position_id");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ShortlistCandidateId",
                table: "Documents",
                column: "ShortlistCandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentStatuses_document_id",
                table: "DocumentStatuses",
                column: "document_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentStatuses_document_status_type_id",
                table: "DocumentStatuses",
                column: "document_status_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_PositionSkills_Positions_position_id",
                table: "PositionSkills",
                column: "position_id",
                principalTable: "Positions",
                principalColumn: "position_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionSkills_Skills_skill_id",
                table: "PositionSkills",
                column: "skill_id",
                principalTable: "Skills",
                principalColumn: "skill_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShortlistCandidates_Candidates_canidate_id",
                table: "ShortlistCandidates",
                column: "canidate_id",
                principalTable: "Candidates",
                principalColumn: "candidate_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShortlistCandidates_Positions_position_id",
                table: "ShortlistCandidates",
                column: "position_id",
                principalTable: "Positions",
                principalColumn: "position_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PositionSkills_Positions_position_id",
                table: "PositionSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionSkills_Skills_skill_id",
                table: "PositionSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_ShortlistCandidates_Candidates_canidate_id",
                table: "ShortlistCandidates");

            migrationBuilder.DropForeignKey(
                name: "FK_ShortlistCandidates_Positions_position_id",
                table: "ShortlistCandidates");

            migrationBuilder.DropTable(
                name: "DocumentStatuses");

            migrationBuilder.DropTable(
                name: "DocumentStatusTypes");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShortlistCandidates",
                table: "ShortlistCandidates");

            migrationBuilder.DropIndex(
                name: "IX_ShortlistCandidates_position_id",
                table: "ShortlistCandidates");

            migrationBuilder.DropColumn(
                name: "position_id",
                table: "ShortlistCandidates");

            migrationBuilder.RenameTable(
                name: "ShortlistCandidates",
                newName: "ShortlistCandidate");

            migrationBuilder.RenameColumn(
                name: "joining_date",
                table: "ShortlistCandidate",
                newName: "JoiningDate");

            migrationBuilder.RenameColumn(
                name: "canidate_id",
                table: "ShortlistCandidate",
                newName: "CandidateId");

            migrationBuilder.RenameColumn(
                name: "shortlist_candidate_id",
                table: "ShortlistCandidate",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_ShortlistCandidates_canidate_id",
                table: "ShortlistCandidate",
                newName: "IX_ShortlistCandidate_CandidateId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoiningDate",
                table: "ShortlistCandidate",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShortlistCandidate",
                table: "ShortlistCandidate",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PositionSkills_Positions_position_id",
                table: "PositionSkills",
                column: "position_id",
                principalTable: "Positions",
                principalColumn: "position_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionSkills_Skills_skill_id",
                table: "PositionSkills",
                column: "skill_id",
                principalTable: "Skills",
                principalColumn: "skill_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShortlistCandidate_Candidates_CandidateId",
                table: "ShortlistCandidate",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "candidate_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
