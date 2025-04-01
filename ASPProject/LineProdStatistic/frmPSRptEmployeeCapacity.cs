using ASPData.ASPDAO;
using ASPData.ASPDTO;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASPProject.LineProdStatistic
{
    public partial class frmPSRptEmployeeCapacity : DevExpress.XtraEditors.XtraForm
    {
        public frmMain frm;
        public delegate void _deDongTab();
        public _deDongTab deDongTab;
        public int iNgonNgu;
        public string userName;

        WOSOPDTO woDto = new WOSOPDTO();
        WOSOPDAO woDao = new WOSOPDAO();
        List<string> lstStr = new List<string>();
        DataTable dtCapacity = new DataTable();
        BindingSource bdsCapacity = new BindingSource();

        public frmPSRptEmployeeCapacity()
        {
            InitializeComponent();

            lstStr.Add("1.Báo cáo năng lực nhân viên - tổng hợp");
            lstStr.Add("2.Báo cáo năng lực nhân viên - theo tháng");

            lkeReportID.Properties.DataSource = lstStr;
            lkeReportID.EditValue = lstStr[0];

            dtFromDate.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtToDate.EditValue = Convert.ToDateTime(dtFromDate.EditValue).AddMonths(1).AddDays(-1);

            this.Load += FrmPSRptEmployeeCapacity_Load;
            this.btFilter.Click += BtFilter_Click;
        }

        private void BtFilter_Click(object sender, EventArgs e)
        {
            FillData();
        }

        private void FrmPSRptEmployeeCapacity_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            woDto.FromDate = Convert.ToDateTime(dtFromDate.EditValue);
            woDto.ToDate = Convert.ToDateTime(dtToDate.EditValue);
            woDto.Username = userName;

            gridEmpCapactityView.Columns.Clear();

            if (lkeReportID.EditValue.ToString().Contains("1."))
            {
                dtCapacity = woDao.GetEmployeeCapacity(woDto, "sp_ASPEmpCapacityV1");
                bdsCapacity.DataSource = dtCapacity;
                gridEmpCapacity.DataSource = bdsCapacity;
            }
            else
            {
                dtCapacity = woDao.GetEmployeeCapacity(woDto, "sp_ASPEmpCapacityV2");
                bdsCapacity.DataSource = dtCapacity;
                gridEmpCapacity.DataSource = bdsCapacity;
            }
        }
    }
}
