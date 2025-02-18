using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProduct
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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
