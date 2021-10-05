using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gelatech.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IServicesProduct servicesProduct = new ServiceProduct();
            ViewBag.Product = servicesProduct.GetProductAll();
            return View();
        }
    }
}