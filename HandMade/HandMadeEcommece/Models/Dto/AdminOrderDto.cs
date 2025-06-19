namespace HandMadeEcommece.Models.Dto
{
    public class AdminOrderDto
    {
        [Required]
        public int AdminId { get; set; }
        [Required]
        public int OrderId { get; set; }
    }
}
