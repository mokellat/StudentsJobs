using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StudentsJobs.Models.OTD_MODELS;

namespace StudentsJobs.Models;

public partial class StudentJobContext : DbContext
{
    public StudentJobContext()
    {
    }

    public StudentJobContext(DbContextOptions<StudentJobContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<Employer> Employers { get; set; }

    public virtual DbSet<JobPosting> JobPostings { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-PRH15DH\\SQLEXPRESS;Initial Catalog=studentJob;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.ApplicationId).HasName("PK__Applicat__C93A4C99302B3854");

            entity.Property(e => e.DateApplied)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('New')");

            entity.HasOne(d => d.JobPosting).WithMany(p => p.Applications)
                .HasForeignKey(d => d.JobPostingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Applications_JobPostings");

            entity.HasOne(d => d.Student).WithMany(p => p.Applications)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Applications_Students");
        });

        modelBuilder.Entity<Employer>(entity =>
        {
            entity.HasKey(e => e.EmployerId).HasName("PK__Employer__CA445261C683A19E");

            entity.HasIndex(e => e.CompanyEmail, "UQ__Employer__A1DB68DB69378966").IsUnique();

            entity.Property(e => e.EmployerId).ValueGeneratedNever();
            entity.Property(e => e.CompanyEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyWebsite)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Industry)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.EmployerNavigation).WithOne(p => p.Employer)
                .HasForeignKey<Employer>(d => d.EmployerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employers_Users");
        });

        modelBuilder.Entity<JobPosting>(entity =>
        {
            entity.HasKey(e => e.JobPostingId).HasName("PK__JobPosti__350AABC9F364AF4F");

            entity.Property(e => e.ApplicationInstructions).IsUnicode(false);
            entity.Property(e => e.DatePosted)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Deadline).HasColumnType("datetime");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Requirements).IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Employer).WithMany(p => p.JobPostings)
                .HasForeignKey(d => d.EmployerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobPostings_Employers");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__32C52B991C9FA97B");

            entity.HasIndex(e => e.Email, "UQ__Students__A9D1053458E18CF8").IsUnique();

            entity.Property(e => e.StudentId).ValueGeneratedNever();
            entity.Property(e => e.Cv).HasColumnName("CV");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Major)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.School)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Skills).IsUnicode(false);

            entity.HasOne(d => d.StudentNavigation).WithOne(p => p.Student)
                .HasForeignKey<Student>(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Students_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C10FA00BD");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E498745582").IsUnique();

            entity.Property(e => e.AuthToken)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
