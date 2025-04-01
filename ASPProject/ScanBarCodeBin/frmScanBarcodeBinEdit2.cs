using ASPData.ASPDAO;
using ASPData.ProdStatisticDTO;
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
    public partial class frmScanBarcodeBinEdit2 : DevExpress.XtraEditors.XtraForm
    {
        public int type;
        ProdStatisticDAO prodStatisticDAO = new ProdStatisticDAO();
        PSScanBarcodeBin psScanBin = new PSScanBarcodeBin();
        public string Quantity, BinQuantity, BinQuantitySum, ShipDate, WO, PkgGwt;
        public long AutoID;
        public bool isAccept;
        public frmScanBarcodeBinEdit2()
        {
            InitializeComponent();

            this.Load += FrmScanBarcodeBinEdit2_Load;
            btCancel.Click += BtCancel_Click;
            btSave.Click += BtSave_Click;
        }

        private void BtSave_Click(object sender, EventArgs e)
        {
            psScanBin.Quantity = txtQuantity.Text.Trim();
            psScanBin.BinQuantity = txtBinQuantity.Text.Trim();
            psScanBin.BinQuantitySum = txtBinQuantitySum.Text.Trim();
            psScanBin.ShipDate = txtShipDate.Text.Trim();
            psScanBin.WO = txtWO.Text.Trim();
            psScanBin.PkgGwt = txtPkgGwt.Text.Trim();
            psScanBin.AutoID = (long)Convert.ToDouble(AutoID);

            prodStatisticDAO.UpdateScanBarCodeBinLineV2(psScanBin);

            isAccept = true;
            this.Close();
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmScanBarcodeBinEdit2_Load(object sender, EventArgs e)
        {
            txtQuantity.Text = Quantity;
            txtBinQuantity.Text = BinQuantity;
            txtBinQuantitySum.Text = BinQuantitySum;
            txtShipDate.Text = ShipDate;
            txtWO.Text = WO;
            txtPkgGwt.Text = PkgGwt;

            this.Show();
        }
    }
}
