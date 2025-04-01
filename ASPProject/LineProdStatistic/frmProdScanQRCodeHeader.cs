using ASPData;
using ASPData.ASPDAO;
using ASPData.ProdStatisticDTO;
using DevExpress.Printing.Core.PdfExport.Metafile;
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
    public partial class frmProdScanQRCodeHeader : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration
        public string userName;

        public frmMain frm;
        public delegate void _deDongTab();
        public _deDongTab deDongTab;
        public int iNgonNgu;
        BindingSource bdsScanQR = new BindingSource();
        DataTable dtScanQR = new DataTable();
        DateTime FromDate, ToDate;
        string LineID, WODocNo, EmpID;
        ProdStatisticDTO prodStatDto = new ProdStatisticDTO();
        ProdStatisticDAO prodStatDao = new ProdStatisticDAO();
        private readonly SQLHelper _sqlHelper = new SQLHelper();
        #endregion

        #region Constructor
        public frmProdScanQRCodeHeader()
        {
            InitializeComponent();

            dtFromDate.EditValue = DateTime.Now.Date;
            dtToDate.EditValue = DateTime.Now.Date;

            DataTable dtWODocNoList = prodStatDao.GetWODocNoList(userName, WODocNo, 1);

            lkeWODocNo.Properties.DataSource = dtWODocNoList;
            lkeWODocNo.Properties.DisplayMember = "So_Ct";
            lkeWODocNo.Properties.ValueMember = "So_Ct";
            lkeWODocNo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeWODocNo.Properties.PopupFilterMode = PopupFilterMode.Contains;

            lkeLine.Properties.DataSource = LineIDData();
            lkeLine.Properties.DisplayMember = "LineName";
            lkeLine.Properties.ValueMember = "LineID";
            lkeLine.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeLine.Properties.PopupFilterMode = PopupFilterMode.Contains;

            lkeEmpID.Properties.DataSource = prodStatDao.GetEmployeeList(string.Empty);
            lkeEmpID.Properties.ValueMember = "EmpID";
            lkeEmpID.Properties.DisplayMember = "EmpID";
            lkeEmpID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeEmpID.Properties.PopupFilterMode = PopupFilterMode.Contains;

            FromDate = Convert.ToDateTime(dtFromDate.EditValue);
            ToDate = Convert.ToDateTime(dtToDate.EditValue);
            LineID = Convert.ToString(lkeLine.EditValue);
            WODocNo = Convert.ToString(lkeWODocNo.EditValue);
            EmpID = Convert.ToString(lkeEmpID.EditValue);

            this.Load += FrmProdScanQRCodeHeader_Load;
            this.btFilter.Click += BtFilter_Click;
        }
        #endregion

        #region Load
        private DataTable LineIDData()
        {
            DataTable dt = new DataTable();

            dt = _sqlHelper.ExecProcedureDataAsDataTable("sp_ASPGetAllLineID");

            return dt;
        }

        private void FrmProdScanQRCodeHeader_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            FromDate = Convert.ToDateTime(dtFromDate.EditValue);
            ToDate = Convert.ToDateTime(dtToDate.EditValue);
            LineID = Convert.ToString(lkeLine.EditValue);
            WODocNo = Convert.ToString(lkeWODocNo.EditValue);
            EmpID = Convert.ToString(lkeEmpID.EditValue);

            dtScanQR = prodStatDao.GetAllScanQRHeader(FromDate, ToDate, LineID, WODocNo, EmpID);
            bdsScanQR.DataSource = dtScanQR;

            gridScanQRCodeHeader.DataSource = bdsScanQR;
        }
        #endregion

        #region Event
        private void BtFilter_Click(object sender, EventArgs e)
        {
            FillData();
        }
        #endregion
    }
}
