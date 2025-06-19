//using HandMadeEcommece.Models.Data;
//using HandMadeEcommece.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using HandMadeEcommece.Models.Dto;
//using Microsoft.EntityFrameworkCore;

//namespace HandMadeEcommece.Controllers.DatabaseControllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AdminTransactionsController : ControllerBase
//    {
//        private readonly AppDbContext Context;
//        public AdminTransactionsController(AppDbContext _Context)
//        {
//            Context = _Context;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetAdminTransactionsAll()
//        {
//            var AdminTransactions = await Context.AdminTransactions.ToListAsync();
//            if (AdminTransactions == null) return NotFound();
//            return Ok(AdminTransactions);
//        }


//        [HttpPost]
//        public async Task<IActionResult> CreateAdminTransactions([FromBody] AdminTransactionDto AdminTransactionDto)
//        {
//            if (!ModelState.IsValid) return BadRequest(ModelState);
//            if (AdminTransactionDto.TransactionMoneyId <= 0 || AdminTransactionDto.AdminId <= 0) return BadRequest();
//            var admin = await Context.Admins.FindAsync(AdminTransactionDto.AdminId);
//            var transaction = await Context.Transactions.FindAsync(AdminTransactionDto.TransactionMoneyId);
//            if (admin == null || transaction == null) return BadRequest("This Admin Or Transaction is not found");
//            bool exists = await Context.AdminTransactions.AnyAsync(w => w.AdminId == AdminTransactionDto.AdminId && w.TransactionMoneyId == AdminTransactionDto.TransactionMoneyId);
//            if (exists)
//            {
//                return Ok(new { Exists = true, Message = "Admin is already found in this Transaction" });
//            }
//            var AdminTransaction = new AdminTransaction
//            {
//                AdminId = AdminTransactionDto.AdminId,
//                TransactionMoneyId = AdminTransactionDto.TransactionMoneyId
//            };
//            await Context.AdminTransactions.AddAsync(AdminTransaction);
//            await Context.SaveChangesAsync();
//            return Ok(AdminTransaction);
//        }



//        [HttpDelete]
//        public async Task<IActionResult> DeleteAdminTransactions([FromQuery] List<ValueTuple<int, int>> ids)
//        {
//            if (ids.Count <= 0) return BadRequest();
//            var AdminTransactions = new List<AdminTransaction>();
//            foreach (var id in ids)
//            {
//                if (id.Item1 <= 0 || id.Item2 <= 0) continue;
//                var AdminTransaction = await Context.AdminTransactions.FindAsync(new { id.Item1, id.Item2 });
//                if (AdminTransaction == null) continue;
//                AdminTransactions.Add(AdminTransaction);
//                Context.AdminTransactions.Remove(AdminTransaction);
//            }
//            await Context.SaveChangesAsync();
//            if (AdminTransactions.Count <= 0) return NotFound();
//            return Ok(AdminTransactions);
//        }
//    }
//}
