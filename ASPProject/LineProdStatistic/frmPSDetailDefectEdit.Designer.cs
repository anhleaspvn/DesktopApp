namespace ASPProject.LineProdStatistic
{
    partial class frmPSDetailDefectEdit
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
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.lbLosstimeID = new DevExpress.XtraEditors.LabelControl();
            this.lkeDefectiD = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtFQCQuantity = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtScrapFQCQuantity = new DevExpress.XtraEditors.TextEdit();
            this.txtPrevFQCQuantity = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtFQCReworkQuantity = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtStageID = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeDefectiD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFQCQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtScrapFQCQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrevFQCQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFQCReworkQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStageID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl12.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl12.Appearance.Options.UseBackColor = true;
            this.labelControl12.Appearance.Options.UseForeColor = true;
            this.labelControl12.Location = new System.Drawing.Point(179, 60);
            this.labelControl12.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(18, 16);
            this.labelControl12.TabIndex = 71;
            this.labelControl12.Text = "(*)";
            // 
            // lbLosstimeID
            // 
            this.lbLosstimeID.Location = new System.Drawing.Point(29, 60);
            this.lbLosstimeID.Margin = new System.Windows.Forms.Padding(6);
            this.lbLosstimeID.Name = "lbLosstimeID";
            this.lbLosstimeID.Size = new System.Drawing.Size(57, 16);
            this.lbLosstimeID.TabIndex = 73;
            this.lbLosstimeID.Text = "Mã Defect";
            // 
            // lkeDefectiD
            // 
            this.lkeDefectiD.EditValue = "";
            this.lkeDefectiD.Location = new System.Drawing.Point(215, 57);
            this.lkeDefectiD.Margin = new System.Windows.Forms.Padding(5);
            this.lkeDefectiD.Name = "lkeDefectiD";
            this.lkeDefectiD.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeDefectiD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeDefectiD.Properties.NullText = "";
            this.lkeDefectiD.Size = new System.Drawing.Size(270, 23);
            this.lkeDefectiD.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(29, 128);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(114, 16);
            this.labelControl1.TabIndex = 77;
            this.labelControl1.Text = "Số lượng lỗi tại FQC";
            // 
            // txtFQCQuantity
            // 
            this.txtFQCQuantity.Location = new System.Drawing.Point(215, 122);
            this.txtFQCQuantity.Margin = new System.Windows.Forms.Padding(8);
            this.txtFQCQuantity.Name = "txtFQCQuantity";
            this.txtFQCQuantity.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtFQCQuantity.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtFQCQuantity.Properties.UseMaskAsDisplayFormat = true;
            this.txtFQCQuantity.Size = new System.Drawing.Size(270, 23);
            this.txtFQCQuantity.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(29, 193);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(10);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(75, 16);
            this.labelControl2.TabIndex = 115;
            this.labelControl2.Text = "Số lượng huỷ";
            // 
            // txtScrapFQCQuantity
            // 
            this.txtScrapFQCQuantity.Location = new System.Drawing.Point(215, 187);
            this.txtScrapFQCQuantity.Margin = new System.Windows.Forms.Padding(10);
            this.txtScrapFQCQuantity.Name = "txtScrapFQCQuantity";
            this.txtScrapFQCQuantity.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtScrapFQCQuantity.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtScrapFQCQuantity.Properties.UseMaskAsDisplayFormat = true;
            this.txtScrapFQCQuantity.Size = new System.Drawing.Size(270, 23);
            this.txtScrapFQCQuantity.TabIndex = 5;
            // 
            // txtPrevFQCQuantity
            // 
            this.txtPrevFQCQuantity.Location = new System.Drawing.Point(215, 89);
            this.txtPrevFQCQuantity.Margin = new System.Windows.Forms.Padding(10);
            this.txtPrevFQCQuantity.Name = "txtPrevFQCQuantity";
            this.txtPrevFQCQuantity.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPrevFQCQuantity.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPrevFQCQuantity.Properties.UseMaskAsDisplayFormat = true;
            this.txtPrevFQCQuantity.Size = new System.Drawing.Size(270, 23);
            this.txtPrevFQCQuantity.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(30, 93);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(10);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(130, 16);
            this.labelControl3.TabIndex = 117;
            this.labelControl3.Text = "Số lượng lỗi trước FQC";
            // 
            // btCancel
            // 
            this.btCancel.ImageOptions.Image = global::ASPProject.Properties.Resources.close__2_;
            this.btCancel.Location = new System.Drawing.Point(305, 291);
            this.btCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(180, 61);
            this.btCancel.TabIndex = 120;
            this.btCancel.Text = "Đóng";
            // 
            // btSave
            // 
            this.btSave.ImageOptions.Image = global::ASPProject.Properties.Resources.save1;
            this.btSave.Location = new System.Drawing.Point(82, 291);
            this.btSave.Margin = new System.Windows.Forms.Padding(5);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(181, 61);
            this.btSave.TabIndex = 119;
            this.btSave.Text = "Lưu";
            // 
            // txtFQCReworkQuantity
            // 
            this.txtFQCReworkQuantity.Location = new System.Drawing.Point(215, 155);
            this.txtFQCReworkQuantity.Margin = new System.Windows.Forms.Padding(10);
            this.txtFQCReworkQuantity.Name = "txtFQCReworkQuantity";
            this.txtFQCReworkQuantity.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtFQCReworkQuantity.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtFQCReworkQuantity.Properties.UseMaskAsDisplayFormat = true;
            this.txtFQCReworkQuantity.Size = new System.Drawing.Size(270, 23);
            this.txtFQCReworkQuantity.TabIndex = 4;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(29, 161);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(10);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(128, 16);
            this.labelControl4.TabIndex = 121;
            this.labelControl4.Text = "Số lượng sửa hàng OK";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(30, 31);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(80, 16);
            this.labelControl6.TabIndex = 124;
            this.labelControl6.Text = "Mã công đoạn";
            this.labelControl6.Visible = false;
            // 
            // txtStageID
            // 
            this.txtStageID.Location = new System.Drawing.Point(215, 24);
            this.txtStageID.Margin = new System.Windows.Forms.Padding(10);
            this.txtStageID.Name = "txtStageID";
            this.txtStageID.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtStageID.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtStageID.Properties.ReadOnly = true;
            this.txtStageID.Properties.UseMaskAsDisplayFormat = true;
            this.txtStageID.Size = new System.Drawing.Size(270, 23);
            this.txtStageID.TabIndex = 125;
            this.txtStageID.Visible = false;
            // 
            // frmPSDetailDefectEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 396);
            this.Controls.Add(this.txtStageID);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.txtFQCReworkQuantity);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.txtPrevFQCQuantity);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtScrapFQCQuantity);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtFQCQuantity);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lkeDefectiD);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.lbLosstimeID);
            this.Name = "frmPSDetailDefectEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nhập Defective mode";
            ((System.ComponentModel.ISupportInitialize)(this.lkeDefectiD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFQCQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtScrapFQCQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrevFQCQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFQCReworkQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStageID.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl lbLosstimeID;
        private DevExpress.XtraEditors.LookUpEdit lkeDefectiD;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtFQCQuantity;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtScrapFQCQuantity;
        private DevExpress.XtraEditors.TextEdit txtPrevFQCQuantity;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btCancel;
        private DevExpress.XtraEditors.SimpleButton btSave;
        private DevExpress.XtraEditors.TextEdit txtFQCReworkQuantity;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtStageID;
    }
}