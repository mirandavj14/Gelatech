using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IProductRepository
    {
        List<Product> GetProductAll();

        Product GetProductByID(int id);


    }
}
