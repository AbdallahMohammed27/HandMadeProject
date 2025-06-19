namespace HandMadeEcommece.Models.Dto
{
    public class TransactionDto
    {
        [Required]
        public int OrderId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int CompanyDeliveryId { get; set; }

        [Required]
        public string PaymentMethod { get; set; } = null!;

        [Required]
        public double Amount { get; set; }

        [Required]
        public double AmountRealCurrency { get; set; }

        [Required]
        public string AmountRealCurrencyName { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }
    }
}
