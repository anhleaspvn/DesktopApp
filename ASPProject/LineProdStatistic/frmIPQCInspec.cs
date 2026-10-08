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

namespace ASPProject.LineProdStatistic
{
    public partial class frmIPQCInspec : XtraForm
    {
        #region Declaration
        public frmMain frm;
        public delegate void _deDongTab();
        public _deDongTab deDongTab;
        public int iNgonNgu;
        public string userName;
        IQCCheckingDTO iqcDto = new IQCCheckingDTO();
        IQCCheckingDAO iqcDao = new IQCCheckingDAO();
        BindingSource bdsIQCInsp = new BindingSource();
        DataTable dtIQCInsp = new DataTable();
        #endregion

        #region Constructor
        public frmIPQCInspec()
        {
            InitializeComponent();

            dtFromDate.EditValue = DateTime.Now.Date;
            dtToDate.EditValue = DateTime.Now.Date; 

            this.Load += FrmIPQCInspec_Load;

            btFilter.Click += BtFilter_Click;
            btExport.Click += BtExport_Click;
        }
        #endregion

        #region Load
        private void FrmIPQCInspec_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            dtIQCInsp = iqcDao.GetIPQCReportForm(Convert.ToDateTime(dtFromDate.EditValue), Convert.ToDateTime(dtToDate.EditValue));

            bdsIQCInsp.DataSource = dtIQCInsp;
            gridIPQC.DataSource = bdsIQCInsp;
        }
        #endregion

        #region Event
        private void BtExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel|*.xlsx";
            saveFileDialog1.Title = "Save an File";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                gridIPQC.ExportToXlsx(saveFileDialog1.FileName);
            }
        }

        private void BtFilter_Click(object sender, EventArgs e)
        {
            FillData();
        }
        #endregion
    }
}
