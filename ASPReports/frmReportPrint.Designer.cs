namespace LinkQ.Reports
{
	partial class frmReportPrint
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportPrint));
			
			this.btExport = new LinkQ.Systems.Controls.btControl();
			this.btSendMail = new LinkQ.Systems.Controls.btControl();
			this.lblControl2 = new LinkQ.Systems.Controls.lblControl();
			this.numBottonMargin = new LinkQ.Systems.Controls.numUpDown();
			this.btRefresh = new LinkQ.Systems.Controls.btControl();
			this.numPageFooterHeight = new LinkQ.Systems.Controls.numUpDown();
			this.lblControl3 = new LinkQ.Systems.Controls.lblControl();
			this.numDetailHeight = new LinkQ.Systems.Controls.numUpDown();
			this.lblControl1 = new LinkQ.Systems.Controls.lblControl();
			viewReport = new DataDynamics.ActiveReports.Viewer.Viewer();
			((System.ComponentModel.ISupportInitialize)(this.numBottonMargin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numPageFooterHeight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numDetailHeight)).BeginInit();
			this.SuspendLayout();
			// 
			// btExport
			// 
			this.btExport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btExport.BackgroundImage")));
			this.btExport.Image = global::LinkQ.Reports.Properties.Resources.Export;
			this.btExport.Location = new System.Drawing.Point(711, 2);
			this.btExport.Location2 = new System.Drawing.Point(0, 0);
			this.btExport.Name = "btExport";
			this.btExport.Size = new System.Drawing.Size(24, 24);
			this.btExport.TabIndex = 1;
			this.btExport.UseHotKey = true;
			this.btExport.UseVisualStyleBackColor = true;
			// 
			// btSendMail
			// 
			this.btSendMail.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btSendMail.BackgroundImage")));
			this.btSendMail.Image = global::LinkQ.Reports.Properties.Resources.SenMail;
			this.btSendMail.Location = new System.Drawing.Point(741, 2);
			this.btSendMail.Location2 = new System.Drawing.Point(0, 0);
			this.btSendMail.Name = "btSendMail";
			this.btSendMail.Size = new System.Drawing.Size(24, 24);
			this.btSendMail.TabIndex = 2;
			this.btSendMail.UseHotKey = true;
			this.btSendMail.UseVisualStyleBackColor = true;
			// 
			// lblControl2
			// 
			this.lblControl2.AutoEllipsis = true;
			this.lblControl2.AutoSize = true;
			this.lblControl2.Location = new System.Drawing.Point(881, 10);
			this.lblControl2.Location2 = new System.Drawing.Point(0, 0);
			this.lblControl2.Name = "lblControl2";
			this.lblControl2.Size = new System.Drawing.Size(74, 13);
			this.lblControl2.TabIndex = 1;
			this.lblControl2.Text = "Bottom margin";
			this.lblControl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblControl2.UseHotKey = true;
			// 
			// numBottonMargin
			// 
			this.numBottonMargin.DecimalPlaces = 2;
			this.numBottonMargin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.numBottonMargin.Location = new System.Drawing.Point(957, 6);
			this.numBottonMargin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numBottonMargin.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numBottonMargin.Name = "numBottonMargin";
			this.numBottonMargin.Size = new System.Drawing.Size(55, 20);
			this.numBottonMargin.TabIndex = 2;
			this.numBottonMargin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btRefresh
			// 
			this.btRefresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btRefresh.BackgroundImage")));
			this.btRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.btRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btRefresh.Location = new System.Drawing.Point(1143, 5);
			this.btRefresh.Location2 = new System.Drawing.Point(0, 0);
			this.btRefresh.Name = "btRefresh";
			this.btRefresh.Size = new System.Drawing.Size(60, 22);
			this.btRefresh.TabIndex = 5;
			this.btRefresh.Text = "Refresh";
			this.btRefresh.UseHotKey = true;
			this.btRefresh.UseVisualStyleBackColor = true;
			// 
			// numPageFooterHeight
			// 
			this.numPageFooterHeight.DecimalPlaces = 2;
			this.numPageFooterHeight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.numPageFooterHeight.Location = new System.Drawing.Point(1083, 6);
			this.numPageFooterHeight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numPageFooterHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numPageFooterHeight.Name = "numPageFooterHeight";
			this.numPageFooterHeight.Size = new System.Drawing.Size(55, 20);
			this.numPageFooterHeight.TabIndex = 4;
			this.numPageFooterHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblControl3
			// 
			this.lblControl3.AutoEllipsis = true;
			this.lblControl3.AutoSize = true;
			this.lblControl3.Location = new System.Drawing.Point(1018, 9);
			this.lblControl3.Location2 = new System.Drawing.Point(0, 0);
			this.lblControl3.Name = "lblControl3";
			this.lblControl3.Size = new System.Drawing.Size(62, 13);
			this.lblControl3.TabIndex = 3;
			this.lblControl3.Text = "Page footer";
			this.lblControl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblControl3.UseHotKey = true;
			// 
			// viewReport
			// 
			viewReport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			viewReport.BackColor = System.Drawing.SystemColors.Control;
			viewReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			viewReport.Dock = System.Windows.Forms.DockStyle.Fill;
			viewReport.Document = new DataDynamics.ActiveReports.Document.Document("ARNet Document");
			viewReport.Location = new System.Drawing.Point(0, 0);
			viewReport.Name = "viewReport";
			viewReport.ReportViewer.CurrentPage = 0;
			viewReport.ReportViewer.DisplayUnits = DataDynamics.ActiveReports.Viewer.DisplayUnits.Metric;
			viewReport.ReportViewer.MultiplePageCols = 3;
			viewReport.ReportViewer.MultiplePageRows = 2;
			viewReport.ReportViewer.ViewType = DataDynamics.ActiveReports.Viewer.ViewType.Normal;
			viewReport.Size = new System.Drawing.Size(1354, 566);
			viewReport.TabIndex = 0;
			viewReport.TableOfContents.Text = "Table Of Contents";
			viewReport.TableOfContents.Width = 200;
			viewReport.TabTitleLength = 35;
			viewReport.Toolbar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			// 
			// numDetailHeight
			// 
			this.numDetailHeight.DecimalPlaces = 2;
			this.numDetailHeight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.numDetailHeight.Location = new System.Drawing.Point(818, 6);
			this.numDetailHeight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.numDetailHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numDetailHeight.Name = "numDetailHeight";
			this.numDetailHeight.Size = new System.Drawing.Size(55, 20);
			this.numDetailHeight.TabIndex = 0;
			this.numDetailHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblControl1
			// 
			this.lblControl1.AutoEllipsis = true;
			this.lblControl1.AutoSize = true;
			this.lblControl1.Location = new System.Drawing.Point(784, 9);
			this.lblControl1.Location2 = new System.Drawing.Point(0, 0);
			this.lblControl1.Name = "lblControl1";
			this.lblControl1.Size = new System.Drawing.Size(29, 13);
			this.lblControl1.TabIndex = 3;
			this.lblControl1.Text = "Row";
			this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblControl1.UseHotKey = true;
			// 
			// frmReportPrint
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1354, 566);
			this.Controls.Add(this.numPageFooterHeight);
			this.Controls.Add(this.lblControl3);
			this.Controls.Add(this.btRefresh);
			this.Controls.Add(this.numBottonMargin);
			this.Controls.Add(this.numDetailHeight);
			this.Controls.Add(this.lblControl2);
			this.Controls.Add(this.lblControl1);
			this.Controls.Add(this.btSendMail);
			this.Controls.Add(this.btExport);
			this.Controls.Add(viewReport);
			this.Name = "frmReportPrint";
			this.ShowInTaskbar = true;
			this.Tag = "frmReportPrint";
			this.Text = "frmReportPrint";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			((System.ComponentModel.ISupportInitialize)(this.numBottonMargin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numPageFooterHeight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numDetailHeight)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion


		private LinkQ.Systems.Controls.btControl btExport;
		private LinkQ.Systems.Controls.btControl btSendMail;
		private Systems.Controls.lblControl lblControl2;
		private Systems.Controls.numUpDown numBottonMargin;
		private Systems.Controls.btControl btRefresh;
		private Systems.Controls.numUpDown numPageFooterHeight;
		private Systems.Controls.lblControl lblControl3;
		private Systems.Controls.numUpDown numDetailHeight;
		private Systems.Controls.lblControl lblControl1;

		DataDynamics.ActiveReports.Viewer.Viewer viewReport;
		//DataDynamics.ActiveReports.Viewer.Viewer viewReport;
	}
}