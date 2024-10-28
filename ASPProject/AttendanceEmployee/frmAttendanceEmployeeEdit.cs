using ASPData.ASPDAO;
using ASPData.AttendanceEmployeeDTO;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.Design.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ASPProject.AttendanceEmployee
{
    public partial class frmAttendanceEmployeeEdit : DevExpress.XtraEditors.XtraForm
    {
        public string userName, lineID, empID, timeKeeping;
        public DateTime attendanceDate;
        public TimeSpan dateBeginTime, dateEndTime;
        public int iNgonNgu, saveMulti, morVege, eveVege;
        public DataTable dtSaveMulti = new DataTable();
       
        private readonly ASPData.SQLHelper _sqlhelper = new ASPData.SQLHelper();
        AttendanceEmployeeDAO attendEmpDAO = new AttendanceEmployeeDAO();
        AttendanceEmployeeDTO attendEmpDTO = new AttendanceEmployeeDTO();
        TimekeepingDAO timekeepDao = new TimekeepingDAO();
        public frmAttendanceEmployeeEdit()
        {
            InitializeComponent();
            this.Load += FrmAttendanceEmployeeEdit_Load;
            this.btSave.Click += BtSave_Click;
            this.btCancel.Click += BtCancel_Click;
            lkeTimekeepID.EditValueChanged += LkeTimekeepID_EditValueChanged;
        }

        private void FrmAttendanceEmployeeEdit_Load(object sender, EventArgs e)
        {
            if (iNgonNgu == 1)
            {
                LoadEL();
            }
            else
            {
                LoadTV();
            }

            lkeTimekeepID.Properties.DataSource = timekeepDao.GetAllTimekeepingEdit();
            lkeTimekeepID.Properties.ValueMember = "TimekeepID";
            lkeTimekeepID.Properties.DisplayMember = "TimekeepID";
            lkeTimekeepID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeTimekeepID.Properties.PopupFilterMode = PopupFilterMode.Contains;

            lkeTimekeepID.EditValue = Convert.ToString(timeKeeping);
            dtpBeginTime.EditValue = Convert.ToString(dateBeginTime); 
            dtpEndTime.EditValue = Convert.ToString(dateEndTime); 

            lblTenkyhieu.Text = (string)_sqlhelper.ExecQuerySacalar("SELECT TOP 1 ISNULL(TimekeepName, '') FROM ASPTimekeeping WHERE TimekeepID = '" + Convert.ToString(timeKeeping) + "'");
        }

        private bool FormCheckValid()
        {
            if (string.IsNullOrEmpty(Convert.ToString(lkeTimekeepID.EditValue)))
            {
                XtraMessageBox.Show("Vui lòng chọn ký hiệu công.");
                return false;
            }
            return true;
        }

        public void LoadTV()
        {
            iNgonNgu = 0;
            CultureInfo objCultureInfo = Thread.CurrentThread.CurrentCulture;
        }
        public void LoadEL()
        {
            iNgonNgu = 1;
            CultureInfo objCultureInfo = Thread.CurrentThread.CurrentCulture;
            this.Text = "Update attendance employee";
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LkeTimekeepID_EditValueChanged(object sender, EventArgs e)
        {
            lblTenkyhieu.Text = (string)_sqlhelper.ExecQuerySacalar("SELECT TOP 1 ISNULL(TimekeepName, '') FROM ASPTimekeeping WHERE TimekeepID = '" + Convert.ToString(lkeTimekeepID.EditValue) + "'");
        }

        private void BtSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormCheckValid())
                    return;

                if (saveMulti == 0)
                {
                    attendEmpDTO.AttendanceDate = attendanceDate.Date;
                    attendEmpDTO.LineID = lineID;
                    attendEmpDTO.EmpID = empID;
                    attendEmpDTO.Timekeeping = Convert.ToString(lkeTimekeepID.EditValue);
                    attendEmpDTO.MorVege = morVege;
                    attendEmpDTO.EveVege = eveVege;
                    attendEmpDTO.DateBeginTime = TimeSpan.Parse(Convert.ToDateTime(dtpBeginTime.EditValue).ToString("HH:mm:ss"));
                    attendEmpDTO.DateEndTime = TimeSpan.Parse(Convert.ToDateTime(dtpEndTime.EditValue).ToString("HH:mm:ss"));
                    attendEmpDTO.CreatedDate = DateTime.Now;
                    attendEmpDTO.CreatedBy = userName;
                    attendEmpDTO.LastModifiedDate = DateTime.Now;
                    attendEmpDTO.LastModifiedBy = userName;

                    attendEmpDAO.UpdateAttendanceEmployee(attendEmpDTO);

                    this.Close();
                }
                else
                {
                    foreach(DataRow drSave in dtSaveMulti.Rows)
                    {
                        attendEmpDTO.AttendanceDate = attendanceDate.Date;
                        attendEmpDTO.LineID = Convert.ToString(drSave["LineID"]);
                        attendEmpDTO.EmpID = Convert.ToString(drSave["EmpID"]);
                        attendEmpDTO.Timekeeping = Convert.ToString(lkeTimekeepID.EditValue);
                        attendEmpDTO.MorVege = morVege;
                        attendEmpDTO.EveVege = eveVege;
                        attendEmpDTO.DateBeginTime = TimeSpan.Parse(Convert.ToDateTime(dtpBeginTime.EditValue).ToString("HH:mm:ss"));
                        attendEmpDTO.DateEndTime = TimeSpan.Parse(Convert.ToDateTime(dtpEndTime.EditValue).ToString("HH:mm:ss"));
                        attendEmpDTO.CreatedDate = DateTime.Now;
                        attendEmpDTO.CreatedBy = userName;
                        attendEmpDTO.LastModifiedDate = DateTime.Now;
                        attendEmpDTO.LastModifiedBy = userName;

                        attendEmpDAO.UpdateAttendanceEmployee(attendEmpDTO);
                    }

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
    }
}
