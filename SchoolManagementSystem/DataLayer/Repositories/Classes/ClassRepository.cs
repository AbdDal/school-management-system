using SchoolManagementSystem.DataLayer.Entities;

namespace SchoolManagementSystem.DataLayer.Repositories.Classes;

public class ClassRepository : IClassRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ClassRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IEnumerable<Class> GetAll()
    {
        return _dbContext.Classes;
    }

    public Class GetById(int id)
    {
        return _dbContext.Classes.FirstOrDefault(x => x.Id == id);
    }

    public void Create(Class entity)
    {
        _dbContext.Classes.Add(entity);
    }

    public void Update(Class entity)
    {
        _dbContext.Classes.Update(entity);
    }

    public void Delete(int id)
    {
        var entity = _dbContext.Classes.FirstOrDefault(x => x.Id == id);

        if (entity != null)
        {
            _dbContext.Classes.Remove(entity);
        }
    }

    public void Commit()
    {
        _dbContext.SaveChanges();
    }
}