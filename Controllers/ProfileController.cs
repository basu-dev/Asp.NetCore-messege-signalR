using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Messege.DAL;
using Messege.Models;
using System.Security.Claims;
using Messege.ViewModels;

namespace Messege.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IMessageRepo _repo;

        public ProfileController(IMessageRepo repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            var c_userid = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ApplicationUser profile = _repo.GetUserProfile(c_userid);
            ProfileView pf = new ProfileView()
            {
                First_Name = profile.First_Name,
                Last_Name = profile.Last_Name,
                Profile_Picture = profile.Profile_Picture,
                Email = profile.Email,
            };
            return View(pf);
        }
    }
}