namespace HandMadeEcommece.Models.Dto
{
    public class PaymentDto
    {
        [Required]
        public long Amount { get; set; }
        [Required]
        public int CompanyDelivery {  get; set; }
        [Required]
        public List<ProductsOrderDto> Products { get; set; }
    }
}
