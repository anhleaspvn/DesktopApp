namespace ASPProject.ProdQRCodeMaster
{
    partial class frmProdQRCodeMasterEdit
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
            this.lkeWO = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.lbLSX = new DevExpress.XtraEditors.LabelControl();
            this.txtProductID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.txtRequestQuantity = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.lkeWO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRequestQuantity.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lkeWO
            // 
            this.lkeWO.EditValue = "";
            this.lkeWO.Location = new System.Drawing.Point(129, 11);
            this.lkeWO.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lkeWO.Name = "lkeWO";
            this.lkeWO.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeWO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeWO.Properties.NullText = "";
            this.lkeWO.Size = new System.Drawing.Size(228, 20);
            this.lkeWO.TabIndex = 74;
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl12.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl12.Appearance.Options.UseBackColor = true;
            this.labelControl12.Appearance.Options.UseForeColor = true;
            this.labelControl12.Location = new System.Drawing.Point(110, 16);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(14, 13);
            this.labelControl12.TabIndex = 75;
            this.labelControl12.Text = "(*)";
            // 
            // lbLSX
            // 
            this.lbLSX.Location = new System.Drawing.Point(39, 16);
            this.lbLSX.Name = "lbLSX";
            this.lbLSX.Size = new System.Drawing.Size(68, 13);
            this.lbLSX.TabIndex = 76;
            this.lbLSX.Text = "Lệnh sản xuất";
            // 
            // txtProductID
            // 
            this.txtProductID.Location = new System.Drawing.Point(129, 42);
            this.txtProductID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Properties.ReadOnly = true;
            this.txtProductID.Size = new System.Drawing.Size(228, 20);
            this.txtProductID.TabIndex = 142;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(39, 48);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(47, 13);
            this.labelControl11.TabIndex = 140;
            this.labelControl11.Text = "Sản phẩm";
            // 
            // txtRequestQuantity
            // 
            this.txtRequestQuantity.Location = new System.Drawing.Point(129, 73);
            this.txtRequestQuantity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRequestQuantity.Name = "txtRequestQuantity";
            this.txtRequestQuantity.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtRequestQuantity.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtRequestQuantity.Properties.ReadOnly = true;
            this.txtRequestQuantity.Size = new System.Drawing.Size(228, 20);
            this.txtRequestQuantity.TabIndex = 144;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(39, 79);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 13);
            this.labelControl1.TabIndex = 143;
            this.labelControl1.Text = "Số lượng YC";
            // 
            // btCancel
            // 
            this.btCancel.ImageOptions.Image = global::ASPProject.Properties.Resources.close__2_;
            this.btCancel.Location = new System.Drawing.Point(193, 126);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(123, 40);
            this.btCancel.TabIndex = 146;
            this.btCancel.Text = "Đóng";
            // 
            // btSave
            // 
            this.btSave.ImageOptions.Image = global::ASPProject.Properties.Resources.save1;
            this.btSave.Location = new System.Drawing.Point(39, 126);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(124, 40);
            this.btSave.TabIndex = 145;
            this.btSave.Text = "Lưu";
            // 
            // frmProdQRCodeMasterEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 200);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.txtRequestQuantity);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtProductID);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.lkeWO);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.lbLSX);
            this.Name = "frmProdQRCodeMasterEdit";
            this.Text = "frmProdQRCodeMasterEdit";
            ((System.ComponentModel.ISupportInitialize)(this.lkeWO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRequestQuantity.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lkeWO;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl lbLSX;
        private DevExpress.XtraEditors.TextEdit txtProductID;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.TextEdit txtRequestQuantity;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btCancel;
        private DevExpress.XtraEditors.SimpleButton btSave;
    }
}