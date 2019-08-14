using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Messege.Models
{
    public class Add_Friend
    {
        public int Id { get; set; }
        public  string Receiver { get; set; }
        public ApplicationUser Sender { get; set; }
        public string SenderId { get; set; }
    }
}
