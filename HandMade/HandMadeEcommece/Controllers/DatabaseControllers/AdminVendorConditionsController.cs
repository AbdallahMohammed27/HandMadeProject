//using HandMadeEcommece.Models.Data;
//using HandMadeEcommece.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using HandMadeEcommece.Models.Dto;
//using Microsoft.EntityFrameworkCore;

//namespace HandMadeEcommece.Controllers.DatabaseControllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AdminVendorConditionsController : ControllerBase
//    {
//        private readonly AppDbContext Context;
//        public AdminVendorConditionsController(AppDbContext _Context)
//        {
//            Context = _Context;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetAdminVendorConditionsAll()
//        {
//            var AdminVendorConditions = await Context.AdminVendorConditions.ToListAsync();
//            if (AdminVendorConditions == null) return NotFound();
//            return Ok(AdminVendorConditions);
//        }


//        [HttpPost]
//        public async Task<IActionResult> CreateAdminVendorConditions([FromBody] AdminVendorConditionsDto AdminVendorConditionDto)
//        {
//            if (!ModelState.IsValid) return BadRequest(ModelState);
//            if (AdminVendorConditionDto.VendorConditionsId <= 0 || AdminVendorConditionDto.AdminId <= 0) return BadRequest();
//            var admin = await Context.Admins.FindAsync(AdminVendorConditionDto.AdminId);
//            var vendorCondition = await Context.VendorConditions.FindAsync(AdminVendorConditionDto.VendorConditionsId);
//            if (admin == null || vendorCondition == null) return BadRequest("This Admin Or VendorCondition is not found");
//            bool exists = await Context.AdminVendorConditions.AnyAsync(w => w.AdminId == AdminVendorConditionDto.AdminId && w.VendorConditionsId == AdminVendorConditionDto.VendorConditionsId);
//            if (exists)
//            {
//                return Ok(new { Exists = true, Message = "Admin is already found in this VendorConditions." });
//            }
//            var AdminVendorCondition = new AdminVendorConditions
//            {
//                AdminId = AdminVendorConditionDto.AdminId,
//                VendorConditionsId = AdminVendorConditionDto.VendorConditionsId
//            };
//            await Context.AdminVendorConditions.AddAsync(AdminVendorCondition);
//            await Context.SaveChangesAsync();
//            return Ok(AdminVendorCondition);
//        }




//        [HttpDelete]
//        public async Task<IActionResult> DeleteAdminVendorConditions([FromQuery] List<ValueTuple<int, int>> ids)
//        {
//            if (ids.Count <= 0) return BadRequest();
//            var AdminVendorConditions = new List<AdminVendorConditions>();
//            foreach (var id in ids)
//            {
//                if (id.Item1 <= 0 || id.Item2 <= 0) continue;
//                var AdminVendorCondition = await Context.AdminVendorConditions.FindAsync(new { id.Item1, id.Item2 });
//                if (AdminVendorCondition == null) continue;
//                AdminVendorConditions.Add(AdminVendorCondition);
//                Context.AdminVendorConditions.Remove(AdminVendorCondition);
//            }
//            await Context.SaveChangesAsync();
//            if (AdminVendorConditions.Count <= 0) return NotFound();
//            return Ok(AdminVendorConditions);
//        }
//    }
//}
