using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using _01_TrainingCenter.Entities;

namespace _01_TrainingCenter.Data
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentProfile> StudentProfiles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasIndex(e => e.InstructorId,"IX_Courses_InstructorId");
                entity.HasIndex(e => e.Status, "IX_Courses_Status");
                entity.HasIndex(e => e.Code, "UQ_Courses_Code").IsUnique();

                entity.Property(e => e.Code).HasMaxLength(30);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())").HasColumnType("datetime");
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.Level).HasMaxLength(30);
                entity.Property(e => e.Price).HasColumnType("decimal(10,2)");
                entity.Property(e => e.PublishedAt).HasColumnType("datetime");
                entity.Property(e => e.Status).HasMaxLength(20);
                entity.Property(e => e.Title).HasMaxLength(150);

                entity.HasOne(d => d.Instructor)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.InstructorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Courses_Instructor");

            });
            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasIndex(e => e.CourseId, "IX_Enrollments_CourseId");
                entity.HasIndex(e => e.StudentId, "IX_Enrollments_StudentId");
                entity.HasIndex(e => e.Status, "IX_Enrollments_Status");

                entity.HasIndex(e => new { e.StudentId, e.CourseId }, "UQ_Enrollments_StudentId_CourseId").IsUnique();

                entity.Property(e => e.CompletionDate).HasColumnType("datetime");
                entity.Property(e => e.EnrollementDate).HasColumnType("datetime");
                entity.Property(e => e.FinalGrade).HasColumnType("decimal(5,2)");
                entity.Property(e => e.ProgressPercent).HasColumnType("decimal(5,2)");
                entity.Property(e => e.Status).HasMaxLength(20);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Enrollments_Courses");
                
                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Enrollments_Students");

            });
            modelBuilder.Entity<Instructor>(entity =>
            {
                entity.HasIndex(e => e.ManagerId, "IX_Instructors_ManagerId");
                entity.HasIndex(e => e.Email, "UQ_Instructors_Email").IsUnique();


                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(150);
                entity.Property(e => e.HireDate).HasColumnType("datetime");
                entity.Property(e => e.Salary).HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.InverseManager)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK_Instructors_Manager");

            });
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StudentId);
                entity.HasIndex(e => e.Status, "IX_Students_Status");
                entity.HasIndex(e => e.Email, "UQ_Students_Email").IsUnique();


                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(150);
                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
                entity.Property(e => e.RegisteredAt).HasDefaultValueSql("(getdate())").HasColumnType("datetime");
                entity.Property(e => e.Status).IsRequired().HasMaxLength(20);
                entity.Property(e => e.PhoneNumber).HasMaxLength(30);
            });
            modelBuilder.Entity<StudentProfile>(entity =>
            {
                entity.HasKey(e => e.StudentId);
                entity.Property(e => e.StudentId).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(200);
                entity.Property(e => e.City).HasMaxLength(100);
                entity.Property(e => e.Country).HasMaxLength(100);
                entity.Property(e => e.Bio).HasMaxLength(500);
                entity.Property(e => e.LinkedInUrl).HasMaxLength(200);
                
                entity.HasOne(d => d.Student)
                    .WithOne(p => p.StudentProfile)
                    .HasForeignKey<StudentProfile>(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentProfile_Students");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}