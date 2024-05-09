using BootcampProjectWS.DBModels;
using BootcampProjectWS.Helpers;
using BootcampProjectWS.Models;
using BootcampProjectWS.Repository;

namespace BootcampProjectWS.Bll
{
    public class UserBll
    {
        BootcampprojectContext ContextDB;

        public UserBll(BootcampprojectContext _context)
        {
            ContextDB = _context;
        }

        public GenericResponse<bool> InsertUser(InsertUserModelRequest model)
        {
            ContextDB.Database.BeginTransaction();

            try
            {
                UserRepository userRep = new UserRepository();

                User user = new User
                {
                    Username = model.Username,
                    Email = model.Email,
                    Password = (new MethodsEncryptHelper()).EncryptPassword(model.Password),
                    Rolid = model.Rolid,
                    Creationdate = DateTime.Now,
                    Statusid = model.Statusid,
                };

                userRep.InsertUser(ContextDB, user);

                ContextDB.Database.CommitTransaction();

                return new GenericResponse<bool>
                {
                    StatusCode = 200,
                    Data = true,
                    Message = "Usuario registrado exitósamente"
                };
            }
            catch (Exception ex)
            {
                ContextDB.Database.RollbackTransaction();

                return new GenericResponse<bool>
                {
                    StatusCode = 500,
                    Data = false,
                    Message = "Ocurrió un error al ingresar el usuario"
                };
            }

        }
    }
}
