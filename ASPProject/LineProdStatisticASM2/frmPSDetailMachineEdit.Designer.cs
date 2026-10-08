namespace ASPProject.LineProdStatisticASM2
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
            this.txtMachineTimePlan = new DevExpress.XtraEditors.TextEdit();
            this.lkeMoldID = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtCycleTime = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtQtyFG = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.txtQtyNG = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.lkeMachineID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMachineTimePlan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeMoldID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCycleTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtyFG.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtyNG.Properties)).BeginInit();
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
            this.btCancel.Location = new System.Drawing.Point(338, 232);
            this.btCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(180, 61);
            this.btCancel.TabIndex = 4;
            this.btCancel.Text = "Đóng";
            // 
            // btSave
            // 
            this.btSave.ImageOptions.Image = global::ASPProject.Properties.Resources.save1;
            this.btSave.Location = new System.Drawing.Point(115, 232);
            this.btSave.Margin = new System.Windows.Forms.Padding(5);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(181, 61);
            this.btSave.TabIndex = 3;
            this.btSave.Text = "Lưu";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(34, 91);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(57, 16);
            this.labelControl1.TabIndex = 123;
            this.labelControl1.Text = "Time Plan";
            // 
            // txtMachineTimePlan
            // 
            this.txtMachineTimePlan.Location = new System.Drawing.Point(175, 85);
            this.txtMachineTimePlan.Margin = new System.Windows.Forms.Padding(8);
            this.txtMachineTimePlan.Name = "txtMachineTimePlan";
            this.txtMachineTimePlan.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMachineTimePlan.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMachineTimePlan.Properties.UseMaskAsDisplayFormat = true;
            this.txtMachineTimePlan.Size = new System.Drawing.Size(226, 23);
            this.txtMachineTimePlan.TabIndex = 2;
            // 
            // lkeMoldID
            // 
            this.lkeMoldID.EditValue = "";
            this.lkeMoldID.Location = new System.Drawing.Point(175, 54);
            this.lkeMoldID.Margin = new System.Windows.Forms.Padding(5);
            this.lkeMoldID.Name = "lkeMoldID";
            this.lkeMoldID.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeMoldID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeMoldID.Properties.NullText = "";
            this.lkeMoldID.Size = new System.Drawing.Size(226, 23);
            this.lkeMoldID.TabIndex = 124;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl2.Appearance.Options.UseBackColor = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(139, 57);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(18, 16);
            this.labelControl2.TabIndex = 125;
            this.labelControl2.Text = "(*)";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(34, 57);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(59, 16);
            this.labelControl3.TabIndex = 126;
            this.labelControl3.Text = "Mã khuôn ";
            // 
            // txtCycleTime
            // 
            this.txtCycleTime.Location = new System.Drawing.Point(175, 117);
            this.txtCycleTime.Margin = new System.Windows.Forms.Padding(8);
            this.txtCycleTime.Name = "txtCycleTime";
            this.txtCycleTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtCycleTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtCycleTime.Properties.UseMaskAsDisplayFormat = true;
            this.txtCycleTime.Size = new System.Drawing.Size(226, 23);
            this.txtCycleTime.TabIndex = 137;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(34, 123);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(63, 16);
            this.labelControl9.TabIndex = 138;
            this.labelControl9.Text = "Cycle Time";
            // 
            // txtQtyFG
            // 
            this.txtQtyFG.Location = new System.Drawing.Point(175, 150);
            this.txtQtyFG.Margin = new System.Windows.Forms.Padding(8);
            this.txtQtyFG.Name = "txtQtyFG";
            this.txtQtyFG.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtQtyFG.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtQtyFG.Properties.UseMaskAsDisplayFormat = true;
            this.txtQtyFG.Size = new System.Drawing.Size(226, 23);
            this.txtQtyFG.TabIndex = 139;
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(34, 156);
            this.labelControl10.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(66, 16);
            this.labelControl10.TabIndex = 140;
            this.labelControl10.Text = "Quantity FG";
            // 
            // txtQtyNG
            // 
            this.txtQtyNG.Location = new System.Drawing.Point(175, 183);
            this.txtQtyNG.Margin = new System.Windows.Forms.Padding(8);
            this.txtQtyNG.Name = "txtQtyNG";
            this.txtQtyNG.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtQtyNG.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtQtyNG.Properties.UseMaskAsDisplayFormat = true;
            this.txtQtyNG.Size = new System.Drawing.Size(226, 23);
            this.txtQtyNG.TabIndex = 141;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(34, 189);
            this.labelControl11.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(67, 16);
            this.labelControl11.TabIndex = 142;
            this.labelControl11.Text = "Quantity NG";
            // 
            // frmPSDetailMachineEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 526);
            this.Controls.Add(this.txtQtyNG);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.txtQtyFG);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.txtCycleTime);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.lkeMoldID);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtMachineTimePlan);
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
            ((System.ComponentModel.ISupportInitialize)(this.txtMachineTimePlan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeMoldID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCycleTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtyFG.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtyNG.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit txtMachineTimePlan;
        private DevExpress.XtraEditors.LookUpEdit lkeMoldID;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtCycleTime;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit txtQtyFG;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.TextEdit txtQtyNG;
        private DevExpress.XtraEditors.LabelControl labelControl11;
    }
}