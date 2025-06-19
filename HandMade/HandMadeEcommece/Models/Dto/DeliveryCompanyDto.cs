namespace HandMadeEcommece.Models.Dto
{
    public class DeliveryCompanyDto
    {
        [Required]
        public string Name { get; set; } = null!;
        [EmailAddress(ErrorMessage = "InValid Email"),Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Address { get; set; } = null!;
        [Required]
        public string Delivery_Zones { get; set; } = null!;
        [Required]
        public decimal Pricing { get; set; }
        [Required]
        public string IdTax { get; set; } = null!;
        [Required]
        public string Logo { get; set; } = null!;
    }
}
