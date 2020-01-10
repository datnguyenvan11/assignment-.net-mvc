using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment.Models
{
    public class Util
    {
        private static MyDbContext db = new MyDbContext();

        private static List<Market> _listCategories;

        public static List<Market> GetCategories()
        {
            if (_listCategories == null)
            {
                _listCategories = db.Markets.ToList();
            }
            return _listCategories;
        }
        public static List<SelectListItem> GetCategoriesAsDropDownList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (_listCategories == null)
            {
                _listCategories = db.Markets.ToList();
            }

            foreach (var category in _listCategories)
            {
                list.Add(new SelectListItem { Text = category.Name, Value = category.Id.ToString() });
            }
            return list;
        }

        public static void SetCategories(List<Market> categories)
        {
            _listCategories = categories;
        }
    }
}