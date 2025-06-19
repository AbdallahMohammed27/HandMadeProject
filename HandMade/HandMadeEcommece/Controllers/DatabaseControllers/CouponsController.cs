using HandMadeEcommece.Models.Data;
using HandMadeEcommece.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HandMadeEcommece.Controllers.DatabaseControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsController : ControllerBase
    {
        private readonly IMapper _Mapper;
        private readonly AppDbContext Context;
        public CouponsController(AppDbContext _Context, IMapper mapper)
        {
            Context = _Context;
            _Mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCouponsAll()
        {
            var Coupons = await Context.Coupons.ToListAsync();
            if (Coupons == null) return NotFound();
            return Ok(Coupons);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetCoupon([FromQuery] List<int> ids)
        //{
        //    if (ids == null) return BadRequest();
        //    var coupons = new List<Coupon>();
        //    foreach (var id in ids)
        //    {
        //        if (id <= 0) continue;
        //        var coupon = await Context.Coupons.FindAsync(id);
        //        if (coupon == null) continue;
        //        coupons.Add(coupon);
        //    }
        //    if (coupons.Count == 0) return BadRequest();
        //    return Ok(coupons);
        //}

        [HttpPost]
        public async Task<IActionResult> CreateCoupon([FromBody] CouponDto couponDto)
        {
            if (!ModelState.IsValid || couponDto == null) return BadRequest();

            var coupon = _Mapper.Map<Coupon>(couponDto);
            coupon.Status = 1;
            await Context.Coupons.AddAsync(coupon);
            await Context.SaveChangesAsync();
            return Ok(coupon);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCoupon(int id, CouponDto couponDto)
        {
            if (id <= 0 || couponDto == null) return BadRequest();
            var coupon = await Context.Coupons.FindAsync(id);
            if (coupon == null) return NotFound();
            coupon = _Mapper.Map(couponDto, coupon);
            coupon.Status = couponDto.Status;
            Context.Coupons.Update(coupon);
            await Context.SaveChangesAsync();
            return Ok(coupon);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCoupon([FromQuery] List<int> ids)
        {
            if (ids == null) return BadRequest();
            var Coupons = new List<Coupon>();
            foreach (var id in ids)
            {
                if (id <= 0) continue;
                var coupon = await Context.Coupons.FindAsync(id);
                if (coupon == null) continue;
                Context.Coupons.Remove(coupon);
                Coupons.Add(coupon);
            }
            await Context.SaveChangesAsync();
            if (Coupons.Count == 0) return BadRequest();
            return Ok(Coupons);
        }
    }
}
