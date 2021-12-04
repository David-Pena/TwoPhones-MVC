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
    public class PhoneController : Controller
    {
        // GET: Phone
        public ActionResult Index()
        {
            List<PhoneTableViewModel> lst = null;
            using (Models.twoPhonesEntities1 DB = new Models.twoPhonesEntities1())
            {
                var idNumber = System.Web.HttpContext.Current.Session["User"];
                var role = System.Web.HttpContext.Current.Session["Role"];

                if (role != null && role.ToString() == "ADMIN")
                {
                    lst = (from row in DB.phones
                           select new PhoneTableViewModel
                           {
                               Id = row.id,
                               IdUser = row.idUser,
                               Number = row.number,
                               Balance = row.balance,
                               Status = row.status,
                               IsPublic = row.isPublic
                           }).ToList();
                }
                
                if (role != null && role.ToString() == "USER")
                {
                    lst = (from row in DB.phones
                           where row.idUser == idNumber.ToString()
                           select new PhoneTableViewModel
                           {
                               Id = row.id,
                               IdUser = row.idUser,
                               Number = row.number,
                               Balance = row.balance,
                               Status = row.status,
                               IsPublic = row.isPublic
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
        public ActionResult Add(PhoneViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var DB = new twoPhonesEntities1())
            {
                phone _phone = new phone();

                _phone.idUser = Session["User"].ToString();
                _phone.number = model.Number;
                _phone.balance = model.Balance;
                _phone.status = model.Status;
                _phone.isPublic = model.IsPublic;

                DB.phones.Add(_phone);

                DB.SaveChanges();
            }

            return Redirect(Url.Content("~/Phone/"));
        }

        public ActionResult Edit(int Id)
        {
            EditPhoneViewModel model = new EditPhoneViewModel();

            using (var DB = new twoPhonesEntities1())
            {
                // Obtenemos el telefono que le corresponde el ID que se le pasó a la función
                var _phone = DB.phones.Find(Id);

                // Hacemos el proceso contrario al de Agregar, asignamos a nuestros campos
                // los datos que obtenemos del model
                model.Number = _phone.number;
                model.Balance = _phone.balance;
                model.Status = _phone.status;
                model.IsPublic = _phone.isPublic;
                model.Id = _phone.id;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditPhoneViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var DB = new twoPhonesEntities1())
            {
                // Obtenemos el telefono que le corresponde el ID que se le pasó a la función
                var _phone = DB.phones.Find(model.Id);

                _phone.number = model.Number;
                _phone.balance = model.Balance;
                _phone.status = model.Status;
                _phone.isPublic = model.IsPublic;

                DB.Entry(_phone).State = System.Data.Entity.EntityState.Modified;
                DB.SaveChanges();
            }

            return Redirect(Url.Content("~/Phone/"));

        }

        public ActionResult Delete(EditPhoneViewModel model)
        {
            //var isUserDeleted = false;
            using (var DB = new twoPhonesEntities1())
            {
                // Obtenemos la cedula del usuario logueado para tener seguimiento
                // de la cantidad de teléfonos
                var _userIdNumber = System.Web.HttpContext.Current.Session["User"];

                // Obtenemos el teléfono que le corresponde el ID que se le pasó a la función.
                var _phone = DB.phones.Find(model.Id);

                // Eliminamos el registro
                DB.Entry(_phone).State = System.Data.Entity.EntityState.Deleted;
                DB.SaveChanges();

                //var phoneCounter = from row in DB.phones
                //                   where row.idUser == _userIdNumber.ToString()
                //                   select row;

                //// Si el contador es 0 indica que no quedan mas telefonos
                //// entonces se borra al usuario también
                //if (phoneCounter.Count() == 0) {
                //    var _userId = (int)System.Web.HttpContext.Current.Session["Id"];
                //    var _user = DB.users.Find(_userId);

                //    DB.Entry(_user).State = System.Data.Entity.EntityState.Deleted;
                //    DB.SaveChanges();

                //    // Al haber eliminado al usuario, debemos redirigirnos a la vista Login
                //    isUserDeleted = true;
                //}else {
                //    isUserDeleted = false;
                //}

            }
            return Content("1");
            //if (!isUserDeleted)
            //    return Content("1");
            //else
            //{
            //    return Content("2");
            //}

        }

    }
}