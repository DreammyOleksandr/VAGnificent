using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace VAGnificent.Models.Models;

public class ApplicationUser : IdentityUser
{
    [Required]
    public string Name { get; set; }
    
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    
    [DisplayName("Postal Code")]
    public string? PostalCode { get; set; }
}