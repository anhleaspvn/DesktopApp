namespace ASPProject.LineProdStatistic
{
    partial class frmPSDetailEmpEdit
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
            this.txtOverTime = new DevExpress.XtraEditors.TextEdit();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.txtWorkTime = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btSave = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lkeEmpID = new DevExpress.XtraEditors.LookUpEdit();
            this.txtEmpSorting = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtEmpRework = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtEmpOverSorting = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtEmpOverRework = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtOverTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeEmpID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpSorting.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpRework.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpOverSorting.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpOverRework.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtOverTime
            // 
            this.txtOverTime.Location = new System.Drawing.Point(228, 92);
            this.txtOverTime.Margin = new System.Windows.Forms.Padding(5);
            this.txtOverTime.Name = "txtOverTime";
            this.txtOverTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtOverTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtOverTime.Properties.UseMaskAsDisplayFormat = true;
            this.txtOverTime.Size = new System.Drawing.Size(332, 23);
            this.txtOverTime.TabIndex = 3;
            // 
            // labelControl14
            // 
            this.labelControl14.Location = new System.Drawing.Point(44, 99);
            this.labelControl14.Margin = new System.Windows.Forms.Padding(5);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(95, 16);
            this.labelControl14.TabIndex = 114;
            this.labelControl14.Text = "Giờ công tăng ca";
            // 
            // txtWorkTime
            // 
            this.txtWorkTime.Location = new System.Drawing.Point(228, 56);
            this.txtWorkTime.Margin = new System.Windows.Forms.Padding(5);
            this.txtWorkTime.Name = "txtWorkTime";
            this.txtWorkTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtWorkTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtWorkTime.Properties.UseMaskAsDisplayFormat = true;
            this.txtWorkTime.Size = new System.Drawing.Size(332, 23);
            this.txtWorkTime.TabIndex = 2;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(44, 63);
            this.labelControl11.Margin = new System.Windows.Forms.Padding(5);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(115, 16);
            this.labelControl11.TabIndex = 111;
            this.labelControl11.Text = "Giờ công hành chính";
            // 
            // btCancel
            // 
            this.btCancel.ImageOptions.Image = global::ASPProject.Properties.Resources.close__2_;
            this.btCancel.Location = new System.Drawing.Point(362, 288);
            this.btCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(180, 61);
            this.btCancel.TabIndex = 9;
            this.btCancel.Text = "Đóng";
            // 
            // btSave
            // 
            this.btSave.ImageOptions.Image = global::ASPProject.Properties.Resources.save1;
            this.btSave.Location = new System.Drawing.Point(139, 288);
            this.btSave.Margin = new System.Windows.Forms.Padding(5);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(181, 61);
            this.btSave.TabIndex = 8;
            this.btSave.Text = "Lưu";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(44, 27);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(76, 16);
            this.labelControl1.TabIndex = 115;
            this.labelControl1.Text = "Mã nhân viên";
            // 
            // lkeEmpID
            // 
            this.lkeEmpID.EditValue = "";
            this.lkeEmpID.Location = new System.Drawing.Point(228, 20);
            this.lkeEmpID.Margin = new System.Windows.Forms.Padding(5);
            this.lkeEmpID.Name = "lkeEmpID";
            this.lkeEmpID.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeEmpID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeEmpID.Properties.NullText = "";
            this.lkeEmpID.Size = new System.Drawing.Size(270, 23);
            this.lkeEmpID.TabIndex = 1;
            // 
            // txtEmpSorting
            // 
            this.txtEmpSorting.Location = new System.Drawing.Point(228, 163);
            this.txtEmpSorting.Margin = new System.Windows.Forms.Padding(5);
            this.txtEmpSorting.Name = "txtEmpSorting";
            this.txtEmpSorting.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtEmpSorting.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtEmpSorting.Properties.UseMaskAsDisplayFormat = true;
            this.txtEmpSorting.Size = new System.Drawing.Size(332, 23);
            this.txtEmpSorting.TabIndex = 5;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(44, 170);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(114, 16);
            this.labelControl2.TabIndex = 120;
            this.labelControl2.Text = "Giờ công Sorting HC";
            // 
            // txtEmpRework
            // 
            this.txtEmpRework.Location = new System.Drawing.Point(228, 127);
            this.txtEmpRework.Margin = new System.Windows.Forms.Padding(5);
            this.txtEmpRework.Name = "txtEmpRework";
            this.txtEmpRework.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtEmpRework.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtEmpRework.Properties.UseMaskAsDisplayFormat = true;
            this.txtEmpRework.Size = new System.Drawing.Size(332, 23);
            this.txtEmpRework.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(44, 134);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(5);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(126, 16);
            this.labelControl3.TabIndex = 118;
            this.labelControl3.Text = "Giờ công sửa hàng HC";
            // 
            // txtEmpOverSorting
            // 
            this.txtEmpOverSorting.Location = new System.Drawing.Point(228, 235);
            this.txtEmpOverSorting.Margin = new System.Windows.Forms.Padding(5);
            this.txtEmpOverSorting.Name = "txtEmpOverSorting";
            this.txtEmpOverSorting.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtEmpOverSorting.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtEmpOverSorting.Properties.UseMaskAsDisplayFormat = true;
            this.txtEmpOverSorting.Size = new System.Drawing.Size(332, 23);
            this.txtEmpOverSorting.TabIndex = 7;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(44, 242);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(5);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(114, 16);
            this.labelControl4.TabIndex = 124;
            this.labelControl4.Text = "Giờ công Sorting TC";
            // 
            // txtEmpOverRework
            // 
            this.txtEmpOverRework.Location = new System.Drawing.Point(228, 199);
            this.txtEmpOverRework.Margin = new System.Windows.Forms.Padding(5);
            this.txtEmpOverRework.Name = "txtEmpOverRework";
            this.txtEmpOverRework.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtEmpOverRework.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtEmpOverRework.Properties.UseMaskAsDisplayFormat = true;
            this.txtEmpOverRework.Size = new System.Drawing.Size(332, 23);
            this.txtEmpOverRework.TabIndex = 6;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(44, 206);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(5);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(126, 16);
            this.labelControl5.TabIndex = 122;
            this.labelControl5.Text = "Giờ công sửa hàng TC";
            // 
            // frmPSDetailEmpEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 388);
            this.Controls.Add(this.txtEmpOverSorting);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtEmpOverRework);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txtEmpSorting);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtEmpRework);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.lkeEmpID);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtOverTime);
            this.Controls.Add(this.labelControl14);
            this.Controls.Add(this.txtWorkTime);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btSave);
            this.Name = "frmPSDetailEmpEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit thống kê nhân viên";
            ((System.ComponentModel.ISupportInitialize)(this.txtOverTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeEmpID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpSorting.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpRework.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpOverSorting.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpOverRework.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtOverTime;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.TextEdit txtWorkTime;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.SimpleButton btCancel;
        private DevExpress.XtraEditors.SimpleButton btSave;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lkeEmpID;
        private DevExpress.XtraEditors.TextEdit txtEmpSorting;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtEmpRework;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtEmpOverSorting;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtEmpOverRework;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}