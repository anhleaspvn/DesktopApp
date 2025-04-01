using ASPData;
using ASPData.ASPDAO;
using ASPData.LosstimeDTO;
using ASPData.ProdStatisticDTO;
using ASPData.TimekeepingDTO;
using ASPProject.Losstime;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
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
using ASPReportToExcel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Links;
using DevExpress.XtraPrintingLinks;
using DevExpress.XtraPrinting.BarCode;
using System.IO;


namespace ASPProject.ProdQRCodeMaster
{
    public partial class frmProdQRCodeMaster : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration
        public string userName;
        private readonly SQLHelper _sqlHelper = new SQLHelper();
        private DataTable dtQRCodeMaster = new DataTable();
        private DataTable dtQRCodeDetail = new DataTable();
        private BindingSource bdsQRCodeMaster = new BindingSource();
        private BindingSource bdsQRCodeDetail = new BindingSource();
        private DataRow drHeaderCur = null;
        private DataRow drDetailCur = null;
        private string labelPath = "D:\\Airspeed Dev\\Tem\\Tem110x30.btw";

        QRCodeMasterList qrDto = new QRCodeMasterList();
        ProdStatisticDAO qrDao = new ProdStatisticDAO();

        public frmMain frm;
        public delegate void _deDongTab();
        public _deDongTab deDongTab;
        public int iNgonNgu, curIndex;
        #endregion

        #region Constructor
        public frmProdQRCodeMaster()
        {
            InitializeComponent();

            this.Load += FrmProdQRCodeMaster_Load; ;
            this.barThem.ItemClick += BarThem_ItemClick;

            this.gridQRCodeMasterView.RowClick += GridQRCodeMasterView_RowClick;
            this.bdsQRCodeMaster.CurrentChanged += BdsQRCodeMaster_CurrentChanged;
            this.bdsQRCodeDetail.CurrentChanged += BdsQRCodeDetail_CurrentChanged;
            this.barIn.ItemClick += BarIn_ItemClick1;
        }

        private void BarIn_ItemClick1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataTable dtChon = GetDataPrintStamp();

                frmPrintPreview frmPre = new frmPrintPreview();
                frmPre._dataTable = dtChon;
                frmPre.ShowDialog();
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                
            }
        }
        #endregion

        #region Load
        private void FrmProdQRCodeMaster_Load(object sender, EventArgs e)
        {
            LoadData();
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
        }
        private void LoadData()
        {
            dtQRCodeMaster = qrDao.GetQRCodeMasterList(qrDto);

            bdsQRCodeMaster.DataSource = dtQRCodeMaster;
            gridQRCodeMaster.DataSource = bdsQRCodeMaster;

            if (drHeaderCur != null)
            {
                drHeaderCur = ((DataRowView)bdsQRCodeMaster.Current).Row;

                FillDataDetail(Convert.ToString(drHeaderCur["WODocNo"]));
            }
        }
        private void FillDataDetail(string WODocNo)
        {
            if (WODocNo == string.Empty)
                return;

            qrDto.WODocNo = WODocNo;

            dtQRCodeDetail = qrDao.GetQRCodeMasterListDetail(qrDto);

            bdsQRCodeDetail.DataSource = dtQRCodeDetail;
            gridQRCodeDetail.DataSource = bdsQRCodeDetail;
        }

        private DataTable GetDataPrintStamp()
        {
            DataTable dtPrintStamp = new DataTable();

            DataRow drCurrent = ((DataRowView)bdsQRCodeMaster.Current).Row;

            string WODocNo = string.Empty;

            if (drCurrent != null)
                WODocNo = drCurrent["WODocNo"].ToString();

            int[] intDr = gridQRCodeDetailView.GetSelectedRows();
            int count = 0;

            foreach (var iRow in gridQRCodeDetailView.GetSelectedRows())
            {
                DataRow dr = gridQRCodeDetailView.GetDataRow(iRow);

                int orderNum = Convert.ToInt32(dr["OrderNo"]);

                DataTable dt = qrDao.GetProdPrintStampQRCode(orderNum, WODocNo);

                if (count == 0)
                {
                    dtPrintStamp = dt.Clone();
                    dtPrintStamp.ImportRow(dt.Rows[0]);
                }
                else
                {
                    dtPrintStamp.ImportRow(dt.Rows[0]);
                }
                count++;
            }

            return dtPrintStamp;
        }

        //public XRBarCode CreateQRCodeBarCode(string BarCodeText)
        //{
        //    // Create a barcode control.
        //    XRBarCode barCode = new XRBarCode();

        //    // Set the barcode's type to QRCode.
        //    barCode.Symbology = new QRCodeGenerator();

        //    // Adjust the barcode's main properties.
        //    barCode.Text = BarCodeText;
        //    barCode.Width = 10;
        //    barCode.Height = 10;

        //    // If the AutoModule property is set to false, uncomment the next line.
        //    barCode.AutoModule = true;
        //    // barcode.Module = 3;

        //    // Adjust the properties specific to the barcode type.
        //    ((QRCodeGenerator)barCode.Symbology).CompactionMode = QRCodeCompactionMode.AlphaNumeric;
        //    ((QRCodeGenerator)barCode.Symbology).ErrorCorrectionLevel = QRCodeErrorCorrectionLevel.H;
        //    ((QRCodeGenerator)barCode.Symbology).Version = QRCodeVersion.AutoVersion;

        //    return barCode;
        //}
        #endregion

        #region Event
        private void BdsQRCodeMaster_CurrentChanged(object sender, EventArgs e)
        {
            drHeaderCur = ((DataRowView)bdsQRCodeMaster.Current).Row;

            if (drHeaderCur == null)
                return;

            FillDataDetail(Convert.ToString(drHeaderCur["WODocNo"]));
        }

        private void BdsQRCodeDetail_CurrentChanged(object sender, EventArgs e)
        {
            drDetailCur = ((DataRowView)bdsQRCodeDetail.Current).Row;

            if (drDetailCur == null)
                return;

            barQRCode.Text = (string)drDetailCur["QRCodeData"];
        }

        private void GridQRCodeMasterView_RowClick(object sender, RowClickEventArgs e)
        {
            drHeaderCur = gridQRCodeMasterView.GetDataRow(e.RowHandle);
            curIndex = e.RowHandle;
        }

        private void BarXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BarNapLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }

        private void BarIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BarXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BarSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BarThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmProdQRCodeMasterEdit th = new frmProdQRCodeMasterEdit();
            th.editType = 1;
            th.userName = userName;
            th.ShowDialog();
            LoadData();
        }

        private void BarThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            deDongTab();
        }

        #endregion
    }
}
