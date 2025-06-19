using HandMadeEcommece.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HandMadeEcommece.Controllers.AuthControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterAdminsController : ControllerBase
    {
        private readonly IAuth _auth;
        private readonly IHttpContextAccessor _contextAccessor;
        public RegisterAdminsController(IAuth auth, IHttpContextAccessor contextAccessor)
        {
            _auth = auth;
            _contextAccessor = contextAccessor;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAdminAsync([FromForm] RegisterAdminDto registerAdminDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var httpContext = _contextAccessor.HttpContext;
            var admin = await _auth.RegisterAdminAsync(registerAdminDto,httpContext);
            if (!admin.IsAuthenticated)
                return BadRequest(admin.Message);
            return Ok(admin);
        }
        [HttpPost("LogIn")]
        public async Task<IActionResult> LogInAdminAsync([FromForm] LogInAdmin logInAdmin)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var admin = await _auth.LogInAdminAsync(logInAdmin);
            if (!admin.IsAuthenticated)
                return BadRequest(admin.Message);
            return Ok(admin);
        }
    }
}
