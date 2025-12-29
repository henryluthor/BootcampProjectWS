namespace BootcampProjectWS.Models
{
    public class LoginResponseModel
    {
        public bool LoginSuccessful { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
