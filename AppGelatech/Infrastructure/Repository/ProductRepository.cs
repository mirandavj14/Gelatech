using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ProductRepository: IProductRepository
    {
        public List<Product> GetProductAll()
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

        public Product GetProductByID(int id)
        {
            Product product = null;
            try
            {

                using (GelatechDBEntities context = new GelatechDBEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    product = context.Product.Find(id);
                }

                return product;
            }
            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
   
}
