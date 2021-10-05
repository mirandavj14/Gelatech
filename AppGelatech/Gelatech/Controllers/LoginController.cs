using Core.Services;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gelatech.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(User pUser)
        {
            try
            {
                User user = null;
                IServicesUser servicesUsers = new ServiceUsers();
                user = servicesUsers.GetUser(pUser);
                if (user != null)
                {
                    Session["User"] = user;
                    return RedirectToAction("Index", "Home");
                }
                TempData["Login"] = "Incorrect user data!";
                return View("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}