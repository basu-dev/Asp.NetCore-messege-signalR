using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Messege.Models
{
    public class Profile
    {

        [Required]
        public int Id { get; set; }
        [MaxLength(30)]
        public string First_Name { get; set; }
        [MaxLength(30)]
        public string Last_Name { get; set; }
        [MaxLength(300)]
        public string Profile_Picture { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

    }
}
