//using HandMadeEcommece.Models.Data;
//using HandMadeEcommece.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace HandMadeEcommece.Controllers.DatabaseControllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class VendorConditionsController : ControllerBase
//    {
//        private readonly IMapper _Mapper;
//        private readonly AppDbContext Context;
//        public VendorConditionsController(AppDbContext _Context, IMapper mapper)
//        {
//            Context = _Context;
//            _Mapper = mapper;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetVendorConditionAll()
//        {
//            var vendorConition = await Context.VendorConditions.ToListAsync();
//            if (vendorConition == null) return NotFound();
//            return Ok(vendorConition);
//        }

//        //[HttpGet]
//        //public async Task<IActionResult> GetVendorCondition([FromQuery] List<int> ids)
//        //{
//        //    if (ids == null) return BadRequest();
//        //    var vendorConditions = new List<VendorCondition>();
//        //    foreach (var id in ids)
//        //    {
//        //        if (id <= 0) continue;
//        //        var vendorCondition = await Context.VendorConditions.FindAsync(id);
//        //        if (vendorCondition == null) continue;
//        //        vendorConditions.Add(vendorCondition);
//        //    }
//        //    if (vendorConditions.Count == 0) return BadRequest();
//        //    return Ok(vendorConditions);
//        //}

//        [HttpPost]
//        public async Task<IActionResult> CreateVendorCondition([FromForm] VendorConditionDto vendorConditionDto)
//        {
//            if (!ModelState.IsValid||vendorConditionDto== null) return BadRequest();
//            var vendorCondition = new VendorCondition
//            {
//                Content = vendorConditionDto.Content,
//                CreatedAt = DateTime.UtcNow,
//                UpdatedAt = DateTime.UtcNow,
//            };
//            await Context.VendorConditions.AddAsync(vendorCondition);
//            await Context.SaveChangesAsync();
//            return Ok(vendorCondition);
//        }


//        [HttpPut]
//        public async Task<IActionResult> UpdateVendorCondition(int id, VendorConditionDto vendorConditionDto)
//        {
//            if (id <= 0 || vendorConditionDto == null) return BadRequest();
//            var vendorCondition = await Context.VendorConditions.FindAsync(id);
//            if (vendorCondition == null) return NotFound();
//            vendorCondition.UpdatedAt = DateTime.UtcNow;
//            vendorCondition.CreatedAt = vendorConditionDto.CreatedAt;
//            Context.VendorConditions.Update(vendorCondition);
//            await Context.SaveChangesAsync();
//            return Ok(vendorCondition);
//        }

//        [HttpDelete]
//        public async Task<IActionResult> DeleteVendorCondition([FromQuery] List<int> ids)
//        {
//            if (ids == null) return BadRequest();
//            var vendorConditions = new List<VendorCondition>();
//            foreach (var id in ids)
//            {
//                if (id <= 0) continue;
//                var vendorCondition = await Context.VendorConditions.FindAsync(id);
//                if (vendorCondition == null) continue;
//                Context.VendorConditions.Remove(vendorCondition);
//                vendorConditions.Add(vendorCondition);
//            }
//            await Context.SaveChangesAsync();
//            if (vendorConditions.Count == 0) return BadRequest();
//            return Ok(vendorConditions);
//        }
//    }
//}
