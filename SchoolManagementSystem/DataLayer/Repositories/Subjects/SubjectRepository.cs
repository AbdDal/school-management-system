using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.DataLayer.Entities;

namespace SchoolManagementSystem.DataLayer.Repositories.Subjects;

public class SubjectRepository : ISubjectRepository
{
    private readonly ApplicationDbContext _dbContext;

    public SubjectRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IEnumerable<Subject> GetAll()
    {
        return _dbContext.Subjects.Include(x=>x.Teacher);
    }

    public Subject GetById(int id)
    {
        return _dbContext.Subjects.Include(x=>x.Teacher).FirstOrDefault(x => x.Id == id);
    }

    public void Create(Subject entity)
    {
        _dbContext.Subjects.Add(entity);
    }

    public void Update(Subject entity)
    {
        _dbContext.Subjects.Update(entity);
    }

    public void Delete(int id)
    {
        var entity = _dbContext.Subjects.FirstOrDefault(x => x.Id == id);

        if (entity != null)
        {
            _dbContext.Subjects.Remove(entity);
        }
    }

    public void Commit()
    {
        _dbContext.SaveChanges();
    }
}