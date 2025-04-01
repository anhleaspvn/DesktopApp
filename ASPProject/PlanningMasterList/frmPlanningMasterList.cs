using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ASPData.ASPDTO;
using ASPData.ASPDAO;
using ASPData.PlanningDTO;
using DevExpress.XtraEditors;
using ASPData;

namespace ASPProject.PlaningMasterList
{
    public partial class frmPlanningMasterList : DevExpress.XtraEditors.XtraForm
    {
        #region declaration
        public string userName, lineID;

        public frmMain frm;
        public delegate void _deDongTab();
        public _deDongTab deDongTab;
        public int iNgonNgu, curIndex, curIndexDetail;

        BindingSource bdsPlanningMonth = new BindingSource();
        DataTable dtPlanningMonth = new DataTable();

        BindingSource bdsPlanningDay = new BindingSource();
        DataTable dtPlanningDay = new DataTable();

        PlanningDTO planDto = new PlanningDTO();
        PlanningDAO planDao = new PlanningDAO();

        private readonly SQLHelper _sqlHelper = new SQLHelper();
        #endregion

        #region constructor
        public frmPlanningMasterList()
        {
            InitializeComponent();

            this.Load += FrmPlanningMasterList_Load;
            btImportMonth.Click += BtImportMonth_Click;
            btImportDay.Click += BtImportDay_Click;
        }
        #endregion

        #region load
        private void FrmPlanningMasterList_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            planDto.FromDate = DateTime.Now;
            planDto.ToDate = DateTime.Now;

            dtPlanningDay = planDao.GetPlanningMasterListByDay(planDto);
            bdsPlanningDay.DataSource = dtPlanningDay;
            
            gridPlanByDay.DataSource = bdsPlanningDay;

            dtPlanningMonth = planDao.GetPlanningMasterListByMonth(planDto);
            bdsPlanningMonth.DataSource = dtPlanningMonth;

            gridPlanByMonth.DataSource = bdsPlanningMonth;  
        }
        #endregion

        #region event
        private void BtImportMonth_Click(object sender, EventArgs e)
        {
            OpenFileDialog openExcel = new OpenFileDialog();
            openExcel.Title = "Open Excel File";
            openExcel.Filter = "XLSX files|*.xlsx";
            openExcel.InitialDirectory = @"C:\";

            if (openExcel.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    List<string> arrYearMonth = new List<string>();
                    ASPExcelDataProcess.ASPExcelDataProcess excel = new ASPExcelDataProcess.ASPExcelDataProcess();
                    DataTable dtExcel = new DataTable();
                    dtExcel = excel.ReadDataFromExcelFile(openExcel.FileName, "Sheet1", "A1:E10000");

                    foreach (DataRow dr in dtExcel.Rows)
                    {
                        int Year = Convert.ToInt32(dr["Year"]);
                        int Month = Convert.ToInt32(dr["Month"]);
                        string YearMonth = Year.ToString() + Month.ToString();

                        if (!arrYearMonth.Contains(YearMonth))
                        {
                            _sqlHelper.ExecQueryNonData("DELETE FROM ASPPlanningDataByMonth WHERE [Year] = '" + Year.ToString() + "' AND [Month] = '" + Month.ToString() + "'");
                            arrYearMonth.Add(Year.ToString() + Month.ToString());
                        }

                        planDto.Year = Year;
                        planDto.Month = Month;
                        planDto.LineID = Convert.ToString(dr["LineID"]);
                        planDto.FGsPlan = Convert.ToDouble(dr["FGsPlan"]);
                        planDto.MPsPlan = Convert.ToDouble(dr["MPsPlan"]);

                        planDao.PlanningImportByMonth(planDto);
                    }

                    XtraMessageBox.Show("Import dữ liệu thành công.");

                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void BtImportDay_Click(object sender, EventArgs e)
        {
            OpenFileDialog openExcel = new OpenFileDialog();
            openExcel.Title = "Open Excel File";
            openExcel.Filter = "XLSX files|*.xlsx";
            openExcel.InitialDirectory = @"C:\";

            if (openExcel.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    List<string> arrYearMonth = new List<string>();
                    ASPExcelDataProcess.ASPExcelDataProcess excel = new ASPExcelDataProcess.ASPExcelDataProcess();
                    DataTable dtExcel = new DataTable();
                    dtExcel = excel.ReadDataFromExcelFile(openExcel.FileName, "Sheet2", "A1:AL10000");

                    foreach (DataRow dr in dtExcel.Rows)
                    {
                        int Year = Convert.ToInt32(dr["Year"]);
                        int Month = Convert.ToInt32(dr["Month"]);
                        string YearMonth = Year.ToString() + Month.ToString();

                        if (!arrYearMonth.Contains(YearMonth))
                        {
                            _sqlHelper.ExecQueryNonData("DELETE FROM ASPPlaningDataImport WHERE [Year] = '" + Year.ToString() + "' AND [Month] = '" + Month.ToString() + "'");
                            arrYearMonth.Add(Year.ToString() + Month.ToString());
                        }

                        planDto.Year = Year;
                        planDto.Month = Month;
                        planDto.WODocNo = Convert.ToString(dr["WODocNo"]);
                        planDto.ProductID = Convert.ToString(dr["ProductID"]);
                        planDto.LineID = Convert.ToString(dr["LineID"]);
                        planDto.ORDG = Convert.ToDouble(dr["ORDG"]);
                        planDto.ORVN = Convert.ToDouble(dr["ORVN"]);
                        planDto.D1 = Convert.ToDouble(dr["1"]);
                        planDto.D2 = Convert.ToDouble(dr["2"]);
                        planDto.D3 = Convert.ToDouble(dr["3"]);
                        planDto.D4 = Convert.ToDouble(dr["4"]);
                        planDto.D5 = Convert.ToDouble(dr["5"]);
                        planDto.D6 = Convert.ToDouble(dr["6"]);
                        planDto.D7 = Convert.ToDouble(dr["7"]);
                        planDto.D8 = Convert.ToDouble(dr["8"]);
                        planDto.D9 = Convert.ToDouble(dr["9"]);
                        planDto.D10 = Convert.ToDouble(dr["10"]);
                        planDto.D11 = Convert.ToDouble(dr["11"]);
                        planDto.D12 = Convert.ToDouble(dr["12"]);
                        planDto.D13 = Convert.ToDouble(dr["13"]);
                        planDto.D14 = Convert.ToDouble(dr["14"]);
                        planDto.D15 = Convert.ToDouble(dr["15"]);
                        planDto.D16 = Convert.ToDouble(dr["16"]);
                        planDto.D17 = Convert.ToDouble(dr["17"]);
                        planDto.D18 = Convert.ToDouble(dr["18"]);
                        planDto.D19 = Convert.ToDouble(dr["19"]);
                        planDto.D20 = Convert.ToDouble(dr["20"]);
                        planDto.D21 = Convert.ToDouble(dr["21"]);
                        planDto.D22 = Convert.ToDouble(dr["22"]);
                        planDto.D23 = Convert.ToDouble(dr["23"]);
                        planDto.D24 = Convert.ToDouble(dr["24"]);
                        planDto.D25 = Convert.ToDouble(dr["25"]);
                        planDto.D26 = Convert.ToDouble(dr["26"]);
                        planDto.D27 = Convert.ToDouble(dr["27"]);
                        planDto.D28 = Convert.ToDouble(dr["28"]);
                        planDto.D29 = Convert.ToDouble(dr["29"]);
                        planDto.D30 = Convert.ToDouble(dr["30"]);
                        planDto.D31 = Convert.ToDouble(dr["31"]);

                        planDao.PlanningImportByDay(planDto);
                    }

                    XtraMessageBox.Show("Import dữ liệu thành công.");

                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
        #endregion
    }
}
