using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messege.Data;
using Microsoft.AspNetCore.Identity;
using Messege.Models;

namespace Messege.DAL
{
    public interface IMessageRepo 
    {
        bool Send_Request(string c_user, string with_user);
        
        bool Accept_Request(string c_user, string with_user);
        bool Cancel_Request(string c_user, string with_user);
        bool Decline_Request(string c_user, string with_user);
        bool Disconnect(string c_user, string with_user);
        ApplicationUser GetUserProfile(string userid);
        bool IsRequestReceived(string c_user, string with_user);
        bool IsRequestSent(string c_user, string with_user);
        bool IsFriend(string c_user, string with_user);
        IEnumerable<Friend> Get_All_Friends(String c_user);
        void Add_Message(Messages newmessage);
        IEnumerable<Messages> Get_Last_N_Message_With(string c_user, string with_urer, int limit);
        Messages Get_Last_Message_With(string c_user, string with_urer);
        List<ApplicationUser> Search(string search);
        IEnumerable<Messages> Get_Last_N_Message_Starting_With(string c_user, string with_urer, int limit, int lowest_id);

    }
}
