using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;

namespace HandMadeEcommece.Models.Data;

public class VendorCondition
{
    public int Id { get; set; }

    public List<string>Content { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
    public ICollection<Admin>admins = new List<Admin>();
    public ICollection<AdminVendorConditions> AdminVendorConditions { get; set; } = new List<AdminVendorConditions>();
}
