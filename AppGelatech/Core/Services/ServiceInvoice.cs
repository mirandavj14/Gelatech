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
