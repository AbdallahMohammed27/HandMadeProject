namespace HandMadeEcommece.Models.Dto
{
    public class RegisterVendor
    {
        [Required]
        public string FName { get; set; }
        [Required]
        public string StripeId {  get; set; }
        [Required]
        public string LName { get; set; }
        [Required,MaxLength(255)]
        public string Password {  get; set; }
        [Required]
        public string UserName {  get; set; }
        [Required,Compare("Password"),MaxLength(255)]
        public string ConfirmPassword {  get; set; }
        [Required, MaxLength(15)]
        public string Phone {  get; set; }

        public string? Image { get; set; }
        [Required]
        public string Address {  get; set; }
        [Required]

        public string Banner { get; set; } = null!;
        [Required]

        public string Email { get; set; } = null!;

        //public string Address { get; set; } = null!;
        [Required,MaxLength(255)]

        public string Description { get; set; } = null!;

        public string? FbLink { get; set; }

        public string? TwLink { get; set; }

        public string? InstaLink { get; set; }

        public string? ShopName { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]

        public int Status { get; set; } = 0;
    }
}
