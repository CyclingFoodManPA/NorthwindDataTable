using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NorthwindDataTable.Context;
using NorthwindDataTable.ViewModels;

namespace NorthwindDataTable.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethod()
        {
            NorthwindEntities db = new NorthwindEntities();
            var vm = (from c in db.Customers
                      select new CustomerListViewModel
                      {
                        CustomerID = c.CustomerID,
                        CompanyName = c.CompanyName,
                        ContactName = c.ContactName,
                        City = c.City,
                        Country = c.Country
                      }).ToList();
            return Json(vm);
        }
    }
}