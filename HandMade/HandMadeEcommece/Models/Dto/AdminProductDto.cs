namespace HandMadeEcommece.Models.Dto
{
    public class AdminProductDto
    {
        [Required]
        public int AdminId { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}
