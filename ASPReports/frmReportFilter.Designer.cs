namespace LinkQ.Reports
{
	partial class frmReportFilter
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
            this.btgAccept = new LinkQ.Systems.Customizes.btgAccept();
            this.tabControl1 = new LinkQ.Systems.Controls.tabControl();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.BackColor = System.Drawing.Color.Transparent;
            this.btgAccept.Location = new System.Drawing.Point(394, 290);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 29);
            this.btgAccept.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Location = new System.Drawing.Point(12, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(563, 274);
            this.tabControl1.TabIndex = 0;
            // 
            // frmReportFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 331);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmReportFilter";
            this.strForm_Type = "2";
            this.strLayoutList = "1";
            this.Tag = "frmReportFilter";
            this.Text = "frmReportFilter";
            this.UseFormLayoutDesign = true;
            this.ResumeLayout(false);

			}

		#endregion

		private LinkQ.Systems.Customizes.btgAccept btgAccept;
		private LinkQ.Systems.Controls.tabControl tabControl1;

	}
}