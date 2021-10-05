using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ServiceUsers : IServicesUser
    {
        public User GetUser(User user)
        {
            IUserRepository repository = new UserRepository();
            return repository.GetUser(user);
        }
    }
}
