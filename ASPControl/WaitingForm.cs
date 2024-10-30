using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASPControl
{
    public partial class WaitingForm : Form
    {
        public WaitingForm()
        {
            InitializeComponent();

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WaitingForm_FormClosing);
            this.Load += new System.EventHandler(this.WaitingForm_Load);
        }

        private void WaitingForm_Load(object sender, EventArgs e)
        {
            progressBar1.Style = ProgressBarStyle.Marquee;
            this.BringToFront();
            this.CenterToScreen();
        }

        private void WaitingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        internal void SetLabel(string p)
        {
            label1.Text = p;
        }
    }
}
