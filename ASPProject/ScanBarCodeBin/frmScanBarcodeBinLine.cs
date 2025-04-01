using ASPData;
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
    public partial class frmScanBarcodeBinLine : DevExpress.XtraEditors.XtraForm
    {
        DataTable dtSB = new DataTable();
        DataTable dtSB2 = new DataTable();
        BindingSource bdsSB = new BindingSource();
        BindingSource bdsSB2 = new BindingSource();

        public frmMain frm;
        public delegate void _deDongTab();
        public _deDongTab deDongTab;
        public int iNgonNgu;
        public string userName;

        ProdStatisticDAO prodStatisticDAO = new ProdStatisticDAO();
        ProdStatisticDTO prodStatisticDTO = new ProdStatisticDTO();
        PSScanBarcodeBin psScanBin = new PSScanBarcodeBin();

        private readonly SQLHelper _sqlHelper = new SQLHelper();
        public frmScanBarcodeBinLine()
        {
            InitializeComponent();

            this.Load += FrmScanBarcodeBinLine_Load;
            this.btInput.Click += BtInput_Click;
            this.btInput2.Click += BtInput2_Click;
            this.btCopy1.Click += BtCopy1_Click;
            this.btCopy2.Click += BtCopy2_Click;

            this.gridScanBarcodeBinLineView.RowStyle += GridScanBarcodeBinLineView_RowStyle;
            this.gridScanBarcodeBinLineV2View.RowStyle += GridScanBarcodeBinLineV2View_RowStyle;
        }

       
        private void GridScanBarcodeBinLineV2View_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            bool isOriginal = Convert.ToBoolean(gridScanBarcodeBinLineV2View.GetRowCellValue(e.RowHandle, "IsOriginal"));

            if (isOriginal)
            {
                e.Appearance.ForeColor = Color.Orange;
            }
        }

        private void GridScanBarcodeBinLineView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            bool isOriginal = Convert.ToBoolean(gridScanBarcodeBinLineView.GetRowCellValue(e.RowHandle, "IsOriginal"));

            if (isOriginal) {
                e.Appearance.ForeColor = Color.Orange;
            }
        }

        private void BtCopy2_Click(object sender, EventArgs e)
        {
            var quantity = XtraInputBox.Show("Nhập số dòng cần copy", "Số lượng dòng", 1);

            if (Convert.ToInt32(quantity) == 0)
                return;

            int count = 1;
            while (count <= quantity)
            {
                foreach (int row in gridScanBarcodeBinLineV2View.GetSelectedRows())
                {
                    DataRow drow = gridScanBarcodeBinLineV2View.GetDataRow(row);

                    if (drow == null)
                        continue;

                    psScanBin.CusID = Convert.ToString(drow["CusID"]);
                    psScanBin.Quantity = Convert.ToString(drow["Quantity"]);
                    psScanBin.BinQuantity = Convert.ToString(drow["BinQuantity"]).Substring(0, Convert.ToString(drow["BinQuantity"]).Length -1) + row.ToString();
                    psScanBin.BinQuantitySum = Convert.ToString(drow["BinQuantitySum"]);
                    psScanBin.ShipDate = Convert.ToString(drow["ShipDate"]);
                    psScanBin.Rev = Convert.ToString(drow["Rev"]);
                    psScanBin.PartNo = Convert.ToString(drow["PartNo"]);
                    psScanBin.WO = Convert.ToString(drow["WO"]);
                    psScanBin.PkgGwt = Convert.ToString(drow["PkgGwt"]);
                    psScanBin.Desc = Convert.ToString(drow["Desc"]);
                    psScanBin.MadeInVN = Convert.ToString(drow["MadeInVN"]);
                    psScanBin.CreatedBy = userName;
                    psScanBin.CreatedDate = DateTime.Now;
                    psScanBin.LastModifiedBy = userName;
                    psScanBin.LastModifiedDate = DateTime.Now;
                  
                    prodStatisticDAO.CopyScanBarcodeBinLineV2(psScanBin);
                }
                count++;
            }

            FillData();
            XtraMessageBox.Show("Đã copy thành công!");
        }

        private void BtCopy1_Click(object sender, EventArgs e)
        {
            var quantity = XtraInputBox.Show("Nhập số dòng cần copy", "Số lượng dòng", 1);

            if (Convert.ToInt32(quantity) == 0)
                return;

            int count = 1;
            while(count <= quantity)
            {
                foreach(int row in gridScanBarcodeBinLineView.GetSelectedRows())
                {
                    DataRow drow = gridScanBarcodeBinLineView.GetDataRow(row);

                    if (drow == null)
                        continue;

                    string iCartNo = (Convert.ToInt32(drow["CartNo"]) + count).ToString().PadLeft(3,'0');

                    psScanBin.PartNo = Convert.ToString(drow["PartNo"]);
                    psScanBin.ItemNo = Convert.ToString(drow["ItemNo"]);
                    psScanBin.Quantity = Convert.ToString(drow["Quantity"]);
                    psScanBin.NW = Convert.ToDouble(drow["NW"]);
                    psScanBin.GW = Convert.ToDouble(drow["GW"]);
                    psScanBin.CartNo = iCartNo;
                    psScanBin.LotNo = Convert.ToString(drow["LotNo"]).Substring(0, Convert.ToString(drow["LotNo"]).Length -3) + iCartNo;
                    psScanBin.WO = Convert.ToString(drow["WO"]);
                    psScanBin.Cable = Convert.ToString(drow["Cable"]);
                    psScanBin.BinSize = Convert.ToString(drow["BinSize"]);
                    psScanBin.ULStamp = Convert.ToString(drow["ULStamp"]);
                    psScanBin.UL2Stamp = Convert.ToString(drow["UL2Stamp"]);
                    psScanBin.SBDate = Convert.ToString(drow["SBDate"]);
                    psScanBin.CreatedBy = userName;
                    psScanBin.CreatedDate = DateTime.Now;
                    psScanBin.LastModifiedBy = userName;
                    psScanBin.LastModifiedDate = DateTime.Now;

                    prodStatisticDAO.CopyScanBarcodeBinLine(psScanBin);
                }
                count++;
            }
            
            FillData();
            XtraMessageBox.Show("Đã copy thành công!");
        }

        private void BtInput_Click(object sender, EventArgs e)
        {
            DataRowView row = (DataRowView)gridScanBarcodeBinLineView.GetFocusedRow();

            if (row == null)
            {
                //XtraMessageBox.Show("Không được chỉnh sửa dòng dữ liệu gốc");
                return;
            }

            frmScanBarcodeBinEdit1 frmEdit1 = new frmScanBarcodeBinEdit1();
            frmEdit1.type = 1;
            frmEdit1.Quantity = Convert.ToString(row["Quantity"]);
            frmEdit1.NW = Convert.ToString(row["NW"]);
            frmEdit1.GW = Convert.ToString(row["GW"]);
            frmEdit1.LotNo = Convert.ToString(row["LotNo"]);
            frmEdit1.WO = Convert.ToString(row["WO"]);
            frmEdit1.AutoID = (long)Convert.ToDouble(row["AutoID"]);

            // Thêm event handler cho FormClosed
            frmEdit1.FormClosed += (s, args) =>
            {
                if (frmEdit1.isAccept) // Chỉ fill data nếu người dùng chấp nhận thay đổi
                {
                    FillData();
                }
            };

            frmEdit1.Show();
        }

        private void BtInput2_Click(object sender, EventArgs e)
        {
            DataRowView row = (DataRowView)gridScanBarcodeBinLineV2View.GetFocusedRow();
            if (row == null)
            {
                //XtraMessageBox.Show("Không được chỉnh sửa dòng dữ liệu gốc");
                return;
            }

            frmScanBarcodeBinEdit2 frmEdit2 = new frmScanBarcodeBinEdit2();
            frmEdit2.type = 1;
            frmEdit2.Quantity = Convert.ToString(row["Quantity"]);
            frmEdit2.BinQuantity = Convert.ToString(row["BinQuantity"]);
            frmEdit2.BinQuantitySum = Convert.ToString(row["BinQuantitySum"]);
            frmEdit2.ShipDate = Convert.ToString(row["ShipDate"]);
            frmEdit2.WO = Convert.ToString(row["WO"]);
            frmEdit2.PkgGwt = Convert.ToString(row["PkgGwt"]);
            frmEdit2.AutoID = (long)Convert.ToDouble(row["AutoID"]);

            // Thêm event handler cho FormClosed
            frmEdit2.FormClosed += (s, args) =>
            {
                if (frmEdit2.isAccept) // Chỉ fill data nếu người dùng chấp nhận thay đổi
                {
                    FillData();
                }
            };

            frmEdit2.Show();
        }

        private void FrmScanBarcodeBinLine_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            DataSet ds = new DataSet();

            prodStatisticDTO.FromDate = DateTime.Now;
            prodStatisticDTO.ToDate = DateTime.Now;
            ds = prodStatisticDAO.GetScanBarcodeBinLine(prodStatisticDTO);

            if (ds.Tables.Count > 0)
            {
                dtSB = ds.Tables[0];
                bdsSB.DataSource = dtSB;
                gridScanBarcodeBinLine.DataSource = bdsSB;
            }

            if (ds.Tables.Count > 1)
            {
                dtSB2 = ds.Tables[1];
                bdsSB2.DataSource = dtSB2;
                gridScanBarcodeBinLineV2.DataSource = bdsSB2;
            }
        }
    }
}
