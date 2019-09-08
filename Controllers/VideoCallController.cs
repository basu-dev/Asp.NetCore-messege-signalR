using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace Messege.Controllers
{
    public class VideoCallController : Controller
    {[Authorize]
        public IActionResult Index(string Id)
        {
            ViewBag.Receiver = Id;
            return View();
        }
        [Authorize]
        public IActionResult IncomingCall(string Id)
        {
            ViewBag.Sender = Id;
            return View();
        }
    }
}