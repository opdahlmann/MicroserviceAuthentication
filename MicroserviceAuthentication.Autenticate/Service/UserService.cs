﻿using MicroserviceAuthentication.Autenticate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroserviceAuthentication.Autenticate.Service
{
    public class UserService
    {
        public User GetUserByCredentials(string email, string password)
        {
            if (email != "email@domain.com" || password != "password")
            {
                return null;
            }
            User user = new User() { Id = "1", Email = "email@domain.com", Password = "password", Name = "Ole Petter Dahlmann" };
            if (user != null)
            {
                user.Password = string.Empty;
            }
            return user;
        }

        public User GetById(string id)
        {
            User user = new User() { Id = "1", Email = "email@domain.com", Password = "password", Name = "Ole Petter Dahlmann" };
            if (user != null)
            {
                user.Password = string.Empty;
            }
            return user;
        }
    }
}