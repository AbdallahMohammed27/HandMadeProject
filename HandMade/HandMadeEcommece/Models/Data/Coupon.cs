using System;
using System.Collections.Generic;

namespace HandMadeEcommece.Models.Data;

public class Coupon
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public int Quantity { get; set; }

    public int MaxUse { get; set; }
    [Required]

    public DateTime StartDate { get; set; }
    [Required]

    public DateTime EndDate { get; set; }

    public double Discount { get; set; }

    public int Status { get; set; }

    public int TotalUsed { get; set; }
    public ICollection<Product> products { get; set; } = new List<Product>();
    public ICollection<UserCoupons>userCoupons { get; set; } = new List<UserCoupons>();
    public ICollection<User> users { get;set; } = new List<User>();
}
