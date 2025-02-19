using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Product.License.TestClient
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ExecuteContext.InitEntry();

            Application.Run(new MainForm(new LicenseFileData()
            {
                KeyFilePath = LicenseManager.LicenseKeyFilePath,
                InitDataFilePath = LicenseManager.InitLicenseProductDataFilePath,
                ExecDataFilePath = LicenseManager.ExecLicenseProductDataFilePath
            }));
        }
    }
}
