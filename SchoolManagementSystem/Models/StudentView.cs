using SchoolManagementSystem.DataLayer.Entities;

namespace SchoolManagementSystem.Models;

public class StudentView
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public int TeacherId { get; set; }
    public string TeacherName { get; set; }
}