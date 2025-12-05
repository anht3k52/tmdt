using Microsoft.EntityFrameworkCore;
using StudentManagement.Data.Models;

namespace StudentManagement.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Student> Students => Set<Student>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Semester> Semesters => Set<Semester>();
    public DbSet<Enrollment> Enrollments => Set<Enrollment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Student>(e =>
        {
            e.Property(p => p.StudentCode).HasMaxLength(50).IsRequired();
            e.Property(p => p.FullName).HasMaxLength(200).IsRequired();
            e.HasIndex(p => p.StudentCode).IsUnique();
        });

        modelBuilder.Entity<Course>(e =>
        {
            e.Property(p => p.CourseCode).HasMaxLength(50).IsRequired();
            e.Property(p => p.Name).HasMaxLength(200).IsRequired();
            e.HasIndex(p => p.CourseCode).IsUnique();
        });

        modelBuilder.Entity<Semester>(e =>
        {
            e.Property(p => p.Code).HasMaxLength(50).IsRequired();
            e.Property(p => p.Name).HasMaxLength(200).IsRequired();
            e.HasIndex(p => p.Code).IsUnique();
        });

        modelBuilder.Entity<Enrollment>(e =>
        {
            e.HasOne(x => x.Student)
             .WithMany(x => x.Enrollments)
             .HasForeignKey(x => x.StudentId)
             .OnDelete(DeleteBehavior.Cascade);

            e.HasOne(x => x.Course)
             .WithMany(x => x.Enrollments)
             .HasForeignKey(x => x.CourseId)
             .OnDelete(DeleteBehavior.Cascade);

            e.HasOne(x => x.Semester)
             .WithMany(x => x.Enrollments)
             .HasForeignKey(x => x.SemesterId)
             .OnDelete(DeleteBehavior.Cascade);

            e.HasIndex(x => new { x.StudentId, x.CourseId, x.SemesterId }).IsUnique();
        });
    }
}
