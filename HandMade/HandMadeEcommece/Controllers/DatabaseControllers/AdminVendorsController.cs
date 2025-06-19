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
    public class AdminVendorsController : ControllerBase
    {
        private readonly AppDbContext Context;
        public AdminVendorsController(AppDbContext _Context)
        {
            Context = _Context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAdminVendorsAll()
        {
            var AdminVendors = await Context.AdminVendors.ToListAsync();
            if (AdminVendors == null) return NotFound();
            return Ok(AdminVendors);
        }


        //[HttpPost]
        //public async Task<IActionResult> CreateAdminVendors([FromBody] AdminVendorDto AdminVendorDto)
        //{
        //    if (!ModelState.IsValid) return BadRequest(ModelState);
        //    if (AdminVendorDto.VendorId <= 0 || AdminVendorDto.AdminId <= 0) return BadRequest();
        //    var admin = await Context.Admins.FindAsync(AdminVendorDto.AdminId);
        //    var Vendor = await Context.Vendors.FindAsync(AdminVendorDto.VendorId);
        //    if (admin == null || Vendor == null) return BadRequest("This Admin Or Vendor is not found");
        //    bool exists = await Context.AdminVendors.AnyAsync(w => w.AdminId == AdminVendorDto.AdminId && w.VendorId == AdminVendorDto.VendorId);
        //    if (exists)
        //    {
        //        return Ok(new { Exists = true, Message = "Admin is already found in this Vendor" });
        //    }
        //    var AdminVendor = new AdminVendor
        //    {
        //        AdminId = AdminVendorDto.AdminId,
        //        VendorId = AdminVendorDto.VendorId
        //    };
        //    await Context.AdminVendors.AddAsync(AdminVendor);
        //    await Context.SaveChangesAsync();
        //    return Ok(AdminVendor);
        //}




        [HttpDelete]
        public async Task<IActionResult> DeleteAdminVendors([FromQuery] List<ValueTuple<int, int>> ids)
        {
            if (ids.Count <= 0) return BadRequest();
            var AdminVendors = new List<AdminVendor>();
            foreach (var id in ids)
            {
                if (id.Item1 <= 0 || id.Item2 <= 0) continue;
                var AdminVendor = await Context.AdminVendors.FindAsync(new { id.Item1, id.Item2 });
                if (AdminVendor == null) continue;
                AdminVendors.Add(AdminVendor);
                Context.AdminVendors.Remove(AdminVendor);
            }
            await Context.SaveChangesAsync();
            if (AdminVendors.Count <= 0) return NotFound();
            return Ok(AdminVendors);
        }
    }
}
