using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Models
{
    public class Login
    {
        public int id { get; set; }
        public string username { get; set; }
        public bool successful { get; set; }
        public DateTime timestamp { get; set; }
    }
}