//using HandMadeEcommece.Models;
//using HandMadeEcommece.Models.Data;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace HandMadeEcommece.Controllers.DatabaseControllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class RolesController : ControllerBase
//    {
//        private readonly AppDbContext _context;
//        public RolesController(AppDbContext context)
//        {
//            _context = context;
//        }

//        [HttpPost]
//        public async Task<IActionResult> CreateRole(string Name)
//        {
//            if (Name == null) return BadRequest("Must Enter RoleName.");
//            var existRole = await _context.Roles.FirstOrDefaultAsync(x => x.Name == Name);
//            if (existRole != null) return BadRequest("This Role is already exist.");
//            var role = new Role { Name = Name };
//            await _context.Roles.AddAsync(role);
//            await _context.SaveChangesAsync();
//            return Ok(role);
//        }
//    }
//}
