using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SMSLibrary.Model;

public partial class SmsContext : DbContext
{
    public SmsContext()
    {
    }

    public SmsContext(DbContextOptions<SmsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SMS;Integrated Security=True;Trust Server Certificate=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseCode).HasName("PK__Course__FC00E001F8E99646");

            entity.ToTable("Course");

            entity.Property(e => e.CourseCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CourseTitle)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Department)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.School)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.LoginName).HasName("PK__Login__DB8464FEA9438C7C");

            entity.ToTable("Login");

            entity.Property(e => e.LoginName)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(12)
                .IsUnicode(false);

            entity.HasOne(d => d.LoginNameNavigation).WithOne(p => p.Login)
                .HasForeignKey<Login>(d => d.LoginName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Login_Student");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52A792E0BAAA0");

            entity.ToTable("Student");

            entity.Property(e => e.StudentId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("StudentID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Program)
                .HasMaxLength(8)
                .IsUnicode(false);

            entity.HasMany(d => d.CourseCodes).WithMany(p => p.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "Enrollment",
                    r => r.HasOne<Course>().WithMany()
                        .HasForeignKey("CourseCode")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Enrollment_Course"),
                    l => l.HasOne<Student>().WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Enrollment_Student"),
                    j =>
                    {
                        j.HasKey("StudentId", "CourseCode");
                        j.ToTable("Enrollment");
                        j.IndexerProperty<string>("StudentId")
                            .HasMaxLength(10)
                            .IsUnicode(false)
                            .HasColumnName("StudentID");
                        j.IndexerProperty<string>("CourseCode")
                            .HasMaxLength(10)
                            .IsUnicode(false);
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
