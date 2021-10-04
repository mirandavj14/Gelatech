using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ProductRepository
    {
        public List<Product> GetProducts()
        {
            List<Product> products = null;
            try
            {
                using (GelatechDBEntities context = new GelatechDBEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    products = context.Product.ToList();
                }
                return products;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
