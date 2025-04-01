using ASPData;
using ASPData.ASPDAO;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Blending;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using static DevExpress.Utils.Svg.CommonSvgImages;

namespace ASPProject.AttendanceEmployee
{
    public partial class frmAttendanceTableByMonth : DevExpress.XtraEditors.XtraForm
    {
        #region Declare
        public string userName;

        public frmMain frm;
        public delegate void _deDongTab();
        public _deDongTab deDongTab;
        public int iNgonNgu;

        private DataTable dtAttMonth = new DataTable();
        private BindingSource bdsAttMonth = new BindingSource();
        private AttendanceEmployeeDAO attDao = new AttendanceEmployeeDAO();
        private SQLHelper _sqlHelper = new SQLHelper();
        #endregion
        #region Constructor
        public frmAttendanceTableByMonth()
        {
            InitializeComponent();
            dtpFromDate.EditValue = DateTime.Now;
            //gridAttMonthView.HorzScrollVisibility = ScrollVisibility.Always;
            //gridAttMonthView.VertScrollVisibility = ScrollVisibility.Always;

            this.Load += FrmAttendanceTableByMonth_Load;
            this.btFilter.Click += BtFilter_Click;
            this.btExport.Click += BtExport_Click;
            this.gridAttMonthView.RowCellStyle += GridAttMonthView_RowCellStyle;
        }
        #endregion

        #region Load
        private void FrmAttendanceTableByMonth_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            DateTime dateCus = Convert.ToDateTime(dtpFromDate.EditValue);
            var dicParams = new Dictionary<string, object>()
            {
                {"@EmpID", userName }
            };

            string LineID = (string)_sqlHelper.ExecQuerySacalar("SELECT ISNULL(LineID, '') FROM ASPEmployee WHERE EmpId = @EmpID", dicParams);
            
            dtAttMonth = attDao.GetAttendanceListByMonth(dateCus.Month, dateCus.Year, LineID, userName);
            bdsAttMonth.DataSource = dtAttMonth;

            gridAttMonth.DataSource = bdsAttMonth;

            gridAttMonthView.BestFitColumns();
        }
        #endregion

        #region Event
        private void BtFilter_Click(object sender, EventArgs e)
        {
            FillData();
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

        private void GridAttMonthView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(e.CellValue)))
            {
                if (Convert.ToString(e.CellValue) == "P")
                    e.Appearance.BackColor = Color.Yellow;
            }
        }
        #endregion
    }
}
