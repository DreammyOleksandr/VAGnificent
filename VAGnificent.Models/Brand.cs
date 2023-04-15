using System.ComponentModel.DataAnnotations;

namespace VAGnificent.Models;

public class Brand
{
    [Key] public int Id { get; set; }
    [Required] public string BrandName { get; set; }
}