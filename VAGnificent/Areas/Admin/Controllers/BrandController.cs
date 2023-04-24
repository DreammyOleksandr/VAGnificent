using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VAGnificent.DataAccess;
using VAGnificent.DataAccess.Repository.IRepository;
using VAGnificent.Models.Models;

namespace VAGnificent.Areas.Admin.Controllers;

[Area("Admin")]
public class BrandController : Controller
{
    private readonly IBrandRepository _brandRepository;

    public BrandController(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public IActionResult Index()
    {
        List<Brand> brandsList = _brandRepository.GetAll().ToList();
        return View(brandsList);
    }


    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Brand obj)
    {
        _brandRepository.Add(obj);
        _brandRepository.Save();
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int? id)
    {
        Brand? brand = _brandRepository.Get(_=>_.Id == id);
        
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
        _brandRepository.Update(obj);
        _brandRepository.Save();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int? id)
    {
        Brand? brand = _brandRepository.Get(_=>_.Id==id);
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
        _brandRepository.Remove(obj);
        _brandRepository.Save();
        return RedirectToAction("Index");
    }

    #region API Calls

    [HttpGet]
    public IActionResult GetAll()
    {
        List<Brand> brandsList = _brandRepository.GetAll().ToList();
        return Json(new { data = brandsList });
    }

    #endregion
}