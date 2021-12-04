using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwoPhones.Controllers;
using TwoPhones.Models;

namespace TwoPhones.Filters
{
    public class ValidateSession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var currentUser = (string)HttpContext.Current.Session["User"];

            if (currentUser == null)
            {
                // Si no existe una session y trato de entrar a Home, me devuelve para el Login
                if (filterContext.Controller is LoginController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Login/Index");
                }
            }else
            {
                // Si existe la session y trato de entrar al Login, me devuelve para el Home
                if (filterContext.Controller is LoginController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}