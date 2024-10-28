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
using static DevExpress.Data.Filtering.Helpers.SubExprHelper.ThreadHoppingFiltering;

namespace ASPProject.LineProdStatistic
{
    public partial class frmPSDetailEmpScanEdit : DevExpress.XtraEditors.XtraForm
    {
        public long EmpHeaderID;
        public string EmpID, StageID, MaterialID, MachineID;
        public DateTime checkinDt, checkoutDt;
        public int Quantity;
        WOSOPDTO wosoDto = new WOSOPDTO();
        WOSOPDAO wosoDao = new WOSOPDAO();
        public frmPSDetailEmpScanEdit()
        {
            InitializeComponent();

            this.Load += FrmPSDetailEmpScanEdit_Load;
            this.btCancel.Click += BtCancel_Click;
            this.btSave.Click += BtSave_Click;
        }

        private void FrmPSDetailEmpScanEdit_Load(object sender, EventArgs e)
        {
            //machineID
            lkeMachineID.EditValue = MachineID;
            lkeMachineID.Properties.DataSource = wosoDao.GetMachineList(string.Empty);
            lkeMachineID.Properties.DisplayMember = "MachineID";
            lkeMachineID.Properties.ValueMember = "MachineID";
            lkeMachineID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeMachineID.Properties.PopupFilterMode = PopupFilterMode.Contains;

            dtpBeginTime.EditValue = checkinDt.ToString("HH:mm:ss");
            dtpEndTime.EditValue = checkoutDt.ToString("HH:mm:ss");
            txtQuantity.EditValue = !string.IsNullOrEmpty(Quantity.ToString()) ? Quantity.ToString() : "0";
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtSave_Click(object sender, EventArgs e)
        {
            wosoDto.EmpHeaderID = EmpHeaderID;
            wosoDto.EmpID = EmpID;
            wosoDto.StageID = StageID;
            wosoDto.MaterialID = MaterialID;
            wosoDto.MachineID = !string.IsNullOrEmpty(lkeMachineID.EditValue.ToString()) ? Convert.ToString(lkeMachineID.EditValue) : string.Empty;

            string[] arCheckInDt = Convert.ToDateTime(dtpBeginTime.EditValue).ToString("HH:mm:ss").Split(':');
            if (arCheckInDt.Length == 3)
                wosoDto.CheckInDt = checkinDt.Date.AddHours(Convert.ToInt32(arCheckInDt[0])).AddMinutes(Convert.ToInt32(arCheckInDt[1])).AddSeconds(Convert.ToInt32(arCheckInDt[2]));
            else
                wosoDto.CheckInDt = checkinDt;

            string[] arCheckOutDt = Convert.ToDateTime(dtpEndTime.EditValue).ToString("HH:mm:ss").Split(':');

            if (arCheckOutDt.Length == 3)
                wosoDto.CheckOutDt = checkoutDt.Date.AddHours(Convert.ToInt32(arCheckOutDt[0])).AddMinutes(Convert.ToInt32(arCheckOutDt[1])).AddSeconds(Convert.ToInt32(arCheckOutDt[2]));
            else
                wosoDto.CheckOutDt = checkoutDt;

            wosoDto.CheckInDtOld = checkoutDt;
            wosoDto.Quantity = !string.IsNullOrEmpty(txtQuantity.Text) ? Convert.ToDouble(txtQuantity.Text) : 0;
            wosoDto.ReworkQuantity = !string.IsNullOrEmpty(txtReworkQty.Text) ? Convert.ToDouble(txtReworkQty.Text) : 0;
            wosoDto.SortingQuantity = !string.IsNullOrEmpty(txtSortingQty.Text) ? Convert.ToDouble(txtSortingQty.Text) : 0;

            wosoDao.UpdateWOSOPStageQuantity(wosoDto);

            this.Close();
        }

    }
}
