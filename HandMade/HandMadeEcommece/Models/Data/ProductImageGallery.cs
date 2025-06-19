using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandMadeEcommece.Models.Data;

public class ProductImageGallery
{
    public int Id { get; set; }

    [Column(TypeName ="VARCHAR(255)")]
    public string Image { get; set; }

    public int ProductId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public Product Product { get; set; } = null!;
}
