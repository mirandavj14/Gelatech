using Core.Services;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gelatech.Controllers
{
    public class OrderController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Orden()
        {
            IServicesProduct servicesArticulos = new ServiceProduct();
            ViewBag.Product = servicesArticulos.GetProductAll();
            //List<ViewModelOrder> lista = new List<ViewModelOrden>();
            //Session["Order"] = lista;
            return View();
        }
    }
}