namespace HandMadeEcommece.Models.Dto
{
    public class CartItemDto
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Qty {  get; set; }
    }
}
