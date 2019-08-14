using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Messege.ViewModels
{
    public class RegisterView
    {
        [Required]
        [EmailAddress]
        
       [Display(Name="Email")]
        [MaxLength(50,ErrorMessage ="Email cannot exceed 20 characters.")]
        public string Email { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "First Name cannot exceed 20 characters.")]
        [Display(Name = "First Name")]
        public string First_Name { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Last Name cannot exceed 20 characters.")]
        [Display(Name = "Last Name")]
        public string Last_Name { get; set; }
        [Required]
        [Display(Name = "Password")]
       
        [DataType(DataType.Password)]
        public string Password1 { get; set; }
        [Required]
        [Display(Name = "Retype Password")]
        [Compare("Password1",ErrorMessage ="Two Passwords Do Not Match")]
        [DataType(DataType.Password)]
        public string Password2 { get; set; }

    }
}
