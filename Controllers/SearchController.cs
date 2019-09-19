using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Messege.DAL;
using Messege.Models;
using Messege.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Messege.Controllers
{
    public class SearchController : Controller
    {
        private IMessageRepo _repo;

        public SearchController(IMessageRepo repo)
        {
            _repo = repo;
        }
        [Authorize]
        [HttpGet]
        public IActionResult Index(string Id)
        {
            List<SearchView> searchViews = new List<SearchView>();
          List<ApplicationUser> results=  _repo.Search(Id);
          
            var c_userid = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            foreach(var result in results)
            {
                SearchView sv = new SearchView()
                {
                    Id = result.Id,
                    First_Name = result.First_Name,
                    Last_Name = result.Last_Name,
                    Profile_Picture = result.Profile_Picture,
                };
               
                if (_repo.IsFriend(c_userid, result.Id))
                {
                    sv.Status = 1;
                }
                else if (_repo.IsRequestReceived(c_userid, result.Id))
                {
                    sv.Status = 2;
                }
                else if (_repo.IsRequestSent(c_userid, result.Id))
                {
                    sv.Status = 3;
                }
                else if(result.Id == c_userid)
                {
                    sv.Status = 4;
                }
                else
                {
                    sv.Status = 5;
                }
                searchViews.Add(sv);
            }
            return View(searchViews);
        }
     
    }
}