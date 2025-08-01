namespace LinkQ.Reports
{
	partial class frmReport
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReport));
            this.imglTree = new System.Windows.Forms.ImageList(this.components);
            this.tvReport = new LinkQ.Systems.Controls.tvControl();
            this.btRun = new LinkQ.Systems.Controls.btControl();
            this.btExit = new LinkQ.Systems.Controls.btControl();
            this.btFormula = new LinkQ.Systems.Controls.btControl();
            this.pnlRunReport = new LinkQ.Systems.Controls.pnlControl();
            this.grbPrint_Sign = new LinkQ.Systems.Controls.grbControl();
            this.txtName3 = new LinkQ.Systems.Controls.txtTextBox();
            this.txtName2 = new LinkQ.Systems.Controls.txtTextBox();
            this.txtName1 = new LinkQ.Systems.Controls.txtTextBox();
            this.txtSign3 = new LinkQ.Systems.Controls.txtTextBox();
            this.txtSign2 = new LinkQ.Systems.Controls.txtTextBox();
            this.txtSign1 = new LinkQ.Systems.Controls.txtTextBox();
            this.chkPrint_Sign = new LinkQ.Systems.Controls.chkControl();
            this.grbLoai_Tien = new LinkQ.Systems.Controls.grbControl();
            this.rdbIs_Vnd_Nt = new LinkQ.Systems.Controls.rdbControl();
            this.rdbIs_Nt = new LinkQ.Systems.Controls.rdbControl();
            this.rdbIs_Vnd = new LinkQ.Systems.Controls.rdbControl();
            this.label1 = new System.Windows.Forms.Label();
            this.picReport = new System.Windows.Forms.PictureBox();
            this.grbControl1 = new LinkQ.Systems.Controls.grbControl();
            this.rdbOther = new LinkQ.Systems.Controls.rdbControl();
            this.rdbEnglish = new LinkQ.Systems.Controls.rdbControl();
            this.rdbVietnamese = new LinkQ.Systems.Controls.rdbControl();
            this.pnlRunReport.SuspendLayout();
            this.grbPrint_Sign.SuspendLayout();
            this.grbLoai_Tien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picReport)).BeginInit();
            this.grbControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imglTree
            // 
            this.imglTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglTree.ImageStream")));
            this.imglTree.TransparentColor = System.Drawing.Color.Transparent;
            this.imglTree.Images.SetKeyName(0, "Node.png");
            this.imglTree.Images.SetKeyName(1, "NodeSelect.png");
            this.imglTree.Images.SetKeyName(2, "NodeExpand.png");
            this.imglTree.Images.SetKeyName(3, "NodeExpandSelect.png");
            // 
            // tvReport
            // 
            this.tvReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.tvReport.DataSource = null;
            this.tvReport.DisplayFieldName = "Report_Name";
            this.tvReport.KeyFieldName = "Report_Id";
            this.tvReport.Location = new System.Drawing.Point(3, 5);
            this.tvReport.Name = "tvReport";
            this.tvReport.ParentFieldName = "Report_Parent";
            this.tvReport.ShowLines = false;
            this.tvReport.ShowPlusMinus = false;
            this.tvReport.ShowRootLines = false;
            this.tvReport.Size = new System.Drawing.Size(290, 565);
            this.tvReport.TabIndex = 0;
            // 
            // btRun
            // 
            this.btRun.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btRun.BackgroundImage")));
            this.btRun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btRun.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btRun.Location = new System.Drawing.Point(3, 3);
            this.btRun.Location2 = new System.Drawing.Point(0, 0);
            this.btRun.Name = "btRun";
            this.btRun.Size = new System.Drawing.Size(115, 23);
            this.btRun.TabIndex = 0;
            this.btRun.Tag = "Thuc_hien";
            this.btRun.Text = "Thực hiện";
            this.btRun.UseHotKey = true;
            this.btRun.UseVisualStyleBackColor = true;
            // 
            // btExit
            // 
            this.btExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btExit.BackgroundImage")));
            this.btExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btExit.Location = new System.Drawing.Point(3, 28);
            this.btExit.Location2 = new System.Drawing.Point(0, 0);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(115, 23);
            this.btExit.TabIndex = 1;
            this.btExit.Tag = "Exit";
            this.btExit.Text = "&Thoát";
            this.btExit.UseHotKey = true;
            this.btExit.UseVisualStyleBackColor = true;
            // 
            // btFormula
            // 
            this.btFormula.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btFormula.BackgroundImage")));
            this.btFormula.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btFormula.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btFormula.Location = new System.Drawing.Point(3, 53);
            this.btFormula.Location2 = new System.Drawing.Point(0, 0);
            this.btFormula.Name = "btFormula";
            this.btFormula.Size = new System.Drawing.Size(115, 23);
            this.btFormula.TabIndex = 2;
            this.btFormula.Tag = "Formula";
            this.btFormula.Text = "&Khai báo công thức";
            this.btFormula.UseHotKey = true;
            this.btFormula.UseVisualStyleBackColor = true;
            // 
            // pnlRunReport
            // 
            this.pnlRunReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRunReport.BackColor = System.Drawing.Color.Transparent;
            this.pnlRunReport.Controls.Add(this.btFormula);
            this.pnlRunReport.Controls.Add(this.btExit);
            this.pnlRunReport.Controls.Add(this.btRun);
            this.pnlRunReport.Location = new System.Drawing.Point(659, 3);
            this.pnlRunReport.Name = "pnlRunReport";
            this.pnlRunReport.Size = new System.Drawing.Size(127, 81);
            this.pnlRunReport.TabIndex = 1;
            this.pnlRunReport.TabStop = true;
            // 
            // grbPrint_Sign
            // 
            this.grbPrint_Sign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.grbPrint_Sign.BackColor = System.Drawing.Color.Transparent;
            this.grbPrint_Sign.Controls.Add(this.txtName3);
            this.grbPrint_Sign.Controls.Add(this.txtName2);
            this.grbPrint_Sign.Controls.Add(this.txtName1);
            this.grbPrint_Sign.Controls.Add(this.txtSign3);
            this.grbPrint_Sign.Controls.Add(this.txtSign2);
            this.grbPrint_Sign.Controls.Add(this.txtSign1);
            this.grbPrint_Sign.Location = new System.Drawing.Point(648, 390);
            this.grbPrint_Sign.Name = "grbPrint_Sign";
            this.grbPrint_Sign.Size = new System.Drawing.Size(138, 158);
            this.grbPrint_Sign.TabIndex = 3;
            this.grbPrint_Sign.TabStop = false;
            // 
            // txtName3
            // 
            this.txtName3.AutoFilter = null;
            this.txtName3.bEnabled = true;
            this.txtName3.bReadOnly = false;
            this.txtName3.CtrlDepend = null;
            this.txtName3.Location = new System.Drawing.Point(5, 132);
            this.txtName3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtName3.Name = "txtName3";
            this.txtName3.Require = false;
            this.txtName3.ShowAddButton = false;
            this.txtName3.Size = new System.Drawing.Size(128, 20);
            this.txtName3.strKeyFilter = "";
            this.txtName3.TabIndex = 5;
            this.txtName3.TabStop = false;
            this.txtName3.UseAutoFilter = false;
            // 
            // txtName2
            // 
            this.txtName2.AutoFilter = null;
            this.txtName2.bEnabled = true;
            this.txtName2.bReadOnly = false;
            this.txtName2.CtrlDepend = null;
            this.txtName2.Location = new System.Drawing.Point(5, 84);
            this.txtName2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtName2.Name = "txtName2";
            this.txtName2.Require = false;
            this.txtName2.ShowAddButton = false;
            this.txtName2.Size = new System.Drawing.Size(128, 20);
            this.txtName2.strKeyFilter = "";
            this.txtName2.TabIndex = 3;
            this.txtName2.TabStop = false;
            this.txtName2.UseAutoFilter = false;
            // 
            // txtName1
            // 
            this.txtName1.AutoFilter = null;
            this.txtName1.bEnabled = true;
            this.txtName1.bReadOnly = false;
            this.txtName1.CtrlDepend = null;
            this.txtName1.Location = new System.Drawing.Point(5, 36);
            this.txtName1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtName1.Name = "txtName1";
            this.txtName1.Require = false;
            this.txtName1.ShowAddButton = false;
            this.txtName1.Size = new System.Drawing.Size(128, 20);
            this.txtName1.strKeyFilter = "";
            this.txtName1.TabIndex = 1;
            this.txtName1.TabStop = false;
            this.txtName1.UseAutoFilter = false;
            // 
            // txtSign3
            // 
            this.txtSign3.AutoFilter = null;
            this.txtSign3.bEnabled = true;
            this.txtSign3.bReadOnly = false;
            this.txtSign3.CtrlDepend = null;
            this.txtSign3.Location = new System.Drawing.Point(5, 110);
            this.txtSign3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSign3.Name = "txtSign3";
            this.txtSign3.Require = false;
            this.txtSign3.ShowAddButton = false;
            this.txtSign3.Size = new System.Drawing.Size(128, 20);
            this.txtSign3.strKeyFilter = "";
            this.txtSign3.TabIndex = 4;
            this.txtSign3.TabStop = false;
            this.txtSign3.UseAutoFilter = false;
            // 
            // txtSign2
            // 
            this.txtSign2.AutoFilter = null;
            this.txtSign2.bEnabled = true;
            this.txtSign2.bReadOnly = false;
            this.txtSign2.CtrlDepend = null;
            this.txtSign2.Location = new System.Drawing.Point(5, 62);
            this.txtSign2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSign2.Name = "txtSign2";
            this.txtSign2.Require = false;
            this.txtSign2.ShowAddButton = false;
            this.txtSign2.Size = new System.Drawing.Size(128, 20);
            this.txtSign2.strKeyFilter = "";
            this.txtSign2.TabIndex = 2;
            this.txtSign2.TabStop = false;
            this.txtSign2.UseAutoFilter = false;
            // 
            // txtSign1
            // 
            this.txtSign1.AutoFilter = null;
            this.txtSign1.bEnabled = true;
            this.txtSign1.bReadOnly = false;
            this.txtSign1.CtrlDepend = null;
            this.txtSign1.Location = new System.Drawing.Point(5, 14);
            this.txtSign1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSign1.Name = "txtSign1";
            this.txtSign1.Require = false;
            this.txtSign1.ShowAddButton = false;
            this.txtSign1.Size = new System.Drawing.Size(128, 20);
            this.txtSign1.strKeyFilter = "";
            this.txtSign1.TabIndex = 0;
            this.txtSign1.TabStop = false;
            this.txtSign1.UseAutoFilter = false;
            // 
            // chkPrint_Sign
            // 
            this.chkPrint_Sign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPrint_Sign.AutoSize = true;
            this.chkPrint_Sign.BackColor = System.Drawing.Color.Transparent;
            this.chkPrint_Sign.Checked = true;
            this.chkPrint_Sign.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPrint_Sign.Location = new System.Drawing.Point(659, 386);
            this.chkPrint_Sign.Location2 = new System.Drawing.Point(0, 0);
            this.chkPrint_Sign.Name = "chkPrint_Sign";
            this.chkPrint_Sign.Size = new System.Drawing.Size(70, 17);
            this.chkPrint_Sign.TabIndex = 0;
            this.chkPrint_Sign.TabStop = false;
            this.chkPrint_Sign.Tag = "Print_Sign";
            this.chkPrint_Sign.Text = "&In chữ ký";
            this.chkPrint_Sign.UseHotKey = true;
            this.chkPrint_Sign.UseVisualStyleBackColor = false;
            // 
            // grbLoai_Tien
            // 
            this.grbLoai_Tien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.grbLoai_Tien.BackColor = System.Drawing.Color.Transparent;
            this.grbLoai_Tien.Controls.Add(this.rdbIs_Vnd_Nt);
            this.grbLoai_Tien.Controls.Add(this.rdbIs_Nt);
            this.grbLoai_Tien.Controls.Add(this.rdbIs_Vnd);
            this.grbLoai_Tien.Location = new System.Drawing.Point(648, 273);
            this.grbLoai_Tien.Name = "grbLoai_Tien";
            this.grbLoai_Tien.Size = new System.Drawing.Size(138, 102);
            this.grbLoai_Tien.TabIndex = 2;
            this.grbLoai_Tien.TabStop = false;
            this.grbLoai_Tien.Tag = "Currency";
            this.grbLoai_Tien.Text = "Loại tiền";
            // 
            // rdbIs_Vnd_Nt
            // 
            this.rdbIs_Vnd_Nt.AutoSize = true;
            this.rdbIs_Vnd_Nt.Location = new System.Drawing.Point(15, 69);
            this.rdbIs_Vnd_Nt.Name = "rdbIs_Vnd_Nt";
            this.rdbIs_Vnd_Nt.Size = new System.Drawing.Size(103, 17);
            this.rdbIs_Vnd_Nt.TabIndex = 1;
            this.rdbIs_Vnd_Nt.Tag = "SSong_Tien";
            this.rdbIs_Vnd_Nt.Text = "Cả &hai đồng tiền";
            this.rdbIs_Vnd_Nt.UnChecked = true;
            this.rdbIs_Vnd_Nt.UseVisualStyleBackColor = true;
            // 
            // rdbIs_Nt
            // 
            this.rdbIs_Nt.AutoSize = true;
            this.rdbIs_Nt.Location = new System.Drawing.Point(15, 46);
            this.rdbIs_Nt.Name = "rdbIs_Nt";
            this.rdbIs_Nt.Size = new System.Drawing.Size(87, 17);
            this.rdbIs_Nt.TabIndex = 0;
            this.rdbIs_Nt.Tag = "Ngoai_Te";
            this.rdbIs_Nt.Text = "Tiền n&goại tệ";
            this.rdbIs_Nt.UnChecked = true;
            this.rdbIs_Nt.UseVisualStyleBackColor = true;
            // 
            // rdbIs_Vnd
            // 
            this.rdbIs_Vnd.AutoSize = true;
            this.rdbIs_Vnd.Checked = true;
            this.rdbIs_Vnd.Location = new System.Drawing.Point(14, 23);
            this.rdbIs_Vnd.Name = "rdbIs_Vnd";
            this.rdbIs_Vnd.Size = new System.Drawing.Size(72, 17);
            this.rdbIs_Vnd.TabIndex = 0;
            this.rdbIs_Vnd.TabStop = true;
            this.rdbIs_Vnd.Tag = "Tien_Current";
            this.rdbIs_Vnd.Text = "Tiền &VND";
            this.rdbIs_Vnd.UnChecked = false;
            this.rdbIs_Vnd.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(650, 551);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "F3 - Change report info";
            // 
            // picReport
            // 
            this.picReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picReport.BackColor = System.Drawing.Color.Transparent;
            this.picReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picReport.Location = new System.Drawing.Point(299, 6);
            this.picReport.Name = "picReport";
            this.picReport.Size = new System.Drawing.Size(342, 558);
            this.picReport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picReport.TabIndex = 5;
            this.picReport.TabStop = false;
            // 
            // grbControl1
            // 
            this.grbControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.grbControl1.BackColor = System.Drawing.Color.Transparent;
            this.grbControl1.Controls.Add(this.rdbOther);
            this.grbControl1.Controls.Add(this.rdbEnglish);
            this.grbControl1.Controls.Add(this.rdbVietnamese);
            this.grbControl1.Location = new System.Drawing.Point(648, 151);
            this.grbControl1.Name = "grbControl1";
            this.grbControl1.Size = new System.Drawing.Size(138, 102);
            this.grbControl1.TabIndex = 6;
            this.grbControl1.TabStop = false;
            this.grbControl1.Tag = "Language_Type";
            this.grbControl1.Text = "Loại ngôn ngữ";
            // 
            // rdbOther
            // 
            this.rdbOther.AutoSize = true;
            this.rdbOther.Location = new System.Drawing.Point(15, 69);
            this.rdbOther.Name = "rdbOther";
            this.rdbOther.Size = new System.Drawing.Size(79, 17);
            this.rdbOther.TabIndex = 1;
            this.rdbOther.Tag = "Other_Language";
            this.rdbOther.Text = "Tiếng khác";
            this.rdbOther.UnChecked = true;
            this.rdbOther.UseVisualStyleBackColor = true;
            // 
            // rdbEnglish
            // 
            this.rdbEnglish.AutoSize = true;
            this.rdbEnglish.Location = new System.Drawing.Point(15, 46);
            this.rdbEnglish.Name = "rdbEnglish";
            this.rdbEnglish.Size = new System.Drawing.Size(73, 17);
            this.rdbEnglish.TabIndex = 0;
            this.rdbEnglish.Tag = "English";
            this.rdbEnglish.Text = "Tiếng anh";
            this.rdbEnglish.UnChecked = true;
            this.rdbEnglish.UseVisualStyleBackColor = true;
            // 
            // rdbVietnamese
            // 
            this.rdbVietnamese.AutoSize = true;
            this.rdbVietnamese.Checked = true;
            this.rdbVietnamese.Location = new System.Drawing.Point(14, 23);
            this.rdbVietnamese.Name = "rdbVietnamese";
            this.rdbVietnamese.Size = new System.Drawing.Size(72, 17);
            this.rdbVietnamese.TabIndex = 0;
            this.rdbVietnamese.TabStop = true;
            this.rdbVietnamese.Tag = "Vietnamese";
            this.rdbVietnamese.Text = "Tiếng việt";
            this.rdbVietnamese.UnChecked = false;
            this.rdbVietnamese.UseVisualStyleBackColor = true;
            // 
            // frmReport
            // 
            this.AcceptButton = this.btRun;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btExit;
            this.ClientSize = new System.Drawing.Size(792, 571);
            this.Controls.Add(this.grbControl1);
            this.Controls.Add(this.picReport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkPrint_Sign);
            this.Controls.Add(this.grbPrint_Sign);
            this.Controls.Add(this.grbLoai_Tien);
            this.Controls.Add(this.pnlRunReport);
            this.Controls.Add(this.tvReport);
            this.Name = "frmReport";
            this.Tag = "frmReport";
            this.Text = "frmReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlRunReport.ResumeLayout(false);
            this.grbPrint_Sign.ResumeLayout(false);
            this.grbPrint_Sign.PerformLayout();
            this.grbLoai_Tien.ResumeLayout(false);
            this.grbLoai_Tien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picReport)).EndInit();
            this.grbControl1.ResumeLayout(false);
            this.grbControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private LinkQ.Systems.Controls.tvControl tvReport;
		private System.Windows.Forms.ImageList imglTree;
        private LinkQ.Systems.Controls.btControl btRun;
		private LinkQ.Systems.Controls.btControl btExit;
        private LinkQ.Systems.Controls.btControl btFormula;
		private LinkQ.Systems.Controls.chkControl chkPrint_Sign;
		private LinkQ.Systems.Controls.pnlControl pnlRunReport;
		private LinkQ.Systems.Controls.grbControl grbPrint_Sign;
		private LinkQ.Systems.Controls.grbControl grbLoai_Tien;
		private LinkQ.Systems.Controls.rdbControl rdbIs_Nt;
		private LinkQ.Systems.Controls.rdbControl rdbIs_Vnd;
		private LinkQ.Systems.Controls.txtTextBox txtName3;
		private LinkQ.Systems.Controls.txtTextBox txtName2;
		private LinkQ.Systems.Controls.txtTextBox txtName1;
		private LinkQ.Systems.Controls.txtTextBox txtSign3;
		private LinkQ.Systems.Controls.txtTextBox txtSign2;
		private LinkQ.Systems.Controls.txtTextBox txtSign1;
		private LinkQ.Systems.Controls.rdbControl rdbIs_Vnd_Nt;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picReport;
        private LinkQ.Systems.Controls.grbControl grbControl1;
        private LinkQ.Systems.Controls.rdbControl rdbOther;
        private LinkQ.Systems.Controls.rdbControl rdbEnglish;
        private LinkQ.Systems.Controls.rdbControl rdbVietnamese;

	}
}