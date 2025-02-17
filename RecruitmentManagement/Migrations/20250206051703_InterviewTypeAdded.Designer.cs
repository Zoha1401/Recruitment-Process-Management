﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecruitmentProcessManagementSystem.Data;

#nullable disable

namespace RecruitmentManagement.Migrations
{
    [DbContext(typeof(RecruitmentDbContext))]
    [Migration("20250206051703_InterviewTypeAdded")]
    partial class InterviewTypeAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RecruitmentManagement.Model.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CollegeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("college_name");

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("degree");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("ResumeUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("resume_url");

                    b.Property<float>("WorkExperience")
                        .HasColumnType("real")
                        .HasColumnName("work_experience");

                    b.HasKey("Id");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("RecruitmentManagement.Model.CandidateSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CandidateId")
                        .HasColumnType("int");

                    b.Property<float>("Experience")
                        .HasColumnType("real");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("SkillId");

                    b.ToTable("CandidateSkills");
                });

            modelBuilder.Entity("RecruitmentManagement.Model.CandidateStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PositionCandidateId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PositionCandidateId");

                    b.HasIndex("StatusId");

                    b.ToTable("CandidateStatus");
                });

            modelBuilder.Entity("RecruitmentManagement.Model.CandidateStatusType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CandidateStatusType");
                });

            modelBuilder.Entity("RecruitmentManagement.Model.Interview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("InterviewTypeId")
                        .HasColumnType("int");

                    b.Property<int>("PositionCandidateId")
                        .HasColumnType("int");

                    b.Property<int>("RecruiterId")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InterviewTypeId");

                    b.HasIndex("PositionCandidateId");

                    b.HasIndex("RecruiterId");

                    b.ToTable("Interviews");
                });

            modelBuilder.Entity("RecruitmentManagement.Model.InterviewFeedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Feedback")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("InterviewId")
                        .HasColumnType("int");

                    b.Property<int>("InterviewInterviewerId")
                        .HasColumnType("int");

                    b.Property<int>("InterviewerInterviewId")
                        .HasColumnType("int");

                    b.Property<int?>("PositionCandidateId")
                        .HasColumnType("int");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InterviewId");

                    b.HasIndex("InterviewerInterviewId");

                    b.HasIndex("PositionCandidateId");

                    b.HasIndex("SkillId");

                    b.ToTable("InterviewFeedback");
                });

            modelBuilder.Entity("RecruitmentManagement.Model.InterviewType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("interview_type");

                    b.HasKey("Id");

                    b.ToTable("InterviewType");
                });

            modelBuilder.Entity("RecruitmentManagement.Model.InterviewerInterview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("InterviewId")
                        .HasColumnType("int");

                    b.Property<int?>("InterviewerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InterviewId");

                    b.HasIndex("InterviewerId");

                    b.ToTable("InterviewerInterview");
                });

            modelBuilder.Entity("RecruitmentManagement.Model.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CandidateId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("RecruitmentManagement.Model.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("position_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<int>("MaxExp")
                        .HasColumnType("int")
                        .HasColumnName("max_exp");

                    b.Property<int>("MinExp")
                        .HasColumnType("int")
                        .HasColumnName("min_exp");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("position_name");

                    b.Property<int>("NoOfInterviews")
                        .HasColumnType("int")
                        .HasColumnName("noOfInterviews");

                    b.Property<int?>("PositionStatusTypeId")
                        .HasColumnType("int");

                    b.Property<string>("ReasonForClosure")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("closure_reason");

                    b.Property<int?>("ReviewerId")
                        .HasColumnType("int")
                        .HasColumnName("reviewer_id");

                    b.Property<int>("StatusId")
                        .HasColumnType("int")
                        .HasColumnName("status_id");

                    b.HasKey("Id");

                    b.HasIndex("PositionStatusTypeId");

                    b.HasIndex("ReviewerId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("RecruitmentManagement.Model.PositionCandidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("position_candidate_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CandidateId")
                        .HasColumnType("int")
                        .HasColumnName("candidate_id");

                    b.Property<bool>("IsShortlisted")
                        .HasColumnType("bit")
                        .HasColumnName("comments");

                    b.Property<int>("PositionId")
                        .HasColumnType("int")
                        .HasColumnName("position_id");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("PositionId");

                    b.ToTable("PositionCandidates");
                });

            modelBuilder.Entity("RecruitmentManagement.Model.PositionInterview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("InterviewTypeId")
                        .HasColumnType("int")
                        .HasColumnName("interview_type_id");

                    b.Property<int>("NoOfInterviews")
                        .HasColumnType("int");

                    b.Property<int>("PositionId")
                        .HasColumnType("int")
                        .HasColumnName("position_id");

                    b.HasKey("Id");

                    b.HasIndex("InterviewTypeId");

                    b.HasIndex("PositionId");

                    b.ToTable("PositionInterview");
                });

            modelBuilder.Entity("RecruitmentManagement.Model.PositionSkill", b =>
                {
                    b.Property<int>("PositionId")
                        .HasColumnType("int")
                        .HasColumnName("position_id");

                    b.Property<int>("SkillId")
                        .HasColumnType("int")
                        .HasColumnName("skill_id");

                    b.Property<string>("Required")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Required");

                    b.HasKey("PositionId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("PositionSkills");
                });

            modelBuilder.Entity("RecruitmentManagement.Model.PositionStatusType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("status_name");

                    b.HasKey("Id");

                    b.ToTable("PositionStatusTypes");
                });

            modelBuilder.Entity("RecruitmentManagement.Model.ShortlistCandidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CandidateId")
                        .HasColumnType("int");

                    b.Property<DateTime>("JoiningDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.ToTable("ShortlistCandidate");
                });

            modelBuilder.Entity("RecruitmentManagement.Model.Skill", b =>
                {
                    b.Property<int>("SkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("skill_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SkillId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("skill_name");

                    b.HasKey("SkillId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("RecruitmentProcessManagementSystem.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("role_name");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("RecruitmentProcessManagementSystem.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date")
                        .HasColumnName("birth_date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("phone");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RecruitmentManagement.Model.CandidateSkill", b =>
                {
                    b.HasOne("RecruitmentManagement.Model.Candidate", "Candidate")
                        .WithMany("CandidateSkills")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecruitmentManagement.Model.Skill", "Skill")
                        .WithMany("CandidateSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("RecruitmentManagement.Model.CandidateStatus", b =>
                {
                    b.HasOne("RecruitmentManagement.Model.PositionCandidate", "PositionCandidate")
                        .WithMany("CandidateStatuses")
                        .HasForeignKey("PositionCandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecruitmentManagement.Model.CandidateStatusType", "Status")
                        .WithMany("CandidateStatuses")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PositionCandidate");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("RecruitmentManagement.Model.Interview", b =>
                {
                    b.HasOne("RecruitmentManagement.Model.InterviewType", "InterviewType")
                        .WithMany()
                        .HasForeignKey("InterviewTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecruitmentManagement.Model.PositionCandidate", "PositionCandidate")
                        .WithMany("Interviews")
                        .HasForeignKey("PositionCandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecruitmentProcessManagementSystem.Models.User", "Recruiter")
                        .WithMany()
                        .HasForeignKey("RecruiterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InterviewType");

                    b.Navigation("PositionCandidate");

                    b.Navigation("Recruiter");
                });

            modelBuilder.Entity("RecruitmentManagement.Model.InterviewFeedback", b =>
                {
                    b.HasOne("RecruitmentManagement.Model.Interview", null)
                        .WithMany("InterviewFeedbacks")
                        .HasForeignKey("InterviewId");

                    b.HasOne("RecruitmentManagement.Model.InterviewerInterview", "InterviewerInterview")
                        .WithMany()
                        .HasForeignKey("InterviewerInterviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecruitmentManagement.Model.PositionCandidate", null)
                        .WithMany("InterviewFeedbacks")
                        .HasForeignKey("PositionCandidateId");

                    b.HasOne("RecruitmentManagement.Model.Skill", "Skill")
                        .WithMany("InterviewFeedbacks")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InterviewerInterview");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("RecruitmentManagement.Model.InterviewerInterview", b =>
                {
                    b.HasOne("RecruitmentManagement.Model.Interview", "Interview")
                        .WithMany("InterviewerInterviews")
                        .HasForeignKey("InterviewId");

                    b.HasOne("RecruitmentProcessManagementSystem.Models.User", "Interviewer")
                        .WithMany()
                        .HasForeignKey("InterviewerId");

                    b.Navigation("Interview");

                    b.Navigation("Interviewer");
                });

            modelBuilder.Entity("RecruitmentManagement.Model.Notification", b =>
                {
                    b.HasOne("RecruitmentManagement.Model.Candidate", "Candidate")
                        .WithMany("Notifications")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("RecruitmentManagement.Model.Position", b =>
                {
                    b.HasOne("RecruitmentManagement.Model.PositionStatusType", null)
                        .WithMany("Positions")
                        .HasForeignKey("PositionStatusTypeId");

                    b.HasOne("RecruitmentProcessManagementSystem.Models.User", "Reviewer")
                        .WithMany()
                        .HasForeignKey("ReviewerId");

                    b.Navigation("Reviewer");
                });

            modelBuilder.Entity("RecruitmentManagement.Model.PositionCandidate", b =>
                {
                    b.HasOne("RecruitmentManagement.Model.Candidate", "Candidate")
                        .WithMany("PositionCandidates")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecruitmentManagement.Model.Position", "Position")
                        .WithMany("PositionCandidates")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("RecruitmentManagement.Model.PositionInterview", b =>
                {
                    b.HasOne("RecruitmentManagement.Model.InterviewType", null)
                        .WithMany("positionInterviews")
                        .HasForeignKey("InterviewTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecruitmentManagement.Model.Position", "position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("position");
                });

            modelBuilder.Entity("RecruitmentManagement.Model.PositionSkill", b =>
                {
                    b.HasOne("RecruitmentManagement.Model.Position", "Position")
                        .WithMany("PositionSkills")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecruitmentManagement.Model.Skill", "Skill")
                        .WithMany("PositionSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Position");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("RecruitmentManagement.Model.ShortlistCandidate", b =>
                {
                    b.HasOne("RecruitmentManagement.Model.Candidate", "Candidate")
                        .WithMany("ShortlistCandidates")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("RecruitmentProcessManagementSystem.Models.User", b =>
                {
                    b.HasOne("RecruitmentProcessManagementSystem.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("RecruitmentManagement.Model.Candidate", b =>
                {
                    b.Navigation("CandidateSkills");

                    b.Navigation("Notifications");

                    b.Navigation("PositionCandidates");

                    b.Navigation("ShortlistCandidates");
                });

            modelBuilder.Entity("RecruitmentManagement.Model.CandidateStatusType", b =>
                {
                    b.Navigation("CandidateStatuses");
                });

            modelBuilder.Entity("RecruitmentManagement.Model.Interview", b =>
                {
                    b.Navigation("InterviewFeedbacks");

                    b.Navigation("InterviewerInterviews");
                });

            modelBuilder.Entity("RecruitmentManagement.Model.InterviewType", b =>
                {
                    b.Navigation("positionInterviews");
                });

            modelBuilder.Entity("RecruitmentManagement.Model.Position", b =>
                {
                    b.Navigation("PositionCandidates");

                    b.Navigation("PositionSkills");
                });

            modelBuilder.Entity("RecruitmentManagement.Model.PositionCandidate", b =>
                {
                    b.Navigation("CandidateStatuses");

                    b.Navigation("InterviewFeedbacks");

                    b.Navigation("Interviews");
                });

            modelBuilder.Entity("RecruitmentManagement.Model.PositionStatusType", b =>
                {
                    b.Navigation("Positions");
                });

            modelBuilder.Entity("RecruitmentManagement.Model.Skill", b =>
                {
                    b.Navigation("CandidateSkills");

                    b.Navigation("InterviewFeedbacks");

                    b.Navigation("PositionSkills");
                });
#pragma warning restore 612, 618
        }
    }
}
