using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductController : Controller
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public IActionResult Index()
    {
        var products = _productRepository.GetAll().ToList();
        return View(products);
    }


    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Product obj)
    {
        if (ModelState.IsValid)
        {
            _productRepository.Add(obj);
            _productRepository.Save();
            TempData["success"] = "Category created successfully!";
            return RedirectToAction("Index", "Category");
        }

        return View();
    }

    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0) return NotFound();

        var productFromDb = _productRepository.Get(p => p.Id.Equals(id));
        if (productFromDb == null) return NotFound();

        return View(productFromDb);
    }

    [HttpPost]
    public IActionResult Edit(Product obj)
    {
        if (ModelState.IsValid)
        {
            _productRepository.Update(obj);
            _productRepository.Save();
            TempData["success"] = "Category updated successfully!";
            return RedirectToAction("Index", "Product");
        }

        return View();
    }

    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0) return NotFound();

        var productFromDb = _productRepository.Get(product => product.Id.Equals(id));
        if (productFromDb == null) return NotFound();

        _productRepository.Remove(productFromDb);
        _productRepository.Save();
        TempData["success"] = "Category deleted successfully!";

        return RedirectToAction("Index", "Product");
    }
}