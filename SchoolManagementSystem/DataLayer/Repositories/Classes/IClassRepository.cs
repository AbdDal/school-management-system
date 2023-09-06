using SchoolManagementSystem.DataLayer.Entities;

namespace SchoolManagementSystem.DataLayer.Repositories.Classes;

public interface IClassRepository
{
    IEnumerable<Class> GetAll();
    Class GetById(int id);
    void Create(Class entity);
    void Update(Class entity);
    void Delete(int id);
    void Commit();
}