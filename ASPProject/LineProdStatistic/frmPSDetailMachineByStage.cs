using ASPData.ASPDAO;
using ASPData.ASPDTO;
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
    public partial class frmPSDetailMachineByStage : DevExpress.XtraEditors.XtraForm
    {
        public frmMain frm;
        public delegate void _deDongTab();
        public _deDongTab deDongTab;
        public int iNgonNgu;
        public string userName;

        WOSOPDTO woDto = new WOSOPDTO();
        WOSOPDAO woDao = new WOSOPDAO();
        public frmPSDetailMachineByStage()
        {
            InitializeComponent();

            dtFromDate.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtToDate.EditValue = Convert.ToDateTime(dtFromDate.EditValue).AddMonths(1).AddDays(-1);

            btFilter.Click += BtFilter_Click;
            btExport.Click += BtExport_Click;
        }

        private void BtExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel|*.xlsx";
            saveFileDialog1.Title = "Save an File";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                gridStatSummaryView.ExportToXlsx(saveFileDialog1.FileName);
            }
        }

        private void BtFilter_Click(object sender, EventArgs e)
        {
            woDto.FromDate = Convert.ToDateTime(dtFromDate.EditValue);
            woDto.ToDate = Convert.ToDateTime(dtToDate.EditValue);
            woDto.LineID = userName;
            woDto.Username = userName;
            woDto.ViewType = 0;

            DataTable dtStage = woDao.LoadMachineByStageReport(woDto);
            gridStatSummary.DataSource = dtStage;
        }
    }
}

