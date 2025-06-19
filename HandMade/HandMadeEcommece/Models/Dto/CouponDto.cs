namespace HandMadeEcommece.Models.Dto
{
    public class CouponDto
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]


        public string Code { get; set; } = null!;
        [Required]

        public int Quantity { get; set; }
        [Required]

        public int MaxUse { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        [Required]

        public DateTime EndDate { get; set; }
        [Required]

        public double Discount { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]

        public int Status { get; set; }
    }
}
