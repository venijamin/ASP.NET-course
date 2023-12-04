using BulkyWebRazor.Data;
using BulkyWebRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor.Pages.Categories;

public class Delete : PageModel
{
    private readonly ApplicationDbContext _db;
    [BindProperty] public Category Category { get; set; }

    public Delete(ApplicationDbContext db)
    {
        _db = db;
    }

    public void OnGet(int? id)
    {
        Category = _db.Categories.Find(id);

    }

    public IActionResult OnPost()
    {
        Category? obj = _db.Categories.Find(Category.Id);
        _db.Categories.Remove(obj);
        _db.SaveChanges();
        return RedirectToPage("Index");
    }
}