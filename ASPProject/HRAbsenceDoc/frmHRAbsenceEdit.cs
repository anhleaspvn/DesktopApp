using ASPData.ASPDAO;
using ASPData.ASPDTO;
using ASPData.ProdStatisticDTO;
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
  

   
    public partial class frmHRAbsenceEdit : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration
        public int editType;
        public int iNgonNgu;
        public DateTimeOffset Timestamp;
        public DateTime TimeOff;
        public double NumDateOff;
        public string ReasonOfAbsence = string.Empty, TypeOfAbsence = string.Empty;
        public long AutoID;

        private HRAbsenceDTO hrDto = new HRAbsenceDTO();
        private HRAbsenceDAO hrDao = new HRAbsenceDAO();

        #endregion

        #region Constructor
        public frmHRAbsenceEdit()
        {
            InitializeComponent();

            this.Load += FrmHRAbsenceEdit_Load;

            lkeTypeOfAbsence.Properties.DataSource = hrDao.GetTypeOfAbsence();
            lkeTypeOfAbsence.Properties.ValueMember = "TypeOfAbsence";
            lkeTypeOfAbsence.Properties.DisplayMember = "TypeOfAbsence";
            lkeTypeOfAbsence.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeTypeOfAbsence.Properties.PopupFilterMode = PopupFilterMode.Contains;

            btSave.Click += BtSave_Click;
            btCancel.Click += BtCancel_Click;
        }
        #endregion

        #region Load
        private void FrmHRAbsenceEdit_Load(object sender, EventArgs e)
        {
            txtNumDateOff.Text = Convert.ToString(NumDateOff);
            dtpTimeOff.EditValue = TimeOff;
            rtxtReasonOfAbsence.Text = ReasonOfAbsence;
            lkeTypeOfAbsence.EditValue = TypeOfAbsence;
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
                hrDto.AutoID = AutoID;
                hrDto.TimeOff = Convert.ToDateTime(dtpTimeOff.EditValue);
                hrDto.NumDateOff = !string.IsNullOrEmpty(txtNumDateOff.Text) ? Convert.ToDouble(txtNumDateOff.Text) : 0;
                hrDto.ReasonOfAbsence = !string.IsNullOrEmpty(rtxtReasonOfAbsence.Text) ? rtxtReasonOfAbsence.Text : ReasonOfAbsence;
                hrDto.TypeOfAbsence = !string.IsNullOrEmpty(Convert.ToString(lkeTypeOfAbsence.EditValue)) ? Convert.ToString(lkeTypeOfAbsence.EditValue) : TypeOfAbsence;

                hrDao.EditHRAbsence(hrDto);
            }
            catch (Exception ex)
            {
                throw ex;   
            }
            XtraMessageBox.Show("Cập nhật thành công !");

            this.Close();
        }
        #endregion 
    }
}
