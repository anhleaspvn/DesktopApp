namespace ASPProject.LineProdStatistic
{
    partial class frmProdPSDetailExWork
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
            this.lkeEmpID = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lkeExWorkID = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtExProdWorkTime = new DevExpress.XtraEditors.TextEdit();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtExProdWorkTimeTC = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.lkeEmpID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeExWorkID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExProdWorkTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExProdWorkTimeTC.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lkeEmpID
            // 
            this.lkeEmpID.EditValue = "";
            this.lkeEmpID.Location = new System.Drawing.Point(194, 17);
            this.lkeEmpID.Margin = new System.Windows.Forms.Padding(8);
            this.lkeEmpID.Name = "lkeEmpID";
            this.lkeEmpID.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeEmpID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeEmpID.Properties.NullText = "";
            this.lkeEmpID.Size = new System.Drawing.Size(287, 23);
            this.lkeEmpID.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(54, 24);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(76, 16);
            this.labelControl1.TabIndex = 116;
            this.labelControl1.Text = "Mã nhân viên";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(54, 59);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(10);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(74, 16);
            this.labelControl2.TabIndex = 117;
            this.labelControl2.Text = "Mã công việc";
            // 
            // lkeExWorkID
            // 
            this.lkeExWorkID.EditValue = "";
            this.lkeExWorkID.Location = new System.Drawing.Point(194, 52);
            this.lkeExWorkID.Margin = new System.Windows.Forms.Padding(10);
            this.lkeExWorkID.Name = "lkeExWorkID";
            this.lkeExWorkID.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeExWorkID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeExWorkID.Properties.NullText = "";
            this.lkeExWorkID.Size = new System.Drawing.Size(287, 23);
            this.lkeExWorkID.TabIndex = 118;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(54, 97);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(12);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(81, 16);
            this.labelControl3.TabIndex = 119;
            this.labelControl3.Text = "Số giờ làm HC";
            // 
            // txtExProdWorkTime
            // 
            this.txtExProdWorkTime.Location = new System.Drawing.Point(194, 90);
            this.txtExProdWorkTime.Margin = new System.Windows.Forms.Padding(8);
            this.txtExProdWorkTime.Name = "txtExProdWorkTime";
            this.txtExProdWorkTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtExProdWorkTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtExProdWorkTime.Properties.UseMaskAsDisplayFormat = true;
            this.txtExProdWorkTime.Size = new System.Drawing.Size(287, 23);
            this.txtExProdWorkTime.TabIndex = 120;
            // 
            // btCancel
            // 
            this.btCancel.ImageOptions.Image = global::ASPProject.Properties.Resources.close__2_;
            this.btCancel.Location = new System.Drawing.Point(320, 183);
            this.btCancel.Margin = new System.Windows.Forms.Padding(8);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(148, 51);
            this.btCancel.TabIndex = 122;
            this.btCancel.Text = "Đóng";
            // 
            // btSave
            // 
            this.btSave.ImageOptions.Image = global::ASPProject.Properties.Resources.save1;
            this.btSave.Location = new System.Drawing.Point(95, 183);
            this.btSave.Margin = new System.Windows.Forms.Padding(8);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(149, 51);
            this.btSave.TabIndex = 121;
            this.btSave.Text = "Lưu";
            // 
            // txtExProdWorkTimeTC
            // 
            this.txtExProdWorkTimeTC.Location = new System.Drawing.Point(194, 127);
            this.txtExProdWorkTimeTC.Margin = new System.Windows.Forms.Padding(8);
            this.txtExProdWorkTimeTC.Name = "txtExProdWorkTimeTC";
            this.txtExProdWorkTimeTC.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtExProdWorkTimeTC.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtExProdWorkTimeTC.Properties.UseMaskAsDisplayFormat = true;
            this.txtExProdWorkTimeTC.Size = new System.Drawing.Size(287, 23);
            this.txtExProdWorkTimeTC.TabIndex = 124;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(54, 134);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(12);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(81, 16);
            this.labelControl4.TabIndex = 123;
            this.labelControl4.Text = "Số giờ làm TC";
            // 
            // frmProdPSDetailExWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 249);
            this.Controls.Add(this.txtExProdWorkTimeTC);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.txtExProdWorkTime);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.lkeExWorkID);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lkeEmpID);
            this.Name = "frmProdPSDetailExWork";
            this.Text = "frmProdPSDetailExWork";
            ((System.ComponentModel.ISupportInitialize)(this.lkeEmpID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeExWorkID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExProdWorkTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExProdWorkTimeTC.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lkeEmpID;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit lkeExWorkID;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtExProdWorkTime;
        private DevExpress.XtraEditors.SimpleButton btCancel;
        private DevExpress.XtraEditors.SimpleButton btSave;
        private DevExpress.XtraEditors.TextEdit txtExProdWorkTimeTC;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}