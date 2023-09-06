using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.DataLayer.Entities;

namespace SchoolManagementSystem.DataLayer.Repositories.StudentsClasses;

public class StudentClassRepository : IStudentClassRepository
{
    private readonly ApplicationDbContext _dbContext;

    public StudentClassRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IEnumerable<StudentClass> GetAll()
    {
        return _dbContext.StudentsClasses
            .Include(x => x.Class)
            .Include(x => x.Student);
    }

    public StudentClass GetByIds(int studentId, int classId)
    {
        return _dbContext.StudentsClasses.FirstOrDefault(x => x.StudentId == studentId && x.ClassId == classId);
    }


    public void Create(StudentClass studentClass)
    {
        _dbContext.StudentsClasses.Add(studentClass);
    }

    public void Commit()
    {
        _dbContext.SaveChanges();
    }
}