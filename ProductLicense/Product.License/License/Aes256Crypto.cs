using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Product.License
{
    public abstract class Aes256Crypto : ICrypto
    {
        public virtual AesCryptoServiceProvider CreateAesCryptoServiceProvider(AesCryptoServiceProviderCreateData createData)
        {
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            if (createData.FeedbackSize > 0)
            {
                aes.FeedbackSize = createData.FeedbackSize;
            }

            aes.KeySize = createData.KeySize;
            aes.BlockSize = createData.BlockSize;
            aes.IV = Convert.FromBase64String(createData.IVBase64);
            aes.Key = Convert.FromBase64String(createData.KeyBase64);
            // Cipher Block Chaining Mode
            aes.Mode = createData.CipherMode;
            aes.Padding = createData.PaddingMode;
            return aes;
        }

        public abstract string Encrypt(string plainText);
        public abstract string Decrypt(string enryptedText);
    }
}
