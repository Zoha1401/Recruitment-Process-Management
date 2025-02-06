using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentManagement.Migrations
{
    /// <inheritdoc />
    public partial class Models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    college_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    degree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    work_experience = table.Column<float>(type: "real", nullable: false),
                    resume_url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CandidateStatusType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateStatusType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobRequirement",
                columns: table => new
                {
                    job_requirement_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    job_requirement_namw = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobRequirement", x => x.job_requirement_id);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    position_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    position_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    noOfInterviews = table.Column<int>(type: "int", nullable: false),
                    min_exp = table.Column<int>(type: "int", nullable: false),
                    max_exp = table.Column<int>(type: "int", nullable: false),
                    closure_reason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.position_id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    skill_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    skill_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.skill_id);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShortlistCandidate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortlistCandidate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShortlistCandidate_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PositionCandidate",
                columns: table => new
                {
                    position_candidate_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    position_id = table.Column<int>(type: "int", nullable: false),
                    candidate_id = table.Column<int>(type: "int", nullable: false),
                    comments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionCandidate", x => x.position_candidate_id);
                    table.ForeignKey(
                        name: "FK_PositionCandidate_Candidate_candidate_id",
                        column: x => x.candidate_id,
                        principalTable: "Candidate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PositionCandidate_Position_position_id",
                        column: x => x.position_id,
                        principalTable: "Position",
                        principalColumn: "position_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PositionJobRequirement",
                columns: table => new
                {
                    positon_job_requirement_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    requirement_id = table.Column<int>(type: "int", nullable: false),
                    position_id = table.Column<int>(type: "int", nullable: false),
                    comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionJobRequirement", x => x.positon_job_requirement_id);
                    table.ForeignKey(
                        name: "FK_PositionJobRequirement_JobRequirement_requirement_id",
                        column: x => x.requirement_id,
                        principalTable: "JobRequirement",
                        principalColumn: "job_requirement_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PositionJobRequirement_Position_position_id",
                        column: x => x.position_id,
                        principalTable: "Position",
                        principalColumn: "position_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateSkill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    Experience = table.Column<float>(type: "real", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateSkill_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateSkill_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "skill_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PositionSkill",
                columns: table => new
                {
                    position_skill_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    position_id = table.Column<int>(type: "int", nullable: false),
                    skill_id = table.Column<int>(type: "int", nullable: false),
                    isRequired = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionSkill", x => x.position_skill_id);
                    table.ForeignKey(
                        name: "FK_PositionSkill_Position_position_id",
                        column: x => x.position_id,
                        principalTable: "Position",
                        principalColumn: "position_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PositionSkill_Skills_skill_id",
                        column: x => x.skill_id,
                        principalTable: "Skills",
                        principalColumn: "skill_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    PositionCandidateId = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateStatus_CandidateStatusType_StatusId",
                        column: x => x.StatusId,
                        principalTable: "CandidateStatusType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateStatus_PositionCandidate_PositionCandidateId",
                        column: x => x.PositionCandidateId,
                        principalTable: "PositionCandidate",
                        principalColumn: "position_candidate_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interview",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PositionCandidateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interview_PositionCandidate_PositionCandidateId",
                        column: x => x.PositionCandidateId,
                        principalTable: "PositionCandidate",
                        principalColumn: "position_candidate_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InterviewerInterview",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterviewId = table.Column<int>(type: "int", nullable: true),
                    InterviewerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewerInterview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InterviewerInterview_Interview_InterviewId",
                        column: x => x.InterviewId,
                        principalTable: "Interview",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InterviewerInterview_Users_InterviewerId",
                        column: x => x.InterviewerId,
                        principalTable: "Users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "InterviewFeedback",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterviewId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    Feedback = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PositionCandidateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewFeedback", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InterviewFeedback_Interview_InterviewId",
                        column: x => x.InterviewId,
                        principalTable: "Interview",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterviewFeedback_PositionCandidate_PositionCandidateId",
                        column: x => x.PositionCandidateId,
                        principalTable: "PositionCandidate",
                        principalColumn: "position_candidate_id");
                    table.ForeignKey(
                        name: "FK_InterviewFeedback_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "skill_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSkill_CandidateId",
                table: "CandidateSkill",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSkill_SkillId",
                table: "CandidateSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateStatus_PositionCandidateId",
                table: "CandidateStatus",
                column: "PositionCandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateStatus_StatusId",
                table: "CandidateStatus",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Interview_PositionCandidateId",
                table: "Interview",
                column: "PositionCandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewerInterview_InterviewerId",
                table: "InterviewerInterview",
                column: "InterviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewerInterview_InterviewId",
                table: "InterviewerInterview",
                column: "InterviewId");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewFeedback_InterviewId",
                table: "InterviewFeedback",
                column: "InterviewId");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewFeedback_PositionCandidateId",
                table: "InterviewFeedback",
                column: "PositionCandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewFeedback_SkillId",
                table: "InterviewFeedback",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_CandidateId",
                table: "Notification",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionCandidate_candidate_id",
                table: "PositionCandidate",
                column: "candidate_id");

            migrationBuilder.CreateIndex(
                name: "IX_PositionCandidate_position_id",
                table: "PositionCandidate",
                column: "position_id");

            migrationBuilder.CreateIndex(
                name: "IX_PositionJobRequirement_position_id",
                table: "PositionJobRequirement",
                column: "position_id");

            migrationBuilder.CreateIndex(
                name: "IX_PositionJobRequirement_requirement_id",
                table: "PositionJobRequirement",
                column: "requirement_id");

            migrationBuilder.CreateIndex(
                name: "IX_PositionSkill_position_id",
                table: "PositionSkill",
                column: "position_id");

            migrationBuilder.CreateIndex(
                name: "IX_PositionSkill_skill_id",
                table: "PositionSkill",
                column: "skill_id");

            migrationBuilder.CreateIndex(
                name: "IX_ShortlistCandidate_CandidateId",
                table: "ShortlistCandidate",
                column: "CandidateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateSkill");

            migrationBuilder.DropTable(
                name: "CandidateStatus");

            migrationBuilder.DropTable(
                name: "InterviewerInterview");

            migrationBuilder.DropTable(
                name: "InterviewFeedback");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "PositionJobRequirement");

            migrationBuilder.DropTable(
                name: "PositionSkill");

            migrationBuilder.DropTable(
                name: "ShortlistCandidate");

            migrationBuilder.DropTable(
                name: "CandidateStatusType");

            migrationBuilder.DropTable(
                name: "Interview");

            migrationBuilder.DropTable(
                name: "JobRequirement");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "PositionCandidate");

            migrationBuilder.DropTable(
                name: "Candidate");

            migrationBuilder.DropTable(
                name: "Position");
        }
    }
}
