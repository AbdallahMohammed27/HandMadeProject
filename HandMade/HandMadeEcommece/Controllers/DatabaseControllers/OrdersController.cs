using HandMadeEcommece.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Dynamic.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HandMadeEcommece.Models.Dto;
using System.Linq.Expressions;
using HandMadeEcommece.Models.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using HandMadeEcommece.Services;
using Stripe;

namespace HandMadeEcommece.Controllers.ModelsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _Context;
        private readonly IAuth _auth;
        public OrdersController(AppDbContext Context, IAuth auth)
        {
            _Context = Context;
            _auth = auth;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrdersAll()
        {
            var orders = await _Context.Orders.ToListAsync();
            if (orders == null) return NotFound();
            return Ok(orders);
        }

        [HttpGet("GetOrder")]
        public async Task<IActionResult> GetOrder([FromQuery] int id)
        {
            if (id <= 0) return BadRequest();
            var order = await _Context.Orders.FirstOrDefaultAsync(o => o.Id == id);
            if (order == null) return NotFound("Not order with this id.");
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderDto orderDto)
        {
            if (!ModelState.IsValid || orderDto == null) return BadRequest();
            bool ok = false;
            var user = new User();
            if (orderDto.UserId > 0)
            {
                // if (orderDto.UserId <= 0) return BadRequest();
                user = await _Context.Users.FindAsync(orderDto.UserId);
                if (user == null) return NotFound("No user in this id.");
                ok = true;
            }
            else orderDto.UserId = null;
            var userName = (orderDto.UserId != null) ? (await _Context.Users.FindAsync(orderDto.UserId)).UserName : "Unkonwn";
            var order = new Order();
            order = await _auth.ProcessOfOrder(order, orderDto);
            if (ok) order.UserName = user.UserName;
            await _Context.Orders.AddAsync(order);
            await _Context.SaveChangesAsync();
            var adminOrder = new AdminOrder
            {
                AdminId = 1,
                OrderId = order.Id
            };
            await _Context.AdminOrders.AddAsync(adminOrder);
            await _Context.SaveChangesAsync();
            return Ok(new
            {
                userName,
                order = order
            });
        }








        [HttpPost("Payment")]
        public async Task<IActionResult> CreatePaymentIntent([FromBody] PaymentDto paymentDto)
        {
            try
            {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = paymentDto.Amount,
                    Currency = "usd",
                    AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
                    {
                        Enabled = true
                    }
                };

                var service = new PaymentIntentService();
                var paymentIntent = service.Create(options);

                return Ok(new { clientSecret = paymentIntent.ClientSecret });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }





        [HttpPut]
        public async Task<IActionResult> UpdateOrder(int id, string OrderStatus)
        {
            if (id <= 0) return BadRequest();
            var order = await _Context.Orders.FindAsync(id);
            if (order == null) return NotFound();
            //order = await _auth.ProcessOfOrder(order, orderDto);
            order.OrderStatus = OrderStatus;
            _Context.Orders.Update(order);
            await _Context.SaveChangesAsync();
            return Ok(order);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (id <= 0) return BadRequest();
            var order = await _Context.Orders.FindAsync(id);
            if (order == null) return NotFound();
            _Context.Orders.Remove(order);
            await _Context.SaveChangesAsync();
            return Ok(order);
        }

    }
}
