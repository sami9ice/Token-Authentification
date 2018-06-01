using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using context.Models;

namespace WebApplication.Repo
{
    public interface IUserRepository
    {
        IEnumerable<ApplicationUser> GetAll();
    }
}