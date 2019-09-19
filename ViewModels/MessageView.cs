using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messege.Models;

namespace Messege.ViewModels
{
    public class Conversation
    {
        public string Receiver_Id { get; set; }
        public string Sender_Id { get; set; }
        public string Sender_Profile_Picture { get; set; }
        public string  Message { get; set; }
       

    }
    public class RemoteUserDetail
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Profile_Picture { get; set; }
        public string User_Id { get; set; }
    }
 
    public class MessageView
    {
        public List<Conversation> Conversation { get; set; }
       public RemoteUserDetail Detail { get; set; }
        public Lowest_Message Lowest_Message { get; set; }
    }
    public class Lowest_Message
    {
        public int Last_Message_Id { get; set; }
    }
}
