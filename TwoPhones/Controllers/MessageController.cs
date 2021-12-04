using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwoPhones.Models;
using TwoPhones.Models.TableViewModels;
using TwoPhones.Models.ViewModels;

namespace TwoPhones.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult Index()
        {
            List<MessageTableViewModel> lst = null;
            using (Models.twoPhonesEntities1 DB = new Models.twoPhonesEntities1())
            {
                var _userId = (int)System.Web.HttpContext.Current.Session["Id"];
                var role = System.Web.HttpContext.Current.Session["Role"];
                var senderObject = DB.phones.Find(_userId);

                if (role != null && role.ToString() == "ADMIN")
                {
                    lst = (from row in DB.messages
                           select new MessageTableViewModel
                           {
                               Id = row.id,
                               From = row.numberFrom,
                               To = row.numberTo,
                               Message = row.text,
                           }).ToList();
                }

                if (role != null && role.ToString() == "USER")
                {
                    lst = (from row in DB.messages
                           select new MessageTableViewModel
                           {
                               Id = row.id,
                               From = row.numberFrom,
                               To = row.numberTo,
                               Message = row.text,
                           }).ToList();
                }

            }

            return View(lst);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(MessageViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var DB = new twoPhonesEntities1())
            {
                var _userId = (int)System.Web.HttpContext.Current.Session["Id"];
                var senderObject = DB.phones.Find(_userId);

                message _message = new message();

                _message.numberFrom = model.From;
                _message.numberTo = model.To;
                _message.text = model.Message;

                DB.messages.Add(_message);

                DB.SaveChanges();
            }

            return Redirect(Url.Content("~/Message/"));
        }

    }
}