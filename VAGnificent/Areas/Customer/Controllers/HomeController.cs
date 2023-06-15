using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VAGnificent.DataAccess.Repository.IRepository;
using VAGnificent.Models.Models;

namespace VAGnificent.Areas.Customer.Controllers;

[Area("Customer")]
public class HomeController : Controller
{
    private readonly IDisposalRepository _disposalRepository;
    private readonly IBrandRepository _brandRepository;
    private readonly ILogger<HomeController> _logger;

    public HomeController(IBrandRepository brandRepository,
        IDisposalRepository disposalRepository, ILogger<HomeController> logger)
    {
        _logger = logger;
        _disposalRepository = disposalRepository;
        _brandRepository = brandRepository;
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

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}