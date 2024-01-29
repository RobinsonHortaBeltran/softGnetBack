using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftGnet.Models;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using SoftGnet.Repository.Repositories;
using Microsoft.AspNetCore.Cors;

namespace SoftGnet.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserRepository _userRepository;
        private readonly string Key;
        private static readonly TimeSpan TokenLifetime = TimeSpan.FromHours(8);
        public AuthController(ApplicationDbContext context, UserRepository userRepository, IConfiguration config)
        {
            _context = context;
            _userRepository = userRepository;
            Key = config.GetSection("JwtConfig").GetSection("Key").ToString();

        }
        [HttpPost("login")]
        public IActionResult Login([FromBody]Users request)
        {
            if (request != null && _userRepository.ValidateUser(request.Email, request.Password))
            {
                Users user = _userRepository.GetUserByUsername(request.Email);
                var token = GenerateToken(request.Email);
                return Ok(new { Token = token, result= user});
            }

            return Unauthorized();
        }

        private string GenerateToken(string email)
        {
            var keyBytes = Encoding.UTF8.GetBytes(Key);
            var claims = new ClaimsIdentity();

            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, email));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(tokenConfig);

            return token;
        }

        // GET: api/Auth
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Auth/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUsers(int id)
        {
            var users = await _context.Users.FindAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        // PUT: api/Auth/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(int id, Users users)
        {
            if (id != users.Id)
            {
                return BadRequest();
            }

            _context.Entry(users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Auth
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("register")]
        public ActionResult<Users> PostUsers(Users users)
        {
           
            
            if (users != null && !string.IsNullOrEmpty(users.Email))
            {
                var exist = _userRepository.GetUserByUsername(users.Email);
                if (exist != null)
                {
                    return BadRequest();
                }

                string passwordHash = BCrypt.Net.BCrypt.HashPassword(users.Password);
                users.Password = passwordHash;
                
            }
            else
            {
                // Maneja el caso donde users.Email es nulo o vacío.
                return BadRequest("Correo electrónico no válido.");
            }

            _userRepository.CreateUser(users);
            return CreatedAtAction("GetUsers", new { id = users.Id }, users);
           
        }

        // DELETE: api/Auth/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers(int id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.Users.Remove(users);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
