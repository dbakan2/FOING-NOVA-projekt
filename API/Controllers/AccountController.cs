using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        public AccountController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {

            if (await UserExists(registerDto.Username)) return BadRequest("Username is taken");
            if (await EmailExists(registerDto.Email)) return BadRequest("Email is taken");
            using var hmac = new HMACSHA512();

            var user = new AppUser
            {
                username = registerDto.Username,
                companyAdress = registerDto.CompanyAdress,
                companyCity = registerDto.CompanyCity,
                companyName = registerDto.CompanyName,
                email = registerDto.Email,
                isMasterAdmin = false,
                name = registerDto.Name,
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                passwordSalt = hmac.Key,
                surname = registerDto.Surname,
                zipCode = registerDto.ZipCode
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserDto{
                username = user.username,
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {

            var user = await _context.Users.SingleOrDefaultAsync(x => x.username == loginDto.Username);

            if (user == null) return Unauthorized("Invalid username");

            using var hmac = new HMACSHA512(user.passwordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.passwordHash[i]) return Unauthorized("Invalid password");
            }

            return new UserDto{
                username = user.username,
            };
        }

        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.username == username);
        }
        private async Task<bool> EmailExists(string email)
        {
            return await _context.Users.AnyAsync(x => x.email == email);
        }
    }
}