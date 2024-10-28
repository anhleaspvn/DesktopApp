namespace ASPProject.LineProdStatistic
{
    partial class frmPSDetailMachineEdit
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
            this.lkeMachineID = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.lbLosstimeID = new DevExpress.XtraEditors.LabelControl();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btSave = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtMachineTime = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeMachineID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMachineTime.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lkeMachineID
            // 
            this.lkeMachineID.EditValue = "";
            this.lkeMachineID.Location = new System.Drawing.Point(175, 24);
            this.lkeMachineID.Margin = new System.Windows.Forms.Padding(5);
            this.lkeMachineID.Name = "lkeMachineID";
            this.lkeMachineID.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeMachineID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeMachineID.Properties.NullText = "";
            this.lkeMachineID.Size = new System.Drawing.Size(226, 23);
            this.lkeMachineID.TabIndex = 1;
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl12.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl12.Appearance.Options.UseBackColor = true;
            this.labelControl12.Appearance.Options.UseForeColor = true;
            this.labelControl12.Location = new System.Drawing.Point(139, 27);
            this.labelControl12.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(18, 16);
            this.labelControl12.TabIndex = 76;
            this.labelControl12.Text = "(*)";
            // 
            // lbLosstimeID
            // 
            this.lbLosstimeID.Location = new System.Drawing.Point(34, 27);
            this.lbLosstimeID.Margin = new System.Windows.Forms.Padding(6);
            this.lbLosstimeID.Name = "lbLosstimeID";
            this.lbLosstimeID.Size = new System.Drawing.Size(45, 16);
            this.lbLosstimeID.TabIndex = 77;
            this.lbLosstimeID.Text = "Mã máy";
            // 
            // btCancel
            // 
            this.btCancel.ImageOptions.Image = global::ASPProject.Properties.Resources.close__2_;
            this.btCancel.Location = new System.Drawing.Point(338, 130);
            this.btCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(180, 61);
            this.btCancel.TabIndex = 4;
            this.btCancel.Text = "Đóng";
            // 
            // btSave
            // 
            this.btSave.ImageOptions.Image = global::ASPProject.Properties.Resources.save1;
            this.btSave.Location = new System.Drawing.Point(115, 130);
            this.btSave.Margin = new System.Windows.Forms.Padding(5);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(181, 61);
            this.btSave.TabIndex = 3;
            this.btSave.Text = "Lưu";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(34, 63);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 16);
            this.labelControl1.TabIndex = 123;
            this.labelControl1.Text = "Số giờ máy";
            // 
            // txtMachineTime
            // 
            this.txtMachineTime.Location = new System.Drawing.Point(175, 57);
            this.txtMachineTime.Margin = new System.Windows.Forms.Padding(8);
            this.txtMachineTime.Name = "txtMachineTime";
            this.txtMachineTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMachineTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMachineTime.Properties.UseMaskAsDisplayFormat = true;
            this.txtMachineTime.Size = new System.Drawing.Size(226, 23);
            this.txtMachineTime.TabIndex = 2;
            // 
            // frmPSDetailMachineEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 220);
            this.Controls.Add(this.txtMachineTime);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.lkeMachineID);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.lbLosstimeID);
            this.Name = "frmPSDetailMachineEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nhập chi tiết máy";
            ((System.ComponentModel.ISupportInitialize)(this.lkeMachineID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMachineTime.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lkeMachineID;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl lbLosstimeID;
        private DevExpress.XtraEditors.SimpleButton btCancel;
        private DevExpress.XtraEditors.SimpleButton btSave;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtMachineTime;
    }
}