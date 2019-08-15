using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Messege.DAL;
using System.Security.Claims;
namespace Messege.Hubs
{
    public class SearchHub:Hub
    {
        private MessageRepo repo;

        public SearchHub(MessageRepo _repo)
        {
            repo = _repo;
        }
         public  async Task Send_Request(string userid)
        {
            var c_userid = Context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (repo.Send_Request(c_userid, userid))
            {
                await Clients.Users(c_userid, userid).SendAsync("Connect","1", userid, c_userid);
            }
            else
            {
                await Clients.Users(c_userid, userid).SendAsync("Connect","0", userid, c_userid);
            }
                
        }
        public async Task Cancel_Request(string userid)
        {
            var c_userid = Context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (repo.Cancel_Request(c_userid, userid))
            {
                await Clients.Users(c_userid, userid).SendAsync("Connect", "1", userid, c_userid);
            }
            else
            {
                await Clients.Users(c_userid, userid).SendAsync("Connect", "0", userid, c_userid);
            }

        }
        public async Task Decline_Request(string userid)
        {
            var c_userid = Context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (repo.Decline_Request(c_userid, userid))
            {
                await Clients.Users(c_userid, userid).SendAsync("Connect", "1", userid, c_userid);
            }
            else
            {
                await Clients.Users(c_userid, userid).SendAsync("Connect", "0", userid, c_userid);
            }

        }
        public async Task Accept_Request(string userid)
        {
            var c_userid = Context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (repo.Accept_Request(c_userid, userid))
            {
                await Clients.Users(c_userid, userid).SendAsync("Connect", "1", userid, c_userid);
            }
            else
            {
                await Clients.Users(c_userid, userid).SendAsync("Connect", "0", userid, c_userid);
            }

        }
        public async Task Unfriend(string userid)
        {
            var c_userid = Context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (repo.Disconnect(c_userid, userid))
            {
                await Clients.Users(c_userid, userid).SendAsync("Connect", "1", userid, c_userid);
            }
            else
            {
                await Clients.Users(c_userid, userid).SendAsync("Connect", "0", userid, c_userid);
            }

        }
    }
}
