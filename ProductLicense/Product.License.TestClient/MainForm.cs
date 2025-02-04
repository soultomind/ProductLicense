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

namespace Product.License.TestClient
{
    public partial class MainForm : Form
    {
        public LicenseFileData LicenseFileData { get; set; }
        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(LicenseFileData licenseFileData)
            : this()
        {
            LicenseFileData = licenseFileData;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            Text = String.Format("{0} {1}", assembly.GetName().Name, assembly.GetName().Version.ToString());
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            string path = LicenseFileData.KeyFilePath;
            SetCrypto(path);
        }

        
    }
}
