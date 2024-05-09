using BootcampProjectWS.DBModels;
using BootcampProjectWS.Models;

namespace BootcampProjectWS.Repository
{
    public class UserRepository
    {
        public User? InsertUser(BootcampprojectContext context, User user)
        {
            //User user = new User
            //{
            //    Username = Model.Username,
            //    Email = Model.Email,
            //    Password = Model.Password,
            //    Rolid = Model.Rolid,
            //    Creationdate = DateTime.Now,
            //    Statusid = Model.Statusid
            //};

            context.Users.Add(user);

            context.SaveChanges();

            return user;

            //try
            //{
            //    context.SaveChanges();
            //    return null;
            //}
            //catch (Exception ex)
            //{
            //    return ex.InnerException.ToString();
            //}
        }
    }
}
