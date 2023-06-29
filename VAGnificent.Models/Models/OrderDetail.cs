using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace VAGnificent.Models.Models;

public class OrderDetail
{
    [Key] public int Id { get; set; }
    public int OrderId { get; set; }
    public int DisposalId { get; set; }
    public decimal Price { get; set; }

    [ForeignKey("DisposalId"), ValidateNever]
    public virtual Disposal Disposal { get; set; }

    [ForeignKey("OrderId"), ValidateNever]
    public virtual Order Order { get; set; }
}