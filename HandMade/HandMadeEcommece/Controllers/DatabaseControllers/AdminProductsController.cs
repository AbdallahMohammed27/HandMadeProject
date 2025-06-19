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
    public class AdminProductsController : ControllerBase
    {
        private readonly AppDbContext Context;
        public AdminProductsController(AppDbContext _Context)
        {
            Context = _Context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAdminProductsAll()
        {
            var AdminProducts = await Context.AdminProducts.ToListAsync();
            if (AdminProducts == null) return NotFound();
            return Ok(AdminProducts);
        }


        //[HttpPost]
        //public async Task<IActionResult> CreateAdminProducts([FromBody] AdminProductDto AdminProductDto)
        //{
        //    if (!ModelState.IsValid) return BadRequest(ModelState);
        //    if (AdminProductDto.ProductId <= 0 || AdminProductDto.AdminId <= 0) return BadRequest();
        //    var admin = await Context.Admins.FindAsync(AdminProductDto.AdminId);
        //    var product = await Context.Products.FindAsync(AdminProductDto.ProductId);
        //    if (admin == null || product == null) return BadRequest("This Admin Or Product is not found");
        //    bool exists = await Context.AdminProducts.AnyAsync(w => w.AdminId == AdminProductDto.AdminId && w.ProductId == AdminProductDto.ProductId);
        //    if (exists)
        //    {
        //        return Ok(new { Exists = true, Message = "Admin is already found in this Product" });
        //    }
        //    var AdminProduct = new AdminProduct
        //    {
        //        AdminId = AdminProductDto.AdminId,
        //        ProductId = AdminProductDto.ProductId
        //    };
        //    await Context.AdminProducts.AddAsync(AdminProduct);
        //    await Context.SaveChangesAsync();
        //    return Ok(AdminProduct);
        //}


        

        [HttpDelete]
        public async Task<IActionResult> DeleteAdminProducts([FromQuery] List<ValueTuple<int, int>> ids)
        {
            if (ids.Count <= 0) return BadRequest();
            var AdminProducts = new List<AdminProduct>();
            foreach (var id in ids)
            {
                if (id.Item1 <= 0 || id.Item2 <= 0) continue;
                var AdminProduct = await Context.AdminProducts.FindAsync(new { id.Item1, id.Item2 });
                if (AdminProduct == null) continue;
                AdminProducts.Add(AdminProduct);
                Context.AdminProducts.Remove(AdminProduct);
            }
            await Context.SaveChangesAsync();
            if (AdminProducts.Count <= 0) return NotFound();
            return Ok(AdminProducts);
        }
    }
}
