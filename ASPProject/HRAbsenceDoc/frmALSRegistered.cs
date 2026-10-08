using ASPData;
using ASPData.ASPDTO;
using ASPProject.AlternatingLeaveSchedule;
using ASPProject.ASPAlternatingLevelSchedule;
using DevExpress.Utils.VisualEffects;
using DevExpress.Xpo.DB;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Design;
using DevExpress.XtraCharts.Native;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ASPProject.AlternatingLeaveSchedule
{
    public partial class frmALSRegistered : XtraForm
    {
        private readonly SQLHelper _sqlHelper = new SQLHelper();
        private readonly string constring;

        private string ID;

        public frmALSRegistered()
        {
            InitializeComponent();
            constring = _sqlHelper.GetConnectionString();

            // Cấu hình giao diện lưới trực quan, hiện đại
            gridView_Registered.OptionsBehavior.Editable = false;
            gridView_Registered.OptionsBehavior.ReadOnly = true;
            gridView_Registered.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView_Registered.OptionsView.EnableAppearanceEvenRow = true;
            gridView_Registered.Appearance.EvenRow.BackColor = Color.FromArgb(246, 249, 254);

            gridView_Registered.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            // Hiển thị số thứ tự dòng trên cột indicator
            gridView_Registered.OptionsView.ShowIndicator = true;
            gridView_Registered.IndicatorWidth = 45;
            gridView_Registered.CustomDrawRowIndicator += gridView_Registered_CustomDrawRowIndicator;

            // Thêm dòng lọc trên lưới
            gridView_Registered.OptionsView.ShowAutoFilterRow = true;

            // Ẩn dòng nhóm trên tiêu đề gridcontrol
            gridView_Registered.OptionsView.ShowGroupPanel = false;

            // Set thời gian chọn tháng năm để lọc
            Set_Fromdate_Filter();
            ID = SessionManagerALS.Username;
            btnExcel.Visible = false;

            this.Load += frmALSRegistered_Load;
        }

        private void frmALSRegistered_Load(object sender, EventArgs e)
        {
            // Tự động tải dữ liệu tháng hiện tại khi mở form
            LoadData(true);
        }

        private void gridView_Registered_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Check_Admin(string ID)
        {
            if(gridView_Registered.RowCount > 0)
            {
                if (ID == "ASP1648")
                {
                    btnExcel.Visible = true;
                }
                else
                {
                    btnExcel.Visible = false;
                }
            }    
        }




        private void Set_Fromdate_Filter()
        {
            DateTime to_day = DateTime.Today;

            dateEditFilter.DateTime = to_day;

            dateEditFilter.Properties.DisplayFormat.FormatString = "MM/yyyy";
            dateEditFilter.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;

            dateEditFilter.Properties.EditFormat.FormatString = "MM/yyyy";
            dateEditFilter.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;

            // Bắt sự kiện để chọn tháng/năm dễ dàng trực quan
            dateEditFilter.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
            dateEditFilter.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            dateEditFilter.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView;

            dateEditFilter.Properties.Mask.EditMask = "MM/yyyy";
            dateEditFilter.Properties.Mask.UseMaskAsDisplayFormat = true;
        }



        private void repair_Column_name()
        {
            string KT_Cot = "DayOff5";

            GridColumn EmpID = gridView_Registered.Columns["EmpID"];
            GridColumn EmpName = gridView_Registered.Columns["EmpName"];
            GridColumn Ten_Bp = gridView_Registered.Columns["Ten_Bp"];
            GridColumn Ten_ChucVu = gridView_Registered.Columns["Ten_Cv"];
            GridColumn DayOff1 = gridView_Registered.Columns["DayOff1"];
            GridColumn DayOff2 = gridView_Registered.Columns["DayOff2"];
            GridColumn DayOff3 = gridView_Registered.Columns["DayOff3"];
            GridColumn DayOff4 = gridView_Registered.Columns["DayOff4"];

            GridColumn Note = gridView_Registered.Columns["Note"];
            GridColumn FilterMonth = gridView_Registered.Columns["FilterMonth"];


            if (EmpID != null)
            {
                EmpID.Caption = "Mã Nhân Viên";
                EmpID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
            if (EmpName != null)
            {
                EmpName.Caption = "Họ và Tên";
            }
            if (Ten_Bp != null)
            {
                Ten_Bp.Caption = "Bộ Phận";
            }
            if (Ten_ChucVu != null)
            {
                Ten_ChucVu.Caption = "Chức Vụ";
            }
            if (DayOff1 != null)
            {
                DayOff1.Caption = "Tuần 1 (T7)";
                DayOff1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
            if (DayOff2 != null)
            {
                DayOff2.Caption = "Tuần 2 (T7)";
                DayOff2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
            if (DayOff3 != null)
            {
                DayOff3.Caption = "Tuần 3 (T7)";
                DayOff3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
            if (DayOff4 != null)
            {
                DayOff4.Caption = "Tuần 4 (T7)";
                DayOff4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
            if (check_column_Grid(gridView_Registered, KT_Cot))
            {
                GridColumn DayOff5 = gridView_Registered.Columns["DayOff5"];
                if (DayOff5 != null)
                {
                    DayOff5.Caption = "Tuần 5 (T7)";
                    DayOff5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                }
            }

            if (Note != null)
            {
                Note.Caption = "Ghi chú";
            }
            if (FilterMonth != null)
            {
                FilterMonth.Caption = "Tháng Đăng Ký";
                FilterMonth.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
        }


        private bool check_column_Grid(GridView GV, string filenames)
        {
            if (GV == null || GV.Columns == null)
            {
                return false;
            }

            GridColumn Column_check = GV.Columns[filenames];

            // Nếu column khác null, tức là cột tồn tại.
            return Column_check != null;
        }



        // hàm trả về số ngày thứ 7 trong tháng (tối ưu O(1))
        public int Count_Saturday_InMonth(int year, int month)
        {
            DateTime first = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);
            int offset = ((int)DayOfWeek.Saturday - (int)first.DayOfWeek + 7) % 7;
            return offset >= daysInMonth ? 0 : 1 + (daysInMonth - 1 - offset) / 7;
        }

        private void btnLoc_Thang_Nam_Click(object sender, EventArgs e)
        {
            LoadData(false);
        }

        private void LoadData(bool isInitialLoad = false)
        {
            SqlDataAdapter DATA = new SqlDataAdapter();
            DataTable DT = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_ASPFilter_Month", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Month", dateEditFilter.DateTime.Month);
                        cmd.Parameters.AddWithValue("@Year", dateEditFilter.DateTime.Year);
                        DATA = new SqlDataAdapter(cmd);
                        DATA.Fill(DT);

                        if (DT.Rows.Count > 0)
                        {
                            gridControl_Registered.DataSource = DT;

                            // Sắp xếp thứ tự cột và ẩn/hiện cột DayOff5 theo đúng thứ tự ngày
                            bool has5Saturdays = Count_Saturday_InMonth(dateEditFilter.DateTime.Year, dateEditFilter.DateTime.Month) == 5;
                            SetGridColumnsOrder(gridView_Registered, has5Saturdays);

                            FormatDateColumn(gridView_Registered);

                            repair_Column_name();

                            Check_Admin(ID);

                            gridView_Registered.BestFitColumns();
                        }
                        else
                        {
                            gridControl_Registered.DataSource = null;
                            if (!isInitialLoad)
                            {
                                XtraMessageBox.Show("Không tìm thấy thông tin đăng ký cho tháng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error : " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SetGridColumnsOrder(GridView gv, bool has5Saturdays)
        {
            if (gv == null) return;

            // Ẩn các cột nội bộ
            if (gv.Columns["PartCode"] != null) gv.Columns["PartCode"].Visible = false;
            if (gv.Columns["Position"] != null) gv.Columns["Position"].Visible = false;
            if (gv.Columns["Level_CV"] != null) gv.Columns["Level_CV"].Visible = false;

            int index = 0;
            if (gv.Columns["STT"] != null && gv.Columns["STT"].Visible)
                gv.Columns["STT"].VisibleIndex = index++;

            if (gv.Columns["EmpID"] != null) { gv.Columns["EmpID"].Visible = true; gv.Columns["EmpID"].VisibleIndex = index++; }
            if (gv.Columns["EmpName"] != null) { gv.Columns["EmpName"].Visible = true; gv.Columns["EmpName"].VisibleIndex = index++; }
            if (gv.Columns["Ten_Bp"] != null) { gv.Columns["Ten_Bp"].Visible = true; gv.Columns["Ten_Bp"].VisibleIndex = index++; }
            if (gv.Columns["Ten_Cv"] != null) { gv.Columns["Ten_Cv"].Visible = true; gv.Columns["Ten_Cv"].VisibleIndex = index++; }
            if (gv.Columns["DayOff1"] != null) { gv.Columns["DayOff1"].Visible = true; gv.Columns["DayOff1"].VisibleIndex = index++; }
            if (gv.Columns["DayOff2"] != null) { gv.Columns["DayOff2"].Visible = true; gv.Columns["DayOff2"].VisibleIndex = index++; }
            if (gv.Columns["DayOff3"] != null) { gv.Columns["DayOff3"].Visible = true; gv.Columns["DayOff3"].VisibleIndex = index++; }
            if (gv.Columns["DayOff4"] != null) { gv.Columns["DayOff4"].Visible = true; gv.Columns["DayOff4"].VisibleIndex = index++; }

            if (gv.Columns["DayOff5"] != null)
            {
                if (has5Saturdays)
                {
                    gv.Columns["DayOff5"].Visible = true;
                    gv.Columns["DayOff5"].VisibleIndex = index++;
                }
                else
                {
                    gv.Columns["DayOff5"].Visible = false;
                }
            }

            if (gv.Columns["Note"] != null) { gv.Columns["Note"].Visible = true; gv.Columns["Note"].VisibleIndex = index++; }
            if (gv.Columns["FilterMonth"] != null && gv.Columns["FilterMonth"].Visible) { gv.Columns["FilterMonth"].VisibleIndex = index++; }
            if (gv.Columns["EditAction"] != null) { gv.Columns["EditAction"].Visible = true; gv.Columns["EditAction"].VisibleIndex = index++; }
        }

        public void FormatDateColumn(GridView Gv)
        {
            const string NgayDangKy = "FilterMonth";

            if (Gv.Columns.ColumnByFieldName(NgayDangKy) != null)
            {
                GridColumn Col_FilterMonth = Gv.Columns[NgayDangKy];

                Col_FilterMonth.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;

                Col_FilterMonth.DisplayFormat.FormatString = "MM/yyyy";

                Col_FilterMonth.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
        }


        private void btnrefresh_Click(object sender, EventArgs e)
        {
            SqlDataAdapter DATA = new SqlDataAdapter();
            DataTable DT = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_ASPRELOAD", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        DATA = new SqlDataAdapter(cmd);
                        DATA.Fill(DT);

                        if (DT.Rows.Count > 0)
                        {
                            gridControl_Registered.DataSource = DT;

                            object tgianObj = gridView_Registered.GetRowCellValue(0, "FilterMonth");
                            bool has5Saturdays = true;
                            if (tgianObj != null && DateTime.TryParse(tgianObj.ToString(), out DateTime getTgian))
                            {
                                has5Saturdays = Count_Saturday_InMonth(getTgian.Year, getTgian.Month) == 5;
                            }

                            // Sắp xếp thứ tự cột và ẩn/hiện cột DayOff5 theo đúng thứ tự ngày
                            SetGridColumnsOrder(gridView_Registered, has5Saturdays);

                            FormatDateColumn(gridView_Registered);

                            repair_Column_name();

                            Check_Admin(ID);

                            gridView_Registered.BestFitColumns();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error : " + ex.Message);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView_Registered.RowCount <= 0)
                {
                    XtraMessageBox.Show("No data Export Excel", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string downloadpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

                    string Filename = "Export_LichNghi_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";
                    string filepath = Path.Combine(downloadpath, Filename);

                    gridView_Registered.ExportToXlsx(filepath);

                    XtraMessageBox.Show("Export Excel Success", "Export Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Failed Export Excel : " + ex.Message, "Error Export Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
