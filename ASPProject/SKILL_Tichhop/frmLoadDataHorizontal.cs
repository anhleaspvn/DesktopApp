using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.Utils;
using DevExpress.Xpo.DB.Helpers;
using DevExpress.XtraCharts.Native;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace ASPProject.SkillMap
{
    public partial class frmLoadDataHorizontal : XtraForm
    {
        string constring = @"Data Source=14.241.201.7,1537;Initial Catalog=ASP;Persist Security Info=True;User ID=sa;Password=L@cH0ng#@!2026$;";
        private SqlDataAdapter DATA;
        private DataTable dt;
        public string UseNameLogin;

        public frmLoadDataHorizontal()
        {
            InitializeComponent();

            UseNameLogin = SessionMangerSkillMap.Username;

            Show_Data();
            update_Actual_Target();
            Tong_KyNangCanDaoTao(gridViewHorizontal);

            //Hàm set màu cho tiêu để cột
            SetColor_Horizontal();

            //điều chỉnh khoảng cách cột
            gridViewHorizontal.OptionsView.ColumnAutoWidth = false;


            //--1. định dạng tiêu đề lưới Grid LSX
            gridViewHorizontal.Appearance.HeaderPanel.Options.UseFont = true;
            //gridViewHorizontal.Appearance.HeaderPanel.Font = new Font("Tahoma", 8F, FontStyle.Bold);

            // 2. BẬT THANH TRƯỢT NGANG (H-Scroll)
            gridViewHorizontal.HorzScrollVisibility = ScrollVisibility.Auto;
          
            // 3.ẩn dòng tìm kiếm trên gridcontrol
            gridViewHorizontal.OptionsView.ShowGroupPanel = false;


            // 4.thêm dòng lọc trên lưới
            gridViewHorizontal.OptionsView.ShowAutoFilterRow = true;
            gridViewHorizontal.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;


            gridViewHorizontal.Columns["Actual Total"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            gridViewHorizontal.Columns["Target Total"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            gridViewHorizontal.Columns["Số Kỹ Năng Cần Đào Tạo"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            gridViewHorizontal.Columns["AutoID"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            
            // căn lề giữa cột trên lưới
            CenterAlignColumnData(gridViewHorizontal, "Số Kỹ Năng Cần Đào Tạo");

        }

        private void GridViewHorizontal_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            // throw new NotImplementedException();

            if (e.Column != null && e.Column.Caption.StartsWith("Target", StringComparison.OrdinalIgnoreCase))
            {
                e.Appearance.BackColor = System.Drawing.Color.Yellow;
                e.Appearance.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void frmLoadDataHorizontal_Load(object sender, EventArgs e)
        {
        }


        private void Display_TotalRecord(GridView GV)
        {
            GridColumn column = (GridColumn)GV.Columns["Tên"];
           // column.Width = 70;
            //column.BestFit();
            column.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            column.SummaryItem.DisplayFormat = "Total Record: {0}";

            GV.OptionsView.ShowFooter = true;
            GV.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
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



        private void update_Actual_Target()
        {
            for (int i = 0; i < gridViewHorizontal.RowCount; i++)
            {
                int Tong_Actual = TinhTongActual(gridViewHorizontal, i);
                gridViewHorizontal.SetRowCellValue(i, "Actual Total", Tong_Actual);
                int Tong_target = TinhTongTarget(gridViewHorizontal, i);
                gridViewHorizontal.SetRowCellValue(i, "Target Total", Tong_target);
            }
        }




        private int TinhTongTarget(GridView gridView, int rowHandle)
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
                        if (targetValue >= 75)
                            tong++;
                    }
                }
            }

            return tong;
        }




        private int TinhTongActual(GridView gridView, int rowHandle)
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
                        if (targetValue >= 75)
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





        private void Show_Data()
        {
            try
            {
                object KQ;
                string KQ_LineID;
                bool CHECK_ID = false;
              

                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();

                    CHECK_ID = (UseNameLogin == "WHA" || UseNameLogin == "WHB" || UseNameLogin == "WHC" || UseNameLogin == "WHD" || (UseNameLogin == "PILOT" || UseNameLogin == "USBB" || UseNameLogin == "USBC")); 

                    if (CHECK_ID == true ) // Username thuộc sản xuất
                    {
                        // Lấy ra  LineID từ EmpID đăng nhập
                        using (SqlCommand CMD1 = new SqlCommand("sp_ShowLineId", con))
                        {
                            CMD1.CommandType = CommandType.StoredProcedure;
                            CMD1.Parameters.AddWithValue("@EmpID", UseNameLogin);
                            KQ = CMD1.ExecuteScalar();
                        }


                        KQ_LineID = string.IsNullOrEmpty(KQ.ToString()) ? "" : KQ.ToString();


                        using (SqlCommand CMD = new SqlCommand("sp_ShowData_Horizontal_WorkerLine", con)) //sp_ShowData_Horizontal_TEST,sp_ShowData_Horizontal
                        {
                            CMD.CommandType = CommandType.StoredProcedure;
                            CMD.Parameters.AddWithValue("@LineID", KQ_LineID);

                            DATA = new SqlDataAdapter(CMD);
                            dt = new DataTable();
                            dt.Clear();
                            DATA.Fill(dt);

                            if (dt.Rows.Count <= 0)
                            {
                                gridControlHorizontal.DataSource = DBNull.Value;
                                gridControlHorizontal.RefreshDataSource();
                            }
                            else
                            {
                                gridControlHorizontal.DataSource = dt;

                                // tự động tạo lại các cột trên lưới
                                gridViewHorizontal.PopulateColumns();

                                // tự động chỉnh độ rộng cột của lưới
                                gridViewHorizontal.BestFitColumns();

                                // Tổng số Record trên lưới
                                Display_TotalRecord(gridViewHorizontal);

                            }
                        }

                        // Ẩn nút Excel khi User là LineSx
                        btnExportExcelHorizontal.Visible = false;
                    }
                    else // UserName KHÔNG thuộc BP.sản xuất
                    {
                        using (SqlCommand CMD = new SqlCommand("sp_ShowData_Horizontal", con)) //sp_ShowData_Horizontal_TEST,sp_ShowData_Horizontal
                        {
                            CMD.CommandType = CommandType.StoredProcedure;
                           // CMD.Parameters.AddWithValue("@LineID", KQ_LineID);

                            DATA = new SqlDataAdapter(CMD);
                            dt = new DataTable();
                            dt.Clear();
                            DATA.Fill(dt);

                            if (dt.Rows.Count <= 0)
                            {
                                gridControlHorizontal.DataSource = DBNull.Value;
                                gridControlHorizontal.RefreshDataSource();
                            }
                            else
                            {
                                gridControlHorizontal.DataSource = dt;

                                // tự động tạo lại các cột trên lưới
                                gridViewHorizontal.PopulateColumns();

                                // tự động chỉnh độ rộng cột của lưới
                                gridViewHorizontal.BestFitColumns();

                                // Tổng số Record trên lưới
                                Display_TotalRecord(gridViewHorizontal);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error Show Data : " + ex.Message, "Error Show Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportExcelHorizontal_Click(object sender, EventArgs e)
        {
            try
            {
                // kiểm tra lưới Gridview trước khi xuất Excel
                if (gridViewHorizontal.RowCount <= 0)
                {
                    XtraMessageBox.Show("No data Export Excel", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string downloadpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

                    string Filename = "Export_Horizontal_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";
                    string filepath = Path.Combine(downloadpath, Filename);

                    gridViewHorizontal.ExportToXlsx(filepath);

                    XtraMessageBox.Show("Export Excel Success", "Export Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Failed Export Excel : " + ex.Message, "Error Export Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //-------------------/Các hàm xây dựng thêm/--------------- 



        // HÀM SET MÀU HEADER CỘT SAU KHI HIỂN THỊ :
        private void SetColor_Horizontal()
        {
            var columns = gridViewHorizontal.VisibleColumns;

            // Lặp qua các mẫu tin
            for (int i = 0; i < gridViewHorizontal.RowCount; i++)
            {

                for (int j = 0; j < gridViewHorizontal.Columns.Count; j++)
                {
                    GridColumn col_Header = gridViewHorizontal.Columns[j];

                    if (col_Header.FieldName.StartsWith("Target", StringComparison.OrdinalIgnoreCase))
                    {
                        //lấy tên cột có tiền tố target
                       // string actualFieldName = col_Header.FieldName.Substring("Target ".Length).Trim();

                        // lấy giá trị cột target
                       // var value = gridViewHorizontal.GetRowCellValue(i, col_Header);


                        col_Header.AppearanceHeader.BackColor = System.Drawing.Color.Yellow;


                        // kiểm tra lấy vị trí index khác 0
                        //if (j > 0)
                        //{
                        //    GridColumn col_Previous = columns[j-1];

                        //    // lấy tên cột phí trước target
                        //    string Col_Previous_Name = col_Previous.FieldName;

                        //    //lấy giá trị của cột phía trước target
                        //    object Value_Previous = gridViewHorizontal.GetRowCellValue(i, Col_Previous_Name);


                        //    XtraMessageBox.Show($"Target : {actualFieldName}: và giá trị {value} /cột trước KN-{Col_Previous_Name} và giá trị {Value_Previous}");

                        //    int GT_Target = Convert.ToInt32(value);
                        //    int GT_KN = Convert.ToInt32(Value_Previous);


                        //    if (GT_KN < GT_Target)
                        //    {
                                
                        //    }

                        //}

                    }



                    // vòng lặp qua các cột trên Gridcontrol
                    //foreach (GridColumn col in gridViewHorizontal.Columns)
                    //{
                    //    // Chỉ xét các cột bắt đầu bằng TÊN "TARGET"
                    //    if (col.FieldName.StartsWith("Target", StringComparison.OrdinalIgnoreCase))
                    //    {
                    //        // lấy được giá trị tại cột 
                    //        var value = gridViewHorizontal.GetRowCellValue(i, col);

                    //        // 2. Xác định tên cột Thực tế (Actual) tương ứng
                    //        // Ví dụ: Target Dập => ActualFieldName = "Dập"
                    //        string actualFieldName = col.FieldName.Substring("Target ".Length).Trim();

                    //        // string knColumnName = col.FieldName.Substring//$"KN{i:D3}";

                    //        XtraMessageBox.Show($"Target : {actualFieldName}: {value}");
                    //    }

                    //}


                }

            }
        }
        

        private void gridViewHorizontal_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            var Gview = sender as GridView;

            //Danh sách Mapping
            var pairs = new Dictionary<string, string>()
            {
                { "KN001-Dập ter","Target Dập ter" },
                { "KN002-Kiểm ter","Target Kiểm ter" },
                { "KN003-Dập IDC","Target Dập IDC" },
                { "KN004-Kiểm IDC","Target Kiểm IDC" },
                { "KN005-Tuốt lõi","Target Tuốt lõi" },
                { "KN006-Kiểm lõi","Target Kiểm lõi" },
                { "KN007-Hàn","Target Hàn" },
                { "KN008-Kiểm Mối Hàn","Target Mối Hàn" },
                { "KN009-Ép Nhựa","Target Ép Nhựa" },
                { "KN010-Kiểm Nhựa","Target Kiểm Nhựa" },
                { "KN011-Xỏ HSG","Target Xỏ HSG" },
                { "KN012-Lắp Ráp","Target Lắp Ráp" },
                { "KN013-Kiểm Điện","Target Kiểm Điện" },
                { "KN014-Kiểm Hình Dáng","Target Kiểm Hình Dáng" }
            };


            // Kiểm tra nếu cell hiện tại là 1 trong các cột KNxxx
            if (pairs.ContainsKey(e.Column.FieldName))
            {
                string colKN = e.Column.FieldName;
                string ColTarget = pairs[colKN];


                int valueKN = 0;
                int valueTarget = 0;


                // lấy giá trị 2 cột
                object v1_KN = Gview.GetRowCellValue(e.RowHandle, colKN);
                object v2_Target = Gview.GetRowCellValue(e.RowHandle, ColTarget);


               // valueKN = Convert.ToInt32(v1_KN);
               // valueTarget = Convert.ToInt32(v2_Target);

                int.TryParse(Convert.ToString(v1_KN), out valueKN);
                int.TryParse(Convert.ToString(v2_Target), out valueTarget);

                // So sánh nếu Kỹ năng < target thì set màu
                if (valueKN < valueTarget)
                {
                    e.Appearance.BackColor = System.Drawing.Color.LightPink;
                }

               
            }

        }

        //private void BtnExit_Click(object sender, EventArgs e)
        //{
        //    Application.Exit();
        //}
    }
}
