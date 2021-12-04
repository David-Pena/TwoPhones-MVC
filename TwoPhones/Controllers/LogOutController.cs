using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TwoPhones.Controllers
{
    public class LogOutController : Controller
    {
        // GET: LogOut
        public ActionResult LogOut()
        {
            Session["User"] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}