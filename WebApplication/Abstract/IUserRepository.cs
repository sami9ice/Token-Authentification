using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.Abstract
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
    }
}