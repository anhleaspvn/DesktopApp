using ASPData;
using BarTender;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace ASPProject.ProdQRCodeMaster
{
    public partial class rptQRCodeLabel : DevExpress.XtraReports.UI.XtraReport
    {
        private readonly SQLHelper _sqlhelper = new SQLHelper();
        public rptQRCodeLabel()
        {
            InitializeComponent();
        }

        public void BindData()
        {
            xrBarCode1.DataBindings.Add("Text", DataSource, "QRCODEDATA");
            xrBarCode2.DataBindings.Add("Text", DataSource, "QRCODEDATA");
            lbQR1.DataBindings.Add("Text", DataSource, "QRCODEDATA");
            lbQR2.DataBindings.Add("Text", DataSource, "QRCODEDATA");

            string strYear = DateTime.Now.Year.ToString().Substring(2, 2);

            var dicParams = new Dictionary<string, object>()
            {
                { "@Date", DateTime.Now }
            };

            string strWeek = string.Empty;

            DataTable dtWeek = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPFindWeeknameByDate", dicParams);
            if (dtWeek.Rows.Count > 0)
            {
                strWeek = "12";//dtWeek.Rows[0]["IntWeek"].ToString().PadLeft(2, '0');
            }

            string dateStr = strYear + strWeek;

            //string xrLabel = "M81715A001 REV A " + dateStr + "      Airspeed        MADE IN VIETNAM";
            string xrLabel = "HOBART P/N:\r\n01-605028-00001\r\nREV.E\r\n" + dateStr + "\r\nRoHS COMPLIANT\r\nMADE IN VIETNAM";

            xrLabel1.Text = xrLabel;
            xrLabel2.Text = xrLabel;
        }
    }
}
