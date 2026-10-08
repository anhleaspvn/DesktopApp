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
            this.rtxtReasonOfAbsence = new System.Windows.Forms.RichTextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lkeTypeOfAbsence = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumDateOff.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTimeOff.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTimeOff.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeTypeOfAbsence.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNumDateOff
            // 
            this.txtNumDateOff.Location = new System.Drawing.Point(100, 39);
            this.txtNumDateOff.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNumDateOff.Name = "txtNumDateOff";
            this.txtNumDateOff.Size = new System.Drawing.Size(164, 20);
            this.txtNumDateOff.TabIndex = 144;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(12, 45);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(62, 13);
            this.labelControl11.TabIndex = 142;
            this.labelControl11.Text = "Số ngày nghỉ";
            // 
            // dtpTimeOff
            // 
            this.dtpTimeOff.EditValue = null;
            this.dtpTimeOff.Location = new System.Drawing.Point(100, 11);
            this.dtpTimeOff.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpTimeOff.Name = "dtpTimeOff";
            this.dtpTimeOff.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpTimeOff.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpTimeOff.Properties.MaskSettings.Set("culture", "vi-VN");
            this.dtpTimeOff.Properties.UseMaskAsDisplayFormat = true;
            this.dtpTimeOff.Size = new System.Drawing.Size(164, 20);
            this.dtpTimeOff.TabIndex = 140;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(66, 13);
            this.labelControl2.TabIndex = 141;
            this.labelControl2.Text = "Thời gian nghỉ";
            // 
            // btCancel
            // 
            this.btCancel.ImageOptions.Image = global::ASPProject.Properties.Resources.close__2_;
            this.btCancel.Location = new System.Drawing.Point(207, 175);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(123, 40);
            this.btCancel.TabIndex = 146;
            this.btCancel.Text = "Đóng";
            // 
            // btSave
            // 
            this.btSave.ImageOptions.Image = global::ASPProject.Properties.Resources.save1;
            this.btSave.Location = new System.Drawing.Point(54, 175);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(124, 40);
            this.btSave.TabIndex = 145;
            this.btSave.Text = "Lưu";
            // 
            // rtxtReasonOfAbsence
            // 
            this.rtxtReasonOfAbsence.Location = new System.Drawing.Point(99, 96);
            this.rtxtReasonOfAbsence.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtxtReasonOfAbsence.Name = "rtxtReasonOfAbsence";
            this.rtxtReasonOfAbsence.Size = new System.Drawing.Size(279, 64);
            this.rtxtReasonOfAbsence.TabIndex = 150;
            this.rtxtReasonOfAbsence.Text = "";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 103);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(49, 13);
            this.labelControl1.TabIndex = 149;
            this.labelControl1.Text = "Lý do nghỉ";
            // 
            // lkeTypeOfAbsence
            // 
            this.lkeTypeOfAbsence.EditValue = "";
            this.lkeTypeOfAbsence.Location = new System.Drawing.Point(100, 67);
            this.lkeTypeOfAbsence.Margin = new System.Windows.Forms.Padding(4);
            this.lkeTypeOfAbsence.Name = "lkeTypeOfAbsence";
            this.lkeTypeOfAbsence.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeTypeOfAbsence.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeTypeOfAbsence.Properties.NullText = "";
            this.lkeTypeOfAbsence.Size = new System.Drawing.Size(164, 20);
            this.lkeTypeOfAbsence.TabIndex = 174;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 74);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(46, 13);
            this.labelControl3.TabIndex = 175;
            this.labelControl3.Text = "Loại phép";
            // 
            // frmHRAbsenceEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 246);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.lkeTypeOfAbsence);
            this.Controls.Add(this.rtxtReasonOfAbsence);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.txtNumDateOff);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.dtpTimeOff);
            this.Controls.Add(this.labelControl2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmHRAbsenceEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmHRAbsenceEdit";
            ((System.ComponentModel.ISupportInitialize)(this.txtNumDateOff.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTimeOff.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTimeOff.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeTypeOfAbsence.Properties)).EndInit();
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
        private System.Windows.Forms.RichTextBox rtxtReasonOfAbsence;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lkeTypeOfAbsence;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}