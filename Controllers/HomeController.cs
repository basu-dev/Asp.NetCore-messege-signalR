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
        [Authorize]
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

                            fnm.Friend = frn_profile;
                            fnm.Message = last_message.Body;
                            fnm.Sender = _usermanager.FindByIdAsync(last_message.Sender).Result.First_Name;
                        }
                        catch (Exception)
                        {
                            fnm.Friend = frn_profile;
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

                            fnm.Friend = frn_profile;
                            fnm.Message = last_message.Body;
                            fnm.Sender = _usermanager.FindByIdAsync(last_message.Sender).Result.First_Name;

                        }
                        catch (Exception)
                        {
                            fnm.Friend = frn_profile;
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

          return View(FNM);

            }
        [Authorize]
        public async Task<IActionResult> Message(string Id)
        {
            
            List<Conversation> Conv = new List<Conversation>();
            List<FriendNMessage> FNM = new List<FriendNMessage>();
            var c_userid = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ApplicationUser c_user = _usermanager.FindByIdAsync(c_userid).Result;
            ApplicationUser user = _usermanager.FindByIdAsync(Id).Result;
            Lowest_Message id = new Lowest_Message();

            List<ApplicationUser> friend_profiles = new List<ApplicationUser>();
            List<Messages> last_messages = new List<Messages>();
            try
            {
                List<Friend> friends = _context.Friends.Where(a => a.Sender == c_user ||a.Receiver== c_userid).ToList();
                
                foreach (var friend in friends)
                {
                    

                    if (friend.SenderId == c_userid)
                    {
                        FriendNMessage fnm = new FriendNMessage();
                        ApplicationUser frn_profile = await _usermanager.FindByIdAsync(friend.Receiver);

                        try
                        {
                            Messages last_message = _context.Messagess.Last(a => a.Sender == friend.SenderId && a.Receiver == friend.Receiver || a.Sender == friend.Receiver && a.Receiver == friend.SenderId);

                            fnm.Friend = frn_profile;
                            fnm.Message = last_message.Body;
                            fnm.Sender = _usermanager.FindByIdAsync(last_message.Sender).Result.First_Name;
                        }
                        catch (Exception)
                        {
                            fnm.Friend = frn_profile;
                            fnm.Message = null;
                            

                        }
                        FNM.Add(fnm);

                    }

                    else if(friend.Receiver==c_userid)
                    {
                        FriendNMessage fnm = new FriendNMessage();
                        ApplicationUser frn_profile =await _usermanager.FindByIdAsync(friend.SenderId);
                        try
                        {
                            Messages last_message = _context.Messagess.Last(a => a.Sender == friend.SenderId && a.Receiver == friend.Receiver || a.Sender == friend.Receiver && a.Receiver == friend.SenderId);

                            fnm.Friend = frn_profile;
                            fnm.Message = last_message.Body;
                            fnm.Sender = _usermanager.FindByIdAsync(last_message.Sender).Result.First_Name;
                            
                        }
                        catch (Exception)
                        {
                            fnm.Friend = frn_profile;
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
            
            if (user == null)
            {
                Conversation convs = new Conversation
                {
                    Message = null,
                    Sender_First_Name = null,
                    Sender_Last_Name = null,
                    Sender_Profile_Picture = null,
                    Sender_Id = null,
                    Receiver_First_Name = null,
                    Receiver_Last_Name = null,
                };
                Conv.Add(convs);
                
                MessageView msview = new MessageView
                {
                    FriendNMessage=FNM,
                   Conversation=Conv,

                };

                return View(msview);

            }
            /* For conversation Part */
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
                        Sender_First_Name = _usermanager.FindByIdAsync(msg.Sender).Result.First_Name,
                        Sender_Last_Name= _usermanager.FindByIdAsync(msg.Sender).Result.Last_Name,
                        Sender_Profile_Picture = _usermanager.FindByIdAsync(msg.Sender).Result.Profile_Picture,
                        Sender_Id= msg.Sender,
                        Receiver_First_Name = _usermanager.FindByIdAsync(msg.Receiver).Result.First_Name,
                        Receiver_Last_Name = _usermanager.FindByIdAsync(msg.Receiver).Result.Last_Name,
                       

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
            

            ViewBag.UserId = Id;
            ViewBag.MyId = c_userid;
            try
            {
                ViewBag.UserName = _usermanager.FindByIdAsync(Id).Result.First_Name;
            }
            catch(Exception)
            {
                return View();
            }
            MessageView msgview = new MessageView
            {
                FriendNMessage = FNM,
                Conversation = Conv,
                Lowest_Message = id,

            };
            string convcount = msgview.Conversation.Count.ToString();
            string frnnmsgcount = msgview.FriendNMessage.Count.ToString();
            ViewBag.ConversationCount=convcount;
            ViewBag.FrnNMessageCount = frnnmsgcount;
            
           
            return View(msgview);
           
         
            
            
        }
    }
    
}


//This is the comment