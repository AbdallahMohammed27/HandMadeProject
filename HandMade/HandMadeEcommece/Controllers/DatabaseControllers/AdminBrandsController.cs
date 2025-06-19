using HandMadeEcommece.Models.Data;
using HandMadeEcommece.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;
using HandMadeEcommece.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace HandMadeEcommece.Controllers.DatabaseControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminBrandsController : ControllerBase
    {
 
        private readonly AppDbContext Context;
        public AdminBrandsController(AppDbContext _Context)
        {
            Context = _Context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAdminBrandsAll()
        {
            var adminBrands = await Context.AdminBrands.ToListAsync();
            if (adminBrands == null) return NotFound();
            return Ok(adminBrands);
        }


        //[HttpPost]
        //public async Task<IActionResult> CreateAdminBrands([FromBody]AdminBrandDto adminBrandDto)
        //{
        //    if(!ModelState.IsValid)return BadRequest(ModelState);
        //    if(adminBrandDto.BrandId <= 0 || adminBrandDto.AdminId <= 0)return BadRequest();
        //    var admin = await Context.Admins.FindAsync(adminBrandDto.AdminId);
        //    var brand = await Context.Brands.FindAsync(adminBrandDto.BrandId);
        //    if (admin == null || brand == null) return BadRequest("This Admin Or Brand is not found");
        //    bool exists = await Context.AdminBrands.AnyAsync(w => w.AdminId == adminBrandDto.AdminId && w.BrandId == adminBrandDto.BrandId);
        //    if (exists)
        //    {
        //        return Ok(new { Exists = true, Message = "Admin is already Found in This Brand" });
        //    }
        //    var adminBrand = new AdminBrand
        //    {
        //        AdminId = adminBrandDto.AdminId,
        //        BrandId = adminBrandDto.BrandId
        //    };
        //    await Context.AdminBrands.AddAsync(adminBrand);
        //    await Context.SaveChangesAsync();
        //    return Ok(adminBrand);
        //}


        [HttpDelete]
        public async Task<IActionResult> DeleteAdminBrands([FromQuery]List<ValueTuple<int,int>>ids)
        {
            if(ids.Count <= 0)return BadRequest();
            var adminBrands = new List<AdminBrand>();   
            foreach(var id in ids)
            {
                if (id.Item1 <= 0 || id.Item2 <= 0) continue;
                var adminBrand = await Context.AdminBrands.FindAsync(new { id.Item1, id.Item2 });
                if (adminBrand == null) continue;
                adminBrands.Add(adminBrand);
                Context.AdminBrands.Remove(adminBrand);
            }
            await Context.SaveChangesAsync();
            if (adminBrands.Count <= 0) return NotFound();
            return Ok(adminBrands);
        }
        
    }
}
