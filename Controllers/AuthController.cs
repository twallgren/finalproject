using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;
using WebApi.Services;
using System.Web.Routing;
using System.Web;
using System.Security.Principal;
using System.Threading;
using System.Text;
using System.Net.Http.Headers;


namespace WebApi.Controllers
{
    [Authorize]
    public class AuthController : ApiController
    {
        List<User> user = new List<User> 
        { 
            new User { Id = 1, Username = "ForestGump", Password = "1Forest1", FailedLogins = 0},
            new User { Id = 2, Username = "lorem", Password = "ipsum", FailedLogins = 0},
            new User { Id = 3, Username = "username", Password = "password", FailedLogins = 0},
            new User { Id = 4, Username = "ItsMyBirthday", Password = "andIllCryIfIWantTo", FailedLogins = 0},
            new User { Id = 5, Username = "fido", Password = "1234pass", FailedLogins = 0} 
        };
        public string Get()
        {
            //return "This is the default response for Get.";
            return "<h3>Login</h3><form><table><tr><td>Username: </td><td><input type=\"text\" id=\"username\" name=\"username\" value=\"fido\" /></td></tr>"+
                "<tr><td>Password: </td><td><input type=\"password\" id=\"password\" name=\"password\" value=\"1234pass\" /></td></tr>"+
                "<tr><td colspan=2><input type=\"button\" id =\"loginButton\" value=\"Submit\" onclick=\"login()\" /></td></tr></table></form>";

        }
        public string Get(string username)
        {
            foreach (User u in user)
            {
                if (u.Username == username)
                    return "User: " + u.Username + " Pass: " + u.Password;
            }
            return "No user found with that ID"; 
        }

        public string Post(string username, string password)
        {
            foreach (User u in user)
            {
                if (u.Username == username && u.Password == password)
                    return "User: " + u.Username + " authenticated successfully!";
            }
            return "Invalid Username/Password";
        }
       
        public class loginDeets
        {
            public string username { get; set; }
            public string password { get; set; }
        }

        public string Post(loginDeets logindeet)
        {
            foreach (User u in user) //checking list of users instead of db
            {
                if (u.Username == logindeet.username && u.Password == logindeet.password)
                {
                    return "true";
                }
                //return "User '" + u.Username + "' authenticated successfully!";
            }
            return "false";
            //return "Invalid Username/Password"; 
        }
        /*public string Post([FromBody]dynamic value)
        {
            return value;
            //var username = value.username; // JToken
            //var password = value.password; // JToken
            //return "Received username '" + username + "' and password '" + password + "'";
        }*/
    }
}


namespace WebHostBasicAuth.Modules
{
    public class BasicAuthHttpModule : IHttpModule
    {
        private const string Realm = "My Realm";

        public void Init(HttpApplication context)
        {
            // Register event handlers
            context.AuthenticateRequest += OnApplicationAuthenticateRequest;
            context.EndRequest += OnApplicationEndRequest;
        }

        private static void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }

        // TODO: Here is where you would validate the username and password.
        private static bool CheckPassword(string username, string password)
        {
            return username == "api-user" && password == "1234pass";
        }

        private static void AuthenticateUser(string credentials)
        {
            try
            {
                var encoding = Encoding.GetEncoding("iso-8859-1");
                credentials = encoding.GetString(Convert.FromBase64String(credentials));

                int separator = credentials.IndexOf(':');
                string name = credentials.Substring(0, separator);
                string password = credentials.Substring(separator + 1);

                if (CheckPassword(name, password))
                {
                    var identity = new GenericIdentity(name);
                    SetPrincipal(new GenericPrincipal(identity, null));
                }
                else
                {
                    // Invalid username or password.
                    HttpContext.Current.Response.StatusCode = 401;
                }
            }
            catch (FormatException)
            {
                // Credentials were not formatted correctly.
                HttpContext.Current.Response.StatusCode = 401;
            }
        }

        private static void OnApplicationAuthenticateRequest(object sender, EventArgs e)
        {
            var request = HttpContext.Current.Request;
            var authHeader = request.Headers["Authorization"];
            if (authHeader != null)
            {
                var authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);

                // RFC 2617 sec 1.2, "scheme" name is case-insensitive
                if (authHeaderVal.Scheme.Equals("basic",
                        StringComparison.OrdinalIgnoreCase) &&
                    authHeaderVal.Parameter != null)
                {
                    AuthenticateUser(authHeaderVal.Parameter);
                }
            }
        }

        // If the request was unauthorized, add the WWW-Authenticate header 
        // to the response.
        private static void OnApplicationEndRequest(object sender, EventArgs e)
        {
            var response = HttpContext.Current.Response;
            if (response.StatusCode == 401)
            {
                response.Headers.Add("WWW-Authenticate",
                    string.Format("Basic realm=\"{0}\"", Realm));
            }
        }

        public void Dispose()
        {
        }
    }
}