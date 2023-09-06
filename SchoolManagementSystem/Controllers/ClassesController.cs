using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.DataLayer.Entities;
using SchoolManagementSystem.DataLayer.Repositories.Classes;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Controllers;

public class ClassesController : Controller
{
    private readonly IClassRepository _classRepository;

    public ClassesController(IClassRepository classRepository)
    {
        _classRepository = classRepository;
    }
    
    // GET
    public IActionResult Index()
    {
        var model = _classRepository.GetAll();

        var classesVm = new List<ClassView>();

        foreach (var item in model)
        {
            var classVm = new ClassView
            {
                Id = item.Id,
                Number = item.Number
            };
            classesVm.Add(classVm);
        }
        return View(classesVm);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Class entity)
    {
        if (ModelState.IsValid)
        {
            _classRepository.Create(entity);
            _classRepository.Commit();
            
            TempData["Message"] = "Added Successfully!";
            return RedirectToAction("Index");
        }
        
        return View();
    }
    
    [HttpGet]
    public IActionResult Edit()
    {
        return View();
    }
    
    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult Edit(Class entity)
    {
        if (ModelState.IsValid)
        {
            _classRepository.Update(entity);
            _classRepository.Commit();

            TempData["Message"] = "Updated Successfully!";
            return RedirectToAction("Index");
        }

        return View();
    }
    
    public IActionResult Delete(int id)
    {
        _classRepository.Delete(id);
        _classRepository.Commit();
        
        return RedirectToAction("Index");
    }
    
    public IActionResult Details(int id)
    {
        var model = _classRepository.GetById(id);

        if (model != null)
        {
            var classVm = new ClassView
            {
                Id = model.Id,
                Number = model.Number
            };
            
            return View(classVm);
        }

        return RedirectToAction("Index");
    }
}