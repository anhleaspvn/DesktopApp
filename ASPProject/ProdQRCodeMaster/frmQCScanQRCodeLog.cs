using ASPData;
using ASPData.ASPDAO;
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

namespace ASPProject.ProdQRCodeMaster
{
    public partial class frmQCScanQRCodeLog : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration
        public string userName;
        private readonly SQLHelper _sqlHelper = new SQLHelper();
        private DataTable dtQCScanQRCode = new DataTable();
        private BindingSource bdsQCScanQRCode = new BindingSource();

        private DataRow drHeaderCur = null;
        private DataRow drDetailCur = null;

        QRCodeLog qrDto = new QRCodeLog();
        ProdStatisticDAO qrDao = new ProdStatisticDAO();
        ASPDAO aspDAO = new ASPDAO();

        public frmMain frm;
        public delegate void _deDongTab();
        public _deDongTab deDongTab;
        public int iNgonNgu, curIndex;
        
        #endregion
        public frmQCScanQRCodeLog()
        {
            InitializeComponent();
            this.KeyPreview = true;

            this.Load += FrmQCScanQRCodeLog_Load;

            this.txtQRCodeData.KeyDown += TxtQRCodeData_KeyDown;
        }

        private void TxtQRCodeData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            e.Handled = true;
            e.SuppressKeyPress = true; // không kêu "beep"

            if (string.IsNullOrWhiteSpace(txtQRCodeData.Text))
            {
                txtQRCodeData.Focus();
                return;
            }

            DataTable dtWO = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@QRCode", txtQRCodeData.Text }
            };

            dtWO = _sqlHelper.ExecProcedureDataAsDataTable("sp_ASPFindWOFromCustomerCode", dicParams);
            string strWO = string.Empty;

            if (dtWO.Rows.Count > 0)
            {
                strWO = dtWO.Rows[0]["WODocNo"].ToString();
            }

            qrDto.LogID = aspDAO.ASPGenLogQRCode("LOG", 20, "LogID", "ASPQCScanQRCodeLog");
            qrDto.LogTime = DateTime.Now;
            qrDto.QRCodeData = txtQRCodeData.Text.Trim();
            qrDto.WODocNo = strWO;
            qrDto.CreatedDate = DateTime.Now;
            qrDto.CreatedBy = userName;
            qrDto.LastModifiedBy = userName;
            qrDto.LastModifiedDate = DateTime.Now;

            if (!ValidateQRCode())
            {
                txtQRCodeData.Clear();
                txtQRCodeData.Focus();
                return;
            }

            qrDao.InsertQCQRCodeLog(qrDto);

            txtQRCodeData.Clear();
            FillData();
            txtQRCodeData.Focus();
        }


        private void FillData()
        {
            qrDto.Username = userName;

            dtQCScanQRCode = qrDao.GetQCQRCodeLog(qrDto);
            bdsQCScanQRCode.DataSource = dtQCScanQRCode;

            gridQRCodeLog.DataSource = dtQCScanQRCode;
        }

        private void FrmQCScanQRCodeLog_Load(object sender, EventArgs e)
        {
            //gan collection vao lkeWO
            //lkeWO.Properties.DataSource = qrDao.GetWODocNoList("AS0064", string.Empty, 1);
            //lkeWO.Properties.DisplayMember = "So_Ct";
            //lkeWO.Properties.ValueMember = "So_Ct";
            //lkeWO.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            //lkeWO.Properties.PopupFilterMode = PopupFilterMode.Contains;

            FillData();
        }

        private bool ValidateQRCode()
        {
            bool chk = true;

            XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            args.AutoCloseOptions.Delay = 5000;
            args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
            args.DefaultButtonIndex = 0;
            args.Caption = "Thông báo lỗi";
            args.Text = "This message closes automatically after 5 seconds.";

            //if (string.IsNullOrEmpty(lkeWO.EditValue.ToString()))
            //{
            //    args.Text = "Bạn chưa chọn Lệnh sản xuất!";
            //    XtraMessageBox.Show(args);
            //    chk = false;
            //}

            DataTable dtCheckExist = new DataTable();

            DataTable dtWO = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@QRCode", txtQRCodeData.Text }
            };

            dtWO = _sqlHelper.ExecProcedureDataAsDataTable("sp_ASPFindWOFromCustomerCode", dicParams);
            string strWO = string.Empty;

            if (dtWO.Rows.Count > 0)
            {
                strWO = dtWO.Rows[0]["WODocNo"].ToString();
            }

            dicParams = new Dictionary<string, object>()
            {
                { "@QRCodeData", txtQRCodeData.Text },
                { "@WODocNo", strWO },
            };

            dtCheckExist = _sqlHelper.ExecQueryDataAsDataTable("SELECT * FROM ASPQCScanQRCodeLog WHERE QRCodeData=@QRCodeData AND WODocNo=@WODocNo", dicParams);
           
            if (dtCheckExist.Rows.Count > 0)
            {
                args.Text = "QR Code đã được scan, không được phép scan lại!";
                XtraMessageBox.Show(args);
                chk = false;
            }

            return chk;
        }
    }
}
