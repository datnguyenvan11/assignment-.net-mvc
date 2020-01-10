using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment.Models;

namespace Assignment.Controllers
{
    public class ClientviewController : Controller
    {
        private MyDbContext db = new MyDbContext();

        public ActionResult ByCategory(string id)
        {
            ViewData["category"] = db.Markets.Find(id);
            var listStudent = db.Coins.Where(s => s.MarketId == id).ToList(); // lọc theo category
            return View("Index", listStudent);
        }

        // GET: Clientview

        public ViewResult Index(string market, string searchString, string currentFilter)
        {

            var coins = from s in db.Coins
                select s;

            if (searchString == null)
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                coins = coins.Where(s => s.Name.Contains(searchString) || s.BaseAsset.Contains(searchString) && s.MarketId.Contains(market));
            }
            ViewBag.market=new SelectList(db.Markets,"Id","Name" );
            return View(coins.ToList());
        }
    }
}