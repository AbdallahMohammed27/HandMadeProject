using System;
using System.Collections.Generic;

namespace HandMadeEcommece.Models.Data;

public class PaypalSetting
{
    public int Id { get; set; }
    public int AccountId {  get; set; }//from user
    public int VendorId { get; set; }
    public int UserId { get; set; }
    public int CompanyDeliveryId {  get; set; }

    public int Status { get; set; }

    public int Mode { get; set; }

    public string CountryName { get; set; } = null!;

    public CurrencyName CurrencyName { get; set; } = CurrencyName.EGP;

    public double CurrencyRate { get; set; }

    public string SecretKey { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
    public User User { get; set; } = null!;
    public DeliveryCompany DeliveryCompany { get; set; } = null!;
    public Vendor Vendor { get; set; } = null!;
}
