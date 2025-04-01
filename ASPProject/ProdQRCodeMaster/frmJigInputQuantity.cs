using ASPData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASPProject.ProdQRCodeMaster
{
    public partial class frmJigInputQuantity : DevExpress.XtraBars.ToolbarForm.ToolbarForm
    {
        public string logJigID;
        private SQLHelper sql = new SQLHelper();
        public frmJigInputQuantity()
        {
            InitializeComponent();
            this.btCancel.Click += BtCancel_Click;
            this.btSave.Click += BtSave_Click;
        }

        private void BtSave_Click(object sender, EventArgs e)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@LogID", logJigID },
                { "@Quantity", Convert.ToDouble(txtStatisQuantity.Text) },
            };

            sql.ExecQueryNonData("UPDATE ASPProdScanQRCodeJigLog SET Quantity = @Quantity WHERE LogID = @LogID", dicParams);

            this.Close();
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
