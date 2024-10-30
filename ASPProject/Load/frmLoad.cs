using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ASPData.ASPDAO;
using ASPProject.HRAbsenceDoc;
using DevExpress.XtraEditors;

namespace ASPProject
{
    public partial class frmLoad : DevExpress.XtraEditors.XtraForm
    {
        public frmLoad()
        {
            InitializeComponent();
        }
        int z;
        public int iNgonNgu;string sThongBao,sThongBao2,sThongBao3;
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            z += 2;

            //if (iNgonNgu==0)
            //{
            //    sThongBao = "Vui Lòng xin chờ ...";
            //    sThongBao3 = "Đang kiểm tra sự hợp lệ...";
            //    sThongBao2 = "Đang tải dữ liệu...";
            //}
            //if (iNgonNgu == 1)
            //{
            //    sThongBao = "Please waiting ...";
            //    sThongBao2 = "Loading data...";
            //    sThongBao3 = "check the validing...";
            //}
           
            //if (z<=30)
            //{
            //    labelControl2.Text = sThongBao2;
            //}
            //if (z >= 50)
            //{
                
            //}
            //if (z<=100)
            //{
                
            //}
            
            if (z > 100)
            {
                this.Hide();


                this.timer1.Enabled = false;

                frmMain frm = new frmMain();
                frm.sBoPhan = sBoPhan;
                frm.sTennv = sTennv;
                frm.sManv = sManv;
                frm.Show();
                this.Hide();

                return;

            }
            this.progressBar1.EditValue = z;

        }
        public string sManv, sTennv, sBoPhan;
        private void frmLoad_Load(object sender, EventArgs e)
        {
           
            this.timer1.Enabled = false;
            this.timer1.Interval = 10;
            timer1.Start();
        }
    }
}