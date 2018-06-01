using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using context.Models;


namespace WebApplication.Repo 
{
     public class UserRepository : IUserRepository
    {
        private ApplicationDbContext context;

        public UserRepository()
        {
            context = new ApplicationDbContext();
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return context.Users.ToList();
        }
    }
}