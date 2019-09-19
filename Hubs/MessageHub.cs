using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Messege.Data;
using Microsoft.AspNetCore.SignalR;
using Messege.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Messege.DAL;
namespace Messege.Hubs
{
    [Authorize]
    public class MessageHub: Hub
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly IMessageRepo repo;

        public MessageHub(ApplicationDbContext context,UserManager<ApplicationUser>usermanager, IMessageRepo _repo)
        {
            _context = context;
            _usermanager = usermanager;
            repo = _repo;
        }

        public async Task Call_Request(string to, object sdp)
        {
            var c_userid = Context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await Clients.User(to).SendAsync("incommingcall",c_userid, sdp);
        }
        public async Task Call_Accept(string to, object sdp)
        {
            await Clients.User(to).SendAsync("call_accepted", sdp);
        }
        public async Task Initial_Call_Request(string to,string from)
        {
           
            var name = _context.AspNetUsers.First(a => a.Id == from);
            List<string> users = new List<string>()
            {
                to,from,
            };
            await Clients.Users(users).SendAsync("initial_call_request", name.First_Name+" "+name.Last_Name,to,from);
        }
        public async Task Accept_Call(string to,string from)
        {
            List<string> users = new List<string>()
            {
                to,from,
            };
            
            await Clients.Users(users).SendAsync("Accept_Call",to,from);
        }
        public async Task Reject_Call(string to)
        {
         
            await Clients.User(to).SendAsync("reject_call");
        }

        public async Task Connect_By_Receiver(string from){
            await Clients.User(from).SendAsync("connect_by_receiver");

}


        public async Task PrivateMessage(string Message,string Receiver)
        {
           string c_userid= Context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
           
            
            ApplicationUser sender = _usermanager.FindByIdAsync(c_userid).Result;
            ApplicationUser receiver = _usermanager.FindByIdAsync(Receiver).Result;
            List<string> to = new List<string>()
            {
                Receiver,
                c_userid,
            };
            Messages message = new Messages()
            {
                Receiver=Receiver,
                Sender=c_userid,
               Body=Message
             };
            _context.Messagess.Add(message);
            await _context.SaveChangesAsync();
            await Clients.Users(to).SendAsync("PrivateMessage", Message,receiver.Id,sender.Id,sender.First_Name,receiver.First_Name,sender.Last_Name,receiver.Last_Name,sender.Profile_Picture,receiver.Profile_Picture);
        }
        public async Task Unfriend(string userid)
        {
            var c_userid = Context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            
            if (repo.Disconnect(c_userid, userid))
            {
                
                await Clients.Users(c_userid, userid).SendAsync("Unfriend", "success", userid, c_userid);
            }
            else
            {
                
                await Clients.Users(c_userid, userid).SendAsync("Unfriend", "failed", userid, c_userid);
            }

        }
        public async Task Send_Request(string userid)
        {
            var c_userid = Context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var abc = repo.Send_Request(c_userid, userid);
            if (abc)
            {
                await Clients.Users(c_userid, userid).SendAsync("Send_Request","success" ,userid,c_userid);
            }
            else
            {
                await Clients.Users(c_userid, userid).SendAsync("Send_Request", "failed", userid, c_userid);
            }
          

        }
        public async Task Decline_Request(string userid)
        {
            var c_userid = Context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (repo.Decline_Request(c_userid, userid))
            {
                await Clients.Users(c_userid, userid).SendAsync("Connect", "success", userid, c_userid);
            }
            else
            {
                await Clients.Users(c_userid, userid).SendAsync("Connect", "failed", userid, c_userid);
            }

        }
        public async Task Cancel_Request(string userid)
        {
            var c_userid = Context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (repo.Cancel_Request(c_userid, userid))
            {
                await Clients.Users(c_userid, userid).SendAsync("Cancel_Request", "success", userid, c_userid);
            }
            else
            {
                await Clients.Users(c_userid, userid).SendAsync("Cancel_Request", "failed", userid, c_userid);
            }

        }
        public async Task Accept_Request(string userid)
        {
            var c_userid = Context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (repo.Accept_Request(c_userid, userid))
            {
                await Clients.Users(c_userid, userid).SendAsync("Accept_Request", "1", userid, c_userid);
            }
            else
            {
                await Clients.Users(c_userid, userid).SendAsync("Accept_Request", "0", userid, c_userid);
            }

        }


    }
}
