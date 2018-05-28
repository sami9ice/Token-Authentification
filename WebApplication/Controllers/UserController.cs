using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication.Models;
using WebApplication.Abstract; 

namespace WebApplication.Controllers
{
   [Authorize]
    public class UserController : ApiController
    {
        private readonly IUserRepository repository;
     

        public UserController(IUserRepository repo)
        {
            repository = repo;
        }
        // GET api/values
        public IEnumerable<User> GetUsers()
        {
            IEnumerable<User> Users = repository.GetUsers();
            return Users;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
