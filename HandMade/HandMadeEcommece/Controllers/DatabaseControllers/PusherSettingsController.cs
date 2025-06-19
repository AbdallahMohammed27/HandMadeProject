//using HandMadeEcommece.Models;
//using HandMadeEcommece.Models.Data;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace HandMadeEcommece.Controllers.DatabaseControllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PusherSettingsController : ControllerBase
//    {
//        private readonly IMapper _Mapper;
//        private readonly AppDbContext Context;
//        public PusherSettingsController(AppDbContext _Context, IMapper mapper)
//        {
//            Context = _Context;
//            _Mapper = mapper;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetPusherSettingsAll()
//        {
//            var pusherSettings = await Context.PusherSettings.ToListAsync();
//            if (pusherSettings == null) return NotFound();
//            return Ok(pusherSettings);
//        }

//        //[HttpGet]
//        //public async Task<IActionResult> GetPusherSettings([FromQuery] List<int> ids)
//        //{
//        //    if (ids == null) return BadRequest();
//        //    var pusherSettings = new List<PusherSetting>();
//        //    foreach (var id in ids)
//        //    {
//        //        if (id <= 0) continue;
//        //        var pusherSetting = await Context.PusherSettings.FindAsync(id);
//        //        if (pusherSetting == null) continue;
//        //        pusherSettings.Add(pusherSetting);
//        //    }
//        //    if (pusherSettings.Count == 0) return BadRequest();
//        //    return Ok(pusherSettings);
//        //}

//        [HttpPost]
//        public async Task<IActionResult> CreatePusherSettings([FromForm] PusherSettingDto pusherSettingDto)
//        {
//            if (!ModelState.IsValid || pusherSettingDto == null) return BadRequest();
//            var pusherSetting = new PusherSetting
//            {
//                PusherAppId = pusherSettingDto.PusherAppId,
//                PusherKey = pusherSettingDto.PusherKey,
//                PusherSecret = pusherSettingDto.PusherSecret,
//                PusherCluster = pusherSettingDto.PusherCluster,
//                CreatedAt = DateTime.UtcNow,
//                UpdatedAt = DateTime.UtcNow,
//            };
//            await Context.PusherSettings.AddAsync(pusherSetting);
//            await Context.SaveChangesAsync();
//            return Ok(pusherSetting);
//        }


//        [HttpPut]
//        public async Task<IActionResult> UpdatePusherSettings(int id, PusherSettingDto pusherSettingDto)
//        {
//            if (id <= 0 || pusherSettingDto == null) return BadRequest();
//            var pusherSetting = await Context.PusherSettings.FindAsync(id);
//            if (pusherSetting == null) return NotFound();
//            pusherSetting.UpdatedAt = DateTime.UtcNow;
//            pusherSetting.CreatedAt = pusherSettingDto.CreatedAt;
//            Context.PusherSettings.Update(pusherSetting);
//            await Context.SaveChangesAsync();
//            return Ok(pusherSetting);
//        }

//        [HttpDelete]
//        public async Task<IActionResult> DeletePusherSettings([FromQuery] List<int> ids)
//        {
//            if (ids == null) return BadRequest();
//            var pusherSettings = new List<PusherSetting>();
//            foreach (var id in ids)
//            {
//                if (id <= 0) continue;
//                var pusherSetting = await Context.PusherSettings.FindAsync(id);
//                if (pusherSetting == null) continue;
//                Context.PusherSettings.Remove(pusherSetting);
//                pusherSettings.Add(pusherSetting);
//            }
//            await Context.SaveChangesAsync();
//            if (pusherSettings.Count == 0) return BadRequest();
//            return Ok(pusherSettings);
//        }
//    }
//}
