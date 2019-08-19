using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Messege.Models;
using Messege.Data;
using Messege.DAL;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Claims;

namespace Messege.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IMemoryCache _cache;
        private MessageRepo _repo;

        public CacheController(ApplicationDbContext context,IMemoryCache cache, MessageRepo repo)
        {
            _context = context;
            _cache = cache;
            _repo = repo;
        }
        // GET: api/Cache
        [HttpGet]
        public IEnumerable<ApplicationUser> Get()
        {
            var c_userid = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            return _repo.Search("bas");
       
            
        }
       // GET: api/Cache/5
       [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cache
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Cache/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
