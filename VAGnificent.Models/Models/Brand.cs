using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VAGnificent.Models.Models;

public class Brand
{
    [Key] public int Id { get; set; }
    [Required, DisplayName("Brand Name")] public string BrandName { get; set; }
    [Required] public string CEO { get; set; }
}