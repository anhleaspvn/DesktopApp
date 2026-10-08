using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Filtering.Templates;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ASPData;
using ASPData.ASPDAO;

namespace ASPProject.AppTemplateSkillMap
{
    public partial class frmAddStaff : XtraForm
    {
        private readonly ASPData.ASPData _aspData = new ASPData.ASPData();
        private readonly SkillMapDAO _skillMapDao = new SkillMapDAO();

        // fix #9: cache connection string
        private readonly string constring;
        DataTable dt;
        OleDbDataAdapter DA;
        SqlDataAdapter DATA;


        // Khai báo Delegate: Định nghĩa "chữ ký" của hàm sẽ được gọi
        public delegate void DataAddEventHandler();

        // Khai báo Event: Dùng để kích hoạt thông báo
        public event DataAddEventHandler DataAdd;

        public configDatabase DB;


        public frmAddStaff()
        {
            InitializeComponent();
            constring = _aspData.ASPDecrypt(configDatabase.CONNECTION_STRINGS);
        }

        private void frmAddStaff_Load(object sender, EventArgs e)
        {
            btnImportFile.Enabled = false;
        }

        // hàm kích hoạt sự kiện
        protected virtual void OnDataAdded()
        {
            DataAdd?.Invoke();
        }


        private void set_caption_column()
        {

            gridView1.Columns["EmpID"].Caption = "EmpID";   
            gridView1.Columns["EmpName"].Caption = "EmpName";
            gridView1.Columns["Position"].Caption = "Position";   
            gridView1.Columns["Direct_Indirect"].Caption = "Direct_Indirect";
            gridView1.Columns["LineID"].Caption = "LineID";   
            gridView1.Columns["SkillID"].Caption = "SkillID";
            gridView1.Columns["PercentLV"].Caption = "PercentLV";   
            gridView1.Columns["DateReachedLV0"].Caption = "DateReachedLV0";
            gridView1.Columns["DateReachedLV1"].Caption = "DateReachedLV1";   
            gridView1.Columns["DateReachedLV2"].Caption = "DateReachedLV2";
            gridView1.Columns["DateReachedLV3"].Caption = "DateReachedLV3";   
            gridView1.Columns["DateReachedLV4"].Caption = "DateReachedLV4";
            gridView1.Columns["EmpStatus"].Caption = "EmpStatus";
            gridView1.Columns["StartDate"].Caption = "StartDate";   
            gridView1.Columns["Seniority"].Caption = "Seniority";
            gridView1.Columns["GroupLine"].Caption = "GroupLine";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnImportFile_Click(object sender, EventArgs e)
        {
            //DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)gridAddStaff.MainView;
            GridView view = (GridView)gridAddStaff.MainView;

            int rowhandle = 0;
            object EmpIDD = gridView1.GetRowCellValue(rowhandle, "EmpID");


            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("sp_ASP_ADD_ID", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpID", EmpIDD.ToString());
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count > 0)
                    {
                        XtraMessageBox.Show($"Employee ID {EmpIDD} already exists : ", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close();
                    }
                    else
                    {
                        //thêm nhân viên mới
                        try
                        {
                            // fix #1 + #2: import toàn bộ trong 1 connection + 1 transaction (thay vì từng dòng)
                            _skillMapDao.AddAllBulk(dt);
                            XtraMessageBox.Show("Import Data Success!");

                            // kích hoạt sự kiện để thông báo form Cha
                            OnDataAdded();
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("Error Import : " + ex.Message, "Error Import File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }


                }
            }



        }

        private void btnChooseFile_Click(object sender, EventArgs e)
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
                        gridAddStaff.DataSource = dt;


                        foreach (DevExpress.XtraGrid.Columns.GridColumn col in gridView1.Columns)
                        {
                            col.Caption = col.FieldName;  // giữ nguyên tên gốc
                        }


                        // tự động chỉnh độ rộng cột của lưới
                        gridView1.BestFitColumns();

                        // Gắn sự kiện CustomUnboundColumnData
                        gridView1.CustomUnboundColumnData += GridView1_CustomUnboundColumnData;
                        gridView1.RefreshData();

                        btnImportFile.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error Import : " + ex.Message, "Error Import File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            // throw new NotImplementedException();
            if (e.Column.FieldName == "AutoID" && e.IsGetData)
            {
                e.Value = e.ListSourceRowIndex + 1;
            }
        }

        private void gridView1_ColumnChanged(object sender, EventArgs e)
        {
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gridView1.Columns)
            {
                col.Caption = col.FieldName;  // giữ nguyên tên gốc
            }
        }
    }
}
