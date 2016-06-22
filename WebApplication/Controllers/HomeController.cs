using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Entities;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VerifyCreditCard()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VerifyCreditCard(CreditCard card)
        {
            ViewBag.CreditCard = card;
            return View();
        }
    }
}