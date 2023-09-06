using SchoolManagementSystem.DataLayer.Entities;

namespace SchoolManagementSystem.DataLayer.Repositories.Students;

public interface IStudentRepository
{
    IEnumerable<Student> GetAll();
    Student GetById(int id);
    void Create(Student entity);
    void Update(Student entity);
    void Delete(int id);
    void Commit();
}