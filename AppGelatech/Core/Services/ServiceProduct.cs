using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ServiceProduct : IServicesProduct
    {
        public List<Product> GetProductAll()
        {
            IProductRepository repository = new ProductRepository();
            return repository.GetProductAll();
        }

        public Product GetProductByID(int id)
        {
            IProductRepository repository = new ProductRepository();
            return repository.GetProductByID(id);
        }
    }
}
