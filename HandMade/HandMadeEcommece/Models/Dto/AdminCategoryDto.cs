namespace HandMadeEcommece.Models.Dto
{
    public class AdminCategoryDto
    {
        [Required]
        public int AdminId { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
