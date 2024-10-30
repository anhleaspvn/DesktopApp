namespace ASPProject.HRAbsenceDoc
{
    partial class frmHRAbsenceEdit
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
            this.txtNumDateOff = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.dtpTimeOff = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btSave = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.rtxtReasonOfAbsence = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumDateOff.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTimeOff.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTimeOff.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNumDateOff
            // 
            this.txtNumDateOff.Location = new System.Drawing.Point(150, 47);
            this.txtNumDateOff.Name = "txtNumDateOff";
            this.txtNumDateOff.Size = new System.Drawing.Size(173, 23);
            this.txtNumDateOff.TabIndex = 144;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(19, 54);
            this.labelControl11.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(74, 16);
            this.labelControl11.TabIndex = 142;
            this.labelControl11.Text = "Số ngày nghỉ";
            // 
            // dtpTimeOff
            // 
            this.dtpTimeOff.EditValue = null;
            this.dtpTimeOff.Location = new System.Drawing.Point(150, 12);
            this.dtpTimeOff.Name = "dtpTimeOff";
            this.dtpTimeOff.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpTimeOff.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpTimeOff.Properties.MaskSettings.Set("culture", "vi-VN");
            this.dtpTimeOff.Properties.UseMaskAsDisplayFormat = true;
            this.dtpTimeOff.Size = new System.Drawing.Size(173, 23);
            this.dtpTimeOff.TabIndex = 140;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(19, 18);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(81, 16);
            this.labelControl2.TabIndex = 141;
            this.labelControl2.Text = "Thời gian nghỉ";
            // 
            // btCancel
            // 
            this.btCancel.ImageOptions.Image = global::ASPProject.Properties.Resources.close__2_;
            this.btCancel.Location = new System.Drawing.Point(242, 175);
            this.btCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(144, 49);
            this.btCancel.TabIndex = 146;
            this.btCancel.Text = "Đóng";
            // 
            // btSave
            // 
            this.btSave.ImageOptions.Image = global::ASPProject.Properties.Resources.save1;
            this.btSave.Location = new System.Drawing.Point(63, 175);
            this.btSave.Margin = new System.Windows.Forms.Padding(4);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(145, 49);
            this.btSave.TabIndex = 145;
            this.btSave.Text = "Lưu";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(19, 90);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 16);
            this.labelControl1.TabIndex = 147;
            this.labelControl1.Text = "Lý do nghỉ";
            // 
            // rtxtReasonOfAbsence
            // 
            this.rtxtReasonOfAbsence.Location = new System.Drawing.Point(150, 82);
            this.rtxtReasonOfAbsence.Name = "rtxtReasonOfAbsence";
            this.rtxtReasonOfAbsence.Size = new System.Drawing.Size(325, 78);
            this.rtxtReasonOfAbsence.TabIndex = 148;
            this.rtxtReasonOfAbsence.Text = "";
            // 
            // frmHRAbsenceEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 243);
            this.Controls.Add(this.rtxtReasonOfAbsence);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.txtNumDateOff);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.dtpTimeOff);
            this.Controls.Add(this.labelControl2);
            this.Name = "frmHRAbsenceEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmHRAbsenceEdit";
            ((System.ComponentModel.ISupportInitialize)(this.txtNumDateOff.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTimeOff.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTimeOff.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtNumDateOff;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.DateEdit dtpTimeOff;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btCancel;
        private DevExpress.XtraEditors.SimpleButton btSave;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.RichTextBox rtxtReasonOfAbsence;
    }
}