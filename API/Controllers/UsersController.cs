using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Entities;
using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]   // e.g., /api/users
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>>GetUsers()
        {
            var users =await  _context.Users.ToListAsync(); //returns data as a list
            return users; // returns 200 OK with users in JSON
        }
        
        [HttpGet ("{id:int}")]
        public async Task<ActionResult<AppUser>>GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(); // returns 404 Not Found if user does not exist
            }
            return Ok(user); // returns 200 OK with users in JSON
        }
    }
}
