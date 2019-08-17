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
            var friend = _context.Friends.First(a => a.SenderId == c_userid && a.Receiver == userid || a.SenderId == userid && a.Receiver == c_userid);
            _context.Friends.Remove(friend);
           await _context.SaveChangesAsync();
            await Clients.Users(userid, c_userid).SendAsync("Unfriend", userid);
        }
        public async Task Send_Request(string userid)
        {
            var c_userid = Context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var abc = repo.Send_Request(c_userid, userid);
            if (abc)
            {
                await Clients.Users(c_userid, userid).SendAsync("Send_Request","1" ,userid,c_userid);
            }
            else
            {
                await Clients.Users(c_userid, userid).SendAsync("Send_Request", "0", userid, c_userid);
            }
          

        }
        public async Task Cancel_Request(string userid)
        {
            var c_userid = Context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (repo.Cancel_Request(c_userid, userid))
            {
                await Clients.Users(c_userid, userid).SendAsync("Cancel_Request", "1", userid, c_userid);
            }
            else
            {
                await Clients.Users(c_userid, userid).SendAsync("Cancel_Request", "0", userid, c_userid);
            }

        }


    }
}
