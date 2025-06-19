namespace HandMadeEcommece.Models.Dto
{
    public class LogInAdmin
    {
        [Required]
        public string UserName {  get; set; }
        [Required]
        public string Password { get; set; }
    }
}
