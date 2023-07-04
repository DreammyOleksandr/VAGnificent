using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace VAGnificent.Models.Models;

public class Order
{
    [Key, BindNever] public int Id { get; set; }

    [ValidateNever]public List<OrderDetail> OrderDetails { get; set; }

    [Required(ErrorMessage = "Enter your first name")]
    [DisplayName("First Name")]
    [StringLength(50)]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Enter your last name")]
    [DisplayName("Last Name")]
    [StringLength(50)]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Enter your Address")]
    [StringLength(100)]
    public string Address { get; set; }

    [Required(ErrorMessage = "Enter your postal code")]
    [DisplayName("Postal Code")]
    [StringLength(10, MinimumLength = 4)]
    public string PostalCode { get; set; }

    [Required(ErrorMessage = "Enter your state")]
    [StringLength(50)]
    public string State { get; set; }

    [Required(ErrorMessage = "Enter your country")]
    [StringLength(50)]
    public string Country { get; set; }

    [Required(ErrorMessage = "Enter your phone number")]
    [DisplayName("Phone Number")]
    [StringLength(20)]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Enter your email")]
    [StringLength(50)]
    public string Email { get; set; }

    [ValidateNever]public string OrderTotal { get; set; }

    public DateTime OrderPlaced { get; set; } = DateTime.Now;
}