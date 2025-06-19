using HandMadeEcommece.Models.Data;
using HandMadeEcommece.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HandMadeEcommece.Controllers.DatabaseControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCouponsController : ControllerBase
    {
        private readonly IMapper _Mapper;
        private readonly AppDbContext Context;
        public UserCouponsController(AppDbContext _Context, IMapper mapper)
        {
            Context = _Context;
            _Mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserCouponsAll()
        {
            var userCoupons = await Context.UserCoupons.ToListAsync();
            if (userCoupons == null) return NotFound();
            return Ok(userCoupons);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetUserCoupon([FromQuery] List<ValueTuple<int, int>> ids)
        //{
        //    if (ids == null) return BadRequest();
        //    var userCoupons = new List<UserCoupons>();
        //    foreach (var id in ids)
        //    {
        //        if (id.Item1 <= 0 || id.Item2 <= 0) continue;
        //        var coupon = await Context.Coupons.FindAsync(id.Item2);
        //        var user = await Context.Users.FindAsync(id.Item1);
        //        if (coupon == null || user == null) return BadRequest("Coupon Or User Is Null");
        //        var userCoupon = await Context.UserCoupons.FindAsync(new { id.Item1, id.Item2 });
        //        if (userCoupon == null) continue;
        //        userCoupons.Add(userCoupon);
        //    }
        //    if (userCoupons.Count == 0) return BadRequest();
        //    return Ok(userCoupons);
        //}

        [HttpPost]
        public async Task<IActionResult> CreateUserCoupon([FromForm] UserCouponsDto userCouponDto)
        {
            if (!ModelState.IsValid||userCouponDto == null) return BadRequest();
            var user = await Context.Users.FindAsync(userCouponDto.UserId);
            if (user == null) return BadRequest("User is Not Found");

            var coupon = await Context.Coupons.FindAsync(userCouponDto.CouponId);
            var time = DateTime.UtcNow;
            if (coupon == null || coupon.Status == 0 || time >= coupon.EndDate || coupon.Quantity <= 0)
            {
                return BadRequest("Coupon is Expired, Unavailable");
            }
            var userCouponCount = await Context.UserCoupons.CountAsync(uc => uc.UserId == userCouponDto.UserId && uc.CouponId == userCouponDto.CouponId);
            if (userCouponCount >= coupon.MaxUse)
            {
                return BadRequest("User has exceeded max usage");
            }
            coupon.Quantity--;
            coupon.TotalUsed++;
            var userCoupon = new UserCoupons { UserId = userCouponDto.UserId, CouponId = userCouponDto.CouponId};
            await Context.UserCoupons.AddAsync(userCoupon);
            await Context.SaveChangesAsync();
            return Ok(coupon);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteUserCoupon([FromQuery] List<ValueTuple<int, int>> ids)
        {
            if (ids == null) return BadRequest();
            var UserCoupons = new List<UserCoupons>();
            foreach (var id in ids)
            {
                if (id.Item1 <= 0 || id.Item2 <= 0) continue;
                //var coupon = await Context.Coupons.FindAsync(id.Item1);
                //var user = await Context.Users.FindAsync(id.Item2);
                //if (coupon == null || user == null) continue;
                var userCoupon = await Context.UserCoupons.FindAsync(new { id.Item1, id.Item2 });
                if (userCoupon == null) continue;
                Context.UserCoupons.Remove(userCoupon);
                UserCoupons.Add(userCoupon);
            }
            await Context.SaveChangesAsync();
            if (UserCoupons.Count == 0) return BadRequest("Result Is Null");
            return Ok(UserCoupons);
        }
    }
}
