﻿using ASPData; using ASPData.ASPDAO; using ASPData.ASPDTO; using ASPData.ProdStatisticDTO; using DevExpress.Printing.Core.PdfExport.Metafile; using DevExpress.XtraEditors; using System; using System.Collections.Generic; using System.ComponentModel; using System.Data; using System.Drawing; using System.Globalization; using System.Linq; using System.Net.Mail; using System.Text; using System.Threading; using System.Threading.Tasks; using System.Windows.Forms;  namespace ASPProject.HRAbsenceDoc {     public partial class frmHRAbsenceEmpDocEdit : DevExpress.XtraEditors.XtraForm     {         public string userName;         public frmMain frm;         public delegate void _deDongTab();         public _deDongTab deDongTab;         public int iNgonNgu;          private readonly SQLHelper _sqlHelper = new SQLHelper();         ProdStatisticDAO prodDao = new ProdStatisticDAO();         ProdStatisticDTO prodDto = new ProdStatisticDTO();         HRAbsenceDAO hrDao = new HRAbsenceDAO();         HRAbsenceDTO hrDto = new HRAbsenceDTO();         SQLHelper sqlHelper = new SQLHelper();          public frmHRAbsenceEmpDocEdit()         {             InitializeComponent();              this.Load += FrmHRAbsenceEmpDocEdit_Load;             btSubmit.Click += BtSubmit_Click;             btCancel.Click += BtCancel_Click;         }          private void FrmHRAbsenceEmpDocEdit_Load(object sender, EventArgs e)         {             var dicParams = new Dictionary<string, string>()             {                 { "@EmpID", userName }             };              lblLineID.Text = (string)_sqlHelper.ExecQuerySacalar("SELECT TOP 1 ISNULL(LineID, '') FROM ASPEmployee WHERE EmpID = '" + userName + "'");              if (iNgonNgu == 1)             {                 LoadEL();             }             else             {                 LoadTV();             }              this.ActiveControl = lkeEmpID;              lkeEmpID.Properties.DataSource = prodDao.GetEmployeeListByUsername(string.Empty, userName);             lkeEmpID.Properties.ValueMember = "EmpID";             lkeEmpID.Properties.DisplayMember = "EmpName";             lkeEmpID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;             lkeEmpID.Properties.PopupFilterMode = PopupFilterMode.Contains;              lkeTypeOfAbsence1.Properties.DataSource = prodDao.GetTypeOfAbsence();             lkeTypeOfAbsence1.Properties.ValueMember = "TypeOfAbsence";             lkeTypeOfAbsence1.Properties.DisplayMember = "TypeOfAbsence";             lkeTypeOfAbsence1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;             lkeTypeOfAbsence1.Properties.PopupFilterMode = PopupFilterMode.Contains;              lkeTypeOfAbsence2.Properties.DataSource = prodDao.GetTypeOfAbsence();             lkeTypeOfAbsence2.Properties.ValueMember = "TypeOfAbsence";             lkeTypeOfAbsence2.Properties.DisplayMember = "TypeOfAbsence";             lkeTypeOfAbsence2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;             lkeTypeOfAbsence2.Properties.PopupFilterMode = PopupFilterMode.Contains;              lkeTypeOfAbsence3.Properties.DataSource = prodDao.GetTypeOfAbsence();             lkeTypeOfAbsence3.Properties.ValueMember = "TypeOfAbsence";             lkeTypeOfAbsence3.Properties.DisplayMember = "TypeOfAbsence";             lkeTypeOfAbsence3.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;             lkeTypeOfAbsence3.Properties.PopupFilterMode = PopupFilterMode.Contains;              //             lkeEmailSup.Properties.DataSource = hrDao.GetHRSupEmpEmail(userName);             lkeEmailSup.Properties.ValueMember = "Email";             lkeEmailSup.Properties.DisplayMember = "FullName";             lkeEmailSup.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;             lkeEmailSup.Properties.PopupFilterMode = PopupFilterMode.Contains;         }          public void LoadTV()         {             iNgonNgu = 0;             CultureInfo objCultureInfo = Thread.CurrentThread.CurrentCulture;         }         public void LoadEL()         {             iNgonNgu = 1;             CultureInfo objCultureInfo = Thread.CurrentThread.CurrentCulture;             this.Text = "Absence Doc";         }          private bool FormCheckValid()         {             if (string.IsNullOrEmpty(Convert.ToString(lkeEmpID.EditValue)))             {                 XtraMessageBox.Show("Vui lòng chọn nhân viên.");                 return false;             }                  if (Convert.ToDateTime(dtpTimeOff1.EditValue).Year < DateTime.Now.Year && Convert.ToDateTime(dtpTimeOff2.EditValue).Year < DateTime.Now.Year &&                     Convert.ToDateTime(dtpTimeOff3.EditValue).Year < DateTime.Now.Year)             {                 XtraMessageBox.Show("Vui lòng nhập ngày xin nghỉ phép.");                 return false;             }              if (string.IsNullOrEmpty(Convert.ToString(txtReasonOfAbsence.Text)))             {                 XtraMessageBox.Show("Vui lòng nhập lý do xin nghỉ.");                 return false;             }                             return true;         }          private void BtSubmit_Click(object sender, EventArgs e)         {             if (!FormCheckValid())                 return;              if (Convert.ToDateTime(dtpTimeOff1.EditValue).Year >= DateTime.Now.Year)             {                 hrDto.EmpID = Convert.ToString(lkeEmpID.EditValue);                 hrDto.TimeOff = Convert.ToDateTime(dtpTimeOff1.EditValue).Date;                 hrDto.NumDateOff = Convert.ToDouble(txtNumDateOff1.EditValue);                 hrDto.TypeOfAbsence = Convert.ToString(lkeTypeOfAbsence1.EditValue);                 hrDto.ReasonOfAbsence = Convert.ToString(txtReasonOfAbsence.Text);                 hrDto.CreatedBy = userName;                 hrDto.CreatedDate = DateTime.Now.Date;                  hrDao.InsertHRAbsenceEmp(hrDto);             }              if (Convert.ToDateTime(dtpTimeOff2.EditValue).Year >= DateTime.Now.Year)             {                 hrDto.EmpID = Convert.ToString(lkeEmpID.EditValue);                 hrDto.TimeOff = Convert.ToDateTime(dtpTimeOff2.EditValue).Date;                 hrDto.NumDateOff = Convert.ToDouble(txtNumDateOff2.EditValue);                 hrDto.TypeOfAbsence = Convert.ToString(lkeTypeOfAbsence2.EditValue);                 hrDto.ReasonOfAbsence = Convert.ToString(txtReasonOfAbsence.Text);                 hrDto.CreatedBy = userName;                 hrDto.CreatedDate = DateTime.Now.Date;                  hrDao.InsertHRAbsenceEmp(hrDto);             }               if (Convert.ToDateTime(dtpTimeOff3.EditValue).Year >= DateTime.Now.Year)             {                 hrDto.EmpID = Convert.ToString(lkeEmpID.EditValue);                 hrDto.TimeOff = Convert.ToDateTime(dtpTimeOff3.EditValue).Date;                 hrDto.NumDateOff = Convert.ToDouble(txtNumDateOff3.EditValue);                 hrDto.TypeOfAbsence = Convert.ToString(lkeTypeOfAbsence3.EditValue);                 hrDto.ReasonOfAbsence = Convert.ToString(txtReasonOfAbsence.Text);                 hrDto.CreatedBy = userName;                 hrDto.CreatedDate = DateTime.Now.Date;                  hrDao.InsertHRAbsenceEmp(hrDto);             }              SendMail("EmpSubmitLeave", string.Empty, Convert.ToString(lkeEmpID.EditValue), string.Empty, string.Empty);              XtraMessageBox.Show("Đã nộp đơn thành công.");         }          private void BtCancel_Click(object sender, EventArgs e)         {             this.Close();            }          private bool SendMail(string MailID, string LeaveFlowID, string MailEmpID, string MailMngID, string DenyReason)         {             try             {                 var dicParams = new Dictionary<string, object>()                 {                     { "@MailID", MailID }                 };                  DataTable dtEmail = sqlHelper.ExecQueryDataAsDataTable("SELECT * FROM ASPExcuteEmailList WHERE ID = @MailID", dicParams);                  if (dtEmail.Rows.Count == 0)                     return false;                  DataRow drSendMail = dtEmail.Rows[0];                  string strTitle = "";                 string strbody = "";                 string fromEmail = drSendMail["Email"].ToString();                 string password = drSendMail["EmailPassword"].ToString();                 string host = drSendMail["HostMail"].ToString() != string.Empty ? drSendMail["HostMail"].ToString() : "smtp.gmail.com";                 int post = drSendMail["Port"].ToString() != string.Empty ? Convert.ToInt32(drSendMail["Port"]) : 587;                 string CcEmail = drSendMail["EmailCC"].ToString();                  if (!string.IsNullOrEmpty(MailMngID))                 {                     CcEmail = CcEmail + "," + MailMngID;                 }                       DataTable dtEmpID = hrDao.HRAbsenceGetMailEmp(MailEmpID);                  if (dtEmpID.Rows.Count == 0)                     return false;                  DataRow drEmpID = dtEmpID.Rows[0];                  // Lấy email nhận                 string toEmail = Convert.ToString(lkeEmailSup.EditValue); //drEmpID["Email"].ToString();                 //lay cc cua email nhan                 dicParams = new Dictionary<string, object>()
                {
                    { "@Email", Convert.ToString(lkeEmailSup.EditValue) }
                };                  DataTable dtToEmail = _sqlHelper.ExecQueryDataAsDataTable("SELECT * FROM ASPEmpSupEmail WHERE Email = @Email", dicParams);                  string toCcMail = string.Empty;                  if (dtToEmail.Rows.Count > 0)                     toCcMail = (string)dtToEmail.Rows[0]["EmailCc"];                  if (toCcMail != string.Empty)                     CcEmail = CcEmail + "," + toCcMail;                  string maCbNv = drEmpID["EmpID"].ToString();                 string tenCbNv = drEmpID["EmpName"].ToString();                 string tenBp = drEmpID["EmpDept"].ToString();                  strTitle = drSendMail["EmailTitle"].ToString();                 strbody = drSendMail["EmailContent"].ToString();                  strTitle = strTitle.Replace("{EmpID}", maCbNv);                 strTitle = strTitle.Replace("{EmpName}", tenCbNv);                  strbody = strbody.Replace("{EmpID}", maCbNv);                 strbody = strbody.Replace("{EmpName}", tenCbNv);                 strbody = strbody.Replace("{EmpDept}", tenBp);                 strbody = strbody.Replace("{DenyReason}", DenyReason);                 strbody = strbody.Replace("{LeaveFlowID}", LeaveFlowID);                  var smtpClient = new SmtpClient(host, post)                 {                     UseDefaultCredentials = false,                     Credentials = new System.Net.NetworkCredential(fromEmail, password),                     DeliveryMethod = SmtpDeliveryMethod.Network,                     EnableSsl = true,                     Timeout = 0                 };                  var mail = new MailMessage                 {                     Body = strbody,                     Subject = strTitle,                     From = new MailAddress(fromEmail, tenCbNv)                 };                  mail.To.Add(toEmail);                 if (CcEmail != string.Empty)                     mail.CC.Add(CcEmail);                 mail.BodyEncoding = System.Text.Encoding.UTF8;                 mail.IsBodyHtml = true;                 mail.Priority = MailPriority.High;                 smtpClient.Send(mail);                 mail.Dispose();                 return true;             }             catch (Exception ex)             {                 return false;             }           }      } } 