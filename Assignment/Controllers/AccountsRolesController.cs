using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Assignment.Controllers
{

    // GET: AccountsRoles
    [Authorize(Roles = "Admin")]
    public class AccountsRolesController : Controller
        {
            private MyDbContext dbContext = new MyDbContext();
            private RoleManager<AccountRole> roleManager;

            public AccountsRolesController()
            {
                RoleStore<AccountRole> roleStore = new RoleStore<AccountRole>(dbContext);
                roleManager = new RoleManager<AccountRole>(roleStore);
            }
            // GET: AccountRoles
            public ActionResult Create()
            {
                return View();
            }

            [HttpPost]
            public ActionResult Store(string name)
            {
                var role = new AccountRole()
                {
                    Name = name,
                    CreatedAt = DateTime.Now
                };
                var result = roleManager.Create(role);
                return View("Create");
            }
        }
    }
