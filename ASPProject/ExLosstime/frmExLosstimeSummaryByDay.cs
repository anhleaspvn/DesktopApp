using ASPData.ASPDAO;
using ASPData.LosstimeDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ASPProject.ExLosstime
{
    public partial class frmExLosstimeSummaryByDay : DevExpress.XtraEditors.XtraForm
    {
        LosstimeDTO losstimeDto = new LosstimeDTO();
        LosstimeDAO losstimeDAO = new LosstimeDAO();
        public DateTime statisticDate;
        public string lineID, username;
        public frmExLosstimeSummaryByDay()
        {
            InitializeComponent();

            this.Load += FrmExLosstimeSummaryByDay_Load;
        }

        private void FrmExLosstimeSummaryByDay_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            losstimeDto.StatisticDate = statisticDate;
            losstimeDto.LineID = lineID;

            dt = losstimeDAO.GetExLosstimeSummary(losstimeDto, username, false);
            gridExLosstimeSummary.DataSource = dt;

            dt = losstimeDAO.GetExLosstimeSummary(losstimeDto, username, true);
            gridExLosstimeSum.DataSource = dt;
        }
    }
}
