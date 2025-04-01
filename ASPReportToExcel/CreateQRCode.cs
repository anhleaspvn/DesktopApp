using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASPReportToExcel
{
    public partial class CreateQRCode : DevExpress.XtraEditors.XtraForm
    {
        private DataTable yourDataTable;
        public CreateQRCode()
        {
            InitializeComponent();
            InitializeDataTable();
        }

        private void InitializeDataTable()
        {
            yourDataTable = new DataTable();
            //yourDataTable.Columns.Add("MA HANG", typeof(string));
            //yourDataTable.Columns.Add("VERSION", typeof(string));
            //yourDataTable.Columns.Add("SO LUONG/ THUNG", typeof(string));
            //yourDataTable.Columns.Add("Ma Cty", typeof(string));
            //yourDataTable.Columns.Add("MA VUNG", typeof(string));
            //yourDataTable.Columns.Add("LOT DH", typeof(string));
            //yourDataTable.Columns.Add("SO TT THUNG", typeof(string));
            //yourDataTable.Columns.Add("Ma trong", typeof(string));
            yourDataTable.Columns.Add("QRCODEDATA", typeof(string));
        }

        private void InitData()
        {

        }
    }
}
