using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using TimeSheet1.Models;
using System.Web.Script.Serialization;
namespace TimeSheet1
{
    /// <summary>
    /// Summary description for Login
    /// </summary>
    [WebService]
    public class Login : System.Web.Services.WebService
    {
        kishoreDB1DataContext db = new kishoreDB1DataContext();
        [WebMethod]
        public string authenticateUser(int uid, string Password)
        {
            var query = from UserDetail in db.UserDetails where uid == UserDetail.uid && Password == UserDetail.password select UserDetail;
            JavaScriptSerializer js = new JavaScriptSerializer();
            var json = js.Serialize(query);
            return json;
        }
        //public class LoginDetails
        //{
        //    public string UserName { get; set; }
        //    public string Password { get; set; }
        //}
    }
}
