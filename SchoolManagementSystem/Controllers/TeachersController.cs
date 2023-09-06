using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.DataLayer.Entities;
using SchoolManagementSystem.DataLayer.Repositories.Teachers;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Controllers;

public class TeachersController : Controller
{
    private readonly ITeacherRepository _teacherRepository;

    public TeachersController(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }
    
    // GET
    public IActionResult Index()
    {
        var model = _teacherRepository.GetAll();
        var teachersVm = new List<TeacherView>();

        foreach (var item in model)
        {
            var teacherVm = new TeacherView
            {
                Id = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Email = item.Email,
                PhoneNumber = item.PhoneNumber,
                Address = item.Address
            };
            teachersVm.Add(teacherVm);
        }
        return View(teachersVm);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Teacher entity)
    {
        if (ModelState.IsValid)
        {
            _teacherRepository.Create(entity);
            _teacherRepository.Commit();

            TempData["Message"] = "Added Successfully!";

            return RedirectToAction("Index");
        }
     
        
        return View();
    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var model = _teacherRepository.GetById(id);

        if (model != null)
        {
            return View(model);
        }

        return RedirectToAction("Index");
    }
    
    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult Edit(Teacher entity)
    {
        if (ModelState.IsValid)
        {
            _teacherRepository.Update(entity);
            _teacherRepository.Commit();

            TempData["Message"] = "Updated Successfully";

            return RedirectToAction("Details", new { id = entity.Id });
        }
        
        return View();
    }
    
    public IActionResult Delete(int id)
    {
        _teacherRepository.Delete(id);
        _teacherRepository.Commit();
        
        return RedirectToAction("Index");
    }
    
    public IActionResult Details(int id)
    {
        var model = _teacherRepository.GetById(id);

        

        if (model != null)
        {
            var teacherVm = new TeacherView
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address
            };
            
            return View(teacherVm);
        }
        
        return RedirectToAction("Index");
    }
}