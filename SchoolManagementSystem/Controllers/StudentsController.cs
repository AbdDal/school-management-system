using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagementSystem.DataLayer.Entities;
using SchoolManagementSystem.DataLayer.Repositories.Students;
using SchoolManagementSystem.DataLayer.Repositories.Teachers;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Controllers;

public class StudentsController : Controller
{
    private readonly IStudentRepository _studentRepository;
    private readonly ITeacherRepository _teacherRepository;

    public StudentsController(IStudentRepository studentRepository, ITeacherRepository teacherRepository)
    {
        _studentRepository = studentRepository;
        _teacherRepository = teacherRepository;
    }
    
    // GET
    public IActionResult Index()
    {
        var model = _studentRepository.GetAll();

        var studentsVm = new List<StudentView>();

        foreach (var item in model)
        {
            var studentVm = new StudentView
            {
                Id = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Age = item.Age,
                Email = item.Email,
                Address = item.Address,
                TeacherId = item.TeacherId,
                TeacherName = item.Teacher.FirstName + "" + item.Teacher.LastName
            };

            studentsVm.Add(studentVm);
        }
        return View(studentsVm);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        var teachers = _teacherRepository.GetAll();
        
        var listItems = teachers.Select(teacher => new SelectListItem { Text = teacher.FirstName + " " + teacher.LastName, Value = teacher.Id.ToString() }).ToList();
        var selectedListItems = new SelectList(listItems, "Value", "Text");
        ViewBag.TeacherIds = selectedListItems;
        
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Student entity)
    {
        var teachers = _teacherRepository.GetAll();
        
        var listItems = teachers.Select(teacher => new SelectListItem { Text = teacher.FirstName + " " + teacher.LastName, Value = teacher.Id.ToString() }).ToList();
        var selectedListItems = new SelectList(listItems, "Value", "Text");
        ViewBag.TeacherIds = selectedListItems;
        
        if (ModelState.IsValid)
        {
            _studentRepository.Create(entity);
            _studentRepository.Commit();

            TempData["Message"] = "Added Successfully!";

            return RedirectToAction("Index");
        }
     
        
        return View();
    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var teachers = _teacherRepository.GetAll();
        
        var listItems = teachers.Select(teacher => new SelectListItem { Text = teacher.FirstName + " " + teacher.LastName, Value = teacher.Id.ToString() }).ToList();
        var selectedListItems = new SelectList(listItems, "Value", "Text");
        ViewBag.TeacherIds = selectedListItems;
        
        var model = _studentRepository.GetById(id);

        if (model != null)
        {
            return View(model);
        }

        return RedirectToAction("Index");
    }
    
    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult Edit(Student entity)
    {
        var teachers = _teacherRepository.GetAll();
        
        var listItems = teachers.Select(teacher => new SelectListItem { Text = teacher.FirstName + " " + teacher.LastName, Value = teacher.Id.ToString() }).ToList();
        var selectedListItems = new SelectList(listItems, "Value", "Text");
        ViewBag.TeacherIds = selectedListItems;
        
        if (ModelState.IsValid)
        {
            _studentRepository.Update(entity);
            _studentRepository.Commit();

            TempData["Message"] = "Updated Successfully";

            return RedirectToAction("Details", new { id = entity.Id });
        }
        
        return View();
    }
    
    public IActionResult Delete(int id)
    {
        _studentRepository.Delete(id);
        _studentRepository.Commit();
        
        return RedirectToAction("Index");
    }
    
    public IActionResult Details(int id)
    {
        var model = _studentRepository.GetById(id);

        if (model != null)
        {
            var studentVm = new StudentView
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                Email = model.Email,
                Address = model.Address,
                TeacherId = model.TeacherId,
                TeacherName = model.Teacher.FirstName + "" + model.Teacher.LastName
            };
            
            return View(studentVm);
        }
        
        return RedirectToAction("Index");
    }
}