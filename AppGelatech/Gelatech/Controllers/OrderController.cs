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
            var productInvoicesInSession = Session["ProductInvoices"];
            var invoice = Session["Invoice"];
            var x = productInvoicesInSession == null ? ViewBag.productInvoices = new List<ProductInvoice>() : ViewBag.productInvoices = (List<ProductInvoice>)Session["ProductInvoices"];
            var y = invoice == null ? ViewBag.invoice = new Invoice() : ViewBag.invoice = (Invoice)Session["Invoice"];
            ServiceProduct servicesProduct = new ServiceProduct();
            ViewBag.products = servicesProduct.GetProductAll();
            return View();
        }

        public ActionResult AddDiscount(int discount)
        {
            Session["Discount"] = discount;
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

            // Get applied discount from session
            int discount = (int)Session["Discount"];

            // calculate Invoice values and save to session
            Invoice invoice = new Invoice();
            invoice.SubTotal = CalculateSubtotal(productInvoices);
            invoice.Taxes = CalculateTaxes((decimal)invoice.SubTotal);           
            invoice.Discount = CalculateDiscount((decimal)invoice.SubTotal, discount);
            invoice.Total = CalculateTotal((decimal)invoice.SubTotal, (decimal)invoice.Taxes, (decimal)invoice.Discount);
            Session["Invoice"] = invoice;

            // saved the result list to the session and return
            Session["ProductInvoices"] = productInvoices;
            return RedirectToAction("Index");
        }

        public ActionResult Orden()
        {
            return View();
        }

        public decimal CalculateSubtotal(List<ProductInvoice> productInvoices)
        {
            decimal? subtotal = 0;
            foreach (var item in productInvoices)
            {
                subtotal += (item.Product.Price * item.Quantity);
            }
            return (decimal)subtotal;
        }

        public decimal CalculateTaxes(decimal subtotal)
        {
            return (decimal)0.13 * subtotal;
        }

        public decimal CalculateTotal(decimal subtotal, decimal taxes, decimal discount)
        {
            return (subtotal + taxes) - discount;
        }

        public decimal CalculateDiscount(decimal subtotal, int pDiscount)
        {
            decimal discountPercentage = pDiscount / 100;
            return subtotal * discountPercentage;
        }
    }
}