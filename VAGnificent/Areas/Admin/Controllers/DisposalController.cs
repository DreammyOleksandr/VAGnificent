using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VAGnificent.DataAccess.Repository.IRepository;
using VAGnificent.Models.Models;
using VAGnificent.Models.ViewModels;

namespace VAGnificent.Areas.Admin.Controllers;

[Area("Admin")]
public class DisposalController : Controller
{
    private readonly IDisposalRepository _disposalRepository;
    private readonly IBrandRepository _brandRepository;

    public DisposalController(IDisposalRepository disposalRepository, IBrandRepository brandRepository)
    {
        _disposalRepository = disposalRepository;
        _brandRepository = brandRepository;
    }

    public IActionResult Index()
    {
        if (ModelState.IsValid)
        {
            List<Disposal> DisposalsList = _disposalRepository.GetAll(includeProperties:"Brand").ToList();
            return View(DisposalsList);
        }

        return View();
    }


    public IActionResult Create()
    {
        DisposalVm disposalVm = new DisposalVm()
        {
            Disposal = new Disposal(),
            Brands = _brandRepository.GetAll().ToList().Select(u => new SelectListItem
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
            _disposalRepository.Add(disposalVm.Disposal);
            _disposalRepository.Save();
            TempData["success"] = "Successful creation";
            return RedirectToAction("Index");
        }
        else
        {
            disposalVm.Brands = _brandRepository.GetAll().ToList().Select(u => new SelectListItem
            {
                Text = u.BrandName,
                Value = u.Id.ToString()
            });
            return View(disposalVm);
        }
    }

    public IActionResult Edit(int? id)
    {
        DisposalVm disposalVm = new DisposalVm()
        {
            Disposal = _disposalRepository.Get(_ => _.Id == id),
            Brands = _brandRepository.GetAll().ToList().Select(u => new SelectListItem
            {
                Text = u.BrandName,
                Value = u.Id.ToString(),
            })
        };

        if (id == null || id == 0)
        {
            return NotFound();
        }

        if (disposalVm == null)
        {
            return NotFound();
        }

        return View(disposalVm);
    }

    [HttpPost]
    public IActionResult Edit(DisposalVm obj)
    {
        if (ModelState.IsValid)
        {
            _disposalRepository.Update(obj.Disposal);
            _disposalRepository.Save();
            TempData["success"] = "Edited successfully";
            return RedirectToAction("Index");
        }

        return NotFound();
    }

    #region API Calls

    [HttpGet]
    public IActionResult GetAll()
    {
        List<Disposal> DisposalsList = _disposalRepository.GetAll(includeProperties:"Brand").ToList();
        
        return Json(new { data = DisposalsList });
    }

    public IActionResult Delete(int? id)
    {
        var disposalToBeDeleted = _disposalRepository.Get(_ => _.Id == id);
        if (disposalToBeDeleted == null)
        {
            return Json(new { success = false, message = "Error while deleting" });
        }

        _disposalRepository.Remove(disposalToBeDeleted);
        _disposalRepository.Save();

        return Json(new
        {
            success = true, message = "Deleted successfully"
        });
    }

    #endregion
}