using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;
using WebApi.Services;
using System.Web.Routing;


namespace WebApi.Controllers
{
    [Authorize]
    public class LoginsController : ApiController
    {
        static Random rnd = new Random();
        List<Login> logins = new List<Login> 
        { 
            new Login { id = 0, username = "ForestGump", successful = (rnd.Next(2)==1), timestamp = new DateTime(2015,rnd.Next(1,12),rnd.Next(1,28),rnd.Next(1,24),rnd.Next(0,59),rnd.Next(0,59))},
            new Login { id = 1, username = "ForestGump", successful = (rnd.Next(2)==1), timestamp = new DateTime(2015,rnd.Next(1,12),rnd.Next(1,28),rnd.Next(1,24),rnd.Next(0,59),rnd.Next(0,59))},
            new Login { id = 2, username = "ForestGump", successful = (rnd.Next(2)==1), timestamp = new DateTime(2015,rnd.Next(1,12),rnd.Next(1,28),rnd.Next(1,24),rnd.Next(0,59),rnd.Next(0,59))},
            new Login { id = 3, username = "ForestGump", successful = (rnd.Next(2)==1), timestamp = new DateTime(2015,rnd.Next(1,12),rnd.Next(1,28),rnd.Next(1,24),rnd.Next(0,59),rnd.Next(0,59))},
            new Login { id = 4, username = "fido", successful = (rnd.Next(2)==1), timestamp = new DateTime(2015,rnd.Next(1,12),rnd.Next(1,28),rnd.Next(1,24),rnd.Next(0,59),rnd.Next(0,59))},
            new Login { id = 5, username = "fido", successful = (rnd.Next(2)==1), timestamp = new DateTime(2015,rnd.Next(1,12),rnd.Next(1,28),rnd.Next(1,24),rnd.Next(0,59),rnd.Next(0,59))},
            new Login { id = 6, username = "fido", successful = (rnd.Next(2)==1), timestamp = new DateTime(2015,rnd.Next(1,12),rnd.Next(1,28),rnd.Next(1,24),rnd.Next(0,59),rnd.Next(0,59))},
            new Login { id = 7, username = "fido", successful = (rnd.Next(2)==1), timestamp = new DateTime(2015,rnd.Next(1,12),rnd.Next(1,28),rnd.Next(1,24),rnd.Next(0,59),rnd.Next(0,59))},
            new Login { id = 8, username = "fido", successful = (rnd.Next(2)==1), timestamp = new DateTime(2015,rnd.Next(1,12),rnd.Next(1,28),rnd.Next(1,24),rnd.Next(0,59),rnd.Next(0,59))},
            new Login { id = 9, username = "username", successful = (rnd.Next(2)==1), timestamp = new DateTime(2015,rnd.Next(1,12),rnd.Next(1,28),rnd.Next(1,24),rnd.Next(0,59),rnd.Next(0,59))},
            new Login { id = 10, username = "username", successful = (rnd.Next(2)==1), timestamp = new DateTime(2015,rnd.Next(1,12),rnd.Next(1,28),rnd.Next(1,24),rnd.Next(0,59),rnd.Next(0,59))},
            new Login { id = 11, username = "username", successful = (rnd.Next(2)==1), timestamp = new DateTime(2015,rnd.Next(1,12),rnd.Next(1,28),rnd.Next(1,24),rnd.Next(0,59),rnd.Next(0,59))},
            new Login { id = 12, username = "lorem", successful = (rnd.Next(2)==1), timestamp = new DateTime(2015,rnd.Next(1,12),rnd.Next(1,28),rnd.Next(1,24),rnd.Next(0,59),rnd.Next(0,59))},
            new Login { id = 13, username = "lorem", successful = (rnd.Next(2)==1), timestamp = new DateTime(2015,rnd.Next(1,12),rnd.Next(1,28),rnd.Next(1,24),rnd.Next(0,59),rnd.Next(0,59))},
            new Login { id = 14, username = "lorem", successful = (rnd.Next(2)==1), timestamp = new DateTime(2015,rnd.Next(1,12),rnd.Next(1,28),rnd.Next(1,24),rnd.Next(0,59),rnd.Next(0,59))},
            new Login { id = 15, username = "lorem", successful = (rnd.Next(2)==1), timestamp = new DateTime(2015,rnd.Next(1,12),rnd.Next(1,28),rnd.Next(1,24),rnd.Next(0,59),rnd.Next(0,59))},
            new Login { id = 16, username = "ItsMyBirday", successful = (rnd.Next(2)==1), timestamp = new DateTime(2015,rnd.Next(1,12),rnd.Next(1,28),rnd.Next(1,24),rnd.Next(0,59),rnd.Next(0,59))},
            new Login { id = 17, username = "ItsMyBirday", successful = (rnd.Next(2)==1), timestamp = new DateTime(2015,rnd.Next(1,12),rnd.Next(1,28),rnd.Next(1,24),rnd.Next(0,59),rnd.Next(0,59))},
        };
        public string Get()
        {
            string finalOut = "<table>";
            foreach (Login l in logins)
            {
                finalOut += "<tr><td>"+l.id+"</td><td>Username: " + l.username + "</td><td>Successful: " + l.successful + "</td><td>Timestamp: " + l.timestamp + "</td></tr>";
            }
            finalOut += "</table>";
            return finalOut;
        }
        public string Get(int id)
        {
            string finalOut = "<table>";
            foreach (Login l in logins)
            {
                if (l.id == id)
                {
                    finalOut += "<tr><td>" + l.id + "</td><td>Username: " + l.username + "</td><td>Successful: " + l.successful + "</td><td>Timestamp: " + l.timestamp + "</td></tr>";
                }
            }
            finalOut += "</table>";
            return finalOut;
        }
        public string Delete(int id)
        {
            string finalOut = "<table>";
            foreach (Login l in logins)
            {
                if (l.id != id)
                {
                    finalOut += "<tr><td>" + l.id + "</td><td>Username: " + l.username + "</td><td>Successful: " + l.successful + "</td><td>Timestamp: " + l.timestamp + "</td></tr>";
                }
            }
            finalOut += "</table>";
            return finalOut;
        }
    }
}
