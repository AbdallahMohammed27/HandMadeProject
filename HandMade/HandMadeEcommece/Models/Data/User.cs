using HandMadeEcommece.helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandMadeEcommece.Models.Data;

public class User 
{
    public int Id {  get; set; }
    public int RoleId {  get; set; }
    [Column(TypeName = "VARCHAR(255)")]
    public string? Image { get; set; }
    public string FName { get; set; } = null!;
    public string LName { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string? Password { get; set; }

    public string? Phone { get; set; }

    public string Email { get; set; } = null!;

    public Role Role { get; set; } = null!;
    public ICollection<ClaimUser> Claims { get; set; } = new List<ClaimUser>();
    public ICollection<Cart>? Carts { get; set; }
    public ICollection<Chat> Chats { get; set; } = new List<Chat>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<WishList> WishLists { get; set; } = new List<WishList>();
    public ICollection<Product> Products { get; set; }=new List<Product>();
    public ICollection<UserCoupons> UserCoupons { get; set; } = new List<UserCoupons>();
    public ICollection<Coupon> Coupons { get; set; } = new List<Coupon>();
    public ICollection<PaypalSetting> PaypalSettings { get; set; } = new List<PaypalSetting>();
    public ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();
    public ICollection<TransactionMoney> TransactionMoneys { get; set; } = new List<TransactionMoney>();
}
