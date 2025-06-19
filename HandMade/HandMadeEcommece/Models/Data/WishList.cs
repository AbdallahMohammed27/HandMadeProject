using System.ComponentModel.DataAnnotations.Schema;

namespace HandMadeEcommece.Models.Data
{
    public class WishList
    {
        public int ProductId {  get; set; }
        public int UserId {  get; set; }
        [JsonIgnore]
        public Product? Product { get; set; }
    }
}
