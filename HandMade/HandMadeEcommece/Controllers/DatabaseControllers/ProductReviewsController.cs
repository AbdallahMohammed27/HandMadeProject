using HandMadeEcommece.Models.Data;
using HandMadeEcommece.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace HandMadeEcommece.Controllers.DatabaseControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductReviewsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductReviewsController(AppDbContext context)
        {
            _context = context;
        }

       

        [HttpGet("GetAllRevProduct")]
        public async Task<IActionResult> GetAllRevProduct(int id)
        {
            if (id <= 0) return BadRequest();
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound("No product with this id.");
            var reviews = await _context.ProductReviews.Where(e => e.ProductId == id).Select(e => new
            {
                e.Id,
                e.Product,
                e.CreatedAt,
                e.UpdatedAt,
                e.Rating,
                e.Review,
                e.Status,
                userId=e.User.Id,
                e.User.UserName,
                e.User.Email,
                e.User.Image,

            }).ToListAsync();
            return Ok(reviews);
        }

        

        [HttpPost]
        public async Task<IActionResult> AddproductRev([FromBody]ProductReviewDto dto)

        {

            if (dto != null)
            {
                if (dto.ProductId <= 0 || dto.UserId <= 0||await _context.Users.FindAsync(dto.UserId) == null || await _context.Products.FindAsync(dto.ProductId) == null) return BadRequest("Error in ProductId Or UserId.");
                var newrev = new ProductReview
                {
                    ProductId = dto.ProductId,
                    UserId = dto.UserId,
                    Review = dto.Review,
                    Rating = dto.Rating,
                    Status = 1,
                    CreatedAt = DateTime.UtcNow,
                };

                await _context.ProductReviews.AddAsync(newrev);
                await _context.SaveChangesAsync();

                return Ok(newrev);
            }

           return BadRequest();

        }


        [HttpPut]
        public async Task<IActionResult>UpdateProductReview(int id,  [FromBody]ProductReviewDto dto)
        {
            if (id <= 0|| dto.ProductId <= 0 || dto.UserId <= 0 || await _context.Users.FindAsync(dto.UserId) == null || await _context.Products.FindAsync(dto.ProductId) == null) return BadRequest("Error in ProductId Or UserId.");
            var productReview = await _context.ProductReviews.FindAsync(id);
            if (productReview == null) return NotFound("This productReview is not found.");
            productReview.ProductId = dto.ProductId;
            productReview.UserId = dto.UserId;
            productReview.Review = dto.Review;
            productReview.Status = dto.Status;
            productReview.UpdatedAt = DateTime.UtcNow;
            productReview.Rating = dto.Rating;
             _context.ProductReviews.Update(productReview);
            await _context.SaveChangesAsync();
            return Ok(productReview);
        }


        [HttpDelete]
        public async Task<IActionResult> deletRev([FromQuery] int id)
        {
            var rev = await _context.ProductReviews.FindAsync(id);
            if (rev == null)
                return NotFound("rev not found");

            _context.ProductReviews.Remove(rev);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "reiew deleted successfully", Deleteditem = rev });
        }
    }
}
