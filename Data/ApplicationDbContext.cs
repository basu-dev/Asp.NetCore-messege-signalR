using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Messege.Models;

namespace Messege.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Messages> Messagess { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Add_Friend> Friend_Requests { get; set; }
        public DbSet<Profile>Profiles { get; set; }
        public DbSet<ApplicationUser> AspNetUsers { get; set; } 
      
    }
}
