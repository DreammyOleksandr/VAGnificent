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
    private readonly IWebHostEnvironment _webHostEnvironment;

    public DisposalController(IDisposalRepository disposalRepository, IBrandRepository brandRepository,
        IWebHostEnvironment webHostEnvironment)
    {
        _disposalRepository = disposalRepository;
        _brandRepository = brandRepository;
        _webHostEnvironment = webHostEnvironment;
    }

    public IActionResult Index()
    {
        if (ModelState.IsValid)
        {
            List<Disposal> DisposalsList = _disposalRepository.GetAll(includeProperties: "Brand").ToList();
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
    public IActionResult Create(DisposalVm disposalVm, IFormFile? file)
    {
        string webRootPath = _webHostEnvironment.WebRootPath;
        if (file != null)
        {
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string disposalsPath = Path.Combine(webRootPath, @"images/disposals");

            using (var fileStream = new FileStream(Path.Combine(disposalsPath, fileName), FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            disposalVm.Disposal.ImageUrl = @"/images/disposals/" + fileName;
        }

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
    public IActionResult Edit(DisposalVm obj, IFormFile? file)
    {
        string webRootPath = _webHostEnvironment.WebRootPath;

        if (ModelState.IsValid)
        {
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string disposalsPath = Path.Combine(webRootPath, @"images/disposals");

                if (!string.IsNullOrEmpty(obj.Disposal.ImageUrl))
                {
                    string oldImagePath = $"{webRootPath}{obj.Disposal.ImageUrl.TrimStart('\\')}";

                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                using (var fileStream = new FileStream(Path.Combine(disposalsPath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                obj.Disposal.ImageUrl = @"/images/disposals/" + fileName;
            }

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
        List<Disposal> DisposalsList = _disposalRepository.GetAll(includeProperties: "Brand").ToList();

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