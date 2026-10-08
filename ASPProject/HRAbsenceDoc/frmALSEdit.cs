using ASPData;
using ASPData.ASPDAO;
using ASPData.ASPDTO;
using ASPProject.AlternatingLeaveSchedule;
using ASPProject.ASPAlternatingLevelSchedule;
using DevExpress.ClipboardSource.SpreadsheetML;
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
using DevExpress.XtraSpellChecker.Parser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASPProject.HRAbsenceDoc
{
    public partial class frmALSEdit : XtraForm
    {
        private readonly string constring;

        DataTable DT_MANV = new DataTable();
        private readonly SQLHelper _sqlHelper = new SQLHelper();
        private RepositoryItemComboBox _riComboDayOff;





        public frmALSEdit()
        {
            InitializeComponent();
            constring = _sqlHelper.GetConnectionString();


            // ẩn dòng tìm kiếm trên gridcontrol
            gridViewUpdate.OptionsView.ShowGroupPanel = false;
            
            //Khoá thanh Bar 
            Lock_Barmanager();

            FormatDateTime();

            Lock_EditDateTime();

            LOAD_MANV();

            //ẨN CONTROL
            barEditTextID.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }


        private void LOAD_MANV()
        {
            DT_MANV = _sqlHelper.ExecQueryDataAsDataTable("SELECT Ma_CbNv,Ten_CbNv FROM L81DMCBNVASP WHERE Ma_Bp in (1100,1200,1300,1404,1500,1501,1701,1702,1703,1704,1800,1900)");

            repositoryItemLookUpEditMANV.DataSource = DT_MANV;
            repositoryItemLookUpEditMANV.DisplayMember = "Ma_CbNv";
            repositoryItemLookUpEditMANV.ValueMember = "Ma_CbNv";

            repositoryItemLookUpEditMANV.Columns.Clear();
            repositoryItemLookUpEditMANV.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_CbNv", "Mã nhân viên", 100));
            repositoryItemLookUpEditMANV.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_CbNv", "Tên nhân viên", 200));

            repositoryItemLookUpEditMANV.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            repositoryItemLookUpEditMANV.NullText = "-- Chọn Mã Nhân Viên --";
        }

        private void Lock_EditDateTime()
        {
            RepositoryItemDateEdit dateEdit = barEditChonDate.Edit as RepositoryItemDateEdit;

            DateTime Maxdate = new DateTime(
                DateTime.Now.Year,
                DateTime.Now.Month,
                DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)
                );

            dateEdit.MaxValue = Maxdate;

            // Format hiển thị
            dateEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            dateEdit.DisplayFormat.FormatString = "dd/MM/yyyy";

            dateEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            dateEdit.EditFormat.FormatString = "dd/MM/yyyy";
        }



        private void Lock_Barmanager()
        {
            bar1.OptionsBar.AllowQuickCustomization = false;

            bar1.OptionsBar.AllowQuickCustomization = false;
            bar1.OptionsBar.AllowCollapse = false;
            bar1.OptionsBar.AllowDelete = false;
            bar1.OptionsBar.DrawDragBorder = false;
            bar1.OptionsBar.UseWholeRow = true;
        }


        private void FormatDateTime()
        {
            RepositoryItemDateEdit repDateEdit = new RepositoryItemDateEdit();

            // 1. Thiết lập Định dạng hiển thị (DISPLAY FORMAT)

            repDateEdit.DisplayFormat.FormatString = "dd/MM/yyyy";
            repDateEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;

            // 2. Thiết lập Định dạng chỉnh sửa (EDIT FORMAT)

            repDateEdit.EditFormat.FormatString = "dd/MM/yyyy";
            repDateEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;

            // 3. Thiết lập Mask 

            repDateEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            repDateEdit.Mask.EditMask = "dd/MM/yyyy";

            barEditChonDate.Edit = repDateEdit;

            // 5. Đặt giá trị ban đầu (tùy chọn)
            barEditChonDate.EditValue = DateTime.Now;
        }



        // hàm lấy ra thứ 7 đầu tiên trong tháng
        private List<DateTime> GetFirst_saturday(int year, int month, int N)
        {
            var List_T7_off = new List<DateTime>(N);
            var first = new DateTime(year, month, 1);
            int daytosat = ((int)DayOfWeek.Saturday - (int)first.DayOfWeek + 7) % 7;
            DateTime First_sat = first.AddDays(daytosat);

            for (int i = 0; i < N; i++)
            {
                List_T7_off.Add(First_sat.AddDays(7 * i));
            }

            return List_T7_off;
        }

        private void Update_caption_Dayoff(GridView GV1, int year, int month)
        {
            int satCount = Count_Saturday_InMonth(year, month);
            var soTuan = GetFirst_saturday(year, month, satCount);

            for (int i = 0; i < satCount; i++)
            {
                string filename = $"DayOff{i + 1}";
                var col = GV1.Columns.ColumnByFieldName(filename);
                if (col != null)
                {
                    col.Caption = soTuan[i].ToString("dd/MM", CultureInfo.InvariantCulture);
                }
            }

            GV1.RefreshData();
        }



        private void frmALSEdit_Load(object sender, EventArgs e)
        {
        }


        // hàm trả về số ngày thứ 7 trong tháng (tối ưu O(1))
        public int Count_Saturday_InMonth(int year, int month)
        {
            DateTime first = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);
            int offset = ((int)DayOfWeek.Saturday - (int)first.DayOfWeek + 7) % 7;
            return offset >= daysInMonth ? 0 : 1 + (daysInMonth - 1 - offset) / 7;
        }



        private void repair_Column_name()
        {
            string KT_Cot = "DayOff5";

            GridColumn EmpID = gridViewUpdate.Columns["EmpID"];
            GridColumn EmpName = gridViewUpdate.Columns["EmpName"];
            GridColumn Ten_Bp = gridViewUpdate.Columns["Ten_Bp"];
            GridColumn Ten_ChucVu = gridViewUpdate.Columns["Ten_Cv"];
            GridColumn DayOff1 = gridViewUpdate.Columns["DayOff1"];
            GridColumn DayOff2 = gridViewUpdate.Columns["DayOff2"];
            GridColumn DayOff3 = gridViewUpdate.Columns["DayOff3"];
            GridColumn DayOff4 = gridViewUpdate.Columns["DayOff4"];

            GridColumn Note = gridViewUpdate.Columns["Note"];
            GridColumn FilterMonth = gridViewUpdate.Columns["FilterMonth"];


            if (EmpID != null)
            {
                EmpID.Caption = "Mã Nhân Viên";
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
                DayOff1.Caption = "Tuần 1(T7)";
            }
            if (DayOff2 != null)
            {
                DayOff2.Caption = "Tuần 2(T7)";
            }
            if (DayOff3 != null)
            {
                DayOff3.Caption = "Tuần 3(T7)";
            }
            if (DayOff4 != null)
            {
                DayOff4.Caption = "Tuần 4(T7)";
            }
            if (check_column_Grid(gridViewUpdate, KT_Cot))
            {
                GridColumn DayOff5 = gridViewUpdate.Columns["DayOff5"];
                if (DayOff5 != null)
                {
                    DayOff5.Caption = "Tuần 5(T7)";
                }
            }

            if (Note != null)
            {
                Note.Caption = "Ghi chú";
            }
            if (FilterMonth != null)
            {
                FilterMonth.Caption = "Tháng Đăng ký";
            }
        }



        private bool check_column_Grid(GridView GV, string filenames)
        {
            if (GV == null || GV.Columns == null)
            {
                return false;
            }

            GridColumn Column_check = GV.Columns[filenames];

            return Column_check != null;
        }


        private void format_Gridcontrol()
        {
            // BẬT THANH TRƯỢT NGANG TRÊN LƯỚI
            gridViewUpdate.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;

            // ẩn dòng tìm kiếm trên gridcontrol
            gridViewUpdate.OptionsView.ShowGroupPanel = false;

            //--1. định dạng tiêu đề lưới Grid LSX
            gridViewUpdate.Appearance.HeaderPanel.Options.UseFont = true;
            gridViewUpdate.Appearance.HeaderPanel.Font = new Font("Tahoma", 10F, FontStyle.Bold);

            // Căn giữa tiêu đề
            gridViewUpdate.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;


            GridColumn STT = gridViewUpdate.Columns["STT"];
            if (STT != null)
                STT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            gridViewUpdate.BestFitColumns();
        }





        private void barButtonTimKiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SqlDataAdapter DATA;
            DataTable DT;
            DateTime? DateDay = barEditChonDate.EditValue as DateTime?;
            int DateMonth = 0;
            int DateYear = 0;
            string ID = barEditItemLookupMANV.EditValue?.ToString();//barEditTextID.EditValue?.ToString();

            if (DateDay == null)
            {
                return;
            }

            DateMonth = DateDay.Value.Month;
            DateYear = DateDay.Value.Year;


            if (ID == null)
            {
                XtraMessageBox.Show("Vui lòng nhập ID", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    using (SqlConnection CON = new SqlConnection(constring)) 
                    {
                        CON.Open();

                        using (SqlCommand CMD = new SqlCommand("sp_ASPAlternate_Partcode_User", CON))
                        {
                            CMD.CommandType = CommandType.StoredProcedure;
                            CMD.Parameters.AddWithValue("@EmpID", barEditItemLookupMANV.EditValue.ToString().Trim());//barEditTextID.EditValue.ToString().Trim());
                            CMD.Parameters.AddWithValue("@THOIGIAN", DateDay.Value.Date);
                            DATA = new SqlDataAdapter(CMD);
                            DT = new DataTable();
                            DATA.Fill(DT);



                            if (DT.Rows.Count > 0)
                            {
                                gridControlUpdate.DataSource = DT;

                                // Thêm Combobox lựa chọn (tái sử dụng nếu đã tạo)
                                if (_riComboDayOff == null)
                                {
                                    _riComboDayOff = new RepositoryItemComboBox();
                                    _riComboDayOff.Items.AddRange(new string[] { "Đi làm", "WFH", "OFF" });
                                    gridControlUpdate.RepositoryItems.Add(_riComboDayOff);
                                }

                                gridViewUpdate.Columns["DayOff1"].ColumnEdit = _riComboDayOff;
                                gridViewUpdate.Columns["DayOff2"].ColumnEdit = _riComboDayOff;
                                gridViewUpdate.Columns["DayOff3"].ColumnEdit = _riComboDayOff;
                                gridViewUpdate.Columns["DayOff4"].ColumnEdit = _riComboDayOff;
                                gridViewUpdate.Columns["DayOff5"].ColumnEdit = _riComboDayOff;

                                // Sắp xếp thứ tự cột và ẩn/hiện cột DayOff5 theo đúng thứ tự ngày
                                bool has5Saturdays = Count_Saturday_InMonth(DateYear, DateMonth) == 5;
                                SetGridColumnsOrder(gridViewUpdate, has5Saturdays);

                                //Thay đổi tên cột hiển thị
                                repair_Column_name();

                                format_Gridcontrol();

                                FormatDateColumn(gridViewUpdate);
                             
                                // Format tên cột các ngày thứ 7
                                Update_caption_Dayoff(gridViewUpdate, DateYear, DateMonth);
                            }
                            else
                            {
                                XtraMessageBox.Show("Chưa tìm thấy thông tin", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Lỗi Show Data : " + ex.Message);
                }
            }


        }


        private void barButtonSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridView Gview = (GridView)gridControlUpdate.MainView;

            string primarykey = barEditItemLookupMANV.EditValue?.ToString();
            DateTime? DateDay = barEditChonDate.EditValue as DateTime?;

            if (DateDay == null)
            {
                return;
            }

            int DateMonth = DateDay.Value.Month;
            int DateYear = DateDay.Value.Year;
            DateTime DateDayAll = DateDay.Value;

            //Update lại Grid
            Gview.CloseEditor();
            Gview.UpdateCurrentRow();

            int Focusrowhandle = Gview.FocusedRowHandle;

            // đã chọn
            if (Focusrowhandle >= 0)
            {
                string empId = Convert.ToString(Gview.GetRowCellValue(Focusrowhandle, "EmpID"));
                string empName = Convert.ToString(Gview.GetRowCellValue(Focusrowhandle, "EmpName"));
                object tenBp = Gview.GetRowCellValue(Focusrowhandle, "Ten_Bp");
                object tenCv = Gview.GetRowCellValue(Focusrowhandle, "Ten_Cv");

                string dayOff1Val = Convert.ToString(Gview.GetRowCellValue(Focusrowhandle, "DayOff1"));
                string dayOff1 = string.IsNullOrWhiteSpace(dayOff1Val) ? "OFF" : dayOff1Val;

                string dayOff2Val = Convert.ToString(Gview.GetRowCellValue(Focusrowhandle, "DayOff2"));
                string dayOff2 = string.IsNullOrWhiteSpace(dayOff2Val) ? "OFF" : dayOff2Val;

                string dayOff3Val = Convert.ToString(Gview.GetRowCellValue(Focusrowhandle, "DayOff3"));
                string dayOff3 = string.IsNullOrWhiteSpace(dayOff3Val) ? "OFF" : dayOff3Val;

                string dayOff4Val = Convert.ToString(Gview.GetRowCellValue(Focusrowhandle, "DayOff4"));
                string dayOff4 = string.IsNullOrWhiteSpace(dayOff4Val) ? "OFF" : dayOff4Val;

                string dayOff5Val = Convert.ToString(Gview.GetRowCellValue(Focusrowhandle, "DayOff5"));
                string dayOff5 = string.IsNullOrWhiteSpace(dayOff5Val) ? "OFF" : dayOff5Val;

                object note = Gview.GetRowCellValue(Focusrowhandle, "Note");
                string filterMonth = DateDayAll.ToString("yyyy-MM-dd HH:mm:ss");
                string partCode = Convert.ToString(Gview.GetRowCellValue(Focusrowhandle, "PartCode"));
                string position = Convert.ToString(Gview.GetRowCellValue(Focusrowhandle, "Position"));
                object levelCv = Gview.GetRowCellValue(Focusrowhandle, "Level_CV");

                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();

                    // Kiểm tra Nhân viên đăng ký?
                    bool KT_ID = Check_EmpID_registered(con, primarykey, DateMonth, DateYear);

                    try
                    {
                        // NV đã đăng ký 
                        if (KT_ID)
                        {
                            using (SqlCommand cmd = new SqlCommand("sp_ASPAlternate_Update", con)) 
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.AddWithValue("@EmpID", primarykey);
                                cmd.Parameters.AddWithValue("@DayOff1", dayOff1);
                                cmd.Parameters.AddWithValue("@DayOff2", dayOff2);
                                cmd.Parameters.AddWithValue("@DayOff3", dayOff3);
                                cmd.Parameters.AddWithValue("@DayOff4", dayOff4);
                                cmd.Parameters.AddWithValue("@DayOff5", dayOff5);
                                cmd.Parameters.AddWithValue("@Note", note ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@FilterMonth", filterMonth);

                                cmd.ExecuteNonQuery();
                                XtraMessageBox.Show("Cập nhật dữ liệu thành công!");
                            }
                        }
                        else //NV chưa đăng ký
                        {
                            using (SqlCommand cmd = new SqlCommand("sp_ASPAlternate_Insert_Edit", con))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.AddWithValue("@EmpID", primarykey);
                                cmd.Parameters.AddWithValue("@EmpName", empName);
                                cmd.Parameters.AddWithValue("@Ten_Bp", tenBp ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@Ten_Cv", tenCv ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@DayOff1", dayOff1);
                                cmd.Parameters.AddWithValue("@DayOff2", dayOff2);
                                cmd.Parameters.AddWithValue("@DayOff3", dayOff3);
                                cmd.Parameters.AddWithValue("@DayOff4", dayOff4);
                                cmd.Parameters.AddWithValue("@DayOff5", dayOff5);
                                cmd.Parameters.AddWithValue("@Note", note ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@FilterMonth", filterMonth);
                                cmd.Parameters.AddWithValue("@PartCode", partCode);
                                cmd.Parameters.AddWithValue("@Position", position);
                                cmd.Parameters.AddWithValue("@Level_CV", levelCv ?? DBNull.Value);

                                cmd.ExecuteNonQuery();
                                XtraMessageBox.Show("Đăng ký lịch nghỉ thành công");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Error : " + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }




        //kiểm tra NV Có/chưa đăng ký lịch 
        private bool Check_EmpID_registered(SqlConnection con1, string EmpID, int Month, int Year)
        {
            bool KQ = false;
            using (SqlCommand cmd = new SqlCommand("sp_ASPCheck_EmpID_Registered", con1))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpID", EmpID);
                cmd.Parameters.AddWithValue("@MONTH", Month);
                cmd.Parameters.AddWithValue("@YEAR", Year);

                object CHECK_SO = cmd.ExecuteScalar();

                if (Convert.ToInt32(CHECK_SO) > 0)
                {
                    KQ = true;
                }
            }

            return KQ;
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




    }


}
