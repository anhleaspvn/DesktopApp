using ASPControl;
using ASPData;
using ASPData.ASPDAO;
using ASPData.ASPDTO;
using DevComponents.DotNetBar.Controls;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASPProject.HRAbsenceDoc
{
    public partial class frmHRGoLate : DevExpress.XtraEditors.XtraForm
    {
        DataTable dtHRGoLate = new DataTable();
        BindingSource bdsHRGoLate = new BindingSource();
        HRGoLateDTO hrDto = new HRGoLateDTO();
        HRAbsenceDAO hrDao = new HRAbsenceDAO();
        ASPControl.Loadingggg aspCtrl = new Loadingggg();
        private SQLHelper sqlhelper = new SQLHelper();

        public frmHRGoLate()
        {
            InitializeComponent();

            this.dtpNgayTB.EditValue = DateTime.Now.Date;

            this.Load += FrmHRGoLate_Load;
            this.btSendMail.Click += BtSendMail_Click;

            gridHRGoLateView.SelectionChanged += GridHRGoLateView_SelectionChanged;
            this.dtpNgayTB.EditValueChanged += DtpNgayTB_EditValueChanged;
        }

        private void DtpNgayTB_EditValueChanged(object sender, EventArgs e)
        {
            FillData();
        }

        private void BtSendMail_Click(object sender, EventArgs e)
        {
            aspCtrl.CreateWaitDialog();
            try
            {
                string strFileOut = string.Empty;
                List<string> arrEmp = new List<string>();

                DataTable dt = GetSelectedRowsAsDataTable();

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    DataRow drow = dt.Rows[i];

                    if (arrEmp.Contains((string)drow["Ma_CbNv"]))
                        continue;

                    DataRow[] arrDr = dt.Select("Ma_CbNv='" + (string)drow["Ma_CbNv"] + "'");

                    string emailTo = Convert.ToString(drow["Email"]);
                    string emailTBP = Convert.ToString(drow["Email_TBP"]);

                    List<EmployeeRecord> empRecord = new List<EmployeeRecord>();

                    foreach (DataRow iRow in arrDr)
                    {
                        EmployeeRecord emp = new EmployeeRecord();
                        emp.Stt = Convert.ToString(iRow["Stt"]);
                        emp.MaNhanVien = (string)iRow["Ma_CbNv"];
                        emp.TenNhanVien = (string)iRow["Ten_CbNv"];
                        emp.NgayChamCong = Convert.ToDateTime(iRow["Ngay_ChamCong"]).ToString("dd/MM/yyyy");
                        emp.GioVao = Convert.ToDateTime(iRow["Gio_Vao"]).ToString("HH:mm");
                        emp.GioRa = Convert.ToDateTime(iRow["Gio_Ra"]).ToString("HH:mm");
                        emp.PhutDiTre = Convert.ToDouble(iRow["Phut_DiTre"]).ToString("F2");
                        emp.PhutVeSom = Convert.ToDouble(iRow["Phut_VeSom"]).ToString("F2");
                        emp.KhongChamGioVao = Convert.ToString(iRow["KhongChamGioVao"]);
                        emp.KhongChamGioRa = Convert.ToString(iRow["KhongChamGioRa"]);
                        emp.GhiChu = Convert.ToString(iRow["Ghi_Chu"]);

                        empRecord.Add(emp);
                    }

                    bool isMailVGM = arrDr.Length >= 3 ? true : false;

                    SendMail("HRGoLate", emailTo, strFileOut, empRecord, emailTBP, isMailVGM);
                    arrEmp.Add((string)drow["Ma_CbNv"]);
                }
                aspCtrl.simpleCloseWait();
            }
            catch (Exception ex)
            {
            }
        }

        // Hàm chuyển các hàng được chọn thành DataTable
        private DataTable GetSelectedRowsAsDataTable()
        {
            // Lấy DataTable gốc từ GridControl
            DataTable sourceTable = bdsHRGoLate.DataSource as DataTable;
            if (sourceTable == null) return null;

            // Tạo DataTable mới với cấu trúc giống DataTable gốc
            DataTable selectedTable = sourceTable.Clone();

            // Lấy danh sách các hàng được chọn
            int[] selectedRowHandles = gridHRGoLateView.GetSelectedRows();

            // Duyệt qua các hàng được chọn
            foreach (int rowHandle in selectedRowHandles)
            {
                if (gridHRGoLateView.IsValidRowHandle(rowHandle))
                {
                    // Lấy dữ liệu của hàng từ DataTable gốc
                    DataRow sourceRow = gridHRGoLateView.GetDataRow(rowHandle);
                    selectedTable.ImportRow(sourceRow);
                }
            }

            return selectedTable;
        }

        private void GridHRGoLateView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
           
                // Lấy mã nhân viên của hàng vừa bỏ chọn
                int rowHandle = e.ControllerRow;
                if (gridHRGoLateView.IsValidRowHandle(rowHandle))
                {
                    string employeeId = gridHRGoLateView.GetRowCellValue(rowHandle, "Ma_CbNv")?.ToString();

                    if (!string.IsNullOrEmpty(employeeId))
                    {
                        bool isSelected = gridHRGoLateView.IsRowSelected(rowHandle);
                        // Duyệt qua tất cả các hàng
                        for (int i = 0; i < gridHRGoLateView.DataRowCount; i++)
                        {
                            // Lấy mã nhân viên của hàng i
                            string currentEmployeeId = gridHRGoLateView.GetRowCellValue(i, "Ma_CbNv")?.ToString();

                            // Nếu mã nhân viên trùng và không phải hàng hiện tại
                            if (currentEmployeeId == employeeId && i != rowHandle)
                            {
                                // Đồng bộ trạng thái: nếu hàng hiện tại được chọn thì chọn, nếu bỏ chọn thì bỏ chọn
                                if (isSelected)
                                {
                                    gridHRGoLateView.SelectRow(i);
                                }
                                else
                                {
                                    gridHRGoLateView.UnselectRow(i);
                                }
                            }
                        }
                    }
                }
            
        }

        private void FrmHRGoLate_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            hrDto.Nam = Convert.ToDateTime(dtpNgayTB.EditValue).Year;
            hrDto.Thang = Convert.ToDateTime(dtpNgayTB.EditValue).Month;
            hrDto.Ngay = Convert.ToDateTime(dtpNgayTB.EditValue).Day;

            dtHRGoLate = hrDao.GetHRGoLate(hrDto);

            bdsHRGoLate.DataSource = dtHRGoLate;
            gridHRGoLate.DataSource = bdsHRGoLate;

            // Tắt màu nền của hàng được chọn
            gridHRGoLateView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Transparent;
            gridHRGoLateView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Transparent;

            // Tắt màu nền của hàng được chọn khi grid không có focus
            gridHRGoLateView.Appearance.SelectedRow.BackColor = System.Drawing.Color.Transparent;
            gridHRGoLateView.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.Transparent;

            // Đảm bảo không sử dụng giao diện mặc định của hệ thống
            gridHRGoLateView.OptionsSelection.EnableAppearanceFocusedRow = false;

            this.gridHRGoLateView.SelectAll();
        }

        private bool SendMail(string MailID, string emailTo, string attachFile, List<EmployeeRecord> empRecord, string emailTBP, bool isEmailVGM)
        {
            try
            {
                var dicParams = new Dictionary<string, object>()
                {
                    { "@MailID", MailID }
                };

                DataTable dtEmail = sqlhelper.ExecQueryDataAsDataTable("SELECT * FROM ASPExcuteEmailList WHERE ID = @MailID", dicParams);

                if (dtEmail.Rows.Count == 0)
                    return false;

                DataRow drSendMail = dtEmail.Rows[0];

                string strTitle = "";
                string strbody = "";
                string strAttachedFile = "";
                string fromEmail = drSendMail["Email"].ToString();
                string password = drSendMail["EmailPassword"].ToString();
                string host = drSendMail["HostMail"].ToString() != string.Empty ? drSendMail["HostMail"].ToString() : "smtp.gmail.com";
                int post = drSendMail["Port"].ToString() != string.Empty ? Convert.ToInt32(drSendMail["Port"]) : 587;
                string CcEmail = drSendMail["EmailCC"].ToString();


                // Lấy email nhận
                string toEmail = emailTo;

                //Lấy email VGM
                string emailVGM = Convert.ToString(drSendMail["EmailVGM"]);

                strTitle = drSendMail["EmailTitle"].ToString();
                strbody = drSendMail["EmailContent"].ToString();

                // Sinh phần tbody động
                StringBuilder tbodyBuilder = new StringBuilder();
                foreach (var record in empRecord)
                {
                    tbodyBuilder.AppendLine("<tbody><tr>");
                    tbodyBuilder.AppendLine($"<td>{record.Stt}</td>");
                    tbodyBuilder.AppendLine($"<td>{record.MaNhanVien}</td>");
                    tbodyBuilder.AppendLine($"<td>{record.TenNhanVien}</td>");
                    tbodyBuilder.AppendLine($"<td>{record.NgayChamCong}</td>");
                    tbodyBuilder.AppendLine($"<td>{record.GioVao}</td>");
                    tbodyBuilder.AppendLine($"<td>{record.GioRa}</td>");
                    tbodyBuilder.AppendLine($"<td>{record.PhutDiTre}</td>");
                    tbodyBuilder.AppendLine($"<td>{record.PhutVeSom}</td>");
                    tbodyBuilder.AppendLine($"<td>{record.KhongChamGioVao}</td>");
                    tbodyBuilder.AppendLine($"<td>{record.KhongChamGioRa}</td>");
                    tbodyBuilder.AppendLine($"<td>{record.GhiChu}</td>");
                    tbodyBuilder.AppendLine("</tr></tbody>");
                }

                strbody = strbody.Replace("<tbody></tbody>", tbodyBuilder.ToString());

                strAttachedFile = drSendMail["AttachedLink"].ToString();

                strTitle = strTitle.Replace("{DocDate}", DateTime.Now.Date.ToString("dd/MM/yyyy"));
                strbody = strbody.Replace("{DocDate}", DateTime.Now.Date.ToString("dd/MM/yyyy"));
                strbody = strbody.Replace("{AttachedLink}", strAttachedFile);
                var smtpClient = new SmtpClient(host, post)
                {
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(fromEmail, password),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = true,
                    Timeout = 300000
                };

                var mail = new MailMessage
                {
                    Body = strbody,
                    Subject = strTitle,
                    From = new MailAddress(fromEmail, "HR Information")
                };

                mail.To.Add(toEmail);

                if (isEmailVGM == true)
                {
                    if (!string.IsNullOrEmpty(emailTBP))
                        CcEmail = emailVGM + "," + emailTBP + "," + CcEmail;
                    else
                        CcEmail = emailVGM + "," + CcEmail;
                }
                else
                {
                    CcEmail = emailTBP + "," + CcEmail;
                }

                if (CcEmail != string.Empty)
                    mail.CC.Add(CcEmail);

                mail.BodyEncoding = Encoding.UTF8;
                mail.SubjectEncoding = Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;
                smtpClient.Send(mail);
                mail.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
