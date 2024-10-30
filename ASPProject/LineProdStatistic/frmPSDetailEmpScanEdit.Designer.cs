namespace ASPProject.LineProdStatistic
{
    partial class frmPSDetailEmpScanEdit
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
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtReworkQty = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtSortingQty = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lkeMachineID = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtpEndTime = new DevExpress.XtraEditors.TextEdit();
            this.dtpBeginTime = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReworkQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSortingQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeMachineID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBeginTime.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(149, 119);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(4);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtQuantity.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtQuantity.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtQuantity.Properties.MaskSettings.Set("mask", "#####");
            this.txtQuantity.Properties.UseMaskAsDisplayFormat = true;
            this.txtQuantity.Size = new System.Drawing.Size(266, 23);
            this.txtQuantity.TabIndex = 108;
            // 
            // labelControl14
            // 
            this.labelControl14.Location = new System.Drawing.Point(41, 125);
            this.labelControl14.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(54, 16);
            this.labelControl14.TabIndex = 109;
            this.labelControl14.Text = "Số Lượng";
            // 
            // btCancel
            // 
            this.btCancel.ImageOptions.Image = global::ASPProject.Properties.Resources.close__2_;
            this.btCancel.Location = new System.Drawing.Point(282, 231);
            this.btCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(144, 49);
            this.btCancel.TabIndex = 112;
            this.btCancel.Text = "Đóng";
            // 
            // btSave
            // 
            this.btSave.ImageOptions.Image = global::ASPProject.Properties.Resources.save1;
            this.btSave.Location = new System.Drawing.Point(103, 231);
            this.btSave.Margin = new System.Windows.Forms.Padding(4);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(145, 49);
            this.btSave.TabIndex = 111;
            this.btSave.Text = "Lưu";
            // 
            // txtReworkQty
            // 
            this.txtReworkQty.Location = new System.Drawing.Point(149, 150);
            this.txtReworkQty.Margin = new System.Windows.Forms.Padding(4);
            this.txtReworkQty.Name = "txtReworkQty";
            this.txtReworkQty.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtReworkQty.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtReworkQty.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtReworkQty.Properties.MaskSettings.Set("mask", "#####");
            this.txtReworkQty.Properties.UseMaskAsDisplayFormat = true;
            this.txtReworkQty.Size = new System.Drawing.Size(266, 23);
            this.txtReworkQty.TabIndex = 113;
            this.txtReworkQty.Visible = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(41, 156);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(62, 16);
            this.labelControl2.TabIndex = 114;
            this.labelControl2.Text = "SL Rework";
            this.labelControl2.Visible = false;
            // 
            // txtSortingQty
            // 
            this.txtSortingQty.Location = new System.Drawing.Point(149, 181);
            this.txtSortingQty.Margin = new System.Windows.Forms.Padding(4);
            this.txtSortingQty.Name = "txtSortingQty";
            this.txtSortingQty.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSortingQty.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSortingQty.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtSortingQty.Properties.MaskSettings.Set("mask", "#####");
            this.txtSortingQty.Properties.UseMaskAsDisplayFormat = true;
            this.txtSortingQty.Size = new System.Drawing.Size(266, 23);
            this.txtSortingQty.TabIndex = 116;
            this.txtSortingQty.Visible = false;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(41, 187);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(59, 16);
            this.labelControl4.TabIndex = 117;
            this.labelControl4.Text = "SL Sorting";
            this.labelControl4.Visible = false;
            // 
            // lkeMachineID
            // 
            this.lkeMachineID.EditValue = "";
            this.lkeMachineID.Location = new System.Drawing.Point(149, 26);
            this.lkeMachineID.Name = "lkeMachineID";
            this.lkeMachineID.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeMachineID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeMachineID.Properties.NullText = "";
            this.lkeMachineID.Size = new System.Drawing.Size(266, 23);
            this.lkeMachineID.TabIndex = 119;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(41, 33);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(45, 16);
            this.labelControl1.TabIndex = 120;
            this.labelControl1.Text = "Mã máy";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Location = new System.Drawing.Point(149, 88);
            this.dtpEndTime.Margin = new System.Windows.Forms.Padding(4);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.dtpEndTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.dtpEndTime.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.DateTimeMaskManager));
            this.dtpEndTime.Properties.MaskSettings.Set("mask", "HH: mm: ss");
            this.dtpEndTime.Properties.UseMaskAsDisplayFormat = true;
            this.dtpEndTime.Size = new System.Drawing.Size(187, 23);
            this.dtpEndTime.TabIndex = 122;
            // 
            // dtpBeginTime
            // 
            this.dtpBeginTime.Location = new System.Drawing.Point(149, 57);
            this.dtpBeginTime.Margin = new System.Windows.Forms.Padding(4);
            this.dtpBeginTime.Name = "dtpBeginTime";
            this.dtpBeginTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.dtpBeginTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.dtpBeginTime.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.DateTimeMaskManager));
            this.dtpBeginTime.Properties.MaskSettings.Set("mask", "HH: mm: ss");
            this.dtpBeginTime.Properties.UseMaskAsDisplayFormat = true;
            this.dtpBeginTime.Size = new System.Drawing.Size(187, 23);
            this.dtpBeginTime.TabIndex = 121;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(41, 64);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(42, 16);
            this.labelControl3.TabIndex = 123;
            this.labelControl3.Text = "Giờ vào";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(41, 95);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(34, 16);
            this.labelControl5.TabIndex = 124;
            this.labelControl5.Text = "Giờ ra";
            // 
            // frmPSDetailEmpScanEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 301);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.dtpEndTime);
            this.Controls.Add(this.dtpBeginTime);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lkeMachineID);
            this.Controls.Add(this.txtSortingQty);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtReworkQty);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.labelControl14);
            this.Name = "frmPSDetailEmpScanEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPSDetailEmpScanEdit";
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReworkQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSortingQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeMachineID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBeginTime.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit txtQuantity;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.SimpleButton btCancel;
        private DevExpress.XtraEditors.SimpleButton btSave;
        private DevExpress.XtraEditors.TextEdit txtReworkQty;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtSortingQty;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LookUpEdit lkeMachineID;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit dtpEndTime;
        private DevExpress.XtraEditors.TextEdit dtpBeginTime;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}