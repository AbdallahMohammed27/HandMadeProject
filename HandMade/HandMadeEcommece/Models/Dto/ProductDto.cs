using HandMadeEcommece.Models.Data;

namespace HandMadeEcommece.Models.Dto
{
    public class ProductDto
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]

        public string Slug { get; set; } = null!;
        [Required]

        public string ThumbImage { get; set; }
        
        public int VendorId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]

        public int? CategoryId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]

        public int? BrandId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]

        public int? CouponId { get; set; }
        [Required]

        public int Qty { get; set; }
        [Required]

        public string ShortDescription { get; set; } = null!;
        [Required]

        public string LongDescription { get; set; } = null!;

        public string? Sku { get; set; }
        [Required]

        public double Price { get; set; }

        public double? OfferPrice { get; set; }

        public DateTime? OfferStartDate { get; set; }

        public DateTime? OfferEndDate { get; set; }

        public string? ProductType { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]

        public int IsApproved { get; set; }

        public string? SeoTitle { get; set; }

        public string? SeoDescription { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

    }
}
