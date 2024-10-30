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

namespace ASPProject.AttendanceEmployee
{
    public partial class frmAttendanceSummary : DevExpress.XtraEditors.XtraForm
    {
        public string lineID, username;
        public DateTime attendanceDate;

        AttendanceEmployeeDAO attendEmpDAO = new AttendanceEmployeeDAO();

        public frmAttendanceSummary()
        {
            InitializeComponent();
            this.Load += FrmAttendanceSummary_Load;
        }

        private void FrmAttendanceSummary_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = attendEmpDAO.GetAttendanceSummary(attendanceDate.Date, lineID, username, false);
            gridAttendanceSummary.DataSource = ds.Tables[0];

            ds = attendEmpDAO.GetAttendanceSummary(attendanceDate.Date, lineID, username, true);
            gridOverallSum.DataSource = ds.Tables[0];

            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[1];
                txtEmpHC.Text = dt.Rows[0]["EmpHC"].ToString();
                txtEmpTC.Text = dt.Rows[0]["EmpTC"].ToString();
                txtEmpSoon.Text = dt.Rows[0]["EmpSoon"].ToString();
                txtEmpV.Text = dt.Rows[0]["EmpV"].ToString();
                txtEmpP.Text = dt.Rows[0]["EmpP"].ToString();
            }
        }
    }
}
