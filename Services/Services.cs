﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Services
{
    public class Services
    {
        public string Get(int id)
        {
            /*foreach (User u in user)
            {
                if (u.Id == id)
                    return "User: " + u.Name + " Pass: " + u.Password;
            }*/
            return "No user found with that ID";
        }
    }
}