namespace HandMadeEcommece.Models.Dto
{
    public class BrandDto
    {
        [Required]
        public string Logo { get; set; } = null!;
        [Required]

        public string Name { get; set; } = null!;
        [Required]

        public string Slug { get; set; } = null!;
        [Required]

        public BrandStatus Status { get; set; } = BrandStatus.Inactive;

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
