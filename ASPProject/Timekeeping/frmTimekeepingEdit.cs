using ASPData.ASPDAO;
using ASPData.LosstimeDTO;
using ASPData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ASPData.TimekeepingDTO;
using System.Globalization;
using System.Threading;
using DevExpress.XtraEditors;

namespace ASPProject.Timekeeping
{
    public partial class frmTimekeepingEdit : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration
        public int editType;
        public int iNgonNgu;
        public string timekeepID, timekeepName, userName, passWord;
        public double timekeepHours, timekeepHoursMain, timekeepHoursOver, timeOffByDate, timeOffByDateTC;
        public TimeSpan dateBeginTime, dateEndTime;
        private readonly SQLHelper _sqlHelper = new SQLHelper();

        TimekeepingDTO timekeepDto = new TimekeepingDTO();
        TimekeepingDAO timekeepDao = new TimekeepingDAO();
        #endregion

        #region Constructor
        public frmTimekeepingEdit()
        {
            InitializeComponent();

            this.Load += TimekeepingEdit_Load;
            this.btSave.Click += BtSave_Click;
            this.btCancel.Click += BtCancel_Click;
        }
        #endregion

        #region Load
        private void TimekeepingEdit_Load(object sender, EventArgs e)
        {
            if (iNgonNgu == 1)
            {
                LoadEL();
            }
            else
            {
                LoadTV();
            }

            if (editType == 0)
            {
                txtTimekeepID.Text = Convert.ToString(timekeepID);
                txtTimekeepName.Text = Convert.ToString(timekeepName);
                txtTimekeepHours.Text = Convert.ToString(timekeepHours);
                txtTimekeepHoursMain.Text = Convert.ToString(timekeepHoursMain);
                txtTimekeepHoursOver.Text = Convert.ToString(timekeepHoursOver);
                dtpDateBeginTime.EditValue = DateTime.Now.Date + dateBeginTime;
                dtpDateEndTime.EditValue = DateTime.Now.Date + dateEndTime;
                txtTimeOffByDate.Text = Convert.ToString(timeOffByDate);
                txtTimeOffByDateTC.Text = Convert.ToString(timeOffByDateTC);
            }
            else
            {
                //load EmpID
            }
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
            this.Text = "Form Insert && Update Timekeeping";
        }
        private bool FormCheckValid()
        {
            if (string.IsNullOrEmpty(txtTimekeepID.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập mã ký hiệu công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (string.IsNullOrEmpty(txtTimekeepName.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập tên ký hiệu công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;
        }
        #endregion

        #region Event
        private void BtCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormCheckValid())
                    return;

                if (editType == 1)
                {
                    timekeepDto.TimekeepID = Convert.ToString(txtTimekeepID.Text);
                    timekeepDto.TimekeepName = Convert.ToString(txtTimekeepName.Text);
                    timekeepDto.TimekeepHours = Convert.ToDouble(txtTimekeepHours.Text);
                    timekeepDto.TimekeepHoursMain = Convert.ToDouble(txtTimekeepHoursMain.Text);
                    timekeepDto.TimekeepHoursOver = Convert.ToDouble(txtTimekeepHoursOver.Text);
                    timekeepDto.DateBeginTime = TimeSpan.Parse(Convert.ToDateTime(dtpDateBeginTime.EditValue).ToString("HH:mm:ss"));
                    timekeepDto.DateEndTime = TimeSpan.Parse(Convert.ToDateTime(dtpDateEndTime.EditValue).ToString("HH:mm:ss"));
                    timekeepDto.TimeOffByDate = Convert.ToDouble(txtTimeOffByDate.Text);
                    timekeepDto.TimeOffByDateTC = Convert.ToDouble(txtTimeOffByDateTC.Text);
                    timekeepDto.CreatedBy = userName;
                    timekeepDto.CreatedDate = DateTime.Now;

                    timekeepDao.InsertTimekeeping(timekeepDto);

                    XtraMessageBox.Show("Đã thêm ký hiệu công thành công.");
                    this.Close();
                }
                else
                {
                    timekeepDto.TimekeepID = Convert.ToString(txtTimekeepID.Text);
                    timekeepDto.TimekeepName = Convert.ToString(txtTimekeepName.Text);
                    timekeepDto.TimekeepHours = Convert.ToDouble(txtTimekeepHours.Text);
                    timekeepDto.TimekeepHoursMain = Convert.ToDouble(txtTimekeepHoursMain.Text);
                    timekeepDto.TimekeepHoursOver = Convert.ToDouble(txtTimekeepHoursOver.Text);
                    timekeepDto.DateBeginTime = TimeSpan.Parse(Convert.ToDateTime(dtpDateBeginTime.EditValue).ToString("HH:mm:ss"));
                    timekeepDto.DateEndTime = TimeSpan.Parse(Convert.ToDateTime(dtpDateEndTime.EditValue).ToString("HH:mm:ss"));
                    timekeepDto.TimeOffByDate = Convert.ToDouble(txtTimeOffByDate.Text);
                    timekeepDto.TimeOffByDateTC = Convert.ToDouble(txtTimeOffByDateTC.Text);
                    timekeepDto.LastModifiedBy = userName;
                    timekeepDto.LastModifiedDate = DateTime.Now;

                    timekeepDao.UpdateTimekeeping(timekeepDto);

                    XtraMessageBox.Show("Đã cập nhật ký hiệu công thành công.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
