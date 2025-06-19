using HandMadeEcommece.helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandMadeEcommece.Models.Data;

public class Vendor
{
    public int Id { get; set; }
    public int RoleId {  get; set; }
    [Column(TypeName = "VARCHAR(255)")]
    public string? Image { get; set; }
    public string Address { get; set; } = null!;
    public string FName { get; set; } = null!;
    public string LName { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string? Banner { get; set; }
    public string Description { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email {  get; set; } = null!;

    public string? FbLink { get; set; }

    public string? TwLink { get; set; }

    public string? InstaLink { get; set; }

    public string? ShopName { get; set; }

    public int Status {  get; set; }

    public Role Role { get; set; } = null!;
    public ICollection<ClaimVendor> claims { get; set; } = new List<ClaimVendor>();
    public ICollection<Chat> Chats { get; set; } = new List<Chat>();
    public ICollection<Admin> admins { get; set; } = new List<Admin>();
    public ICollection<AdminVendor> adminsVendor { get; set; } = new List<AdminVendor>();
    public ICollection<OrderVendor> orderVendor { get; set; } = new List<OrderVendor>();
    public ICollection<Order> orders { get; set; } = new List<Order>();
    public ICollection<Product> products { get; set; } = new List<Product>();
    //public ICollection<VendorProduct> vendorProducts { get; set; } = new List<VendorProduct>();
    public ICollection<PaypalSetting> paypalSettings { get; set; } = new List<PaypalSetting>();
    public ICollection<TransactionMoney>transactionMoney { get; set; } = new List<TransactionMoney>();
    public ICollection<VendorTransaction>vendorTransactions { get; set; } = new List<VendorTransaction>();
}
