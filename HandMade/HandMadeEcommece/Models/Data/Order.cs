using System;
using System.Collections.Generic;

namespace HandMadeEcommece.Models.Data;

public class Order
{
    public int Id { get; set; }
    public int CompanyDeliveryId {  get; set; }

    //public int CartId { get; set; }

    public int? UserId { get; set; }

    public string? UserName {  get; set; }

    public decimal Amount { get; set; }// Amount from cart

    public string CurrencyName { get; set; } = null!;


    public string PaymentMethod { get; set; } = null!;

    public string OrderAddress { get; set; } = null!;

    public string OrderStatus { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DeliveryCompany DeliveryCompany { get; set;} = null!;
    public User user { get; set; } = null!;
    public TransactionMoney transactionMoney { get; set; } = null!;
   // public Cart Cart { get; set; } = null!;
    public ICollection<AdminOrder> adminOrders { get; set; } = new List< AdminOrder > ();
    public ICollection<Admin>admins { get; set; } = new List < Admin > ();
    public ICollection<OrderVendor> orderVendor { get; set; } = new List<OrderVendor> ();
    public ICollection<Vendor> vendor { get; set; } = new List<Vendor>();
    public ICollection<Product> product { get; set; } = new List<Product> ();
    public ICollection<OrderProduct> orderProduct { get; set; } = new List<OrderProduct>();
}
