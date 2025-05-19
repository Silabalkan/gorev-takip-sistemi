using Microsoft.AspNetCore.Mvc;
using kullaniciGorevTakipSistemi.DataAccess;
using kullaniciGorevTakipSistemi.Entities;
using Microsoft.EntityFrameworkCore;
using kullaniciGorevTakipSistemi.Helpers;


namespace kullaniciGorevTakipSistemi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<AuthController> _logger;
        private readonly IConfiguration _configuration;


        public AuthController(AppDbContext context, ILogger<AuthController> logger, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }




        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Kayıt olurken bir hata oluştu.");
                return StatusCode(500, "Sunucu hatası.");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
                if (user == null)
                    return Unauthorized("Kullanıcı bulunamadı.");

                bool passwordMatches = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
                if (!passwordMatches)
                    return Unauthorized("Şifre yanlış.");

                var jwtKey = _configuration["Jwt:Key"]!;
                var token = JwtHelper.GenerateJwtToken(user, jwtKey);

                return Ok(new
                {
                    token,
                    user = new
                    {
                        user.Id,
                        user.Name,
                        user.Email
                    }
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Giriş sırasında hata oluştu.");
                return StatusCode(500, "Sunucu hatası.");
            }
        }


    }
}
