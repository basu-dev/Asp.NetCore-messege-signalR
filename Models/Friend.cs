using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Messege.Models
{
    public class Friend
    {
        public int Id { get; set; }
        public string Receiver { get; set; }
        public ApplicationUser Sender { get; set; }
        
        public DateTime Time { get; set; }
        public string SenderId { get; set; }
        public Friend()
        {
            Time = DateTime.Now;
        }
        
    }
}
