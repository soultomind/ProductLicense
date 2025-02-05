
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
            this.groupBoxTest.SuspendLayout();
            this.contextMenuStripRichTextBoxConsole.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxLicesneCrypto
            // 
            this.groupBoxLicesneCrypto.Location = new System.Drawing.Point(12, 12);
            this.groupBoxLicesneCrypto.Name = "groupBoxLicesneCrypto";
            this.groupBoxLicesneCrypto.Size = new System.Drawing.Size(960, 606);
            this.groupBoxLicesneCrypto.TabIndex = 0;
            this.groupBoxLicesneCrypto.TabStop = false;
            this.groupBoxLicesneCrypto.Text = "라이선스 암복호화";
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
            this.groupBoxTest.Size = new System.Drawing.Size(960, 325);
            this.groupBoxTest.TabIndex = 1;
            this.groupBoxTest.TabStop = false;
            this.groupBoxTest.Text = "테스트";
            // 
            // textBoxWmiQuery
            // 
            this.textBoxWmiQuery.Location = new System.Drawing.Point(499, 79);
            this.textBoxWmiQuery.Name = "textBoxWmiQuery";
            this.textBoxWmiQuery.Size = new System.Drawing.Size(453, 23);
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
            this.comboBoxWmiQueryItem.Size = new System.Drawing.Size(453, 23);
            this.comboBoxWmiQueryItem.TabIndex = 15;
            this.comboBoxWmiQueryItem.SelectedIndexChanged += new System.EventHandler(this.ComboBoxWmiQueryItem_SelectedIndexChanged);
            // 
            // labelWmiNamespace
            // 
            this.labelWmiNamespace.AutoSize = true;
            this.labelWmiNamespace.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelWmiNamespace.Location = new System.Drawing.Point(768, 25);
            this.labelWmiNamespace.Name = "labelWmiNamespace";
            this.labelWmiNamespace.Size = new System.Drawing.Size(76, 15);
            this.labelWmiNamespace.TabIndex = 14;
            this.labelWmiNamespace.Text = "Namespace";
            // 
            // textBoxWmiNamespace
            // 
            this.textBoxWmiNamespace.Location = new System.Drawing.Point(852, 22);
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
            this.linkLabelWmi.Location = new System.Drawing.Point(401, 291);
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
            this.richTextBoxConsole.Size = new System.Drawing.Size(948, 180);
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
            this.ClientSize = new System.Drawing.Size(984, 961);
            this.Controls.Add(this.groupBoxTest);
            this.Controls.Add(this.groupBoxLicesneCrypto);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "Product.License.TestClient";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
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
    }
}

