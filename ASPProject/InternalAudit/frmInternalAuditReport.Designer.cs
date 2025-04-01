namespace ASPProject.InternalAudit
{
    partial class frmInternalAuditReport
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
            this.lkeDeptID = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lbDepartment = new DevExpress.XtraEditors.LabelControl();
            this.lkeFactoryID = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblFactory = new DevExpress.XtraEditors.LabelControl();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btView = new DevExpress.XtraEditors.SimpleButton();
            this.btSummary = new DevExpress.XtraEditors.SimpleButton();
            this.btAudit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.lkeDeptID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeFactoryID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lkeDeptID
            // 
            this.lkeDeptID.EditValue = "";
            this.lkeDeptID.Location = new System.Drawing.Point(116, 59);
            this.lkeDeptID.Name = "lkeDeptID";
            this.lkeDeptID.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeDeptID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeDeptID.Properties.NullText = "";
            this.lkeDeptID.Size = new System.Drawing.Size(237, 20);
            this.lkeDeptID.TabIndex = 85;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl3.Appearance.Options.UseBackColor = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(82, 65);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(14, 13);
            this.labelControl3.TabIndex = 87;
            this.labelControl3.Text = "(*)";
            // 
            // lbDepartment
            // 
            this.lbDepartment.Location = new System.Drawing.Point(31, 65);
            this.lbDepartment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbDepartment.Name = "lbDepartment";
            this.lbDepartment.Size = new System.Drawing.Size(39, 13);
            this.lbDepartment.TabIndex = 86;
            this.lbDepartment.Text = "Bộ phận";
            // 
            // lkeFactoryID
            // 
            this.lkeFactoryID.EditValue = "";
            this.lkeFactoryID.Location = new System.Drawing.Point(116, 30);
            this.lkeFactoryID.Name = "lkeFactoryID";
            this.lkeFactoryID.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeFactoryID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeFactoryID.Properties.NullText = "";
            this.lkeFactoryID.Size = new System.Drawing.Size(237, 20);
            this.lkeFactoryID.TabIndex = 88;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(82, 36);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(14, 13);
            this.labelControl1.TabIndex = 90;
            this.labelControl1.Text = "(*)";
            // 
            // lblFactory
            // 
            this.lblFactory.Location = new System.Drawing.Point(31, 36);
            this.lblFactory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblFactory.Name = "lblFactory";
            this.lblFactory.Size = new System.Drawing.Size(42, 13);
            this.lblFactory.TabIndex = 89;
            this.lblFactory.Text = "Nhà máy";
            // 
            // btCancel
            // 
            this.btCancel.ImageOptions.Image = global::ASPProject.Properties.Resources.close__2_;
            this.btCancel.Location = new System.Drawing.Point(267, 109);
            this.btCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(111, 38);
            this.btCancel.TabIndex = 91;
            this.btCancel.Text = "Đóng";
            // 
            // btView
            // 
            this.btView.ImageOptions.Image = global::ASPProject.Properties.Resources.save1;
            this.btView.Location = new System.Drawing.Point(140, 109);
            this.btView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btView.Name = "btView";
            this.btView.Size = new System.Drawing.Size(119, 38);
            this.btView.TabIndex = 92;
            this.btView.Text = "Xem File";
            // 
            // btSummary
            // 
            this.btSummary.ImageOptions.Image = global::ASPProject.Properties.Resources.money;
            this.btSummary.Location = new System.Drawing.Point(386, 109);
            this.btSummary.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btSummary.Name = "btSummary";
            this.btSummary.Size = new System.Drawing.Size(119, 38);
            this.btSummary.TabIndex = 93;
            this.btSummary.Text = "Tổng hợp";
            this.btSummary.Visible = false;
            // 
            // btAudit
            // 
            this.btAudit.ImageOptions.Image = global::ASPProject.Properties.Resources.edit2;
            this.btAudit.Location = new System.Drawing.Point(21, 109);
            this.btAudit.Margin = new System.Windows.Forms.Padding(5);
            this.btAudit.Name = "btAudit";
            this.btAudit.Size = new System.Drawing.Size(111, 38);
            this.btAudit.TabIndex = 101;
            this.btAudit.Text = "Audit";
            // 
            // frmInternalAuditReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 182);
            this.Controls.Add(this.btAudit);
            this.Controls.Add(this.btSummary);
            this.Controls.Add(this.btView);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.lkeFactoryID);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lblFactory);
            this.Controls.Add(this.lkeDeptID);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.lbDepartment);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmInternalAuditReport";
            this.Text = "frmInternalAuditReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.lkeDeptID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeFactoryID.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lkeDeptID;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl lbDepartment;
        private DevExpress.XtraEditors.LookUpEdit lkeFactoryID;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblFactory;
        private DevExpress.XtraEditors.SimpleButton btCancel;
        private DevExpress.XtraEditors.SimpleButton btView;
        private DevExpress.XtraEditors.SimpleButton btSummary;
        private DevExpress.XtraEditors.SimpleButton btAudit;
    }
}