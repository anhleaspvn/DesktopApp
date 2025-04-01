namespace ASPProject.InternalAudit
{
    partial class frmISOAuditEmailEdit
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
            this.lbDeptID = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lkeFactoryID = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btSave = new DevExpress.XtraEditors.SimpleButton();
            this.lkeGLID = new DevExpress.XtraEditors.LookUpEdit();
            this.lkeHeadID = new DevExpress.XtraEditors.LookUpEdit();
            this.lkeDepartID = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeDeptID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeFactoryID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeGLID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeHeadID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeDepartID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lkeDeptID
            // 
            this.lkeDeptID.EditValue = "";
            this.lkeDeptID.Location = new System.Drawing.Point(202, 14);
            this.lkeDeptID.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.lkeDeptID.Name = "lkeDeptID";
            this.lkeDeptID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeDeptID.Properties.NullText = "";
            this.lkeDeptID.Size = new System.Drawing.Size(202, 23);
            this.lkeDeptID.TabIndex = 7;
            // 
            // lbDeptID
            // 
            this.lbDeptID.Location = new System.Drawing.Point(78, 22);
            this.lbDeptID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbDeptID.Name = "lbDeptID";
            this.lbDeptID.Size = new System.Drawing.Size(46, 16);
            this.lbDeptID.TabIndex = 68;
            this.lbDeptID.Text = "Bộ phận";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(78, 60);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(50, 16);
            this.labelControl1.TabIndex = 69;
            this.labelControl1.Text = "Nhà máy";
            // 
            // lkeFactoryID
            // 
            this.lkeFactoryID.EditValue = "";
            this.lkeFactoryID.Location = new System.Drawing.Point(202, 52);
            this.lkeFactoryID.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.lkeFactoryID.Name = "lkeFactoryID";
            this.lkeFactoryID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeFactoryID.Properties.NullText = "";
            this.lkeFactoryID.Size = new System.Drawing.Size(202, 23);
            this.lkeFactoryID.TabIndex = 70;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(78, 98);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(78, 16);
            this.labelControl2.TabIndex = 71;
            this.labelControl2.Text = "Trưởng nhóm";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(78, 137);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(74, 16);
            this.labelControl3.TabIndex = 185;
            this.labelControl3.Text = "Trưởng đoàn";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(78, 175);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(92, 16);
            this.labelControl4.TabIndex = 187;
            this.labelControl4.Text = "Trưởng bộ phận";
            // 
            // btCancel
            // 
            this.btCancel.ImageOptions.Image = global::ASPProject.Properties.Resources.close__2_;
            this.btCancel.Location = new System.Drawing.Point(260, 224);
            this.btCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(144, 49);
            this.btCancel.TabIndex = 190;
            this.btCancel.Text = "Đóng";
            // 
            // btSave
            // 
            this.btSave.ImageOptions.Image = global::ASPProject.Properties.Resources.save1;
            this.btSave.Location = new System.Drawing.Point(82, 224);
            this.btSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(145, 49);
            this.btSave.TabIndex = 189;
            this.btSave.Text = "Lưu";
            // 
            // lkeGLID
            // 
            this.lkeGLID.EditValue = "";
            this.lkeGLID.Location = new System.Drawing.Point(202, 90);
            this.lkeGLID.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.lkeGLID.Name = "lkeGLID";
            this.lkeGLID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeGLID.Properties.NullText = "";
            this.lkeGLID.Size = new System.Drawing.Size(202, 23);
            this.lkeGLID.TabIndex = 191;
            // 
            // lkeHeadID
            // 
            this.lkeHeadID.EditValue = "";
            this.lkeHeadID.Location = new System.Drawing.Point(202, 128);
            this.lkeHeadID.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.lkeHeadID.Name = "lkeHeadID";
            this.lkeHeadID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeHeadID.Properties.NullText = "";
            this.lkeHeadID.Size = new System.Drawing.Size(202, 23);
            this.lkeHeadID.TabIndex = 192;
            // 
            // lkeDepartID
            // 
            this.lkeDepartID.EditValue = "";
            this.lkeDepartID.Location = new System.Drawing.Point(202, 166);
            this.lkeDepartID.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.lkeDepartID.Name = "lkeDepartID";
            this.lkeDepartID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeDepartID.Properties.NullText = "";
            this.lkeDepartID.Size = new System.Drawing.Size(202, 23);
            this.lkeDepartID.TabIndex = 193;
            // 
            // frmISOAuditEmailEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 302);
            this.Controls.Add(this.lkeDepartID);
            this.Controls.Add(this.lkeHeadID);
            this.Controls.Add(this.lkeGLID);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.lkeFactoryID);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lbDeptID);
            this.Controls.Add(this.lkeDeptID);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmISOAuditEmailEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmISOAuditEmailEdit";
            ((System.ComponentModel.ISupportInitialize)(this.lkeDeptID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeFactoryID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeGLID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeHeadID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeDepartID.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lkeDeptID;
        private DevExpress.XtraEditors.LabelControl lbDeptID;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lkeFactoryID;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btCancel;
        private DevExpress.XtraEditors.SimpleButton btSave;
        private DevExpress.XtraEditors.LookUpEdit lkeGLID;
        private DevExpress.XtraEditors.LookUpEdit lkeHeadID;
        private DevExpress.XtraEditors.LookUpEdit lkeDepartID;
    }
}