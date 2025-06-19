using Microsoft.AspNetCore.Http.Features;

namespace HandMadeEcommece.Models.Data
{
    public class Cart
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int IsActived { get; set; }
        public int? UserId {  get; set; }//delete
        [JsonIgnore]
        public User? User { get; set; }
        public ICollection<CartItem> items { get; set; } = new List<CartItem>();
        public ICollection<Product> products { get; set; } = new List<Product>();
        //public Order Order { get; set; } = null!;
    }
}
