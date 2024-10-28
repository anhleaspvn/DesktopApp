namespace ASPProject.LineProdStatistic
{
    partial class frmPSDetailMoldEdit
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
            this.txtNumOfStamp = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btSave = new DevExpress.XtraEditors.SimpleButton();
            this.lkeMoldID = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.lbMoldID = new DevExpress.XtraEditors.LabelControl();
            this.lkeStampBy = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtProdQuantity = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumOfStamp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeMoldID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeStampBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProdQuantity.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNumOfStamp
            // 
            this.txtNumOfStamp.Location = new System.Drawing.Point(163, 83);
            this.txtNumOfStamp.Margin = new System.Windows.Forms.Padding(8);
            this.txtNumOfStamp.Name = "txtNumOfStamp";
            this.txtNumOfStamp.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtNumOfStamp.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtNumOfStamp.Properties.UseMaskAsDisplayFormat = true;
            this.txtNumOfStamp.Size = new System.Drawing.Size(226, 22);
            this.txtNumOfStamp.TabIndex = 125;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(22, 89);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 16);
            this.labelControl1.TabIndex = 130;
            this.labelControl1.Text = "Số lần dập";
            // 
            // btCancel
            // 
            this.btCancel.ImageOptions.Image = global::ASPProject.Properties.Resources.close__2_;
            this.btCancel.Location = new System.Drawing.Point(326, 162);
            this.btCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(180, 61);
            this.btCancel.TabIndex = 127;
            this.btCancel.Text = "Đóng";
            // 
            // btSave
            // 
            this.btSave.ImageOptions.Image = global::ASPProject.Properties.Resources.save1;
            this.btSave.Location = new System.Drawing.Point(103, 162);
            this.btSave.Margin = new System.Windows.Forms.Padding(5);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(181, 61);
            this.btSave.TabIndex = 126;
            this.btSave.Text = "Lưu";
            // 
            // lkeMoldID
            // 
            this.lkeMoldID.EditValue = "";
            this.lkeMoldID.Location = new System.Drawing.Point(163, 14);
            this.lkeMoldID.Margin = new System.Windows.Forms.Padding(5);
            this.lkeMoldID.Name = "lkeMoldID";
            this.lkeMoldID.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeMoldID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeMoldID.Properties.NullText = "";
            this.lkeMoldID.Size = new System.Drawing.Size(226, 22);
            this.lkeMoldID.TabIndex = 124;
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl12.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl12.Appearance.Options.UseBackColor = true;
            this.labelControl12.Appearance.Options.UseForeColor = true;
            this.labelControl12.Location = new System.Drawing.Point(127, 17);
            this.labelControl12.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(18, 16);
            this.labelControl12.TabIndex = 128;
            this.labelControl12.Text = "(*)";
            // 
            // lbMoldID
            // 
            this.lbMoldID.Location = new System.Drawing.Point(22, 17);
            this.lbMoldID.Margin = new System.Windows.Forms.Padding(6);
            this.lbMoldID.Name = "lbMoldID";
            this.lbMoldID.Size = new System.Drawing.Size(55, 16);
            this.lbMoldID.TabIndex = 129;
            this.lbMoldID.Text = "Mã khuôn";
            // 
            // lkeStampBy
            // 
            this.lkeStampBy.EditValue = "";
            this.lkeStampBy.Location = new System.Drawing.Point(163, 119);
            this.lkeStampBy.Margin = new System.Windows.Forms.Padding(5);
            this.lkeStampBy.Name = "lkeStampBy";
            this.lkeStampBy.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeStampBy.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeStampBy.Properties.NullText = "";
            this.lkeStampBy.Size = new System.Drawing.Size(226, 22);
            this.lkeStampBy.TabIndex = 131;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(22, 126);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(83, 16);
            this.labelControl2.TabIndex = 132;
            this.labelControl2.Text = "Người thao tác";
            // 
            // txtProdQuantity
            // 
            this.txtProdQuantity.Location = new System.Drawing.Point(163, 48);
            this.txtProdQuantity.Margin = new System.Windows.Forms.Padding(8);
            this.txtProdQuantity.Name = "txtProdQuantity";
            this.txtProdQuantity.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtProdQuantity.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtProdQuantity.Properties.UseMaskAsDisplayFormat = true;
            this.txtProdQuantity.Size = new System.Drawing.Size(226, 22);
            this.txtProdQuantity.TabIndex = 133;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(22, 55);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(70, 16);
            this.labelControl3.TabIndex = 134;
            this.labelControl3.Text = "Số lượng TP";
            // 
            // frmPSDetailMoldEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 257);
            this.Controls.Add(this.txtProdQuantity);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.lkeStampBy);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtNumOfStamp);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.lkeMoldID);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.lbMoldID);
            this.Name = "frmPSDetailMoldEdit";
            this.Text = "frmPSDetailMoldEdit";
            ((System.ComponentModel.ISupportInitialize)(this.txtNumOfStamp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeMoldID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeStampBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProdQuantity.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtNumOfStamp;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btCancel;
        private DevExpress.XtraEditors.SimpleButton btSave;
        private DevExpress.XtraEditors.LookUpEdit lkeMoldID;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl lbMoldID;
        private DevExpress.XtraEditors.LookUpEdit lkeStampBy;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtProdQuantity;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}