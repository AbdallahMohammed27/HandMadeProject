//using HandMadeEcommece.Models.Data;
//using HandMadeEcommece.Models.Dto;
//using HandMadeEcommece.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;

//namespace HandMadeEcommece.Controllers.DatabaseControllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class TransactionsController : ControllerBase
//    {
//        private readonly AppDbContext _context;

//        public TransactionsController(AppDbContext context)
//        {
//            _context = context;
//        }

//        [HttpGet]
//        public async Task<IActionResult> getallTransactions()
//        {
//            var transaction = await _context.Transactions.ToListAsync();
//            if (!transaction.IsNullOrEmpty())
//                return Ok(transaction);
//            return NotFound($"No transaction is found :");

//        }

       


//        [HttpPost]
//        public async Task<IActionResult> newtransaction([FromBody] TransactionDto dto)
//        {
//            if (!ModelState.IsValid || dto == null) return BadRequest();
//            if (dto.CompanyDeliveryId <= 0 || dto.UserId <= 0 || dto.OrderId <= 0 || await _context.DeliveryCompanies.FindAsync(dto.CompanyDeliveryId) == null || await _context.Users.FindAsync(dto.UserId) == null || await _context.Orders.FindAsync(dto.OrderId) == null) return BadRequest("Error in OrderId Or UserId Or DeliveryCompainyId.");
//            var newtransaction = new TransactionMoney
//            {
//                OrderId = dto.OrderId,
//                UserId = dto.UserId,
//                CompanyDeliveryId = dto.CompanyDeliveryId,
//                PaymentMethod = dto.PaymentMethod,
//                AmountRealCurrency = dto.AmountRealCurrency,
//                Amount = dto.Amount,
//                AmountRealCurrencyName = dto.AmountRealCurrencyName,
//                CreatedAt = DateTime.Now,
//            };

//            await _context.Transactions.AddAsync(newtransaction);
//            await _context.SaveChangesAsync();

//            return Ok(newtransaction);
//        }


//        [HttpPut]
//        public async Task<IActionResult> UpdateTransaction(int Id,[FromBody] TransactionDto dto)
//        {
//            if (!ModelState.IsValid || dto == null) return BadRequest();
//            if (dto.CompanyDeliveryId <= 0 || dto.UserId <= 0 || dto.OrderId <= 0 || await _context.DeliveryCompanies.FindAsync(dto.CompanyDeliveryId) == null || await _context.Users.FindAsync(dto.UserId) == null || await _context.Orders.FindAsync(dto.OrderId) == null) return BadRequest("Error in OrderId Or UserId Or DeliveryCompainyId.");
//            var transaction = await _context.Transactions.FindAsync(Id);
//            if (transaction == null) return NotFound("This Transaction is not found.");

//            transaction.OrderId = dto.OrderId;
//            transaction.UserId = dto.UserId;
//            transaction.CompanyDeliveryId = dto.CompanyDeliveryId;
//            transaction.PaymentMethod = dto.PaymentMethod;
//            transaction.AmountRealCurrency = dto.AmountRealCurrency;
//            transaction.Amount = dto.Amount;
//            transaction.AmountRealCurrencyName = dto.AmountRealCurrencyName;
//            transaction.UpdatedAt = DateTime.Now;
   

//             _context.Transactions.Update(transaction);
//            await _context.SaveChangesAsync();

//            return Ok(transaction);
//        }




//        [HttpDelete]
//        public async Task<IActionResult> deletetransaction([FromQuery] int id)
//        {

//            var transaction = await _context.Transactions
//                                    .FirstOrDefaultAsync(t => t.Id == id);

//            if (transaction == null)

//                return NotFound(new { message = "Transaction not found." });



//            _context.Transactions.Remove(transaction);
//            await _context.SaveChangesAsync();

//            return Ok(new { message = "Transaction deleted successfully." });
//        }
//    }
//}
