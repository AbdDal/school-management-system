using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.DataLayer.Entities;

namespace SchoolManagementSystem.DataLayer.Repositories.Students;

public class StudentRepository : IStudentRepository
{
    private readonly ApplicationDbContext _dbContext;

    public StudentRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IEnumerable<Student> GetAll()
    {
        return _dbContext.Students.Include(x=>x.Teacher);
    }

    public Student GetById(int id)
    {
        return _dbContext.Students.Include(x=>x.Teacher).FirstOrDefault(x => x.Id == id);
    }

    public void Create(Student entity)
    {
        _dbContext.Students.Add(entity);
    }

    public void Update(Student entity)
    {
        _dbContext.Students.Update(entity);
    }

    public void Delete(int id)
    {
        var entity = _dbContext.Students.FirstOrDefault(x => x.Id == id);

        if (entity != null)
        {
            _dbContext.Students.Remove(entity);
        }
    }

    public void Commit()
    {
        _dbContext.SaveChanges();
    }
}