using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using stud_bud_back.Entities;
using stud_bud_back.Models;

namespace stud_bud_back.Helpers
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<ClassSchedule> ClassSchedules { get; set; }
        public virtual DbSet<CohortModerator> CohortModerators { get; set; }
        public virtual DbSet<CohortStudent> CohortStudents { get; set; }
        public virtual DbSet<Cohort> Cohorts { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        //public virtual DbSet<GroupAssignment> GroupAssignments { get; set; }
        public virtual DbSet<GroupUser> GroupUsers { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.HasIndex(e => e.CourseId);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Assignment)
                    .HasForeignKey(d => d.CourseId);
            });

            modelBuilder.Entity<CohortModerator>(entity =>
            {
                entity.HasKey(e => new { e.CohortId, e.UserId });

                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.Cohort)
                    .WithMany(p => p.CohortModerator)
                    .HasForeignKey(d => d.CohortId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CohortModerator)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<CohortStudent>(entity =>
            {
                entity.HasKey(e => new { e.CohortId, e.UserId });

                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.Cohort)
                    .WithMany(p => p.CohortStudent)
                    .HasForeignKey(d => d.CohortId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CohortStudent)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Cohort>(entity =>
            {
                entity.ToTable("Cohorts");

                entity.HasIndex(e => e.AdminId);

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.Cohorts)
                    .HasForeignKey(d => d.AdminId);

                entity.HasOne(d => d.ClassSchedule)
                    .WithOne(p => p.Cohort)
                    .HasForeignKey<ClassSchedule>(d => d.CohortId);
            });
       
            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("Groups");

                entity.HasIndex(e => e.CohortId);

                entity.HasOne(d => d.ClassSchedule)
                    .WithOne(p => p.Group)
                    .HasForeignKey<ClassSchedule>(d => d.GroupId);

                entity.HasOne(d => d.Cohort)
                    .WithMany(p => p.Group)
                    .HasForeignKey(d => d.CohortId);
            });

            //modelBuilder.Entity<GroupAssignment>(entity =>
            //{
            //    entity.HasIndex(e => e.CourseId);

            //    entity.HasIndex(e => e.GroupId);

            //    entity.HasOne(d => d.Course)
            //        .WithMany(p => p.GroupAssignment)
            //        .HasForeignKey(d => d.CourseId);

            //    entity.HasOne(d => d.Group)
            //        .WithMany(p => p.GroupAssignment)
            //        .HasForeignKey(d => d.GroupId);
            //});

            modelBuilder.Entity<GroupUser>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.StudentId });

                entity.HasIndex(e => e.StudentId);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupUser)
                    .HasForeignKey(d => d.GroupId);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.GroupUser)
                    .HasForeignKey(d => d.StudentId);
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.HasIndex(e => e.CourseId);

                entity.HasOne(d => d.ClassSchedule)
                .WithMany(p => p.Lessons)
                .HasForeignKey(d => d.ClassScheduleId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
