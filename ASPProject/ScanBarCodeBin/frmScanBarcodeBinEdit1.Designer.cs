namespace ASPProject.ScanBarCodeBin
{
    partial class frmScanBarcodeBinEdit1
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
            this.txtQuantity = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.txtNW = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtGW = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtLotNo = new DevExpress.XtraEditors.TextEdit();
            this.txtWO = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtSBDate = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtBinSize = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNW.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGW.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSBDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBinSize.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(132, 41);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(4);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Properties.DisplayFormat.FormatString = "0";
            this.txtQuantity.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtQuantity.Properties.EditFormat.FormatString = "0";
            this.txtQuantity.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtQuantity.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtQuantity.Properties.MaskSettings.Set("mask", "n0");
            this.txtQuantity.Properties.UseMaskAsDisplayFormat = true;
            this.txtQuantity.Size = new System.Drawing.Size(266, 23);
            this.txtQuantity.TabIndex = 104;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(22, 47);
            this.labelControl11.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(51, 16);
            this.labelControl11.TabIndex = 105;
            this.labelControl11.Text = "Số lượng";
            // 
            // txtNW
            // 
            this.txtNW.Location = new System.Drawing.Point(132, 75);
            this.txtNW.Margin = new System.Windows.Forms.Padding(4);
            this.txtNW.Name = "txtNW";
            this.txtNW.Properties.DisplayFormat.FormatString = "0";
            this.txtNW.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtNW.Properties.EditFormat.FormatString = "0";
            this.txtNW.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtNW.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtNW.Properties.MaskSettings.Set("mask", "n2");
            this.txtNW.Properties.UseMaskAsDisplayFormat = true;
            this.txtNW.Size = new System.Drawing.Size(266, 23);
            this.txtNW.TabIndex = 106;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(22, 81);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(20, 16);
            this.labelControl1.TabIndex = 107;
            this.labelControl1.Text = "NW";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(21, 150);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(36, 16);
            this.labelControl8.TabIndex = 111;
            this.labelControl8.Text = "Lot No";
            // 
            // btCancel
            // 
            this.btCancel.ImageOptions.Image = global::ASPProject.Properties.Resources.close__2_;
            this.btCancel.Location = new System.Drawing.Point(220, 305);
            this.btCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(144, 49);
            this.btCancel.TabIndex = 113;
            this.btCancel.Text = "Đóng";
            // 
            // btSave
            // 
            this.btSave.ImageOptions.Image = global::ASPProject.Properties.Resources.save1;
            this.btSave.Location = new System.Drawing.Point(41, 305);
            this.btSave.Margin = new System.Windows.Forms.Padding(4);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(145, 49);
            this.btSave.TabIndex = 112;
            this.btSave.Text = "Lưu";
            // 
            // txtGW
            // 
            this.txtGW.Location = new System.Drawing.Point(132, 109);
            this.txtGW.Margin = new System.Windows.Forms.Padding(4);
            this.txtGW.Name = "txtGW";
            this.txtGW.Properties.DisplayFormat.FormatString = "0";
            this.txtGW.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtGW.Properties.EditFormat.FormatString = "0";
            this.txtGW.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtGW.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtGW.Properties.MaskSettings.Set("mask", "n2");
            this.txtGW.Properties.UseMaskAsDisplayFormat = true;
            this.txtGW.Size = new System.Drawing.Size(266, 23);
            this.txtGW.TabIndex = 114;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(22, 115);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(20, 16);
            this.labelControl2.TabIndex = 115;
            this.labelControl2.Text = "GW";
            // 
            // txtLotNo
            // 
            this.txtLotNo.Location = new System.Drawing.Point(132, 143);
            this.txtLotNo.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.Properties.UseMaskAsDisplayFormat = true;
            this.txtLotNo.Size = new System.Drawing.Size(266, 23);
            this.txtLotNo.TabIndex = 184;
            // 
            // txtWO
            // 
            this.txtWO.Location = new System.Drawing.Point(132, 177);
            this.txtWO.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtWO.Name = "txtWO";
            this.txtWO.Properties.UseMaskAsDisplayFormat = true;
            this.txtWO.Size = new System.Drawing.Size(266, 23);
            this.txtWO.TabIndex = 186;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(21, 184);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(21, 16);
            this.labelControl3.TabIndex = 185;
            this.labelControl3.Text = "WO";
            // 
            // txtSBDate
            // 
            this.txtSBDate.Location = new System.Drawing.Point(132, 212);
            this.txtSBDate.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtSBDate.Name = "txtSBDate";
            this.txtSBDate.Properties.UseMaskAsDisplayFormat = true;
            this.txtSBDate.Size = new System.Drawing.Size(266, 23);
            this.txtSBDate.TabIndex = 188;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(21, 219);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(45, 16);
            this.labelControl4.TabIndex = 187;
            this.labelControl4.Text = "SB Date";
            // 
            // txtBinSize
            // 
            this.txtBinSize.Location = new System.Drawing.Point(132, 248);
            this.txtBinSize.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtBinSize.Name = "txtBinSize";
            this.txtBinSize.Properties.UseMaskAsDisplayFormat = true;
            this.txtBinSize.Size = new System.Drawing.Size(266, 23);
            this.txtBinSize.TabIndex = 190;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(21, 255);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(45, 16);
            this.labelControl5.TabIndex = 189;
            this.labelControl5.Text = "Bin Size";
            // 
            // frmScanBarcodeBinEdit1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 395);
            this.Controls.Add(this.txtBinSize);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txtSBDate);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtWO);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtLotNo);
            this.Controls.Add(this.txtGW);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.txtNW);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.labelControl11);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmScanBarcodeBinEdit1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập liệu";
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNW.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGW.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSBDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBinSize.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtQuantity;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.TextEdit txtNW;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.SimpleButton btCancel;
        private DevExpress.XtraEditors.SimpleButton btSave;
        private DevExpress.XtraEditors.TextEdit txtGW;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtLotNo;
        private DevExpress.XtraEditors.TextEdit txtWO;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtSBDate;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtBinSize;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}