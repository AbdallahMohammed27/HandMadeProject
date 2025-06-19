using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandMadeEcommece.Models.Data;

public class ProductReviewGallery
{
    public int Id { get; set; }

    public int ProductReviewId { get; set; }

    [Column(TypeName ="VARCHAR(255)")]
    public string Image { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public ProductReview ProductReview { get; set; } = null!;
}
