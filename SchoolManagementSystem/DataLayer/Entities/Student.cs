using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.DataLayer.Entities;

public class Student
{
    public int Id { get; set; }
    
    [Required, StringLength(55)]
    public string FirstName { get; set; }
    
    [Required, StringLength(55)]
    public string LastName { get; set; }
    
    [Required]
    public int Age { get; set; }
    
    [Required, EmailAddress]
    public string Email { get; set; }
    
    public string Address { get; set; }
    
    [ForeignKey(nameof(Teacher))]
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }

    public ICollection<StudentClass> StudentsClasses { get; set; }
}