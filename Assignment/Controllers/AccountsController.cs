using Assignment.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Assignment.App_Start;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Assignment.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        private MyDbContext _dbContext;
        private MyUserManager _userManager;

        public MyUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<MyUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public AccountsController()
        {
        }

        public MyDbContext DbContext
        {
            get
            {
                return _dbContext ?? HttpContext.GetOwinContext().GetUserManager<MyDbContext>();

            }
            set { _dbContext = value; }
        }
        public ActionResult Index(string[] ids, string[] roleNames)
        {
            foreach (var id in ids)
            {
                UserManager.AddToRoles(id, roleNames);
            }
            Account acc = DbContext.Users.Find("");
            return View("Register");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            Account account = UserManager.Find(username, password);
            if (account == null)
            {
                return HttpNotFound();
            }
            // success
            var ident = UserManager.CreateIdentity(account, DefaultAuthenticationTypes.ApplicationCookie);
            //use the instance that has been created. 
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignIn(
                new AuthenticationProperties { IsPersistent = false }, ident);
            return Redirect("/Home");
        }


        // GET: Accounts
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Store(string username, string password)
        {
            var account = new Account()
            {
                UserName = username,
                Email = username,
                FirstName = "Xuan Hung",
                LastName = "Dao",
                Avatar = "avatar",
                Birthday = DateTime.Now,
                CreatedAt = DateTime.Now
            };
            IdentityResult result = await UserManager.CreateAsync(account, password);
            if (result.Succeeded)
            {
                UserManager.AddToRole(account.Id, "User");

                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                //string code = await UserManager.GenerateEmailConfirmationTokenAsync(account.Id);
                await UserManager.SendEmailAsync(account.Id, "Hello world! Please confirm your account", "<b>Please confirm your account</b> by clicking <a href=\"http://google.com.vn\">here</a>");
                return RedirectToAction("Index", "Home");
            }

            return View("Register");
        }

        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return Redirect("/Home");
        }
    }
}
