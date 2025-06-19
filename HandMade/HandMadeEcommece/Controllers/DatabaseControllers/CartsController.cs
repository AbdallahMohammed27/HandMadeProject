using HandMadeEcommece.Models.Data;
using HandMadeEcommece.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using HandMadeEcommece.Models.Dto;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace HandMadeEcommece.Controllers.DatabaseControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly IMapper _Mapper;
        private readonly AppDbContext Context;
        public CartsController(AppDbContext _Context, IMapper mapper)
        {
            Context = _Context;
            _Mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCartsAll()
        {
            var Carts = await Context.Carts.ToListAsync();
            if (Carts == null) return NotFound();
            return Ok(Carts);
        }


        [HttpGet("GetCart")]
        public async Task<IActionResult> GetCart(int id)
        {
            if (id <= 0) return BadRequest();
            var cart = await Context.Carts.FindAsync(id);
            if (cart == null) return NotFound("Not cart with id.");
            return Ok(cart);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCart([FromBody] CartDto cartDto)
        {
            if (!ModelState.IsValid) return BadRequest("Error in modelState.");

            if (cartDto.UserId <= 0) cartDto.UserId = null;
            else
            {
                var user = await Context.Users.FindAsync(cartDto.UserId);
                if (user == null) return NotFound("Not user with this Id.");
            }
            var cart = new Cart
            {
                IsActived = 1,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                UserId = cartDto.UserId
            };
            await Context.Carts.AddAsync(cart);
            await Context.SaveChangesAsync();
            return Ok(cart);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCart(int id, CartDto cartDto)
        {
            if (id <= 0 || cartDto == null) return BadRequest();
            var cart = await Context.Carts.FindAsync(id);
            if (cart == null) return NotFound();

            if (cartDto.UserId.HasValue)
            {
                if (cartDto.UserId.Value <= 0) return BadRequest();
                var user = await Context.Users.FindAsync(cartDto.UserId);
                if (user == null) return NotFound("Not User in this cart.");
            }
            cartDto.UserId = null;
            cart.IsActived = 1;
            cart.CreatedAt = DateTime.UtcNow;
            cart.UpdatedAt = DateTime.UtcNow;
            cart.UserId = cartDto.UserId;
            Context.Carts.Update(cart);
            await Context.SaveChangesAsync();
            return Ok(cart);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCart([FromQuery] int id)
        {

            if (id <= 0) return BadRequest();
            var Cart = await Context.Carts.FindAsync(id);
            if (Cart == null) return NotFound("Not cart with this id.");
            Context.Carts.Remove(Cart);
            await Context.SaveChangesAsync();
            return Ok(Cart);
        }
    }
}
