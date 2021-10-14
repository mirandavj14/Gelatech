using Core.Services;
using Infrastructure.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Gelatech.Controllers
{
    public class OrderController : Controller
    {
        public ActionResult Index()
        {
            var productInvoicesInSession = Session["ProductInvoices"];
            var invoice = Session["Invoice"];
            var x = productInvoicesInSession == null ? ViewBag.productInvoices = new List<ProductInvoice>() : ViewBag.productInvoices = (List<ProductInvoice>)Session["ProductInvoices"];
            var y = invoice == null ? ViewBag.invoice = new Invoice() : ViewBag.invoice = (Invoice)Session["Invoice"];
            ServiceProduct servicesProduct = new ServiceProduct();
            ViewBag.products = servicesProduct.GetProductAll();
            return View();
        }

        [System.Web.Http.HttpPost]
        public ActionResult AddDiscount(int discount)
        {
            ServiceInvoice serviceInvoice = new ServiceInvoice();
            Invoice invoice = (Invoice)Session["Invoice"];
            invoice.Discount = serviceInvoice.CalculateDiscount((decimal)invoice.SubTotal, discount);
            Session["Invoice"] = invoice;
            return RedirectToAction("Index");
        }

        public ActionResult AddProduct(ProductInvoice productInvoice)
        {
            // Get the full product object using the id in productInvoice
            ServiceProduct servicesProduct = new ServiceProduct();
            Product fullProduct = servicesProduct.GetProductByID(productInvoice.ProductId);
            productInvoice.Product = fullProduct;

            // Declare new list of ProductInvoice
            List<ProductInvoice> productInvoices = new List<ProductInvoice>();

            // Get Product Invoices saved in the session
            var productInvoicesInSession = Session["ProductInvoices"];

            // If there is already Product Invoices saved in the session
            if (productInvoicesInSession != null)
            {
                // Get Product Invoices saved in the session
                productInvoices = (List<ProductInvoice>)Session["ProductInvoices"];

                // Check if the product productInvoice is already in the list
                ProductInvoice invoiceProductAlreadyAdded = productInvoices.FirstOrDefault(p => p.ProductId.Equals(productInvoice.ProductId));

                // If the invoice Product is Already Added
                if (invoiceProductAlreadyAdded != null)
                {
                    // update the quantity adn update the object
                    invoiceProductAlreadyAdded.Quantity += productInvoice.Quantity;
                    productInvoices.Remove(invoiceProductAlreadyAdded);
                    productInvoices.Add(invoiceProductAlreadyAdded);
                }

                // If the invoice Product is NOT Already Added
                else
                {
                    // add the invoice Product to the list
                    productInvoices.Add(productInvoice);
                }
            }

            // If there is NOT already Product Invoices saved in the session
            else
            {
                // add the invoice Product to the list
                productInvoices.Add(productInvoice);
            }

            // Invoice Service instance to perform operations
            ServiceInvoice serviceInvoice = new ServiceInvoice();

            Invoice invoice = new Invoice();
            invoice.SubTotal = serviceInvoice.CalculateSubtotal(productInvoices);
            invoice.Taxes = serviceInvoice.CalculateTaxes((decimal)invoice.SubTotal);

            // Check if the invoice is already created
            var invoiceInSession = Session["Invoice"];
                
            if (invoiceInSession != null)
            {
                var auxInvoice = (Invoice)Session["Invoice"];
                invoice.Discount = auxInvoice.Discount;
                invoice.Total = serviceInvoice.CalculateTotal((decimal)invoice.SubTotal, (decimal)invoice.Taxes, (decimal)invoice.Discount);
            }
            else
            {
                invoice.Discount = 0;
                invoice.Total = serviceInvoice.CalculateTotal((decimal)invoice.SubTotal, (decimal)invoice.Taxes, (decimal)invoice.Discount);
            }
            Session["Invoice"] = invoice;
            Session["ProductInvoices"] = productInvoices;
            return RedirectToAction("Index");
        }

        [System.Web.Http.HttpPost]
        public ActionResult SaveInvoice(string payment)
        {
            Invoice invoice = (Invoice)Session["Invoice"];
            invoice.Payment = payment;
            invoice.Date = DateTime.Now;
            List<ProductInvoice> productInvoices = (List<ProductInvoice>)Session["ProductInvoices"];
            ServiceInvoice serviceInvoice = new ServiceInvoice();
            serviceInvoice.SaveInvoice(invoice, productInvoices);
            return RedirectToAction("Index","Login");
        }
    }
}