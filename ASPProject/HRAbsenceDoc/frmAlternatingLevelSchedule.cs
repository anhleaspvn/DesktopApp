using ASPData;
using ASPData.ASPDTO;
using ASPProject.AlternatingLeaveSchedule;
using ASPProject.ASPAlternatingLevelSchedule;
using ASPProject.HRAbsenceDoc;
using DevExpress.Pdf.Native;
using DevExpress.Utils.VisualEffects;
using DevExpress.Xpo.DB;
using DevExpress.XtraCharts;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;



namespace ASPProject.ASPAlternatingLevelSchedule
{
    public partial class frmAlternatingLevelSchedule : XtraForm
    {
        private readonly SQLHelper _sqlHelper = new SQLHelper();
        private readonly string constring;



        private RepositoryItemComboBox _riComboDayOff;

        public frmAlternatingLevelSchedule(string username)
        {
            InitializeComponent();
            constring = _sqlHelper.GetConnectionString();

            // Tự động lấp đầy toàn bộ diện tích tab cha
            this.Dock = System.Windows.Forms.DockStyle.Fill;

            DateTime TimeNow = DateTime.Today;
            DateTime Time_ToMonth = DateTime.Today.AddMonths(1);

            string FormatTime = (TimeNow.Day >= 25 ? TimeNow.AddMonths(1) : TimeNow).ToString("MM/yyyy");
            labelControlEnglish.Text += " " + FormatTime.ToString();
            labelControlViet.Text += " " + FormatTime.ToString();
            labelControlEnglish.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;

            //---- ẩn button ------
            btnExit.Visible = false;
            buttonEdit.Visible = true;

            SessionManagerALS.Username = username;
            //Check_Admin(username);

            LOAD_GRID();

            // thay đổi tên cột dayoff
            Update_caption_Dayoff(gridViewShowData, Time_ToMonth.Year, Time_ToMonth.Month);
            // định dạng Gridcontrol hiển thị
            format_Gridcontrol();

            // Bật tô màu dòng chẵn lẻ nhẹ nhàng, giữ nguyên font chữ gốc của GridView
            gridViewShowData.OptionsView.EnableAppearanceEvenRow = true;
            gridViewShowData.Appearance.EvenRow.BackColor = Color.FromArgb(246, 249, 254);
            gridViewShowData.OptionsSelection.EnableAppearanceFocusedCell = true;
            gridViewShowData.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            gridViewShowData.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;

            // thêm dòng lọc 
            gridViewShowData.OptionsView.ShowAutoFilterRow = true;
            gridViewShowData.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridViewShowData.RowCellStyle += GridViewShowData_RowCellStyle;
            gridViewShowData.ShowingEditor += GridViewShowData_ShowingEditor;
            gridViewShowData.ShownEditor += GridViewShowData_ShownEditor;
            gridViewShowData.CustomRowCellEdit += GridViewShowData_CustomRowCellEdit;

            //----- Mở(25 hàng tháng) - khoá(hết ngày 2) 
            UpdateGridEditableState();
        }



        private bool CheckIsAdmin(string ID)
        {
            if (string.IsNullOrEmpty(ID)) return false;
            string cleanId = ID.Trim().ToUpper();
            return cleanId == "ASP1648" || cleanId == "ASP2222" || cleanId == "ASP1733" || cleanId == "ASP0061" || cleanId == "ASP1701";
        }

        private void Check_Admin(string ID)
        {
            if (CheckIsAdmin(ID))
            {
                buttonEdit.Visible = true;
            }
            else
            {
                buttonEdit.Visible = false;
            } 
        }



        private void GridViewShowData_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView GV_KT = sender as GridView;
            if (GV_KT == null) return;

            // Cho phép tìm kiếm trên dòng lọc (AutoFilterRow)
            if (GV_KT.IsFilterRow(GV_KT.FocusedRowHandle)) return;

            string colName = GV_KT.FocusedColumn?.FieldName ?? "";

            // Các cột thông tin nhân viên không cho phép chỉnh sửa
            if (colName == "STT" || colName == "EmpID" || colName == "EmpName" || colName == "Ten_Bp" || colName == "Ten_Cv" || colName == "FilterMonth")
            {
                e.Cancel = true;
                return;
            }

            string Username = SessionManagerALS.Username ?? "";

            // Nếu đang chạy không có login (môi trường test) hoặc là Admin / Trưởng phòng: cho phép sửa All dòng
            if (string.IsNullOrEmpty(Username) || CheckIsAdmin(Username) || check_ChucVu(Username) == 2)
            {
                e.Cancel = false;
                return;
            }

            string MANV_DN = GV_KT.GetRowCellValue(GV_KT.FocusedRowHandle, "EmpID")?.ToString()?.Trim() ?? "";

            // Nhân viên thường chỉ được sửa dòng của chính mình (so sánh Trim không phân biệt hoa thường)
            if (!string.Equals(MANV_DN, Username.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                e.Cancel = true; // khoá các dòng khác
            }
        }

        // Tự động bung popup dropdown ngay lập tức khi click vào ô
        private void GridViewShowData_ShownEditor(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;

            if (view.ActiveEditor is ComboBoxEdit combo)
            {
                combo.ShowPopup();
            }
        }

        // Đảm bảo DevExpress luôn luôn gán RepositoryItemComboBox cho tất cả các ô DayOff
        private void GridViewShowData_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column != null && e.Column.FieldName.StartsWith("DayOff"))
            {
                if (_riComboDayOff == null)
                {
                    _riComboDayOff = new RepositoryItemComboBox();
                    _riComboDayOff.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                    _riComboDayOff.Items.AddRange(new object[] { "Đi làm", "WFH", "OFF" });
                    gridControlShowData.RepositoryItems.Add(_riComboDayOff);
                }
                e.RepositoryItem = _riComboDayOff;
            }
        }


        private void GridViewShowData_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName.StartsWith("DayOff") && e.CellValue != null)
            {
                string status = e.CellValue.ToString().Trim().ToUpper();

                switch (status)
                {
                    case "ĐI LÀM":
                        e.Appearance.BackColor = Color.LightGreen;
                        break;
                    case "OFF":
                        e.Appearance.BackColor = Color.LightPink;
                        break;
                    case "WFH":
                        e.Appearance.BackColor = Color.LightSkyBlue;
                        break;
                }
            }
        }

        private void frmAlternatingLevelSchedule_Load(object sender, EventArgs e)
        {
        }



        // hàm kiểm tra chức vụ nhân viên
        private int check_ChucVu(string Username)
        {
            object KQ_Level;
            int KQ = 0;

            using (SqlConnection CON = new SqlConnection(constring))
            {
                CON.Open();
                using (SqlCommand CMD = new SqlCommand("sp_ASP_Level_ChucVu", CON))
                {
                    CMD.CommandType = CommandType.StoredProcedure;
                    CMD.Parameters.AddWithValue("@Usename", Username);

                    KQ_Level = CMD.ExecuteScalar();

                    KQ = Convert.ToInt32(KQ_Level);
                }
            }
            return KQ;
        }


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
            DateTime timePreviousMonth = DateTime.Today; 
            int day = DateTime.Today.Day;

            int targetYear = (day == 1 || day == 2) ? timePreviousMonth.Year : year;
            int targetMonth = (day == 1 || day == 2) ? timePreviousMonth.Month : month;

            int satCount = Count_Saturday_InMonth(targetYear, targetMonth);
            var soTuan = GetFirst_saturday(targetYear, targetMonth, satCount);

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

        // hàm trả về số ngày thứ 7 trong tháng (tối ưu O(1))
        public int Count_Saturday_InMonth(int year, int month)
        {
            DateTime first = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);
            int offset = ((int)DayOfWeek.Saturday - (int)first.DayOfWeek + 7) % 7;
            return offset >= daysInMonth ? 0 : 1 + (daysInMonth - 1 - offset) / 7;
        }




        // hàm kiểm tra cột có tồn tại
        private bool check_column_Grid(GridView GV, string filenames)
        {
            if (GV == null || GV.Columns == null)
            {
                return false;
            }

            GridColumn Column_check = GV.Columns[filenames];

            // Nếu column KHÔNG phải là null, cột tồn tại.
            return Column_check != null;
        }



        private void format_Gridcontrol()
        {
            // BẬT THANH TRƯỢT NGANG
            gridViewShowData.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;

            // ẩn dòng tìm kiếm trên gridcontrol
            gridViewShowData.OptionsView.ShowGroupPanel = false;

            //--1. định dạng tiêu đề lưới Grid LSX
            gridViewShowData.Appearance.HeaderPanel.Options.UseFont = true;
            gridViewShowData.Appearance.HeaderPanel.Font = new Font("Tahoma", 10F, FontStyle.Bold);

            // Căn giữa tiêu đề
            gridViewShowData.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            GridColumn STT = gridViewShowData.Columns["STT"];
            if (STT != null)
                STT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

        }



        private void Setup_width_Gridcontrol()
        {
            string KT_Cot = "DayOff5";

            if (gridViewShowData.RowCount > 0)
            {
                if (gridViewShowData.Columns["STT"] != null)
                {
                    gridViewShowData.Columns["STT"].Width = 45;
                    gridViewShowData.Columns["STT"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                }

                if (gridViewShowData.Columns["EmpID"] != null)
                {
                    gridViewShowData.Columns["EmpID"].Width = 110;
                    gridViewShowData.Columns["EmpID"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                }

                if (gridViewShowData.Columns["EmpName"] != null)
                    gridViewShowData.Columns["EmpName"].Width = 170;

                if (gridViewShowData.Columns["Ten_Bp"] != null)
                    gridViewShowData.Columns["Ten_Bp"].Width = 200;

                if (gridViewShowData.Columns["Ten_Cv"] != null)
                    gridViewShowData.Columns["Ten_Cv"].Width = 180;

                if (gridViewShowData.Columns["DayOff1"] != null)
                {
                    gridViewShowData.Columns["DayOff1"].Width = 70;
                    gridViewShowData.Columns["DayOff1"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                }
                if (gridViewShowData.Columns["DayOff2"] != null)
                {
                    gridViewShowData.Columns["DayOff2"].Width = 70;
                    gridViewShowData.Columns["DayOff2"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                }
                if (gridViewShowData.Columns["DayOff3"] != null)
                {
                    gridViewShowData.Columns["DayOff3"].Width = 70;
                    gridViewShowData.Columns["DayOff3"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                }
                if (gridViewShowData.Columns["DayOff4"] != null)
                {
                    gridViewShowData.Columns["DayOff4"].Width = 70;
                    gridViewShowData.Columns["DayOff4"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                }

                if (check_column_Grid(gridViewShowData, KT_Cot) && gridViewShowData.Columns["DayOff5"] != null)
                {
                    gridViewShowData.Columns["DayOff5"].Width = 70;
                    gridViewShowData.Columns["DayOff5"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                }

                if (gridViewShowData.Columns["Note"] != null)
                    gridViewShowData.Columns["Note"].Width = 160;

                if (gridViewShowData.Columns["FilterMonth"] != null)
                {
                    gridViewShowData.Columns["FilterMonth"].Width = 100;
                    gridViewShowData.Columns["FilterMonth"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                }

                if (gridViewShowData.Columns["EditAction"] != null)
                    gridViewShowData.Columns["EditAction"].Width = 85;
            }
        }


        private void repair_Column_name()
        {
            string KT_Cot = "DayOff5";

            GridColumn EmpID = gridViewShowData.Columns["EmpID"];
            GridColumn EmpName = gridViewShowData.Columns["EmpName"];
            GridColumn Ten_Bp = gridViewShowData.Columns["Ten_Bp"];
            GridColumn Ten_ChucVu = gridViewShowData.Columns["Ten_Cv"];
            GridColumn DayOff1 = gridViewShowData.Columns["DayOff1"];
            GridColumn DayOff2 = gridViewShowData.Columns["DayOff2"];
            GridColumn DayOff3 = gridViewShowData.Columns["DayOff3"];
            GridColumn DayOff4 = gridViewShowData.Columns["DayOff4"];

            GridColumn Note = gridViewShowData.Columns["Note"];
            GridColumn FilterMonth = gridViewShowData.Columns["FilterMonth"];


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
            if (check_column_Grid(gridViewShowData, KT_Cot))
            {
                GridColumn DayOff5 = gridViewShowData.Columns["DayOff5"];
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



        //CỘT NÚT CONFIRM
        private void Setup_Confirm_Columns()
        {
            if (gridViewShowData.Columns["EditAction"] != null)
            {
                return;
            }

            RepositoryItemButtonEdit riButtonEdit = new RepositoryItemButtonEdit();

            // 2. Xóa nút mặc định (nếu có)
            riButtonEdit.Buttons.Clear();

            // 3. Thêm một nút mới (nút Edit)
            EditorButton button = new EditorButton(ButtonPredefines.Glyph);

            button.Caption = "Confirm"; 
            button.Kind = ButtonPredefines.Glyph; 
            riButtonEdit.Buttons.Add(button);

            riButtonEdit.TextEditStyle = TextEditStyles.HideTextEditor;
            riButtonEdit.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;

            // 5. Gán sự kiện khi nút được bấm
            riButtonEdit.ButtonClick += RiButtonEdit_ButtonClick;

            // Thêm Repository Item vào GridControl
            gridControlShowData.RepositoryItems.Add(riButtonEdit);



            //===============--- 2. phần tạo cột để chứa nút Confirm
            GridColumn colConfirm = new GridColumn();
            colConfirm.FieldName = "EditAction";
            colConfirm.Caption = "Xác Nhận";
            colConfirm.UnboundType = DevExpress.Data.UnboundColumnType.Object; 

            // 2. Gán Repository Item cho cột
            colConfirm.ColumnEdit = riButtonEdit;

            // 3. Thêm cột vào GridView
            gridViewShowData.Columns.Add(colConfirm);

            // Tùy chọn: Thiết lập kích thước
            colConfirm.VisibleIndex = gridViewShowData.Columns.Count;
            colConfirm.Width = 80;
            colConfirm.OptionsColumn.AllowEdit = true;
            colConfirm.OptionsColumn.ShowCaption = true;


            //4. Hiệu chỉnh các nút Button trong Gridview

            //__nút Edit__
            DevExpress.XtraEditors.Controls.EditorButton EditButton = riButtonEdit.Buttons[0];

            //ghi chữ
            EditButton.Caption = "Confirm";
            //thiết lập kiểu hiển thị
            EditButton.Kind = ButtonPredefines.Glyph;
            EditButton.ImageOptions.Location = ImageLocation.Default;
            EditButton.Appearance.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            EditButton.Appearance.BorderColor = System.Drawing.Color.Red;
            EditButton.Appearance.Options.UseBackColor = true;
            EditButton.Appearance.Options.UseBorderColor = true;


            gridViewShowData.BestFitColumns();
        }

        private void RiButtonEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            GridView Gview = (GridView)gridControlShowData.MainView;

            DateTime TGIAN_DK =  DateTime.Today.AddMonths(1); 

            // lấy vị trí index dòng đang chọn 
            int Focusrowhandle = Gview.FocusedRowHandle;

            // đã chọn
            if (Focusrowhandle >= 0)
            {
                string primarykey = Convert.ToString(Gview.GetRowCellValue(Focusrowhandle, "EmpID"));
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
                string filterMonth = TGIAN_DK.ToString("yyyy-MM-dd HH:mm:ss");
                string partCode = Convert.ToString(Gview.GetRowCellValue(Focusrowhandle, "PartCode"));
                string position = Convert.ToString(Gview.GetRowCellValue(Focusrowhandle, "Position"));
                object levelCv = Gview.GetRowCellValue(Focusrowhandle, "Level_CV");

                //Update
                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();

                    bool KT_ID = Check_EmpID_registered(con, primarykey, TGIAN_DK.Month, TGIAN_DK.Year);
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
                                LOAD_REFRESH(Focusrowhandle);
                            }
                        }
                        else //NV chưa đăng ký
                        {
                            using (SqlCommand cmd = new SqlCommand("sp_ASPAlternate_Insert", con))
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
                                LOAD_REFRESH(Focusrowhandle);
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


        //Hàm kiểm tra nhân viên đã đăng ký
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


        //format Datetime FilterMonth
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


        //REFRESH DÒNG ĐĂNG KÝ
        private void LOAD_REFRESH(int VT_focus)
        {
            string MaNhamay;
            object KQ_NhaMay;
            string Username = SessionManagerALS.Username;
            try
            {
                using (SqlConnection CON = new SqlConnection(constring))
                {
                    CON.Open();

                    using (SqlCommand CMD1 = new SqlCommand("sp_ASP_Level_NhaMay", CON))
                    {
                        CMD1.CommandType = CommandType.StoredProcedure;
                        CMD1.Parameters.AddWithValue("@Usename", Username);
                        KQ_NhaMay = CMD1.ExecuteScalar();
                    }

                    string PartCode = Convert.ToString(gridViewShowData.GetRowCellValue(VT_focus, "PartCode"));
                    MaNhamay = Convert.ToString(KQ_NhaMay);

                    DateTime targetMonth = (DateTime.Today.Day == 1 || DateTime.Today.Day == 2) ? DateTime.Today : DateTime.Today.AddMonths(1);

                    // Nếu Login là ID : ASP0061(A.trung) / ASP1701(A.Hải)
                    if (Username == "ASP0061" || Username == "ASP1701")
                    {
                        using (SqlCommand CMD2 = new SqlCommand("sp_ASPAlternate_ALL_Partcode_FACTORY_USER_REFRESH", CON))
                        {
                            CMD2.CommandType = CommandType.StoredProcedure;
                            CMD2.Parameters.AddWithValue("@EmpID", Username);

                            SqlDataAdapter DATA1 = new SqlDataAdapter(CMD2);
                            DataTable DT1 = new DataTable();
                            DATA1.Fill(DT1);
                            gridControlShowData.DataSource = DT1;
                            ConfigureGridAfterLoad(targetMonth);
                        }
                    }
                    else 
                    {
                        using (SqlCommand CMD2 = new SqlCommand("sp_ASPAlternate_ALL_Partcode_FACTORY", CON))
                        {
                            CMD2.CommandType = CommandType.StoredProcedure;
                            CMD2.Parameters.AddWithValue("@PartCode", PartCode);
                            CMD2.Parameters.AddWithValue("@Ma_NhaMay", MaNhamay);

                            SqlDataAdapter DATA1 = new SqlDataAdapter(CMD2);
                            DataTable DT1 = new DataTable();
                            DATA1.Fill(DT1);
                            gridControlShowData.DataSource = DT1;
                            ConfigureGridAfterLoad(targetMonth);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Lỗi Refresh: " + ex.Message);
            }
        }



        //LOAD DATA 
        private void LOAD_GRID()
        {
            // lấy thời gian tháng tới
            DateTime tgian = DateTime.Today.AddMonths(1);
            DateTime Time_PreviousMonth = DateTime.Today; 
            DateTime DATE1 = DateTime.Today;

            int DAY = DATE1.Day;

            try
            {
                string Username = SessionManagerALS.Username;
                string PartCode;
                string Ma_nhamay;
                object KQ;
                object KQ_Level;
                object KQ_NhaMay;

                using (SqlConnection CON = new SqlConnection(constring))
                {
                    CON.Open();

                    //1. Kiểm tra bộ phận 
                    using (SqlCommand CMD1 = new SqlCommand("sp_ASP_Partcode", CON))
                    {
                        CMD1.CommandType = CommandType.StoredProcedure;
                        CMD1.Parameters.AddWithValue("@Usename", Username);
                        KQ = CMD1.ExecuteScalar();
                    }

                    //2. kiểm tra chức vụ
                    using (SqlCommand CMD1 = new SqlCommand("sp_ASP_Level_ChucVu", CON))
                    {
                        CMD1.CommandType = CommandType.StoredProcedure;
                        CMD1.Parameters.AddWithValue("@Usename", Username);
                        KQ_Level = CMD1.ExecuteScalar();
                    }


                    //3. kiểm tra nhà máy
                    using (SqlCommand CMD1 = new SqlCommand("sp_ASP_Level_NhaMay", CON))
                    {
                        CMD1.CommandType = CommandType.StoredProcedure;
                        CMD1.Parameters.AddWithValue("@Usename", Username);
                        KQ_NhaMay = CMD1.ExecuteScalar();
                    }



                    //==================================== LOAD THÔNG TIN BP.SẢN XUẤT, BP.KỸ SƯ THEO NHÀ MÁY ==================================


                    // Nếu mã bộ phận khác null
                    if (KQ != null)
                    {

                        PartCode = KQ.ToString();
                        Ma_nhamay = KQ_NhaMay.ToString();


                        DateTime targetMonth = (DAY == 1 || DAY == 2) ? Time_PreviousMonth : tgian;

                        if (Username == "ASP0061" || Username == "ASP1701") // NẾU Username LÀ TBP quản lý nhiều BP CỦA NM1 HOẶC NM2
                        {
                            // load thông tin từ mã bộ phận
                            using (SqlCommand CMD2 = new SqlCommand("sp_ASPAlternate_ALL_Partcode_FACTORY_USER", CON)) 
                            {
                                CMD2.CommandType = CommandType.StoredProcedure;
                                CMD2.Parameters.AddWithValue("@EmpID", Username);

                                SqlDataAdapter DATA1 = new SqlDataAdapter(CMD2);
                                DataTable DT1 = new DataTable();
                                DATA1.Fill(DT1);
                                gridControlShowData.DataSource = DT1;
                                ConfigureGridAfterLoad(targetMonth);
                            }
                        }
                        else // CÁC NHÂN VIÊN CÒN LẠI
                        {
                            // nếu BP là sản xuất hoặc kỹ thuật ===> Load thông tin theo nhà máy (ASM1,ASM2)
                            if (PartCode == "1404" || PartCode == "1500")
                            {
                                // load thông tin từ mã bộ phận và mã nhà máy
                                using (SqlCommand CMD2 = new SqlCommand("sp_ASPAlternate_ALL_Partcode_Check", CON))
                                {
                                    CMD2.CommandType = CommandType.StoredProcedure;
                                    CMD2.Parameters.AddWithValue("@PartCode", PartCode);
                                    CMD2.Parameters.AddWithValue("@Ma_NhaMay", Ma_nhamay);

                                    SqlDataAdapter DATA1 = new SqlDataAdapter(CMD2);
                                    DataTable DT1 = new DataTable();
                                    DATA1.Fill(DT1);
                                    gridControlShowData.DataSource = DT1;
                                    ConfigureGridAfterLoad(targetMonth);
                                }
                            }
                            else // các Bộ phận còn lại không thuộc bp.kỹ sư(1500)/ bp.sản xuất(1404)
                            {
                                using (SqlCommand CMD2 = new SqlCommand("sp_ASPAlternate_ALL_Partcode", CON)) 
                                {
                                    CMD2.CommandType = CommandType.StoredProcedure;
                                    CMD2.Parameters.AddWithValue("@PartCode", PartCode);

                                    SqlDataAdapter DATA1 = new SqlDataAdapter(CMD2);
                                    DataTable DT1 = new DataTable();
                                    DATA1.Fill(DT1);
                                    gridControlShowData.DataSource = DT1;
                                    ConfigureGridAfterLoad(targetMonth);
                                }
                            }
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Lỗi : chưa tìm thấy mã bộ phận");
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi : " + ex.Message);
            }
        }

        private void ConfigureGridAfterLoad(DateTime targetMonth)
        {
            if (gridViewShowData.RowCount <= 0) return;

            if (_riComboDayOff == null)
            {
                _riComboDayOff = new RepositoryItemComboBox();
                _riComboDayOff.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                _riComboDayOff.Items.AddRange(new object[] { "Đi làm", "WFH", "OFF" });
                gridControlShowData.RepositoryItems.Add(_riComboDayOff);
            }
            else
            {
                _riComboDayOff.Items.Clear();
                _riComboDayOff.Items.AddRange(new object[] { "Đi làm", "WFH", "OFF" });
            }

            string[] dayOffCols = new string[] { "DayOff1", "DayOff2", "DayOff3", "DayOff4", "DayOff5" };
            foreach (var colName in dayOffCols)
            {
                var col = gridViewShowData.Columns[colName];
                if (col != null)
                {
                    col.ColumnEdit = _riComboDayOff;
                    col.OptionsColumn.AllowEdit = true;
                    col.OptionsColumn.ReadOnly = false;
                }
            }

            string[] readOnlyCols = new string[] { "STT", "EmpID", "EmpName", "Ten_Bp", "Ten_Cv", "FilterMonth" };
            foreach (var colName in readOnlyCols)
            {
                var col = gridViewShowData.Columns[colName];
                if (col != null)
                {
                    col.OptionsColumn.AllowEdit = false;
                    col.OptionsColumn.ReadOnly = true;
                }
            }

            gridViewShowData.OptionsBehavior.Editable = true;
            gridViewShowData.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            gridViewShowData.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;

            // setup cột Edit, nút confirm trên lưới
            Setup_Confirm_Columns();

            // Sắp xếp thứ tự cột và ẩn/hiện cột DayOff5 theo đúng thứ tự ngày
            bool has5Saturdays = Count_Saturday_InMonth(targetMonth.Year, targetMonth.Month) == 5;
            SetGridColumnsOrder(gridViewShowData, has5Saturdays);

            // chỉnh lại kích thước cột
            Setup_width_Gridcontrol();

            // định dạng cột ngày đăng ký
            FormatDateColumn(gridViewShowData);

            // Thay đổi tên cột
            repair_Column_name();

            // Cập nhật ngày thứ 7 thực tế làm tiêu đề cột
            Update_caption_Dayoff(gridViewShowData, targetMonth.Year, targetMonth.Month);
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




        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void btnDS_DangKy_Click(object sender, EventArgs e)
        {
            frmALSRegistered frm_registered = new frmALSRegistered();
            frm_registered.ShowDialog();
        }



        // Mở và Khoá Grid
        private void UpdateGridEditableState()
        {
            string username = SessionManagerALS.Username ?? "";

            // Admin hoặc Trưởng phòng luôn luôn có quyền mở lưới để chỉnh sửa/kiểm tra
            if (string.IsNullOrEmpty(username) || CheckIsAdmin(username) || check_ChucVu(username) == 2)
            {
                gridViewShowData.OptionsBehavior.Editable = true;
                gridControlShowData.Enabled = true;
                return;
            }

            DateTime today = DateTime.Today;

            // lấy ngày bắt đầu khoá và ngày kết thúc
            DateTime periodStart, periodEnd;

            GetCurrentPeriod(today, out periodStart, out periodEnd);

            bool isOpen = (today >= periodStart && today <= periodEnd);

            // DevExpress: cho phép chỉnh sửa
            gridViewShowData.OptionsBehavior.Editable = isOpen;

            //(mờ) nếu khóa
            gridControlShowData.Enabled = isOpen;
        }



        private void GetCurrentPeriod(DateTime now, out DateTime start, out DateTime end)
        {
            if (now.Day >= 23) 
            {
                start = new DateTime(now.Year, now.Month, 23);
            }
            else 
            {
                var prev = now.AddMonths(-1);
                start = new DateTime(prev.Year, prev.Month, 23);
            }
            end = new DateTime(start.Year, start.Month, 2).AddMonths(1);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            frmALSEdit frmEdit = new frmALSEdit();
            frmEdit.ShowDialog();
        }
    }
}
