using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace HandMadeEcommece.Models.Data
{
    public class CartItem
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Qty {  get; set; }
       // public Cart cart { get; set; } = null!;
    }
}
