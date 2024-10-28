namespace ASPProject.AttendanceEmployee
{
    partial class frmAttendanceEmployeeEdit
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
            this.lkeTimekeepID = new DevExpress.XtraEditors.LookUpEdit();
            this.lblTenkyhieu = new DevExpress.XtraEditors.LabelControl();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btSave = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dtpBeginTime = new DevExpress.XtraEditors.TextEdit();
            this.dtpEndTime = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeTimekeepID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBeginTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEndTime.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl12.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl12.Appearance.Options.UseBackColor = true;
            this.labelControl12.Appearance.Options.UseForeColor = true;
            this.labelControl12.Location = new System.Drawing.Point(126, 25);
            this.labelControl12.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(18, 16);
            this.labelControl12.TabIndex = 69;
            this.labelControl12.Text = "(*)";
            // 
            // lbLosstimeID
            // 
            this.lbLosstimeID.Location = new System.Drawing.Point(30, 25);
            this.lbLosstimeID.Margin = new System.Windows.Forms.Padding(4);
            this.lbLosstimeID.Name = "lbLosstimeID";
            this.lbLosstimeID.Size = new System.Drawing.Size(41, 16);
            this.lbLosstimeID.TabIndex = 70;
            this.lbLosstimeID.Text = "Ký hiệu";
            // 
            // lkeTimekeepID
            // 
            this.lkeTimekeepID.EditValue = "";
            this.lkeTimekeepID.Location = new System.Drawing.Point(152, 22);
            this.lkeTimekeepID.Margin = new System.Windows.Forms.Padding(4);
            this.lkeTimekeepID.Name = "lkeTimekeepID";
            this.lkeTimekeepID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeTimekeepID.Properties.NullText = "";
            this.lkeTimekeepID.Size = new System.Drawing.Size(449, 23);
            this.lkeTimekeepID.TabIndex = 71;
            // 
            // lblTenkyhieu
            // 
            this.lblTenkyhieu.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblTenkyhieu.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenkyhieu.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblTenkyhieu.Appearance.Options.UseBackColor = true;
            this.lblTenkyhieu.Appearance.Options.UseFont = true;
            this.lblTenkyhieu.Appearance.Options.UseForeColor = true;
            this.lblTenkyhieu.Location = new System.Drawing.Point(126, 65);
            this.lblTenkyhieu.Name = "lblTenkyhieu";
            this.lblTenkyhieu.Size = new System.Drawing.Size(85, 18);
            this.lblTenkyhieu.TabIndex = 72;
            this.lblTenkyhieu.Text = "Tên ký hiệu";
            // 
            // btCancel
            // 
            this.btCancel.ImageOptions.Image = global::ASPProject.Properties.Resources.close__2_;
            this.btCancel.Location = new System.Drawing.Point(235, 188);
            this.btCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(131, 40);
            this.btCancel.TabIndex = 74;
            this.btCancel.Text = "Đóng";
            // 
            // btSave
            // 
            this.btSave.ImageOptions.Image = global::ASPProject.Properties.Resources.save1;
            this.btSave.Location = new System.Drawing.Point(93, 188);
            this.btSave.Margin = new System.Windows.Forms.Padding(5);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(132, 40);
            this.btSave.TabIndex = 73;
            this.btSave.Text = "Lưu";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(30, 106);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(131, 16);
            this.labelControl1.TabIndex = 75;
            this.labelControl1.Text = "Thời gian bắt đầu ngày";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(30, 136);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(133, 16);
            this.labelControl2.TabIndex = 76;
            this.labelControl2.Text = "Thời gian kết thúc ngày";
            // 
            // dtpBeginTime
            // 
            this.dtpBeginTime.Location = new System.Drawing.Point(192, 103);
            this.dtpBeginTime.Margin = new System.Windows.Forms.Padding(4);
            this.dtpBeginTime.Name = "dtpBeginTime";
            this.dtpBeginTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.dtpBeginTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.dtpBeginTime.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.DateTimeMaskManager));
            this.dtpBeginTime.Properties.MaskSettings.Set("mask", "HH: mm: ss");
            this.dtpBeginTime.Properties.UseMaskAsDisplayFormat = true;
            this.dtpBeginTime.Size = new System.Drawing.Size(187, 23);
            this.dtpBeginTime.TabIndex = 77;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Location = new System.Drawing.Point(192, 134);
            this.dtpEndTime.Margin = new System.Windows.Forms.Padding(4);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.dtpEndTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.dtpEndTime.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.DateTimeMaskManager));
            this.dtpEndTime.Properties.MaskSettings.Set("mask", "HH: mm: ss");
            this.dtpEndTime.Properties.UseMaskAsDisplayFormat = true;
            this.dtpEndTime.Size = new System.Drawing.Size(187, 23);
            this.dtpEndTime.TabIndex = 78;
            // 
            // frmAttendanceEmployeeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 250);
            this.Controls.Add(this.dtpEndTime);
            this.Controls.Add(this.dtpBeginTime);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.lblTenkyhieu);
            this.Controls.Add(this.lkeTimekeepID);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.lbLosstimeID);
            this.Name = "frmAttendanceEmployeeEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nhập ký hiệu công";
            ((System.ComponentModel.ISupportInitialize)(this.lkeTimekeepID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBeginTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEndTime.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl lbLosstimeID;
        private DevExpress.XtraEditors.LookUpEdit lkeTimekeepID;
        private DevExpress.XtraEditors.LabelControl lblTenkyhieu;
        private DevExpress.XtraEditors.SimpleButton btCancel;
        private DevExpress.XtraEditors.SimpleButton btSave;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit dtpBeginTime;
        private DevExpress.XtraEditors.TextEdit dtpEndTime;
    }
}