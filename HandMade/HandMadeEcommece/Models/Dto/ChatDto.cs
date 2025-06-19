namespace HandMadeEcommece.Models.Dto
{
    public class ChatDto
    {
        [Required]
        public int UserId { get; set; }
        [Required]

        public int VendorId { get; set; }
        [Required]

        public string Message { get; set; } = null!;
        [Required]

        public int Seen { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
