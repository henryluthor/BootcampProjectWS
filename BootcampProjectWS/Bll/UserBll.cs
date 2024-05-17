using BootcampProjectWS.DBModels;
using BootcampProjectWS.Helpers;
using BootcampProjectWS.Models;
using BootcampProjectWS.Repository;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

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
            bool usernameValid;            
            string usernameInvalidMessage = "Usuario no válido.";
            bool passwordValid;
            string passwordInvalidMessage = "Contraseña no válida.";

            usernameValid = ValidateUsername(model.Username);
            passwordValid = ValidatePassword(model.Password);

            string? responseMessage = null;

            if(usernameValid && passwordValid)
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
                        Statusid = 1 //In DB active status have id 1
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
                        Message = "Ocurrió un error al tratar de ingresar el usuario"
                    };
                }
            }
            else
            {
                if(!usernameValid)
                {
                    responseMessage = usernameInvalidMessage;
                    if(!passwordValid)
                    {
                        responseMessage = responseMessage + " " + passwordInvalidMessage;
                    }
                }
                else
                {
                    responseMessage = passwordInvalidMessage;
                }

                return new GenericResponse<bool>
                {
                    StatusCode = 500,
                    Data = false,
                    Message = responseMessage
                };
                
            }

        }


        public GenericResponse<User> GetUserByUsername(string username)
        {
            //ContextDB.Database.BeginTransaction();

            try
            {
                UserRepository userRep = new UserRepository(); 

                User userFound = userRep.SelectUserByUsername(ContextDB, username);

                User user = userFound;
                user.Password = (new MethodsEncryptHelper().DecryptPassword(userFound.Password));

                return new GenericResponse<User>
                {
                    StatusCode = 200,
                    Data = user,
                    Message = ""
                };
            }
            catch
            {
                //ContextDB.Database.RollbackTransaction();

                return new GenericResponse<User>
                {
                    StatusCode = 500,
                    Message = "No se encontró el usuario"
                };
            }
        }

        public bool ValidateUsername(string username)
        {
            //rule for username:
            //Minimum 8 characters, maximun 20 characters, can have lowercase o uppercase letters, and at least one number:
            string usernamePattern = @"^(?=.*\d)[a-zA-Z\d]{8,20}$";

            return Regex.IsMatch(username, usernamePattern);
        }

        public bool ValidatePassword(string password)
        {
            //rule for password:
            //Minimum 8 characters, maximun 30 characters, at least one uppercase letter, at least one lowercase letter and at least one number:
            string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,30}$";

            return Regex.IsMatch(password, passwordPattern);
        }
    }
}
