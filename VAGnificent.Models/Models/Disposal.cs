using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VAGnificent.Models.Models;

public class Disposal
{
    [Key]
    public int Id { get; set; }
    
    [ValidateNever, DisplayName("Brand")]
    public int BrandId { get; set; }
    [ForeignKey("BrandId")]
    [ValidateNever]
    public Brand? Brand { get; set; }

    [Required] public string? Model { get; set; }
    [Required, DisplayName("Country of Brand")] public string? BrandCountry { get; set; }
    [Required] public string? Colour { get; set; }
    [Required, DisplayName("Fuel Type")] public string? FuelType { get; set; }
    public int Weight { get; set; }
    [DisplayName("Horse Power")]public int HorsePower { get; set; }
    [DisplayName("Engine Capacity")]public int EngineCapacity { get; set; }
    [Required, DisplayName("Transmision Type")] public string? TransmisionType { get; set; }
    [Required, DisplayName("Travelled Distance")] public int TravelledDistance { get; set; }
    [Required] public DateTime Year { get; set; }

    [Required, Range(0, 999999, ErrorMessage = "Our site is not that rich to sell such expensive cars :D"), DisplayName("Price in Dollars")]
    public int DollarsPrice { get; set; }

    [Required] public bool Accidents { get; set; }
    [ValidateNever, DisplayName("Image")] public string? ImageUrl { get; set; }
}