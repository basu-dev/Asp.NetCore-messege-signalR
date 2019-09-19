using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace Messege.Controllers
{

    public class VideoCallController : ControllerBase
    {
        [Authorize]
        public IActionResult Index(string Id)
        {
            ViewBag.Receiver = Id;
            return View();
        }
        public IActionResult IncomingCall(string Id)
        {
            ViewBag.Sender = Id;
            return View();
        }
    }
}