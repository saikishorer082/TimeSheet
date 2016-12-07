using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeSheet1.Models;
using System.Web.Script.Serialization;
namespace TimeSheet1.Models
{
    public class UserDetails
    {
        public Nullable<int> uid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        Sunray12dbDataContext db = new Sunray12dbDataContext();
        public bool AutheticateUser(Login login)
        {
            //var loginDetails = new UserDetails();
           
            var query = from tblauth 
                         in db.tblauths
                         where login.username == tblauth.Username 
                         && login.password == tblauth.Password
                        select tblauth;
          // JavaScriptSerializer js = new JavaScriptSerializer();
            if (query.Any()) {
                //tblauth u1 = db.Profiletbls.Single(x => login.username == x.Username && login.password == x.Password);
                //loginDetails.Firstname = u1.Firstname;
                //loginDetails.uid = u1.uid;
                //loginDetails.username = u1.username;
                //loginDetails.password = u1.password;
                //loginDetails.Lastname = u1.Lastname;
                //return loginDetails;
                return true;
            }
            else
                return false;
        }
        
    }
    public class Login
    {
        public string username { get; set; }
        public string password { get; set; }
    }
   
}