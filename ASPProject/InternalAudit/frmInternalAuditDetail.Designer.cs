namespace ASPProject.InternalAudit
{
    partial class frmInternalAuditDetail
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
            this.btView = new DevExpress.XtraEditors.SimpleButton();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lkeFactoryID = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblFactory = new DevExpress.XtraEditors.LabelControl();
            this.btSummary = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.lkeFactoryID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btView
            // 
            this.btView.ImageOptions.Image = global::ASPProject.Properties.Resources.save1;
            this.btView.Location = new System.Drawing.Point(26, 61);
            this.btView.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btView.Name = "btView";
            this.btView.Size = new System.Drawing.Size(111, 38);
            this.btView.TabIndex = 98;
            this.btView.Text = "Xem File";
            // 
            // btCancel
            // 
            this.btCancel.ImageOptions.Image = global::ASPProject.Properties.Resources.close__2_;
            this.btCancel.Location = new System.Drawing.Point(148, 61);
            this.btCancel.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(110, 38);
            this.btCancel.TabIndex = 97;
            this.btCancel.Text = "Đóng";
            // 
            // lkeFactoryID
            // 
            this.lkeFactoryID.EditValue = "";
            this.lkeFactoryID.Location = new System.Drawing.Point(106, 15);
            this.lkeFactoryID.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.lkeFactoryID.Name = "lkeFactoryID";
            this.lkeFactoryID.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeFactoryID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeFactoryID.Properties.NullText = "";
            this.lkeFactoryID.Size = new System.Drawing.Size(244, 20);
            this.lkeFactoryID.TabIndex = 94;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(70, 21);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(14, 13);
            this.labelControl1.TabIndex = 96;
            this.labelControl1.Text = "(*)";
            // 
            // lblFactory
            // 
            this.lblFactory.Location = new System.Drawing.Point(18, 21);
            this.lblFactory.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lblFactory.Name = "lblFactory";
            this.lblFactory.Size = new System.Drawing.Size(42, 13);
            this.lblFactory.TabIndex = 95;
            this.lblFactory.Text = "Nhà máy";
            // 
            // btSummary
            // 
            this.btSummary.ImageOptions.Image = global::ASPProject.Properties.Resources.money;
            this.btSummary.Location = new System.Drawing.Point(268, 61);
            this.btSummary.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btSummary.Name = "btSummary";
            this.btSummary.Size = new System.Drawing.Size(119, 38);
            this.btSummary.TabIndex = 99;
            this.btSummary.Text = "Tổng hợp";
            // 
            // frmInternalAuditDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 152);
            this.Controls.Add(this.btSummary);
            this.Controls.Add(this.btView);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.lkeFactoryID);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lblFactory);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmInternalAuditDetail";
            this.Text = "frmInternalAuditDetail";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.lkeFactoryID.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btView;
        private DevExpress.XtraEditors.SimpleButton btCancel;
        private DevExpress.XtraEditors.LookUpEdit lkeFactoryID;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblFactory;
        private DevExpress.XtraEditors.SimpleButton btSummary;
    }
}