//global using Microsoft.EntityFrameworkCore;
//using HandMadeEcommece.Models.Data;
//using HandMadeEcommece.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace HandMadeEcommece.Controllers.DatabaseControllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ProductVariantItemsController : ControllerBase
//    {
//        private readonly AppDbContext _Context;
//        public ProductVariantItemsController(AppDbContext Context)
//        {
//            _Context = Context;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetProductVariantItemsAll()
//        {
//            var productVariantItems = await _Context.ProductVariantItems.ToListAsync();
//            if (productVariantItems == null) return NotFound();
//            return Ok(productVariantItems);
//        }

//        [HttpPost]
//        public async Task<IActionResult> CreateProductVariantItems([FromBody] ProductVariantItemDto productVariantItemDto)
//        {
//            if (!ModelState.IsValid || productVariantItemDto == null) return BadRequest();

//            var productVariantItem = new ProductVariantItem
//            {
//                ProductVariantId = productVariantItemDto.ProductVariantId,
//                IsDefault = productVariantItemDto.IsDefault,
//                Status = 1,
//                CreatedAt = DateTime.UtcNow,
//                UpdatedAt = DateTime.UtcNow,
//                Name = productVariantItemDto.Name,
//                Price = productVariantItemDto.Price
//            };

//            await _Context.ProductVariantItems.AddAsync(productVariantItem);
//            await _Context.SaveChangesAsync();
//            return Ok(productVariantItem);
//        }


//        [HttpPut]
//        public async Task<IActionResult> UpdateProductVariantItems(int id, ProductVariantItemDto productVariantItemDto)
//        {
//            if (id <= 0 || productVariantItemDto == null) return BadRequest();
//            var productVariantItem = await _Context.ProductVariantItems.FindAsync(id);
//            if (productVariantItem == null) return NotFound();
//            productVariantItem.UpdatedAt = DateTime.UtcNow;
//            productVariantItem.Name = productVariantItemDto.Name;
//            productVariantItem.ProductVariantId = productVariantItemDto.ProductVariantId;
//            productVariantItem.Status = productVariantItemDto.Status;
//            productVariantItem.CreatedAt = productVariantItemDto.CreatedAt;
//            productVariantItem.Price = productVariantItemDto.Price;
//            productVariantItemDto.IsDefault = productVariantItemDto.IsDefault;
//            _Context.ProductVariantItems.Update(productVariantItem);
//            await _Context.SaveChangesAsync();
//            return Ok(productVariantItem);
//        }


//        [HttpDelete]
//        public async Task<IActionResult> DeleteProductVariantItems([FromQuery] List<int> ids)
//        {
//            if (ids == null || ids.Count <= 0) return BadRequest();
//            var productVariantItems = new List<ProductVariantItem>();
//            foreach (var id in ids)
//            {
//                var productVariantItem = await _Context.ProductVariantItems.FindAsync(id);
//                if (productVariantItem == null) continue;
//                _Context.ProductVariantItems.Remove(productVariantItem);
//            }
//            await _Context.SaveChangesAsync();
//            if (productVariantItems.Count == 0) return NotFound();
//            return Ok(productVariantItems);
//        }
//    }
//}
