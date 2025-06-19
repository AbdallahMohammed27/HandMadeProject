namespace HandMadeEcommece.Models.Dto
{
    public class LogInVendor
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
