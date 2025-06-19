using HandMadeEcommece.Models.Data;

namespace HandMadeEcommece.Models.Dto
{
    public class OrderDto
    {
        [Required]

        public int CompanyDeliveryId { get; set; }

        public int? UserId { get; set; }

        [JsonIgnore(Condition =JsonIgnoreCondition.WhenWritingDefault)]

        public CurrencyName CurrencyName { get; set; } = CurrencyName.EGP;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]

        public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.Paypal;
        [Required]

        public string OrderAddress { get; set; } = null!;
        [JsonIgnore]
        public double Discount { get; set; } = 0.0;
        [JsonIgnore]
        public decimal DFees { get; set; } = 0.0m;
        [Required]
        public decimal SubTotal { get; set; } = 0.0m;

        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
        [Required]
        [JsonPropertyName("productsOrder")]
        public List<ProductsOrderDto> ProductsOrder { get; set; } = new List<ProductsOrderDto>();
        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

    }
}
