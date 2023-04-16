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
        List<Brand> brandsList = _db.Brands.ToList();
        return View(brandsList);
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
        Brand? brand = _db.Brands.Find(id);
        
        if (id == null || id == 0)
        {
            return NotFound();
        }

        if (brand == null)
        {
            return NotFound();
        }
        return View(brand);
    }

    [HttpPost]
    public IActionResult Edit(Brand obj)
    {
        _db.Update(obj);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int? id)
    {
        Brand? brand = _db.Brands.Find(id);
        if (id == null || id == 0)
        {
            return NotFound();
        }

        if (brand == null)
        {
            return NotFound();
        }
        return View(brand);
    }

    [HttpPost]
    public IActionResult Delete(Brand obj)
    {
        _db.Remove(obj);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    #region API Calls

    [HttpGet]
    public IActionResult GetAll()
    {
        List<Brand> brandsList = _db.Brands.ToList();
        return Json(new { data = brandsList });
    }

    #endregion
}