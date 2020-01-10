using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment.App_Start;
using Assignment.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace Assignment
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(MyDbContext.Create);
            app.CreatePerOwinContext<MyUserManager>(MyUserManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Accounts/Login"),

            });

        }
    }
}