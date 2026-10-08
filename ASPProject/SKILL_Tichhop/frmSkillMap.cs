//using ClosedXML.Excel;
using ASPProject.SkillMap;
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
//using ExcelDataReader;
//using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using static DevExpress.XtraEditors.Mask.MaskSettings;
using static System.Net.WebRequestMethods;






namespace ASPProject.AppTemplateSkillMap
{
    public partial class frmSkillMap : XtraForm
    {
        //--DB backup
        //string constring = @"Data Source=14.241.201.7,1537;Initial Catalog=ASPBK;Persist Security Info=True;User ID=sa;Password=L@cH0ng#@!2026$;"; //ASPBK ,ASP

        //--DB chính
        string constring = @"Data Source=14.241.201.7,1537;Initial Catalog=ASP;Persist Security Info=True;User ID=sa;Password=L@cH0ng#@!2026$;";

        DataTable dt;
        OleDbDataAdapter DA;
        SqlDataAdapter DATA;
        public string UseNameLogin;


        public frmSkillMap()
        {
            InitializeComponent();

            UseNameLogin = SessionMangerSkillMap.Username;

            // ẩn các nút
            BtnImportFile.Enabled = false;
            txtPath.Enabled = false;
            btnExportExcel.Visible = true;
            btnLoad_Data_Horizontal.Visible = false;

            // chỉnh font Header của Gridcontrol
            gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            gridView1.Appearance.HeaderPanel.Font = new Font("Tahoma", 10F, FontStyle.Bold);

            // khoá lưới Gridcontrol
            gridView1.OptionsBehavior.Editable = false;
            //gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;


            // thêm dòng lọc trên lưới
            gridView1.OptionsView.ShowAutoFilterRow = true;
            gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            // ẩn dòng tìm kiếm trên gridcontrol
            gridView1.OptionsView.ShowGroupPanel = false;



            //điều chỉnh khoảng cách cột
            gridView1.OptionsView.ColumnAutoWidth = true;

            // Wrap tiêu đề cột cho bảng hiển thị Kỹ thuật viên
            gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;


            //thêm cột Edit & Delete
            // ADD_EditDelete_Columns();


            //đăng ký sự kiện click
            repItemBtnEdit.ButtonClick += RepItemBtnEdit_ButtonClick;
            repItemBtnDelete.ButtonClick += RepItemBtnDelete_ButtonClick;

            //Load thông tin theo User đăng nhập
            KT_Login(UseNameLogin);

        }



        private void KT_Login(string Username)
        {
            bool CHECK_ID = false;

            CHECK_ID = (Username == "WHA" || Username == "WHB" || Username == "WHC" || Username == "WHD" || (Username == "PILOT" || Username == "USBB" || Username == "USBC"));

            if (CHECK_ID == true) // Username thuộc sản xuất
            {
                gridControlData.Visible = false;
                txtPath.Visible = false;
                btnAdd.Visible = false;
                btnExit.Visible = false;
                btnLoadDataKTV.Visible = false;
                BtnChooseFile.Visible = false;
                btnExportExcel.Visible = false;
                BtnImportFile.Visible = false;
                label1.Visible = false;
                btnLoad_Data_Horizontal.Visible = false;
            }
            else
            {
                btnLoadDataUser.Visible = false;
                Show_Data();
            }
        }







        // Refresh Data vẫn giữ vị trí cũ
        private void RefresData_Notchange_Position()
        {
            // lưu trữ vị trí dòng đang chỉnh sửa
            int focusrowhandle = gridView1.FocusedRowHandle;

            object rowkey = null;

            if (focusrowhandle >= 0)
            {
                // lấy giá trị khoá khi có dòng hợp lệ được chọn
                rowkey = gridView1.GetRowCellValue(focusrowhandle, "AutoID");
            }

            Show_Data();

            if (rowkey == null)
            {
                return;
            }


            int NewRow_handle = gridView1.LocateByValue("AutoID", rowkey);

            if (NewRow_handle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                // tìm thấy khoá sẽ trả lại vị trí y cũ
                gridView1.FocusedRowHandle = NewRow_handle;
            }
            else
            {
                //phục hồi lại vị trí cũ
                if (focusrowhandle < gridView1.DataRowCount)
                {
                    gridView1.FocusedRowHandle = focusrowhandle;
                }
            }

        }





        // Tổng số dòng trên gridcontrol
        private void Display_TotalRecord(GridView GV)
        {
            GridColumn column = (GridColumn)GV.Columns["EmpName"];
            //column.Width = 70;
            //column.BestFit();
            column.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            column.SummaryItem.DisplayFormat = "Total Record: {0}";

            GV.OptionsView.ShowFooter = true;
            GV.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
        }




        private void InitializeGridButtons()
        {

            repItemBtnEdit = (RepositoryItemButtonEdit)gridControlData.RepositoryItems["repItemBtnEdit"];
            repItemBtnDelete = (RepositoryItemButtonEdit)gridControlData.RepositoryItems["repItemBtnDelete"];


            DevExpress.XtraEditors.Controls.EditorButton EditButton = repItemBtnEdit.Buttons[0];

            //ghi chữ
            EditButton.Caption = "Edit";

            //thiết lập kiểu hiển thị
            EditButton.Kind = ButtonPredefines.Glyph;

            EditButton.ImageOptions.Location = ImageLocation.Default;


            EditButton.Appearance.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);

            EditButton.Appearance.Options.UseBackColor = true;
        }


        // khởi tạo thêm các cột mới sau khi dữ liệu đã tạo
        private void SetupEditDeleteColumns()
        {
            // Đảm bảo GridView có cột trước khi thao tác
            if (gridView1.Columns.Count == 0 || repItemBtnEdit == null || repItemBtnDelete == null) return;

            // 1. Kiểm tra và Xóa cột cũ (để tránh thêm lại)
            if (gridView1.Columns["colEdit"] != null) gridView1.Columns.Remove(gridView1.Columns["colEdit"]);
            if (gridView1.Columns["colDelete"] != null) gridView1.Columns.Remove(gridView1.Columns["colDelete"]);

            // 2. TẠO VÀ CẤU HÌNH CỘT EDIT
            DevExpress.XtraGrid.Columns.GridColumn colEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            colEdit.FieldName = "EditButton"; // FieldName có thể là bất kỳ chuỗi duy nhất nào
            colEdit.Caption = "Edit";
            colEdit.Name = "colEdit";
            colEdit.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            colEdit.OptionsColumn.AllowEdit = true;
            colEdit.OptionsColumn.ShowCaption = true;
            colEdit.ColumnEdit = repItemBtnEdit; // GÁN REPOSITORY ITEM ĐÃ TẠO
            colEdit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colEdit.Visible = true;

            // 3. TẠO VÀ CẤU HÌNH CỘT DELETE
            DevExpress.XtraGrid.Columns.GridColumn colDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            colDelete.FieldName = "DeleteButton";
            colDelete.Caption = "Delete";
            colDelete.Name = "colDelete";
            colDelete.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            colDelete.OptionsColumn.AllowEdit = true;
            colDelete.OptionsColumn.ShowCaption = true;
            colDelete.ColumnEdit = repItemBtnDelete; // GÁN REPOSITORY ITEM ĐÃ TẠO
            colDelete.Visible = true;

            // 4. THÊM VÀ SẮP XẾP VỊ TRÍ
            gridView1.Columns.Add(colEdit);
            gridView1.Columns.Add(colDelete);




            // Đưa cột Edit/Delete ra cuối cùng
            colEdit.VisibleIndex = gridView1.Columns.Count - 2;
            colDelete.VisibleIndex = gridView1.Columns.Count - 1;


            // chỉnh độ rộng cột
            colDelete.Width = 95;
            colEdit.Width = 95;


            //khoá cột không cho sửa
            colEdit.OptionsColumn.AllowSize = false;
            colDelete.OptionsColumn.AllowSize = false;



            //5. Hiệu chỉnh các nút Button trong Gridview

            //__nút Edit__
            DevExpress.XtraEditors.Controls.EditorButton EditButton = repItemBtnEdit.Buttons[0];

            //ghi chữ
            EditButton.Caption = "Edit";
            //thiết lập kiểu hiển thị
            EditButton.Kind = ButtonPredefines.Glyph;
            EditButton.ImageOptions.Location = ImageLocation.Default;
            EditButton.Appearance.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            EditButton.Appearance.BorderColor = System.Drawing.Color.Red;
            EditButton.Appearance.Options.UseBackColor = true;
            EditButton.Appearance.Options.UseBorderColor = true;



            //__nút Delete
            DevExpress.XtraEditors.Controls.EditorButton DeleteButton = repItemBtnDelete.Buttons[0];

            //ghi chữ
            DeleteButton.Caption = "Delete";
            //thiết lập kiểu hiển thị
            DeleteButton.Kind = ButtonPredefines.Glyph;
            DeleteButton.ImageOptions.Location = ImageLocation.Default;
            DeleteButton.Appearance.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            DeleteButton.Appearance.Options.UseBackColor = true;


            // hiển thị text và image trên Button
            repItemBtnEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            repItemBtnDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;

            // chỉnh viền Button trên lưới
            repItemBtnEdit.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            repItemBtnDelete.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;

            //gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;

            gridView1.BestFitColumns();
        }



        private void RepItemBtnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            GridView Gview = (GridView)gridControlData.MainView;

            // lấy vị trí index dòng đang chọn trên lưới
            int Focusrowhandle = Gview.FocusedRowHandle;

            if (Focusrowhandle >= 0)
            {
                object primarykey = Gview.GetRowCellValue(Focusrowhandle, "EmpID");

                DialogResult KQ = XtraMessageBox.Show($"Are you sure you want to delete the employee with ID : {primarykey}  ? ", "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (KQ == DialogResult.OK)
                {

                    // xoá trên lưới
                    Gview.DeleteRow(Focusrowhandle);

                    //hàm code xoá trong Database
                    Delete_Data_ID(primarykey.ToString());
                    Show_Data();
                    gridView1.RefreshData();
                }
            }
        }

        private void RepItemBtnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            GridView Gview = (GridView)gridControlData.MainView;

            // lấy vị trí index dòng đang chọn trên lưới
            //int Focusrowhandle = Gview.FocusedRowHandle;


            //DataView DV = (DataView)Gview.DataSource;
            //var checkrow = DV.Table.AsEnumerable()
            //.Where(X => X.Field<bool?>("IsSelected") == true)
            //.ToList();


            //if (checkrow.Count == 0)
            //{
            //    XtraMessageBox.Show("Bạn chưa chọn dòng nào");
            //}

            ////Duyệt qua từng dòng
            //foreach (var ROW in checkrow)
            //{
            //    string MANV = ROW["EmpID"].ToString();
            //    string HOTEN = ROW["EmpName"].ToString();

            //    XtraMessageBox.Show("Đang sửa : " + HOTEN);
            //}


            try
            {

                int dem = 0;

                for (int i = 0; i < Gview.RowCount; i++)
                {
                    bool IsChecked = Gview.GetRowCellValue(i, "IsSelected") == DBNull.Value
                    ? false
                    : Convert.ToBoolean(Gview.GetRowCellValue(i, "IsSelected"));


                    if (IsChecked == true) // nếu có check chọn
                    {
                        dem += 1;

                        if (dem > 0)
                        {
                            object primarykey = Gview.GetRowCellValue(i, "EmpID");
                            object EmpName = Gview.GetRowCellValue(i, "EmpName");
                            object Position = Gview.GetRowCellValue(i, "Position");
                            object Direct_Indirect = Gview.GetRowCellValue(i, "Direct_Indirect");
                            object LineID = Gview.GetRowCellValue(i, "LineID");
                            object SkillID = Gview.GetRowCellValue(i, "SkillID");
                            object PercentLV = Gview.GetRowCellValue(i, "PercentLV");
                            object DateReachedLV0 = Gview.GetRowCellValue(i, "DateReachedLV0");
                            object DateReachedLV1 = Gview.GetRowCellValue(i, "DateReachedLV1");
                            object DateReachedLV2 = Gview.GetRowCellValue(i, "DateReachedLV2");
                            object DateReachedLV3 = Gview.GetRowCellValue(i, "DateReachedLV3");
                            object DateReachedLV4 = Gview.GetRowCellValue(i, "DateReachedLV4");
                            object EmpStatus = Gview.GetRowCellValue(i, "EmpStatus");
                            object StartDate = Gview.GetRowCellValue(i, "StartDate");
                            object Seniority = Gview.GetRowCellValue(i, "Seniority");
                            object GroupLine = Gview.GetRowCellValue(i, "GroupLine");


                            // XtraMessageBox.Show($"Bạn cập nhật thông tin nhân viên có ID : {primarykey}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //hàm code sửa
                            using (SqlConnection con = new SqlConnection(constring))
                            {
                                con.Open();
                                using (SqlCommand cmd = new SqlCommand("sp_ASP_UPDATE_ID", con)) //sp_ASP_UPDATE_ID2
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;

                                    cmd.Parameters.AddWithValue("@EmpID", primarykey);
                                    cmd.Parameters.AddWithValue("@EmpName", EmpName);
                                    cmd.Parameters.AddWithValue("@Position", Position);
                                    cmd.Parameters.AddWithValue("@Direct_Indirect", Direct_Indirect);
                                    cmd.Parameters.AddWithValue("@LineID", LineID);
                                    cmd.Parameters.AddWithValue("@SkillID", SkillID);
                                    cmd.Parameters.AddWithValue("@PercentLV", PercentLV);
                                    cmd.Parameters.AddWithValue("@DateReachedLV0", DateReachedLV0);
                                    cmd.Parameters.AddWithValue("@DateReachedLV1", DateReachedLV1);
                                    cmd.Parameters.AddWithValue("@DateReachedLV2", DateReachedLV2);
                                    cmd.Parameters.AddWithValue("@DateReachedLV3", DateReachedLV3);
                                    cmd.Parameters.AddWithValue("@DateReachedLV4", DateReachedLV4);
                                    cmd.Parameters.AddWithValue("@EmpStatus", EmpStatus);
                                    cmd.Parameters.AddWithValue("@StartDate", StartDate);
                                    cmd.Parameters.AddWithValue("@Seniority", Seniority);
                                    cmd.Parameters.AddWithValue("@GroupLine", GroupLine);

                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }

                if (dem > 0)
                {
                    // hàm giữ lại vị trí sau khi lưu
                    RefresData_Notchange_Position();

                    XtraMessageBox.Show("Update Data Success ! " + dem + " Record");
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error Edit : " + ex.Message);
            }


            #region
            /*
            if (Focusrowhandle > 0)
            {
                object primarykey = Gview.GetRowCellValue(Focusrowhandle, "EmpID");
                object EmpName = Gview.GetRowCellValue(Focusrowhandle, "EmpName");
                object Position = Gview.GetRowCellValue(Focusrowhandle, "Position");
                object Direct_Indirect = Gview.GetRowCellValue(Focusrowhandle, "Direct_Indirect");
                object LineID = Gview.GetRowCellValue(Focusrowhandle, "LineID");
                object SkillID = Gview.GetRowCellValue(Focusrowhandle, "SkillID");
                object PercentLV = Gview.GetRowCellValue(Focusrowhandle, "PercentLV");
                object DateReachedLV0 = Gview.GetRowCellValue(Focusrowhandle, "DateReachedLV0");
                object DateReachedLV1 = Gview.GetRowCellValue(Focusrowhandle, "DateReachedLV1");
                object DateReachedLV2 = Gview.GetRowCellValue(Focusrowhandle, "DateReachedLV2");
                object DateReachedLV3 = Gview.GetRowCellValue(Focusrowhandle, "DateReachedLV3");
                object DateReachedLV4 = Gview.GetRowCellValue(Focusrowhandle, "DateReachedLV4");
                object EmpStatus = Gview.GetRowCellValue(Focusrowhandle, "EmpStatus");
                object StartDate = Gview.GetRowCellValue(Focusrowhandle, "StartDate");
                object Seniority = Gview.GetRowCellValue(Focusrowhandle, "Seniority");
                object GroupLine = Gview.GetRowCellValue(Focusrowhandle, "GroupLine");


                XtraMessageBox.Show($"Bạn cập nhật thông tin nhân viên có ID : {primarykey}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //hàm code sửa
                using(SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_ASP_UPDATE_ID",con)) //sp_ASP_UPDATE_ID2
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@EmpID", primarykey);
                        cmd.Parameters.AddWithValue("@EmpName", EmpName);
                        cmd.Parameters.AddWithValue("@Position", Position);
                        cmd.Parameters.AddWithValue("@Direct_Indirect", Direct_Indirect);
                        cmd.Parameters.AddWithValue("@LineID", LineID);
                        cmd.Parameters.AddWithValue("@SkillID", SkillID);
                        cmd.Parameters.AddWithValue("@PercentLV", PercentLV);
                        cmd.Parameters.AddWithValue("@DateReachedLV0", DateReachedLV0);
                        cmd.Parameters.AddWithValue("@DateReachedLV1", DateReachedLV1);
                        cmd.Parameters.AddWithValue("@DateReachedLV2", DateReachedLV2);
                        cmd.Parameters.AddWithValue("@DateReachedLV3", DateReachedLV3);
                        cmd.Parameters.AddWithValue("@DateReachedLV4", DateReachedLV4);
                        cmd.Parameters.AddWithValue("@EmpStatus", EmpStatus);
                        cmd.Parameters.AddWithValue("@StartDate", StartDate);
                        cmd.Parameters.AddWithValue("@Seniority", Seniority);
                        cmd.Parameters.AddWithValue("@GroupLine", GroupLine);

                        cmd.ExecuteNonQuery();
                    }    
                }
                // Show_Data();
                RefresData_Notchange_Position();
                XtraMessageBox.Show("Update Data Success!");
            }

            */
            #endregion

        }



        // chọn file All
        private void BtnChooseFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "Excel Files|*.xls;*.xlsx";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFile.FileName;
                    txtPath.Text = filePath;

                    string Input_file = Path.GetExtension(filePath).ToLower();
                    string connStr = "";


                    //kiểm tra file đầu vào
                    if (Input_file == ".xlsx")
                    {
                        connStr = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={txtPath.Text.Trim()};Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;'";
                    }
                    else if (Input_file == ".xls")
                    {
                        connStr = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={txtPath.Text.Trim()};Extended Properties='Excel 8.0 Xml;HDR=YES;IMEX=1;'";
                    }
                    else
                    {
                        XtraMessageBox.Show("Choose File Excel , Please !", "Error Import", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }



                    // Kết nối tới file Excel
                    using (OleDbConnection conn = new OleDbConnection(connStr))
                    {
                        conn.Open();

                        //lấy sheet đầu tiên tên "Sheet1" của file Excel
                        DA = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", conn);

                        dt = new DataTable();
                        dt.Clear();
                        DA.Fill(dt);

                        foreach (DataColumn col in dt.Columns)
                        {
                            col.ColumnName = col.ColumnName.Replace(" ", "").Trim();
                        }

                        gridView1.Columns.Clear();
                        //gridControlData.DataSource = null;
                        gridControlData.DataSource = dt;

                        // tự động chỉnh độ rộng cột của lưới
                        gridView1.BestFitColumns();


                        //hiện số thứ tự trong Gridcontrol
                        DevExpress.XtraGrid.Columns.GridColumn Gridcol = new DevExpress.XtraGrid.Columns.GridColumn();
                        Gridcol.Caption = "AutoID";
                        Gridcol.FieldName = "AutoID";
                        Gridcol.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
                        Gridcol.Visible = true;
                        gridView1.Columns.Add(Gridcol);

                        // Đặt lại vị trí sau khi add, căn lề giữa tại cột STT trên Gridcontrol
                        gridView1.Columns["AutoID"].VisibleIndex = 0;
                        gridView1.Columns["AutoID"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gridView1.Columns["AutoID"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;



                        // Gắn sự kiện CustomUnboundColumnData
                        gridView1.CustomUnboundColumnData += GridView1_CustomUnboundColumnData;
                        gridView1.RefreshData();

                    }
                }

                // HIỆN NÚT Import, Export Excel 
                BtnImportFile.Enabled = true;
                btnExportExcel.Visible = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error Import : " + ex.Message, "Error Import File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // HÀM XỬ LÝ SỰ KIỆN RIÊNG
        private void GridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "AutoID" && e.IsGetData)
            {
                e.Value = e.ListSourceRowIndex + 1;
            }
        }


        /*-----------------------------/Các hàm để gọi trong chương trình/---------------------------------------*/
        private void Delete_Data()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();

                    using (SqlCommand CMD = new SqlCommand("sp_ASP_DELETE_DATA", con))
                    {
                        CMD.CommandType = CommandType.StoredProcedure;
                        CMD.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error Delete Data : " + ex.Message);
            }
        }



        // hàm Load dữ liệu
        private void Show_Data()
        {

            try
            {

                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();

                    using (SqlCommand CMD = new SqlCommand("sp_ASP_SHOW_DATA2", con))
                    {
                        CMD.CommandType = CommandType.StoredProcedure;
                        DATA = new SqlDataAdapter(CMD);
                        dt = new DataTable();
                        dt.Clear();
                        DATA.Fill(dt);

                        if (dt.Rows.Count <= 0)
                        {
                            gridControlData.DataSource = DBNull.Value;
                            gridControlData.RefreshDataSource();
                        }
                        else
                        {
                            gridControlData.DataSource = dt;

                            // vòng lặp quét qua các cột để tăng % cột percent
                            for (int i = 0; i < gridView1.RowCount; i++)
                            {
                                object LV1 = gridView1.GetRowCellValue(i, "DateReachedLV1");
                                object LV2 = gridView1.GetRowCellValue(i, "DateReachedLV2");
                                object LV3 = gridView1.GetRowCellValue(i, "DateReachedLV3");
                                object LV4 = gridView1.GetRowCellValue(i, "DateReachedLV4");

                                int percent = Calculate_Percent(LV1, LV2, LV3, LV4);

                                gridView1.SetRowCellValue(i, "PercentLV", percent);
                            }

                            // tự động tạo lại các cột trên lưới
                            gridView1.PopulateColumns();

                            // tự động chỉnh độ rộng cột của lưới
                            gridView1.BestFitColumns();

                            // căn lề dữ liệu trong cột
                             gridView1.Columns["AutoID"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;


                            //Tổng số record trên lưới hiển thị
                            Display_TotalRecord(gridView1);

                            //khởi tạo lại các cột sau khi load dữ liệu
                            SetupEditDeleteColumns();


                            //CheckBox
                            CreateCheckColumnForEdit(dt);

                            //mở lại cột load dữ liệu tổng
                            btnLoad_Data_Horizontal.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error Show Data : " + ex.Message, "Error Show Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        // Hàm xoá dữ liệu theo ID nhân viên
        private void Delete_Data_ID(string EmpIDD)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();

                using (SqlCommand CMD = new SqlCommand("sp_ASP_DELETE_ID", con))
                {
                    CMD.CommandType = CommandType.StoredProcedure;
                    CMD.Parameters.AddWithValue("@EMPID", EmpIDD);
                    CMD.ExecuteNonQuery();
                }
            }
        }






        private void ADD_EditDelete_Columns()
        {
            //thêm cột Edit
            DevExpress.XtraGrid.Columns.GridColumn colEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            colEdit.FieldName = "Edit";
            colEdit.Caption = "Edit";
            colEdit.Visible = true;
            gridView1.Columns.Add(colEdit);

            //thêm cột Edit
            DevExpress.XtraGrid.Columns.GridColumn colDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            colDelete.FieldName = "Delete";
            colDelete.Caption = "Delete";
            colDelete.Visible = true;
            gridView1.Columns.Add(colDelete);
        }



        // hàm tăng tự động cột percent
        private int Calculate_Percent(object LV1, object LV2, object LV3, object LV4)
        {
            int Percent = 0;

            if (LV1 != null && LV1 != DBNull.Value)
            {
                Percent = 25;

                if (LV2 != null && LV2 != DBNull.Value)
                {
                    Percent = 50;

                    if (LV3 != null && LV3 != DBNull.Value)
                    {
                        Percent = 75;

                        if (LV4 != null && LV4 != DBNull.Value)
                        {
                            Percent = 100;
                        }
                    }
                }
            }

            return Percent;
        }





        //hàm update từ gridview
        private void Update_from_Gridview()
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    string EmpID = Convert.ToString(gridView1.GetRowCellValue(i, "EmpID"));
                    string EmpName = Convert.ToString(gridView1.GetRowCellValue(i, "EmpName"));
                    string Position = Convert.ToString(gridView1.GetRowCellValue(i, "Position"));
                    string Direct_Indirect = Convert.ToString(gridView1.GetRowCellValue(i, "Direct_Indirect"));
                    string LineID = Convert.ToString(gridView1.GetRowCellValue(i, "LineID"));
                    string SkillID = Convert.ToString(gridView1.GetRowCellValue(i, "SkillID"));
                    decimal PercentLV = Convert.ToDecimal(gridView1.GetRowCellValue(i, "PercentLV"));
                    string EmpStatus = Convert.ToString(gridView1.GetRowCellValue(i, "EmpStatus"));
                    string StartDate = Convert.ToString(gridView1.GetRowCellValue(i, "StartDate"));
                    decimal Seniority = Convert.ToDecimal(gridView1.GetRowCellValue(i, "Seniority"));
                    string GroupLine = Convert.ToString(gridView1.GetRowCellValue(i, "GroupLine"));



                    using (SqlConnection con = new SqlConnection(constring))
                    {
                        con.Open();

                        using (SqlCommand cmd = new SqlCommand("sp_ASP_UPDATE_ID2", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@EmpID", EmpID);
                            cmd.Parameters.AddWithValue("@EmpName", EmpName);
                            cmd.Parameters.AddWithValue("@Position", Position);
                            cmd.Parameters.AddWithValue("@Direct_Indirect", Direct_Indirect);
                            cmd.Parameters.AddWithValue("@LineID", LineID);
                            cmd.Parameters.AddWithValue("@SkillID", SkillID);
                            cmd.Parameters.AddWithValue("@PercentLV", SqlDbType.Money).Value = PercentLV;
                            cmd.Parameters.AddWithValue("@EmpStatus", EmpStatus);
                            cmd.Parameters.AddWithValue("@StartDate", Convert.ToDateTime(StartDate).ToString("yyyyMMdd"));
                            cmd.Parameters.AddWithValue("@Seniority", SqlDbType.Money).Value = Seniority;
                            cmd.Parameters.AddWithValue("@GroupLine", GroupLine);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                Show_Data();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error Update : " + ex.Message, "Error Update (Show_data) ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }



        private void BtnImportFile_Click(object sender, EventArgs e)
        {
            //Xoá dữ liệu cũ trước khi insert 
            Delete_Data();

            try
            {
                using (SqlConnection conn = new SqlConnection(constring))
                {
                    conn.Open();
                    foreach (DataRow row in dt.Rows)
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_ASP_ADD_ALL", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@EmpID", row["EmpID"].ToString());
                            cmd.Parameters.AddWithValue("@EmpName", row["EmpName"].ToString());
                            cmd.Parameters.AddWithValue("@Position", row["Position"].ToString());
                            cmd.Parameters.AddWithValue("@Direct_Indirect", row["Direct_Indirect"].ToString());
                            cmd.Parameters.AddWithValue("@LineID", row["LineID"].ToString());
                            cmd.Parameters.AddWithValue("@SkillID", row["SkillID"].ToString());
                            cmd.Parameters.AddWithValue("@PercentLV", row["PercentLV"].ToString());
                            // cmd.Parameters.AddWithValue("@DateReachedLV0", string.IsNullOrEmpty(row["DateReachedLV0"].ToString()) ? new DateTime(1900, 1, 1) : DateTime.Parse(row["DateReachedLV0"].ToString()).Date.Add(DateTime.Now.TimeOfDay));

                            cmd.Parameters.AddWithValue("@DateReachedLV0", string.IsNullOrEmpty(row["DateReachedLV0"].ToString()) ? row["DateReachedLV0"] : DateTime.Parse(row["DateReachedLV0"].ToString()).Date.Add(DateTime.Now.TimeOfDay));
                            cmd.Parameters.AddWithValue("@DateReachedLV1", string.IsNullOrEmpty(row["DateReachedLV1"].ToString()) ? row["DateReachedLV1"] : DateTime.Parse(row["DateReachedLV1"].ToString()).Date.Add(DateTime.Now.TimeOfDay));
                            cmd.Parameters.AddWithValue("@DateReachedLV2", string.IsNullOrEmpty(row["DateReachedLV2"].ToString()) ? row["DateReachedLV2"] : DateTime.Parse(row["DateReachedLV2"].ToString()).Date.Add(DateTime.Now.TimeOfDay));
                            cmd.Parameters.AddWithValue("@DateReachedLV3", string.IsNullOrEmpty(row["DateReachedLV3"].ToString()) ? row["DateReachedLV3"] : DateTime.Parse(row["DateReachedLV3"].ToString()).Date.Add(DateTime.Now.TimeOfDay));
                            cmd.Parameters.AddWithValue("@DateReachedLV4", string.IsNullOrEmpty(row["DateReachedLV4"].ToString()) ? row["DateReachedLV4"] : DateTime.Parse(row["DateReachedLV4"].ToString()).Date.Add(DateTime.Now.TimeOfDay));
                            cmd.Parameters.AddWithValue("@EmpStatus", string.IsNullOrEmpty(row["EmpStatus"].ToString()) ? "''" : "");
                            cmd.Parameters.AddWithValue("@StartDate", string.IsNullOrEmpty(row["StartDate"].ToString()) ? row["StartDate"] : "");
                            cmd.Parameters.AddWithValue("@Seniority", string.IsNullOrEmpty(row["Seniority"].ToString()) ? 0 : 0);
                            cmd.Parameters.AddWithValue("@GroupLine", row["GroupLine"]?.ToString() ?? "");

                            cmd.ExecuteNonQuery();
                        }
                    }
                    //load dữ liệu từ database lên gridview
                    Show_Data();
                    Update_from_Gridview();
                    XtraMessageBox.Show("Import Data Success!");

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error Import : " + ex.Message, "Error Import File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }




        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // kiểm tra lưới Gridview trước khi xuất Excel
                if (gridView1.RowCount <= 0)
                {
                    XtraMessageBox.Show("No data Export Excel", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string downloadpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

                    string Filename = "Export_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";
                    string filepath = Path.Combine(downloadpath, Filename);

                    gridControlData.ExportToXlsx(filepath);

                    XtraMessageBox.Show("Export Excel Success", "Export Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Failed Export Excel : " + ex.Message, "Error Export Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void Delete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void Edit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //throw new NotImplementedException();
            //MessageBox.Show("bạn đang nhấn Edit");
        }

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {

            gridView1.FocusedColumn = e.Column;
            gridView1.ShowEditor();
            gridView1.OptionsBehavior.Editable = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddStaff frmAdd = new frmAddStaff();

            // đăng ký phương thức xử lý sự kiện
            frmAdd.DataAdd += FrmAdd_DataAdd;

            frmAdd.Show();
        }

        private void FrmAdd_DataAdd()
        {
            Show_Data();
        }

        private void gridView1_ColumnChanged(object sender, EventArgs e)
        {
            //foreach (DevExpress.XtraGrid.Columns.GridColumn col in gridView1.Columns)
            //{
            //    col.Caption = col.FieldName;  // giữ nguyên tên gốc
            //}
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;

            if (view == null) return;

            if (e.Column.FieldName == "DateReachedLV1" || e.Column.FieldName == "DateReachedLV2" || e.Column.FieldName == "DateReachedLV3" || e.Column.FieldName == "DateReachedLV4")
            {
                object LV1 = view.GetRowCellValue(e.RowHandle, "DateReachedLV1");
                object LV2 = view.GetRowCellValue(e.RowHandle, "DateReachedLV2");
                object LV3 = view.GetRowCellValue(e.RowHandle, "DateReachedLV3");
                object LV4 = view.GetRowCellValue(e.RowHandle, "DateReachedLV4");


                // Điều kiện phải đi theo thứ tự từ LV1 -> LV4
                int percent = Calculate_Percent(LV1, LV2, LV3, LV4);

                view.SetRowCellValue(e.RowHandle, "PercentLV", percent);
            }


            // Kiểm tra cột Islected trong Gridcontrol

            //if (e.Column.FieldName.Equals("IsSelected"))
            //{
            //    // trạng thái check
            //    bool isChecked = Convert.ToBoolean(e.Value);

            //    //lấy số dòng hiện tại
            //    int rowhandle = e.RowHandle;


            //    // Lấy dữ liệu của dòng vừa check (ví dụ Mã nhân viên)
            //    string maNV = gridView1.GetRowCellValue(rowhandle, "EmpID")?.ToString();

            //    // Hiển thị thông báo
            //    XtraMessageBox.Show(
            //        $"Bạn đã {(isChecked ? "CHECK" : "BỎ CHECK")} dòng:\n" +
            //        $"RowHandle: {rowhandle}\n" +
            //        $"Mã nhân viên: {maNV}",
            //        "Thông báo",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Information
            //    );
            //}


        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            DateTime dt;
            if (e.Column.FieldName == "DateReachedLV0")
            {
                if (e.Value != null && DateTime.TryParse(e.Value.ToString(), out dt))
                {
                    e.DisplayText = dt.ToString("dd/MM/yyyy");
                }
                else
                {
                    e.DisplayText = "";
                }
            }


            //if (e.Column.FieldName == "DateReachedLV0")
            //{
            //    if (e.Value == null || e.Value == DBNull.Value)
            //    {
            //        e.DisplayText = ""; // bỏ qua nếu null
            //    }
            //    else
            //    {
            //        e.DisplayText = Convert.ToDateTime(e.Value).ToString("dd/MM/yyyy");
            //    }
            //}



            if (e.Column.FieldName == "DateReachedLV1")
            {
                if (e.Value == null || e.Value == DBNull.Value)
                {
                    e.DisplayText = ""; // bỏ qua nếu null
                }
                else
                {
                    e.DisplayText = Convert.ToDateTime(e.Value).ToString("dd/MM/yyyy");
                }
            }
            if (e.Column.FieldName == "DateReachedLV2")
            {
                if (e.Value == null || e.Value == DBNull.Value)
                {
                    e.DisplayText = "";
                }
                else
                {
                    e.DisplayText = Convert.ToDateTime(e.Value).ToString("dd/MM/yyyy");
                }
            }

            if (e.Column.FieldName == "DateReachedLV3")
            {
                if (e.Value == null || e.Value == DBNull.Value)
                {
                    e.DisplayText = "";
                }
                else
                {
                    e.DisplayText = Convert.ToDateTime(e.Value).ToString("dd/MM/yyyy");
                }
            }

            if (e.Column.FieldName == "DateReachedLV4")
            {
                if (e.Value == null || e.Value == DBNull.Value)
                {
                    e.DisplayText = "";
                }
                else
                {
                    e.DisplayText = Convert.ToDateTime(e.Value).ToString("dd/MM/yyyy");
                }
            }

            if (e.Column.FieldName == "StartDate")
            {
                if (e.Value == null || e.Value == DBNull.Value)
                {
                    e.DisplayText = "";
                }
                else
                {
                    e.DisplayText = Convert.ToDateTime(e.Value).ToString("dd/MM/yyyy");
                }
            }

            if (e.Column.FieldName == "PercentLV") // cột kiểu money
            {
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    decimal moneyValue = Convert.ToDecimal(e.Value);
                    e.DisplayText = Convert.ToInt32(moneyValue).ToString();
                }
            }
        }

        private void btnLoad_Data_Horizontal_Click(object sender, EventArgs e)
        {
            frmLoadDataHorizontal frm_horizontal = new frmLoadDataHorizontal();
            frm_horizontal.Show();
        }

        private void frmSkillMap_Load(object sender, EventArgs e)
        {
        }

        private void btnLoadDataKTV_Click(object sender, EventArgs e)
        {
            frmLoadDataHorizontalKTV frmKTV = new frmLoadDataHorizontalKTV();
            frmKTV.Show();

        }



        // Tạo cột check trên gridcontrol
        private void CreateCheckColumnForEdit(DataTable dt)
        {
            // nếu cột không tồn tại
            if (!dt.Columns.Contains("IsSelected"))
            {
                dt.Columns.Add("IsSelected", typeof(bool));
            }

            gridControlData.DataSource = dt;

            GridColumn checkcolumn = gridView1.Columns.ColumnByFieldName("IsSelected");

            // Nếu cột chưa tồn tại
            if (checkcolumn != null) return;

            checkcolumn = new GridColumn();
            checkcolumn.FieldName = "IsSelected";
            checkcolumn.Caption = "Check";
            checkcolumn.VisibleIndex = 0;
            checkcolumn.Width = 50;
            checkcolumn.OptionsColumn.AllowEdit = true;
            checkcolumn.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;  //UnboundDataType = typeof(bool);

            checkcolumn.FilterMode = ColumnFilterMode.DisplayText;
            checkcolumn.OptionsFilter.AllowFilter = false;
            checkcolumn.UnboundExpression = "False";


            // Tạo Respository checkbox
            RepositoryItemCheckEdit RICEDIT = new RepositoryItemCheckEdit();
            gridControlData.RepositoryItems.Add(RICEDIT);
            checkcolumn.ColumnEdit = RICEDIT;


            gridView1.Columns.Add(checkcolumn);

            if (gridView1.Columns["IsSelected"] != null)
            {
                // Đặt cột Check ở vị trí hiển thị đầu tiên (Index 0)
                // Thao tác này sẽ tự động đẩy các cột khác (bao gồm AutoID) lùi lại một vị trí.
                gridView1.Columns["IsSelected"].VisibleIndex = 0;

                // Tùy chọn: Set chiều rộng tối thiểu và căn giữa cho cột Check
                gridView1.Columns["IsSelected"].Width = 60;
                gridView1.Columns["IsSelected"].OptionsColumn.FixedWidth = true;

                // Tùy chọn: Đảm bảo cột Check luôn hiển thị và không thể kéo đi.
                gridView1.Columns["IsSelected"].OptionsColumn.AllowMove = false;
            }
        }

        private void gridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            // chặn không cho vẽ check tại dòng filter

            if (e.Column.FieldName == "IsSelected" && gridView1.IsFilterRow(e.RowHandle))
            {
                e.Handled = true;
            }
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {

            // ngăn không cho bật cell check tại dòng filter

            if (gridView1.IsFilterRow(gridView1.FocusedRowHandle))
            {
                e.Cancel = true;
            }
        }


        private void gridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "Edit" && e.RepositoryItem.Name == "repItemBtnEdit")
            {
                // gắn sự kiện cho nút Edit

                ((DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit)e.RepositoryItem).ButtonClick += Edit_ButtonClick;

            } // gắn sự kiện cho nút Delete
            else if ((e.Column.FieldName == "Delete" && e.RepositoryItem.Name == "repItemBtnDelete"))
            {
                ((DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit)e.RepositoryItem).ButtonClick += Delete_ButtonClick;
            }

            // Ẩn ô check tại dòng lọc
            //if (e.Column.FieldName == "IsSelected") //"IsSelected")
            //{
            //    // Nếu là dòng lọc thì không dùng checkbox
            //    if (gridView1.IsFilterRow(e.RowHandle)) //(e.RowHandle == DevExpress.XtraGrid.GridControl.AutoFilterRowHandle)
            //    {
            //        e.RepositoryItem = null;
            //    }
            //}

        }

        private void btnLoadDataUser_Click(object sender, EventArgs e)
        {
            frmLoadDataHorizontal frm_horizontal = new frmLoadDataHorizontal();
            frm_horizontal.Show();
        }
    }
}
