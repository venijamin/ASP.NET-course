using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;

using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryRepository _categoryRepository;
    public CategoryController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    // GET
    public IActionResult Index()
    {
        List<Category> objCategoryList = _categoryRepository.GetAll().ToList();
        return View(objCategoryList);
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Category obj)
    {
        if (ModelState.IsValid)
        {
           _categoryRepository.Add(obj);
            _categoryRepository.Save();
            TempData["success"] = "Category created successfully!";
            return RedirectToAction("Index", "Category");
        }

        return View();
    }

    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        Category? categoryFromDb = _categoryRepository.Get(category => category.Id.Equals(id));
        if (categoryFromDb == null)
        {
            return NotFound();
        }
        return View(categoryFromDb);
    }
    
    [HttpPost]
    public IActionResult Edit(Category obj)
    {
        if (ModelState.IsValid)
        {
            _categoryRepository.Update(obj);
            _categoryRepository.Save();
            TempData["success"] = "Category updated successfully!";
            return RedirectToAction("Index", "Category");
        }
        return View();
    }

    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        Category? categoryFromDb = _categoryRepository.Get(category => category.Id.Equals(id));
        if (categoryFromDb == null)
        {
            return NotFound();
        }
        _categoryRepository.Remove(categoryFromDb);
        _categoryRepository.Save();
        TempData["success"] = "Category deleted successfully!";
        
        return RedirectToAction("Index", "Category");

    }
}