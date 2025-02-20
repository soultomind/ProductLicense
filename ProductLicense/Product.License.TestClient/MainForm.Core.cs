using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Product.License.TestClient
{
    partial class MainForm
    {
        private void SetCrypto(string path)
        {
            if (File.Exists(path))
            {
                Aes256CBCKeyData keyData = Aes256CBCKeyGenerator.ToAes256CBCKeyData(path);
                Crypto = new Aes256CBCCrypto(keyData.IVBase64, keyData.KeyBase64);
            }
            else
            {
                Aes256CBCKeyData keyData = new Aes256CBCKeyData();
                // "Hancominnostream" IVBase64
                keyData.IVBase64 = "SGFuY29taW5ub3N0cmVhbQ==";
                // "Copyright C Hancom !innostream.@" KeyBase64
                keyData.KeyBase64 = "Q29weXJpZ2h0IEMgSGFuY29tICFpbm5vc3RyZWFtLkA=";

                Crypto = new Aes256CBCCrypto(keyData.IVBase64, keyData.KeyBase64);
            }
        }

        internal FileDialogResult ShowSaveFileDialog(string filter, string fileName = "License")
        {
            string path = String.Empty;
            DialogResult dialogResult = DialogResult.OK;
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.InitialDirectory = Application.StartupPath;
                dlg.Filter = filter;
                dlg.FileName = fileName;

                dialogResult = dlg.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    path = dlg.FileName;
                }
            }

            return new SaveFileDialogResult() { Path = path, DialogResult = dialogResult };
        }
    }
}
