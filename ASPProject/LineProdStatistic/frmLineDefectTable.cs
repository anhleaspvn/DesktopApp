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

namespace ASPProject.LineProdStatistic
{
    public partial class frmLineDefectTable : DevExpress.XtraEditors.XtraForm
    {
        private SQLHelper _sqlHelper = new SQLHelper();
        public DateTime fromDate, toDate;
        public string lineID, username;
        public frmLineDefectTable()
        {
            InitializeComponent();

            this.Load += FrmLineDefectTable_Load;
            gridLineDefectView.RowCellStyle += GridLineDefectView_RowCellStyle;
        }

       

        private void FrmLineDefectTable_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void GridLineDefectView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            object value = gridLineDefectView.GetRowCellValue(e.RowHandle, "Bold");

            if (value != DBNull.Value && Convert.ToInt32(value) == 1)
            {
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }
        }

        private void FillData() 
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@FromDate", fromDate },
                { "@ToDate", toDate },
                { "@LineID", lineID },
                { "@Username", username }
            };

            DataTable dtDF = new DataTable();
            dtDF = _sqlHelper.ExecProcedureDataAsDataTable("sp_ASPLineDefectTable", dicParams);

            gridLineDefect.DataSource = dtDF;
        }
    }
}
