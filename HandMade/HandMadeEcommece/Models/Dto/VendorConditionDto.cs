namespace HandMadeEcommece.Models.Dto
{
    public class VendorConditionDto
    {
        [Required]
        public List<string> Content { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
