namespace LinkQ.Reports
{
	partial class frmReportResult
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tblLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblPath = new LinkQ.Systems.Controls.lblControl();
			this.lblSubTile2 = new LinkQ.Systems.Controls.lblControl();
			this.lblSubTile1 = new LinkQ.Systems.Controls.lblControl();
			this.lblTitle = new LinkQ.Systems.Controls.lblControl();
			this.tblLayoutPanel.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tblLayoutPanel
			// 
			this.tblLayoutPanel.BackColor = System.Drawing.Color.Transparent;
			this.tblLayoutPanel.ColumnCount = 1;
			this.tblLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tblLayoutPanel.Controls.Add(this.panel1, 0, 0);
			this.tblLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tblLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.tblLayoutPanel.Name = "tblLayoutPanel";
			this.tblLayoutPanel.RowCount = 2;
			this.tblLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.tblLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tblLayoutPanel.Size = new System.Drawing.Size(525, 349);
			this.tblLayoutPanel.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblPath);
			this.panel1.Controls.Add(this.lblSubTile2);
			this.panel1.Controls.Add(this.lblSubTile1);
			this.panel1.Controls.Add(this.lblTitle);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(519, 94);
			this.panel1.TabIndex = 0;
			// 
			// lblPath
			// 
			this.lblPath.AutoEllipsis = true;
			this.lblPath.AutoSize = true;
			this.lblPath.BackColor = System.Drawing.Color.Transparent;
			this.lblPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.lblPath.ForeColor = System.Drawing.Color.DarkOrange;
			this.lblPath.Location = new System.Drawing.Point(9, 8);
			this.lblPath.Location2 = new System.Drawing.Point(0, 0);
			this.lblPath.Name = "lblPath";
			this.lblPath.Size = new System.Drawing.Size(132, 17);
			this.lblPath.TabIndex = 3;
			this.lblPath.Tag = "F4_AN_HIEN_TITLE";
			this.lblPath.Text = "F4- Ẩn, hiện tiêu đề";
			this.lblPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblPath.UseHotKey = true;
			// 
			// lblSubTile2
			// 
			this.lblSubTile2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblSubTile2.AutoEllipsis = true;
			this.lblSubTile2.BackColor = System.Drawing.Color.Transparent;
			this.lblSubTile2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
			this.lblSubTile2.Location = new System.Drawing.Point(9, 40);
			this.lblSubTile2.Location2 = new System.Drawing.Point(0, 0);
			this.lblSubTile2.Name = "lblSubTile2";
			this.lblSubTile2.Size = new System.Drawing.Size(501, 32);
			this.lblSubTile2.TabIndex = 5;
			this.lblSubTile2.Tag = "";
			this.lblSubTile2.Text = "SubTitle1";
			this.lblSubTile2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.lblSubTile2.UseHotKey = true;
			// 
			// lblSubTile1
			// 
			this.lblSubTile1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblSubTile1.AutoEllipsis = true;
			this.lblSubTile1.BackColor = System.Drawing.Color.Transparent;
			this.lblSubTile1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Italic);
			this.lblSubTile1.Location = new System.Drawing.Point(9, 21);
			this.lblSubTile1.Location2 = new System.Drawing.Point(0, 0);
			this.lblSubTile1.Name = "lblSubTile1";
			this.lblSubTile1.Size = new System.Drawing.Size(501, 17);
			this.lblSubTile1.TabIndex = 4;
			this.lblSubTile1.Tag = "";
			this.lblSubTile1.Text = "SubTitle1";
			this.lblSubTile1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblSubTile1.UseHotKey = true;
			// 
			// lblTitle
			// 
			this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblTitle.AutoEllipsis = true;
			this.lblTitle.BackColor = System.Drawing.Color.Transparent;
			this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
			this.lblTitle.Location = new System.Drawing.Point(9, 0);
			this.lblTitle.Location2 = new System.Drawing.Point(0, 0);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(501, 17);
			this.lblTitle.TabIndex = 3;
			this.lblTitle.Tag = "";
			this.lblTitle.Text = "Title";
			this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblTitle.UseHotKey = true;
			// 
			// frmReportResult
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(525, 349);
			this.Controls.Add(this.tblLayoutPanel);
			this.Name = "frmReportResult";
			this.strForm_ID = "frmReportResult";
			this.Text = "frmResult";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.tblLayoutPanel.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tblLayoutPanel;
		private System.Windows.Forms.Panel panel1;
		private Systems.Controls.lblControl lblTitle;
		private Systems.Controls.lblControl lblSubTile2;
		private Systems.Controls.lblControl lblSubTile1;
		private Systems.Controls.lblControl lblPath;


    }
}