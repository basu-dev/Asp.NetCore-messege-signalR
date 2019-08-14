using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Messege.Models
{
    public class ApplicationUser : IdentityUser
    {
     
        [Required]
        public string First_Name { get; set; }
        [Required]
        public string Last_Name { get; set; }
        public DateTime DOB { get; set; }
        public string Profile_Picture { get; set; }

    }
}
