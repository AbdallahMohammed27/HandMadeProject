using HandMadeEcommece.Models;
using HandMadeEcommece.Models.Data;
using HandMadeEcommece.Models.Dto;
using HandMadeEcommece.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;
using System.Text.Json;

namespace HandMadeEcommece.Controllers.PagesControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly AppDbContext _Context;
        private readonly IAuth _auth;
        private const string CartSessionKey = "ShoppingCart";
        public HomeController(AppDbContext context, IAuth auth)
        {
            _Context = context;
            _auth = auth;
        }

 

        [HttpGet("Offers")]
        public async Task<IActionResult> GetOffers()
        {
            var product = await _Context.Products.Where(e=>e.OfferPrice > 0).ToListAsync();
            if(product == null) return NotFound("Not Offers.");
            return Ok(product);
        }

        [HttpGet("GetOffer")]

        public async Task<IActionResult> GetSpecificOffer([FromQuery] double offer)
        {
            var products = await _Context.Products.Where(e => e.OfferPrice == offer).ToListAsync();
            if (products == null) return NotFound("Not products in this offer.");
            return Ok(products);
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _Context.Products.Select(e => new
            {
                e.Id,
                e.Sku,
                e.Name,
                e.Slug,
                e.Price,
                e.Qty,
                e.OfferPrice,
                e.LongDescription,
                e.OfferEndDate,
                e.OfferStartDate,
                e.ThumbImage
            }).ToListAsync();
            if (products.Count == 0) return NotFound("Products is not found.");
            return Ok(products);
        }

        //[HttpPost("AddInWishList")]
        //public async Task<IActionResult> AddInWishList(WishListDto wishListDto)
        //{
        //    if (wishListDto == null || wishListDto.UserId <= 0 || wishListDto.ProductId <= 0) return BadRequest("Error in userId or productId.");
        //    var user = await _Context.Users.FindAsync(wishListDto.UserId);
        //    var product = await _Context.Products.FindAsync(wishListDto.ProductId);
        //    if (user == null || product == null) return NotFound("user or product not found.");
        //    var wishlist = new WishList { ProductId = wishListDto.ProductId,UserId=wishListDto.UserId};
        //    await _Context.WishList.AddAsync(wishlist);
        //    await _Context.SaveChangesAsync();
        //    return Ok(wishlist);
        //}


        //[HttpDelete("DeleteFromWishList")]
        //public async Task<IActionResult>DeleteFromWishList(int id)
        //{
        //    if (id <= 0) return BadRequest("Error in this id.");
        //    var wishlist = await _Context.WishList.FindAsync(id);
        //    if (wishlist == null) return NotFound("This wishlist is not found.");
        //    _Context.WishList.Remove(wishlist);
        //    await _Context.SaveChangesAsync();
        //    return Ok(wishlist);
        //}


        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            var Categories = await _Context.Categories.Select(e => new
            {
                e.Id,
                e.Name,
                e.Icon,
                e.Slug,
                e.Status,
                e.UpdatedAt,
                e.CreatedAt
            }).ToListAsync();
            if (Categories == null) return NotFound();
            return Ok(Categories);
        }


        [HttpGet("GetBrands")]
        public async Task<IActionResult> GetBrands()
        {
            var brands = await _Context.Brands.Select(e => new
            {
                e.Id,
                e.Logo,
                e.Name,
                e.Slug,
                e.Status,
                e.UpdatedAt,
                e.CreatedAt,
            }).ToListAsync();
            if (brands == null) return NotFound();
            return Ok(brands);
        }

        [HttpPost("AddToCart")]
        public async Task<IActionResult> AddToCart(CartItemDto cartItemDto)
        {
            if (cartItemDto == null) return BadRequest();
            var product = await _Context.Products.FindAsync(cartItemDto.ProductId);
            if (product == null) return NotFound("Not Product with this id.");
            var sessionData = HttpContext.Session.GetString(CartSessionKey);
            var cart = new List<CartItemDto>();
            if (sessionData != null) cart = JsonSerializer.Deserialize<List<CartItemDto>>(sessionData);
            cart.Add(cartItemDto);
            HttpContext.Session.SetString(CartSessionKey, JsonSerializer.Serialize(cart));
            return Ok(product);
        }
    }
}
