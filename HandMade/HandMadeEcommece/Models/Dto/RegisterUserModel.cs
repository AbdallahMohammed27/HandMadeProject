namespace HandMadeEcommece.Models.Dto
{
    public class RegisterUserModel
    {
        [Required,StringLength(255)]
        public string FName {  get; set; }
        [Required, StringLength(255)]
        public string LName { get; set; }
        [Required, StringLength(255)]
        public string UserName {  get; set; }
        [StringLength(255)]
        public string? Password { get; set; }
        [Compare("Password")]
        public string? ConfirmPassword {  get; set; }
        [Required, StringLength(255)]
        public string Email { get; set; }
        [StringLength(15)]
        public string? Phone { get; set; }
        public string? Image { get; set; }

    }
}
