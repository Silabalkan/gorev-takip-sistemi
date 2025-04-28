using Microsoft.AspNetCore.Mvc;
using kullaniciGorevTakipSistemi.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace kullaniciGorevTakipSistemi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NotificationController(AppDbContext context)
        {
            _context = context;
        }

        // Tüm bildirimleri getir
        [HttpGet]
        public async Task<IActionResult> GetAllNotifications()
        {
            var notifications = await _context.Notifications.ToListAsync();
            return Ok(notifications);
        }
    }
}
