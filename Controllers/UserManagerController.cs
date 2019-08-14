using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Messege.ViewModels;
using Messege.Data;
using Microsoft.AspNetCore.Identity;
using Messege.Models;

namespace Messege.Controllers
{
    public class UserManagerController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _usermanager;
        private SignInManager<ApplicationUser> _signinmanager;

        public UserManagerController(ApplicationDbContext context,UserManager<ApplicationUser> usermanager,SignInManager<ApplicationUser> signinmanager)
        {
            _context = context;
            _usermanager = usermanager;
            _signinmanager = signinmanager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterView Rgv)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser newuser = new ApplicationUser
                {
                    UserName=Rgv.Email,
                    Email = Rgv.Email,
                    First_Name = Rgv.First_Name,
                    Last_Name = Rgv.Last_Name,


                };
              var result =await  _usermanager.CreateAsync(newuser, Rgv.Password1);
                if (result.Succeeded)
                {
                await _signinmanager.SignInAsync(newuser, true);
                  
                    return Redirect("/");
                }
                else
                {
                    foreach(var e in result.Errors)
                    {
                        ModelState.AddModelError("Email", e.Description);
                    }
                }
            }
            else
            {
                return View(Rgv);
            }
            return View(Rgv);
        }
    }
}