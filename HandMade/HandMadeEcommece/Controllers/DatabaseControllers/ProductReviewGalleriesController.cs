//using HandMadeEcommece.Models.Data;
//using HandMadeEcommece.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using HandMadeEcommece.Models.Dto;

//namespace HandMadeEcommece.Controllers.DatabaseControllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ProductReviewGalleriesController : ControllerBase
//    {
//        private readonly AppDbContext _context;
//        private readonly IWebHostEnvironment _webHostEnvironment;
//        private readonly IHttpContextAccessor _contextAccessor;
//        public ProductReviewGalleriesController(AppDbContext context, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor contextAccessor)
//        {
//            _context = context;
//            _webHostEnvironment = webHostEnvironment;
//            _contextAccessor = contextAccessor;
//        }


//        [HttpGet]
//        public async Task<IActionResult> GetALL()
//        {
//            var product = await _context.ProductReviewGalleries.ToListAsync();

//            if (product.IsNullOrEmpty())
//                return NotFound("Product img not found.");

            
//            return Ok(product);
//        }


        
        


//        [HttpPost]
//        public async Task<IActionResult> UploadProduct([FromBody]ProductReviewGalleryDto productReviewGalleryDto)
//        {

//            if (productReviewGalleryDto.Image == null || productReviewGalleryDto.Image.Length == 0)
//                return BadRequest("No image uploaded.");

//            if (!ModelState.IsValid || productReviewGalleryDto == null || productReviewGalleryDto.ProductReviewId <= 0) return BadRequest();
//            var productReview  = await _context.ProductReviews.FindAsync(productReviewGalleryDto.ProductReviewId);
//            if (productReview == null) return BadRequest("This productReview is not found");
//            var product = await _context.Products.FindAsync(productReview.ProductId);
//            if (product == null) return BadRequest("This product is not found");

//            var httpContext = _contextAccessor.HttpContext;

//            var productReviewGallery = new ProductReviewGallery
//            {
//                ProductReviewId = productReviewGalleryDto.ProductReviewId,
//                CreatedAt = DateTime.Now,
//                Image = productReviewGalleryDto.Image
//            };

//            await _context.ProductReviewGalleries.AddAsync(productReviewGallery);
//            await _context.SaveChangesAsync();

//            return Ok(productReviewGallery);

//        }



//        [HttpDelete]
//        public async Task<IActionResult> deleteProductimg([FromQuery] int id)
//        {
     

//            var product = await _context.ProductReviewGalleries.FindAsync(id);

//            if (product == null)
//                return NotFound("Product img not found.");



//            _context.ProductReviewGalleries.RemoveRange(product);
//            await _context.SaveChangesAsync();

//            return Ok(product);
//        }
//    }
//}
