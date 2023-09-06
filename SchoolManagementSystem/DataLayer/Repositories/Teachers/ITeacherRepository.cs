using SchoolManagementSystem.DataLayer.Entities;

namespace SchoolManagementSystem.DataLayer.Repositories.Teachers;

public interface ITeacherRepository
{
    IEnumerable<Teacher> GetAll();
    Teacher GetById(int id);
    void Create(Teacher entity);
    void Update(Teacher entity);
    void Delete(int id);
    void Commit();
}