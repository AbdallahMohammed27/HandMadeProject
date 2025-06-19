global using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandMadeEcommece.Models.Dto
{
    public class ChangePasswordDto
    {
        [Required]
        public string UserName { get; set; }
        [JsonIgnore]
        public string? Message {  get; set; }
        [JsonIgnore]
        public bool IsChange { get; set; } = false;

        [Required]
        public string CurrentPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }

        [Required]
        [Compare("NewPassword")]
        public string ConfirmPassword { get; set; }
    }
}
