namespace VAGnificent.Models.Models;

public class OrderDetail
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int DisposalId { get; set; }
    public decimal Price { get; set; }
    public virtual Disposal Disposal { get; set; }
}