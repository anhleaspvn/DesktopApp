namespace ASPProject.ExternalIQC
{
    partial class frmExternalIQCDetailContentEdit
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
            this.txtIQCTemplateQuantity = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lkeIQCCheckID = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.lbLosstimeID = new DevExpress.XtraEditors.LabelControl();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtEvalueResult = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtIQCCheckCont = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtIQCPeriodTime = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIQCTemplateQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeIQCCheckID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEvalueResult.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIQCCheckCont.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIQCPeriodTime.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIQCTemplateQuantity
            // 
            this.txtIQCTemplateQuantity.Location = new System.Drawing.Point(222, 105);
            this.txtIQCTemplateQuantity.Margin = new System.Windows.Forms.Padding(10);
            this.txtIQCTemplateQuantity.Name = "txtIQCTemplateQuantity";
            this.txtIQCTemplateQuantity.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtIQCTemplateQuantity.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtIQCTemplateQuantity.Properties.UseMaskAsDisplayFormat = true;
            this.txtIQCTemplateQuantity.Size = new System.Drawing.Size(270, 23);
            this.txtIQCTemplateQuantity.TabIndex = 119;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(37, 109);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(10);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(80, 16);
            this.labelControl3.TabIndex = 122;
            this.labelControl3.Text = "Số lượng mẫu";
            // 
            // lkeIQCCheckID
            // 
            this.lkeIQCCheckID.EditValue = "";
            this.lkeIQCCheckID.Location = new System.Drawing.Point(222, 40);
            this.lkeIQCCheckID.Margin = new System.Windows.Forms.Padding(5);
            this.lkeIQCCheckID.Name = "lkeIQCCheckID";
            this.lkeIQCCheckID.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeIQCCheckID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeIQCCheckID.Properties.NullText = "";
            this.lkeIQCCheckID.Size = new System.Drawing.Size(270, 23);
            this.lkeIQCCheckID.TabIndex = 118;
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl12.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl12.Appearance.Options.UseBackColor = true;
            this.labelControl12.Appearance.Options.UseForeColor = true;
            this.labelControl12.Location = new System.Drawing.Point(186, 43);
            this.labelControl12.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(18, 16);
            this.labelControl12.TabIndex = 120;
            this.labelControl12.Text = "(*)";
            // 
            // lbLosstimeID
            // 
            this.lbLosstimeID.Location = new System.Drawing.Point(36, 43);
            this.lbLosstimeID.Margin = new System.Windows.Forms.Padding(6);
            this.lbLosstimeID.Name = "lbLosstimeID";
            this.lbLosstimeID.Size = new System.Drawing.Size(70, 16);
            this.lbLosstimeID.TabIndex = 121;
            this.lbLosstimeID.Text = "Mã nội dung";
            // 
            // btCancel
            // 
            this.btCancel.ImageOptions.Image = global::ASPProject.Properties.Resources.close__2_;
            this.btCancel.Location = new System.Drawing.Point(284, 226);
            this.btCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(180, 61);
            this.btCancel.TabIndex = 124;
            this.btCancel.Text = "Đóng";
            // 
            // btSave
            // 
            this.btSave.ImageOptions.Image = global::ASPProject.Properties.Resources.save1;
            this.btSave.Location = new System.Drawing.Point(61, 226);
            this.btSave.Margin = new System.Windows.Forms.Padding(5);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(181, 61);
            this.btSave.TabIndex = 123;
            this.btSave.Text = "Lưu";
            // 
            // txtEvalueResult
            // 
            this.txtEvalueResult.Location = new System.Drawing.Point(222, 136);
            this.txtEvalueResult.Margin = new System.Windows.Forms.Padding(10);
            this.txtEvalueResult.Name = "txtEvalueResult";
            this.txtEvalueResult.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtEvalueResult.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtEvalueResult.Properties.UseMaskAsDisplayFormat = true;
            this.txtEvalueResult.Size = new System.Drawing.Size(270, 23);
            this.txtEvalueResult.TabIndex = 125;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(37, 140);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(62, 16);
            this.labelControl1.TabIndex = 126;
            this.labelControl1.Text = "Kết quả KT";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(37, 171);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(10);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(72, 16);
            this.labelControl2.TabIndex = 128;
            this.labelControl2.Text = "Thời gian KT";
            // 
            // txtIQCCheckCont
            // 
            this.txtIQCCheckCont.Location = new System.Drawing.Point(221, 73);
            this.txtIQCCheckCont.Margin = new System.Windows.Forms.Padding(10);
            this.txtIQCCheckCont.Name = "txtIQCCheckCont";
            this.txtIQCCheckCont.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtIQCCheckCont.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtIQCCheckCont.Properties.UseMaskAsDisplayFormat = true;
            this.txtIQCCheckCont.Size = new System.Drawing.Size(270, 23);
            this.txtIQCCheckCont.TabIndex = 129;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(36, 77);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(10);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(80, 16);
            this.labelControl4.TabIndex = 130;
            this.labelControl4.Text = "Mã công đoạn";
            // 
            // txtIQCPeriodTime
            // 
            this.txtIQCPeriodTime.Location = new System.Drawing.Point(221, 168);
            this.txtIQCPeriodTime.Margin = new System.Windows.Forms.Padding(10);
            this.txtIQCPeriodTime.Name = "txtIQCPeriodTime";
            this.txtIQCPeriodTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtIQCPeriodTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtIQCPeriodTime.Properties.UseMaskAsDisplayFormat = true;
            this.txtIQCPeriodTime.Size = new System.Drawing.Size(270, 23);
            this.txtIQCPeriodTime.TabIndex = 131;
            // 
            // frmExternalIQCDetailContentEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 325);
            this.Controls.Add(this.txtIQCPeriodTime);
            this.Controls.Add(this.txtIQCCheckCont);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtEvalueResult);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.txtIQCTemplateQuantity);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.lkeIQCCheckID);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.lbLosstimeID);
            this.Name = "frmExternalIQCDetailContentEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmExternalIQCDetailContentEdit";
            ((System.ComponentModel.ISupportInitialize)(this.txtIQCTemplateQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeIQCCheckID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEvalueResult.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIQCCheckCont.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIQCPeriodTime.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtIQCTemplateQuantity;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit lkeIQCCheckID;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl lbLosstimeID;
        private DevExpress.XtraEditors.SimpleButton btCancel;
        private DevExpress.XtraEditors.SimpleButton btSave;
        private DevExpress.XtraEditors.TextEdit txtEvalueResult;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtIQCCheckCont;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtIQCPeriodTime;
    }
}