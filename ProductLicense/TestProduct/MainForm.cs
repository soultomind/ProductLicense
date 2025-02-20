using Product.License;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProduct
{
    public partial class MainForm : Form
    {
        private Product.License.LicenseManager licenseManager;
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            Text = String.Format("{0} {1}", assembly.GetName().Name, assembly.GetName().Version.ToString());

            Product.License.LicenseManager.UserCrypto = CreateCrypto;
        }

        private ICrypto CreateCrypto(string licenseKeyFilePath)
        {
            string ivBase64 = String.Empty, keyBase64 = String.Empty;

            Aes256CBCKeyData keyData = Aes256CBCKeyGenerator.ToAes256CBCKeyData(licenseKeyFilePath);
            return new Aes256CBCCrypto(keyData.IVBase64, keyData.KeyBase64);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (!Product.License.LicenseManager.CanVerify)
            {
                if (Product.License.LicenseManager.MachineGuidException != null)
                {
                    RichTextBoxConsole_AppendTextLine("MachineGuid 값 가져오는데 문제가 있습니다. 아래 에러 내용을 참고하세요");
                    RichTextBoxConsole_AppendTextLine(Product.License.LicenseManager.MachineGuidException.StackTrace);
                }

                if (Product.License.LicenseManager.MacAddressException != null)
                {
                    RichTextBoxConsole_AppendTextLine("MacAddress 값 가져오는데 문제가 있습니다. 아래 에러 내용을 참고하세요");
                    RichTextBoxConsole_AppendTextLine(Product.License.LicenseManager.MacAddressException.StackTrace);
                }

                return;
            }

            if (!File.Exists(Product.License.LicenseManager.LicenseKeyFilePath))
            {
                RichTextBoxConsole_AppendTextLine(
                    string.Format("{0} 파일이 존재하지 않습니다.", Product.License.LicenseManager.LicenseKeyFilePath));
                return;
            }

            if (!File.Exists(Product.License.LicenseManager.ExecLicenseProductDataFilePath))
            {
                RichTextBoxConsole_AppendTextLine(
                    string.Format("{0} 파일이 존재하지 않습니다.", Product.License.LicenseManager.ExecLicenseProductDataFilePath));

                if (!File.Exists(Product.License.LicenseManager.InitLicenseProductDataFilePath))
                {
                    
                    RichTextBoxConsole_AppendTextLine(
                        string.Format("{0} 파일이 존재하지 않습니다. \n제품에 사용되는 라이선스 초기화 데이터가 존재하지 않습니다. 관리자에게 문의하세요", 
                        Product.License.LicenseManager.InitLicenseProductDataFilePath));
                    return;
                }
                else
                {
                    licenseManager = Product.License.LicenseManager.
                        NewInitLicenseManager(
                            Product.License.LicenseManager.LicenseKeyFilePath,
                            Product.License.LicenseManager.InitLicenseProductDataFilePath,
                            Product.License.LicenseManager.ExecLicenseProductDataFilePath);
                }
            }
            else
            {
                licenseManager = Product.License.LicenseManager.
                        NewExecLicenseManager(
                            Product.License.LicenseManager.LicenseKeyFilePath,
                            Product.License.LicenseManager.ExecLicenseProductDataFilePath);
            }

            if (!licenseManager.Verify())
            {
                RichTextBoxConsole_AppendTextLine("실패! 이유=" + licenseManager.ProcessResult.ToString());
            }
            else
            {
                RichTextBoxConsole_AppendTextLine("성공!");
            }
        }

        private void ToolStripButtonClipBoard_Click(object sender, EventArgs e)
        {
            string text = richTextBoxConsole.Text;
            Clipboard.SetText(text);
        }

        private void RichTextBoxConsole_AppendText(string text)
        {
            if (InvokeRequired)
            {
                richTextBoxConsole.Invoke(new Action<string>(RichTextBoxConsole_AppendText), text);
                return;
            }

            richTextBoxConsole.AppendText(text);
            richTextBoxConsole.ScrollToCaret();
        }

        private void RichTextBoxConsole_AppendTextLine(string text)
        {
            if (InvokeRequired)
            {
                richTextBoxConsole.Invoke(new Action<string>(RichTextBoxConsole_AppendTextLine), text);
                return;
            }

            richTextBoxConsole.AppendText(text);
            richTextBoxConsole.AppendText(Environment.NewLine);
            richTextBoxConsole.ScrollToCaret();
        }
    }
}
