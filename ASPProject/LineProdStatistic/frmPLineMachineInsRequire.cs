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
using static System.Net.WebRequestMethods;

namespace ASPProject.LineProdStatistic
{
    public partial class frmPLineMachineInsRequire : DevExpress.XtraEditors.XtraForm
    {
        #region declaration
        public string userName;
        DataRow drCurrent;
        PLineMachineIns prodDto = new PLineMachineIns();
        ProdStatisticDAO prodDao = new ProdStatisticDAO();
        BindingSource bdsMachineIns = new BindingSource();
        private readonly SQLHelper _sqlHelper = new SQLHelper();
        #endregion

        #region constructor
        public frmPLineMachineInsRequire()
        {
            InitializeComponent();

            dtFromDate.EditValue = DateTime.Now;
            dtToDate.EditValue = DateTime.Now;

            this.Load += FrmPLineMachineInsRequire_Load;
            btAdd.Click += BtAdd_Click;
            btEdit.Click += BtEdit_Click;
            btDelete.Click += BtDelete_Click;
            btFilter.Click += BtFilter_Click;
            btExport.Click += BtExport_Click;
            gridMachineInsView.RowClick += GridMachineInsView_RowClick;
            gridMachineInsView.RowStyle += GridMachineInsView_RowStyle;
        }

        private void BtExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel|*.xlsx";
            saveFileDialog1.Title = "Save an File";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                gridMachineInsView.ExportToXlsx(saveFileDialog1.FileName);
            }
        }

        private void GridMachineInsView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            string strIsCompleteName = Convert.ToString(gridMachineInsView.GetRowCellValue(e.RowHandle, "IsCompleteName"));
            string strTechApproval = Convert.ToString(gridMachineInsView.GetRowCellValue(e.RowHandle, "TechApprovalName"));

            if (strIsCompleteName == "Đã hoàn thành")
                e.Appearance.BackColor = Color.LightGreen;
            else if (strTechApproval == "Đã nhận máy" && strIsCompleteName != "Đã hoàn thành")
                e.Appearance.BackColor = Color.LightYellow;
        }

        private void GridMachineInsView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            drCurrent = gridMachineInsView.GetDataRow(e.RowHandle);
        }
        #endregion

        #region Load
        private void FrmPLineMachineInsRequire_Load(object sender, EventArgs e)
        {
            FillData();

            gridMachineInsView.BestFitColumns();
        }
        private void FillData()
        {
            DataTable dt = new DataTable();

            dt = prodDao.GetPLineMachineIns(Convert.ToDateTime(dtFromDate.EditValue).Date, Convert.ToDateTime(dtToDate.EditValue).Date);

            bdsMachineIns.DataSource = dt;
            gridMachineIns.DataSource = bdsMachineIns;

        }
        #endregion

        #region event

        private void BtFilter_Click(object sender, EventArgs e)
        {
            FillData();
        }
        private void BtDelete_Click(object sender, EventArgs e)
        {
            if (drCurrent != null)
            {
                var dicParams = new Dictionary<string, object>()
                {
                    { "@AutoID", (long)Convert.ToDouble(drCurrent["AutoID"]) }
                };

                _sqlHelper.ExecQueryNonData("DELETE FROM ASPPLineMachineIns WHERE AutoID = @AutoID", dicParams);
            }

            FillData();
            XtraMessageBox.Show("Đã xoá thành công!");
        }

        private void BtEdit_Click(object sender, EventArgs e)
        {
            if (drCurrent == null)
                return;

            frmPLineMachineInsRequireEdit frmEdit = new frmPLineMachineInsRequireEdit();
            frmEdit.autoID = (long)Convert.ToDouble(drCurrent["AutoID"]);
            frmEdit.editType = 0;
            frmEdit.userName = userName;
            frmEdit.docDate = Convert.ToDateTime(drCurrent["DocDate"]);
            frmEdit.lineID = Convert.ToString(drCurrent["LineID"]);
            frmEdit.woDocNo = Convert.ToString(drCurrent["WODocNo"]);
            frmEdit.productID = Convert.ToString(drCurrent["ProductID"]);
            frmEdit.stageID = Convert.ToString(drCurrent["StageID"]);
            frmEdit.machineID = Convert.ToString(drCurrent["MachineID"]);
            frmEdit.requireStatus = Convert.ToString(drCurrent["RequiredStatus"]);
            frmEdit.requireQuantity = Convert.ToDouble(drCurrent["MaterialQuantity"]);
            frmEdit.materialID = Convert.ToString(drCurrent["MaterialID"]);
            frmEdit.isPriority = Convert.ToBoolean(drCurrent["IsPriority"]);
            frmEdit.ShowDialog();

            FillData();
        }

        private void BtAdd_Click(object sender, EventArgs e)
        {
            frmPLineMachineInsRequireEdit frmEdit = new frmPLineMachineInsRequireEdit();
            frmEdit.editType = 1;
            frmEdit.userName = userName;
            frmEdit.ShowDialog();

            FillData();
        }
        #endregion
    }
}
