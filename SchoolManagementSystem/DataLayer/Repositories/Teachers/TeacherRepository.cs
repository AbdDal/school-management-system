using SchoolManagementSystem.DataLayer.Entities;

namespace SchoolManagementSystem.DataLayer.Repositories.Teachers;

public class TeacherRepository : ITeacherRepository
{
    private readonly ApplicationDbContext _dbContext;

    public TeacherRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IEnumerable<Teacher> GetAll()
    {
        return _dbContext.Teachers;
    }

    public Teacher GetById(int id)
    {
        return _dbContext.Teachers.FirstOrDefault(x => x.Id == id);
    }

    public void Create(Teacher entity)
    {
        _dbContext.Teachers.Add(entity);
    }

    public void Update(Teacher entity)
    {
        _dbContext.Teachers.Update(entity);
    }

    public void Delete(int id)
    {
        var entity = _dbContext.Teachers.FirstOrDefault(x => x.Id == id);

        if (entity != null)
        {
            _dbContext.Teachers.Remove(entity);
        }
    }

    public void Commit()
    {
        _dbContext.SaveChanges();
    }
}