using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Messege.DAL;

namespace Messege.Controllers
{
    public class SearchController : Controller
    {
        private MessageRepo _repo;

        public SearchController(MessageRepo repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {

            return View();
        }
     
    }
}