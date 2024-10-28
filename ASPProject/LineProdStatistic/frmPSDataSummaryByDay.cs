using ASPData;
using ASPData.ASPDAO;
using ASPData.ASPDTO;
using ASPData.ProdStatisticDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASPProject.LineProdStatistic
{
    public partial class frmPSDataSummaryByDay : DevExpress.XtraEditors.XtraForm
    {
        public DateTime statisticDate;
        public string lineID, username;
        public decimal exlosstime;
        private readonly SQLHelper _sqlHelper = new SQLHelper();

        ProdStatisticDTO prodStatDto = new ProdStatisticDTO();
        ProdStatisticDAO prodStatDao = new ProdStatisticDAO();
        public frmPSDataSummaryByDay()
        {
            InitializeComponent();

            this.Load += FrmPSDataSummaryByDay_Load;
            this.dtpStatisticDate.EditValueChanged += DtpStatisticDate_EditValueChanged;

        }

        private void LoadData()
        {
            gridProdPSSummaryView.BestFitColumns();

            DataTable dt = new DataTable();

            prodStatDto.StatisticDate = statisticDate;
            prodStatDto.LineID = lineID;
            prodStatDto.Username = username;

            dt = prodStatDao.SummaryProdStatisticByDay(prodStatDto, false);

            if (dt.Rows.Count > 0)
            {
                txtProdTime.Text = Convert.ToString(dt.Rows[0]["ProdWorktime"]);
                txtEmpHC.Text = Convert.ToString(dt.Rows[0]["EmpHC"]);
                txtHC.Text = Convert.ToString(dt.Rows[0]["TimeHC"]);
                txtEmpTC.Text = Convert.ToString(dt.Rows[0]["EmpTC"]);
                txtTimeTC.Text = Convert.ToString(dt.Rows[0]["TimeTC"]);
                txtEmpSoon.Text = Convert.ToString(dt.Rows[0]["EmpSoon"]);
                txtTimeSoon.Text = Convert.ToString(dt.Rows[0]["TimeSoon"]);
                txtEmpLoan.Text = Convert.ToString(dt.Rows[0]["EmpLoan"]);
                txtTimeLoan.Text = Convert.ToString(dt.Rows[0]["TimeLoan"]);
                txtEmpBorrow.Text = Convert.ToString(dt.Rows[0]["EmpBorrow"]);
                txtTimeBorrow.Text = Convert.ToString(dt.Rows[0]["TimeBorrow"]);
                txtSumTime.Text = Convert.ToString(dt.Rows[0]["SumTime"]);
                txtExLosstime.Text = Convert.ToString(dt.Rows[0]["ExLosstime"]);
                txtProdDefect.Text = Convert.ToString(dt.Rows[0]["ProdDefect"]);
                txtProdMachineTime.Text = Convert.ToString(dt.Rows[0]["ProdMachineTime"]);
                txtExLosstime.Text = Convert.ToString(dt.Rows[0]["ExLosstime"]);
                txtSubJobTime.Text = Convert.ToString(dt.Rows[0]["SubJobTime"]);
            }
            else
            {
                txtProdTime.Text = "0.0";
                txtEmpHC.Text = "0.0";
                txtHC.Text = "0.0";
                txtEmpTC.Text = "0.0";
                txtTimeTC.Text = "0.0";
                txtEmpSoon.Text = "0.0";
                txtTimeSoon.Text = "0.0";
                txtEmpLoan.Text = "0.0";
                txtTimeLoan.Text = "0.0";
                txtEmpBorrow.Text = "0.0";
                txtTimeBorrow.Text = "0.0";
                txtSumTime.Text = "0.0";

                exlosstime = 0;

                txtExLosstime.Text = "0.0";
                txtProdDefect.Text = "0.0";
                txtProdMachineTime.Text = "0.0";
                txtSubJobTime.Text = "0.0";
            }

            dt = prodStatDao.SummaryProdStatisticByDay(prodStatDto, true);

            gridProdPSSummary.DataSource = dt;
        }
        private void FrmPSDataSummaryByDay_Load(object sender, EventArgs e)
        {
            dtpStatisticDate.EditValue = DateTime.Now.Date;

            LoadData();
        }

        private void DtpStatisticDate_EditValueChanged(object sender, EventArgs e)
        {
            statisticDate = Convert.ToDateTime(dtpStatisticDate.EditValue).Date;

            LoadData();
        }
    }
}
