namespace HandMadeEcommece.Models.Dto
{
    public class LogInUserModel
    {
        [Required]
        public string UserName { get; set; }
        public string? Password { get; set; }
    }
}
