namespace HandMadeEcommece.Models.Dto
{
    public class TranseferDto
    {
        public string PaymentIntentId { get; set; }
        public int CompanyDelivery { get; set; }
        public List<ProductsOrderDto> Products { get; set; }
    }
}
