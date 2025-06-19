using System.ComponentModel.DataAnnotations.Schema;

namespace HandMadeEcommece.Models.Dto
{
    public class ProductImageGalleryDto
    {
        [Required]
        public string Image { get; set; }
        [Required]

        public int ProductId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
