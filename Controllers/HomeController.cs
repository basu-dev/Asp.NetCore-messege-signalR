using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Messege.Data;
using Messege.Models;
using Messege.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;


namespace Messege.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _usermanager;

        public HomeController(ApplicationDbContext context,UserManager<ApplicationUser >usermanager)
        {
            _context = context;
            _usermanager = usermanager;
        }
        public IActionResult without()
        {
            return Json(_context.Messagess.ToList());
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<FriendNMessage> FNM = new List<FriendNMessage>();
            var c_userid = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ApplicationUser c_user = _usermanager.FindByIdAsync(c_userid).Result;
            List<ApplicationUser> friend_profiles = new List<ApplicationUser>();
            List<Messages> last_messages = new List<Messages>();
            try
            {
                List<Friend> friends = _context.Friends.Where(a => a.Sender == c_user || a.Receiver == c_userid).ToList();

                foreach (var friend in friends)
                {


                    if (friend.SenderId == c_userid)
                    {
                        FriendNMessage fnm = new FriendNMessage();
                        ApplicationUser frn_profile = await _usermanager.FindByIdAsync(friend.Receiver);

                        try
                        {
                            Messages last_message = _context.Messagess.Last(a => a.Sender == friend.SenderId && a.Receiver == friend.Receiver || a.Sender == friend.Receiver && a.Receiver == friend.SenderId);

                            fnm.First_Name = frn_profile.First_Name;
                            fnm.Last_name = frn_profile.Last_Name;
                            fnm.Profile_Picture = frn_profile.Profile_Picture;
                            fnm.User_Id = frn_profile.Id;
                            fnm.Message = last_message.Body;
                            fnm.Sender = _usermanager.FindByIdAsync(last_message.Sender).Result.First_Name;
                        }
                        catch (Exception)
                        {
                            
                            fnm.Message = null;


                        }
                        FNM.Add(fnm);

                    }

                    else if (friend.Receiver == c_userid)
                    {
                        FriendNMessage fnm = new FriendNMessage();
                        ApplicationUser frn_profile = await _usermanager.FindByIdAsync(friend.SenderId);
                        try
                        {
                            Messages last_message = _context.Messagess.Last(a => a.Sender == friend.SenderId && a.Receiver == friend.Receiver || a.Sender == friend.Receiver && a.Receiver == friend.SenderId);

                            fnm.First_Name = frn_profile.First_Name;
                            fnm.Last_name = frn_profile.Last_Name;
                            fnm.Profile_Picture = frn_profile.Profile_Picture;
                            fnm.User_Id = frn_profile.Id;
                            fnm.Message = last_message.Body;
                            fnm.Sender = _usermanager.FindByIdAsync(last_message.Sender).Result.First_Name;

                        }
                        catch (Exception)
                        {
                            fnm.First_Name = frn_profile.First_Name;
                            fnm.Last_name = frn_profile.Last_Name;
                            fnm.Profile_Picture = frn_profile.Profile_Picture;
                            fnm.User_Id = frn_profile.Id;
                            fnm.Message = null;
                            FNM.Add(fnm);
                        }
                        FNM.Add(fnm);
                    }

                }


            }
            catch
            {
                FNM.Add(null);
            }

          return Json(FNM);

            }
        [Authorize]
        public  IActionResult Message(string Id)
        {  
            List<Conversation> Conv = new List<Conversation>();
            RemoteUserDetail detail = new RemoteUserDetail();
            var c_userid = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ApplicationUser c_user = _usermanager.FindByIdAsync(c_userid).Result;
            ApplicationUser user = _usermanager.FindByIdAsync(Id).Result;
            Lowest_Message id = new Lowest_Message();

            /* For conversation Part */
            try
            {
                var remote_user = _usermanager.FindByIdAsync(Id).Result;
                detail.First_Name = remote_user.First_Name;
                detail.Last_Name = remote_user.Last_Name;
                detail.Profile_Picture = remote_user.Profile_Picture;
                detail.User_Id = remote_user.Id;

            }
            catch(Exception)
            {
                
                return Json(NotFound);
            }
            try
            {
                
                List<int> Ids = new List<int>();
                int lowest_id = 0;
                List<Messages> msgs = _context.Messagess.Where(a => a.Sender == c_userid && a.Receiver == Id || a.Sender == Id && a.Receiver == c_userid).OrderByDescending(a=>a.Id).Take(20).OrderBy(a=>a.Id).ToList();
                if(msgs.Count != 0) {
                    lowest_id = msgs.Min(a => a.Id);
                }
                
                id.Last_Message_Id = lowest_id;
              

                foreach (Messages msg in msgs)
                {

                    Conversation conv = new Conversation
                    {
                        Message = msg.Body,
                        Sender_Id = msg.Sender,
                        Receiver_Id = msg.Receiver
                    };
                    
                    if (msg.Sender == Id)
                    {
                        msg.Seen = true;
                    };
                    _context.SaveChanges();
                    Conv.Add(conv);
                }
            }

            catch (Exception )
            {
                Conv.Add(null); 
            }

            MessageView msgview = new MessageView
            {
                Detail = detail,
                Conversation = Conv,
                Lowest_Message = id,


            };
   
            return Json(msgview);
           
         
            
            
        }

        private IActionResult Json(Func<NotFoundResult> notFound)
        {
            throw new NotImplementedException();
        }
    }
    
}


//This is the comment