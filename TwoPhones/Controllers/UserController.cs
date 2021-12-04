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
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<UserTableViewModel> lst = null;
            using (Models.twoPhonesEntities1 DB = new Models.twoPhonesEntities1())
            {
                var idNumber = System.Web.HttpContext.Current.Session["User"];
                var role = System.Web.HttpContext.Current.Session["Role"];

                if (role != null && role.ToString() == "ADMIN")
                {
                    lst = (from row in DB.users
                           select new UserTableViewModel
                           {
                               Id = row.id,
                               Name = row.name,
                               LastName = row.lastname,
                               Address = row.address,
                               Identification = row.idNumber,
                               Email = row.email,
                               AccountNumber = row.accNumber,
                               ExpirationDate = row.expDate,
                               CVV = row.cvv,
                               Role = row.role
                           }).ToList();
                }

                if (role != null && role.ToString() == "USER")
                {
                    lst = (from row in DB.users
                           where row.idNumber == idNumber.ToString()
                           select new UserTableViewModel
                           {
                               Id = row.id,
                               Name = row.name,
                               LastName = row.lastname,
                               Address = row.address,
                               Identification = row.idNumber,
                               Email = row.email,
                               AccountNumber = row.accNumber,
                               ExpirationDate = row.expDate,
                               CVV = row.cvv,
                               Role = row.role
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
        public ActionResult Add(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using ( var DB = new twoPhonesEntities1())
            {
                user _user = new user();

                _user.idState = 1;
                _user.email = model.Email;
                _user.password = model.Password;
                _user.name = model.Name;
                _user.lastname = model.LastName;
                _user.address = model.Address;
                _user.accNumber = model.AccountNumber;
                _user.expDate = model.ExpirationDate;
                _user.cvv = model.CVV;
                _user.idNumber = model.Identification;
                _user.role = model.Role;

                DB.users.Add(_user);

                DB.SaveChanges();
            }

            return Redirect(Url.Content("~/User/"));
        }
    
        public ActionResult Edit(int Id)
        {
            EditUserViewModel model = new EditUserViewModel();

            using (var DB = new twoPhonesEntities1 ())
            {
                // Obtenemos el usuario que le corresponde el ID que se le pasó a la función
                var _user = DB.users.Find(Id);

                // Hacemos el proceso contrario al de Agregar, asignamos a nuestros campos
                // los datos que obtenemos del model
                model.Email = _user.email;
                model.Name = _user.name;
                model.LastName = _user.lastname;
                model.Address = _user.address;
                model.AccountNumber = _user.accNumber;
                model.ExpirationDate = _user.expDate;
                model.CVV = _user.cvv;
                model.Identification = _user.idNumber;
                model.Role = _user.role;
                model.Id = _user.id;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var DB = new twoPhonesEntities1())
            {
                // Obtenemos el usuario que le corresponde el ID que se le pasó a la función
                var _user = DB.users.Find(model.Id);

                _user.email = model.Email;
                _user.name = model.Name;
                _user.lastname = model.LastName;
                _user.address = model.Address;
                _user.accNumber = model.AccountNumber;
                _user.expDate = model.ExpirationDate;
                _user.cvv = model.CVV;
                _user.idNumber = model.Identification;
                _user.role = model.Role;

                if (model.Password != null && model.Password.Trim() != null)
                {
                    _user.password = model.Password;
                }

                DB.Entry(_user).State = System.Data.Entity.EntityState.Modified;
                DB.SaveChanges();
            }

            return Redirect(Url.Content("~/User/"));

        }

        public ActionResult Delete(EditUserViewModel model)
        {

            using (var DB = new twoPhonesEntities1())
            {
                // Obtenemos el usuario que le corresponde el ID que se le pasó a la función.
                var _user = DB.users.Find(model.Id);
                // Eliminamos el registro
                DB.Entry(_user).State = System.Data.Entity.EntityState.Deleted;
                DB.SaveChanges();
            }

            return Content("1");

        }
    }
}