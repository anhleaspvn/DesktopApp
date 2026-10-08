using ASPData;
using ASPData.ASPDAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ASPProject.LineProdStatistic
{
    public partial class frmLineProductivity : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dtProdLine = new DataTable();
        BindingSource bdsProdLine = new BindingSource();

        public string userName;

        public frmMain frm;
        public delegate void _deDongTab();
        public _deDongTab deDongTab;
        public int iNgonNgu;

        private DateTime FromDate = DateTime.Now;
        private DateTime ToDate = DateTime.Now;
        private SQLHelper _sqlHelper = new SQLHelper();

        private ProdStatisticDAO prodDao = new ProdStatisticDAO();
        public frmLineProductivity()
        {
            InitializeComponent();
            dtFromDate.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtToDate.EditValue = DateTime.Now;

            gridLineProView.RowCellStyle += GridLineProView_RowCellStyle;
            gridLineProView.RowClick += GridLineProView_RowClick;

            this.Load += FrmLineProductivity_Load;
            btFilter.Click += BtFilter_Click;
            btDefectTable.Click += BtDefectTable_Click;
           
        }

        private void GridLineProView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            object value = gridLineProView.GetRowCellValue(e.RowHandle, "Bold");

            if (value != DBNull.Value && Convert.ToInt32(value) == 1)
            {
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }
        }

        private void GridLineProView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow drLCur = ((DataRowView)bdsProdLine.Current).Row;
            // Safe nullable extraction (won't throw on DBNull)
            DateTime statisticDate = drLCur.Field<DateTime>("StatisticDate");
            double defectQuantity = Convert.ToDouble(drLCur["DefectQuantity"]); 

            frmLineDefectTable frm = new frmLineDefectTable();
            frm.fromDate = statisticDate; frm.toDate = statisticDate;
            var dicParams = new Dictionary<string, object>()
            {
                {"@EmpID", userName }
            };

            string LineID = (string)_sqlHelper.ExecQuerySacalar("SELECT ISNULL(LineID, '') FROM ASPEmployee WHERE EmpId = @EmpID", dicParams);
            frm.lineID = LineID;
            frm.username = userName;
            frm.Show();
        }

        private void BtFilter_Click(object sender, EventArgs e)
        {
            FromDate = Convert.ToDateTime(dtFromDate.EditValue);
            ToDate = Convert.ToDateTime(dtToDate.EditValue);

            FillData();
        }

        private void BtDefectTable_Click(object sender, EventArgs e)
        {
            frmLineDefectTable frm = new frmLineDefectTable();
            frm.fromDate = FromDate; frm.toDate = ToDate;
            var dicParams = new Dictionary<string, object>()
            {
                {"@EmpID", userName }
            };

            string LineID = (string)_sqlHelper.ExecQuerySacalar("SELECT ISNULL(LineID, '') FROM ASPEmployee WHERE EmpId = @EmpID", dicParams);
            frm.lineID = LineID;
            frm.username = userName;
            frm.Show();
        }

        private void FrmLineProductivity_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            var dicParams = new Dictionary<string, object>()
            {
                {"@EmpID", userName }
            };

            string LineID = (string)_sqlHelper.ExecQuerySacalar("SELECT ISNULL(LineID, '') FROM ASPEmployee WHERE EmpId = @EmpID", dicParams);

            dtProdLine = prodDao.GetLineProductivity(FromDate.Date, ToDate.Date, LineID, userName);
            bdsProdLine.DataSource = dtProdLine;

            gridLinePro.DataSource = bdsProdLine;

            gridLineProView.BestFitColumns();
        }
    }
}
