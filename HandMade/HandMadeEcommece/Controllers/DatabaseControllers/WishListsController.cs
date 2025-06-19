using HandMadeEcommece.Models.Data;
using HandMadeEcommece.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace HandMadeEcommece.Controllers.DatabaseControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WishListsController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllListOfUser([FromQuery] int id)
        {
            if (id <= 0) return BadRequest();
            var wishlist = await _context.WishList.Include(e=>e.Product).Where(w => w.UserId == id).Select(e => new
            {
                e.UserId,
                e.ProductId,
                e.Product.Name,
                e.Product.Qty,
                e.Product.Price,
                e.Product.OfferPrice,
                e.Product.OfferStartDate,
                e.Product.OfferEndDate,
                e.Product.BrandId,
                e.Product.CategoryId,
                e.Product.CouponId,
                e.Product.CreatedAt,
                e.Product.UpdatedAt,
                e.Product.IsApproved,
                e.Product.LongDescription,
                e.Product.ShortDescription,
                e.Product.SeoDescription,
                e.Product.ThumbImage,
                e.Product.ProductType,
            }).ToListAsync();
            if (wishlist == null || !wishlist.Any())
                return NotFound($"No wishlist found for User ID: {id}");

            return Ok(wishlist);
        }



        [HttpPost]
        public async Task<IActionResult> AddWishList([FromBody] WishListDto wishListDto)
        {
            if (!ModelState.IsValid || wishListDto == null || wishListDto.ProductId <= 0 || wishListDto.UserId <= 0) return BadRequest();
            bool userExists = await _context.Users.AnyAsync(w => w.Id == wishListDto.UserId);
            if (userExists)
            {
                bool exists = await _context.WishList.AnyAsync(w => w.UserId == wishListDto.UserId && w.ProductId == wishListDto.UserId);
                if (exists)
                {
                    return Ok(new { Exists = true, Message = "Product is already in the wishlist." });
                }
                var product = await _context.Products.FirstOrDefaultAsync(e=>e.Id == wishListDto.ProductId);
                var newWishItem = new WishList();
                newWishItem.ProductId = wishListDto.ProductId;
                newWishItem.UserId = wishListDto.UserId;
                newWishItem.Product = product;

                await _context.WishList.AddAsync(newWishItem);
                await _context.SaveChangesAsync();
                return Ok(newWishItem);

            }
            return BadRequest();
        }




        [HttpDelete]
        public async Task<IActionResult> deleteItem([FromQuery]WishListDto wishListDto)
        {
            var items = await _context.WishList.Where(w => w.UserId == wishListDto.UserId && w.ProductId == wishListDto.ProductId).ToListAsync();
            if (items.IsNullOrEmpty())
                return NotFound("no item found ");


            _context.WishList.RemoveRange(items);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "item deleted successfully" });


        }
    }
}
