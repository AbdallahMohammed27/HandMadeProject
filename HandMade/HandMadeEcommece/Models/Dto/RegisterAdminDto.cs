

namespace HandMadeEcommece.Models.Dto
{
    public class RegisterAdminDto
    {
        public string? image { get; set; }
        [Required]
        public string Address {  get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }
        [Required]

        public string UserName { get; set; }
        [Required,JsonIgnore]

        public string Password { get; set; }
        [Required]

        public string Email { get; set; }

        [Compare("Password"),Required]
        public string ConfirmPassword {  get; set; }
        [Required,MaxLength(15)]

        public string Phone { get; set; }
        [Required]

        public decimal Salary {  get; set; }
    }
}
