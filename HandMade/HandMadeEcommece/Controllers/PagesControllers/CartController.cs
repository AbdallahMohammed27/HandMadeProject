using HandMadeEcommece.Models;
using HandMadeEcommece.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HandMadeEcommece.Controllers.PagesControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly AppDbContext _Context;
        private readonly IAuth _auth;
        private const string CartSessionKey = "ShoppingCart";
        public CartController(AppDbContext Context, IAuth auth)
        {
            _Context = Context;
            _auth = auth;
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProduct([FromQuery] int id)
        {
            if (id <= 0) return BadRequest();
            var cart = await _Context.Carts.FindAsync(id);
            if (cart == null) return NotFound("Not cart with this id.");
            var products = await _Context.Carts.Where(e => e.Id == id).Include(e => e.items).
                SelectMany(e => e.items)
                .Select(e => new
                {
                    e.ProductId,
                    e.CartId,
                    e.Qty,
                })
                .ToListAsync();
            return Ok(products);
        }

        [HttpDelete("DeleteCartItem")]
        public async Task<IActionResult> DeleteCartItem([FromQuery] int id)
        {
            if (id <= 0) return BadRequest();
            var CartItem = await _Context.CartItems.FindAsync(id);
            if (CartItem == null) return NotFound("Not cartitem with this id.");
            _Context.CartItems.Remove(CartItem);
            await _Context.SaveChangesAsync();
            return Ok(CartItem);
        }

        //[HttpPost("CreateOrder")]
        //public async Task<IActionResult> CreateOrder(OrderDto orderDto)
        //{
        //    if (!ModelState.IsValid || orderDto.CompanyDeliveryId <= 0 || orderDto.UserId <= 0) return BadRequest();
        //    var user = await _Context.Users.FindAsync(orderDto.UserId);
        //    var delivery = await _Context.DeliveryCompanies.FindAsync(orderDto.CompanyDeliveryId);
        //    if (user == null || delivery == null) return NotFound("Error in cartId or userId or deliveryId.");
        //    orderDto.DFees = delivery.Pricing;
        //    orderDto.SubTotal = orderDto.SubTotal;
        //    orderDto.Discount = (orderDto.Discount / 100) * (double)orderDto.SubTotal;
        //    return Ok(orderDto);
        //}

        [HttpGet("GetCart")]
        public async Task<IActionResult> GetCart()
        {
            var session = HttpContext.Session.GetString(CartSessionKey);
            if (session == null) return NotFound("Not found cart.");
            return Ok(JsonSerializer.Deserialize<List<CartItemDto>>(session));
        }

        [HttpDelete("DeleteCart")]
        public async Task<IActionResult> DeleteCart(CartItemDto cartItemDto)
        {
            if (cartItemDto == null) return BadRequest();
            var session = HttpContext.Session.GetString(CartSessionKey);
            if (session == null) return NotFound("Not found cart.");
            var cart = JsonSerializer.Deserialize<List<CartItemDto>>(session);
            if (!cart.Contains(cartItemDto)) return NotFound("Not product in this cart.");
            cart.Remove(cartItemDto);
            HttpContext.Session.SetString(CartSessionKey, JsonSerializer.Serialize(cart));
            return Ok(cart);
        }
    }
}
