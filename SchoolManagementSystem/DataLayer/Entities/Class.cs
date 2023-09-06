using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.DataLayer.Entities;

public class Class
{
    public int Id { get; set; }
    
    [Required, StringLength(10)]
    public string Number { get; set; }

    public ICollection<StudentClass> StudentsClasses { get; set; }
}