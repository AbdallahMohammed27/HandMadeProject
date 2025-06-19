namespace HandMadeEcommece.Models.Dto
{
    public class CategoryDto
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]

        public string Slug { get; set; } = null!;

        public string? Icon { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]

        public int Status { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
