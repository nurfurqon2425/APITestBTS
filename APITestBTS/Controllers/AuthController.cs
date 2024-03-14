using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace APITestBTS.Controllers
{
    [ApiController]
    //[Route("api")]
    public class AuthController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IConfiguration _configuration;
        private readonly JwtService _jwtService;

        public AuthController(AppDbContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
            _jwtService = new JwtService(_configuration["Jwt:Key"]);
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<Auth>> Login(Auth login)
        {
            // Validate the username and password against your database or any other source
            var loginData = await _db.Auth.FindAsync(login.Email);

            if (loginData == null)
            {
                return NotFound();
            }

            string hashedPassword = HashPassword(login.Password);

            if (hashedPassword == loginData.Password)
            {
                string token = _jwtService.GenerateToken(loginData.UserName);
                return Ok(new { Token = token });
            }
            else
            {
                return Unauthorized();
            }
        }

        [Route("register")]
        [HttpPost]
        public async Task<ActionResult<Auth>> Register(Auth user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var loginData = await _db.Auth.FindAsync(user.Email);
            if (loginData == null)
            {
                string hashedPassword = HashPassword(user.Password);
                user.Password = hashedPassword;

                _db.Auth.Add(user);
                await _db.SaveChangesAsync();

                return Ok();
            }
            else
            {
                return ValidationProblem();
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                return hash;
            }
        }
    }
}
