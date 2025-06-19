//global using Microsoft.IdentityModel.Tokens;
//using HandMadeEcommece.Models;
//using HandMadeEcommece.Models.Data;
//using HandMadeEcommece.Models.Dto;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace HandMadeEcommece.Controllers.DatabaseControllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ProductImageGalleriesController : ControllerBase
//    {
//        private readonly AppDbContext _context;
//        private readonly IWebHostEnvironment _webHostEnvironment;
//        private readonly IHttpContextAccessor httpContextAccessor;
//        public ProductImageGalleriesController(AppDbContext context, IWebHostEnvironment webHostEnvironment,IHttpContextAccessor httpContextAccessor)
//        {
//            _context = context;
//            _webHostEnvironment = webHostEnvironment;
//            this.httpContextAccessor = httpContextAccessor;
//        }


//        [HttpPost]
//        public async Task<IActionResult> UploadProduct([FromBody] ProductImageGalleryDto productImageGalleryDto)
//        {
//            if (productImageGalleryDto.Image == null || productImageGalleryDto.Image.Length == 0)
//                return BadRequest("No image uploaded.");
//            if (!ModelState.IsValid || productImageGalleryDto == null || productImageGalleryDto.ProductId <= 0) return BadRequest();
//            var product = await _context.Products.FindAsync(productImageGalleryDto.ProductId);
//            if (product == null) return BadRequest("This product is not found");

//            var httpContext = httpContextAccessor.HttpContext;

//            var productImageGallery = new ProductImageGallery
//            {
//                ProductId = productImageGalleryDto.ProductId,
//                CreatedAt = DateTime.Now,
//                Image = productImageGalleryDto.Image
//            };

//            await _context.ProductImageGalleries.AddAsync(productImageGallery);
//            await _context.SaveChangesAsync();

//            return Ok(productImageGallery);

//        }






//        [HttpGet]
//        public async Task<IActionResult> GetALLProduct()
//        {
//            var product = await _context.ProductImageGalleries.ToListAsync();

//            if (product.IsNullOrEmpty())
//                return NotFound("Product img not found.");

           
//            return Ok(product);
//        }


//        [HttpDelete()]
//        public async Task<IActionResult> deleteProductimg([FromQuery] int productid)
//        {

//            var product = await _context.ProductImageGalleries.Where(p => p.ProductId == productid)
//                 .ToListAsync();

//            if (product.IsNullOrEmpty())
//                return NotFound("Product img not found.");


//            _context.ProductImageGalleries.RemoveRange(product);
//            await _context.SaveChangesAsync();

//            return Ok(product);
//        }
//    }
//}
