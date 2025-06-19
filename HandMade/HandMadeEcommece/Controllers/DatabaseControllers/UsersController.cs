using HandMadeEcommece.Models;
using HandMadeEcommece.Models.Data;
using HandMadeEcommece.Models.Dto;
using HandMadeEcommece.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Numerics;

namespace HandMadeEcommece.Controllers.DatabaseControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IMapper _Mapper;
        private readonly AppDbContext Context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IAuth _auth;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IWebHostEnvironment webHostEnvironment;

        public UsersController(AppDbContext _Context, IMapper mapper, UserManager<AppUser> userManager, IAuth auth, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment)
        {
            Context = _Context;
            _Mapper = mapper;
            this._userManager = userManager;
            this._auth = auth;
            this.httpContextAccessor = httpContextAccessor;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var users = await Context.Users.Include(e => e.Role)
                .Select(e=>new
                {
                    Id = e.Id,
                    FName = e.FName,
                    LName = e.LName,
                    Phone = e.Phone,
                    UserName = e.UserName,
                    Image = e.Image,
                    RoleName = e.Role.Name,
                    Email = e.Email,

                })
                .ToListAsync();
            if (users.Count <= 0) return NotFound();
            return Ok(users);
        }


        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            if (id <= 0) return BadRequest();
            var user = await Context.Users.FindAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateUser(int id, UserDto userDto)
        {
            if (!ModelState.IsValid || id <= 0 || userDto == null) return BadRequest();
            var user = await Context.Users.FindAsync(id);
            if (user == null) return NotFound();
            if (user.UserName != userDto.UserName && await Context.checkUserNameAndEmails.FirstOrDefaultAsync(e=>e.UserName == userDto.UserName && e.Email == user.Email) != null) return BadRequest("The UserName Is Found");
            var httpContext = httpContextAccessor.HttpContext;
            user.UserName = userDto.UserName;
            user.Phone = userDto.Phone;
            user.Image = userDto.image;
            user.LName = userDto.LName;
            user.FName = userDto.FName;
            Context.Users.Update(user);
            await Context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPut("ChangeUserPassword")]
        public async Task<IActionResult> ChangeUserPassword([FromBody] ChangePasswordDto changePassword)
        {
            if (!ModelState.IsValid)
                return BadRequest(changePassword.Message);
            var result = await _auth.ChangePassword(changePassword);
            if (!result.IsChange)
                return BadRequest(changePassword.Message);
            return Ok(result);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (id <= 0) return BadRequest();
            var user = await Context.Users.FindAsync(id);
            if (user == null) return NotFound();
            Context.Users.Remove(user);
            await Context.SaveChangesAsync();
            return Ok(user);
        }

    }
}

