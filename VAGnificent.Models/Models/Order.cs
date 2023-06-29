using System.ComponentModel.DataAnnotations;

namespace VAGnificent.Models.Models;

public class Order
{
    [Key] public int Id { get; set; }

    public List<OrderDetail> OrderDetails { get; set; }

    [Required] public string FirstName { get; set; }
    [Required] public string LastName { get; set; }
    [Required] public string Address { get; set; }
    [Required] public string PostalCode { get; set; }
    [Required] public string State { get; set; }
    [Required] public string Country { get; set; }
    [Required] public string PhoneNumber { get; set; }
    [Required] public string Email { get; set; }

    public string OrderTotal { get; set; }

    public DateTime OrderPlaced { get; set; }
}