using DevExpress.Utils;
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
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ASPData;
using ASPData.ASPDAO;

namespace ASPProject.SkillMap
{
    public partial class frmLoadDataHorizontal : XtraForm
    {
        private readonly ASPData.ASPData _aspData = new ASPData.ASPData();
        private readonly SkillMapDAO _skillMapDao = new SkillMapDAO();

        // fix #9: cache connection string
        private readonly string constring;
        private SqlDataAdapter DATA;
        private DataTable dt;
        public string UseNameLogin;

        public frmLoadDataHorizontal()
        {
            InitializeComponent();
            constring = _aspData.ASPDecrypt(configDatabase.CONNECTION_STRINGS);

            UseNameLogin = SessionMangerSkillMap.Username;

            Show_Data();
            update_Actual_Target();
            Tong_KyNangCanDaoTao(gridViewHorizontal);
            CalculateTotalsByLine3(UseNameLogin);
            SetColor_Horizontal();

            gridViewHorizontal.OptionsView.ColumnAutoWidth = false;
            gridViewHorizontal.Appearance.HeaderPanel.Options.UseFont = true;
            gridViewHorizontal.HorzScrollVisibility = ScrollVisibility.Auto;
            gridViewHorizontal.OptionsView.ShowGroupPanel = false;
            gridViewHorizontal.OptionsView.ShowAutoFilterRow = true;
            gridViewHorizontal.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;


            if (gridViewHorizontal.Columns["Actual Total"] != null)
                gridViewHorizontal.Columns["Actual Total"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            if (gridViewHorizontal.Columns["Target Total"] != null)
                gridViewHorizontal.Columns["Target Total"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            if (gridViewHorizontal.Columns["Số Kỹ Năng Cần Đào Tạo"] != null)
                gridViewHorizontal.Columns["Số Kỹ Năng Cần Đào Tạo"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            if (gridViewHorizontal.Columns["AutoID"] != null)
                gridViewHorizontal.Columns["AutoID"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            CenterAlignColumnData(gridViewHorizontal, "Số Kỹ Năng Cần Đào Tạo");
            SetUp_DateEdit();
        }

        private void GridViewHorizontal_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
 
            if (e.Column != null && e.Column.Caption.StartsWith("Target", StringComparison.OrdinalIgnoreCase))
            {
                e.Appearance.BackColor = System.Drawing.Color.Yellow;
                e.Appearance.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void frmLoadDataHorizontal_Load(object sender, EventArgs e)
        {
        }



        private void SetUp_DateEdit()
        {
            DateTime TODAY = DateTime.Now;

            dateEditDate.DateTime = TODAY;
            dateEditDate.EditValue = TODAY;


            // 1. Định dạng hiển thị và nhập liệu chỉ có Năm
            dateEditDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            dateEditDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";

            dateEditDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            dateEditDate.Properties.EditFormat.FormatString = "dd-MM-yyyy";

            dateEditDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            dateEditDate.Properties.Mask.UseMaskAsDisplayFormat = true;

        }






        private void Display_TotalRecord(GridView GV)
        {
            GridColumn column = (GridColumn)GV.Columns["Tên"];
            column.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            column.SummaryItem.DisplayFormat = "Total Record: {0}";

            GV.OptionsView.ShowFooter = true;
            GV.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
        }



        public void CenterAlignColumnData(GridView gridView, string columnName)
        {
            GridColumn targetColumn = gridView.Columns[columnName];

            if (targetColumn != null)
            {
                targetColumn.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
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




        public void CalculateTotalsByLine3(string UserName)
        {

            if (UserName != "WHC" &&  UserName != "WHA" && UserName != "WHB" && UserName != "WHD" && UserName != "PILOT" && UserName != "USBB" && UserName != "USBC" && UserName != "WH9")
            {
                GridView view = gridControlHorizontal.MainView as GridView;
                if (view != null)
                {
                    view.PostEditor(); 
                    view.UpdateCurrentRow(); 
                }

                DataTable DT = gridControlHorizontal.DataSource as DataTable;
                if (DT == null) return;

                // fix #4: GroupBy 1 lần, lookup bằng Dictionary O(1) thay vì FirstOrDefault trong vòng lặp O(N^2)
                var summary = DT.AsEnumerable()
                    .GroupBy(r => r.Field<string>("Line")?.Trim() ?? "")
                    .ToDictionary(
                        g => g.Key,
                        g => new
                        {
                            SumActual = g.Sum(r =>
                            {
                                string val = r["Actual Total"]?.ToString();
                                int KQ;
                                return int.TryParse(val, out KQ) ? KQ : 0;
                            }),
                            SumTarget = g.Sum(r =>
                            {
                                string VAL = r["Target Total"]?.ToString();
                                int KQ;
                                return int.TryParse(VAL, out KQ) ? KQ : 0;
                            })
                        });

                foreach (DataRow row in DT.Rows)
                {
                    string currentLine = row["Line"]?.ToString()?.Trim() ?? "";
                    if (summary.TryGetValue(currentLine, out var match))
                    {
                        row["Total_Line"] = match.SumActual;
                        row["Total_Target"] = match.SumTarget;
                    }
                }

                gridControlHorizontal.RefreshDataSource();
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

                    CHECK_ID = configDatabase.IsProductionUser(UseNameLogin);

                    if (CHECK_ID == true ) 
                    {
                        // Lấy ra  LineID từ EmpID đăng nhập
                        using (SqlCommand CMD1 = new SqlCommand("sp_ShowLineId", con))
                        {
                            CMD1.CommandType = CommandType.StoredProcedure;
                            CMD1.Parameters.AddWithValue("@EmpID", UseNameLogin);
                            KQ = CMD1.ExecuteScalar();
                        }

                        KQ_LineID = string.IsNullOrEmpty(KQ.ToString()) ? "" : KQ.ToString();

                        using (SqlCommand CMD = new SqlCommand("sp_ShowData_Horizontal_WorkerLine", con)) 
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

                                gridViewHorizontal.PopulateColumns();

                                gridViewHorizontal.BestFitColumns();

                                Display_TotalRecord(gridViewHorizontal);


                                // Ẩn các control
                                labelControl1.Visible = false;
                                dateEditDate.Visible = false;
                                btnImportToDate.Visible = false;
                                btnExportMonthYear.Visible = false;
                            }
                        }

                        // Ẩn nút Excel khi User là LineSx
                        btnExportExcelHorizontal.Visible = false;
                    }
                    else // UserName KHÔNG thuộc BP.sản xuất
                    {
                        using (SqlCommand CMD = new SqlCommand("sp_ShowData_Horizontal_Date", con)) 
                        {
                            CMD.CommandType = CommandType.StoredProcedure;
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

                                gridViewHorizontal.PopulateColumns();

                                gridViewHorizontal.BestFitColumns();

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

        //----------------------------------------|Các hàm xây dựng thêm|----------------------------------------------- 



        // HÀM SET MÀU HEADER CỘT SAU KHI HIỂN THỊ :
        // fix #3: màu header Target đã được vẽ bởi GridViewHorizontal_CustomDrawColumnHeader (sự kiện OnCustomDrawColumnHeader).
        // Vòng lặp cũ duyệt theo RowCount chỉ để set màu column => dư thừa + O(N x cols). Thay bằng 1 lượt duyệt column.
        private void SetColor_Horizontal()
        {
            foreach (GridColumn col_Header in gridViewHorizontal.Columns)
            {
                if (col_Header.FieldName.StartsWith("Target", StringComparison.OrdinalIgnoreCase))
                {
                    col_Header.AppearanceHeader.BackColor = System.Drawing.Color.Yellow;
                }
            }
        }
        

        private void gridViewHorizontal_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            var Gview = sender as GridView;

            // refactor #6: dùng dict chung thay vì khai báo 14 cặp lặp lại
            if (configDatabase.SkillMapKnToTarget.TryGetValue(e.Column.FieldName, out string ColTarget))
            {
                string colKN = e.Column.FieldName;


                int valueKN = 0;
                int valueTarget = 0;


                object v1_KN = Gview.GetRowCellValue(e.RowHandle, colKN);
                object v2_Target = Gview.GetRowCellValue(e.RowHandle, ColTarget);

                int.TryParse(Convert.ToString(v1_KN), out valueKN);
                int.TryParse(Convert.ToString(v2_Target), out valueTarget);

                if (valueKN < valueTarget)
                {
                    e.Appearance.BackColor = System.Drawing.Color.LightPink;
                }

            }

        }



        private void Insert_DB_MONTH(string Line,int Totaltarget,int ActualSum)
        {
            int TONG_SO_KN = Totaltarget - ActualSum;
            DateTime DATE_SKILL = (DateTime)(dateEditDate.EditValue);
            DateTime  CreateDate = (DateTime)(dateEditDate.EditValue);
            string UserCreate = UseNameLogin;


            using (SqlConnection CON = new SqlConnection(constring))
            {
                CON.Open();

                using (SqlCommand CMD = new SqlCommand("sp_ASP_INSERT_SKILL_MONTH", CON))
                {
                    CMD.CommandType = CommandType.StoredProcedure;
                    CMD.Parameters.AddWithValue("@LineID", Line);
                    CMD.Parameters.AddWithValue("@TargetSum", Totaltarget);
                    CMD.Parameters.AddWithValue("@ActualSum", ActualSum);
                    CMD.Parameters.AddWithValue("@NumberOfSkills", TONG_SO_KN);
                    CMD.Parameters.AddWithValue("@DateSkill", DATE_SKILL);
                    CMD.Parameters.AddWithValue("@CreateDate", CreateDate);
                    CMD.Parameters.AddWithValue("@UserCreate", UserCreate);

                    CMD.ExecuteNonQuery();
                }
            }
        }



      






        //.1.Insert theo target_Actual
        public void ProcessAndInsertSkillData(string colKN, string colTarget)
        {
            int TotalActual = 0;
            int TotalTarget = 0;
            int TotalNumberOfSkills = 0;

            object valActual;
            object valTarget;

            try
            {
                
                for (int i = 0; i < gridViewHorizontal.RowCount; i++)
                {
                    valActual = gridViewHorizontal.GetRowCellValue(i, colKN);
                    valTarget = gridViewHorizontal.GetRowCellValue(i, colTarget);

                    double ActualValue = (valActual != null && valActual != DBNull.Value) ? Convert.ToDouble(valActual) : 0;
                    double ActualTarget = (valTarget != null && valTarget != DBNull.Value) ? Convert.ToDouble(valTarget) : 0;

                    //GT >= 75 thì cộng 1
                    if (ActualValue >= 75) TotalActual++;
                    if (ActualTarget >= 75) TotalTarget++;
                }

                TotalNumberOfSkills = TotalTarget - TotalActual;


                using (SqlConnection Con = new SqlConnection(constring))
                {
                    Con.Open();

                    using (SqlCommand CMD = new SqlCommand("sp_ASP_INSERT_SKILL_MONTH_TOTAL", Con))
                    {
                        
                        CMD.CommandType = CommandType.StoredProcedure;
                        CMD.Parameters.AddWithValue("@LineID", "Total");
                        CMD.Parameters.AddWithValue("@TotalTarget", TotalTarget);
                        CMD.Parameters.AddWithValue("@TotalActual", TotalActual);
                        CMD.Parameters.AddWithValue("@TotalNumberOfSkills", TotalNumberOfSkills);
                        CMD.Parameters.AddWithValue("Skill", colKN.Trim());
                        CMD.Parameters.AddWithValue("@CreateDate", DateTime.Now.ToString());
                        CMD.Parameters.AddWithValue("@UserCreate", UseNameLogin);

                        CMD.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi hàm Insert : "+ex.Message);
            }
        }



        //.2. Hàm thêm theo mảng
        private void Insert_Array_SkillMonth()
        {
            try
            {
                // refactor #6: duyệt dict chung thay vì khai báo lại 14 cặp
                foreach (var item in configDatabase.SkillMapKnToTarget)
                {
                    ProcessAndInsertSkillData(item.Key, item.Value);
                }

                MessageBox.Show("Import 14 kỹ năng thành công!");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi Array Insert : " + ex.Message);
            }

          
        }






        //private void Insert_DB_Skill_Month(GridView Gv)








        private void btnImportToDate_Click(object sender, EventArgs e)
        {
            /*
            try
            {
                // tạo bước đánh dấu
                HashSet<string> ds_List = new HashSet<string>();

                for (int i = 0; i < gridViewHorizontal.RowCount; i++)
                {
                    string LineID = gridViewHorizontal.GetRowCellValue(i, "Line")?.ToString();


                    //kiểm tra nếu line chưa xử lý thì bắt đầu insert
                    if (!string.IsNullOrEmpty(LineID) && !ds_List.Contains(LineID))
                    {
                        int TotalLine = Convert.ToInt32(gridViewHorizontal.GetRowCellValue(i, "Total_Line"));
                        int TotalTarget = Convert.ToInt32(gridViewHorizontal.GetRowCellValue(i, "Total_Target"));

                        //HÀM INSERT
                        Insert_DB_MONTH(LineID, TotalTarget, TotalLine);

                        // Đánh dấu line này đã xử lý
                        ds_List.Add(LineID);
                    }
                }
                XtraMessageBox.Show("Import Success", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error import : "+ ex.Message);
            }
            */

            try
            {

                // tạo bước đánh dấu
                HashSet<string> ds_List = new HashSet<string>();
                int tong_TotalActual = 0;
                int tong_TotalTarget = 0;

                for (int i = 0; i < gridViewHorizontal.RowCount; i++)
                {
                    string LineID = gridViewHorizontal.GetRowCellValue(i, "Line")?.ToString();


                    //kiểm tra nếu line chưa xử lý thì bắt đầu insert
                    if (!string.IsNullOrEmpty(LineID) && !ds_List.Contains(LineID))
                    {
                        int TotalLine = Convert.ToInt32(gridViewHorizontal.GetRowCellValue(i, "Total_Line"));
                        int TotalTarget = Convert.ToInt32(gridViewHorizontal.GetRowCellValue(i, "Total_Target"));

                        tong_TotalActual += TotalLine;
                        tong_TotalTarget += TotalTarget;

                        Insert_DB_MONTH(LineID, TotalTarget, TotalLine);

                        ds_List.Add(LineID);
                    }
                }


               //--Thêm Target-Actual Bảng 1
                Insert_DB_MONTH("Total", tong_TotalTarget, tong_TotalActual);

                //--Thêm Total Target-Actual Bảng 2 
                Insert_Array_SkillMonth();


                XtraMessageBox.Show("Import Success", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error import : " + ex.Message);
            }

        }


        private void btnExportMonthYear_Click(object sender, EventArgs e)
        {
            frmLoadSkillDate frmskill = new frmLoadSkillDate();
            frmskill.ShowDialog();


        }

        private void gridControlHorizontal_Click(object sender, EventArgs e)
        {

        }


        private void btnExportTotalSkillMonth_Click(object sender, EventArgs e)
        {
            frmLoadSkillTotal frmskillTotal = new frmLoadSkillTotal();
            frmskillTotal.ShowDialog();
        }



    }
}
