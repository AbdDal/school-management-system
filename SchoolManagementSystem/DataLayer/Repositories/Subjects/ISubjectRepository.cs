using SchoolManagementSystem.DataLayer.Entities;

namespace SchoolManagementSystem.DataLayer.Repositories.Subjects;

public interface ISubjectRepository
{
    IEnumerable<Subject> GetAll();
    Subject GetById(int id);
    void Create(Subject entity);
    void Update(Subject entity);
    void Delete(int id);
    void Commit();
}