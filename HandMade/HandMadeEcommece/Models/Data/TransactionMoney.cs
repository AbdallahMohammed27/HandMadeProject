using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;

namespace HandMadeEcommece.Models.Data;

public class TransactionMoney
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int UserId {  get; set; }

    public int CompanyDeliveryId { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public double Amount { get; set; }

    public double AmountRealCurrency { get; set; }

    public string AmountRealCurrencyName { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DeliveryCompany DeliveryCompany { get; set; } = null!;
    public Order order { get; set; } = null!;
    public User user { get; set; } = null!;
    public ICollection<Admin> admins { get; set; } = new List<Admin>();
    public ICollection<AdminTransaction> adminTransactions { get; set; }= new List<AdminTransaction>();
    public ICollection<Vendor> vendors { get; set; } = new List<Vendor>();
    public ICollection<VendorTransaction> vendorTransactions { get;set; } = new List<VendorTransaction>();
}
