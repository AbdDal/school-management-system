using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.DataLayer.Entities;

public class Subject
{
    public int Id { get; set; }
    
    [Required, StringLength(50)]
    public string Title { get; set; }

    [StringLength(200)]
    public string Description { get; set; }

    [ForeignKey(nameof(Teacher))]
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
}