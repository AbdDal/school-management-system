using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.DataLayer.Entities;

public class StudentClass
{
    public int Id { get; set; }
    
    [ForeignKey(nameof(Student))]
    public int StudentId { get; set; }
    public Student Student { get; set; }
    
    [ForeignKey(nameof(Class))]
    public int ClassId { get; set; }
    public Class Class { get; set; }
}