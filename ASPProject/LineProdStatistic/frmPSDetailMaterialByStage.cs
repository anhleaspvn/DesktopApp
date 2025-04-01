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
    public partial class frmPSDetailMaterialByStage : DevExpress.XtraEditors.XtraForm
    {
        public frmMain frm;
        public delegate void _deDongTab();
        public _deDongTab deDongTab;
        public int iNgonNgu;
        public string userName;
        public List<string> lstReport = new List<string>();
        DataTable dtReport = new DataTable();
        
        WOSOPDTO woDto = new WOSOPDTO();
        WOSOPDAO woDao = new WOSOPDAO();
        public frmPSDetailMaterialByStage()
        {
            InitializeComponent();

            this.Load += FrmPSDetailMaterialByStage_Load;

            lstReport.Add("1.Báo cáo vật tư sử dụng");
            lstReport.Add("2.Báo cáo vật tư NG");

            dtFromDate.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtToDate.EditValue = Convert.ToDateTime(dtFromDate.EditValue).AddMonths(1).AddDays(-1);

            lkeReportID.Properties.DataSource = lstReport;
            lkeReportID.EditValue = "1.Báo cáo vật tư sử dụng";

            btFilter.Click += BtFilter_Click;
            btExport.Click += BtExport_Click;
        }

        private void FrmPSDetailMaterialByStage_Load(object sender, EventArgs e)
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
                gridStatSummaryView.ExportToXlsx(saveFileDialog1.FileName);
            }
        }

        private void BtFilter_Click(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            woDto.FromDate = Convert.ToDateTime(dtFromDate.EditValue);
            woDto.ToDate = Convert.ToDateTime(dtToDate.EditValue);
            woDto.LineID = userName;
            woDto.Username = userName;

            gridStatSummaryView.Columns.Clear();

            if (lkeReportID.EditValue.ToString().Contains("1."))
            {
                dtReport = woDao.LoadMaterialByStageReport("sp_ASPMaterialByStage", woDto);
                gridStatSummary.DataSource = dtReport;
            }
            else
            {
                dtReport = woDao.LoadMaterialByStageReport("sp_ASPNGMaterialByStage", woDto);
                gridStatSummary.DataSource = dtReport;
            }
        }
    }
}
