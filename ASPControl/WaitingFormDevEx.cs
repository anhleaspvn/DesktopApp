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
            dlg.TopMost = false;
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
            if (dlg == null) return;
            try
            {
                dlg.Close();
                dlg.Dispose();
            }
            catch
            {
                // already closed
            }
            finally
            {
                dlg = null;
            }
        }

    }
}
