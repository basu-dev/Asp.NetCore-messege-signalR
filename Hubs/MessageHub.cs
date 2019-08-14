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
namespace Messege.Hubs
{
    [Authorize]
    public class MessageHub: Hub
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _usermanager;
        public MessageHub(ApplicationDbContext context,UserManager<ApplicationUser>usermanager)
        {
            _context = context;
            _usermanager = usermanager;
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
    }
}
