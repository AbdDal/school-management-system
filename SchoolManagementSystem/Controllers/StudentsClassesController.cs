using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagementSystem.DataLayer.Entities;
using SchoolManagementSystem.DataLayer.Repositories.Classes;
using SchoolManagementSystem.DataLayer.Repositories.Students;
using SchoolManagementSystem.DataLayer.Repositories.StudentsClasses;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Controllers;

public class StudentsClassesController : Controller
{
    private readonly IStudentClassRepository _studentClassRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly IClassRepository _classRepository;

    public StudentsClassesController(IStudentClassRepository studentClassRepository, IStudentRepository studentRepository, IClassRepository classRepository)
    {
        _studentClassRepository = studentClassRepository;
        _studentRepository = studentRepository;
        _classRepository = classRepository;
    }

    public IActionResult Index()
    {
        var studentsClasses = _studentClassRepository.GetAll();
        var studentsClassesVm = new List<StudentClassView>();

        foreach (var studentClass in studentsClasses)
        {
            var studentClassVm = new StudentClassView
            {
                Id = studentClass.Id,
                StudentId = studentClass.StudentId,
                ClassId = studentClass.ClassId,
                StudentFullName = studentClass.Student.FirstName + " " + studentClass.Student.LastName,
                ClassNumber = studentClass.Class.Number
            };
            studentsClassesVm.Add(studentClassVm);
        }
        
        return View(studentsClassesVm);
    }

    [HttpGet]
    public IActionResult Create()
    {
        var students = _studentRepository.GetAll().ToList();
        var classes = _classRepository.GetAll().ToList();

        var studentListItems = new List<SelectListItem>();
        var classListItems = new List<SelectListItem>();

        foreach (var student in students)
        {
            var studentListItem = new SelectListItem
            {
                Text = student.FirstName + " " + student.LastName,
                Value = student.Id.ToString()
            };
            
            studentListItems.Add(studentListItem);
        }

        ViewBag.StudentsIds = new SelectList(studentListItems, "Value", "Text");
        
        foreach (var @class in classes)
        {
            var classListItem = new SelectListItem
            {
                Text = @class.Number,
                Value = @class.Id.ToString()
            };
            
            classListItems.Add(classListItem);
        }
        
        ViewBag.ClassesIds = new SelectList(classListItems, "Value", "Text");
        
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(StudentClass studentClass)
    {
        var entity = _studentClassRepository.GetByIds(studentClass.StudentId, studentClass.ClassId);

        if (entity == null)
        {
            _studentClassRepository.Create(studentClass);
            _studentClassRepository.Commit();
            return RedirectToAction("Index");
        }

        TempData["MessageError"] = "The student already registered with this class!";
        return RedirectToAction("Index");
    }
    
}