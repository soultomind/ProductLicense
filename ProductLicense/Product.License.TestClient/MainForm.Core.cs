using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.License.TestClient
{
    partial class MainForm
    {
        private void SetCrypto(string path)
        {
            if (File.Exists(path))
            {
                //Aes256CBCKeyData keyData = Aes256CBCKeyGenerator.ToAes256CBCKeyData(path);
                Aes256CBCKeyData keyData = new Aes256CBCKeyData();
                keyData.IVBase64 = "SGFuY29taW5ub3N0cmVhbQ==";
                keyData.KeyBase64 = "Q29weXJpZ2h0IOKTkiBIYW5jb20gaW5ub3N0cmVhbS4=";

                Crypto = new Aes256CBCCrypto(keyData.IVBase64, keyData.KeyBase64);
            }
        }
    }
}
