using ASPData.ASPDAO;
using ASPData.ProdStatisticDTO;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASPProject.ScanBarCodeBin
{
    public partial class frmScanBarcodeBinEdit1 : DevExpress.XtraEditors.XtraForm
    {
        public int type;
        ProdStatisticDAO prodStatisticDAO = new ProdStatisticDAO();
        PSScanBarcodeBin psScanBin = new PSScanBarcodeBin();
        public string Quantity, NW, GW, LotNo, WO;
        public long AutoID;
        public bool isAccept;
        public frmScanBarcodeBinEdit1()
        {
            InitializeComponent();

            this.Load += FrmScanBarcodeBinEdit1_Load;
            this.btCancel.Click += BtCancel_Click;
            this.btSave.Click += BtSave_Click;
        }

        #region Event
        private void BtCancel_Click(object sender, EventArgs e)
        {
            isAccept = false;
            this.Close();
        }

        private void BtSave_Click(object sender, EventArgs e)
        {
            psScanBin.Quantity = txtQuantity.Text.Trim();
            psScanBin.NW = Convert.ToDouble(txtNW.Text);
            psScanBin.GW = Convert.ToDouble(txtGW.Text);
            psScanBin.LotNo = txtLotNo.Text.Trim();
            psScanBin.WO = txtWO.Text.Trim();
            psScanBin.AutoID = (long)Convert.ToDouble(AutoID);

            prodStatisticDAO.UpdateScanBarCodeBinLine(psScanBin);

            //XtraMessageBox.Show("Đã cập nhật xong!");
            isAccept = true;
            this.Close();
        }

        private void FrmScanBarcodeBinEdit1_Load(object sender, EventArgs e)
        {
            txtQuantity.Text = Quantity;
            txtNW.Text = NW;
            txtGW.Text = GW;
            txtLotNo.Text = LotNo;
            txtWO.Text = WO;

            this.Show();
        }
        #endregion
    }
}
