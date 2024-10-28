namespace ASPProject.ExternalIQC
{
    partial class frmIQCDetailDefectEdit
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
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtDefectQuantity = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lkeDefectiD = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.lbLosstimeID = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtDefectQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeDefectiD.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btCancel
            // 
            this.btCancel.ImageOptions.Image = global::ASPProject.Properties.Resources.close__2_;
            this.btCancel.Location = new System.Drawing.Point(305, 153);
            this.btCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(180, 61);
            this.btCancel.TabIndex = 126;
            this.btCancel.Text = "Đóng";
            // 
            // btSave
            // 
            this.btSave.ImageOptions.Image = global::ASPProject.Properties.Resources.save1;
            this.btSave.Location = new System.Drawing.Point(82, 153);
            this.btSave.Margin = new System.Windows.Forms.Padding(5);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(181, 61);
            this.btSave.TabIndex = 125;
            this.btSave.Text = "Lưu";
            // 
            // txtDefectQuantity
            // 
            this.txtDefectQuantity.Location = new System.Drawing.Point(241, 69);
            this.txtDefectQuantity.Margin = new System.Windows.Forms.Padding(10);
            this.txtDefectQuantity.Name = "txtDefectQuantity";
            this.txtDefectQuantity.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDefectQuantity.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDefectQuantity.Properties.UseMaskAsDisplayFormat = true;
            this.txtDefectQuantity.Size = new System.Drawing.Size(270, 23);
            this.txtDefectQuantity.TabIndex = 128;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(56, 73);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(10);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(51, 16);
            this.labelControl3.TabIndex = 131;
            this.labelControl3.Text = "Số lượng";
            // 
            // lkeDefectiD
            // 
            this.lkeDefectiD.EditValue = "";
            this.lkeDefectiD.Location = new System.Drawing.Point(241, 37);
            this.lkeDefectiD.Margin = new System.Windows.Forms.Padding(5);
            this.lkeDefectiD.Name = "lkeDefectiD";
            this.lkeDefectiD.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeDefectiD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeDefectiD.Properties.NullText = "";
            this.lkeDefectiD.Size = new System.Drawing.Size(270, 23);
            this.lkeDefectiD.TabIndex = 127;
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl12.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl12.Appearance.Options.UseBackColor = true;
            this.labelControl12.Appearance.Options.UseForeColor = true;
            this.labelControl12.Location = new System.Drawing.Point(205, 40);
            this.labelControl12.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(18, 16);
            this.labelControl12.TabIndex = 129;
            this.labelControl12.Text = "(*)";
            // 
            // lbLosstimeID
            // 
            this.lbLosstimeID.Location = new System.Drawing.Point(55, 40);
            this.lbLosstimeID.Margin = new System.Windows.Forms.Padding(6);
            this.lbLosstimeID.Name = "lbLosstimeID";
            this.lbLosstimeID.Size = new System.Drawing.Size(57, 16);
            this.lbLosstimeID.TabIndex = 130;
            this.lbLosstimeID.Text = "Mã Defect";
            // 
            // frmIQCDetailDefectEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 283);
            this.Controls.Add(this.txtDefectQuantity);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.lkeDefectiD);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.lbLosstimeID);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btSave);
            this.Name = "frmIQCDetailDefectEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmIQCDetailDefectEdit";
            ((System.ComponentModel.ISupportInitialize)(this.txtDefectQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeDefectiD.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btCancel;
        private DevExpress.XtraEditors.SimpleButton btSave;
        private DevExpress.XtraEditors.TextEdit txtDefectQuantity;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit lkeDefectiD;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl lbLosstimeID;
    }
}