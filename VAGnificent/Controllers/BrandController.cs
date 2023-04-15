using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VAGnificent.DataAccess;
using VAGnificent.Models;

namespace VAGnificent.Controllers;

public class BrandController : Controller
{
    private readonly ApplicationDbContext _db;

    public BrandController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        IEnumerable<Brand> brandsList = _db.Brands;
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Brand obj)
    {
        _db.Add(obj);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    
    public IActionResult Edit(int? id)
    {
        return View();
    }

    [HttpPost]
    public IActionResult Edit(Brand obj)
    {
        _db.Update(obj);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    
    
}