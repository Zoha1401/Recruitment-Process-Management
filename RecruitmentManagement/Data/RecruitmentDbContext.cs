using Microsoft.EntityFrameworkCore;
using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Models;

namespace RecruitmentProcessManagementSystem.Data
{
    public class RecruitmentDbContext : DbContext
    {
        public RecruitmentDbContext(DbContextOptions<RecruitmentDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Skill> Skills { get; set; }

        public DbSet<Candidate> Candidates { get; set; }
        // public DbSet<JobRequirement> JobRequirements { get; set; }

        public DbSet<PositionStatusType> PositionStatusTypes { get; set; }

        public DbSet<Position> Positions { get; set; }
        public DbSet<PositionSkill> PositionSkills { get; set; }

        public DbSet<PositionCandidate> PositionCandidates { get; set; }

        public DbSet<CandidateSkill> CandidateSkills { get; set; }

        public DbSet<Interview> Interviews { get; set; }
        public DbSet<InterviewType> InterviewTypes { get; set; }

        public DbSet<PositionInterview> PositionInterviews { get; set; }

        public DbSet<InterviewerInterview> InterviewerInterviews { get; set; }

        public DbSet<InterviewFeedback> InterviewFeedbacks { get; set; }

        // public DbSet<PositionJobRequirement> PositionJobRequirements { get; set; }

        // public DbSet<JobPositions> JobPositions{get; set;}

        // public DbSet<skills> Skills{get; set;}

        // public DbSet<JobSkill> JobSkill{get; set;}

        // public DbSet<JobStatus> JobStatus{get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // modelBuilder.Entity<JobStatus>().HasData(
            //     new JobStatus { statusId = 1, statusName = "Open" },
            //     new JobStatus { statusId = 2, statusName = "Closed"},
            //     new JobStatus { statusId = 3, statusName = "On Hold"}
            // );

            // modelBuilder.Entity<skills>().HasData(
            //     new skills { skillId = 1, skillName = "Java-Spring Boot" },
            //     new skills { skillId = 2, skillName = ".Net"},
            //     new skills { skillId = 3, skillName = "React"}
            // );

            modelBuilder.Entity<PositionSkill>()
                .HasKey(sc => new { sc.PositionId, sc.SkillId }); // Composite Key for Join Table
            modelBuilder.Entity<PositionSkill>()
                .HasOne(sc => sc.Position)
                .WithMany(s => s.PositionSkills) // Navigation Property in Student
                .HasForeignKey(sc => sc.PositionId); //Foreign Key
            modelBuilder.Entity<PositionSkill>()
                .HasOne(sc => sc.Skill)
                .WithMany(c => c.PositionSkills) // Navigation Property in Course
                .HasForeignKey(sc => sc.SkillId);

            modelBuilder.Entity<CandidateSkill>()
                    .HasKey(cs => new { cs.CandidateId, cs.SkillId });
            modelBuilder.Entity<CandidateSkill>()
        .HasOne(cs => cs.Skill)
        .WithMany(s => s.CandidateSkills)
        .HasForeignKey(cs => cs.SkillId)
        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CandidateSkill>()
            .HasOne(cs => cs.Candidate)
            .WithMany(c => c.CandidateSkills)
            .HasForeignKey(cs => cs.CandidateId)
            .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Interview>()
                .HasOne(i => i.InterviewType)
                .WithMany()
                .HasForeignKey(i => i.InterviewTypeId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<PositionCandidate>()
                .HasOne(pc => pc.Candidate)
                .WithMany(c => c.PositionCandidates)
                .HasForeignKey(pc => pc.CandidateId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<PositionCandidate>()
                .HasOne(pc => pc.Position)
                .WithMany(c => c.PositionCandidates)
                .HasForeignKey(pc => pc.PositionId)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(modelBuilder);
        }
    }
}
