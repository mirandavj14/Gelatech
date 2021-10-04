using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UserRepository
    {
        public User GetUser(User pUser)
        {
            User user = null;
            try
            {
                using (GelatechDBEntities context = new GelatechDBEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    user = context.User.Where(u => u.Username == pUser.Username && u.Password == pUser.Password).FirstOrDefault();
                }
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
