namespace ASPProject.ProdQRCodeMaster
{
    partial class frmProdScanQRCodeLog
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
            this.lbNG = new DevExpress.XtraEditors.LabelControl();
            this.lbOK = new DevExpress.XtraEditors.LabelControl();
            this.txtQRCodeData = new System.Windows.Forms.TextBox();
            this.lkeProduct = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridQRCodeLog = new DevExpress.XtraGrid.GridControl();
            this.gridQRCodeLogView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLogID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStageID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStageName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQRCodeData = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkeProduct.Properties)).BeginInit();
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
            this.splitContainerControl1.Panel1.Controls.Add(this.lbNG);
            this.splitContainerControl1.Panel1.Controls.Add(this.lbOK);
            this.splitContainerControl1.Panel1.Controls.Add(this.txtQRCodeData);
            this.splitContainerControl1.Panel1.Controls.Add(this.lkeProduct);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.gridQRCodeLog);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1259, 633);
            this.splitContainerControl1.SplitterPosition = 133;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // lbNG
            // 
            this.lbNG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbNG.Appearance.BackColor = System.Drawing.Color.Red;
            this.lbNG.Appearance.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNG.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.lbNG.Appearance.Options.UseBackColor = true;
            this.lbNG.Appearance.Options.UseFont = true;
            this.lbNG.Appearance.Options.UseForeColor = true;
            this.lbNG.Appearance.Options.UseTextOptions = true;
            this.lbNG.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbNG.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbNG.Location = new System.Drawing.Point(1087, 18);
            this.lbNG.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.lbNG.MaximumSize = new System.Drawing.Size(150, 100);
            this.lbNG.MinimumSize = new System.Drawing.Size(150, 100);
            this.lbNG.Name = "lbNG";
            this.lbNG.Size = new System.Drawing.Size(150, 100);
            this.lbNG.TabIndex = 79;
            this.lbNG.Text = "NG";
            this.lbNG.Visible = false;
            // 
            // lbOK
            // 
            this.lbOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbOK.Appearance.BackColor = System.Drawing.Color.Green;
            this.lbOK.Appearance.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOK.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.lbOK.Appearance.Options.UseBackColor = true;
            this.lbOK.Appearance.Options.UseFont = true;
            this.lbOK.Appearance.Options.UseForeColor = true;
            this.lbOK.Appearance.Options.UseTextOptions = true;
            this.lbOK.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbOK.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbOK.Location = new System.Drawing.Point(913, 18);
            this.lbOK.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.lbOK.MaximumSize = new System.Drawing.Size(150, 100);
            this.lbOK.MinimumSize = new System.Drawing.Size(150, 100);
            this.lbOK.Name = "lbOK";
            this.lbOK.Size = new System.Drawing.Size(150, 100);
            this.lbOK.TabIndex = 78;
            this.lbOK.Text = "OK";
            this.lbOK.Visible = false;
            // 
            // txtQRCodeData
            // 
            this.txtQRCodeData.BackColor = System.Drawing.Color.Cyan;
            this.txtQRCodeData.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQRCodeData.Location = new System.Drawing.Point(361, 33);
            this.txtQRCodeData.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtQRCodeData.MaximumSize = new System.Drawing.Size(500, 200);
            this.txtQRCodeData.MinimumSize = new System.Drawing.Size(400, 70);
            this.txtQRCodeData.Name = "txtQRCodeData";
            this.txtQRCodeData.Size = new System.Drawing.Size(500, 70);
            this.txtQRCodeData.TabIndex = 77;
            // 
            // lkeProduct
            // 
            this.lkeProduct.EditValue = "";
            this.lkeProduct.Location = new System.Drawing.Point(35, 50);
            this.lkeProduct.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.lkeProduct.MaximumSize = new System.Drawing.Size(500, 62);
            this.lkeProduct.MinimumSize = new System.Drawing.Size(250, 37);
            this.lkeProduct.Name = "lkeProduct";
            this.lkeProduct.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lkeProduct.Properties.Appearance.ForeColor = System.Drawing.Color.DarkOrange;
            this.lkeProduct.Properties.Appearance.Options.UseFont = true;
            this.lkeProduct.Properties.Appearance.Options.UseForeColor = true;
            this.lkeProduct.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeProduct.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeProduct.Properties.NullText = "";
            this.lkeProduct.Properties.ReadOnly = true;
            this.lkeProduct.Size = new System.Drawing.Size(250, 30);
            this.lkeProduct.TabIndex = 75;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(35, 17);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(76, 28);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "STAGE";
            // 
            // gridQRCodeLog
            // 
            this.gridQRCodeLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridQRCodeLog.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.gridQRCodeLog.Location = new System.Drawing.Point(0, 0);
            this.gridQRCodeLog.MainView = this.gridQRCodeLogView;
            this.gridQRCodeLog.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.gridQRCodeLog.Name = "gridQRCodeLog";
            this.gridQRCodeLog.Size = new System.Drawing.Size(1259, 493);
            this.gridQRCodeLog.TabIndex = 9;
            this.gridQRCodeLog.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridQRCodeLogView});
            // 
            // gridQRCodeLogView
            // 
            this.gridQRCodeLogView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLogID,
            this.colStageID,
            this.colStageName,
            this.colLogResult,
            this.colLogTime,
            this.colQRCodeData});
            this.gridQRCodeLogView.GridControl = this.gridQRCodeLog;
            this.gridQRCodeLogView.Name = "gridQRCodeLogView";
            this.gridQRCodeLogView.OptionsBehavior.Editable = false;
            this.gridQRCodeLogView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridQRCodeLogView.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridQRCodeLogView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridQRCodeLogView.OptionsView.ShowAutoFilterRow = true;
            this.gridQRCodeLogView.OptionsView.ShowGroupPanel = false;
            // 
            // colLogID
            // 
            this.colLogID.Caption = "Log ID";
            this.colLogID.FieldName = "LogID";
            this.colLogID.MinWidth = 24;
            this.colLogID.Name = "colLogID";
            this.colLogID.Visible = true;
            this.colLogID.VisibleIndex = 0;
            this.colLogID.Width = 94;
            // 
            // colStageID
            // 
            this.colStageID.Caption = "Stage ID";
            this.colStageID.FieldName = "StageID";
            this.colStageID.MinWidth = 24;
            this.colStageID.Name = "colStageID";
            this.colStageID.Visible = true;
            this.colStageID.VisibleIndex = 1;
            this.colStageID.Width = 94;
            // 
            // colStageName
            // 
            this.colStageName.Caption = "Stage Name";
            this.colStageName.FieldName = "StageName";
            this.colStageName.MinWidth = 23;
            this.colStageName.Name = "colStageName";
            this.colStageName.Visible = true;
            this.colStageName.VisibleIndex = 2;
            this.colStageName.Width = 87;
            // 
            // colLogResult
            // 
            this.colLogResult.Caption = "Log Result";
            this.colLogResult.FieldName = "LogResult";
            this.colLogResult.MinWidth = 24;
            this.colLogResult.Name = "colLogResult";
            this.colLogResult.Visible = true;
            this.colLogResult.VisibleIndex = 3;
            this.colLogResult.Width = 94;
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
            this.colLogTime.VisibleIndex = 4;
            this.colLogTime.Width = 94;
            // 
            // colQRCodeData
            // 
            this.colQRCodeData.Caption = "QR Code Data";
            this.colQRCodeData.FieldName = "QRCodeData";
            this.colQRCodeData.MinWidth = 25;
            this.colQRCodeData.Name = "colQRCodeData";
            this.colQRCodeData.Visible = true;
            this.colQRCodeData.VisibleIndex = 5;
            this.colQRCodeData.Width = 87;
            // 
            // frmProdScanQRCodeLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 633);
            this.Controls.Add(this.splitContainerControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "frmProdScanQRCodeLog";
            this.Text = "frmProdScanQRCodeLog";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            this.splitContainerControl1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lkeProduct.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridQRCodeLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridQRCodeLogView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridQRCodeLog;
        private DevExpress.XtraGrid.Views.Grid.GridView gridQRCodeLogView;
        private DevExpress.XtraGrid.Columns.GridColumn colLogID;
        private DevExpress.XtraGrid.Columns.GridColumn colStageID;
        private DevExpress.XtraGrid.Columns.GridColumn colLogResult;
        private DevExpress.XtraGrid.Columns.GridColumn colLogTime;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.TextBox txtQRCodeData;
        private DevExpress.XtraEditors.LookUpEdit lkeProduct;
        private DevExpress.XtraEditors.LabelControl lbOK;
        private DevExpress.XtraEditors.LabelControl lbNG;
        private DevExpress.XtraGrid.Columns.GridColumn colStageName;
        private DevExpress.XtraGrid.Columns.GridColumn colQRCodeData;
    }
}