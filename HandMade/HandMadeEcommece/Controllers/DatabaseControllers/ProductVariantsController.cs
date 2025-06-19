//using HandMadeEcommece.Models.Data;
//using HandMadeEcommece.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace HandMadeEcommece.Controllers.DatabaseControllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ProductVariantsController : ControllerBase
//    {
//        private readonly AppDbContext _Context;
//        public ProductVariantsController(AppDbContext Context)
//        {
//            _Context = Context;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetProductVariantsAll()
//        {
//            var productVariants = await _Context.ProductVariants.ToListAsync();
//            if (productVariants == null) return NotFound();
//            return Ok(productVariants);
//        }

//        [HttpPost]
//        public async Task<IActionResult> CreateProductVariants([FromBody]ProductVariantDto productVariantDto)
//        {
//            if (productVariantDto == null) return BadRequest();

//            var productVariant = new ProductVariant
//            {
//                CreatedAt = DateTime.UtcNow,
//                UpdatedAt = DateTime.UtcNow,
//                Name = productVariantDto.Name,
//                ProductId = productVariantDto.ProductId,
//                Status = 1
//            };

//            await _Context.ProductVariants.AddAsync(productVariant);
//            await _Context.SaveChangesAsync();
//            return Ok(productVariant);
//        }


//        [HttpPut]
//        public async Task<IActionResult> UpdateProductVariants(int id, ProductVariant productVariantDto)
//        {
//            if (id <= 0 || productVariantDto == null) return BadRequest();
//            var productVariant = await _Context.ProductVariants.FindAsync(id);
//            if (productVariant == null) return NotFound();
//            productVariant.UpdatedAt = DateTime.UtcNow;
//            productVariant.Name = productVariantDto.Name;
//            productVariant.ProductId = productVariantDto.ProductId;
//            productVariant.Status = productVariantDto.Status;
//            productVariant.CreatedAt = productVariantDto.CreatedAt;
//            _Context.ProductVariants.Update(productVariant);
//            await _Context.SaveChangesAsync();
//            return Ok(productVariant);
//        }


//        [HttpDelete]
//        public async Task<IActionResult> DeleteProductVariants([FromQuery] List<int> ids)
//        {
//            if (ids == null || ids.Count <= 0) return BadRequest();
//            var productVariants = new List<ProductVariant>();
//            foreach (var id in ids)
//            {
//                var productVariant = await _Context.ProductVariants.FindAsync(id);
//                if (productVariant == null) continue;
//                _Context.ProductVariants.Remove(productVariant);
//            }
//            await _Context.SaveChangesAsync();
//            if (productVariants.Count == 0) return NotFound();
//            return Ok(productVariants);
//        }
//    }
//}
