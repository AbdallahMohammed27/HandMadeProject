using HandMadeEcommece.Models;
using HandMadeEcommece.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HandMadeEcommece.helper;
using Microsoft.EntityFrameworkCore;

namespace HandMadeEcommece.Controllers.DatabaseControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IMapper _Mapper;
        private readonly AppDbContext Context;
        private readonly IHttpContextAccessor _HttpContextAccessor;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public BrandsController(AppDbContext _Context, IMapper mapper, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment)
        {
            Context = _Context;
            _Mapper = mapper;
            _HttpContextAccessor = httpContextAccessor;
            _WebHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> GetBrandsAll()
        {
            var brands = await Context.Brands.ToListAsync();
            if (brands == null) return NotFound();
            return Ok(brands);
        }

        [HttpGet("GetBrand")]
        public async Task<IActionResult> GetBrand(string Name)
        {
            if (Name == null) return BadRequest();
            var brand = await Context.Brands.FirstOrDefaultAsync(e=>e.Name == Name);
            if (brand == null) return NotFound("Not brand with this Name.");
            return Ok(brand);
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts([FromQuery] string Name)
        {
            if (Name == null) return BadRequest();
            var brand = await Context.Brands.FirstOrDefaultAsync(e => e.Name == Name);
            if (brand == null) return NotFound("This brand not found.");
            var Products = await Context.Products.Where(e => e.BrandId == brand.Id)
                .Select(e => new
                {
                    e.Id,
                    e.Name,
                    e.LongDescription,
                    e.OfferEndDate,
                    e.OfferStartDate,
                    e.SeoDescription,
                    e.ShortDescription,
                    e.CategoryId,
                    e.CouponId,
                    e.CreatedAt,
                    e.UpdatedAt,
                    e.IsApproved,
                    e.Qty,
                    e.BrandId,
                    e.OfferPrice,
                    e.Price,
                    e.Slug,
                    e.Sku,
                    e.SeoTitle,
                    e.ProductType,
                    e.ThumbImage,
                })
                .ToListAsync();
            if (Products.Count == 0) return NotFound("Not products in this brand.");
            return Ok(Products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand([FromBody] BrandDto brandDto)
        {
            if (!ModelState.IsValid || brandDto == null) return BadRequest();
            if (!Enum.IsDefined(typeof(BrandStatus), brandDto.Status))
            {
                return BadRequest("Invalid brand status.");
            }
            var httpContext = _HttpContextAccessor.HttpContext;
            var brand = new Brand
            {
                Logo = brandDto.Logo,
                Name = brandDto.Name,
                Slug = brandDto.Slug,
                Status = brandDto.Status.ToString(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };
            await Context.Brands.AddAsync(brand);
            await Context.SaveChangesAsync();
            var adminbrand = new AdminBrand
            {
                AdminId = 1,
                BrandId = brand.Id,
            };
            await Context.AdminBrands.AddAsync(adminbrand);
            await Context.SaveChangesAsync();
            return Ok(brand);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateBrand(int id, BrandDto brandDto)
        {
            if (id <= 0 || brandDto == null) return BadRequest();
            if (!Enum.IsDefined(typeof(BrandStatus), brandDto.Status))
            {
                return BadRequest("Invalid brand status.");
            }
            var brand = await Context.Brands.FindAsync(id);
            if (brand == null) return NotFound();
            var httpContext = _HttpContextAccessor.HttpContext;
            brand.Name = brandDto.Name;
            brand.UpdatedAt = DateTime.UtcNow;
            brand.CreatedAt = brandDto.CreatedAt;
            brand.Status = brandDto.Status.ToString();
            brand.Logo = brandDto.Logo;
            brand.Slug = brandDto.Slug;
            Context.Brands.Update(brand);
            await Context.SaveChangesAsync();
            return Ok(brand);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            if (id <= 0) return BadRequest();
           
            var brand = await Context.Brands.FindAsync(id);
            if (brand == null) return NotFound("This brand not found.");
            Context.Brands.Remove(brand);
            await Context.SaveChangesAsync();
            return Ok(brand);
        }
    }
}
