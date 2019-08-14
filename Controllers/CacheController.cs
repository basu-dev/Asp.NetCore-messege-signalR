using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Messege.Models;
using Messege.Data;
using Microsoft.Extensions.Caching.Memory;

namespace Messege.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IMemoryCache _cache;
        public CacheController(ApplicationDbContext context,IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }
        // GET: api/Cache
        [HttpGet]
        public IEnumerable<Messages> Get()
        {
            List<Messages>messages = new List<Messages>();
            _cache.TryGetValue("messages", out messages);
            Messages m = new Messages
            {
                Sender = "SANAJTOHSH",
                Receiver = "SANLJ;FN SAJ ",
                Body = "THIS IS SI S "
            };
            Messages m2 = new Messages
            {
                Sender = "SANAJTOHSH",
                Receiver = "SANLJ;FN SAJ ",
                Body = "THIS IS SI S "
            };
            List<Messages> mm = new List<Messages>()
            {
                m,
                m2
            };
            if (messages != null)
            {
                return messages;
            }
            else
            {
                messages=_context.Messagess.ToList();
                _cache.Set("messages", messages,DateTime.Now.AddSeconds(500));
                return mm;

            }
            
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
