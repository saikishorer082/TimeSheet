using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TimeSheet1.Models;
using System.Web.Script.Serialization;
namespace TimeSheet1.Controllers
{
    public class LoginController : ApiController
    {
        
        [HttpPost]
        public bool AuthenticateUser(Login login)
        {
            var userDetails = new UserDetails();
            var details = userDetails.AutheticateUser(login);
            return details;

        }
    }
}
