using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PropDatabaseCore;
using PropMockModels;
using System.Security.Cryptography;
using System.Text;

namespace PropMock.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly PropDbContext _context;

        public UserController(PropDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(string email, string pw, string userfirst, string userlast, string companyname, string phone, string address, int clientid, string userType)
        {
            using var hmac = new HMACSHA512();

            var user = new User
            {
                email = email,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(pw)),
                PasswordSalt = hmac.Key,
                userFirst = userfirst,
                userLast = userlast,
                companyName = companyname,
                phone = phone,
                address = address,
                clientId = clientid,
                userType = userType
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        [HttpGet("userlist")]
        public IEnumerable<User> Get()
        {
            return _context.Users;
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _context.Users.FirstOrDefault(s => s.userId == id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(s => s.userId == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}