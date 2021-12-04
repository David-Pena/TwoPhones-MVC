using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwoPhones.Models;

namespace TwoPhones.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ingresar(string user, string password)
        {
            try
            {
                using (twoPhonesEntities1 DB = new twoPhonesEntities1())
                {
                    var _user = (from row in DB.users
                              where row.email == user && row.password == password && row.idState == 1
                              select row).FirstOrDefault();

                    if (_user == null)
                    {
                        return Content("User Not Found :(");
                    }else
                    {
                        Session["User"] = _user.idNumber;
                        Session["Role"] = _user.role;
                        Session["Name"] = _user.name + " " + _user.lastname;
                        Session["Id"] = _user.id;
                        return Content("1");
                    }
                }
            } catch (Exception ex)
            {
                return Content("Error: " + ex.Message);
            }
        }
    }
}