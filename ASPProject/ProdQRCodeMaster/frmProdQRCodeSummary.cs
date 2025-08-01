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
    public partial class frmProdQRCodeSummary : DevExpress.XtraEditors.XtraForm
    {
        public frmMain frm;
        public delegate void _deDongTab();
        public _deDongTab deDongTab;
        public int iNgonNgu;
        public string userName;

        private BindingSource bdsData = new BindingSource();

        ProdStatisticDAO prodStatDao = new ProdStatisticDAO();
        ProdStatisticDTO prodStatisticDTO = new ProdStatisticDTO();
        PSScanBarcodeBin psScanBin = new PSScanBarcodeBin();

        private readonly SQLHelper _sqlHelper = new SQLHelper();
        private bool filterByDate = false, filterByWO = false;

        public frmProdQRCodeSummary()
        {
            InitializeComponent();

            this.Load += FrmProdQRCodeSummary_Load;
            btFilter.Click += BtFilter_Click;
        }

        private void FrmProdQRCodeSummary_Load(object sender, EventArgs e)
        {
            DataTable dtWODocNoList = prodStatDao.GetWODocNoList(userName, string.Empty, 1);

            lkeWO.Properties.DataSource = dtWODocNoList;
            lkeWO.Properties.DisplayMember = "So_Ct";
            lkeWO.Properties.ValueMember = "So_Ct";
            lkeWO.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeWO.Properties.PopupFilterMode = PopupFilterMode.Contains;

            DataTable dtStageQR = prodStatDao.GetTableOfStageArea(userName);

            lkeStageID.Properties.DataSource = dtStageQR;
            lkeStageID.Properties.DisplayMember = "StageName";
            lkeStageID.Properties.ValueMember = "StageID";
            lkeStageID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeStageID.Properties.PopupFilterMode = PopupFilterMode.Contains;

            checkEdit1.Visible = true;
            checkEdit2.Visible = true;

            labelControl1.Visible = false;
            labelControl2.Visible = false;
            dtFromDate.Visible = false;
            dtToDate.Visible = false;

            lbLSX.Visible = false;
            lkeWO.Visible = false;

            checkEdit1.CheckStateChanged += CheckEdit1_CheckStateChanged;
            checkEdit2.CheckStateChanged += CheckEdit2_CheckStateChanged;

            dtFromDate.EditValue = DateTime.Now;
            dtToDate.EditValue = DateTime.Now;
        }

        private void CheckEdit2_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkEdit2.CheckState != CheckState.Checked)
            {
                labelControl1.Visible = false;
                labelControl2.Visible = false;
                dtFromDate.Visible = false;
                dtToDate.Visible = false;
                filterByDate = false;
                checkEdit1.CheckState = CheckState.Checked;
                
            }
            else
            {
                labelControl1.Visible = true;
                labelControl2.Visible = true;
                dtFromDate.Visible = true;
                dtToDate.Visible = true;
                filterByDate = true;

                checkEdit1.CheckState = CheckState.Unchecked;
            }
        }

        private void CheckEdit1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkEdit1.CheckState != CheckState.Checked)
            {
                lbLSX.Visible = false;
                lkeWO.Visible = false;

                filterByWO = false;
                checkEdit2.CheckState = CheckState.Checked;

            }
            else
            {
                lbLSX.Visible = true;
                lkeWO.Visible = true;

                filterByWO = true;
                checkEdit2.CheckState = CheckState.Unchecked;
            }
        }

        private void BtFilter_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            DataTable dt = new DataTable();

            try
            {
                if (filterByDate == true)
                    dt = prodStatDao.GetSumOfProdQRCodeData(Convert.ToDateTime(dtFromDate.EditValue).Date, Convert.ToDateTime(dtToDate.EditValue).Date, (string)lkeWO.EditValue, 1, (string)lkeStageID.EditValue);

                if (filterByWO == true)
                    dt = prodStatDao.GetSumOfProdQRCodeData(Convert.ToDateTime(dtFromDate.EditValue).Date, Convert.ToDateTime(dtToDate.EditValue).Date, (string)lkeWO.EditValue, 2, (string)lkeStageID.EditValue);

                bdsData.DataSource = dt;
                gridProdQRCodeSum.DataSource = bdsData;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
