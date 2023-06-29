namespace VAGnificent.Models.Models;

public class Order
{
    public int Id { get; set; }

    public List<OrderDetail> OrderDetails { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PostalCode { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string OrderTotal { get; set; }
    public DateTime OrderPlaced { get; set; }
}