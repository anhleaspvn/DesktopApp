using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ASPProject.Load;

namespace ASPProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //DevExpress.UserSkins.BonusSkins.Register();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (AutoUpdater.CheckAndStartUpdate(null))
            {
                return;
            }

            Application.Run(new frmLogin());
        }
    }
}
