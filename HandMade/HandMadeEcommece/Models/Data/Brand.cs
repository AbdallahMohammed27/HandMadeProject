using HandMadeEcommece.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandMadeEcommece.Models;

public class Brand
{
    public int Id { get; set; }

    [Column(TypeName = "VARCHAR(255)")]
    public string? Logo { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public ICollection<Product> products { get; set; } = new List<Product>();
    public ICollection<Admin> admins { get; set; } = new List<Admin>();
    public ICollection<AdminBrand>adminBrands { get; set; } = new List<AdminBrand>();
}
