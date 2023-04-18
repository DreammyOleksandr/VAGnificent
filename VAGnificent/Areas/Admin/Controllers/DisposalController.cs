using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VAGnificent.DataAccess;
using VAGnificent.Models;

namespace VAGnificent.Areas.Admin.Controllers;

[Area("Admin")]
public class DisposalController : Controller
{
    private readonly ApplicationDbContext _db;

    public DisposalController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        List<Disposal> DisposalsList = _db.Disposals.ToList();
        return View(DisposalsList);
    }


    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Disposal obj)
    {
        _db.Add(obj);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int? id)
    {
        Disposal? Disposal = _db.Disposals.Find(id);
        
        if (id == null || id == 0)
        {
            return NotFound();
        }

        if (Disposal == null)
        {
            return NotFound();
        }
        return View(Disposal);
    }

    [HttpPost]
    public IActionResult Edit(Disposal obj)
    {
        _db.Update(obj);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int? id)
    {
        Disposal? Disposal = _db.Disposals.Find(id);
        if (id == null || id == 0)
        {
            return NotFound();
        }

        if (Disposal == null)
        {
            return NotFound();
        }
        return View(Disposal);
    }

    [HttpPost]
    public IActionResult Delete(Disposal obj)
    {
        _db.Remove(obj);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    #region API Calls

    [HttpGet]
    public IActionResult GetAll()
    {
        List<Disposal> DisposalsList = _db.Disposals.ToList();
        return Json(new { data = DisposalsList });
    }

    #endregion
}