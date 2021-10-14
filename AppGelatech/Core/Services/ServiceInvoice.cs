using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ServiceInvoice
    {
        public void SaveInvoice(Invoice invoice, List<ProductInvoice> productInvoices)
        {
            int retorno = 0;
            try
            {
                using (GelatechDBEntities context = new GelatechDBEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    context.Invoice.Add(invoice);

                    foreach (var item in productInvoices)
                    {
                        item.InvoiceId = invoice.Id;
                        context.ProductInvoice.Add(item);
                    }
                    retorno = context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Invoice GetInvoice(int id)
        {
            Invoice invoice = null;
            try
            {
                using (GelatechDBEntities context = new GelatechDBEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    invoice = context.Invoice.Find(id);
                }

                return invoice;
            }
            catch (Exception e)
            {
                throw e;
            }
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
            decimal discountPercentage = (decimal)pDiscount / 100;
            return subtotal * discountPercentage;
        }
    }
}
