using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NearBy_Friends.Data;
using NearBy_Friends.Models;

namespace NearBy_Friends.Controllers
{
    public class ChatController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChatController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Chat()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(Message message)
        {
            if (ModelState.IsValid)
            {
                _context.Messages.Add(message);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        public async Task<IActionResult> GetMessages()
        {
            var messages = await _context.Messages.ToListAsync();
            return Json(messages);
        }
    }
}
