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
    public class AdminOrdersController : ControllerBase
    {
        private readonly AppDbContext Context;
        public AdminOrdersController(AppDbContext _Context)
        {
            Context = _Context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAdminOrdersAll()
        {
            var AdminOrders = await Context.AdminOrders.ToListAsync();
            if (AdminOrders == null) return NotFound();
            return Ok(AdminOrders);
        }


        //[HttpPost]
        //public async Task<IActionResult> CreateAdminOrders([FromBody] AdminOrderDto AdminOrderDto)
        //{
        //    if (!ModelState.IsValid) return BadRequest(ModelState);
        //    if (AdminOrderDto.OrderId <= 0 || AdminOrderDto.AdminId <= 0) return BadRequest();
        //    var admin = await Context.Admins.FindAsync(AdminOrderDto.AdminId);
        //    var order = await Context.Orders.FindAsync(AdminOrderDto.OrderId);
        //    if (admin == null || order == null) return BadRequest("This Admin Or Order is not found");
        //    bool exists = await Context.AdminOrders.AnyAsync(w => w.AdminId == AdminOrderDto.AdminId && w.OrderId == AdminOrderDto.OrderId);
        //    if (exists)
        //    {
        //        return Ok(new { Exists = true, Message = "Admin is already found in This Order" });
        //    }
        //    var AdminOrder = new AdminOrder
        //    {
        //        AdminId = AdminOrderDto.AdminId,
        //        OrderId = AdminOrderDto.OrderId
        //    };
        //    await Context.AdminOrders.AddAsync(AdminOrder);
        //    await Context.SaveChangesAsync();
        //    return Ok(AdminOrder);
        //}


        [HttpDelete]
        public async Task<IActionResult> DeleteAdminOrders([FromQuery] List<ValueTuple<int, int>> ids)
        {
            if (ids.Count <= 0) return BadRequest();
            var AdminOrders = new List<AdminOrder>();
            foreach (var id in ids)
            {
                if (id.Item1 <= 0 || id.Item2 <= 0) continue;
                var AdminOrder = await Context.AdminOrders.FindAsync(new { id.Item1, id.Item2 });
                if (AdminOrder == null) continue;
                AdminOrders.Add(AdminOrder);
                Context.AdminOrders.Remove(AdminOrder);
            }
            await Context.SaveChangesAsync();
            if (AdminOrders.Count <= 0) return NotFound();
            return Ok(AdminOrders);
        }
    }
}
