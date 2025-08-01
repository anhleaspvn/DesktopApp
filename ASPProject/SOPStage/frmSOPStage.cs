using ASPData;
using ASPData.ASPDAO;
using ASPData.ASPDTO;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Collections.Generic;
using System.Linq;

namespace ASPProject.SOPStage
{
    public partial class frmWOSOP : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration
        public string userName, lineID;
       
        public frmMain frm;
        public delegate void _deDongTab();
        public _deDongTab deDongTab;
        public int iNgonNgu, curIndex, curIndexDetail;
        private DataRow drHeaderCur, drDetailCur;
        private DataTable dtWOSOP = new DataTable();
        BindingSource bdsWOSOP = new BindingSource();

        private DataTable dtWOSOPDetail = new DataTable();
        BindingSource bdsWOSOPDetail = new BindingSource();

        WOSOPDTO woDto = new WOSOPDTO();
        WOSOPDAO woDao = new WOSOPDAO();

        private readonly SQLHelper _sqlHelper = new SQLHelper();
        #endregion

        #region Load
        public frmWOSOP()
        {
            InitializeComponent();

            this.Load += FrmWOSOP_Load;
  
            this.gridWOSOPView.RowClick += GridWOSOPView_RowClick;
            this.gridSOPStageView.RowClick += GridSOPStageView_RowClick;

            bdsWOSOP.CurrentChanged += BdsWOSOP_CurrentChanged;
            btImportExcel.Click += BtImportExcel_Click;
            btExport.Click += BtExport_Click;
            btDelete.Click += BtDelete_Click;
        }

        private DataTable LineIDData()
        {
            DataTable dt = new DataTable();

            dt = _sqlHelper.ExecProcedureDataAsDataTable("sp_ASPGetAllLineID");

            return dt;
        }

        private void FrmWOSOP_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            DataTable dtSOP = new DataTable();
            dtSOP = _sqlHelper.ExecQueryDataAsDataTable("SELECT * FROM ASPWOSOPDetail");
            gridSOP.DataSource = dtSOP;

            woDto.LineID = lineID;
            woDto.Username = userName;
        
            woDto.CreatedBy = userName;
            woDto.CreatedDate = DateTime.Now;
            woDto.LastModifiedBy = string.Empty;
            woDto.LastModifiedDate = Convert.ToDateTime("1900-01-01");

            dtWOSOP = woDao.GetWOSOP(woDto);

            bdsWOSOP.DataSource = dtWOSOP;
            gridWOSOP.DataSource = bdsWOSOP;

            if (drHeaderCur != null)
            {
                drHeaderCur = ((DataRowView)bdsWOSOP.Current).Row;

                FillDataDetail(Convert.ToString(drHeaderCur["ProductID"]));
            }    
           
        }

        private void FillDataDetail(string ProductID)
        {
            if (ProductID == string.Empty)
                return;

            woDto.ProductID = ProductID;

            dtWOSOPDetail = woDao.GetWOSOPDetail(woDto);

            bdsWOSOPDetail.DataSource = dtWOSOPDetail;
            gridSOPStage.DataSource = bdsWOSOPDetail;
        }
        #endregion

        #region Event
        private void GridWOSOPView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            drHeaderCur = gridWOSOPView.GetDataRow(e.RowHandle);
            curIndex = e.RowHandle;
        }

        private void GridSOPStageView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            drDetailCur = gridSOPStageView.GetDataRow(e.RowHandle);
            curIndexDetail = e.RowHandle;
        }

        private void BdsWOSOP_CurrentChanged(object sender, EventArgs e)
        {
            drHeaderCur = ((DataRowView)bdsWOSOP.Current).Row;

            if (drHeaderCur == null)
                return;

            FillDataDetail(Convert.ToString(drHeaderCur["ProductID"]));
        }

        private void BtExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel|*.xlsx";
            saveFileDialog1.Title = "Save an File";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                gridSOPView.ExportToXlsx(saveFileDialog1.FileName);
            }
        }

        private void BtDelete_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có chắc chắn muốn xoá SOP này không ?", "Thông  báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataRow drRow = ((DataRowView)bdsWOSOP.Current).Row;
                if (drRow == null) 
                    return;

                string productID = (string)drRow["ProductID"];

                var dicParams = new Dictionary<string, object>()
                {
                    { "@ProductID", productID }
                };

                _sqlHelper.ExecQueryNonData("DELETE FROM ASPWOSOPDetail WHERE ProductID = @ProductID", dicParams);

                FillData();
            }
        }

        private void BtImportExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openExcel = new OpenFileDialog();
            openExcel.Title = "Open Excel File";
            openExcel.Filter = "XLSX files|*.xlsx";
            openExcel.InitialDirectory = @"C:\";

            if (openExcel.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //
                    List<string> arrProd = new List<string>();
                    ASPExcelDataProcess.ASPExcelDataProcess excel = new ASPExcelDataProcess.ASPExcelDataProcess();
                    DataTable dtExcel = new DataTable();
                    dtExcel = excel.ReadDataFromExcelFile(openExcel.FileName, "Sheet1", "A1:G10000");
                 
                    foreach (DataRow dr in dtExcel.Rows)
                    {
                        string ProductID = Convert.ToString(dr["ProductID"]);

                        if (!arrProd.Contains(ProductID))
                        {
                            _sqlHelper.ExecQueryNonData("DELETE FROM ASPWOSOPDetail WHERE ProductID = '" + ProductID + "'");
                            arrProd.Add(Convert.ToString(dr["ProductID"]));
                        }
                           
                        woDto.ProductID = Convert.ToString(dr["ProductID"]);
                        woDto.StageID = Convert.ToString(dr["StageID"]);
                        woDto.StageName = Convert.ToString(dr["StageName"]);
                        woDto.MaterialID = Convert.ToString(dr["MaterialID"]);
                        woDto.CycleTime = Convert.ToDouble(dr["CycleTime"]);
                        woDto.UsageBom = Convert.ToDouble(dr["UsageBom"]);
                        woDto.ManPower = Convert.ToDouble(dr["ManPower"]);
                        woDto.CreatedBy = userName;
                        woDto.CreatedDate = DateTime.Now;

                        woDao.ImportExcelSOP(woDto);
                    }    

                    XtraMessageBox.Show("Import dữ liệu thành công.");

                    FillData();
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
