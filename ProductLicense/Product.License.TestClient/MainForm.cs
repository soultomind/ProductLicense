using Product.Extension;
using Product.Utility;
using Product.Wmi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

            InitGroupBoxLicenseCrypto();
            InitGroupBoxTest();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (LicenseFileData != null)
            {
                string path = LicenseFileData.KeyFilePath;
                SetAes256Crypto(path);
            }
        }

        #region GroupBox LicenseCrypto

        private void InitGroupBoxLicenseCrypto()
        {

        }

        #endregion

        #region GroupBox Test

        private void InitGroupBoxTest()
        {
            comboBoxWmiQueryItem.SelectedIndex = 0;
            textBoxWmiQuery.Text = comboBoxWmiQueryItem.Items[0].ToString();
        }


        private void ButtonPrintSystemInfo_Click(object sender, EventArgs e)
        {
            richTextBoxConsole.Clear();

            #region 시스템/정보

            RichTextBoxConsoleAppendTextLine("시스템/정보 관련 정보");

            #region 시스템/정보/장치사양

            RichTextBoxConsoleAppendTextLine("장치사양");
            RichTextBoxConsoleAppendTextLine("제품 ID=" + OperatingSystemExtension.ProductId);

            #endregion

            #region 시스템/정보/Windows 사양

            RichTextBoxConsoleAppendTextLine("Windows 사양");
            RichTextBoxConsoleAppendTextLine("에디션=" + OperatingSystemExtension.Edition);
            RichTextBoxConsoleAppendTextLine("버전=" + OperatingSystemExtension.Version);
            RichTextBoxConsoleAppendTextLine("OS 빌드=" + OperatingSystemExtension.Build);

            #endregion

            #endregion

            #region 기타

            #region HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Cryptography\\MachineGuid

            string machineGuid = null;
            Exception exception = null;
            if (RegistryUtility.TryGetMachineGuid(out machineGuid, out exception))
            {
                RichTextBoxConsoleAppendTextLine("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Cryptography\\MachineGuid");
                RichTextBoxConsoleAppendTextLine("MachineGuid=" + machineGuid);
            }
            else
            {
                RichTextBoxConsoleAppendTextLine("Failed TryGetMachineGuid");
                RichTextBoxConsoleAppendTextLine(exception.StackTrace);
            }

            #endregion

            #region MacAddress

            string macAddress = null;
            if (NetworkUtility.TryGetMacAddress(out macAddress, out exception))
            {
                RichTextBoxConsoleAppendTextLine("MacAddress=" + macAddress);
            }
            else
            {
                RichTextBoxConsoleAppendTextLine("Failed TryGetMacAddress");
                RichTextBoxConsoleAppendTextLine(exception.StackTrace);
            }

            #endregion

            #endregion
        }

        private void ButtonExecuteWmiQuery_Click(object sender, EventArgs e)
        {
            richTextBoxConsole.Clear();

            string wmiNameSpaceName = textBoxWmiNamespace.Text;
            string wmiQuery = textBoxWmiQuery.Text;
            string result = WmiEnvironment.ToStringQueryResult(wmiNameSpaceName, wmiQuery, false);
            RichTextBoxConsoleAppendTextLine(result);
        }

        private void ComboBoxWmiQueryItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                int selectedIndex = comboBox.SelectedIndex;
                textBoxWmiQuery.Text = comboBoxWmiQueryItem.Items[selectedIndex].ToString();
            }
        }


        private void RichTextBoxConsoleToolStripMenuItemClear_Click(object sender, EventArgs e)
        {
            richTextBoxConsole.Clear();
        }

        private void RichTextBoxConsoleAppendText(string text)
        {
            if (InvokeRequired)
            {
                richTextBoxConsole.Invoke(new Action<string>(RichTextBoxConsoleAppendText), text);
                return;
            }

            richTextBoxConsole.AppendText(text);
        }

        private void RichTextBoxConsoleAppendTextLine(string text)
        {
            if (InvokeRequired)
            {
                richTextBoxConsole.Invoke(new Action<string>(RichTextBoxConsoleAppendTextLine), text);
                return;
            }

            richTextBoxConsole.AppendText(text);
            richTextBoxConsole.AppendText(Environment.NewLine);
        }

        private void LinkLabelWmi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel linkLabel = sender as LinkLabel;
            if (linkLabel != null)
            {
                Process.Start(linkLabel.Text);
            }
        }

        #endregion
    }
}
