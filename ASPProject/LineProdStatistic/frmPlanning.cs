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
    using ASPData.ASPDAO;
    using ASPData.PlanningDTO;
    using DevExpress.XtraEditors;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Views.Grid;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    public partial class frmPlanning : XtraForm
    {
        public string username;
        DataTable dtPlan = new DataTable();
        BindingSource bdsPlan = new BindingSource();
        PlanningDTO planDTO = new PlanningDTO();
        PlanningDAO planDAO = new PlanningDAO();
        public frmPlanning()
        {
            InitializeComponent();
            LoadMonthYear();

            this.Load += FrmPlanning_Load;
        }

        private void FrmPlanning_Load(object sender, EventArgs e)
        {
            
        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FillData()
        {
            
        }

        private void LoadMonthYear()
        {
            // Dữ liệu tháng
            DataTable dtMonth = new DataTable();
            dtMonth.Columns.Add("Value", typeof(int));
            dtMonth.Columns.Add("Display", typeof(string));
            for (int i = 1; i <= 12; i++)
                dtMonth.Rows.Add(i, "Tháng " + i);

            lkeMonth.Properties.DataSource = dtMonth;
            lkeMonth.Properties.DisplayMember = "Display";
            lkeMonth.Properties.ValueMember = "Value";
            lkeMonth.EditValue = DateTime.Now.Month;

            // Dữ liệu năm
            DataTable dtYear = new DataTable();
            dtYear.Columns.Add("Value", typeof(int));
            dtYear.Columns.Add("Display", typeof(string));
            for (int y = DateTime.Now.Year - 5; y <= DateTime.Now.Year + 5; y++)
                dtYear.Rows.Add(y, y.ToString());

            lkeYear.Properties.DataSource = dtYear;
            lkeYear.Properties.DisplayMember = "Display";
            lkeYear.Properties.ValueMember = "Value";
            lkeYear.EditValue = DateTime.Now.Year;
        }
    }

}
