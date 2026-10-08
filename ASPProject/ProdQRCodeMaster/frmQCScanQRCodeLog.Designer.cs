namespace ASPProject.ProdQRCodeMaster
{
    partial class frmQCScanQRCodeLog
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.txtQRCodeData = new System.Windows.Forms.TextBox();
            this.gridQRCodeLog = new DevExpress.XtraGrid.GridControl();
            this.gridQRCodeLogView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colWODocNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQRCodeData = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridQRCodeLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridQRCodeLogView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Controls.Add(this.txtQRCodeData);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.gridQRCodeLog);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1172, 659);
            this.splitContainerControl1.SplitterPosition = 82;
            this.splitContainerControl1.TabIndex = 1;
            // 
            // txtQRCodeData
            // 
            this.txtQRCodeData.BackColor = System.Drawing.Color.Cyan;
            this.txtQRCodeData.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQRCodeData.Location = new System.Drawing.Point(56, 11);
            this.txtQRCodeData.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtQRCodeData.MaximumSize = new System.Drawing.Size(500, 200);
            this.txtQRCodeData.MinimumSize = new System.Drawing.Size(400, 40);
            this.txtQRCodeData.Name = "txtQRCodeData";
            this.txtQRCodeData.Size = new System.Drawing.Size(437, 36);
            this.txtQRCodeData.TabIndex = 77;
            // 
            // gridQRCodeLog
            // 
            this.gridQRCodeLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridQRCodeLog.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.gridQRCodeLog.Location = new System.Drawing.Point(0, 0);
            this.gridQRCodeLog.MainView = this.gridQRCodeLogView;
            this.gridQRCodeLog.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.gridQRCodeLog.Name = "gridQRCodeLog";
            this.gridQRCodeLog.Size = new System.Drawing.Size(1172, 570);
            this.gridQRCodeLog.TabIndex = 9;
            this.gridQRCodeLog.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridQRCodeLogView});
            // 
            // gridQRCodeLogView
            // 
            this.gridQRCodeLogView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colWODocNo,
            this.colLogTime,
            this.colQRCodeData,
            this.colEmpName,
            this.colNGDescription,
            this.colResult});
            this.gridQRCodeLogView.GridControl = this.gridQRCodeLog;
            this.gridQRCodeLogView.Name = "gridQRCodeLogView";
            this.gridQRCodeLogView.OptionsBehavior.Editable = false;
            this.gridQRCodeLogView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridQRCodeLogView.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridQRCodeLogView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridQRCodeLogView.OptionsView.ShowAutoFilterRow = true;
            this.gridQRCodeLogView.OptionsView.ShowGroupPanel = false;
            // 
            // colWODocNo
            // 
            this.colWODocNo.Caption = "W.O";
            this.colWODocNo.FieldName = "WODocNo";
            this.colWODocNo.MinWidth = 25;
            this.colWODocNo.Name = "colWODocNo";
            this.colWODocNo.Visible = true;
            this.colWODocNo.VisibleIndex = 0;
            this.colWODocNo.Width = 94;
            // 
            // colLogTime
            // 
            this.colLogTime.Caption = "Log Time";
            this.colLogTime.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.colLogTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colLogTime.FieldName = "LogTime";
            this.colLogTime.MinWidth = 24;
            this.colLogTime.Name = "colLogTime";
            this.colLogTime.Visible = true;
            this.colLogTime.VisibleIndex = 1;
            this.colLogTime.Width = 94;
            // 
            // colQRCodeData
            // 
            this.colQRCodeData.Caption = "QR Code Data";
            this.colQRCodeData.FieldName = "QRCodeData";
            this.colQRCodeData.MinWidth = 25;
            this.colQRCodeData.Name = "colQRCodeData";
            this.colQRCodeData.Visible = true;
            this.colQRCodeData.VisibleIndex = 2;
            this.colQRCodeData.Width = 87;
            // 
            // colEmpName
            // 
            this.colEmpName.Caption = "Employee";
            this.colEmpName.FieldName = "EmpName";
            this.colEmpName.MinWidth = 25;
            this.colEmpName.Name = "colEmpName";
            this.colEmpName.Visible = true;
            this.colEmpName.VisibleIndex = 3;
            this.colEmpName.Width = 94;
            // 
            // colNGDescription
            // 
            this.colNGDescription.Caption = "NG Description";
            this.colNGDescription.FieldName = "NGDescription";
            this.colNGDescription.MinWidth = 25;
            this.colNGDescription.Name = "colNGDescription";
            this.colNGDescription.Visible = true;
            this.colNGDescription.VisibleIndex = 4;
            this.colNGDescription.Width = 94;
            // 
            // colResult
            // 
            this.colResult.Caption = "Result";
            this.colResult.FieldName = "ScanResult";
            this.colResult.MinWidth = 25;
            this.colResult.Name = "colResult";
            this.colResult.Visible = true;
            this.colResult.VisibleIndex = 5;
            this.colResult.Width = 94;
            // 
            // frmQCScanQRCodeLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 659);
            this.Controls.Add(this.splitContainerControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmQCScanQRCodeLog";
            this.Text = "frmQCScanQRCodeLog";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            this.splitContainerControl1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridQRCodeLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridQRCodeLogView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private System.Windows.Forms.TextBox txtQRCodeData;
        private DevExpress.XtraGrid.GridControl gridQRCodeLog;
        private DevExpress.XtraGrid.Views.Grid.GridView gridQRCodeLogView;
        private DevExpress.XtraGrid.Columns.GridColumn colLogTime;
        private DevExpress.XtraGrid.Columns.GridColumn colQRCodeData;
        private DevExpress.XtraGrid.Columns.GridColumn colWODocNo;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpName;
        private DevExpress.XtraGrid.Columns.GridColumn colNGDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colResult;
    }
}