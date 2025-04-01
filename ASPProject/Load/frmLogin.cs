using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.Win32;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Globalization;
using System.Threading;
using System.Configuration;
using ASPData.ASPDTO;
using ASPData.ASPDAO;
using DevExpress.LookAndFeel;
using ASPProject.Load;

namespace ASPProject
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            //AutoUpdater.UpdateAllDlls();
            InitializeComponent();
        }

        private void btKetThuc_Click(object sender, EventArgs e)
        {
            if (iNgonNgu == 0)
            {
                if (XtraMessageBox.Show("Bạn có muốn thoát hay không ? ", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
            else
            {
                if (XtraMessageBox.Show("Do you want to exit ? ", "Info", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    Application.Exit();
                }
            }

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }

        ASPDTO aspDto = new ASPDTO();
        ASPDAO aspDao = new ASPDAO();
        public static string MaHoa(string cleanString)
        {
            Byte[] clearBytes = new UnicodeEncoding().GetBytes(cleanString);
            Byte[] hashedBytes = ((System.Security.Cryptography.HashAlgorithm)System.Security.Cryptography.CryptoConfig.CreateFromName("MD5")).ComputeHash(clearBytes);

            return BitConverter.ToString(hashedBytes);
        }

        private void Validate_EmptyStringRule(BaseEdit control)
        {
            string sThongBao;
            if (iNgonNgu == 0)
            {
                sThongBao = " Không được bỏ trống";
            }
            else
            {
                sThongBao = "No empty";
            }
            if (control.Text == null || control.Text.Trim().Length == 0) dxErrorProvider1.SetError(control, sThongBao, ErrorType.Critical);
            else dxErrorProvider1.SetError(control, "");
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if (txtTenTaiKhoan.Text == "")
            {

                Validate_EmptyStringRule(txtTenTaiKhoan);
                if (iNgonNgu == 0)
                {
                    XtraMessageBox.Show("Vui lòng nhập tên");
                    return;
                }
                else
                {
                    XtraMessageBox.Show("Please input username");
                    return;
                }
            }
            if (txtMatKhau.Text == "")
            {
                Validate_EmptyStringRule(txtMatKhau);
                if (iNgonNgu == 0)
                {
                    XtraMessageBox.Show("Vui lòng nhập mật khẩu");
                    return;
                }
                else
                {
                    XtraMessageBox.Show("Please input password");
                    return;
                }

            }

            aspDto.UserName = txtTenTaiKhoan.Text;

            DataTable tbLogin = new DataTable();
            tbLogin = aspDao.ASPLogin(aspDto);

            if (tbLogin.Rows.Count > 0)
            {
                if (txtMatKhau.Text != Convert.ToString(tbLogin.Rows[0]["Password"]))
                {
                    XtraMessageBox.Show("Mật khẩu sai !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.Hide();
                frmLoad frm = new frmLoad();
                frm.sTennv = tbLogin.Rows[0]["Ten_CbNv"].ToString();
                frm.sBoPhan = tbLogin.Rows[0]["Ma_Bp"].ToString();
                frm.sManv = tbLogin.Rows[0]["Username"].ToString();
                frm.iNgonNgu = iNgonNgu;
                frm.ShowDialog();
                SaveRegistry();
            }
            else
            {
                if (iNgonNgu == 0)
                {
                    XtraMessageBox.Show("Tên đăng nhập sai !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    XtraMessageBox.Show("Username or pasword wrong");
                }

            }

        }

        private void SaveRegistry()
        {
            if (checkNho.Checked == true)
            {

                Registry.SetValue(@"HKEY_CURRENT_USER\Software\SaveUserAndPassword", "Chk", "1");
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\SaveUserAndPassword", "ID", txtTenTaiKhoan.Text);
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\SaveUserAndPassword", "PSS", txtMatKhau.Text);
            }
            else if (checkNho.Checked == false)
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\SaveUserAndPassword", "Chk", "0");
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\SaveUserAndPassword", "ID", "");
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\SaveUserAndPassword", "PSS", "");
            }
        }
        private void LoadRegistry()
        {
            txtTenTaiKhoan.Text = (string)(Registry.GetValue(@"HKEY_CURRENT_USER\Software\SaveUserAndPassword", "ID", null));
            txtMatKhau.Text = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\SaveUserAndPassword", "PSS", null);
            if ((string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\SaveUserAndPassword", "Chk", null) == "1")
            {
                checkNho.Checked = true;
            }
            if ((string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\SaveUserAndPassword", "Chk", null) == "0")
            {
                checkNho.Checked = false;
            }
        }
        public int iNgonNgu;
        private void frmLogin_Load(object sender, EventArgs e)
        {
            UserLookAndFeel defaultLF = UserLookAndFeel.Default;
            defaultLF.SkinName = "Blue";
            iNgonNgu = 0;
            if (iNgonNgu == 1)
            {

                loadEN();
            }
            if (iNgonNgu == 0)
            {

                loadVN();
            }
            txtTenTaiKhoan.Focus();
            LoadRegistry();
        }
        public void loadVN()
        {
            iNgonNgu = 0;
            CultureInfo objCultureInfo = Thread.CurrentThread.CurrentCulture;
            btDangNhap.Text = resVietNam.DangNhap.ToString();
            
            checkNho.Text = resVietNam.checkNho.ToString();
            this.Text = "Đăng nhập tài khoản";
        }
        public void loadEN()
        {
            iNgonNgu = 1;
            CultureInfo objCultureInfo = Thread.CurrentThread.CurrentCulture;
            btDangNhap.Text = resEngLand.DangNhap.ToString();
           
            checkNho.Text = resEngLand.checkNho.ToString();
            this.Text = "Login account";


        }
        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                simpleButton1_Click(null, null);
            }
        }

        private void txtTenTaiKhoan_Validating(object sender, CancelEventArgs e)
        {
            Validate_EmptyStringRule(sender as BaseEdit);
        }

        private void txtMatKhau_Validating(object sender, CancelEventArgs e)
        {
            Validate_EmptyStringRule(sender as BaseEdit);
        }
    }
}