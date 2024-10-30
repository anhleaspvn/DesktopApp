using ASPData;
using ASPData.ASPDAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ASPProject.LineProdStatistic
{
    public partial class frmProductionPlanTable : DevExpress.XtraEditors.XtraForm
    {
        public string userName;

        public frmMain frm;
        public delegate void _deDongTab();
        public _deDongTab deDongTab;
        public int iNgonNgu;

        private DataTable dtAttMonth = new DataTable();
        private BindingSource bdsAttMonth = new BindingSource();
        private ProdStatisticDAO attDao = new ProdStatisticDAO();
        private SQLHelper _sqlHelper = new SQLHelper();

        private DateTime FromDate = DateTime.Now;
        private DateTime ToDate = DateTime.Now;

        public frmProductionPlanTable()
        {
            InitializeComponent();

            dtFromDate.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtToDate.EditValue = DateTime.Now.Date;

            this.Load += FrmProductionPlanTable_Load;
            this.btFilter.Click += BtFilter_Click;
            this.gridAttMonthView.RowStyle += GridAttMonthView_RowStyle;
            this.gridAttMonthView.RowCellStyle += GridAttMonthView_RowCellStyle;
            this.btExport.Click += BtExport_Click;
        }

        private void BtExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel|*.xlsx";
            saveFileDialog1.Title = "Save an File";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                gridAttMonthView.ExportToXlsx(saveFileDialog1.FileName);
            }
        }

        private void FrmProductionPlanTable_Load(object sender, EventArgs e)
        {
            BtFilter_Click(null, null);
        }

        private void BtFilter_Click(object sender, EventArgs e)
        {
            FromDate = Convert.ToDateTime(dtFromDate.EditValue);
            ToDate = Convert.ToDateTime(dtToDate.EditValue);

            FillData();
        }

        private void FillData()
        {

            var dicParams = new Dictionary<string, object>()
            {
                {"@EmpID", userName }
            };

            string LineID = (string)_sqlHelper.ExecQuerySacalar("SELECT ISNULL(LineID, '') FROM ASPEmployee WHERE EmpId = @EmpID", dicParams);

            dtAttMonth = attDao.GetProductionPlanning(FromDate, ToDate, LineID, userName);
            bdsAttMonth.DataSource = dtAttMonth;

            gridAttMonth.DataSource = bdsAttMonth;

            gridAttMonthView.BestFitColumns();
        }

        private void GridAttMonthView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            string prodStatus = Convert.ToString(gridAttMonthView.GetRowCellValue(e.RowHandle, "ProdStatus"));

            if (prodStatus == "Hoàn thành")
            {
                e.Appearance.ForeColor = Color.Gray;
            }
            if (prodStatus == "Chưa sản xuất")
            {
                e.Appearance.ForeColor = Color.DarkGreen;
            }
            if (prodStatus == "Đang sản xuất")
            {
                e.Appearance.ForeColor = Color.Black;
            }
        }

        private void GridAttMonthView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.Name == "Productivity")
            {
                if (Convert.ToDouble(e.CellValue) >= 100)
                    e.Appearance.ForeColor = Color.Blue;
                else
                    e.Appearance.ForeColor = Color.Red;
            }
        }
    }
}
