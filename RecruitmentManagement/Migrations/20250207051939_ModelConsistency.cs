using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentManagement.Migrations
{
    /// <inheritdoc />
    public partial class ModelConsistency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateStatus_CandidateStatusType_StatusId",
                table: "CandidateStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateStatus_PositionCandidates_PositionCandidateId",
                table: "CandidateStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewerInterviews_Interviews_InterviewId",
                table: "InterviewerInterviews");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewerInterviews_Users_InterviewerId",
                table: "InterviewerInterviews");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewFeedbacks_InterviewerInterviews_InterviewerInterviewId",
                table: "InterviewFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewFeedbacks_Skills_SkillId",
                table: "InterviewFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_InterviewTypes_InterviewTypeId",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_PositionCandidates_PositionCandidateId",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Users_RecruiterId",
                table: "Interviews");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PositionStatusTypes",
                newName: "position_status_type_id");

            migrationBuilder.RenameColumn(
                name: "NoOfInterviews",
                table: "PositionInterviews",
                newName: "no_of_inteviews");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PositionInterviews",
                newName: "position_interview_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "InterviewTypes",
                newName: "interview_type_id");

            migrationBuilder.RenameColumn(
                name: "RoundNumber",
                table: "Interviews",
                newName: "round_number");

            migrationBuilder.RenameColumn(
                name: "RecruiterId",
                table: "Interviews",
                newName: "recruiter_id");

            migrationBuilder.RenameColumn(
                name: "PositionCandidateId",
                table: "Interviews",
                newName: "position_candidate_id");

            migrationBuilder.RenameColumn(
                name: "InterviewTypeId",
                table: "Interviews",
                newName: "interview_type_id");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Interviews",
                newName: "interview_date");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Interviews",
                newName: "interview_id");

            migrationBuilder.RenameIndex(
                name: "IX_Interviews_RecruiterId",
                table: "Interviews",
                newName: "IX_Interviews_recruiter_id");

            migrationBuilder.RenameIndex(
                name: "IX_Interviews_PositionCandidateId",
                table: "Interviews",
                newName: "IX_Interviews_position_candidate_id");

            migrationBuilder.RenameIndex(
                name: "IX_Interviews_InterviewTypeId",
                table: "Interviews",
                newName: "IX_Interviews_interview_type_id");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "InterviewFeedbacks",
                newName: "rating");

            migrationBuilder.RenameColumn(
                name: "Feedback",
                table: "InterviewFeedbacks",
                newName: "feedback");

            migrationBuilder.RenameColumn(
                name: "SkillId",
                table: "InterviewFeedbacks",
                newName: "skill_id");

            migrationBuilder.RenameColumn(
                name: "InterviewerInterviewId",
                table: "InterviewFeedbacks",
                newName: "interviewer_interview_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "InterviewFeedbacks",
                newName: "interview_feedback_id");

            migrationBuilder.RenameIndex(
                name: "IX_InterviewFeedbacks_SkillId",
                table: "InterviewFeedbacks",
                newName: "IX_InterviewFeedbacks_skill_id");

            migrationBuilder.RenameIndex(
                name: "IX_InterviewFeedbacks_InterviewerInterviewId",
                table: "InterviewFeedbacks",
                newName: "IX_InterviewFeedbacks_interviewer_interview_id");

            migrationBuilder.RenameColumn(
                name: "InterviewerId",
                table: "InterviewerInterviews",
                newName: "interviewer_id");

            migrationBuilder.RenameColumn(
                name: "InterviewId",
                table: "InterviewerInterviews",
                newName: "interview_id");

            migrationBuilder.RenameColumn(
                name: "InterviewerInterviewId",
                table: "InterviewerInterviews",
                newName: "interviewer_interview_id");

            migrationBuilder.RenameIndex(
                name: "IX_InterviewerInterviews_InterviewId",
                table: "InterviewerInterviews",
                newName: "IX_InterviewerInterviews_interview_id");

            migrationBuilder.RenameIndex(
                name: "IX_InterviewerInterviews_InterviewerId",
                table: "InterviewerInterviews",
                newName: "IX_InterviewerInterviews_interviewer_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "CandidateStatusType",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CandidateStatusType",
                newName: "candiate_status_type_id");

            migrationBuilder.RenameColumn(
                name: "Comments",
                table: "CandidateStatus",
                newName: "comments");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "CandidateStatus",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "CandidateStatus",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "CandidateStatus",
                newName: "status_id");

            migrationBuilder.RenameColumn(
                name: "PositionCandidateId",
                table: "CandidateStatus",
                newName: "position_candidate_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CandidateStatus",
                newName: "candidate_status_id");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateStatus_StatusId",
                table: "CandidateStatus",
                newName: "IX_CandidateStatus_status_id");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateStatus_PositionCandidateId",
                table: "CandidateStatus",
                newName: "IX_CandidateStatus_position_candidate_id");

            migrationBuilder.RenameColumn(
                name: "Experience",
                table: "CandidateSkills",
                newName: "experience");

            migrationBuilder.RenameColumn(
                name: "CandidateId",
                table: "Candidates",
                newName: "candidate_id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateStatus_CandidateStatusType_status_id",
                table: "CandidateStatus",
                column: "status_id",
                principalTable: "CandidateStatusType",
                principalColumn: "candiate_status_type_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateStatus_PositionCandidates_position_candidate_id",
                table: "CandidateStatus",
                column: "position_candidate_id",
                principalTable: "PositionCandidates",
                principalColumn: "position_candidate_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewerInterviews_Interviews_interview_id",
                table: "InterviewerInterviews",
                column: "interview_id",
                principalTable: "Interviews",
                principalColumn: "interview_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewerInterviews_Users_interviewer_id",
                table: "InterviewerInterviews",
                column: "interviewer_id",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewFeedbacks_InterviewerInterviews_interviewer_interview_id",
                table: "InterviewFeedbacks",
                column: "interviewer_interview_id",
                principalTable: "InterviewerInterviews",
                principalColumn: "interviewer_interview_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewFeedbacks_Skills_skill_id",
                table: "InterviewFeedbacks",
                column: "skill_id",
                principalTable: "Skills",
                principalColumn: "skill_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_InterviewTypes_interview_type_id",
                table: "Interviews",
                column: "interview_type_id",
                principalTable: "InterviewTypes",
                principalColumn: "interview_type_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_PositionCandidates_position_candidate_id",
                table: "Interviews",
                column: "position_candidate_id",
                principalTable: "PositionCandidates",
                principalColumn: "position_candidate_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Users_recruiter_id",
                table: "Interviews",
                column: "recruiter_id",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateStatus_CandidateStatusType_status_id",
                table: "CandidateStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateStatus_PositionCandidates_position_candidate_id",
                table: "CandidateStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewerInterviews_Interviews_interview_id",
                table: "InterviewerInterviews");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewerInterviews_Users_interviewer_id",
                table: "InterviewerInterviews");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewFeedbacks_InterviewerInterviews_interviewer_interview_id",
                table: "InterviewFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewFeedbacks_Skills_skill_id",
                table: "InterviewFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_InterviewTypes_interview_type_id",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_PositionCandidates_position_candidate_id",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Users_recruiter_id",
                table: "Interviews");

            migrationBuilder.RenameColumn(
                name: "position_status_type_id",
                table: "PositionStatusTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "no_of_inteviews",
                table: "PositionInterviews",
                newName: "NoOfInterviews");

            migrationBuilder.RenameColumn(
                name: "position_interview_id",
                table: "PositionInterviews",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "interview_type_id",
                table: "InterviewTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "round_number",
                table: "Interviews",
                newName: "RoundNumber");

            migrationBuilder.RenameColumn(
                name: "recruiter_id",
                table: "Interviews",
                newName: "RecruiterId");

            migrationBuilder.RenameColumn(
                name: "position_candidate_id",
                table: "Interviews",
                newName: "PositionCandidateId");

            migrationBuilder.RenameColumn(
                name: "interview_type_id",
                table: "Interviews",
                newName: "InterviewTypeId");

            migrationBuilder.RenameColumn(
                name: "interview_date",
                table: "Interviews",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "interview_id",
                table: "Interviews",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Interviews_recruiter_id",
                table: "Interviews",
                newName: "IX_Interviews_RecruiterId");

            migrationBuilder.RenameIndex(
                name: "IX_Interviews_position_candidate_id",
                table: "Interviews",
                newName: "IX_Interviews_PositionCandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_Interviews_interview_type_id",
                table: "Interviews",
                newName: "IX_Interviews_InterviewTypeId");

            migrationBuilder.RenameColumn(
                name: "rating",
                table: "InterviewFeedbacks",
                newName: "Rating");

            migrationBuilder.RenameColumn(
                name: "feedback",
                table: "InterviewFeedbacks",
                newName: "Feedback");

            migrationBuilder.RenameColumn(
                name: "skill_id",
                table: "InterviewFeedbacks",
                newName: "SkillId");

            migrationBuilder.RenameColumn(
                name: "interviewer_interview_id",
                table: "InterviewFeedbacks",
                newName: "InterviewerInterviewId");

            migrationBuilder.RenameColumn(
                name: "interview_feedback_id",
                table: "InterviewFeedbacks",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_InterviewFeedbacks_skill_id",
                table: "InterviewFeedbacks",
                newName: "IX_InterviewFeedbacks_SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_InterviewFeedbacks_interviewer_interview_id",
                table: "InterviewFeedbacks",
                newName: "IX_InterviewFeedbacks_InterviewerInterviewId");

            migrationBuilder.RenameColumn(
                name: "interviewer_id",
                table: "InterviewerInterviews",
                newName: "InterviewerId");

            migrationBuilder.RenameColumn(
                name: "interview_id",
                table: "InterviewerInterviews",
                newName: "InterviewId");

            migrationBuilder.RenameColumn(
                name: "interviewer_interview_id",
                table: "InterviewerInterviews",
                newName: "InterviewerInterviewId");

            migrationBuilder.RenameIndex(
                name: "IX_InterviewerInterviews_interviewer_id",
                table: "InterviewerInterviews",
                newName: "IX_InterviewerInterviews_InterviewerId");

            migrationBuilder.RenameIndex(
                name: "IX_InterviewerInterviews_interview_id",
                table: "InterviewerInterviews",
                newName: "IX_InterviewerInterviews_InterviewId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "CandidateStatusType",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "candiate_status_type_id",
                table: "CandidateStatusType",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "comments",
                table: "CandidateStatus",
                newName: "Comments");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "CandidateStatus",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "CandidateStatus",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "status_id",
                table: "CandidateStatus",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "position_candidate_id",
                table: "CandidateStatus",
                newName: "PositionCandidateId");

            migrationBuilder.RenameColumn(
                name: "candidate_status_id",
                table: "CandidateStatus",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateStatus_status_id",
                table: "CandidateStatus",
                newName: "IX_CandidateStatus_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateStatus_position_candidate_id",
                table: "CandidateStatus",
                newName: "IX_CandidateStatus_PositionCandidateId");

            migrationBuilder.RenameColumn(
                name: "experience",
                table: "CandidateSkills",
                newName: "Experience");

            migrationBuilder.RenameColumn(
                name: "candidate_id",
                table: "Candidates",
                newName: "CandidateId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateStatus_CandidateStatusType_StatusId",
                table: "CandidateStatus",
                column: "StatusId",
                principalTable: "CandidateStatusType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateStatus_PositionCandidates_PositionCandidateId",
                table: "CandidateStatus",
                column: "PositionCandidateId",
                principalTable: "PositionCandidates",
                principalColumn: "position_candidate_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewerInterviews_Interviews_InterviewId",
                table: "InterviewerInterviews",
                column: "InterviewId",
                principalTable: "Interviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewerInterviews_Users_InterviewerId",
                table: "InterviewerInterviews",
                column: "InterviewerId",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewFeedbacks_InterviewerInterviews_InterviewerInterviewId",
                table: "InterviewFeedbacks",
                column: "InterviewerInterviewId",
                principalTable: "InterviewerInterviews",
                principalColumn: "InterviewerInterviewId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewFeedbacks_Skills_SkillId",
                table: "InterviewFeedbacks",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "skill_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_InterviewTypes_InterviewTypeId",
                table: "Interviews",
                column: "InterviewTypeId",
                principalTable: "InterviewTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_PositionCandidates_PositionCandidateId",
                table: "Interviews",
                column: "PositionCandidateId",
                principalTable: "PositionCandidates",
                principalColumn: "position_candidate_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Users_RecruiterId",
                table: "Interviews",
                column: "RecruiterId",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
