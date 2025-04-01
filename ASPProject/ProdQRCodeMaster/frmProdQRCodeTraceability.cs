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

namespace ASPProject.ProdQRCodeMaster
{
    public partial class frmProdQRCodeTraceability : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration
        public string userName;
        private readonly SQLHelper _sqlHelper = new SQLHelper();
        private DataTable dtProdScanQRCode = new DataTable();
        private DataTable dtWODocNoList = new DataTable();
        private DataTable dtProductList = new DataTable();
        private BindingSource bdsBOM = new BindingSource();
        private BindingSource bdsQRCodeMaster = new BindingSource();
        private BindingSource bdsQRCodeDetail = new BindingSource();
        private DataRow drHeaderCur = null;
        private DataRow drDetailCur = null;

        QRCodeMasterList qrDto = new QRCodeMasterList();
        ProdStatisticDAO qrDao = new ProdStatisticDAO();

        public frmMain frm;
        public delegate void _deDongTab();
        public _deDongTab deDongTab;
        public int iNgonNgu, curIndex;
        #endregion

        public frmProdQRCodeTraceability()
        {
            InitializeComponent();

            this.Load += FrmProdQRCodeTraceability_Load;
            this.lkeWO.EditValueChanged += LkeWO_EditValueChanged;
            this.lkeProduct.EditValueChanged += LkeProduct_EditValueChanged;
            this.btExportExcel.Click += BtExportExcel_Click;
        }

        private void BtExportExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel|*.xlsx";
            saveFileDialog1.Title = "Save an File";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                gridBOMView.ExportToXlsx(saveFileDialog1.FileName);
            }
        }

        private void LkeProduct_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dtBOM = new DataTable();

            if (string.IsNullOrEmpty(lkeProduct.EditValue.ToString()))
                return;

            dtBOM = qrDao.GetCheckFullBOMByProduct(lkeProduct.EditValue.ToString());
            bdsBOM.DataSource = dtBOM;
            gridBOM.DataSource = bdsBOM;
        }

        private void FrmProdQRCodeTraceability_Load(object sender, EventArgs e)
        {
            dtWODocNoList = qrDao.GetWODocNoList(userName, string.Empty, 1);

            lkeWO.Properties.DataSource = dtWODocNoList;
            lkeWO.Properties.DisplayMember = "So_Ct"; 
            lkeWO.Properties.ValueMember = "So_Ct";
            lkeWO.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeWO.Properties.PopupFilterMode = PopupFilterMode.Contains;

            dtProductList = qrDao.GetProductList(userName);

            lkeProduct.Properties.DataSource = dtProductList;
            lkeProduct.Properties.DisplayMember = "Ma_Vt";
            lkeProduct.Properties.ValueMember = "Ma_Vt";
            lkeProduct.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeProduct.Properties.PopupFilterMode = PopupFilterMode.Contains;
        }

        #region Event
        private void LkeWO_EditValueChanged(object sender, EventArgs e)
        {
           
        }
        #endregion
    }
}
