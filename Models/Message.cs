using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace Messege.Models
{
    public class Messages
    {
        public int Id { get; set; }
        public string Receiver { get; set; }
       
        public string Sender { get; set; }
        public DateTime Time { get; set; }
        public string Body { get; set; }
        public bool Seen { get; set; }
        
        public Messages()
        {
            Time = DateTime.Now;
            
        }

    }
}
