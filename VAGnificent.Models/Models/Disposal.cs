using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VAGnificent.Models.Models;

public class Disposal
{
    [Key]
    public int Id { get; set; }
    
    [ValidateNever]
    public int BrandId { get; set; }
    [ForeignKey("BrandId")]
    [ValidateNever]
    public Brand? Brand { get; set; }

    [Required] public string? Model { get; set; }
    [Required] public string? BrandCountry { get; set; }
    [Required] public string? Colour { get; set; }
    [Required] public string? FuelType { get; set; }
    public int Weight { get; set; }
    public int HorsePower { get; set; }
    public int EngineCapacity { get; set; }
    [Required] public string? TransmisionType { get; set; }
    [Required] public int TravelledDistance { get; set; }
    [Required] public DateTime Year { get; set; }

    [Required, Range(0, 999999, ErrorMessage = "Our site is not that rich to sell such expensive cars :D")]
    public int DollarsPrice { get; set; }

    [Required] public bool Accidents { get; set; }
    [ValidateNever] public string? ImageUrl { get; set; }
}