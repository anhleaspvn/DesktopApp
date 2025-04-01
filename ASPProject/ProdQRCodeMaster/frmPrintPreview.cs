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
    public partial class frmPrintPreview : DevExpress.XtraBars.ToolbarForm.ToolbarForm
    {
        public System.Data.DataTable _dataTable = null;
        public frmPrintPreview()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            Text = @"IN TEM NHÃN LABEL";

            var rpt = new rptQRCodeLabel();
            documentViewer1.PrintingSystem = rpt.PrintingSystem;
            rpt.DataSource = _dataTable;
            rpt.BindData();
            rpt.CreateDocument();
        }
    }
}
