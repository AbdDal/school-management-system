using SchoolManagementSystem.DataLayer.Entities;

namespace SchoolManagementSystem.DataLayer.Repositories.StudentsClasses;

public interface IStudentClassRepository
{
    IEnumerable<StudentClass> GetAll();
    StudentClass GetByIds(int studentId, int classId);
    void Create(StudentClass studentClass);
    void Commit();
}