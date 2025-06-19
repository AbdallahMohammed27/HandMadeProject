namespace HandMadeEcommece.Models.Dto
{
    public class ProductReviewGalleryDto
    {
        [Required]
        public int ProductReviewId { get; set; }

        [Required]
        public string Image { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
