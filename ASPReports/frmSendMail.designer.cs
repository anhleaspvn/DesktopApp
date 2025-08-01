namespace LinkQ.Systems.Customizes
{
	partial class frmSendMail
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
			this.txtfilename = new LinkQ.Systems.Controls.txtTextBox();
			this.lblPath = new LinkQ.Systems.Controls.lblControl();
			this.btgAccept = new LinkQ.Systems.Customizes.btgAccept();
			this.cboExportType = new LinkQ.Systems.Controls.cboControl();
			this.lblControl1 = new LinkQ.Systems.Controls.lblControl();
			this.SuspendLayout();
			// 
			// txtfilename
			// 
			this.txtfilename.AutoFilter = null;
			this.txtfilename.bEnabled = true;
			this.txtfilename.bReadOnly = false;
			this.txtfilename.CtrlDepend = null;
			this.txtfilename.Location = new System.Drawing.Point(118, 65);
			this.txtfilename.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtfilename.Name = "txtfilename";
			this.txtfilename.Require = false;
			this.txtfilename.ShowAddButton = false;
			this.txtfilename.Size = new System.Drawing.Size(214, 20);
			this.txtfilename.strKeyFilter = "";
			this.txtfilename.TabIndex = 1;
			this.txtfilename.UseAutoFilter = false;
			// 
			// lblPath
			// 
			this.lblPath.AutoEllipsis = true;
			this.lblPath.AutoSize = true;
			this.lblPath.BackColor = System.Drawing.Color.Transparent;
			this.lblPath.Location = new System.Drawing.Point(15, 67);
			this.lblPath.Location2 = new System.Drawing.Point(0, 0);
			this.lblPath.Name = "lblPath";
			this.lblPath.Size = new System.Drawing.Size(58, 13);
			this.lblPath.TabIndex = 2;
			this.lblPath.Tag = "filename";
			this.lblPath.Text = "Tên tập tin";
			this.lblPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblPath.UseHotKey = true;
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.BackColor = System.Drawing.Color.Transparent;
			this.btgAccept.Location = new System.Drawing.Point(151, 148);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(181, 29);
			this.btgAccept.TabIndex = 7;
			// 
			// cboExportType
			// 
			this.cboExportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboExportType.FormattingEnabled = true;
			this.cboExportType.InitValue = "";
			this.cboExportType.Items.AddRange(new object[] {
            "1 - Export to MS excel",
            "2 - Export to MS word",
            "3 - Export to PDF type"});
			this.cboExportType.Location = new System.Drawing.Point(118, 28);
			this.cboExportType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.cboExportType.Name = "cboExportType";
			this.cboExportType.Size = new System.Drawing.Size(214, 21);
			this.cboExportType.strValueList = "";
			this.cboExportType.TabIndex = 0;
			this.cboExportType.UseAutoComplete = false;
			// 
			// lblControl1
			// 
			this.lblControl1.AutoEllipsis = true;
			this.lblControl1.AutoSize = true;
			this.lblControl1.BackColor = System.Drawing.Color.Transparent;
			this.lblControl1.Location = new System.Drawing.Point(15, 31);
			this.lblControl1.Location2 = new System.Drawing.Point(0, 0);
			this.lblControl1.Name = "lblControl1";
			this.lblControl1.Size = new System.Drawing.Size(97, 13);
			this.lblControl1.TabIndex = 2;
			this.lblControl1.Tag = "Format";
			this.lblControl1.Text = "Định dạng kết xuất";
			this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblControl1.UseHotKey = true;
			// 
			// frmSendMail
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(352, 189);
			this.Controls.Add(this.cboExportType);
			this.Controls.Add(this.btgAccept);
			this.Controls.Add(this.lblControl1);
			this.Controls.Add(this.lblPath);
			this.Controls.Add(this.txtfilename);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSendMail";
			this.Tag = "frmSendMail";
			this.Text = "frmSendMail";
			
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private LinkQ.Systems.Controls.txtTextBox txtfilename;
		private LinkQ.Systems.Controls.lblControl lblPath;
		private LinkQ.Systems.Customizes.btgAccept btgAccept;
		public LinkQ.Systems.Controls.cboControl cboExportType;
		private LinkQ.Systems.Controls.lblControl lblControl1;
	}
}