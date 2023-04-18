using Microsoft.AspNetCore.Mvc.Rendering;
using VAGnificent.Models.Models;

namespace VAGnificent.Models.ViewModels;

public class DisposalVm
{
    public Disposal Disposal { get; set; }
    public IEnumerable<SelectListItem> Brands { get; set; }
}