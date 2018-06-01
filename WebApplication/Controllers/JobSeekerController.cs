using context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WebApplication.Repo;

namespace WebApplication.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class JobSeekerController : ApiController
    {
        private UserRepository repository { get; }
        public JobSeekerController()
        {
            repository = new UserRepository();
        }

        [HttpGet]

        public IEnumerable<ApplicationUser> Get()
        {

            return repository.GetAll();
        }
    }
}
