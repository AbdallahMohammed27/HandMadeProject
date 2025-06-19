//using HandMadeEcommece.Models.Data;
//using HandMadeEcommece.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Protocols.OpenIdConnect;
//using Microsoft.EntityFrameworkCore;

//namespace HandMadeEcommece.Controllers.DatabaseControllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CartItemsController : ControllerBase
//    {
//        private readonly IMapper _Mapper;
//        private readonly AppDbContext Context;
//        public CartItemsController(AppDbContext _Context, IMapper mapper)
//        {
//            Context = _Context;
//            _Mapper = mapper;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetCartItemsAll()
//        {
//            var cartItems = await Context.CartItems.ToListAsync();
//            if (cartItems == null) return NotFound();
//            return Ok(cartItems);
//        }

//        [HttpPost]
//        public async Task<IActionResult> CreateCartItem([FromBody] CartItemDto cartItemDto)
//        {
//            if (!ModelState.IsValid || cartItemDto == null || cartItemDto.CartId <= 0 || cartItemDto.ProductId <= 0) return BadRequest();

//            var product = await Context.Products.FindAsync(cartItemDto.ProductId);
//            var cart = await Context.Carts.FindAsync(cartItemDto.CartId);
//            if (product == null || cart == null) return NotFound("Error in cartId or ProductId."); 

//            var cartItem = new CartItem
//            {
//                CartId = cartItemDto.CartId,
//                ProductId = cartItemDto.ProductId,
//                Qty = cartItemDto.Qty,
//            };
//            await Context.CartItems.AddAsync(cartItem);
//            await Context.SaveChangesAsync();
//            return Ok(cartItem);
//        }


//        [HttpPut]
//        public async Task<IActionResult> UpdateCartItem(int id, CartItemDto cartItemDto)
//        {
//            if (id <= 0 || cartItemDto == null || cartItemDto.CartId <= 0 || cartItemDto.ProductId <= 0) return BadRequest();
//            var cartItem = await Context.CartItems.FindAsync(id);
//            if (cartItem == null) return NotFound("Not cartItem with this Id.");
//            var product = await Context.Products.FindAsync(cartItemDto.ProductId);
//            var cart = await Context.Carts.FindAsync(cartItemDto.CartId);
//            if (product == null || cart == null) return NotFound("Error in cartId or ProductId.");

//            cartItem.CartId = cartItemDto.CartId;
//            cartItem.ProductId = cartItemDto.ProductId;
//            cartItem.Qty = cartItemDto.Qty;
//            Context.CartItems.Update(cartItem);
//            await Context.SaveChangesAsync();
//            return Ok(cartItem);
//        }

//        [HttpDelete]
//        public async Task<IActionResult> DeleteCartItem([FromQuery] int id)
//        {
//            if (id <= 0) return BadRequest();
//            var CartItem = await Context.CartItems.FindAsync(id);
//            if (CartItem == null) return NotFound("Not cartitem with this id.");
//            Context.CartItems.Remove(CartItem);
//            await Context.SaveChangesAsync();
//            return Ok(CartItem);
//        }
//    }
//}
