
namespace Product.License.TestClient
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBoxLicesneCrypto = new System.Windows.Forms.GroupBox();
            this.labelLicenseKeyAes256Result = new System.Windows.Forms.Label();
            this.labelAes256IVBase64 = new System.Windows.Forms.Label();
            this.labelAes256KeyBase64 = new System.Windows.Forms.Label();
            this.buttonAes256Base64Data = new System.Windows.Forms.Button();
            this.richTextBoxAes256IVBase64 = new System.Windows.Forms.RichTextBox();
            this.richTextBoxAes256KeyBase64 = new System.Windows.Forms.RichTextBox();
            this.labelAes256IVText = new System.Windows.Forms.Label();
            this.labelAes256KeyText = new System.Windows.Forms.Label();
            this.richTextBoxAes256IVText = new System.Windows.Forms.RichTextBox();
            this.richTextBoxAes256KeyText = new System.Windows.Forms.RichTextBox();
            this.buttonGenerateLicenseProductDataPlainText = new System.Windows.Forms.Button();
            this.groupBoxCrypto = new System.Windows.Forms.GroupBox();
            this.buttonEncryptionPlainTextLicenseProductDataCreateFile = new System.Windows.Forms.Button();
            this.labelLicenseProductDataResult = new System.Windows.Forms.Label();
            this.labelAfterPlainTextLicenseProductData = new System.Windows.Forms.Label();
            this.labelBeforePlainTextLicenseProductData = new System.Windows.Forms.Label();
            this.richTextBoxAfterPlainTextLicenseProductData = new System.Windows.Forms.RichTextBox();
            this.buttonEncryptionPlainTextLicenseProductData = new System.Windows.Forms.Button();
            this.labelEnryptionPlainTextLicenseProductData = new System.Windows.Forms.Label();
            this.richTextBoxBeforePlainTextLicenseProductData = new System.Windows.Forms.RichTextBox();
            this.buttonDecryptionPlainTextLicenseProductData = new System.Windows.Forms.Button();
            this.richTextBoxEnryptionPlainTextLicenseProductData = new System.Windows.Forms.RichTextBox();
            this.buttonDecryptLicenseProductData = new System.Windows.Forms.Button();
            this.groupBoxLicenseProductData = new System.Windows.Forms.GroupBox();
            this.labelInputDescription = new System.Windows.Forms.Label();
            this.textBoxRuntimeEnvironment = new System.Windows.Forms.TextBox();
            this.labelRuntimeEnvironment = new System.Windows.Forms.Label();
            this.labelExecKeyValuePairs = new System.Windows.Forms.Label();
            this.textBoxProductIds = new System.Windows.Forms.TextBox();
            this.textBoxExecKeyValuePairs = new System.Windows.Forms.TextBox();
            this.dateTimePickerIssueDate = new System.Windows.Forms.DateTimePicker();
            this.labelOperationMode = new System.Windows.Forms.Label();
            this.dateTimePickerExpireDate = new System.Windows.Forms.DateTimePicker();
            this.labelProjectName = new System.Windows.Forms.Label();
            this.textBoxLicenseNo = new System.Windows.Forms.TextBox();
            this.labelCustomerName = new System.Windows.Forms.Label();
            this.textBoxCustomerName = new System.Windows.Forms.TextBox();
            this.labelLicenseNo = new System.Windows.Forms.Label();
            this.textBoxProjectName = new System.Windows.Forms.TextBox();
            this.labelExpireDate = new System.Windows.Forms.Label();
            this.textBoxOperationMode = new System.Windows.Forms.TextBox();
            this.labelIssueDate = new System.Windows.Forms.Label();
            this.labelProductIds = new System.Windows.Forms.Label();
            this.labelEncryptedLicenseData = new System.Windows.Forms.Label();
            this.richTextBoxEncryptedtLicenseData = new System.Windows.Forms.RichTextBox();
            this.groupBoxTest = new System.Windows.Forms.GroupBox();
            this.textBoxWmiQuery = new System.Windows.Forms.TextBox();
            this.labelWmiQuery = new System.Windows.Forms.Label();
            this.labelWmiQueryItem = new System.Windows.Forms.Label();
            this.comboBoxWmiQueryItem = new System.Windows.Forms.ComboBox();
            this.labelWmiNamespace = new System.Windows.Forms.Label();
            this.textBoxWmiNamespace = new System.Windows.Forms.TextBox();
            this.buttonExecuteWmiQuery = new System.Windows.Forms.Button();
            this.buttonPrintSystemInfo = new System.Windows.Forms.Button();
            this.linkLabelWmi = new System.Windows.Forms.LinkLabel();
            this.richTextBoxConsole = new System.Windows.Forms.RichTextBox();
            this.contextMenuStripRichTextBoxConsole = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemClear = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxLicesneCrypto.SuspendLayout();
            this.groupBoxCrypto.SuspendLayout();
            this.groupBoxLicenseProductData.SuspendLayout();
            this.groupBoxTest.SuspendLayout();
            this.contextMenuStripRichTextBoxConsole.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxLicesneCrypto
            // 
            this.groupBoxLicesneCrypto.Controls.Add(this.labelLicenseKeyAes256Result);
            this.groupBoxLicesneCrypto.Controls.Add(this.labelAes256IVBase64);
            this.groupBoxLicesneCrypto.Controls.Add(this.labelAes256KeyBase64);
            this.groupBoxLicesneCrypto.Controls.Add(this.buttonAes256Base64Data);
            this.groupBoxLicesneCrypto.Controls.Add(this.richTextBoxAes256IVBase64);
            this.groupBoxLicesneCrypto.Controls.Add(this.richTextBoxAes256KeyBase64);
            this.groupBoxLicesneCrypto.Controls.Add(this.labelAes256IVText);
            this.groupBoxLicesneCrypto.Controls.Add(this.labelAes256KeyText);
            this.groupBoxLicesneCrypto.Controls.Add(this.richTextBoxAes256IVText);
            this.groupBoxLicesneCrypto.Controls.Add(this.richTextBoxAes256KeyText);
            this.groupBoxLicesneCrypto.Controls.Add(this.buttonGenerateLicenseProductDataPlainText);
            this.groupBoxLicesneCrypto.Controls.Add(this.groupBoxCrypto);
            this.groupBoxLicesneCrypto.Controls.Add(this.buttonDecryptLicenseProductData);
            this.groupBoxLicesneCrypto.Controls.Add(this.groupBoxLicenseProductData);
            this.groupBoxLicesneCrypto.Controls.Add(this.labelEncryptedLicenseData);
            this.groupBoxLicesneCrypto.Controls.Add(this.richTextBoxEncryptedtLicenseData);
            this.groupBoxLicesneCrypto.Location = new System.Drawing.Point(12, 12);
            this.groupBoxLicesneCrypto.Name = "groupBoxLicesneCrypto";
            this.groupBoxLicesneCrypto.Size = new System.Drawing.Size(1060, 606);
            this.groupBoxLicesneCrypto.TabIndex = 0;
            this.groupBoxLicesneCrypto.TabStop = false;
            this.groupBoxLicesneCrypto.Text = "라이선스 암복호화";
            // 
            // labelLicenseKeyAes256Result
            // 
            this.labelLicenseKeyAes256Result.AutoSize = true;
            this.labelLicenseKeyAes256Result.Location = new System.Drawing.Point(706, 159);
            this.labelLicenseKeyAes256Result.Name = "labelLicenseKeyAes256Result";
            this.labelLicenseKeyAes256Result.Size = new System.Drawing.Size(0, 15);
            this.labelLicenseKeyAes256Result.TabIndex = 18;
            // 
            // labelAes256IVBase64
            // 
            this.labelAes256IVBase64.AutoSize = true;
            this.labelAes256IVBase64.Location = new System.Drawing.Point(780, 31);
            this.labelAes256IVBase64.Name = "labelAes256IVBase64";
            this.labelAes256IVBase64.Size = new System.Drawing.Size(104, 15);
            this.labelAes256IVBase64.TabIndex = 61;
            this.labelAes256IVBase64.Text = "Aes256 IV Base64";
            // 
            // labelAes256KeyBase64
            // 
            this.labelAes256KeyBase64.AutoSize = true;
            this.labelAes256KeyBase64.Location = new System.Drawing.Point(780, 95);
            this.labelAes256KeyBase64.Name = "labelAes256KeyBase64";
            this.labelAes256KeyBase64.Size = new System.Drawing.Size(112, 15);
            this.labelAes256KeyBase64.TabIndex = 60;
            this.labelAes256KeyBase64.Text = "Aes256 Key Base64";
            // 
            // buttonAes256Base64Data
            // 
            this.buttonAes256Base64Data.Location = new System.Drawing.Point(730, 84);
            this.buttonAes256Base64Data.Name = "buttonAes256Base64Data";
            this.buttonAes256Base64Data.Size = new System.Drawing.Size(30, 30);
            this.buttonAes256Base64Data.TabIndex = 59;
            this.buttonAes256Base64Data.Text = "▶";
            this.buttonAes256Base64Data.UseVisualStyleBackColor = true;
            this.buttonAes256Base64Data.Click += new System.EventHandler(this.ButtonAes256Base64Data_Click);
            // 
            // richTextBoxAes256IVBase64
            // 
            this.richTextBoxAes256IVBase64.Location = new System.Drawing.Point(783, 49);
            this.richTextBoxAes256IVBase64.Name = "richTextBoxAes256IVBase64";
            this.richTextBoxAes256IVBase64.Size = new System.Drawing.Size(266, 37);
            this.richTextBoxAes256IVBase64.TabIndex = 58;
            this.richTextBoxAes256IVBase64.Text = "";
            // 
            // richTextBoxAes256KeyBase64
            // 
            this.richTextBoxAes256KeyBase64.Location = new System.Drawing.Point(783, 113);
            this.richTextBoxAes256KeyBase64.Name = "richTextBoxAes256KeyBase64";
            this.richTextBoxAes256KeyBase64.Size = new System.Drawing.Size(266, 37);
            this.richTextBoxAes256KeyBase64.TabIndex = 57;
            this.richTextBoxAes256KeyBase64.Text = "";
            // 
            // labelAes256IVText
            // 
            this.labelAes256IVText.AutoSize = true;
            this.labelAes256IVText.Location = new System.Drawing.Point(496, 31);
            this.labelAes256IVText.Name = "labelAes256IVText";
            this.labelAes256IVText.Size = new System.Drawing.Size(88, 15);
            this.labelAes256IVText.TabIndex = 56;
            this.labelAes256IVText.Text = "Aes256 IV Text";
            // 
            // labelAes256KeyText
            // 
            this.labelAes256KeyText.AutoSize = true;
            this.labelAes256KeyText.Location = new System.Drawing.Point(496, 95);
            this.labelAes256KeyText.Name = "labelAes256KeyText";
            this.labelAes256KeyText.Size = new System.Drawing.Size(96, 15);
            this.labelAes256KeyText.TabIndex = 55;
            this.labelAes256KeyText.Text = "Aes256 Key Text";
            // 
            // richTextBoxAes256IVText
            // 
            this.richTextBoxAes256IVText.Location = new System.Drawing.Point(499, 49);
            this.richTextBoxAes256IVText.Name = "richTextBoxAes256IVText";
            this.richTextBoxAes256IVText.Size = new System.Drawing.Size(208, 37);
            this.richTextBoxAes256IVText.TabIndex = 54;
            this.richTextBoxAes256IVText.Text = "Hancominnostream";
            // 
            // richTextBoxAes256KeyText
            // 
            this.richTextBoxAes256KeyText.Location = new System.Drawing.Point(499, 113);
            this.richTextBoxAes256KeyText.Name = "richTextBoxAes256KeyText";
            this.richTextBoxAes256KeyText.Size = new System.Drawing.Size(208, 37);
            this.richTextBoxAes256KeyText.TabIndex = 47;
            this.richTextBoxAes256KeyText.Text = "Copyright C Hancom !innostream.@\n";
            // 
            // buttonGenerateLicenseProductDataPlainText
            // 
            this.buttonGenerateLicenseProductDataPlainText.Location = new System.Drawing.Point(450, 224);
            this.buttonGenerateLicenseProductDataPlainText.Name = "buttonGenerateLicenseProductDataPlainText";
            this.buttonGenerateLicenseProductDataPlainText.Size = new System.Drawing.Size(30, 30);
            this.buttonGenerateLicenseProductDataPlainText.TabIndex = 53;
            this.buttonGenerateLicenseProductDataPlainText.Text = "▶";
            this.buttonGenerateLicenseProductDataPlainText.UseVisualStyleBackColor = true;
            this.buttonGenerateLicenseProductDataPlainText.Click += new System.EventHandler(this.ButtonGenerateLicenseProductDataPlainText_Click);
            // 
            // groupBoxCrypto
            // 
            this.groupBoxCrypto.Controls.Add(this.buttonEncryptionPlainTextLicenseProductDataCreateFile);
            this.groupBoxCrypto.Controls.Add(this.labelLicenseProductDataResult);
            this.groupBoxCrypto.Controls.Add(this.labelAfterPlainTextLicenseProductData);
            this.groupBoxCrypto.Controls.Add(this.labelBeforePlainTextLicenseProductData);
            this.groupBoxCrypto.Controls.Add(this.richTextBoxAfterPlainTextLicenseProductData);
            this.groupBoxCrypto.Controls.Add(this.buttonEncryptionPlainTextLicenseProductData);
            this.groupBoxCrypto.Controls.Add(this.labelEnryptionPlainTextLicenseProductData);
            this.groupBoxCrypto.Controls.Add(this.richTextBoxBeforePlainTextLicenseProductData);
            this.groupBoxCrypto.Controls.Add(this.buttonDecryptionPlainTextLicenseProductData);
            this.groupBoxCrypto.Controls.Add(this.richTextBoxEnryptionPlainTextLicenseProductData);
            this.groupBoxCrypto.Location = new System.Drawing.Point(499, 183);
            this.groupBoxCrypto.Name = "groupBoxCrypto";
            this.groupBoxCrypto.Size = new System.Drawing.Size(550, 410);
            this.groupBoxCrypto.TabIndex = 52;
            this.groupBoxCrypto.TabStop = false;
            this.groupBoxCrypto.Text = "LicenseProductData Crypto";
            // 
            // buttonEncryptionPlainTextLicenseProductDataCreateFile
            // 
            this.buttonEncryptionPlainTextLicenseProductDataCreateFile.Location = new System.Drawing.Point(386, 123);
            this.buttonEncryptionPlainTextLicenseProductDataCreateFile.Name = "buttonEncryptionPlainTextLicenseProductDataCreateFile";
            this.buttonEncryptionPlainTextLicenseProductDataCreateFile.Size = new System.Drawing.Size(149, 23);
            this.buttonEncryptionPlainTextLicenseProductDataCreateFile.TabIndex = 17;
            this.buttonEncryptionPlainTextLicenseProductDataCreateFile.Text = "암호화 파일 생성";
            this.buttonEncryptionPlainTextLicenseProductDataCreateFile.UseVisualStyleBackColor = true;
            this.buttonEncryptionPlainTextLicenseProductDataCreateFile.Click += new System.EventHandler(this.ButtonEncryptionPlainTextLicenseProductDataCreateFile_Click);
            // 
            // labelLicenseProductDataResult
            // 
            this.labelLicenseProductDataResult.AutoSize = true;
            this.labelLicenseProductDataResult.Location = new System.Drawing.Point(18, 382);
            this.labelLicenseProductDataResult.Name = "labelLicenseProductDataResult";
            this.labelLicenseProductDataResult.Size = new System.Drawing.Size(0, 15);
            this.labelLicenseProductDataResult.TabIndex = 16;
            // 
            // labelAfterPlainTextLicenseProductData
            // 
            this.labelAfterPlainTextLicenseProductData.AutoSize = true;
            this.labelAfterPlainTextLicenseProductData.Location = new System.Drawing.Point(18, 281);
            this.labelAfterPlainTextLicenseProductData.Name = "labelAfterPlainTextLicenseProductData";
            this.labelAfterPlainTextLicenseProductData.Size = new System.Drawing.Size(165, 15);
            this.labelAfterPlainTextLicenseProductData.TabIndex = 15;
            this.labelAfterPlainTextLicenseProductData.Text = "PlainText LicenseProductData";
            // 
            // labelBeforePlainTextLicenseProductData
            // 
            this.labelBeforePlainTextLicenseProductData.AutoSize = true;
            this.labelBeforePlainTextLicenseProductData.Location = new System.Drawing.Point(18, 28);
            this.labelBeforePlainTextLicenseProductData.Name = "labelBeforePlainTextLicenseProductData";
            this.labelBeforePlainTextLicenseProductData.Size = new System.Drawing.Size(165, 15);
            this.labelBeforePlainTextLicenseProductData.TabIndex = 14;
            this.labelBeforePlainTextLicenseProductData.Text = "PlainText LicenseProductData";
            // 
            // richTextBoxAfterPlainTextLicenseProductData
            // 
            this.richTextBoxAfterPlainTextLicenseProductData.BackColor = System.Drawing.Color.White;
            this.richTextBoxAfterPlainTextLicenseProductData.Location = new System.Drawing.Point(21, 299);
            this.richTextBoxAfterPlainTextLicenseProductData.Name = "richTextBoxAfterPlainTextLicenseProductData";
            this.richTextBoxAfterPlainTextLicenseProductData.Size = new System.Drawing.Size(514, 70);
            this.richTextBoxAfterPlainTextLicenseProductData.TabIndex = 12;
            this.richTextBoxAfterPlainTextLicenseProductData.Text = "";
            // 
            // buttonEncryptionPlainTextLicenseProductData
            // 
            this.buttonEncryptionPlainTextLicenseProductData.Location = new System.Drawing.Point(21, 120);
            this.buttonEncryptionPlainTextLicenseProductData.Name = "buttonEncryptionPlainTextLicenseProductData";
            this.buttonEncryptionPlainTextLicenseProductData.Size = new System.Drawing.Size(75, 23);
            this.buttonEncryptionPlainTextLicenseProductData.TabIndex = 8;
            this.buttonEncryptionPlainTextLicenseProductData.Text = "암호화 ▼";
            this.buttonEncryptionPlainTextLicenseProductData.UseVisualStyleBackColor = true;
            this.buttonEncryptionPlainTextLicenseProductData.Click += new System.EventHandler(this.ButtonEncryptionPlainTextLicenseProductData_Click);
            // 
            // labelEnryptionPlainTextLicenseProductData
            // 
            this.labelEnryptionPlainTextLicenseProductData.AutoSize = true;
            this.labelEnryptionPlainTextLicenseProductData.Location = new System.Drawing.Point(18, 152);
            this.labelEnryptionPlainTextLicenseProductData.Name = "labelEnryptionPlainTextLicenseProductData";
            this.labelEnryptionPlainTextLicenseProductData.Size = new System.Drawing.Size(211, 15);
            this.labelEnryptionPlainTextLicenseProductData.TabIndex = 13;
            this.labelEnryptionPlainTextLicenseProductData.Text = "PlainText 제품라이선스 암호화 데이터";
            // 
            // richTextBoxBeforePlainTextLicenseProductData
            // 
            this.richTextBoxBeforePlainTextLicenseProductData.BackColor = System.Drawing.Color.White;
            this.richTextBoxBeforePlainTextLicenseProductData.Location = new System.Drawing.Point(21, 46);
            this.richTextBoxBeforePlainTextLicenseProductData.Name = "richTextBoxBeforePlainTextLicenseProductData";
            this.richTextBoxBeforePlainTextLicenseProductData.Size = new System.Drawing.Size(514, 70);
            this.richTextBoxBeforePlainTextLicenseProductData.TabIndex = 9;
            this.richTextBoxBeforePlainTextLicenseProductData.Text = "";
            // 
            // buttonDecryptionPlainTextLicenseProductData
            // 
            this.buttonDecryptionPlainTextLicenseProductData.Location = new System.Drawing.Point(21, 246);
            this.buttonDecryptionPlainTextLicenseProductData.Name = "buttonDecryptionPlainTextLicenseProductData";
            this.buttonDecryptionPlainTextLicenseProductData.Size = new System.Drawing.Size(75, 23);
            this.buttonDecryptionPlainTextLicenseProductData.TabIndex = 10;
            this.buttonDecryptionPlainTextLicenseProductData.Text = "복호화 ▼";
            this.buttonDecryptionPlainTextLicenseProductData.UseVisualStyleBackColor = true;
            this.buttonDecryptionPlainTextLicenseProductData.Click += new System.EventHandler(this.ButtonDecryptionPlainTextLicenseProductData_Click);
            // 
            // richTextBoxEnryptionPlainTextLicenseProductData
            // 
            this.richTextBoxEnryptionPlainTextLicenseProductData.BackColor = System.Drawing.Color.White;
            this.richTextBoxEnryptionPlainTextLicenseProductData.Location = new System.Drawing.Point(21, 170);
            this.richTextBoxEnryptionPlainTextLicenseProductData.Name = "richTextBoxEnryptionPlainTextLicenseProductData";
            this.richTextBoxEnryptionPlainTextLicenseProductData.Size = new System.Drawing.Size(514, 70);
            this.richTextBoxEnryptionPlainTextLicenseProductData.TabIndex = 11;
            this.richTextBoxEnryptionPlainTextLicenseProductData.Text = "";
            // 
            // buttonDecryptLicenseProductData
            // 
            this.buttonDecryptLicenseProductData.Location = new System.Drawing.Point(79, 120);
            this.buttonDecryptLicenseProductData.Name = "buttonDecryptLicenseProductData";
            this.buttonDecryptLicenseProductData.Size = new System.Drawing.Size(30, 30);
            this.buttonDecryptLicenseProductData.TabIndex = 45;
            this.buttonDecryptLicenseProductData.Text = "▼";
            this.buttonDecryptLicenseProductData.UseVisualStyleBackColor = true;
            this.buttonDecryptLicenseProductData.Click += new System.EventHandler(this.ButtonDecryptLicenseProductData_Click);
            // 
            // groupBoxLicenseProductData
            // 
            this.groupBoxLicenseProductData.Controls.Add(this.labelInputDescription);
            this.groupBoxLicenseProductData.Controls.Add(this.textBoxRuntimeEnvironment);
            this.groupBoxLicenseProductData.Controls.Add(this.labelRuntimeEnvironment);
            this.groupBoxLicenseProductData.Controls.Add(this.labelExecKeyValuePairs);
            this.groupBoxLicenseProductData.Controls.Add(this.textBoxProductIds);
            this.groupBoxLicenseProductData.Controls.Add(this.textBoxExecKeyValuePairs);
            this.groupBoxLicenseProductData.Controls.Add(this.dateTimePickerIssueDate);
            this.groupBoxLicenseProductData.Controls.Add(this.labelOperationMode);
            this.groupBoxLicenseProductData.Controls.Add(this.dateTimePickerExpireDate);
            this.groupBoxLicenseProductData.Controls.Add(this.labelProjectName);
            this.groupBoxLicenseProductData.Controls.Add(this.textBoxLicenseNo);
            this.groupBoxLicenseProductData.Controls.Add(this.labelCustomerName);
            this.groupBoxLicenseProductData.Controls.Add(this.textBoxCustomerName);
            this.groupBoxLicenseProductData.Controls.Add(this.labelLicenseNo);
            this.groupBoxLicenseProductData.Controls.Add(this.textBoxProjectName);
            this.groupBoxLicenseProductData.Controls.Add(this.labelExpireDate);
            this.groupBoxLicenseProductData.Controls.Add(this.textBoxOperationMode);
            this.groupBoxLicenseProductData.Controls.Add(this.labelIssueDate);
            this.groupBoxLicenseProductData.Controls.Add(this.labelProductIds);
            this.groupBoxLicenseProductData.Location = new System.Drawing.Point(28, 183);
            this.groupBoxLicenseProductData.Name = "groupBoxLicenseProductData";
            this.groupBoxLicenseProductData.Size = new System.Drawing.Size(401, 410);
            this.groupBoxLicenseProductData.TabIndex = 44;
            this.groupBoxLicenseProductData.TabStop = false;
            this.groupBoxLicenseProductData.Text = "LicenseProductData";
            // 
            // labelInputDescription
            // 
            this.labelInputDescription.AutoSize = true;
            this.labelInputDescription.Location = new System.Drawing.Point(144, 70);
            this.labelInputDescription.Name = "labelInputDescription";
            this.labelInputDescription.Size = new System.Drawing.Size(159, 15);
            this.labelInputDescription.TabIndex = 46;
            this.labelInputDescription.Text = "Key1=Value1&&Key2=Value2";
            // 
            // textBoxRuntimeEnvironment
            // 
            this.textBoxRuntimeEnvironment.Location = new System.Drawing.Point(164, 33);
            this.textBoxRuntimeEnvironment.Name = "textBoxRuntimeEnvironment";
            this.textBoxRuntimeEnvironment.Size = new System.Drawing.Size(183, 23);
            this.textBoxRuntimeEnvironment.TabIndex = 45;
            this.textBoxRuntimeEnvironment.Text = "Client";
            // 
            // labelRuntimeEnvironment
            // 
            this.labelRuntimeEnvironment.AutoSize = true;
            this.labelRuntimeEnvironment.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelRuntimeEnvironment.Location = new System.Drawing.Point(32, 36);
            this.labelRuntimeEnvironment.Name = "labelRuntimeEnvironment";
            this.labelRuntimeEnvironment.Size = new System.Drawing.Size(126, 15);
            this.labelRuntimeEnvironment.TabIndex = 44;
            this.labelRuntimeEnvironment.Text = "RuntimeEnvironment";
            // 
            // labelExecKeyValuePairs
            // 
            this.labelExecKeyValuePairs.AutoSize = true;
            this.labelExecKeyValuePairs.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelExecKeyValuePairs.Location = new System.Drawing.Point(32, 94);
            this.labelExecKeyValuePairs.Name = "labelExecKeyValuePairs";
            this.labelExecKeyValuePairs.Size = new System.Drawing.Size(88, 15);
            this.labelExecKeyValuePairs.TabIndex = 43;
            this.labelExecKeyValuePairs.Text = "KeyValuePairs";
            // 
            // textBoxProductIds
            // 
            this.textBoxProductIds.Location = new System.Drawing.Point(147, 120);
            this.textBoxProductIds.Name = "textBoxProductIds";
            this.textBoxProductIds.Size = new System.Drawing.Size(200, 23);
            this.textBoxProductIds.TabIndex = 28;
            this.textBoxProductIds.Text = "11000,11001,11002";
            // 
            // textBoxExecKeyValuePairs
            // 
            this.textBoxExecKeyValuePairs.Location = new System.Drawing.Point(147, 91);
            this.textBoxExecKeyValuePairs.Name = "textBoxExecKeyValuePairs";
            this.textBoxExecKeyValuePairs.Size = new System.Drawing.Size(200, 23);
            this.textBoxExecKeyValuePairs.TabIndex = 42;
            // 
            // dateTimePickerIssueDate
            // 
            this.dateTimePickerIssueDate.Location = new System.Drawing.Point(147, 149);
            this.dateTimePickerIssueDate.Name = "dateTimePickerIssueDate";
            this.dateTimePickerIssueDate.Size = new System.Drawing.Size(200, 23);
            this.dateTimePickerIssueDate.TabIndex = 29;
            this.dateTimePickerIssueDate.Value = new System.DateTime(2025, 1, 1, 0, 0, 0, 0);
            // 
            // labelOperationMode
            // 
            this.labelOperationMode.AutoSize = true;
            this.labelOperationMode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelOperationMode.Location = new System.Drawing.Point(32, 297);
            this.labelOperationMode.Name = "labelOperationMode";
            this.labelOperationMode.Size = new System.Drawing.Size(99, 15);
            this.labelOperationMode.TabIndex = 41;
            this.labelOperationMode.Text = "OperationMode";
            // 
            // dateTimePickerExpireDate
            // 
            this.dateTimePickerExpireDate.Location = new System.Drawing.Point(147, 178);
            this.dateTimePickerExpireDate.Name = "dateTimePickerExpireDate";
            this.dateTimePickerExpireDate.Size = new System.Drawing.Size(200, 23);
            this.dateTimePickerExpireDate.TabIndex = 30;
            this.dateTimePickerExpireDate.Value = new System.DateTime(2025, 2, 28, 0, 0, 0, 0);
            // 
            // labelProjectName
            // 
            this.labelProjectName.AutoSize = true;
            this.labelProjectName.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelProjectName.Location = new System.Drawing.Point(32, 268);
            this.labelProjectName.Name = "labelProjectName";
            this.labelProjectName.Size = new System.Drawing.Size(82, 15);
            this.labelProjectName.TabIndex = 40;
            this.labelProjectName.Text = "ProjectName";
            // 
            // textBoxLicenseNo
            // 
            this.textBoxLicenseNo.Location = new System.Drawing.Point(147, 207);
            this.textBoxLicenseNo.Name = "textBoxLicenseNo";
            this.textBoxLicenseNo.Size = new System.Drawing.Size(200, 23);
            this.textBoxLicenseNo.TabIndex = 31;
            this.textBoxLicenseNo.Text = "100";
            // 
            // labelCustomerName
            // 
            this.labelCustomerName.AutoSize = true;
            this.labelCustomerName.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelCustomerName.Location = new System.Drawing.Point(32, 239);
            this.labelCustomerName.Name = "labelCustomerName";
            this.labelCustomerName.Size = new System.Drawing.Size(98, 15);
            this.labelCustomerName.TabIndex = 39;
            this.labelCustomerName.Text = "CustomerName";
            // 
            // textBoxCustomerName
            // 
            this.textBoxCustomerName.Location = new System.Drawing.Point(147, 236);
            this.textBoxCustomerName.Name = "textBoxCustomerName";
            this.textBoxCustomerName.Size = new System.Drawing.Size(200, 23);
            this.textBoxCustomerName.TabIndex = 32;
            this.textBoxCustomerName.Text = "한컴이노스트림";
            // 
            // labelLicenseNo
            // 
            this.labelLicenseNo.AutoSize = true;
            this.labelLicenseNo.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelLicenseNo.Location = new System.Drawing.Point(32, 210);
            this.labelLicenseNo.Name = "labelLicenseNo";
            this.labelLicenseNo.Size = new System.Drawing.Size(66, 15);
            this.labelLicenseNo.TabIndex = 38;
            this.labelLicenseNo.Text = "LicenseNo";
            // 
            // textBoxProjectName
            // 
            this.textBoxProjectName.Location = new System.Drawing.Point(147, 265);
            this.textBoxProjectName.Name = "textBoxProjectName";
            this.textBoxProjectName.Size = new System.Drawing.Size(200, 23);
            this.textBoxProjectName.TabIndex = 33;
            this.textBoxProjectName.Text = "내부프로젝트";
            // 
            // labelExpireDate
            // 
            this.labelExpireDate.AutoSize = true;
            this.labelExpireDate.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelExpireDate.Location = new System.Drawing.Point(32, 184);
            this.labelExpireDate.Name = "labelExpireDate";
            this.labelExpireDate.Size = new System.Drawing.Size(70, 15);
            this.labelExpireDate.TabIndex = 37;
            this.labelExpireDate.Text = "ExpireDate";
            // 
            // textBoxOperationMode
            // 
            this.textBoxOperationMode.Location = new System.Drawing.Point(147, 294);
            this.textBoxOperationMode.Name = "textBoxOperationMode";
            this.textBoxOperationMode.Size = new System.Drawing.Size(200, 23);
            this.textBoxOperationMode.TabIndex = 34;
            this.textBoxOperationMode.Text = "Dev";
            // 
            // labelIssueDate
            // 
            this.labelIssueDate.AutoSize = true;
            this.labelIssueDate.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelIssueDate.Location = new System.Drawing.Point(32, 155);
            this.labelIssueDate.Name = "labelIssueDate";
            this.labelIssueDate.Size = new System.Drawing.Size(65, 15);
            this.labelIssueDate.TabIndex = 36;
            this.labelIssueDate.Text = "IssueDate";
            // 
            // labelProductIds
            // 
            this.labelProductIds.AutoSize = true;
            this.labelProductIds.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelProductIds.Location = new System.Drawing.Point(32, 123);
            this.labelProductIds.Name = "labelProductIds";
            this.labelProductIds.Size = new System.Drawing.Size(74, 15);
            this.labelProductIds.TabIndex = 35;
            this.labelProductIds.Text = "Product Ids";
            // 
            // labelEncryptedLicenseData
            // 
            this.labelEncryptedLicenseData.AutoSize = true;
            this.labelEncryptedLicenseData.Location = new System.Drawing.Point(25, 27);
            this.labelEncryptedLicenseData.Name = "labelEncryptedLicenseData";
            this.labelEncryptedLicenseData.Size = new System.Drawing.Size(147, 15);
            this.labelEncryptedLicenseData.TabIndex = 26;
            this.labelEncryptedLicenseData.Text = "암호화된 라이선스 데이터";
            // 
            // richTextBoxEncryptedtLicenseData
            // 
            this.richTextBoxEncryptedtLicenseData.BackColor = System.Drawing.Color.White;
            this.richTextBoxEncryptedtLicenseData.Location = new System.Drawing.Point(28, 45);
            this.richTextBoxEncryptedtLicenseData.Name = "richTextBoxEncryptedtLicenseData";
            this.richTextBoxEncryptedtLicenseData.Size = new System.Drawing.Size(400, 65);
            this.richTextBoxEncryptedtLicenseData.TabIndex = 25;
            this.richTextBoxEncryptedtLicenseData.Text = "";
            // 
            // groupBoxTest
            // 
            this.groupBoxTest.Controls.Add(this.textBoxWmiQuery);
            this.groupBoxTest.Controls.Add(this.labelWmiQuery);
            this.groupBoxTest.Controls.Add(this.labelWmiQueryItem);
            this.groupBoxTest.Controls.Add(this.comboBoxWmiQueryItem);
            this.groupBoxTest.Controls.Add(this.labelWmiNamespace);
            this.groupBoxTest.Controls.Add(this.textBoxWmiNamespace);
            this.groupBoxTest.Controls.Add(this.buttonExecuteWmiQuery);
            this.groupBoxTest.Controls.Add(this.buttonPrintSystemInfo);
            this.groupBoxTest.Controls.Add(this.linkLabelWmi);
            this.groupBoxTest.Controls.Add(this.richTextBoxConsole);
            this.groupBoxTest.Location = new System.Drawing.Point(12, 624);
            this.groupBoxTest.Name = "groupBoxTest";
            this.groupBoxTest.Size = new System.Drawing.Size(1060, 325);
            this.groupBoxTest.TabIndex = 1;
            this.groupBoxTest.TabStop = false;
            this.groupBoxTest.Text = "테스트";
            // 
            // textBoxWmiQuery
            // 
            this.textBoxWmiQuery.Location = new System.Drawing.Point(499, 79);
            this.textBoxWmiQuery.Name = "textBoxWmiQuery";
            this.textBoxWmiQuery.Size = new System.Drawing.Size(550, 23);
            this.textBoxWmiQuery.TabIndex = 18;
            // 
            // labelWmiQuery
            // 
            this.labelWmiQuery.AutoSize = true;
            this.labelWmiQuery.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelWmiQuery.Location = new System.Drawing.Point(422, 83);
            this.labelWmiQuery.Name = "labelWmiQuery";
            this.labelWmiQuery.Size = new System.Drawing.Size(71, 15);
            this.labelWmiQuery.TabIndex = 17;
            this.labelWmiQuery.Text = "Wmi Query";
            // 
            // labelWmiQueryItem
            // 
            this.labelWmiQueryItem.AutoSize = true;
            this.labelWmiQueryItem.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelWmiQueryItem.Location = new System.Drawing.Point(399, 49);
            this.labelWmiQueryItem.Name = "labelWmiQueryItem";
            this.labelWmiQueryItem.Size = new System.Drawing.Size(94, 15);
            this.labelWmiQueryItem.TabIndex = 16;
            this.labelWmiQueryItem.Text = "WmiQueryItem";
            // 
            // comboBoxWmiQueryItem
            // 
            this.comboBoxWmiQueryItem.FormattingEnabled = true;
            this.comboBoxWmiQueryItem.Items.AddRange(new object[] {
            "SELECT * FROM Win32_OperatingSystem",
            "SELECT * FROM Win32_NetworkAdapterConfiguration",
            "SELECT ProcessorID FROM Win32_processor",
            "SELECT UUID FROM Win32_ComputerSystemProduct"});
            this.comboBoxWmiQueryItem.Location = new System.Drawing.Point(499, 49);
            this.comboBoxWmiQueryItem.Name = "comboBoxWmiQueryItem";
            this.comboBoxWmiQueryItem.Size = new System.Drawing.Size(550, 23);
            this.comboBoxWmiQueryItem.TabIndex = 15;
            this.comboBoxWmiQueryItem.SelectedIndexChanged += new System.EventHandler(this.ComboBoxWmiQueryItem_SelectedIndexChanged);
            // 
            // labelWmiNamespace
            // 
            this.labelWmiNamespace.AutoSize = true;
            this.labelWmiNamespace.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelWmiNamespace.Location = new System.Drawing.Point(866, 27);
            this.labelWmiNamespace.Name = "labelWmiNamespace";
            this.labelWmiNamespace.Size = new System.Drawing.Size(76, 15);
            this.labelWmiNamespace.TabIndex = 14;
            this.labelWmiNamespace.Text = "Namespace";
            // 
            // textBoxWmiNamespace
            // 
            this.textBoxWmiNamespace.Location = new System.Drawing.Point(949, 21);
            this.textBoxWmiNamespace.Name = "textBoxWmiNamespace";
            this.textBoxWmiNamespace.Size = new System.Drawing.Size(100, 23);
            this.textBoxWmiNamespace.TabIndex = 13;
            this.textBoxWmiNamespace.Text = "root\\cimv2";
            // 
            // buttonExecuteWmiQuery
            // 
            this.buttonExecuteWmiQuery.Location = new System.Drawing.Point(265, 79);
            this.buttonExecuteWmiQuery.Name = "buttonExecuteWmiQuery";
            this.buttonExecuteWmiQuery.Size = new System.Drawing.Size(139, 23);
            this.buttonExecuteWmiQuery.TabIndex = 7;
            this.buttonExecuteWmiQuery.Text = "Execute Wmi Query";
            this.buttonExecuteWmiQuery.UseVisualStyleBackColor = true;
            this.buttonExecuteWmiQuery.Click += new System.EventHandler(this.ButtonExecuteWmiQuery_Click);
            // 
            // buttonPrintSystemInfo
            // 
            this.buttonPrintSystemInfo.Location = new System.Drawing.Point(6, 79);
            this.buttonPrintSystemInfo.Name = "buttonPrintSystemInfo";
            this.buttonPrintSystemInfo.Size = new System.Drawing.Size(141, 23);
            this.buttonPrintSystemInfo.TabIndex = 6;
            this.buttonPrintSystemInfo.Text = "시스템 정보 출력";
            this.buttonPrintSystemInfo.UseVisualStyleBackColor = true;
            this.buttonPrintSystemInfo.Click += new System.EventHandler(this.ButtonPrintSystemInfo_Click);
            // 
            // linkLabelWmi
            // 
            this.linkLabelWmi.AutoSize = true;
            this.linkLabelWmi.Location = new System.Drawing.Point(496, 282);
            this.linkLabelWmi.Name = "linkLabelWmi";
            this.linkLabelWmi.Size = new System.Drawing.Size(553, 15);
            this.linkLabelWmi.TabIndex = 5;
            this.linkLabelWmi.TabStop = true;
            this.linkLabelWmi.Text = "https://learn.microsoft.com/ko-kr/windows/win32/cimwin32prov/computer-system-hard" +
    "ware-classes";
            this.linkLabelWmi.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelWmi_LinkClicked);
            // 
            // richTextBoxConsole
            // 
            this.richTextBoxConsole.ContextMenuStrip = this.contextMenuStripRichTextBoxConsole;
            this.richTextBoxConsole.Location = new System.Drawing.Point(6, 108);
            this.richTextBoxConsole.Name = "richTextBoxConsole";
            this.richTextBoxConsole.Size = new System.Drawing.Size(1048, 180);
            this.richTextBoxConsole.TabIndex = 2;
            this.richTextBoxConsole.Text = "";
            // 
            // contextMenuStripRichTextBoxConsole
            // 
            this.contextMenuStripRichTextBoxConsole.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemClear});
            this.contextMenuStripRichTextBoxConsole.Name = "contextMenuStripRichTextBoxConsole";
            this.contextMenuStripRichTextBoxConsole.Size = new System.Drawing.Size(102, 26);
            // 
            // ToolStripMenuItemClear
            // 
            this.ToolStripMenuItemClear.Name = "ToolStripMenuItemClear";
            this.ToolStripMenuItemClear.Size = new System.Drawing.Size(101, 22);
            this.ToolStripMenuItemClear.Text = "Clear";
            this.ToolStripMenuItemClear.Click += new System.EventHandler(this.RichTextBoxConsoleToolStripMenuItemClear_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 961);
            this.Controls.Add(this.groupBoxTest);
            this.Controls.Add(this.groupBoxLicesneCrypto);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "Product.License.TestClient";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.groupBoxLicesneCrypto.ResumeLayout(false);
            this.groupBoxLicesneCrypto.PerformLayout();
            this.groupBoxCrypto.ResumeLayout(false);
            this.groupBoxCrypto.PerformLayout();
            this.groupBoxLicenseProductData.ResumeLayout(false);
            this.groupBoxLicenseProductData.PerformLayout();
            this.groupBoxTest.ResumeLayout(false);
            this.groupBoxTest.PerformLayout();
            this.contextMenuStripRichTextBoxConsole.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxLicesneCrypto;
        private System.Windows.Forms.GroupBox groupBoxTest;
        private System.Windows.Forms.LinkLabel linkLabelWmi;
        private System.Windows.Forms.RichTextBox richTextBoxConsole;
        private System.Windows.Forms.Button buttonPrintSystemInfo;
        private System.Windows.Forms.Button buttonExecuteWmiQuery;
        private System.Windows.Forms.TextBox textBoxWmiQuery;
        private System.Windows.Forms.Label labelWmiQueryItem;
        private System.Windows.Forms.ComboBox comboBoxWmiQueryItem;
        private System.Windows.Forms.Label labelWmiNamespace;
        private System.Windows.Forms.TextBox textBoxWmiNamespace;
        private System.Windows.Forms.Label labelWmiQuery;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripRichTextBoxConsole;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemClear;
        private System.Windows.Forms.Label labelEncryptedLicenseData;
        private System.Windows.Forms.RichTextBox richTextBoxEncryptedtLicenseData;
        private System.Windows.Forms.Label labelExecKeyValuePairs;
        private System.Windows.Forms.TextBox textBoxExecKeyValuePairs;
        private System.Windows.Forms.Label labelOperationMode;
        private System.Windows.Forms.Label labelProjectName;
        private System.Windows.Forms.Label labelCustomerName;
        private System.Windows.Forms.Label labelLicenseNo;
        private System.Windows.Forms.Label labelExpireDate;
        private System.Windows.Forms.Label labelIssueDate;
        private System.Windows.Forms.Label labelProductIds;
        private System.Windows.Forms.TextBox textBoxOperationMode;
        private System.Windows.Forms.TextBox textBoxProjectName;
        private System.Windows.Forms.TextBox textBoxCustomerName;
        private System.Windows.Forms.TextBox textBoxLicenseNo;
        private System.Windows.Forms.DateTimePicker dateTimePickerExpireDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerIssueDate;
        private System.Windows.Forms.TextBox textBoxProductIds;
        private System.Windows.Forms.GroupBox groupBoxLicenseProductData;
        private System.Windows.Forms.Button buttonDecryptLicenseProductData;
        private System.Windows.Forms.Button buttonGenerateLicenseProductDataPlainText;
        private System.Windows.Forms.GroupBox groupBoxCrypto;
        private System.Windows.Forms.RichTextBox richTextBoxAfterPlainTextLicenseProductData;
        private System.Windows.Forms.Button buttonEncryptionPlainTextLicenseProductData;
        private System.Windows.Forms.Label labelEnryptionPlainTextLicenseProductData;
        private System.Windows.Forms.RichTextBox richTextBoxBeforePlainTextLicenseProductData;
        private System.Windows.Forms.Button buttonDecryptionPlainTextLicenseProductData;
        private System.Windows.Forms.RichTextBox richTextBoxEnryptionPlainTextLicenseProductData;
        private System.Windows.Forms.Label labelBeforePlainTextLicenseProductData;
        private System.Windows.Forms.Label labelAfterPlainTextLicenseProductData;
        private System.Windows.Forms.Label labelRuntimeEnvironment;
        private System.Windows.Forms.TextBox textBoxRuntimeEnvironment;
        private System.Windows.Forms.Label labelInputDescription;
        private System.Windows.Forms.Label labelLicenseProductDataResult;
        private System.Windows.Forms.Button buttonEncryptionPlainTextLicenseProductDataCreateFile;
        private System.Windows.Forms.Label labelAes256IVBase64;
        private System.Windows.Forms.Label labelAes256KeyBase64;
        private System.Windows.Forms.Button buttonAes256Base64Data;
        private System.Windows.Forms.RichTextBox richTextBoxAes256IVBase64;
        private System.Windows.Forms.RichTextBox richTextBoxAes256KeyBase64;
        private System.Windows.Forms.Label labelAes256IVText;
        private System.Windows.Forms.Label labelAes256KeyText;
        private System.Windows.Forms.RichTextBox richTextBoxAes256IVText;
        private System.Windows.Forms.RichTextBox richTextBoxAes256KeyText;
        private System.Windows.Forms.Label labelLicenseKeyAes256Result;
    }
}

