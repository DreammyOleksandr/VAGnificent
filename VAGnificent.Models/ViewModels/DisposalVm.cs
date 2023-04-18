using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using VAGnificent.Models.Models;

namespace VAGnificent.Models.ViewModels;

public class DisposalVm
{
    public Disposal Disposal { get; set; }
    [ValidateNever]
    public IEnumerable<SelectListItem> Brands { get; set; }
}