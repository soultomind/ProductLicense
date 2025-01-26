using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Product.License
{
    public class AesCryptoServiceProviderCreateData
    {
        public int FeedbackSize { get; set; }
        public int KeySize { get; set; }
        public int BlockSize { get; set; }
        public string KeyBase64 { get; set; }
        public string IVBase64 { get; set; }
        public CipherMode CipherMode { get; set; } = CipherMode.CBC;
        public PaddingMode PaddingMode { get; set; } = PaddingMode.PKCS7;
    }
}
