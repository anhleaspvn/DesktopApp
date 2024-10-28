namespace ASPProject.SOPStage
{
    partial class frmSOPStageEdit
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
            this.txtStageID = new DevExpress.XtraEditors.TextEdit();
            this.txtStageName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.lbStageName = new DevExpress.XtraEditors.LabelControl();
            this.lbStageID = new DevExpress.XtraEditors.LabelControl();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtStageID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStageName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStageID
            // 
            this.txtStageID.Enabled = false;
            this.txtStageID.Location = new System.Drawing.Point(169, 33);
            this.txtStageID.Margin = new System.Windows.Forms.Padding(4);
            this.txtStageID.Name = "txtStageID";
            this.txtStageID.Properties.ReadOnly = true;
            this.txtStageID.Size = new System.Drawing.Size(146, 23);
            this.txtStageID.TabIndex = 69;
            // 
            // txtStageName
            // 
            this.txtStageName.Location = new System.Drawing.Point(169, 62);
            this.txtStageName.Margin = new System.Windows.Forms.Padding(4);
            this.txtStageName.Name = "txtStageName";
            this.txtStageName.Size = new System.Drawing.Size(266, 23);
            this.txtStageName.TabIndex = 70;
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl14.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl14.Appearance.Options.UseBackColor = true;
            this.labelControl14.Appearance.Options.UseForeColor = true;
            this.labelControl14.Location = new System.Drawing.Point(146, 68);
            this.labelControl14.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(18, 16);
            this.labelControl14.TabIndex = 72;
            this.labelControl14.Text = "(*)";
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl12.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl12.Appearance.Options.UseBackColor = true;
            this.labelControl12.Appearance.Options.UseForeColor = true;
            this.labelControl12.Location = new System.Drawing.Point(146, 36);
            this.labelControl12.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(18, 16);
            this.labelControl12.TabIndex = 71;
            this.labelControl12.Text = "(*)";
            // 
            // lbStageName
            // 
            this.lbStageName.Location = new System.Drawing.Point(50, 68);
            this.lbStageName.Margin = new System.Windows.Forms.Padding(4);
            this.lbStageName.Name = "lbStageName";
            this.lbStageName.Size = new System.Drawing.Size(85, 16);
            this.lbStageName.TabIndex = 74;
            this.lbStageName.Text = "Tên công đoạn";
            // 
            // lbStageID
            // 
            this.lbStageID.Location = new System.Drawing.Point(50, 36);
            this.lbStageID.Margin = new System.Windows.Forms.Padding(4);
            this.lbStageID.Name = "lbStageID";
            this.lbStageID.Size = new System.Drawing.Size(80, 16);
            this.lbStageID.TabIndex = 73;
            this.lbStageID.Text = "Mã công đoạn";
            // 
            // btCancel
            // 
            this.btCancel.ImageOptions.Image = global::ASPProject.Properties.Resources.close__2_;
            this.btCancel.Location = new System.Drawing.Point(400, 117);
            this.btCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(144, 49);
            this.btCancel.TabIndex = 76;
            this.btCancel.Text = "Đóng";
            // 
            // btSave
            // 
            this.btSave.ImageOptions.Image = global::ASPProject.Properties.Resources.save1;
            this.btSave.Location = new System.Drawing.Point(221, 117);
            this.btSave.Margin = new System.Windows.Forms.Padding(4);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(145, 49);
            this.btSave.TabIndex = 75;
            this.btSave.Text = "Lưu";
            // 
            // frmSOPStage_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 192);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.txtStageID);
            this.Controls.Add(this.txtStageName);
            this.Controls.Add(this.labelControl14);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.lbStageName);
            this.Controls.Add(this.lbStageID);
            this.Name = "frmSOPStage_Edit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Công đoạn SOP";
            ((System.ComponentModel.ISupportInitialize)(this.txtStageID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStageName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtStageID;
        private DevExpress.XtraEditors.TextEdit txtStageName;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl lbStageName;
        private DevExpress.XtraEditors.LabelControl lbStageID;
        private DevExpress.XtraEditors.SimpleButton btCancel;
        private DevExpress.XtraEditors.SimpleButton btSave;
    }
}