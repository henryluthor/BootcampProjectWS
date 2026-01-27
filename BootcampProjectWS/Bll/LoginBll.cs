using BootcampProjectWS.DBModels;
using BootcampProjectWS.Helpers;
using BootcampProjectWS.Models;
using BootcampProjectWS.Repository;

namespace BootcampProjectWS.Bll
{
    public class LoginBll
    {
        BootcampprojectContext ContextDB;

        public LoginBll(BootcampprojectContext contextDB)
        {
            ContextDB = contextDB;
        }

        public GenericResponse<LoginResponseModel> GetLoginUSer(LoginRequestModel model)
        {            

            try
            {
                UserRepository userRep = new UserRepository();
                User userFound = userRep.SelectUserByUsername(ContextDB, model.userName);

                if (userFound != null) // if a user was found
                {
                    // verify user status is ACTIVE - statusId = 1
                    if (userFound.Statusid == 1)
                    {
                        // verify passwords match
                        string passFindDecrypted = (new MethodsEncryptHelper().DecryptPassword(userFound.Password));

                        if (passFindDecrypted == model.password)
                        {
                            //login was successful
                            return new GenericResponse<LoginResponseModel>
                            {
                                StatusCode = 200,
                                Data = new LoginResponseModel
                                {
                                    LoginSuccessful = true,
                                    UserName = userFound.Username,
                                    Token = (new MethodsHelper()).CreateTokenSession(userFound.Userid)
                                },
                                Message = MessageHelper.LoginSuccess
                            };
                        }
                        else
                        {
                            //loging was unsuccessful
                            return new GenericResponse<LoginResponseModel>
                            {
                                StatusCode = 500,
                                Message = MessageHelper.LoginError
                            };
                        }
                    }
                    else
                    {
                        // user is NOT activated
                        return new GenericResponse<LoginResponseModel>
                        {
                            StatusCode = 500,
                            Message = MessageHelper.LoginError
                        };
                    }
                    
                }
                else
                {
                    // user not found
                    return new GenericResponse<LoginResponseModel>
                    {
                        StatusCode = 500,
                        Message = MessageHelper.LoginError
                    };
                }

            }
            catch (Exception ex)
            {
                return new GenericResponse<LoginResponseModel>
                {
                    StatusCode = 500,
                    Message = MessageHelper.LoginError
                };
            }
            
        }
    }
}
