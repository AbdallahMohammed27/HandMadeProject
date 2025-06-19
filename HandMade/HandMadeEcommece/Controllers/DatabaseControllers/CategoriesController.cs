using HandMadeEcommece.Models;
using HandMadeEcommece.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HandMadeEcommece.Controllers.DatabaseControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper _Mapper;
        private readonly AppDbContext Context;
        private readonly IHttpContextAccessor _HttpContextAccessor;
        private readonly IWebHostEnvironment webHostEnvironment;
        public CategoriesController(AppDbContext _Context, IMapper mapper, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment)
        {
            Context = _Context;
            _Mapper = mapper;
            _HttpContextAccessor = httpContextAccessor;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoriesAll()
        {
         
            var Categories = await Context.Categories.ToListAsync();
            if (Categories == null) return NotFound();
            return Ok(Categories);
        }

        [HttpGet("GetCategory")]
        public async Task<IActionResult>GetCategory(string Name)
        {
            if (Name == null) return BadRequest();
            var category = await Context.Categories.FirstOrDefaultAsync(e=>e.Name == Name);
            if (category == null) return NotFound("Not category with this Name.");
            return Ok(category);
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts([FromQuery] string Name)
        {
            if(Name == null) return BadRequest();
            var category = await Context.Categories.FirstOrDefaultAsync(e=>e.Name == Name);
            if(category == null) return NotFound("This category not found.");
            var Products = await Context.Products.Where(e=>e.CategoryId == category.Id)
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
            if (Products.Count == 0) return NotFound("Not products in this category.");
            return Ok(Products);
        }
        

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDto categoryDto)
        {
            if (categoryDto == null) return BadRequest();
            var httpContext = _HttpContextAccessor.HttpContext;
            var category = new Category
            {
                Icon = categoryDto.Icon,
                Name = categoryDto.Name,
                Slug = categoryDto.Slug,
                Status = 1,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };
            await Context.Categories.AddAsync(category);
            await Context.SaveChangesAsync();
            var admincategory = new AdminCategory
            {
                AdminId = 1,
                CategoryId = category.Id,
            };
            await Context.AdminCategories.AddAsync(admincategory);
            await Context.SaveChangesAsync();
            return Ok(category);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCategory(int id, CategoryDto categoryDto)
        {
            if (id <= 0 || categoryDto == null) return BadRequest();
            var category = await Context.Categories.FindAsync(id);
            if (category == null) return NotFound();
            var httpContext = _HttpContextAccessor.HttpContext;
            category.Name = categoryDto.Name;
            category.UpdatedAt = DateTime.UtcNow;
            category.CreatedAt = categoryDto.CreatedAt;
            category.Status = categoryDto.Status;
            category.Icon = categoryDto.Icon;
            Context.Categories.Update(category);
            await Context.SaveChangesAsync();
            return Ok(category);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (id <= 0) return BadRequest();
            var category = await Context.Categories.FindAsync(id);
            if (category == null) return NotFound();
            Context.Categories.Remove(category);
            await Context.SaveChangesAsync();
            return Ok(category);
        }
    }
}
