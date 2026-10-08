using DevComponents.DotNetBar.Controls;
using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.Utils;
using DevExpress.Xpo.DB.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Filtering.Templates;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using static DevExpress.XtraEditors.Mask.MaskSettings;
using static System.Net.WebRequestMethods;
using ASPData;
using ASPData.ASPDAO;

namespace ASPProject.SkillMap
{
    public partial class frmLoadDataHorizontalKTV : XtraForm
    {
        private readonly ASPData.ASPData _aspData = new ASPData.ASPData();
        private readonly SkillMapDAO _skillMapDao = new SkillMapDAO();

        private string constring => _aspData.ASPDecrypt(configDatabase.CONNECTION_STRINGS);
        private SqlDataAdapter DATA;
        private DataTable dt;



        public frmLoadDataHorizontalKTV()
        {
            InitializeComponent();

     
            Show_Data();
            update_Actual_Target();
            Tong_KyNangCanDaoTao(gridViewHorizontalKTV);


            //điều chỉnh khoảng cách cột
            gridViewHorizontalKTV.OptionsView.ColumnAutoWidth = false;

            // Wrap tiêu đề cột cho bảng hiển thị Kỹ thuật viên
            gridViewHorizontalKTV.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            gridViewHorizontalKTV.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;



            //--1. định dạng tiêu đề lưới Grid LSX
            gridViewHorizontalKTV.Appearance.HeaderPanel.Options.UseFont = true;
            //gridViewHorizontal.Appearance.HeaderPanel.Font = new Font("Tahoma", 8F, FontStyle.Bold);

            // 2. BẬT THANH TRƯỢT NGANG (H-Scroll)
            gridViewHorizontalKTV.HorzScrollVisibility = ScrollVisibility.Auto;

            // 3.ẩn dòng tìm kiếm trên gridcontrol
            gridViewHorizontalKTV.OptionsView.ShowGroupPanel = false;


            // 4.thêm dòng lọc trên lưới
            gridViewHorizontalKTV.OptionsView.ShowAutoFilterRow = true;
            gridViewHorizontalKTV.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;


            if (gridViewHorizontalKTV.Columns["Actual Total"] != null)
                gridViewHorizontalKTV.Columns["Actual Total"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            if (gridViewHorizontalKTV.Columns["Target Total"] != null)
                gridViewHorizontalKTV.Columns["Target Total"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            if (gridViewHorizontalKTV.Columns["Số Kỹ Năng Cần Đào Tạo"] != null)
                gridViewHorizontalKTV.Columns["Số Kỹ Năng Cần Đào Tạo"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            if (gridViewHorizontalKTV.Columns["AutoID"] != null)
                gridViewHorizontalKTV.Columns["AutoID"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;


            // căn lề giữa cột trên lưới
            CenterAlignColumnData(gridViewHorizontalKTV, "Số Kỹ Năng Cần Đào Tạo");

            btnExportExcel.Click += BtnExportExcel_Click;
        }

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
           try
            {
                // kiểm tra lưới Gridview trước khi xuất Excel
                if (gridViewHorizontalKTV.RowCount <= 0)
                {
                    XtraMessageBox.Show("No data Export Excel", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string downloadpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

                    string Filename = "Export_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";
                    string filepath = Path.Combine(downloadpath, Filename);

                    gridControlHorizontalKTV.ExportToXlsx(filepath);

                    XtraMessageBox.Show("Export Excel Success", "Export Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Failed Export Excel : " + ex.Message, "Error Export Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Show_Data()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();

                    using (SqlCommand CMD = new SqlCommand("sp_ShowData_Horizontal_KTV", con))
                    {
                        CMD.CommandType = CommandType.StoredProcedure;
                        DATA = new SqlDataAdapter(CMD);
                        dt = new DataTable();
                        dt.Clear();
                        DATA.Fill(dt);

                        if (dt.Rows.Count <= 0)
                        {
                            gridControlHorizontalKTV.DataSource = DBNull.Value;
                            gridControlHorizontalKTV.RefreshDataSource();
                        }
                        else
                        {
                            gridControlHorizontalKTV.DataSource = dt;


                            gridViewHorizontalKTV.Columns["Tên"].Width = 150;   // đặt chiều rộng tùy ý 
                            gridViewHorizontalKTV.Columns["Số Kỹ Năng Cần Đào Tạo"].Width = 110;


                            // tự động tạo lại các cột trên lưới
                            // gridViewHorizontalKTV.PopulateColumns();

                            // tự động chỉnh độ rộng cột của lưới
                            // gridViewHorizontalKTV.BestFitColumns();

                            // Tổng số Record trên lưới
                            //  Display_TotalRecord(gridViewHorizontal);


                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error Show Data : " + ex.Message, "Error Show Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }









        private void frmLoadDataHorizontalKTV_Load(object sender, EventArgs e)
        {
        }




        private void update_Actual_Target()
        {
            for (int i = 0; i < gridViewHorizontalKTV.RowCount; i++)
            {
                int Tong_Actual = TinhTongActual_KTV(gridViewHorizontalKTV, i);
                gridViewHorizontalKTV.SetRowCellValue(i, "Actual Total", Tong_Actual);
                int Tong_target = TinhTongTarget_KTV(gridViewHorizontalKTV, i);
                gridViewHorizontalKTV.SetRowCellValue(i, "Target Total", Tong_target);
            }
        }




        private int TinhTongTarget_KTV(GridView gridView, int rowHandle)
        {
            int tong = 0;

            foreach (GridColumn col in gridView.Columns)
            {
                // Chỉ xét các cột bắt đầu bằng TÊN "TARGET"
                if (col.FieldName.StartsWith("Target", StringComparison.OrdinalIgnoreCase))
                {
                    var value = gridView.GetRowCellValue(rowHandle, col);

                    if (value != null && double.TryParse(value.ToString(), out double targetValue))
                    {
                        if (targetValue == 100)
                            tong++;
                    }
                }
            }

            return tong;
        }








        private int TinhTongActual_KTV(GridView gridView, int rowHandle)
        {
            int tong = 0;

            foreach (GridColumn col in gridView.Columns)
            {
                // Chỉ xét các cột bắt đầu bằng "KN"
                if (col.FieldName.StartsWith("KN", StringComparison.OrdinalIgnoreCase))
                {
                    var value = gridView.GetRowCellValue(rowHandle, col);

                    if (value != null && double.TryParse(value.ToString(), out double targetValue))
                    {
                        if (targetValue == 100)
                            tong++;
                    }
                }
            }

            return tong;
        }



        private void Tong_KyNangCanDaoTao(GridView Gv1)
        {
            for (int i = 0; i < Gv1.RowCount; i++)
            {
                decimal TONG_ALL_KYNANG = 0;
                object val_target = Gv1.GetRowCellValue(i, "Target Total");
                object val_KN = Gv1.GetRowCellValue(i, "Actual Total");

                decimal Tong_target = val_target == null ? 0 : Convert.ToDecimal(val_target);
                decimal Tong_Kynang = val_KN == null ? 0 : Convert.ToDecimal(val_KN);
                TONG_ALL_KYNANG = Tong_target - Tong_Kynang;

                Gv1.SetRowCellValue(i, "Số Kỹ Năng Cần Đào Tạo", TONG_ALL_KYNANG);
            }
        }



        // căn lề giữa dòng 
        public void CenterAlignColumnData(GridView gridView, string columnName)
        {
            GridColumn targetColumn = gridView.Columns[columnName];

            if (targetColumn != null)
            {
                targetColumn.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;

                // sử dụng tùy chỉnh font/căn lề
                targetColumn.AppearanceCell.Options.UseTextOptions = true;

                targetColumn.AppearanceCell.Font = new Font("Tahoma", 8F, FontStyle.Bold);
            }
        }




    }
}
