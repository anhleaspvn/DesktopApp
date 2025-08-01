using ASPData;
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

namespace ASPProject.HRAbsenceDoc
{
    public partial class frmHRAbsenceDocByStaff : DevExpress.XtraEditors.XtraForm
    {
        public frmMain frm;
        public delegate void _deDongTab();
        public _deDongTab deDongTab;
        public int iNgonNgu;
        public string userName;

        private SQLHelper sqlhelper = new SQLHelper();
        private HRAbsenceDTO hrDto = new HRAbsenceDTO();
        private HRAbsenceDAO hrDao = new HRAbsenceDAO();
        private HRAbsenceStaffDTO hrStaffDto = new HRAbsenceStaffDTO();
      
        private DataTable dtHRAbsenceStaff = new DataTable();
        private BindingSource bdsHRAbsenceStaff = new BindingSource();

        public frmHRAbsenceDocByStaff()
        {
            InitializeComponent();

            dtpFromDate.EditValue = DateTime.Now;
            dtpToDate.EditValue = DateTime.Now;

            lblEmpName.Visible = false;
            lblDepName.Visible = false;
            lblPosition.Visible = false;
            lblDateJob.Visible = false;
            lblStatus.Visible = false;
            lblTongPTN.Visible = false;
            lblTongPTH.Visible = false;

            this.Load += FrmHRAbsenceDocByStaff_Load;
            btFilter.Click += BtFilter_Click;
            
        }

        private void FrmHRAbsenceDocByStaff_Load(object sender, EventArgs e)
        {
            lkeEmpID.Properties.DataSource = hrDao.GetHREmployeeListV2(userName);
            lkeEmpID.Properties.ValueMember = "Ma_CbNv";
            lkeEmpID.Properties.DisplayMember = "Ma_CbNv";
            lkeEmpID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeEmpID.Properties.PopupFilterMode = PopupFilterMode.Contains;

            this.LoadData();
        }

        private void LoadData()
        {
            hrDto.FromDate = Convert.ToDateTime(dtpFromDate.EditValue);
            hrDto.ToDate = Convert.ToDateTime(dtpToDate.EditValue);
            hrDto.EmpID = Convert.ToString(lkeEmpID.EditValue);
            hrDto.Username = userName;

            dtHRAbsenceStaff = hrDao.GetViewHRAbsenceStaff(hrDto);

            bdsHRAbsenceStaff.DataSource = dtHRAbsenceStaff;
            gridHRAbsence.DataSource = bdsHRAbsenceStaff;
        }
        private void BtFilter_Click(object sender, EventArgs e)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@EmpID", lkeEmpID.EditValue },
                { "@Year", Convert.ToDateTime(dtpFromDate.EditValue).Year }
            };

            try
            {
                DataTable dtEmpID = sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetHRAbsenceStaffInfo", dicParams);

                if (dtEmpID.Rows.Count > 0)
                {
                    lblEmpName.Visible = true;
                    lblDepName.Visible = true;
                    lblPosition.Visible = true;
                    lblDateJob.Visible = true;
                    lblStatus.Visible = true;
                    lblTongPTN.Visible = true;
                    lblTongPTH.Visible = true;

                    lblEmpName.Text = dtEmpID.Rows[0]["Ten_CbNv"].ToString();
                    lblDepName.Text = dtEmpID.Rows[0]["Ten_Bp"].ToString();
                    lblPosition.Text = dtEmpID.Rows[0]["Ten_ChucVu"].ToString();
                    lblDateJob.Text = dtEmpID.Rows[0]["Ngay_ChinhThuc"].ToString();
                    lblStatus.Text = dtEmpID.Rows[0]["Status_CBNV"].ToString();
                    lblTongPTN.Text = dtEmpID.Rows[0]["Phep_Chuan"].ToString();
                    lblTongPTH.Text = dtEmpID.Rows[0]["Phep_Thuong"].ToString();
                }
            }
            catch { }

            this.LoadData();
        }
    }
}
