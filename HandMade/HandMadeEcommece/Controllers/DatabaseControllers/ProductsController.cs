using HandMadeEcommece.Models.Data;
using HandMadeEcommece.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Linq.Expressions;

namespace HandMadeEcommece.Controllers.DatabaseControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _Mapper;
        private readonly AppDbContext Context;
        private readonly IHttpContextAccessor _HttpContextAccessor;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ProductsController(AppDbContext _Context, IMapper mapper, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment)
        {
            Context = _Context;
            _Mapper = mapper;
            _HttpContextAccessor = httpContextAccessor;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductAll([FromQuery] string? Name)
        {
            var products = new List<Product>();
            if (Name != null)
            {
                 products = await Context.Products.Where(e => e.Name.Contains(Name)).ToListAsync();
                if (products.Count == 0) return NotFound("Not found product start with this name.");
            }
            else
            {
                products = await Context.Products.ToListAsync();
                if (products == null) return NotFound();
            }

                var productsWithGallery = new List<Product>();
                foreach (var product in products)
                {
                    var gallery = await Context.ProductImageGalleries.Where(e => e.ProductId == product.Id).ToListAsync();
                    var addProduct = new Product
                    {
                        Id = product.Id,
                        Name = product.Name,
                        LongDescription = product.LongDescription,
                        OfferEndDate = product.OfferEndDate,
                        OfferStartDate = product.OfferStartDate,
                        SeoDescription = product.SeoDescription,
                        ShortDescription = product.ShortDescription,
                        CategoryId = product.CategoryId,
                        CouponId = product.CouponId,
                        CreatedAt = product.CreatedAt,
                        UpdatedAt = product.UpdatedAt,
                        IsApproved = product.IsApproved,
                        Qty = product.Qty,
                        BrandId = product.BrandId,
                        OfferPrice = product.OfferPrice,
                        Price = product.Price,
                        Slug = product.Slug,
                        Sku = product.Sku,
                        SeoTitle = product.SeoTitle,
                        ProductType = product.ProductType,
                        ThumbImage = product.ThumbImage,
                        ProductImagesGallery = gallery,
                    };
                    productsWithGallery.Add(addProduct);
                }
                return Ok(productsWithGallery);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0) return BadRequest("Error in id.");
            var product = await Context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null) return NotFound("This product is not found.");
            var gallery = await Context.ProductImageGalleries.Where(e=>e.ProductId == product.Id).ToListAsync();
            product.ProductImagesGallery = gallery;
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto)// change fromForm to formbody
        {
            if (!ModelState.IsValid || productDto == null || productDto.VendorId <= 0 || productDto.CouponId < 0 || productDto.BrandId < 0 || productDto.CategoryId < 0) return BadRequest();
            var vendor = await Context.Vendors.FindAsync(productDto.VendorId);
            if (vendor == null) return BadRequest("This vendor is not found");
            if (productDto == null) return BadRequest();
            if (await Context.Coupons.FindAsync(productDto.CouponId) == null)
            {
                productDto.CouponId = null;
            }

            if (await Context.Categories.FindAsync(productDto.CategoryId) == null)
            {
               productDto.CategoryId = null;
            }

            if (await Context.Brands.FindAsync(productDto.BrandId) == null)
            {
                productDto.BrandId = null;
            }
            var httpContext = _HttpContextAccessor.HttpContext;
            var product = new Product
            {
                Name = productDto.Name,
                VendorId = vendor.Id,
                LongDescription = productDto.LongDescription,
                OfferEndDate = productDto.OfferEndDate,
                OfferStartDate = productDto.OfferStartDate,
                BrandId = productDto.BrandId,
               CategoryId = productDto.CategoryId,
                ShortDescription = productDto.ShortDescription,
                SeoDescription = productDto.SeoDescription,
                CouponId = productDto.CouponId,
                IsApproved = productDto.IsApproved,
                SeoTitle = productDto.SeoTitle,
                Sku = productDto.Sku,
                OfferPrice = productDto.OfferPrice,
                Price = productDto.Price,
                ThumbImage = productDto.ThumbImage,
                Slug = productDto.Slug,
                Qty = productDto.Qty,
                ProductType = productDto.ProductType,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };
            await Context.Products.AddAsync(product);
            await Context.SaveChangesAsync();

            var adminProduct = new AdminProduct
            {
                AdminId = 1,
                ProductId = product.Id,
            };
            await Context.AdminProducts.AddAsync(adminProduct);
            await Context.SaveChangesAsync();
            return Ok(product);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDto productDto)
        {
            if (!ModelState.IsValid || productDto == null || productDto.VendorId <= 0 || productDto.CouponId < 0 || productDto.BrandId < 0 || productDto.CategoryId < 0) return BadRequest();
            var vendor = await Context.Vendors.FindAsync(productDto.VendorId);
            if (vendor == null) return BadRequest("This vendor is not found");
            if (productDto == null) return BadRequest();
            if (await Context.Coupons.FindAsync(productDto.CouponId) == null)
            {
                productDto.CouponId = null;
            }

            if (await Context.Categories.FindAsync(productDto.CategoryId) == null)
            {
                productDto.CategoryId = null;
            }

            if (await Context.Brands.FindAsync(productDto.BrandId) == null)
            {
                productDto.BrandId = null;
            }
            var product = await Context.Products.FindAsync(id);
            if (product == null) return NotFound();
            var httpContext = _HttpContextAccessor.HttpContext;
            product.Name = productDto.Name;
            product.VendorId = productDto.VendorId;
            product.LongDescription = productDto.LongDescription;
            product.OfferEndDate = productDto.OfferEndDate;
            product.OfferStartDate = productDto.OfferStartDate;
            product.BrandId = productDto.BrandId;
            product.CategoryId = productDto.CategoryId;
            product.ShortDescription = productDto.ShortDescription;
            product.SeoDescription = productDto.SeoDescription;
            product.CouponId = productDto.CouponId;
            product.IsApproved = productDto.IsApproved;
            product.SeoTitle = productDto.SeoTitle;
            product.Sku = productDto.Sku;
            product.OfferPrice = productDto.OfferPrice;
            product.Price = productDto.Price;
            product.ThumbImage = productDto.ThumbImage;
            product.Slug = productDto.Slug;
            product.Qty = productDto.Qty;
            product.ProductType = productDto.ProductType;
            product.CreatedAt = DateTime.UtcNow;
            product.UpdatedAt = DateTime.UtcNow;
            Context.Products.Update(product);
            await Context.SaveChangesAsync();
            return Ok(product);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (id <= 0) return BadRequest();
            var product = await Context.Products.FindAsync(id);
            if (product == null) return NotFound();
            Context.Products.Remove(product);
            await Context.SaveChangesAsync();
            return Ok(product);
        }
    }
}
