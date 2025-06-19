//using HandMadeEcommece.Models.Data;
//using HandMadeEcommece.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Http.HttpResults;
//using Microsoft.EntityFrameworkCore;

//namespace HandMadeEcommece.Controllers.DatabaseControllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ChatsController : ControllerBase
//    {
//        private readonly AppDbContext _Context;
//        public ChatsController(AppDbContext Context)
//        {
//            _Context = Context;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetChatsAll()
//        {
//            var Chats = await _Context.Chats.ToListAsync();
//            if (Chats == null) return NotFound();
//            return Ok(Chats);
//        }

//        [HttpPost]
//        public async Task<IActionResult> CreateChat([FromForm] ChatDto chatDto)
//        {
//            if (!ModelState.IsValid || chatDto == null) return BadRequest();

//            var chat = new Chat
//            {
//                VendorId = chatDto.VendorId,
//                UserId = chatDto.UserId,
//                CreatedAt = DateTime.UtcNow,
//                UpdatedAt = DateTime.UtcNow,
//                Message = chatDto.Message,
//                Seen = chatDto.Seen,
//            };

//            await _Context.Chats.AddAsync(chat);
//            await _Context.SaveChangesAsync();
//            return Ok(chat);
//        }


//        [HttpPut]
//        public async Task<IActionResult> UpdateChats(int id, ChatDto chatDto)
//        {
//            if (id <= 0 || chatDto == null) return BadRequest();
//            var chat = await _Context.Chats.FindAsync(id);
//            if (chat == null) return NotFound();
//            chat.VendorId = chatDto.VendorId;
//            chat.UserId = chatDto.UserId;
//            chat.CreatedAt = chat.CreatedAt;
//            chat.UpdatedAt = DateTime.UtcNow;
//            chat.Message = chatDto.Message;
//            chat.Seen = chatDto.Seen;
//            _Context.Chats.Update(chat);
//            await _Context.SaveChangesAsync();
//            return Ok(chat);
//        }


//        [HttpDelete]
//        public async Task<IActionResult> DeleteChats([FromQuery] List<int> ids)
//        {
//            if (ids == null || ids.Count <= 0) return BadRequest();
//            var Chats = new List<Chat>();
//            foreach (var id in ids)
//            {
//                var chat = await _Context.Chats.FindAsync(id);
//                if (chat == null) continue;
//                _Context.Chats.Remove(chat);
//            }
//            await _Context.SaveChangesAsync();
//            if (Chats.Count == 0) return NotFound();
//            return Ok(Chats);
//        }
//    }
//}
