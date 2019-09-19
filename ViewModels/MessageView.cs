using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messege.Models;

namespace Messege.ViewModels
{
    public class Conversation
    {
        public string Sender_First_Name { get; set; }
        public string Sender_Last_Name { get; set; }
        public string Sender_Id { get; set; }
        public string Sender_Profile_Picture { get; set; }
        public string Receiver_First_Name { get; set; }
        public string Receiver_Last_Name { get; set; }
        public ApplicationUser friend { get; set; }
        public Messages last_message { get; set; }
        public string  Message { get; set; }
       

    }
    public class FriendNMessage
    {
       
        public ApplicationUser Friend { get; set; }
        public string Message { get; set; }
        public string Sender { get; set; }

    }
    public class MessageView
    {
        public List<Conversation> Conversation { get; set; }
        public List<FriendNMessage> FriendNMessage { get; set; }
        public Lowest_Message Lowest_Message { get; set; }
    }
    public class Lowest_Message
    {
        public int Last_Message_Id { get; set; }
    }
}
