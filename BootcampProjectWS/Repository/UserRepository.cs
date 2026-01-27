using BootcampProjectWS.DBModels;
using BootcampProjectWS.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BootcampProjectWS.Repository
{
    public class UserRepository
    {
        public User? InsertUser(BootcampprojectContext context, User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

        public User? SelectUserByUsername(BootcampprojectContext context, string username)
        {
            User user = context.Users.SingleOrDefault(x => x.Username == username);
            return user;
        }
    }
}
