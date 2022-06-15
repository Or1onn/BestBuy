using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCore_HomeWork_1
{
    public partial class AcademyContext : DbContext
    {
        public AcademyContext()
        {
        }

        public AcademyContext(DbContextOptions<AcademyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Assistant> Assistants { get; set; } = null!;
        public virtual DbSet<Curator> Curators { get; set; } = null!;
        public virtual DbSet<Dean> Deans { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Faculty> Faculties { get; set; } = null!;
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<GroupsCurator> GroupsCurators { get; set; } = null!;
        public virtual DbSet<GroupsLecture> GroupsLectures { get; set; } = null!;
        public virtual DbSet<Head> Heads { get; set; } = null!;
        public virtual DbSet<Lecture> Lectures { get; set; } = null!;
        public virtual DbSet<LectureRoom> LectureRooms { get; set; } = null!;
        public virtual DbSet<Schedule> Schedules { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-1B95R4O;Initial Catalog=Academy;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assistant>(entity =>
            {
                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Assistants)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Assistant__Teach__30F848ED");
            });

            modelBuilder.Entity<Curator>(entity =>
            {
                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Curators)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Curators__Teache__33D4B598");
            });

            modelBuilder.Entity<Dean>(entity =>
            {
                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Deans)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Deans__TeacherId__36B12243");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Departme__737584F6F5D36C18")
                    .IsUnique();

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.FacultyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Departmen__Facul__44FF419A");

                entity.HasOne(d => d.Head)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.HeadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Departmen__HeadI__45F365D3");
            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Facultie__737584F6B6B8964A")
                    .IsUnique();

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Dean)
                    .WithMany(p => p.Faculties)
                    .HasForeignKey(d => d.DeanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Faculties__DeanI__3C69FB99");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Groups__737584F6E5EEB580")
                    .IsUnique();

                entity.Property(e => e.Name).HasMaxLength(10);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Groups__Departme__4BAC3F29");
            });

            modelBuilder.Entity<GroupsCurator>(entity =>
            {
                entity.HasOne(d => d.Curator)
                    .WithMany(p => p.GroupsCurators)
                    .HasForeignKey(d => d.CuratorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GroupsCur__Curat__4E88ABD4");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupsCurators)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GroupsCur__Group__4F7CD00D");
            });

            modelBuilder.Entity<GroupsLecture>(entity =>
            {
                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupsLectures)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GroupsLec__Group__5629CD9C");

                entity.HasOne(d => d.Lecture)
                    .WithMany(p => p.GroupsLectures)
                    .HasForeignKey(d => d.LectureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GroupsLec__Lectu__571DF1D5");
            });

            modelBuilder.Entity<Head>(entity =>
            {
                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Heads)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Heads__TeacherId__3F466844");
            });

            modelBuilder.Entity<Lecture>(entity =>
            {
                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Lectures)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Lectures__Subjec__52593CB8");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Lectures)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Lectures__Teache__534D60F1");
            });

            modelBuilder.Entity<LectureRoom>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__LectureR__737584F6B808980E")
                    .IsUnique();

                entity.Property(e => e.Name).HasMaxLength(10);
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.HasOne(d => d.Lecture)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.LectureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Schedules__Lectu__5CD6CB2B");

                entity.HasOne(d => d.LectureRoom)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.LectureRoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Schedules__Lectu__5DCAEF64");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Subjects__737584F63DAE344A")
                    .IsUnique();

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
