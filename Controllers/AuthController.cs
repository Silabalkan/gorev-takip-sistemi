using Microsoft.AspNetCore.Mvc;
using kullaniciGorevTakipSistemi.DataAccess;
using kullaniciGorevTakipSistemi.Entities;
using Microsoft.EntityFrameworkCore;

namespace kullaniciGorevTakipSistemi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        // Kullanıcı Kayıt
        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            var userExist = await _context.Users.FirstOrDefaultAsync(x => x.Email == user.Email);
            if (userExist != null)
            {
                return BadRequest("Bu e-posta zaten kayıtlı.");
            }

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
            if (user == null)
            {
                return Unauthorized("Kullanıcı bulunamadı.");
            }

            bool passwordMatches = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
            if (!passwordMatches)
            {
                return Unauthorized("Şifre yanlış.");
            }

            return Ok(user);
        }

    }
}
