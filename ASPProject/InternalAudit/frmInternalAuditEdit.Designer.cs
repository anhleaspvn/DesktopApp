namespace ASPProject.InternalAudit
{
    partial class frmInternalAuditEdit
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
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btSave = new DevExpress.XtraEditors.SimpleButton();
            this.mmEvidences = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.mmConclusion = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtAuditorName = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.mmEvidences.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmConclusion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAuditorName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(33, 28);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(57, 13);
            this.labelControl2.TabIndex = 134;
            this.labelControl2.Text = "Bằng chứng";
            // 
            // btCancel
            // 
            this.btCancel.ImageOptions.Image = global::ASPProject.Properties.Resources.close__2_;
            this.btCancel.Location = new System.Drawing.Point(350, 256);
            this.btCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(112, 32);
            this.btCancel.TabIndex = 132;
            this.btCancel.Text = "Đóng";
            // 
            // btSave
            // 
            this.btSave.ImageOptions.Image = global::ASPProject.Properties.Resources.save1;
            this.btSave.Location = new System.Drawing.Point(217, 256);
            this.btSave.Margin = new System.Windows.Forms.Padding(4);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(113, 32);
            this.btSave.TabIndex = 131;
            this.btSave.Text = "Lưu";
            // 
            // mmEvidences
            // 
            this.mmEvidences.Location = new System.Drawing.Point(162, 11);
            this.mmEvidences.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mmEvidences.Name = "mmEvidences";
            this.mmEvidences.Size = new System.Drawing.Size(506, 78);
            this.mmEvidences.TabIndex = 135;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(33, 129);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(39, 13);
            this.labelControl1.TabIndex = 136;
            this.labelControl1.Text = "Kết luận";
            // 
            // mmConclusion
            // 
            this.mmConclusion.Location = new System.Drawing.Point(162, 101);
            this.mmConclusion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mmConclusion.Name = "mmConclusion";
            this.mmConclusion.Size = new System.Drawing.Size(506, 78);
            this.mmConclusion.TabIndex = 137;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(33, 206);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(92, 13);
            this.labelControl3.TabIndex = 138;
            this.labelControl3.Text = "Tên người đánh giá";
            // 
            // txtAuditorName
            // 
            this.txtAuditorName.Location = new System.Drawing.Point(162, 203);
            this.txtAuditorName.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtAuditorName.Name = "txtAuditorName";
            this.txtAuditorName.Properties.UseMaskAsDisplayFormat = true;
            this.txtAuditorName.Size = new System.Drawing.Size(200, 20);
            this.txtAuditorName.TabIndex = 183;
            // 
            // frmInternalAuditEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 317);
            this.Controls.Add(this.txtAuditorName);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.mmConclusion);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.mmEvidences);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btSave);
            this.Name = "frmInternalAuditEdit";
            this.Text = "frmInternalAuditEdit";
            ((System.ComponentModel.ISupportInitialize)(this.mmEvidences.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmConclusion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAuditorName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btCancel;
        private DevExpress.XtraEditors.SimpleButton btSave;
        private DevExpress.XtraEditors.MemoEdit mmEvidences;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit mmConclusion;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtAuditorName;
    }
}