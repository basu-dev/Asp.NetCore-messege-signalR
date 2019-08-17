using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Messege.DAL;
using System.Security.Claims;

namespace Messege.Controllers
{
    public class MessageApiController : Controller
    {
        private IMessageRepo _repo;

        public MessageApiController(IMessageRepo repo)
        {
            _repo = repo;
        }
        public IActionResult Index(string userid, int lowest_id)
        {
            var c_userid = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var message = _repo.Get_Last_N_Message_Starting_With(c_userid, userid, 10, lowest_id);
            return Json(message);
        }
    }
}