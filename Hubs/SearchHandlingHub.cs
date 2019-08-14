using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Messege.Hubs
{
    public class SearchHandlingHubController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}