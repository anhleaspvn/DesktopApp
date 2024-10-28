using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevComponents.DotNetBar;
using System.Windows.Forms;

namespace ASPControl
{
    public class Loadingggg
    {

        private DevExpress.Utils.WaitDialogForm dlg = null;
        public void CreateWaitDialog()
        {
            dlg = new DevExpress.Utils.WaitDialogForm("Xin vui lòng chờ đợi");
        }
        public void SetWaitDialogCaption(string fCaption)
        {
            if (dlg != null)
            {
                dlg.Caption = fCaption;
            }
        }

        public void simpleCloseWait()
        {
            dlg.Close();
        }

    }
}
