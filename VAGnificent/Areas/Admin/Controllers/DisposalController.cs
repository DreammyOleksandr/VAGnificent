using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VAGnificent.DataAccess;
using VAGnificent.Models.Models;
using VAGnificent.Models.ViewModels;

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
        if (ModelState.IsValid)
        {
            List<Disposal> DisposalsList = _db.Disposals.ToList();
            return View(DisposalsList);
        }

        return View();
    }


    public IActionResult Create()
    {
        DisposalVm disposalVm = new DisposalVm()
        {
            Disposal = new Disposal(),
            Brands = _db.Brands.ToList().Select(u => new SelectListItem
            {
                Text = u.BrandName,
                Value = u.Id.ToString(),
            })
        };
        return View(disposalVm);
    }

    [HttpPost]
    public IActionResult Create(DisposalVm disposalVm)
    {
        if (ModelState.IsValid)
        {
            _db.Add(disposalVm.Disposal);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            disposalVm.Brands = _db.Brands.ToList().Select(u => new SelectListItem
            {
                Text = u.BrandName,
                Value = u.Id.ToString(),
            });
            return View(disposalVm);
        }
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
        if (ModelState.IsValid)
        {
            _db.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        return View();
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