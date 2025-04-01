using ASPData.ASPDAO;
using ASPData.ProdStatisticDTO;
using ASPData;
using System;
using System.Data;
using DevExpress.XtraEditors;
using System.Globalization;
using System.Threading;
using ASPData.ASPDTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ASPProject.LineProdStatistic
{
    public partial class frmRptWOSumByStage : DevExpress.XtraEditors.XtraForm
    {
        WOSOPDTO woDto = new WOSOPDTO();
        WOSOPDAO woDao = new WOSOPDAO();
        public DateTime fromDate, toDate;
        public string userName;
        public frmRptWOSumByStage()
        {
            InitializeComponent();

            this.Load += FrmRptWOSumByStage_Load;
        }

        private void FrmRptWOSumByStage_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            woDto.FromDate = fromDate;
            woDto.ToDate = toDate;
            woDto.LineID = userName;
            woDto.Username = userName;
            woDto.ViewType = 2;

            dt = woDao.LoadEmpByStageReport(woDto);

            gridAuditInput.DataSource = dt;
        }
    }
}
