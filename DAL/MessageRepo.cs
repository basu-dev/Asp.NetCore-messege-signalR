using Messege.Data;
using Messege.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messege.DAL
{
    public class MessageRepo : IMessageRepo
    {
        private  ApplicationDbContext _context;


        public MessageRepo(ApplicationDbContext context)
        {
            _context = context;
          
        }
        public List<ApplicationUser> Search(string search)
        {
            return _context.AspNetUsers.Where(a => a.Email.Contains(search) || a.First_Name.Contains(search) || a.Last_Name.Contains(search)).ToList();
        }
        public void Save()
        {
            _context.SaveChangesAsync();

        }
        public Messages Get_Last_Message_With(string c_user, string with_urer)
        {
            Messages m = _context.Messagess.Last(a => a.Sender == c_user && a.Receiver == with_urer || a.Sender == with_urer && a.Receiver == c_user);
            return m;
        }
        public IEnumerable<Messages> Get_Last_N_Message_With(string c_user, string with_urer, int limit)
        {
            IEnumerable<Messages> m = _context.Messagess.Where(a => a.Sender == c_user && a.Receiver == with_urer || a.Sender == with_urer && a.Receiver == c_user).OrderByDescending(a => a.Id).Take(limit).ToList();
            return m.OrderBy(A => A.Id);
        }
        public IEnumerable<Messages> Get_Last_N_Message_Starting_With(string c_user, string with_urer, int limit,int lowest_id)
        {
            return  _context.Messagess.Where(a=>a.Id< lowest_id).Where(a => a.Sender == c_user && a.Receiver == with_urer || a.Sender == with_urer && a.Receiver == c_user).OrderByDescending(a => a.Id).Take(limit).ToList();
            
        }
        public void Add_Message(Messages newmessage)
        {
            _context.Messagess.AddAsync(newmessage);
            Save();
        }
        public IEnumerable<Friend> Get_All_Friends(String c_user)
        {

            return _context.Friends.Where(a => a.SenderId == c_user || a.Receiver == c_user);
        }
        public IEnumerable<Add_Friend> Get_All_Friend_Requests(String c_user)
        {
            return _context.Friend_Requests.Where(a => a.SenderId == c_user || a.Receiver == c_user);
        }

        public bool IsFriend(string c_user, string with_user)
        {
            try
            {
                var frn = _context.Friends.First(a => a.SenderId == c_user && a.Receiver == with_user || a.SenderId == with_user && a.Receiver == c_user);
                if (frn != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        } 
        public bool IsRequestSent(string c_user ,string with_user)
        {
            try
            {
                var frn = _context.Friend_Requests.First(a => a.SenderId == c_user && a.Receiver == with_user);
                if (frn != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool IsRequestReceived(string c_user, string with_user)
        {
            try
            {
                var frn = _context.Friend_Requests.First(a => a.SenderId == with_user && a.Receiver == c_user);
                if (frn != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public  bool Send_Request(string c_user , string with_user)
        {
           if( IsFriend(c_user, with_user) || IsRequestSent(c_user, with_user) || IsRequestReceived(c_user,with_user))
            {
                return false;
            }
            else
            {
                Add_Friend newfrnreq = new Add_Friend
                {
                    SenderId = c_user,
                    Receiver = with_user,
                    
                };
               _context.Friend_Requests.AddAsync(newfrnreq);

                _context.SaveChanges();
                return true;
            }
           
           
        }
        public bool Accept_Request(string c_user, string with_user)
        {
            if (!IsRequestReceived(c_user, with_user))
            {
                return false;
            }
            else
            {
              var data=  _context.Friend_Requests.First(a => a.SenderId == with_user && a.Receiver == c_user); 
                Friend newfrn = new Friend
                {
                    SenderId = with_user,
                    Receiver = c_user,
                    Time = DateTime.Now,
                };
               _context.Friends.AddAsync(newfrn);
                _context.Friend_Requests.Remove(data);
                _context.SaveChanges();

                return true ;
            }
        }
        public bool Cancel_Request(string c_user, string with_user)
        {
            if (IsRequestSent(c_user, with_user))
            {

               var req= _context.Friend_Requests.First(a => a.SenderId == c_user && a.Receiver == with_user);
                _context.Friend_Requests.Remove(req);
                _context.SaveChanges();
                return true;
            }
            else
            { return false; }
           
                
            }
        public bool Decline_Request(string c_user, string with_user)
        {
            if (IsRequestReceived(c_user, with_user))
            {

                var req = _context.Friend_Requests.First(a => a.SenderId ==with_user  && a.Receiver == c_user);
                _context.Friend_Requests.Remove(req);
                _context.SaveChanges();
                return true;
            }
            else

                return false;
        }
        public bool Disconnect(string c_user, string with_user)
        {
            if (IsFriend(c_user, with_user))
            {
                var req = _context.Friends.First(a => a.SenderId == with_user && a.Receiver == c_user);
                _context.Friends.Remove(req);
                _context.SaveChanges();
                return true;
            }
            else

                return false;
        }
        public ApplicationUser GetUserProfile(string userid)
        {
            return _context.AspNetUsers.First(a => a.Id == userid);
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}


    

