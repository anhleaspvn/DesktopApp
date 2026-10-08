using System;
using System.Drawing;
using System.Windows.Forms;

namespace ASPUpdater
{
    internal sealed class UpdateProgressForm : Form
    {
        private readonly Label titleLabel;
        private readonly Label statusLabel;
        private readonly ProgressBar progressBar;

        public UpdateProgressForm()
        {
            Text = "Cap nhat phan mem";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ControlBox = false;
            ShowInTaskbar = true;
            TopMost = true;
            ClientSize = new Size(420, 135);

            titleLabel = new Label
            {
                AutoSize = false,
                Text = "Dang cap nhat phan mem",
                Font = new Font(Font.FontFamily, 11.5f, FontStyle.Bold),
                Location = new Point(20, 18),
                Size = new Size(380, 24)
            };

            statusLabel = new Label
            {
                AutoSize = false,
                Text = "Dang chuan bi...",
                Location = new Point(20, 52),
                Size = new Size(380, 24)
            };

            progressBar = new ProgressBar
            {
                Location = new Point(20, 86),
                Size = new Size(380, 22),
                Style = ProgressBarStyle.Marquee,
                MarqueeAnimationSpeed = 35
            };

            Controls.Add(titleLabel);
            Controls.Add(statusLabel);
            Controls.Add(progressBar);
        }

        public void SetStatus(string status)
        {
            statusLabel.Text = status;
            statusLabel.Refresh();
            progressBar.Refresh();
        }

        public void StopProgress()
        {
            progressBar.MarqueeAnimationSpeed = 0;
            progressBar.Style = ProgressBarStyle.Blocks;
            progressBar.Value = 100;
            progressBar.Visible = false;
            progressBar.Refresh();
        }

        public void ForceToFront()
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }

            TopMost = false;
            TopMost = true;
            Show();
            BringToFront();
            Activate();
        }
    }
}
