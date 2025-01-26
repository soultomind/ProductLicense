using Product.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Product.License
{
    public class Aes256CBCCrypto : Aes256Crypto
    {
        #region Reference

        // https://aspdotnet.tistory.com/2836
        // https://gist.github.com/RichardHan/0848a25d9466a21f1f38

        #endregion

        #region Static

        static Aes256CBCCrypto()
        {
            // 맨 마지막 ==를 제외한 나머지 앞 22개의 Base64 문자는 아무거나 와도 됨
            //AesIvBase64 = "bsxnWolsAy12kCfWuyrnqg=="; //24자
            AesIvBase64 = "SGFuY29taW5ub3N0cmVhbQ==";

            //SGFuY29taW5ub3N0cmVhbQ==

            // 맨 마지막 =를 제외한 나머지 앞 43개의 Base64 문자는 아무거나 와도 됨
            //AesKeyBase64 = "AXe8YwuIn56xt3FPWTZFlAa14EHdPAdN9FaZ9RQWihc="; //44자
            AesKeyBase64 = "Q29weXJpZ2h0IOKTkiBIYW5jb20gaW5ub3N0cmVhbS4=";

            //Q29weXJpZ2h0IOKTkiBIYW5jb20gaW5ub3N0cmVhbS4=
        }

        public static readonly string AesIvBase64;
        public static readonly string AesKeyBase64;

        public static bool IsValidIVBase64(string ivBase64)
        {
            return StringUtility.IsBase64(ivBase64);
        }

        public static bool IsValidKeyBase64(string keyBase64)
        {
            return StringUtility.IsBase64(keyBase64);
        }

        #endregion

        public string IVBase64
        {
            get { return ivBase64; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                if (!(value.Length == 24))
                {
                    throw new ArgumentException(nameof(IVBase64) + "is length 24");
                }

                if (!StringUtility.IsBase64(value))
                {
                    throw new ArgumentException(String.Format("Can't convert {0} is base64", nameof(IVBase64)));
                }

                ivBase64 = value;
            }
        }
        private string ivBase64;

        public string KeyBase64
        {
            get { return keyBase64; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                if (!(value.Length == 44))
                {
                    throw new ArgumentException(nameof(KeyBase64) + "is length 44");
                }

                if (!StringUtility.IsBase64(value))
                {
                    throw new ArgumentException(String.Format("Can't convert {0} is base64", nameof(KeyBase64)));
                }

                keyBase64 = value;
            }
        }
        private string keyBase64;

        public Aes256CBCCrypto()
            : this(AesIvBase64, AesKeyBase64)
        {

        }

        public Aes256CBCCrypto(string ivBase64, string keyBase64)
        {
            IVBase64 = ivBase64;
            KeyBase64 = keyBase64;
        }

        public AesCryptoServiceProvider CreateAesCryptoServiceProvider()
        {
            AesCryptoServiceProvider aes = CreateAesCryptoServiceProvider(
                new AesCryptoServiceProviderCreateData()
                {
                    KeySize = 256,
                    BlockSize = 128,
                    IVBase64 = IVBase64,
                    KeyBase64 = KeyBase64,
                    CipherMode = CipherMode.CBC,
                    PaddingMode = PaddingMode.PKCS7
                }
            );
            return aes;
        }

        public override string Encrypt(string plainText)
        {
            byte[] encrypted = null;
            using (AesCryptoServiceProvider aes = CreateAesCryptoServiceProvider())
            {
                ICryptoTransform transform = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cryptoStream))
                        {
                            sw.Write(plainText);
                        }

                        encrypted = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(encrypted);
        }

        public override string Decrypt(string encryptedText)
        {
            string decryptedText = null;

            byte[] buffer = Convert.FromBase64String(encryptedText);
            using (AesCryptoServiceProvider aes = CreateAesCryptoServiceProvider())
            {
                ICryptoTransform transform = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cryptoStream))
                        {
                            decryptedText = sr.ReadToEnd();
                        }
                    }
                }
            }

            return decryptedText;
        }
    }
}
