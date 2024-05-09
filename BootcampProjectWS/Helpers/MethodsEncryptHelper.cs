using LibraryMethod.Helpers;

namespace BootcampProjectWS.Helpers
{
    public class MethodsEncryptHelper
    {
        public string EncryptPassword(string value)
        {
            var SectionKey = (new ConfigurationBuilder()).AddJsonFile("appsettings.json").Build().GetSection("passwordEncrypt");
            EncryptHelper encryptH = new EncryptHelper
            {
                EncKey = SectionKey.GetValue<string>("key"),
                EncMackKey = SectionKey.GetValue<string>("macKey")
            };

            return encryptH.EncryptValue(value);
        }

        public string DecryptPassword(string value)
        {
            var sectionKey = (new ConfigurationBuilder()).AddJsonFile("appsettings.json").Build().GetSection("passwordEncrypt");
            EncryptHelper encryptH = new EncryptHelper
            {
                EncKey = sectionKey.GetValue<string>("key"),
                EncMackKey = sectionKey.GetValue<string>("macKey")
            };

            return encryptH.DecryptValue(value);
        }
    }
}
