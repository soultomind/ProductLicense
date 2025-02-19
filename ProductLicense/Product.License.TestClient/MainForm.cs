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
        public LicenseFileData LicenseFileData { get; internal set; }
        public ICrypto Crypto { get; internal set; }

        private IList<byte> ivEncryptedBase64Bytes;
        private IList<byte> keyEncryptedBase64Bytes;
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
                SetCrypto(path);
            }
        }

        #region GroupBox LicenseCrypto

        public string BeforePlainTextLicenseProductData
        {
            get { return richTextBoxBeforePlainTextLicenseProductData.Text; }
            set { richTextBoxBeforePlainTextLicenseProductData.Text = value; }
        }

        public string EnryptionPlainTextLicenseProductData
        {
            get { return richTextBoxEnryptionPlainTextLicenseProductData.Text; }
            set { richTextBoxEnryptionPlainTextLicenseProductData.Text = value; }
        }

        public string AfterPlainTextLicenseProductData
        {
            get { return richTextBoxAfterPlainTextLicenseProductData.Text; }
            set { richTextBoxAfterPlainTextLicenseProductData.Text = value; }
        }

        private void InitGroupBoxLicenseCrypto()
        {

        }

        private void ButtonDecryptLicenseProductData_Click(object sender, EventArgs e)
        {
            string encryptedText = richTextBoxEncryptedtLicenseData.Text;
            string plainText = Crypto.Decrypt(encryptedText);

            LicenseProductData licenseProductData = LicenseProductData.Parse(plainText);
            if (licenseProductData != null)
            {
                textBoxRuntimeEnvironment.Text = licenseProductData.RuntimeEnvironment.ToString();

                textBoxExecKeyValuePairs.Text = licenseProductData.ExecMachineGuid;
                textBoxProductIds.Text = licenseProductData.SplitCharProductIds;
                dateTimePickerIssueDate.Value = licenseProductData.IssueDateTime;
                dateTimePickerExpireDate.Value = licenseProductData.ExpireDateTime;
                textBoxLicenseNo.Text = licenseProductData.LicenseNo;
                textBoxCustomerName.Text = licenseProductData.CustomerName;
                textBoxProjectName.Text = licenseProductData.ProjectName;
                textBoxOperationMode.Text = licenseProductData.OperationMode.ToString();
            }
        }

        private void ButtonGenerateLicenseProductDataPlainText_Click(object sender, EventArgs e)
        {
            OperationMode operationMode = (OperationMode)Enum.Parse(typeof(OperationMode), textBoxOperationMode.Text);
            string strProductIds = textBoxProductIds.Text;
            DateTime issueDateTime = dateTimePickerIssueDate.Value;
            DateTime expireDateTime = dateTimePickerExpireDate.Value;
            LicenseProductData licenseProductData = LicenseProductData.New(
                operationMode, strProductIds, issueDateTime, expireDateTime);

            if (textBoxExecKeyValuePairs.Text.Length > 0)
            {
                // Client
                RuntimeEnvironment runtimeEnvironment = (RuntimeEnvironment)Enum.Parse(typeof(RuntimeEnvironment), textBoxRuntimeEnvironment.Text);
                licenseProductData.KeyValuePairs.Add(typeof(RuntimeEnvironment).Name, runtimeEnvironment.ToString());

                string[] execKeyValuePairs = textBoxExecKeyValuePairs.Text.Split('&');
                for (int i = 0; i < execKeyValuePairs.Length; i++)
                {
                    string keyValuePair = execKeyValuePairs[i];
                    string key = keyValuePair.Split('=')[0];
                    string value = keyValuePair.Split('=')[1];
                    licenseProductData.KeyValuePairs.Add(key, value);
                }
            }

            licenseProductData.LicenseNo = textBoxLicenseNo.Text;
            licenseProductData.CustomerName = textBoxCustomerName.Text;
            licenseProductData.ProjectName = textBoxProjectName.Text;

            string beforePlainText = licenseProductData.GeneratePlainText();
            BeforePlainTextLicenseProductData = beforePlainText;
        }

        private void ButtonEncryptionPlainTextLicenseProductData_Click(object sender, EventArgs e)
        {
            string beforePlainText = BeforePlainTextLicenseProductData;
            string encryptedText = Crypto.Encrypt(beforePlainText);
            EnryptionPlainTextLicenseProductData = encryptedText;
        }

        private void ButtonEncryptionPlainTextLicenseProductDataCreateFile_Click(object sender, EventArgs e)
        {
            string encryptedText = EnryptionPlainTextLicenseProductData;

            FileDialogResult result = ShowSaveFileDialog(LicenseManager.DataFileFilter, "InitLicenseProduct");
            if (result.DialogResult != DialogResult.OK)
            {
                return;
            }

            using (StreamWriter sw = new StreamWriter(result.Path))
            {
                sw.WriteLine(encryptedText);
            }
        }

        private async void ButtonDecryptionPlainTextLicenseProductData_Click(object sender, EventArgs e)
        {
            string encryptedText = EnryptionPlainTextLicenseProductData;
            string decryptedText = Crypto.Decrypt(encryptedText);
            AfterPlainTextLicenseProductData = decryptedText;

            await SetLabelLicenseProductDataResultTextAsync();
        }

        private async Task SetLabelLicenseProductDataResultTextAsync()
        {
            await Task.Delay(1000);
            if (BeforePlainTextLicenseProductData.Equals(AfterPlainTextLicenseProductData))
            {
                labelLicenseProductDataResult.Text = "결과 : 성공";
            }
            else
            {
                labelLicenseProductDataResult.Text = "결과 : 실패";
            }

            await Task.Delay(3000);
            labelLicenseProductDataResult.Text = "";
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

        private async void ButtonAes256Base64Data_Click(object sender, EventArgs e)
        {
            string ivPlainText = richTextBoxAes256IVText.Text.Replace("\n", "");
            string ivEncryptedBase64 = null;
            string ivDecryptedKeyBase64 = null;
            IList<byte> ivEncryptedBase64Bytes = null;

            bool iv = false, key = false;
            if (Aes256CBCKeyGenerator.TryGetEncryptedIVBase64(ivPlainText, out ivEncryptedBase64, out ivEncryptedBase64Bytes))
            {
                if (!Aes256CBCCrypto.IsValidIVBase64Ex(ivEncryptedBase64))
                {
                    await SetLabelLicenseKeyAes256ResultTextAsync(false, "!IsValidIVBase64(ivEncryptedBase64)");
                    return;
                }


                if (Aes256CBCKeyGenerator.TryGetDecryptedBase64(ivEncryptedBase64Bytes, out ivDecryptedKeyBase64))
                {
                    Trace.WriteLine("ivEncryptedBase64=" + ivEncryptedBase64);
                    Trace.WriteLine("ivDecryptedKeyBase64=" + ivDecryptedKeyBase64);

                    string decryptedIvPlainText = ConvertUtility.Base64Decode(ivDecryptedKeyBase64);
                    Trace.WriteLine("decryptedIvPlainText=" + decryptedIvPlainText);

                    if (ivPlainText.Equals(decryptedIvPlainText))
                    {
                        iv = true;
                    }
                }
                else
                {
                    await SetLabelLicenseKeyAes256ResultTextAsync(false, "ivEncryptedBase64Bytes => ivDecryptedKeyBase64 실패");
                    return;
                }
            }
            else
            {
                await SetLabelLicenseKeyAes256ResultTextAsync(false, "ivPlainText => Base64 실패");
                return;
            }

            string keyPlainText = richTextBoxAes256KeyText.Text.Replace("\n", "");
            string keyEncryptedBase64 = null;
            string keyDecryptedKeyBase64 = null;
            IList<byte> keyEncryptedBase64Bytes = null;
            if (Aes256CBCKeyGenerator.TryGetEncryptedKeyBase64(keyPlainText, out keyEncryptedBase64, out keyEncryptedBase64Bytes))
            {
                if (!Aes256CBCCrypto.IsValidKeyBase64Ex(keyEncryptedBase64))
                {
                    await SetLabelLicenseKeyAes256ResultTextAsync(false, "!IsValidIVBase64(keyEncryptedBase64)");
                    return;
                }

                if (Aes256CBCKeyGenerator.TryGetDecryptedBase64(keyEncryptedBase64Bytes, out keyDecryptedKeyBase64))
                {
                    Trace.WriteLine("keyEncryptedBase64=" + keyEncryptedBase64);
                    Trace.WriteLine("keyDecryptedKeyBase64=" + keyDecryptedKeyBase64);

                    string decryptedKeyPlainText = ConvertUtility.Base64Decode(keyDecryptedKeyBase64);
                    Trace.WriteLine("decryptedKeyPlainText=" + decryptedKeyPlainText);

                    if (keyPlainText.Equals(decryptedKeyPlainText))
                    {
                        key = true;
                    }
                }
                else
                {
                    await SetLabelLicenseKeyAes256ResultTextAsync(false, "keyEncryptedBase64Bytes => keyDecryptedKeyBase64 실패");
                    return;
                }
            }
            else
            {
                await SetLabelLicenseKeyAes256ResultTextAsync(false, "keyPlainText => Base64 실패");
                return;
            }

            bool result = iv && key;
            if (result)
            {
                //ivEncryptedBase64
                //keyEncryptedBase64

                this.ivEncryptedBase64Bytes = ivEncryptedBase64Bytes;
                this.keyEncryptedBase64Bytes = keyEncryptedBase64Bytes;

                richTextBoxAes256IVBase64.Text = ivEncryptedBase64;
                richTextBoxAes256KeyBase64.Text = keyEncryptedBase64;
            }
            await SetLabelLicenseKeyAes256ResultTextAsync(result);

            if (result)
            {
                buttonCreateLicenseKeyFile.Visible = true;
            }
        }

        private void ButtonCreateLicenseKeyFile_Click(object sender, EventArgs e)
        {
            FileDialogResult result = ShowSaveFileDialog(LicenseManager.KeyFileFilter);
            if (result.DialogResult != DialogResult.OK)
            {
                return;
            }

            string ivEncryptedBase64 = richTextBoxAes256IVBase64.Text;
            string keyEncryptedBase64 = richTextBoxAes256KeyBase64.Text;

            //this.ivEncryptedBase64Bytes = ivEncryptedBase64Bytes;
            //this.keyEncryptedBase64Bytes = keyEncryptedBase64Bytes;

            FileStream fsWrite = new FileStream(result.Path, FileMode.OpenOrCreate, FileAccess.Write);
            for (int i = 0; i < ivEncryptedBase64Bytes.Count; i++)
            {
                byte value = ivEncryptedBase64Bytes[i];
                fsWrite.WriteByte(value);
            }

            for (int i = 0; i < keyEncryptedBase64Bytes.Count; i++)
            {
                byte value = keyEncryptedBase64Bytes[i];
                fsWrite.WriteByte(value);
            }

            fsWrite.Flush();
            fsWrite.Close();

            MessageBox.Show(this, "라이선스 키 파일 생성 완료", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async Task SetLabelLicenseKeyAes256ResultTextAsync(bool result, string causeText = null)
        {
            await Task.Delay(1000);

            if (result)
            {
                labelLicenseKeyAes256Result.Text = String.Format("{0}={1}", "결과", "성공");
            }
            else
            {
                labelLicenseKeyAes256Result.Text = String.Format("{0}={1}, 이유={2}", "결과", "실패", causeText);
            }

            await Task.Delay(3000);

            labelLicenseKeyAes256Result.Text = "";
        }
    }
}
