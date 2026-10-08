using ASPData;
using ASPData.ASPDAO;
using ASPData.ProdStatisticDTO;
using DevExpress.DataAccess.Native.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;
using GridView = DevExpress.XtraGrid.Views.Grid.GridView;

namespace ASPProject.ScanBarCodeBin
{
    public partial class frmBinLineQCApproval : DevExpress.XtraEditors.XtraForm
    {
        DataTable dtQC = new DataTable();
        BindingSource bdsQC = new BindingSource();
        DataTable dtQCVerify = new DataTable();
        BindingSource bdsQCVerify = new BindingSource();
        ProdStatisticDAO prodStatisticDAO = new ProdStatisticDAO();
        ProdStatisticDTO prodStatisticDTO = new ProdStatisticDTO();
        private readonly SQLHelper _sqlHelper = new SQLHelper();
        int currentRowHandle = 0;
        bool isScanning = false;
        //DateTime FromDate, ToDate;
        //System.Windows.Forms.TextBox hiddenTextBox;
        public frmBinLineQCApproval()
        {
            InitializeComponent();

            this.Load += FrmBinLineQCApproval_Load;

            this.dtFromDate.EditValue = DateTime.Now;
            this.dtToDate.EditValue = DateTime.Now;
           
            this.gridBinLineQCApprovalView.CellValueChanging += GridBinLineQCApprovalView_CellValueChanging;
            this.gridBinLineQCApprovalView.MouseUp += GridBinLineQCApprovalView_MouseUp;
            this.gridBinLineQCApprovalView.RowCellClick += GridBinLineQCApprovalView_RowCellClick;
            this.gridBinLineQCApprovalView.RowClick += GridBinLineQCApprovalView_RowClick;
            this.gridBinLineQCApprovalView.RowStyle += GridBinLineQCApprovalView_RowStyle;

            this.txtQRContent.KeyDown += TxtQRContent_KeyDown;
            this.txtQRQuantity.KeyDown += TxtQRQuantity_KeyDown;
            this.txtProdEmpName.KeyDown += TxtProdEmpName_KeyDown;
            this.txtQCEmpName.KeyDown += TxtQCEmpName_KeyDown;
            this.btFilter.Click += BtFilter_Click;
            this.txtPOCode.KeyDown += TxtPOCode_KeyDown;
            this.txtPOKH.KeyDown += TxtPOKH_KeyDown;
            //this.txtRev.KeyDown += TxtRev_KeyDown;
            this.txtSupplier.KeyDown += TxtSupplier_KeyDown;
            this.txtEngLevel.KeyDown += TxtEngLevel_KeyDown;
            this.txtPartNo0.KeyDown += TxtPartNo0_KeyDown;
            this.txtWODocNo.KeyDown += TxtWODocNo_KeyDown;

            this.txtQRContent.ImeMode = ImeMode.Off;
            this.txtQRQuantity.ImeMode = ImeMode.Off;
            this.txtProdEmpName.ImeMode = ImeMode.Off;
            this.txtQCEmpName.ImeMode = ImeMode.Off;
            
            this.txtPOCode.ImeMode = ImeMode.Off;
            this.txtPOKH.ImeMode = ImeMode.Off;
            //this.txtRev.KeyDown += TxtRev_KeyDown;
            this.txtSupplier.ImeMode = ImeMode.Off;
            this.txtEngLevel.ImeMode = ImeMode.Off;
            this.txtPartNo0.ImeMode = ImeMode.Off;
            this.txtWODocNo.ImeMode = ImeMode.Off;

            this.btProdInput.Click += BtProdInput_Click;
            
        }

        private void TxtWODocNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string scanResult = txtWODocNo.Text.Trim();
                if (!string.IsNullOrEmpty(scanResult))
                {
                    gridBinLineQCApprovalView.SetRowCellValue(currentRowHandle, "WODocNo", scanResult);
                    DataRow drCurrent = gridBinLineQCApprovalView.GetDataRow(currentRowHandle);
                    drCurrent["WODocNo"] = scanResult;

                    if (drCurrent != null)
                    {
                        SaveData();
                    }

                    // Xóa TextEdit sau khi chèn
                    txtWODocNo.Text = "";
                }
                e.Handled = true; // Ngăn xử lý thêm
            }
        }

        private void BtProdInput_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn nhập thành phẩm của các Lệnh sản xuất này không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            foreach (int i in   gridBinLineQCApprovalView.GetSelectedRows())
            {
                DataRow drI = gridBinLineQCApprovalView.GetDataRow(i);

                string woDocNo = drI["WODocNo"].ToString().Trim();

                DateTime printDate = Convert.ToDateTime(drI["PrintDate"]);

                var dicParams = new Dictionary<string, object>()
                {
                    { "@WODocNo", woDocNo },
                    { "@PrintDate", printDate }
                };

                _sqlHelper.ExecProcedureNonData("sp_ASPTransferInputProduct", dicParams);
            }

            XtraMessageBox.Show("Đã chuyển thành công!");
        }

        private void TxtPartNo0_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string scanResult = txtPartNo0.Text.Trim();
                if (!string.IsNullOrEmpty(scanResult))
                {
                    gridBinLineQCApprovalView.SetRowCellValue(currentRowHandle, "PartNo0", scanResult);
                    DataRow drCurrent = gridBinLineQCApprovalView.GetDataRow(currentRowHandle);
                    drCurrent["PartNo0"] = scanResult;

                    if (drCurrent != null)
                    {
                        SaveData();
                    }

                    // Xóa TextEdit sau khi chèn
                    txtPartNo0.Text = "";
                }
                e.Handled = true; // Ngăn xử lý thêm
            }
        }

        private void TxtEngLevel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string scanResult = txtEngLevel.Text.Trim();
                if (!string.IsNullOrEmpty(scanResult))
                {
                    gridBinLineQCApprovalView.SetRowCellValue(currentRowHandle, "EngLevel", scanResult);
                    DataRow drCurrent = gridBinLineQCApprovalView.GetDataRow(currentRowHandle);
                    drCurrent["EngLevel"] = scanResult;

                    if (drCurrent != null)
                    {
                        SaveData();
                    }

                    // Xóa TextEdit sau khi chèn
                    txtEngLevel.Text = "";
                }
                e.Handled = true; // Ngăn xử lý thêm
            }
        }

        private void TxtSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string scanResult = txtSupplier.Text.Trim();
                if (!string.IsNullOrEmpty(scanResult))
                {
                    gridBinLineQCApprovalView.SetRowCellValue(currentRowHandle, "Supplier", scanResult);
                    DataRow drCurrent = gridBinLineQCApprovalView.GetDataRow(currentRowHandle);
                    drCurrent["Supplier"] = scanResult;

                    if (drCurrent != null)
                    {
                        SaveData();
                    }

                    // Xóa TextEdit sau khi chèn
                    txtSupplier.Text = "";
                }
                e.Handled = true; // Ngăn xử lý thêm
            }
        }

        private void TxtPOKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string scanResult = txtPOKH.Text.Trim();
                if (!string.IsNullOrEmpty(scanResult))
                {
                    gridBinLineQCApprovalView.SetRowCellValue(currentRowHandle, "POText", scanResult);
                    DataRow drCurrent = gridBinLineQCApprovalView.GetDataRow(currentRowHandle);
                    drCurrent["POText"] = scanResult;

                    if (drCurrent != null)
                    {
                        if (scanResult.Trim() == (string)drCurrent["POTextLinkQ"])
                            drCurrent["POTextVerify"] = "OK";
                        else
                            drCurrent["POTextVerify"] = "NG";

                        SaveData();
                    }

                    // Xóa TextEdit sau khi chèn
                    txtPOKH.Text = "";
                }
                e.Handled = true; // Ngăn xử lý thêm
            }
        }

        private void GridBinLineQCApprovalView_RowStyle(object sender, RowStyleEventArgs e)
        {
            string isDup = Convert.ToString(gridBinLineQCApprovalView.GetRowCellValue(e.RowHandle, "QRCodeVerify"));
            string isPOKH = Convert.ToString(gridBinLineQCApprovalView.GetRowCellValue(e.RowHandle, "POTextVerify"));

            if (isDup == "NG" || isPOKH == "NG")
            {
                e.Appearance.BackColor = Color.Red;
            }
        }

        private void TxtQCEmpName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                string scanResult = txtQCEmpName.Text.Trim();
                string[] arrScanResult = scanResult.Split('-');
                if (!string.IsNullOrEmpty(scanResult))
                {
                    gridBinLineQCApprovalView.SetRowCellValue(currentRowHandle, "QCEmpName", arrScanResult[0]);
                    DataRow drCurrent = gridBinLineQCApprovalView.GetDataRow(currentRowHandle);

                    if (drCurrent != null)
                    {
                        drCurrent["QCEmpName"] = arrScanResult[0];

                        SaveData();
                    }

                    // Xóa TextEdit sau khi chèn
                    txtQCEmpName.Text = "";
                }
                e.Handled = true; // Ngăn xử lý thêm
            }
        }

        private void TxtProdEmpName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string scanResult = txtProdEmpName.Text.Trim();
                string[] arrScanResult = scanResult.Split('-');
                if (!string.IsNullOrEmpty(scanResult))
                {
                    gridBinLineQCApprovalView.SetRowCellValue(currentRowHandle, "ProdEmpName", arrScanResult[0]);
                    DataRow drCurrent = gridBinLineQCApprovalView.GetDataRow(currentRowHandle);

                    if (drCurrent != null)
                    {
                        drCurrent["ProdEmpName"] = arrScanResult[0];

                        SaveData();
                    }

                    // Xóa TextEdit sau khi chèn
                    txtProdEmpName.Text = "";
                }
                e.Handled = true; // Ngăn xử lý thêm
            }
        }

        private void BtFilter_Click(object sender, EventArgs e)
        {
            FillData();
            FillDataVerify();
        }

        private void TxtQRContent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string scanResult = txtQRContent.Text.Trim();
                if (!string.IsNullOrEmpty(scanResult))
                {
                    gridBinLineQCApprovalView.SetRowCellValue(currentRowHandle, "QRCodeData", scanResult);
                    DataRow drCurrent = gridBinLineQCApprovalView.GetDataRow(currentRowHandle);
                    drCurrent["QRCodeData"] = scanResult;

                    if (drCurrent != null)
                    {
                        if (scanResult.Trim() == (string)drCurrent["CustomerVerify"])
                            drCurrent["QRCodeVerify"] = "OK";
                        else
                            drCurrent["QRCodeVerify"] = "NG";

                        SaveData();
                    }

                    // Xóa TextEdit sau khi chèn
                    txtQRContent.Text = "";
                }
                e.Handled = true; // Ngăn xử lý thêm
            }
        }

        private void TxtPOCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string scanResult = txtPOCode.Text.Trim();
                if (!string.IsNullOrEmpty(scanResult))
                {
                    gridBinLineQCApprovalView.SetRowCellValue(currentRowHandle, "POCode", scanResult);
                    DataRow drCurrent = gridBinLineQCApprovalView.GetDataRow(currentRowHandle);
                    drCurrent["POCode"] = scanResult;

                    if (drCurrent != null)
                    {
                      

                        SaveData();
                    }

                    // Xóa TextEdit sau khi chèn
                    txtPOCode.Text = "";
                }
                e.Handled = true; // Ngăn xử lý thêm
            }
        }

        private void TxtQRQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string scanResult = txtQRQuantity.Text.Trim().Replace("pcs", string.Empty).Replace("PCS", string.Empty).Replace("+P+C+S", string.Empty);
                if (!string.IsNullOrEmpty(scanResult))
                {
                    gridBinLineQCApprovalView.SetRowCellValue(currentRowHandle, "SumQuantity", scanResult);
                    DataRow drCurrent = gridBinLineQCApprovalView.GetDataRow(currentRowHandle);

                    double sumQuantity = 0;

                    bool bQua = Double.TryParse(scanResult, out sumQuantity);

                    drCurrent["SumQuantity"] = bQua == true ? sumQuantity : 0;
                    
                    if (drCurrent != null)
                    {
                        SaveData();
                    }

                    // Xóa TextEdit sau khi chèn
                    txtQRQuantity.Text = string.Empty;
                }
                e.Handled = true; // Ngăn xử lý thêm
            }
        }

        private void GridBinLineQCApprovalView_RowClick(object sender, RowClickEventArgs e)
        {
            currentRowHandle = e.RowHandle;
        }

        private void GridBinLineQCApprovalView_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            // Kiểm tra xem cột được nhấp vào có phải là "Xác nhận QC" không
            if (e.Column.FieldName == "QCVerify")
            {
                // Lấy giá trị hiện tại của ô
                bool currentValue = Convert.ToBoolean(gridBinLineQCApprovalView.GetRowCellValue(e.RowHandle, e.Column));

                string qcEmpName = Convert.ToString(gridBinLineQCApprovalView.GetRowCellValue(e.RowHandle, "QCEmpName"));
                string prodEmpName = Convert.ToString(gridBinLineQCApprovalView.GetRowCellValue(e.RowHandle, "ProdEmpName"));

                if (string.IsNullOrEmpty(qcEmpName) || string.IsNullOrEmpty(prodEmpName)) {
                    XtraMessageBox.Show("Vui lòng bổ sung đủ người xác nhận QC và nhân viên sản xuất!");
                    return;
                }

                // Đảo ngược giá trị (từ true thành false hoặc ngược lại)
                bool newValue = !currentValue;

                // Cập nhật giá trị mới cho ô (bỏ qua thuộc tính ReadOnly)
                gridBinLineQCApprovalView.SetRowCellValue(e.RowHandle, e.Column, newValue);

                // Đảm bảo dữ liệu được commit vào datasource
                gridBinLineQCApprovalView.CloseEditor();
                gridBinLineQCApprovalView.UpdateCurrentRow();

                // Thực hiện logic của bạn
                //MessageBox.Show($"Xác nhận QC thay đổi thành: {newValue}");
                SaveData();

                // Ngăn sự kiện mặc định để không yêu cầu click lần thứ hai
                e.Handled = true;

                FillData();
                FillDataVerify();
            }
        }

        // Lắng nghe sự kiện KeyPress để nhận dữ liệu từ máy quét
   
        private void FrmBinLineQCApproval_Load(object sender, EventArgs e)
        {
            FillData();
            FillDataVerify();
        }

        private void GridBinLineQCApprovalView_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView gridView = sender as GridView;
            if (gridView != null && (e.Column.FieldName == "QRCodeData"))
            {
                // Lấy giá trị mới vừa nhập
                var newValue = e.Value;
                var rowIndex = e.RowHandle;
                var row = gridView.GetDataRow(rowIndex);

                // Cập nhật giá trị vào DataTable
                row[e.Column.FieldName] = newValue;

                // Lưu dữ liệu (gọi phương thức lưu)
                SaveData();
            }
        }

        private void GridBinLineQCApprovalView_MouseUp(object sender, MouseEventArgs e)
        {
            GridHitInfo hitInfo = gridBinLineQCApprovalView.CalcHitInfo(e.Location);
            if (hitInfo.InRowCell && hitInfo.Column.FieldName == "QCVerify")
            {
                gridBinLineQCApprovalView.CloseEditor();
                gridBinLineQCApprovalView.UpdateCurrentRow();
            }
        }

        private void SaveData()
        {
            try
            {
                // Kết thúc chỉnh sửa trên BindingSource để áp dụng thay đổi vào DataTable
                bdsQC.EndEdit();

                // Lưu DataTable về cơ sở dữ liệu
                prodStatisticDAO.UpdateBinQCApproval(dtQC);

                FillData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillData()
        {
            dtQC = prodStatisticDAO.GetBinQCApproval(Convert.ToDateTime(dtFromDate.EditValue), Convert.ToDateTime(dtToDate.EditValue));
            bdsQC.DataSource = dtQC;

            gridBinLineQCApproval.DataSource = bdsQC;
        }

        private void FillDataVerify()
        {
            dtQCVerify = prodStatisticDAO.GetBinQCApprovalVerify(Convert.ToDateTime(dtFromDate.EditValue), Convert.ToDateTime(dtToDate.EditValue));
            bdsQCVerify.DataSource = dtQCVerify;

            gridQC.DataSource = bdsQCVerify;
        }
    }
}
