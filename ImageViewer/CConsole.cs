using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ImageViewer
{
    public partial class CConsole : Form
    {

        delegate void SetTextCallback(string text);
        delegate void endCallback();
        delegate void scrollback();

        public CConsole()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public RichTextBox getConsole()
        {
            return ConsoleArea;
        }

        public void printLine(string input)
        {
            SetText(string.Concat(input, "\n"));
        }

        public void end()
        {
            if (this.getConsole().InvokeRequired)
            {
                endCallback d = new endCallback(end);
                this.Invoke(d);
            }
            else
            {
                this.Close();
            }
        }

        private void SetText(string text)
        {
            if (this.getConsole().InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
                scrollDown();
            }
            else
            {
                this.getConsole().Text += text;
            }
        }

        private void scrollDown()
        {
            if (this.getConsole().InvokeRequired)
            {
                scrollback d = new scrollback(scrollDown);
                this.Invoke(d);
            }
            else
            {
                this.getConsole().SelectionStart = this.getConsole().Text.Length;
                this.getConsole().ScrollToCaret();
            }
        }
    }
}
