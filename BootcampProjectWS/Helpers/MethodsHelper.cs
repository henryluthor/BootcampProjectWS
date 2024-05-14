using BootcampProjectWS.Models;

namespace BootcampProjectWS.Helpers
{
    public class MethodsHelper
    {

        private string dateTimeFormat = (new ConfigurationBuilder()).AddJsonFile("appsettings.json").Build().GetSection("dateTimeFormat").Value;

        public string ConvertDatetimeToString(DateTime dateTime)
        {
            return dateTime.ToString(dateTimeFormat);
        }

        public DateTime ConvertStringToDate(string dateTime)
        {
            return DateTime.ParseExact(dateTime, dateTimeFormat, System.Globalization.CultureInfo.InvariantCulture);
        }


        public string CreateTokenSession(int userId)
        {
            int secondsValidate = (new ConfigurationBuilder()).AddJsonFile("appsettings.json").Build().GetSection("tokenSession").GetValue<int>("secondsValidate");

            TokenSessionModel modelTokenSesion = new TokenSessionModel
            {
                UserId = userId,
                DateExpired = ConvertDatetimeToString(DateTime.Now.AddSeconds(secondsValidate)),
            };

            MethodsEncryptHelper encryptH = new MethodsEncryptHelper();
            return encryptH.EncryptToken(modelTokenSesion.ToJson());
        }

        public TokenSessionModel? GetModelSessionByToken(string token)
        {
            MethodsEncryptHelper encryptH = new MethodsEncryptHelper();
            string modelSessionString = encryptH.DecrypToken(token);
            TokenSessionModel modelSession = TokenSessionModel.FromJson(modelSessionString);

            return modelSession;
        }

        public string? ValidateTokenSession(string token)
        {
            try
            {
                var modelSession = GetModelSessionByToken(token);
                if(DateTime.Now.CompareTo(ConvertStringToDate(modelSession.DateExpired)) < 0)
                {
                    return null;
                }
                else
                {
                    return "La sesión ha caducado.";
                }
            }
            catch (Exception ex)
            {
                return "La sesión no es válida.";
            }
        }


    }
}
