using HandMadeEcommece.Models.Data;
using System.ComponentModel.DataAnnotations;

namespace HandMadeEcommece.Models.Dto
{
    public class UserDto
    {

        public string FName { get; set; } = null!;
        public string LName { get; set; } = null!;
        [Required]

        public string UserName { get; set; }

        public string? image { get; set; }

        public string? Phone { get; set; }
        [Required]
        [JsonIgnore]

        public string Password { get; set; } = null!;
   
    }
}
