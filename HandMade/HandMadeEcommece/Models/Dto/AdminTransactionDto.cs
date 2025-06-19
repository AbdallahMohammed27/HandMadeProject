namespace HandMadeEcommece.Models.Dto
{
    public class AdminTransactionDto
    {
        [Required]
        public int AdminId { get; set; }
        [Required]
        public int TransactionMoneyId { get; set; }
    }
}
