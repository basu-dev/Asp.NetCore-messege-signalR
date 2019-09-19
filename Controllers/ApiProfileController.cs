using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Messege.DAL;
using Messege.Data;
using Messege.ViewModels;
using Messege.Models;
using System.Security.Claims;

namespace Messege.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiProfileController : ControllerBase
    {
        private IMessageRepo _repo;

        public ApiProfileController(IMessageRepo repo)
        {
            _repo = repo;
        }
        // GET: api/ApiProfile
        [HttpGet]
        public ProfileView Get()
        {
            var c_userid = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ApplicationUser profile = _repo.GetUserProfile(c_userid);
            ProfileView pf = new ProfileView()
            {
                First_Name = profile.First_Name.ToString(),
                Last_Name = profile.Last_Name.ToString(),
                Profile_Picture = profile.Profile_Picture.ToString(),
                Email = profile.Email,
            };
            return pf;
        }

        // GET: api/ApiProfile/5
      

        // POST: api/ApiProfile
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/ApiProfile/5
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
