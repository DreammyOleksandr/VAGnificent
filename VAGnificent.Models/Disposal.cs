using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace VAGnificent.Models;

public class Disposal
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(50, ErrorMessage = "Brand name can not contain 50 symbols")]

    public int BrandId { get; set; }
    [ForeignKey("BrandId")]
    public Brand Brand { get; set; }
    [Required]
    public string? Model { get; set; }
    [Required]
    public string? BrandCountry { get; set; }
    [Required]
    public string? Colour { get; set; }
    [Required]
    public string? FuelType { get; set; }
    public string? Weight { get; set; }
    public string? HorsePower { get; set; }
    public double EngineCapacity { get; set; }
    [Required]
    public string? TransmisionType { get; set; }
    [Required]
    public double TravelledDistance { get; set; }
    [Required]
    public DateTime Year { get; set; }
    [Required, MaxLength(999999, ErrorMessage = "Our site is not that rich to sell such expensive cars :D")]
    public decimal DollarsPrice { get; set; }
    [Required]
    public bool Accidents { get; set; }
    [ValidateNever]
    public string ImageUrl { get; set; }
}