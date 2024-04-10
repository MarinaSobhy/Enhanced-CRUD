using CRUD.Models;
using CRUD.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace CRUD.HTTPClientShowCase
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersService _usersService;
        private readonly IMemoryCache _memoryCache;

        public UsersController(IUsersService usersService, IMemoryCache memoryCache)
        {
            _usersService = usersService;
            _memoryCache = memoryCache;
        }
        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var users = _memoryCache.Get<IEnumerable<User>>("users");
            if (users != null)
            {
                return Ok(users); 
            }

            var expirationTime = DateTimeOffset.Now.AddMinutes(5.0);
            users = await _usersService.GetAllUsers();
            _memoryCache.Set("users", users, expirationTime);
            return Ok(users);


        }
    }
}
