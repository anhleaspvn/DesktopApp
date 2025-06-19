﻿using ASPData.ASPDAO;
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
        ProdStatisticDAO prodStatisticDAO = new ProdStatisticDAO();
        ProdStatisticDTO prodStatisticDTO = new ProdStatisticDTO();
        int currentRowHandle = 0;
        bool isScanning = false;
        //System.Windows.Forms.TextBox hiddenTextBox;
        public frmBinLineQCApproval()
        {
            InitializeComponent();

            this.Load += FrmBinLineQCApproval_Load;
           
            this.gridBinLineQCApprovalView.CellValueChanging += GridBinLineQCApprovalView_CellValueChanging;
            this.gridBinLineQCApprovalView.MouseUp += GridBinLineQCApprovalView_MouseUp;
            this.gridBinLineQCApprovalView.RowCellClick += GridBinLineQCApprovalView_RowCellClick;
            this.gridBinLineQCApprovalView.RowClick += GridBinLineQCApprovalView_RowClick;

            this.txtQRContent.KeyDown += TxtQRContent_KeyDown;
            this.txtQRQuantity.KeyDown += TxtQRQuantity_KeyDown;
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

        private void TxtQRQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string scanResult = txtQRQuantity.Text.Trim().Replace("pcs", string.Empty);
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
            }
        }

        // Lắng nghe sự kiện KeyPress để nhận dữ liệu từ máy quét
   
        private void FrmBinLineQCApproval_Load(object sender, EventArgs e)
        {
            FillData();
           
            //gridBinLineQCApprovalView.OptionsBehavior.Editable = true;
           
            //foreach (GridColumn dc in gridBinLineQCApprovalView.Columns)
            //{
            //    if (dc.FieldName.ToUpper() != "QRCODEDATA")
            //        dc.OptionsColumn.ReadOnly = true;
            //}
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

                // Thông báo lưu thành công (tùy chọn)
                //MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillData()
        {
            dtQC = prodStatisticDAO.GetBinQCApproval();
            bdsQC.DataSource = dtQC;

            gridBinLineQCApproval.DataSource = bdsQC;
        }
    }
}
