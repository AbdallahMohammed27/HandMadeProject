using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandMadeEcommece.Models.Data;

public class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Slug { get; set; } = null!;

    [Column(TypeName = "VARCHAR(255)")]
    public string? Icon { get; set; }

    public int Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    //public ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>();
    public ICollection<Product> Products { get; set; } = new List<Product>();
    public ICollection<Admin>admins { get; set; } = new List<Admin>();  
    public ICollection<AdminCategory> categories { get; set; } = new List<AdminCategory>();
}
