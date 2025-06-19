using HandMadeEcommece.Models.Data;
using HandMadeEcommece.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe;
using System.Numerics;

namespace HandMadeEcommece.Controllers.DatabaseControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryCompaniesController : ControllerBase
    {
        private readonly AppDbContext _Context;
        private readonly IHttpContextAccessor _HttpContextAccessor;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public DeliveryCompaniesController(AppDbContext Context, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment)
        {
            _Context = Context;
            _HttpContextAccessor = httpContextAccessor;
            _WebHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> GetDeliveryCompaniesAll()
        {
            var deliveryCompanies = await _Context.DeliveryCompanies.ToListAsync();
            if (deliveryCompanies == null) return NotFound();
            return Ok(deliveryCompanies);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDeliveryCompany([FromBody] DeliveryCompanyDto deliveryCompanyDto)
        {
            if (!ModelState.IsValid || deliveryCompanyDto == null) return BadRequest();
            var httpContext = _HttpContextAccessor.HttpContext;
            var deliveryCompany = new DeliveryCompany
            {
                Delivery_Zones = deliveryCompanyDto.Delivery_Zones,
                Email = deliveryCompanyDto.Email,
                Address = deliveryCompanyDto.Address,
                IdTax = deliveryCompanyDto.IdTax,
                Logo = deliveryCompanyDto.Logo,
                Name = deliveryCompanyDto.Name,
                Pricing = deliveryCompanyDto.Pricing,
            };

            await _Context.DeliveryCompanies.AddAsync(deliveryCompany);
            await _Context.SaveChangesAsync();
            return Ok(deliveryCompany);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateDeliveryCompany(int id, DeliveryCompanyDto deliveryCompanyDto)
        {
            if (id <= 0 || deliveryCompanyDto == null) return BadRequest();

            var deliveryCompany = await _Context.DeliveryCompanies.FindAsync(id);
            if (deliveryCompany == null) return NotFound();
            var httpContext = _HttpContextAccessor.HttpContext;
         

            deliveryCompany.Pricing = deliveryCompanyDto.Pricing;
            deliveryCompany.Delivery_Zones = deliveryCompanyDto.Delivery_Zones;
            deliveryCompany.Address = deliveryCompanyDto.Address;
            deliveryCompany.Email = deliveryCompanyDto.Email;
            deliveryCompany.Name = deliveryCompanyDto.Name;
            deliveryCompany.Logo = deliveryCompanyDto.Logo;
            deliveryCompany.IdTax = deliveryCompanyDto.IdTax;
            _Context.DeliveryCompanies.Update(deliveryCompany);
            await _Context.SaveChangesAsync();
            return Ok(deliveryCompany);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteDeliveryCompany(int id)
        {
            if (id <= 0) return BadRequest();
            var deliveryCompany = await _Context.DeliveryCompanies.FindAsync(id);
            if (deliveryCompany == null) return NotFound();
            _Context.DeliveryCompanies.Remove(deliveryCompany);
            await _Context.SaveChangesAsync();
            return Ok(deliveryCompany);
        }
    }
}
