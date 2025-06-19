using HandMadeEcommece.Models.Data;
using System.ComponentModel.DataAnnotations;

namespace HandMadeEcommece.Models.Dto
{
    public class VendorDto
    {
        public string FName { get; set; } 
        public string LName { get; set; }
        [Required]

        public string UserName {  get; set; }

        public string? Image {  get; set; }

        [Required]
        public string Address { get; set; } = null!;

        public string? Banner { get; set; }

        public string Phone { get; set; } = null!;

        [Required]
        public string Password { get; set; }
 

        //public string Address { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string? FbLink { get; set; }

        public string? TwLink { get; set; }

        public string? InstaLink { get; set; }

        public string? ShopName { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]

        public int Status { get; set; } = 0;

    }
}
