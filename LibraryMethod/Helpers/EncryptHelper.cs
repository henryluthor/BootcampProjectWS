using ApiPolizasElectronicas.Models.Complementos;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Engines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMethod.Helpers
{
    public class EncryptHelper
    {
        public string EncKey { get; set; }
        public string EncMackKey { get; set; }

        public string EncryptValue(string Value)
        {
            var aes = new Encryptor<AesEngine, Sha256Digest>(Encoding.UTF8, Encoding.UTF8.GetBytes(EncKey), Encoding.UTF8.GetBytes(EncMackKey));
            return aes.Encrypt(Value);
        }

        public string DecryptValue(string Value)
        {
            var aes = new Encryptor<AesEngine, Sha256Digest>(Encoding.UTF8, Encoding.UTF8.GetBytes(EncKey), Encoding.UTF8.GetBytes(EncMackKey));
            return aes.Decrypt(Value);
        }
    }
}
