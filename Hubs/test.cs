using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Messege.Hubs
{
    public class test : Hub
    {
        public async Task Unfriend(string userid)
        {
            var c_userid = Context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await Clients.Users(c_userid).SendAsync("Unfriend", userid);
        }
    }
}
