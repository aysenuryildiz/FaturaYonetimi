﻿using Entities;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Security.Claims;

namespace MVCAPP.BLL
{
    public class UserAuth
    {
        public void SignIn(LoginModel model, IAuthenticationManager authenticationManager)
        {
            var claims = new Claim[]
          {
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim(ClaimTypes.Email, model.Email),
                 new Claim(ClaimTypes.Name, model.Email)
                //new Claim(ClaimTypes.Role,"Admin")
                          };

            var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(identity);
        }
    }
}