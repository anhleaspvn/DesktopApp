using ASPData.ASPDAO;
using ASPData.ProdStatisticDTO;
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
using DevExpress.Printing.Core.PdfExport.Metafile;
using DevExpress.XtraEditors;
using System.Device;
using System.Management;
using DevExpress.DataAccess.Native.EntityFramework;
using DevExpress.Utils.Gesture;
using System.Runtime.Remoting.Messaging;

namespace ASPProject.ProdQRCodeMaster
{
    public partial class frmProdQRCodeJigTestLog : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration
        public string userName;
        private readonly SQLHelper _sqlHelper = new SQLHelper();
        //private DataTable dtQRCodeMaster = new DataTable();
        //private DataTable dtQRCodeDetail = new DataTable();
        private DataTable dtProdScanQRCode = new DataTable();
        private BindingSource bdsProdScanQRCode = new BindingSource();

        private DataRow drHeaderCur = null;
        private DataRow drDetailCur = null;

        QRCodeLog qrDto = new QRCodeLog();
        ProdStatisticDAO qrDao = new ProdStatisticDAO();

        public frmMain frm;
        public delegate void _deDongTab();
        public _deDongTab deDongTab;
        public int iNgonNgu, curIndex;
        #endregion
        public frmProdQRCodeJigTestLog()
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.Load += FrmProdQRCodeJigTestLog_Load;

            this.txtQRCodeData.TextChanged += TxtQRCodeData_TextChanged;
            this.gridQRCodeLogView.RowCellClick += GridQRCodeLogView_RowCellClick;
        }

        private void GridQRCodeLogView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (bdsProdScanQRCode.Position < 0)
                return;

            DataRow drCur = ((DataRowView)bdsProdScanQRCode.Current).Row;

            if (drCur == null) return;

            if (e.Column.Name == "colQuantity")
            {
                frmJigInputQuantity frmEdit = new frmJigInputQuantity();
                frmEdit.logJigID = (string)drCur["LogID"];
                frmEdit.Show();
            }

            FillData();
        }

        private void TxtQRCodeData_TextChanged(object sender, EventArgs e)
        {
            if (txtQRCodeData.Text == string.Empty)
            {
                this.ActiveControl = txtQRCodeData;
                return;
            }

            if (!ValidateQRCode(txtQRCodeData.Text))
                return;

            qrDto.LogID = ASPGenLogQRCode();
            qrDto.JigID = GetJigIDFromQRCode(txtQRCodeData.Text);
            qrDto.LogTime = DateTime.Now;
            qrDto.QRCodeData = txtQRCodeData.Text.Trim();
            qrDto.CreatedDate = DateTime.Now;
            qrDto.CreatedBy = userName;
            qrDto.LastModifiedBy = userName;
            qrDto.LastModifiedDate = DateTime.Now;

            qrDao.InsertProdQRCodeJigLog(qrDto);

            txtQRCodeData.Text = string.Empty;

            FillData();

            this.ActiveControl = txtQRCodeData;
        }

        private void FrmProdQRCodeJigTestLog_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private string ASPGenLogQRCode()
        {
            string qrCode = string.Empty;

            var dicParams = new Dictionary<string, object> {
                { "@Prefix", "JIG" },
                { "@NumLen", 20 },
                { "@ColumnID", "LogID" },
                { "@TableName", "ASPProdScanQRCodeJigLog" }
            };

            qrCode = (string)_sqlHelper.ExecProcedureSacalar("sp_ASPGenerateCode", dicParams);

            return qrCode;
        }

        private void FillData()
        {
            qrDto.Username = userName;

            dtProdScanQRCode = qrDao.GetQRCodeJigLog(qrDto);
            bdsProdScanQRCode.DataSource = dtProdScanQRCode;

            gridQRCodeLog.DataSource = bdsProdScanQRCode;
        }

        private string GetJigIDFromQRCode(string qrCode)
        {
            string jigID = string.Empty;

            string[] arrStr = qrCode.Split('_');

            if (arrStr.Length > 0)
            {
                jigID = arrStr[0];
            }

            return jigID;
        }

        private void gridQRCodeLog_Click(object sender, EventArgs e)
        {

        }

        private bool ValidateQRCode(string qrCode)
        {
            bool chk = true;
            string jigID = string.Empty;
            string[] arrStr = qrCode.Split('_');

            if (arrStr.Length != 5)
                chk = false;

            if (arrStr.Length > 0)
            {
                jigID = arrStr[0];
            }

            var dicParams = new Dictionary<string, object>()
            {
                { "@JigID", jigID }
            };

            DataTable dtJig = _sqlHelper.ExecQueryDataAsDataTable("SELECT * FROM L81DMJIGASP WHERE Ma_Jig = @JigID", dicParams);

            if (dtJig.Rows.Count == 0)
                return false;

            return chk;
        }
    }
}
