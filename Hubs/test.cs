using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Messege.DAL;
using Messege.Data;
using Messege.Models;
using Microsoft.AspNetCore.Identity;

namespace Messege.Hubs
{

    public class test:Hub
    {
      
        private ApplicationDbContext _con;
        private readonly UserManager<ApplicationUser> _user;
        public MessageRepo repo;
        public test(ApplicationDbContext con,UserManager<ApplicationUser>user)
        {
            _con = con;
            _user = user;
        
        }
    

    }
}
