using Microsoft.AspNetCore.Mvc;
using VAGnificent.DataAccess.Repository.IRepository;
using VAGnificent.Models.Models;

namespace VAGnificent.Areas.Customer.Controllers;

[Area("Customer")]
public class OrderController : Controller
{
    private readonly IOrderRepository _orderRepository;

    public OrderController(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    
    public IActionResult CheckOut(int? id)
    {
        var order = _orderRepository.Get(_ => _.Id == id);
        return View(order);
    }
}