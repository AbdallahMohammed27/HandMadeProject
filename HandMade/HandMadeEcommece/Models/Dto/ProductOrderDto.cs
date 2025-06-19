namespace HandMadeEcommece.Models.Dto
{
    public class ProductOrderDto
    {
        [Required]  
        public int ProductId {  get; set; }
        [Required]
        public int OrderId {  get; set; }
    }
}
