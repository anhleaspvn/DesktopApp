namespace LinkQ.Reports
{
	partial class frmChartOption
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
			this.label1 = new System.Windows.Forms.Label();
			this.cboChartType = new LinkQ.Systems.Controls.cboControl();
			this.chk3D = new LinkQ.Systems.Controls.chkControl();
			this.btgAccept = new LinkQ.Systems.Customizes.btgAccept();
			this.label2 = new System.Windows.Forms.Label();
			this.txtColY_Title = new LinkQ.Systems.Controls.txtTextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtColX_Title = new LinkQ.Systems.Controls.txtTextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Location = new System.Drawing.Point(18, 76);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 13);
			this.label1.TabIndex = 0;
			this.label1.Tag = "ChartType";
			this.label1.Text = "Dạng biểu đồ";
			// 
			// cboChartType
			// 
			this.cboChartType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboChartType.FormattingEnabled = true;
			this.cboChartType.InitValue = "";
			this.cboChartType.Location = new System.Drawing.Point(130, 73);
			this.cboChartType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.cboChartType.Name = "cboChartType";
			this.cboChartType.Size = new System.Drawing.Size(172, 21);
			this.cboChartType.strValueList = "";
			this.cboChartType.TabIndex = 2;
			this.cboChartType.UseAutoComplete = false;
			// 
			// chk3D
			// 
			this.chk3D.AutoSize = true;
			this.chk3D.BackColor = System.Drawing.Color.Transparent;
			this.chk3D.Checked = true;
			this.chk3D.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk3D.Location = new System.Drawing.Point(130, 99);
			this.chk3D.Location2 = new System.Drawing.Point(0, 0);
			this.chk3D.Name = "chk3D";
			this.chk3D.Size = new System.Drawing.Size(69, 17);
			this.chk3D.TabIndex = 3;
			this.chk3D.Text = "Dạng 3D";
			this.chk3D.UseHotKey = true;
			this.chk3D.UseVisualStyleBackColor = false;
			// 
			// btgAccept
			// 
			this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btgAccept.BackColor = System.Drawing.Color.Transparent;
			this.btgAccept.Location = new System.Drawing.Point(231, 142);
			this.btgAccept.Name = "btgAccept";
			this.btgAccept.Size = new System.Drawing.Size(185, 28);
			this.btgAccept.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Location = new System.Drawing.Point(18, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 13);
			this.label2.TabIndex = 0;
			this.label2.Tag = "";
			this.label2.Text = "Tiêu đề cột";
			// 
			// txtColY_Title
			// 
			this.txtColY_Title.AutoFilter = null;
			this.txtColY_Title.bEnabled = true;
			this.txtColY_Title.bReadOnly = false;
			this.txtColY_Title.CtrlDepend = null;
			this.txtColY_Title.Location = new System.Drawing.Point(130, 29);
			this.txtColY_Title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtColY_Title.Name = "txtColY_Title";
			this.txtColY_Title.Require = false;
			this.txtColY_Title.ShowAddButton = false;
			this.txtColY_Title.Size = new System.Drawing.Size(241, 20);
			this.txtColY_Title.strKeyFilter = "";
			this.txtColY_Title.TabIndex = 0;
			this.txtColY_Title.UseAutoFilter = false;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Location = new System.Drawing.Point(18, 54);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(71, 13);
			this.label3.TabIndex = 0;
			this.label3.Tag = "";
			this.label3.Text = "Tiêu đề dòng";
			// 
			// txtColX_Title
			// 
			this.txtColX_Title.AutoFilter = null;
			this.txtColX_Title.bEnabled = true;
			this.txtColX_Title.bReadOnly = false;
			this.txtColX_Title.CtrlDepend = null;
			this.txtColX_Title.Location = new System.Drawing.Point(130, 51);
			this.txtColX_Title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.txtColX_Title.Name = "txtColX_Title";
			this.txtColX_Title.Require = false;
			this.txtColX_Title.ShowAddButton = false;
			this.txtColX_Title.Size = new System.Drawing.Size(241, 20);
			this.txtColX_Title.strKeyFilter = "";
			this.txtColX_Title.TabIndex = 1;
			this.txtColX_Title.UseAutoFilter = false;
			// 
			// frmChartOption
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(428, 182);
			this.Controls.Add(this.txtColX_Title);
			this.Controls.Add(this.txtColY_Title);
			this.Controls.Add(this.btgAccept);
			this.Controls.Add(this.chk3D);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cboChartType);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmChartOption";
			this.Text = "frmChartOption";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		public LinkQ.Systems.Controls.cboControl cboChartType;
		public LinkQ.Systems.Controls.chkControl chk3D;
		private LinkQ.Systems.Customizes.btgAccept btgAccept;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		public LinkQ.Systems.Controls.txtTextBox txtColY_Title;
		public LinkQ.Systems.Controls.txtTextBox txtColX_Title;
	}
}