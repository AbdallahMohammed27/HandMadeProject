using HandMadeEcommece.Models.Data;
using HandMadeEcommece.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HandMadeEcommece.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace HandMadeEcommece.Controllers.DatabaseControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminCategoriesController : ControllerBase
    {
        private readonly AppDbContext Context;
        public AdminCategoriesController(AppDbContext _Context)
        {
            Context = _Context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAdminCategoriesAll()
        {
            var AdminCategories = await Context.AdminCategories.ToListAsync();
            if (AdminCategories == null) return NotFound();
            return Ok(AdminCategories);
        }


        //[HttpPost]
        //public async Task<IActionResult> CreateAdminCategories([FromBody] AdminCategoryDto AdminCategoryDto)
        //{
        //    if (!ModelState.IsValid) return BadRequest(ModelState);
        //    if (AdminCategoryDto.CategoryId <= 0 || AdminCategoryDto.AdminId <= 0) return BadRequest();
        //    var admin = await Context.Admins.FindAsync(AdminCategoryDto.AdminId);
        //    var category = await Context.Categories.FindAsync(AdminCategoryDto.CategoryId);
        //    if (admin == null || category == null) return BadRequest("This Admin Or Category is not found");
        //    bool exists = await Context.AdminCategories.AnyAsync(w => w.AdminId == AdminCategoryDto.AdminId && w.CategoryId == AdminCategoryDto.CategoryId);
        //    if (exists)
        //    {
        //        return Ok(new { Exists = true, Message = "Admin is already found in This Category" });
        //    }
        //    var AdminCategory = new AdminCategory
        //    {
        //        AdminId = AdminCategoryDto.AdminId,
        //        CategoryId = AdminCategoryDto.CategoryId
        //    };
        //    await Context.AdminCategories.AddAsync(AdminCategory);
        //    await Context.SaveChangesAsync();
        //    return Ok(AdminCategory);
        //}



        [HttpDelete]
        public async Task<IActionResult> DeleteAdminCategories([FromQuery] List<ValueTuple<int, int>> ids)
        {
            if (ids.Count <= 0) return BadRequest();
            var AdminCategories = new List<AdminCategory>();
            foreach (var id in ids)
            {
                if (id.Item1 <= 0 || id.Item2 <= 0) continue;
                var AdminCategory = await Context.AdminCategories.FindAsync(new { id.Item1, id.Item2 });
                if (AdminCategory == null) continue;
                AdminCategories.Add(AdminCategory);
                Context.AdminCategories.Remove(AdminCategory);
            }
            await Context.SaveChangesAsync();
            if (AdminCategories.Count <= 0) return NotFound();
            return Ok(AdminCategories);
        }
    }
}
