using Infrastructure.Models;
using Infrastructure.Repository;
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
                UserRepository userRepository = new UserRepository();
                User user = userRepository.GetUser(pUser);
                if (user != null)
                {
                    Session["User"] = user;
                    return RedirectToAction("Index", "Order");
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