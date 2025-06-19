using HandMadeEcommece.Models;
using HandMadeEcommece.Models.Data;
using HandMadeEcommece.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Microsoft.EntityFrameworkCore;
using Stripe;
using System.Runtime.InteropServices;

namespace HandMadeEcommece.Controllers.DatabaseControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        private readonly IMapper _Mapper;
        private readonly AppDbContext Context;
        private readonly IAuth _auth;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public VendorsController(AppDbContext _Context, IMapper mapper, IAuth auth, IHttpContextAccessor contextAccessor, IWebHostEnvironment webHostEnvironment)
        {
            Context = _Context;
            _Mapper = mapper;
            _auth = auth;
            _contextAccessor = contextAccessor;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> GetVendorAll()
        {
            var vendors = await Context.Vendors.ToListAsync();
            if (vendors.Count <= 0) return NotFound();
            return Ok(vendors);
        }

        [HttpGet("GetVendor")]
        public async Task<IActionResult> GetVendor([FromQuery] int id)
        {
            if (id <= 0) return BadRequest();
            var vendor = await Context.Vendors.FindAsync(id);
            if (vendor == null) return NotFound("Not found vendor in this id.");
            var orderids = await Context.OrderVendorOrders.Where(e => e.VendorId == id).Select(e=>e.OrderId).ToListAsync();
            vendor.orders = await Context.Orders.Where(e => orderids.Contains(e.Id)).ToListAsync();
            vendor.products = await Context.Products.Where(e => e.VendorId == vendor.Id).ToListAsync();
            return Ok(vendor);
        }


        [HttpPost]
        public async Task<IActionResult> AddVendor(RegisterVendor addVendorDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var checkEmail = await Context.checkUserNameAndEmails.FirstOrDefaultAsync(e => e.Email == addVendorDto.Email);
            var checkUserName = await Context.checkUserNameAndEmails.FirstOrDefaultAsync(e => e.UserName == addVendorDto.UserName);


            if (checkUserName != null)  return BadRequest("This UserName is already found");
            if (checkEmail != null) return BadRequest("This Email is already found");
            if (!await Methods.IsValidEmail(addVendorDto.Email)) return BadRequest("This Email is not valid.");
            if (!await Methods.IsValidPhone(addVendorDto.Phone)) return BadRequest("This Phone is not valid in egypt");

            var vendor = new Vendor
            {
                Email = addVendorDto.Email,
                Phone = addVendorDto.Phone,
                UserName = addVendorDto.UserName,
                FName = addVendorDto.FName,
                LName = addVendorDto.LName,
                Image = addVendorDto.Image,
                Address = addVendorDto.Address,
                RoleId = 2,
                FbLink = addVendorDto.FbLink,
                InstaLink = addVendorDto.InstaLink,
                TwLink = addVendorDto.TwLink,
                Status = 1,
                ShopName = addVendorDto.ShopName,
                Banner = addVendorDto.Image,
                Description = addVendorDto.Description,
                Password = addVendorDto.Password,
            };
            await Context.Vendors.AddAsync(vendor);
            await Context.checkUserNameAndEmails.AddAsync(new CheckUserNameAndEmail { UserName = addVendorDto.UserName, Email = addVendorDto.Email });
            await Context.SaveChangesAsync();

            var adminVendor = new AdminVendor
            {
                AdminId = 1,
                VendorId = vendor.Id
            };
            await Context.AdminVendors.AddAsync(adminVendor);
            await Context.SaveChangesAsync();
            return Ok(vendor);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateVendor(int id, VendorDto vendorDto)
        {
            if (!ModelState.IsValid || id <= 0 || vendorDto == null) return BadRequest();
            var vendor = await Context.Vendors.FindAsync(id);
            if (vendor == null) return NotFound();
            if (vendor.UserName != vendorDto.UserName && await Context.Vendors.FirstOrDefaultAsync(e=>e.UserName == vendorDto.UserName) != null) return BadRequest("The UserName Is Found");
           var httpContext = _contextAccessor.HttpContext;
            vendor.UserName = vendorDto.UserName;
            vendor.Phone = vendorDto.Phone;
            vendor.Image = vendorDto.Image;
            vendor.LName = vendorDto.LName;
            vendor.FName = vendorDto.FName;
            vendor.Description = vendorDto.Description;
            vendor.InstaLink = vendorDto.InstaLink;
            vendor.TwLink = vendorDto.TwLink;
            vendor.FbLink = vendorDto.FbLink;
            vendor.Status = vendorDto.Status;
            vendor.ShopName = vendorDto.ShopName;
            vendor.Banner = vendorDto.Banner;
            vendor.Password = vendorDto.Password;


            Context.Vendors.Update(vendor);
            await Context.SaveChangesAsync();
            return Ok(vendor);
        }

        [HttpPut("ChangeVendorPassword")]
        public async Task<IActionResult> ChangeVendorPassword([FromBody] ChangePasswordDto changePassword)
        {
            if (!ModelState.IsValid)
                return BadRequest(changePassword.Message);
            var result = await _auth.ChangePassword(changePassword);
            if (!result.IsChange)
                return BadRequest(changePassword.Message);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteVendor(int id)
        {
            if (id <= 0) return BadRequest();
            var vendor = await Context.Vendors.FindAsync(id);
            if (vendor == null) return NotFound();
            Context.Vendors.Remove(vendor);
            await Context.SaveChangesAsync();
            return Ok(vendor);
        }
    }
}
