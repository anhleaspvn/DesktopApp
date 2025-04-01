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
    public partial class frmHRAbsenceEdit : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration
        public int editType;
        public int iNgonNgu;
        public DateTimeOffset Timestamp;

        private HRAbsenceDTO hrDto = new HRAbsenceDTO();
        private HRAbsenceDAO hrDao = new HRAbsenceDAO();
        #endregion

        #region Constructor
        public frmHRAbsenceEdit()
        {
            InitializeComponent();

            this.Load += FrmHRAbsenceEdit_Load;

            btSave.Click += BtSave_Click;
            btCancel.Click += BtCancel_Click;
        }
        #endregion

        #region Load
        private void FrmHRAbsenceEdit_Load(object sender, EventArgs e)
        {
            
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
                hrDto.TimeStamp = Timestamp;

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
