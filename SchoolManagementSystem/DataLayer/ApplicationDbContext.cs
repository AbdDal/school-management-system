using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.DataLayer.Entities;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.DataLayer;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentClass>().HasKey(sc => new { sc.StudentId, sc.ClassId });
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Class> Classes { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<StudentClass> StudentsClasses { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<SchoolManagementSystem.Models.StudentClassView> StudentClassView { get; set; }
}