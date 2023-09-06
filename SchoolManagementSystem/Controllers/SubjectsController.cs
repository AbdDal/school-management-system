using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagementSystem.DataLayer.Entities;
using SchoolManagementSystem.DataLayer.Repositories.Subjects;
using SchoolManagementSystem.DataLayer.Repositories.Teachers;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Controllers;

public class SubjectsController : Controller
{
    private readonly ISubjectRepository _subjectRepository;
    private readonly ITeacherRepository _teacherRepository;

    public SubjectsController(ISubjectRepository subjectRepository, ITeacherRepository teacherRepository)
    {
        _subjectRepository = subjectRepository;
        _teacherRepository = teacherRepository;
    }

    // GET
    public IActionResult Index()
    {
        var model = _subjectRepository.GetAll();

        var subjectsVm = new List<SubjectView>();

        foreach (var item in model)
        {
            var subjectVm = new SubjectView
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                TeacherId = item.TeacherId,
                TeacherName = item.Teacher.FirstName + "" + item.Teacher.LastName
            };

            subjectsVm.Add(subjectVm);
        }

        return View(subjectsVm);
    }

    [HttpGet]
    public IActionResult Create()
    {
        var teachers = _teacherRepository.GetAll().ToList();
        
        var listItems = teachers.Select(teacher => new SelectListItem { Text = teacher.FirstName + " " + teacher.LastName, Value = teacher.Id.ToString() }).ToList();
        var selectedListItems = new SelectList(listItems, "Value", "Text");
        ViewBag.TeacherIds = selectedListItems;

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Subject entity)
    {
        var teachers = _teacherRepository.GetAll().ToList();
        
        var listItems = teachers.Select(teacher => new SelectListItem { Text = teacher.FirstName + " " + teacher.LastName, Value = teacher.Id.ToString() }).ToList();
        var selectedListItems = new SelectList(listItems, "Value", "Text");
        ViewBag.TeacherIds = selectedListItems;
        
        if (ModelState.IsValid)
        {
            _subjectRepository.Create(entity);
            _subjectRepository.Commit();

            TempData["Message"] = "Added Successfully!";

            return RedirectToAction("Index");
        }


        return View();
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var teachers = _teacherRepository.GetAll().ToList();
        
        var listItems = teachers.Select(teacher => new SelectListItem { Text = teacher.FirstName + " " + teacher.LastName, Value = teacher.Id.ToString() }).ToList();
        var selectedListItems = new SelectList(listItems, "Value", "Text");
        ViewBag.TeacherIds = selectedListItems;
        
        var model = _subjectRepository.GetById(id);

        if (model != null)
        {
            return View(model);
        }

        return RedirectToAction("Index");
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult Edit(Subject entity)
    {
        var teachers = _teacherRepository.GetAll().ToList();
        
        var listItems = teachers.Select(teacher => new SelectListItem { Text = teacher.FirstName + " " + teacher.LastName, Value = teacher.Id.ToString() }).ToList();
        var selectedListItems = new SelectList(listItems, "Value", "Text");
        ViewBag.TeacherIds = selectedListItems;
        
        if (ModelState.IsValid)
        {
            _subjectRepository.Update(entity);
            _subjectRepository.Commit();

            TempData["Message"] = "Updated Successfully";

            return RedirectToAction("Details", new { id = entity.Id });
        }

        return View();
    }

    public IActionResult Delete(int id)
    {
        _subjectRepository.Delete(id);
        _subjectRepository.Commit();

        return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
        var model = _subjectRepository.GetById(id);

        if (model != null)
        {
            var subjectVm = new SubjectView
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                TeacherId = model.TeacherId,
                TeacherName = model.Teacher.FirstName + "" + model.Teacher.LastName
            };


            return View(subjectVm);
        }

        return RedirectToAction("Index");
    }
}