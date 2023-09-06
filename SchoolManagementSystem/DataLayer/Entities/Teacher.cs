using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.DataLayer.Entities;

public class Teacher
{
    public int Id { get; set; }
    
    [Required, StringLength(55)]
    public string FirstName { get; set; }
    
    [Required, StringLength(55)]
    public string LastName { get; set; }
    
    [Required, EmailAddress]
    public string Email { get; set; }
    
    [Required, Phone]
    public string PhoneNumber { get; set; }
    
    public string Address { get; set; }
    
    public ICollection<Student> Students { get; set; }
    
    public ICollection<Subject> Subjects { get; set; }
}