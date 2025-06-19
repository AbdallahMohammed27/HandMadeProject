using System;
using System.Collections.Generic;

namespace HandMadeEcommece.Models.Data;

public class ProductReview
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int UserId { get; set; }

    public string Review { get; set; } = null!;

    public string Rating { get; set; } = null!;

    public int Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public Product Product { get; set; } = null!;

    public User User { get; set; } = null!;
    public ICollection<ProductReviewGallery> ImageGallery { get; set; } = new List<ProductReviewGallery>();
}
