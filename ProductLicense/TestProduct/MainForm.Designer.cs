
namespace TestProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageConsole = new System.Windows.Forms.TabPage();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonClipBoard = new System.Windows.Forms.ToolStripButton();
            this.richTextBoxConsole = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageConsole.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.panelTop, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.panelBottom, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(799, 661);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(3, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(793, 456);
            this.panelTop.TabIndex = 0;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.tabControl);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(3, 465);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(793, 193);
            this.panelBottom.TabIndex = 1;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageConsole);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(793, 193);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageConsole
            // 
            this.tabPageConsole.Controls.Add(this.toolStrip);
            this.tabPageConsole.Controls.Add(this.richTextBoxConsole);
            this.tabPageConsole.Location = new System.Drawing.Point(4, 24);
            this.tabPageConsole.Name = "tabPageConsole";
            this.tabPageConsole.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConsole.Size = new System.Drawing.Size(785, 165);
            this.tabPageConsole.TabIndex = 1;
            this.tabPageConsole.Text = "Console";
            this.tabPageConsole.UseVisualStyleBackColor = true;
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonClipBoard});
            this.toolStrip.Location = new System.Drawing.Point(3, 3);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(779, 25);
            this.toolStrip.TabIndex = 1;
            // 
            // toolStripButtonClipBoard
            // 
            this.toolStripButtonClipBoard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonClipBoard.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonClipBoard.Image")));
            this.toolStripButtonClipBoard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClipBoard.Name = "toolStripButtonClipBoard";
            this.toolStripButtonClipBoard.Size = new System.Drawing.Size(63, 22);
            this.toolStripButtonClipBoard.Text = "ClipBoard";
            this.toolStripButtonClipBoard.Click += new System.EventHandler(this.ToolStripButtonClipBoard_Click);
            // 
            // richTextBoxConsole
            // 
            this.richTextBoxConsole.BackColor = System.Drawing.Color.Black;
            this.richTextBoxConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxConsole.ForeColor = System.Drawing.Color.White;
            this.richTextBoxConsole.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxConsole.Name = "richTextBoxConsole";
            this.richTextBoxConsole.Size = new System.Drawing.Size(779, 159);
            this.richTextBoxConsole.TabIndex = 0;
            this.richTextBoxConsole.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 661);
            this.Controls.Add(this.tableLayoutPanel);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.tableLayoutPanel.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageConsole.ResumeLayout(false);
            this.tabPageConsole.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageConsole;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButtonClipBoard;
        private System.Windows.Forms.RichTextBox richTextBoxConsole;
    }
}

