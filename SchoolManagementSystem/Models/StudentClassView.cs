using SchoolManagementSystem.DataLayer.Entities;

namespace SchoolManagementSystem.Models;

public class StudentClassView
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int ClassId { get; set; }

    public string StudentFullName { get; set; }
    public string ClassNumber { get; set; }
}