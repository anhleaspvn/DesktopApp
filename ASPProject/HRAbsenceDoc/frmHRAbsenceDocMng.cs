using ASPData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ASPGoogleSheet;
using System.Dynamic;
using ASPData.ASPDTO;
using ASPData.ASPDAO;
using DevExpress.XtraEditors;
using System.Globalization;
using System.Drawing;
using System.Net.Mail;

namespace ASPProject.HRAbsenceDoc
{
    public partial class frmHRAbsenceDocMng : DevExpress.XtraEditors.XtraForm
    {
        public frmMain frm;
        public delegate void _deDongTab();
        public _deDongTab deDongTab;
        public int iNgonNgu;
        public string userName;

        private SQLHelper sqlhelper = new SQLHelper();
        BindingSource bdsGGSData = new BindingSource();
        DataTable dtGGSData = new DataTable();
        private HRAbsenceDTO hrDto = new HRAbsenceDTO();
        private HRAbsenceDAO hrDao = new HRAbsenceDAO();
        private List<string> listTypeEmp = new List<string>();

        public frmHRAbsenceDocMng()
        {
            InitializeComponent();
            this.Load += FrmHRAbsenceDocMng_Load;

            lkeTypeEmp.EditValue = "Công nhân";

            btReadGGS.Click += BtReadGGS_Click;
            btFilter.Click += BtFilter_Click;
            gridHRAbsenceView.RowStyle += GridHRAbsenceView_RowStyle;
            gridHRAbsenceView.RowCellClick += GridHRAbsenceView_RowCellClick;
            //rtxtDeniedReason.TextChanged += RtxtDeniedReason_TextChanged;
            bdsGGSData.PositionChanged += BdsGGSData_PositionChanged;
            //btDeny.Click += BtDeny_Click;
            btCancelLeave.Click += BtCancelLeave_Click;
            btEditLeave.Click += BtEditLeave_Click;
        }

        private void FrmHRAbsenceDocMng_Load(object sender, EventArgs e)
        {
            dtpFromDate.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpToDate.EditValue = Convert.ToDateTime(dtpFromDate.EditValue).AddMonths(1).AddDays(-1);

            listTypeEmp.Add("Văn phòng");
            listTypeEmp.Add("Công nhân");

            lkeTypeEmp.Properties.DataSource = listTypeEmp;
            
            LoadData();
        }

        private static DateTimeOffset FromString(string offsetString)
        {
            DateTimeOffset offset;

            if (!DateTimeOffset.TryParse(offsetString, out offset))
            {

            }

            return offset;
        }

        private void LoadData()
        {
            hrDto.FromDate = Convert.ToDateTime(dtpFromDate.EditValue);
            hrDto.ToDate = Convert.ToDateTime(dtpToDate.EditValue);
            hrDto.AHDStatus = false;
            hrDto.Username = userName;
            hrDto.TypeEmp = Convert.ToString(lkeTypeEmp.EditValue) == "Văn phòng" ? 0 : 1;

            DataTable dtHRAbsence = new DataTable();

            dtHRAbsence = hrDao.GetHRAbsence(hrDto);

            bdsGGSData.DataSource = dtHRAbsence;
            gridHRAbsence.DataSource = bdsGGSData;
        }

        private void BtReadGGS_Click(object sender, EventArgs e)
        {
            try
            {
                string credentialFile = "credentials.json";
                string spreadSheetID = "1be_VRZXPCLtrgpGaHRAk5TprGjDGXbJz6J4Y2uJdJCw";

                GoogleSheetsHelper ggs = new GoogleSheetsHelper(credentialFile, spreadSheetID);
                GoogleSheetParameters ggsParams = new GoogleSheetParameters();
                ggsParams.SheetName = "HSUV";
                ggsParams.FirstRowIsHeaders = true;
                ggsParams.RangeRowStart = 1;
                ggsParams.RangeColumnStart = 1;
                ggsParams.RangeColumnEnd = 9;
                ggsParams.RangeRowEnd = 10000;

                List<ExpandoObject> lstDt = ggs.GetDataFromSheet(ggsParams);

                DataTable dtHRAbsence = new DataTable();
                dtHRAbsence = GGSExtension.ToDataTable(lstDt);

                foreach (DataRow dr in dtHRAbsence.Rows)
                {
                    hrDto.TimeStamp = FromString(dr[0].ToString());  //(DateTimeOffset)dr[0]; //(DateTimeOffset)DateTime.Now;
                    hrDto.FactoryID = Convert.ToString(dr[1]);
                    hrDto.EmpID = Convert.ToString(dr[2]);
                    hrDto.EmpName = Convert.ToString(dr[3]);
                    hrDto.EmpPosition = Convert.ToString(dr[4]);
                    hrDto.TimeOff = Convert.ToDateTime(dr[5].ToString());
                    hrDto.NumDateOff = Convert.ToDouble(dr[6]);
                    hrDto.TypeOfAbsence = Convert.ToString(dr[7]);
                    hrDto.ReasonOfAbsence = Convert.ToString(dr[8]);
                   
                    hrDto.CreatedBy = userName;
                    hrDto.CreatedDate = DateTime.Now;

                    DataTable dtCheckHRAbsence = new DataTable();
                    dtCheckHRAbsence = hrDao.CheckHRAbsence(hrDto);

                    bool isHRAbsence = false;

                    if (dtCheckHRAbsence.Rows.Count > 0)
                    {
                        isHRAbsence = Convert.ToBoolean(dtCheckHRAbsence.Rows[0][0]);
                    }

                    if (isHRAbsence == true)
                        hrDao.InsertHRAbsence(hrDto);
                }

                LoadData();
            }
            catch (Exception ex)
            {

            }
        }

        private void BtFilter_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        //private void BtDeny_Click(object sender, EventArgs e)
        //{
        //    if (bdsGGSData.Position < 0)
        //        return;

        //    DataRow drCurrent = ((DataRowView)bdsGGSData.Current).Row;

        //    if (drCurrent == null)
        //    {
        //        XtraMessageBox.Show("Vui lòng chọn nhân viên.");
        //        return;
        //    }

        //    if (string.IsNullOrEmpty(rtxtDeniedReason.Text) || rtxtDeniedReason.Text.Length <= 1)
        //    {
        //        XtraMessageBox.Show("Vui lòng nhập lý do từ chối.");
        //        return;
        //    }

        //    if (XtraMessageBox.Show("Bạn có muốn gửi lý do từ chối đơn xin nghỉ phép đến nhân viên ?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
        //    {
        //        bool bSend = SendMail("DenyLeave", string.Empty, drCurrent["EmpID"].ToString(), string.Empty, rtxtDeniedReason.Text);

        //        if (bSend)
        //            XtraMessageBox.Show("Đã gửi mail thành công.");
        //    }
        //}

        private void BtCancelLeave_Click(object sender, EventArgs e)
        {
            if (bdsGGSData.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsGGSData.Current).Row;

            DataTable dtCheckPermission = hrDao.HRCheckPermissionLeave(userName);

            if (dtCheckPermission.Rows.Count == 0 && Convert.ToString(drCurrent["EmpID"]).Trim().ToUpper() != userName.Trim().ToUpper())
            {
                XtraMessageBox.Show("Bạn không được quyền huỷ phép này !");
                return;
            }    

            if (drCurrent == null)
            {
                XtraMessageBox.Show("Vui lòng chọn nhân viên.");
                return;
            }

            bool duyetHr = Convert.ToBoolean(drCurrent["HRStatus"]);

            if (duyetHr == true)
            {
                XtraMessageBox.Show("Đơn nghỉ phép của bạn đã được HR duyệt, vui lòng liên hệ HR để huỷ phép !");
                return;
            }   
            
            if (XtraMessageBox.Show("Bạn có muốn huỷ phép ?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                hrDto.TimeStamp = (DateTimeOffset)drCurrent[1];

                hrDao.UpdateCancelHRAbsence(hrDto);

                XtraMessageBox.Show("Đã huỷ phép thành công !");
            }

           
        }

        private void BtEditLeave_Click(object sender, EventArgs e)
        {
            if (bdsGGSData.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsGGSData.Current).Row;

            if (Convert.ToString(drCurrent["EmpID"]).Trim().ToUpper() != userName.Trim().ToUpper())
            {
                XtraMessageBox.Show("Bạn không được quyền sửa phép này !");
                return;
            }

            if (drCurrent == null)
            {
                XtraMessageBox.Show("Vui lòng chọn nhân viên.");
                return;
            }

            bool duyetHr = Convert.ToBoolean(drCurrent["HRStatus"]);
            bool duyetTp = Convert.ToBoolean(drCurrent["AHDStatus"]);

            if (duyetHr == true || duyetTp == true)
            {
                XtraMessageBox.Show("Đơn nghỉ phép của bạn đã được duyệt, vui lòng liên hệ quản lý để sửa phép !");
                return;
            }

            frmHRAbsenceEdit frmEdit = new frmHRAbsenceEdit();
            frmEdit.Timestamp = (DateTimeOffset)drCurrent[1];
            frmEdit.Show();
        }


        private void GridHRAbsenceView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            DataRow dRow = gridHRAbsenceView.GetDataRow(e.RowHandle);

            if (dRow == null)
                return;

            double numDateOff = Convert.ToDouble(dRow["NumDateOff"]);
            double sumRemainAbsense = Convert.ToDouble(dRow["SumRemainAbsense"]);

            if (numDateOff > sumRemainAbsense)
                e.Appearance.BackColor = Color.Yellow;
        }

        private void GridHRAbsenceView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            DataRow drCurrent = ((DataRowView)bdsGGSData.Current).Row;

            var dicParams = new Dictionary<string, object>
                {
                    { "@TimeStamp", (DateTimeOffset)drCurrent[1] }
                };

            DataTable dtUpdate = sqlhelper.ExecQueryDataAsDataTable("SELECT * FROM ASPHRAbsenceMng WHERE [Timestamp] = @TimeStamp", dicParams);

            double numdateOff = Convert.ToDouble(drCurrent["NumDateOff"]);
            double sumRemainAbsense = Convert.ToDouble(drCurrent["SumRemainAbsense"]);

            DataTable dtCheckPermission = hrDao.HRCheckPermissionLeave(userName);

            if (numdateOff > sumRemainAbsense)
            {
                XtraMessageBox.Show("Đơn nghỉ phép không hợp lệ, số ngày xin nghỉ phép không vượt quá số ngày phép còn lại.");
                return;
            }

            if (e.Column.FieldName == "AHDStatus")
            {
                if (Convert.ToString(drCurrent["EmpID"]).Trim().ToUpper() == userName.Trim().ToUpper())
                {
                    XtraMessageBox.Show("Không được tự duyệt đơn nghỉ phép của chính bạn.");
                    return;
                }

                if (dtCheckPermission.Rows.Count == 0)
                {
                    XtraMessageBox.Show("Tài khoản chưa được phân quyền để duyệt đơn. Vui lòng liên hệ quản trị viên.");
                    return;
                }
                else
                {
                    DataRow drPer = dtCheckPermission.Rows[0];

                    bool allow = Convert.ToBoolean(drPer["IsHRAbsenceMng"]);
                    bool allowemp = Convert.ToBoolean(drPer["IsHRAbsenceMngEmp"]);

                    if (Convert.ToString(lkeTypeEmp.EditValue) == "Văn phòng")
                        if (allow == false)
                        {
                            XtraMessageBox.Show("Bạn không được phép duyệt / bỏ duyệt đơn nghỉ phép này.");
                            return;
                        }
                    else
                        {
                            if (allowemp == false)
                            {
                                XtraMessageBox.Show("Bạn không được phép duyệt / bỏ duyệt đơn nghỉ phép này.");
                                return;
                            }
                        }    
                }

                bool duyetTp = (bool)drCurrent["AHDStatus"];

                if (duyetTp == false)
                {
                    if (XtraMessageBox.Show("Bạn có muốn duyệt đơn nghỉ phép này không ?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //xu ly duyet
                        hrDto.TimeStamp = (DateTimeOffset)drCurrent[1];
                        hrDto.AHDStatus = !duyetTp;
                        hrDto.AHDBy = userName;
                        hrDto.AHDDate = DateTime.Now;
                        hrDto.HRStatus = dtUpdate.Rows.Count > 0 && !string.IsNullOrEmpty(dtUpdate.Rows[0]["HRStatus"].ToString()) ? Convert.ToBoolean(dtUpdate.Rows[0]["HRStatus"]) : false;
                        hrDto.HRBy = dtUpdate.Rows.Count > 0 && !string.IsNullOrEmpty(dtUpdate.Rows[0]["HRBy"].ToString()) ? Convert.ToString(dtUpdate.Rows[0]["HRBy"]) : string.Empty;
                        hrDto.HRDate = dtUpdate.Rows.Count > 0 && !string.IsNullOrEmpty(dtUpdate.Rows[0]["HRDate"].ToString()) ? Convert.ToDateTime(dtUpdate.Rows[0]["HRDate"]) : Convert.ToDateTime("1900-01-01");
                        hrDto.DLDStatus = dtUpdate.Rows.Count > 0 && !string.IsNullOrEmpty(dtUpdate.Rows[0]["DLDStatus"].ToString()) ? Convert.ToBoolean(dtUpdate.Rows[0]["DLDStatus"]) : false;
                        hrDto.DLDDate = dtUpdate.Rows.Count > 0 && !string.IsNullOrEmpty(dtUpdate.Rows[0]["DLDDate"].ToString()) ? Convert.ToDateTime(dtUpdate.Rows[0]["DLDDate"]) : Convert.ToDateTime("1900-01-01");
                        hrDto.DLDBy = dtUpdate.Rows.Count > 0 && !string.IsNullOrEmpty(dtUpdate.Rows[0]["DLDBy"].ToString()) ? Convert.ToString(dtUpdate.Rows[0]["DLDBy"]) : string.Empty;
                        //
                        hrDao.UpdateHRAbsence(hrDto);
                        //
                        drCurrent["AHDStatus"] = !duyetTp;
                        //
                        bool bSend = SendMail("FlowLeave", "Trưởng bộ phận / BOD", drCurrent["EmpID"].ToString(), userName, string.Empty);
                    }
                }
                else
                {
                    bool duyetHr = (bool)drCurrent["HRStatus"];

                    if (duyetHr == true)
                    {
                        XtraMessageBox.Show("Bạn không được phép bỏ duyệt đơn nghỉ phép này, vì đơn nghỉ phép đã được bộ phận HR duyệt. Vui lòng liên hệ bộ phận HR.");
                        return;
                    }

                    if (XtraMessageBox.Show("Bạn có muốn bỏ duyệt đơn nghỉ phép này không? ", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //xu ly duyet
                        hrDto.TimeStamp = (DateTimeOffset)drCurrent[1];
                        hrDto.AHDStatus = !duyetTp;
                        hrDto.AHDBy = string.Empty;
                        hrDto.AHDDate = Convert.ToDateTime("1900-01-01");
                        hrDto.HRStatus = dtUpdate.Rows.Count > 0 && !string.IsNullOrEmpty(dtUpdate.Rows[0]["HRStatus"].ToString()) ? Convert.ToBoolean(dtUpdate.Rows[0]["HRStatus"]) : false;
                        hrDto.HRBy = dtUpdate.Rows.Count > 0 && !string.IsNullOrEmpty(dtUpdate.Rows[0]["HRBy"].ToString()) ? Convert.ToString(dtUpdate.Rows[0]["HRBy"]) : string.Empty;
                        hrDto.HRDate = dtUpdate.Rows.Count > 0 && !string.IsNullOrEmpty(dtUpdate.Rows[0]["HRDate"].ToString()) ? Convert.ToDateTime(dtUpdate.Rows[0]["HRDate"]) : Convert.ToDateTime("1900-01-01");
                        hrDto.DLDStatus = dtUpdate.Rows.Count > 0 && !string.IsNullOrEmpty(dtUpdate.Rows[0]["DLDStatus"].ToString()) ? Convert.ToBoolean(dtUpdate.Rows[0]["DLDStatus"]) : false;
                        hrDto.DLDDate = dtUpdate.Rows.Count > 0 && !string.IsNullOrEmpty(dtUpdate.Rows[0]["DLDDate"].ToString()) ? Convert.ToDateTime(dtUpdate.Rows[0]["DLDDate"]) : Convert.ToDateTime("1900-01-01");
                        hrDto.DLDBy = dtUpdate.Rows.Count > 0 && !string.IsNullOrEmpty(dtUpdate.Rows[0]["DLDBy"].ToString()) ? Convert.ToString(dtUpdate.Rows[0]["DLDBy"]) : string.Empty;

                        hrDao.UpdateHRAbsence(hrDto);
                        drCurrent["AHDStatus"] = !duyetTp;
                    }
                }
            }
            if (e.Column.FieldName == "DLDStatus")
            {
                if (dtCheckPermission.Rows.Count == 0)
                {
                    XtraMessageBox.Show("Tài khoản chưa được phân quyền để duyệt đơn. Vui lòng liên hệ quản trị viên.");
                    return;
                }
                else
                {
                    DataRow drPer = dtCheckPermission.Rows[0];

                    bool allow = Convert.ToBoolean(drPer["IsLineLeader"]);

                    if (allow == false)
                    {
                        XtraMessageBox.Show("Bạn không được phép duyệt / bỏ duyệt đơn nghỉ phép này.");
                        return;
                    }
                }

                bool duyetTp = (bool)drCurrent["DLDStatus"];

                if (duyetTp == false)
                {
                    if (XtraMessageBox.Show("Bạn có muốn duyệt đơn nghỉ phép này không ?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //xu ly duyet
                        hrDto.TimeStamp = (DateTimeOffset)drCurrent[1];
                        hrDto.AHDStatus = dtUpdate.Rows.Count > 0 && !string.IsNullOrEmpty(dtUpdate.Rows[0]["AHDStatus"].ToString()) ? Convert.ToBoolean(dtUpdate.Rows[0]["AHDStatus"]) : false;
                        hrDto.AHDBy = dtUpdate.Rows.Count > 0 && !string.IsNullOrEmpty(dtUpdate.Rows[0]["AHDBy"].ToString()) ? Convert.ToString(dtUpdate.Rows[0]["AHDBy"]) : string.Empty;
                        hrDto.AHDDate = dtUpdate.Rows.Count > 0 && !string.IsNullOrEmpty(dtUpdate.Rows[0]["AHDDate"].ToString()) ? Convert.ToDateTime(dtUpdate.Rows[0]["AHDDate"]) : Convert.ToDateTime("1900-01-01");
                        hrDto.HRStatus = dtUpdate.Rows.Count > 0 && !string.IsNullOrEmpty(dtUpdate.Rows[0]["HRStatus"].ToString()) ? Convert.ToBoolean(dtUpdate.Rows[0]["HRStatus"]) : false;
                        hrDto.HRBy = dtUpdate.Rows.Count > 0 && !string.IsNullOrEmpty(dtUpdate.Rows[0]["HRBy"].ToString()) ? Convert.ToString(dtUpdate.Rows[0]["HRBy"]) : string.Empty;
                        hrDto.HRDate = dtUpdate.Rows.Count > 0 && !string.IsNullOrEmpty(dtUpdate.Rows[0]["HRDate"].ToString()) ? Convert.ToDateTime(dtUpdate.Rows[0]["HRDate"]) : Convert.ToDateTime("1900-01-01");
                        hrDto.DLDStatus = !duyetTp;
                        hrDto.DLDDate = DateTime.Now;
                        hrDto.DLDBy = userName;
                        //
                        hrDao.UpdateHRAbsence(hrDto);
                        //
                        drCurrent["DLDStatus"] = !duyetTp;
                        //
                        bool bSend = SendMail("FlowLeave", "Trưởng Line", drCurrent["EmpID"].ToString(), userName, string.Empty);
                    }
                }
                else
                {
                    bool duyetHr = (bool)drCurrent["AHDStatus"];

                    if (duyetHr == true)
                    {
                        XtraMessageBox.Show("Bạn không được phép bỏ duyệt đơn nghỉ phép này, vì đơn nghỉ phép đã được trưởng bộ phận duyệt. Vui lòng liên hệ trưởng bộ phận của bạn.");
                        return;
                    }

                    if (XtraMessageBox.Show("Bạn có muốn bỏ duyệt đơn nghỉ phép này không? ", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //xu ly duyet
                        hrDto.TimeStamp = (DateTimeOffset)drCurrent[1];
                        hrDto.AHDStatus = dtUpdate.Rows.Count > 0 && !string.IsNullOrEmpty(dtUpdate.Rows[0]["AHDStatus"].ToString()) ? Convert.ToBoolean(dtUpdate.Rows[0]["AHDStatus"]) : false;
                        hrDto.AHDBy = dtUpdate.Rows.Count > 0 && !string.IsNullOrEmpty(dtUpdate.Rows[0]["AHDBy"].ToString()) ? Convert.ToString(dtUpdate.Rows[0]["AHDBy"]) : string.Empty;
                        hrDto.AHDDate = dtUpdate.Rows.Count > 0 && !string.IsNullOrEmpty(dtUpdate.Rows[0]["AHDDate"].ToString()) ? Convert.ToDateTime(dtUpdate.Rows[0]["AHDDate"]) : Convert.ToDateTime("1900-01-01");
                        hrDto.HRStatus = dtUpdate.Rows.Count > 0 && !string.IsNullOrEmpty(dtUpdate.Rows[0]["HRStatus"].ToString()) ? Convert.ToBoolean(dtUpdate.Rows[0]["HRStatus"]) : false;
                        hrDto.HRBy = dtUpdate.Rows.Count > 0 && !string.IsNullOrEmpty(dtUpdate.Rows[0]["HRBy"].ToString()) ? Convert.ToString(dtUpdate.Rows[0]["HRBy"]) : string.Empty;
                        hrDto.HRDate = dtUpdate.Rows.Count > 0 && !string.IsNullOrEmpty(dtUpdate.Rows[0]["HRDate"].ToString()) ? Convert.ToDateTime(dtUpdate.Rows[0]["HRDate"]) : Convert.ToDateTime("1900-01-01");
                        hrDto.DLDStatus = !duyetTp;
                        hrDto.DLDDate = Convert.ToDateTime("1900-01-01");
                        hrDto.DLDBy = string.Empty;

                        hrDao.UpdateHRAbsence(hrDto);
                        drCurrent["DLDStatus"] = !duyetTp;
                    }
                }
            }
            if (e.Column.FieldName == "HRStatus")
            {
                if (dtCheckPermission.Rows.Count == 0)
                {
                    XtraMessageBox.Show("Tài khoản chưa được phân quyền để duyệt đơn. Vui lòng liên hệ quản trị viên.");
                    return;
                }
                else
                {
                    DataRow drPer = dtCheckPermission.Rows[0];

                    bool allow = Convert.ToBoolean(drPer["IsHRAdmin"]);

                    if (allow == false)
                    {
                        XtraMessageBox.Show("Bạn không được phép duyệt / bỏ duyệt đơn nghỉ phép này.");
                        return;
                    }
                }

                bool duyet1 = (bool)drCurrent["AHDStatus"];

                if (duyet1 == false)
                {
                    XtraMessageBox.Show("Bạn chưa duyệt được đơn nghỉ phép này, do trường bộ phận chưa duyệt.");
                    return;
                }

                bool duyetTp = (bool)drCurrent["HRStatus"];

                if (duyetTp == false)
                {
                    if (XtraMessageBox.Show("Bạn có muốn duyệt đơn nghỉ phép này không ?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //xu ly duyet
                        hrDto.TimeStamp = (DateTimeOffset)drCurrent[1];
                        hrDto.HRStatus = !duyetTp;
                        hrDto.HRBy = userName;
                        hrDto.HRDate = DateTime.Now;
                        hrDto.AHDStatus = dtUpdate.Rows.Count > 0 && !string.IsNullOrEmpty(dtUpdate.Rows[0]["AHDStatus"].ToString()) ? Convert.ToBoolean(dtUpdate.Rows[0]["AHDStatus"]) : false;
                        hrDto.AHDBy = dtUpdate.Rows.Count > 0 && !string.IsNullOrEmpty(dtUpdate.Rows[0]["AHDBy"].ToString()) ? Convert.ToString(dtUpdate.Rows[0]["AHDBy"]) : string.Empty;
                        hrDto.AHDDate = dtUpdate.Rows.Count > 0 && !string.IsNullOrEmpty(dtUpdate.Rows[0]["AHDDate"].ToString()) ? Convert.ToDateTime(dtUpdate.Rows[0]["AHDDate"]) : Convert.ToDateTime("1900-01-01");
                        hrDto.DLDStatus = dtUpdate.Rows.Count > 0 && !string.IsNullOrEmpty(dtUpdate.Rows[0]["DLDStatus"].ToString()) ? Convert.ToBoolean(dtUpdate.Rows[0]["DLDStatus"]) : false;
                        hrDto.DLDDate = dtUpdate.Rows.Count > 0 && !string.IsNullOrEmpty(dtUpdate.Rows[0]["DLDDate"].ToString()) ? Convert.ToDateTime(dtUpdate.Rows[0]["DLDDate"]) : Convert.ToDateTime("1900-01-01");
                        hrDto.DLDBy = dtUpdate.Rows.Count > 0 && !string.IsNullOrEmpty(dtUpdate.Rows[0]["DLDBy"].ToString()) ? Convert.ToString(dtUpdate.Rows[0]["DLDBy"]) : string.Empty;

                        hrDao.UpdateHRAbsence(hrDto);

                        //
                        drCurrent["HRStatus"] = !duyetTp;

                        //xu ly chuyển sang cập nhật công LinkQ
                        hrDto.Stt = hrDao.HRGetNewStt();
                        hrDto.InsertDate = DateTime.Now.Date;
                        hrDto.EmpID = Convert.ToString(drCurrent["EmpID"]);

                        if (dtUpdate.Rows.Count > 0)
                        {
                            if (Convert.ToString(dtUpdate.Rows[0]["TypeOfAbsence"]).Contains("A1") || Convert.ToString(dtUpdate.Rows[0]["TypeOfAbsence"]).Contains("U1"))
                                hrDto.UpdateType = "0-Cập nhật khác";
                            else
                                hrDto.UpdateType = "1-Cập nhật công";
                        }    
                            
                        string[] arrTimekeep = Convert.ToString(drCurrent["TypeOfAbsence"]).Split('-');

                        hrDto.TimekeepID = arrTimekeep.Length > 0 ? arrTimekeep[0].Trim() : string.Empty;

                        hrDto.FromDate = Convert.ToDateTime(drCurrent["TimeOff"]);
                        hrDto.ToDate = Convert.ToDateTime(drCurrent["TimeOff"]).AddDays(Convert.ToInt32(drCurrent["NumDateOff"]));
                        hrDto.FactoryID = Convert.ToString(drCurrent["FactoryID"]);

                        hrDao.InsertLinkQTimekeep(hrDto);

                        bool bSend = SendMail("FlowLeave", "Bộ phận HCNS", drCurrent["EmpID"].ToString(), userName, string.Empty);
                    }
                }
                else
                {
                    if (XtraMessageBox.Show("Bạn có muốn bỏ duyệt đơn nghỉ phép này không? Nếu bỏ duyệt bạn cần kiểm tra và xóa cập nhật phép trên phần mềm LinkQ cho đơn nghỉ phép này", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //xu ly duyet
                        hrDto.TimeStamp = (DateTimeOffset)drCurrent[1];
                        hrDto.HRStatus = !duyetTp;
                        hrDto.HRBy = string.Empty;
                        hrDto.HRDate = Convert.ToDateTime("1900-01-01");
                        hrDto.AHDStatus = dtUpdate.Rows.Count > 0 && !string.IsNullOrEmpty(dtUpdate.Rows[0]["AHDStatus"].ToString()) ? Convert.ToBoolean(dtUpdate.Rows[0]["AHDStatus"]) : false;
                        hrDto.AHDBy = dtUpdate.Rows.Count > 0 && !string.IsNullOrEmpty(dtUpdate.Rows[0]["AHDBy"].ToString()) ? Convert.ToString(dtUpdate.Rows[0]["AHDBy"]) : string.Empty;
                        hrDto.AHDDate = dtUpdate.Rows.Count > 0 && !string.IsNullOrEmpty(dtUpdate.Rows[0]["AHDDate"].ToString()) ? Convert.ToDateTime(dtUpdate.Rows[0]["AHDDate"]) : Convert.ToDateTime("1900-01-01");
                        hrDto.DLDStatus = dtUpdate.Rows.Count > 0 && !string.IsNullOrEmpty(dtUpdate.Rows[0]["DLDStatus"].ToString()) ? Convert.ToBoolean(dtUpdate.Rows[0]["DLDStatus"]) : false;
                        hrDto.DLDDate = dtUpdate.Rows.Count > 0 && !string.IsNullOrEmpty(dtUpdate.Rows[0]["DLDDate"].ToString()) ? Convert.ToDateTime(dtUpdate.Rows[0]["DLDDate"]) : Convert.ToDateTime("1900-01-01");
                        hrDto.DLDBy = dtUpdate.Rows.Count > 0 && !string.IsNullOrEmpty(dtUpdate.Rows[0]["DLDBy"].ToString()) ? Convert.ToString(dtUpdate.Rows[0]["DLDBy"]) : string.Empty;

                        hrDao.UpdateHRAbsence(hrDto);


                        drCurrent["HRStatus"] = !duyetTp;
                    }
                }
            }

            LoadData();
        }

        //private void RtxtDeniedReason_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        DataRow drCurrent = ((DataRowView)bdsGGSData.Current).Row;

        //        if (drCurrent == null)
        //            return;

        //        string deniedReason = !string.IsNullOrEmpty(rtxtDeniedReason.Text) ? rtxtDeniedReason.Text : string.Empty;

        //        var dicParams = new Dictionary<string, object>()
        //        {
        //            { "@DeniedReason",  deniedReason},
        //            { "@Timestamp", drCurrent["Timestamp"] },
        //        };

        //        sqlhelper.ExecQueryNonData("UPDATE ASPHRAbsenceMng SET DeniedReason = @DeniedReason WHERE Timestamp = @Timestamp", dicParams);
        //    }
        //    catch
        //    { }
        //}

        private void BdsGGSData_PositionChanged(object sender, EventArgs e)
        {
            DataRow drCurrent = ((DataRowView)bdsGGSData.Current).Row;

            if (drCurrent == null)
                return;

            //rtxtDeniedReason.Text = Convert.ToString(drCurrent["DeniedReason"]);
        }

        private bool SendMail(string MailID, string LeaveFlowID, string MailEmpID, string MailMngID, string DenyReason)
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
                string fromEmail = drSendMail["Email"].ToString();
                string password = drSendMail["EmailPassword"].ToString();
                string host = drSendMail["HostMail"].ToString() != string.Empty ? drSendMail["HostMail"].ToString() : "smtp.gmail.com";
                int post = drSendMail["Port"].ToString() != string.Empty ? Convert.ToInt32(drSendMail["Port"]) : 587;
                string CcEmail = drSendMail["EmailCC"].ToString();

                DataTable dtMailMngID = sqlhelper.ExecQueryDataAsDataTable("SELECT Email FROM L81DMCBNVASP WHERE Ma_CbNv = '" + MailMngID + "'");

                if (dtMailMngID.Rows.Count > 0)
                {
                    MailMngID = (string)dtMailMngID.Rows[0]["Email"];
                }    
              
                if (!string.IsNullOrEmpty(MailMngID))
                {
                    CcEmail = CcEmail + "," + MailMngID;
                }    


                DataTable dtEmpID = hrDao.HRAbsenceGetMailEmp(MailEmpID);

                if (dtEmpID.Rows.Count == 0)
                    return false;

                DataRow drEmpID = dtEmpID.Rows[0];

                // Lấy email nhận
                string toEmail = drEmpID["Email"].ToString();
                string maCbNv = drEmpID["EmpID"].ToString();
                string tenCbNv = drEmpID["EmpName"].ToString();
                string tenBp = drEmpID["EmpDept"].ToString();

                strTitle = drSendMail["EmailTitle"].ToString();
                strbody = drSendMail["EmailContent"].ToString();

                strTitle = strTitle.Replace("{EmpID}", maCbNv);
                strTitle = strTitle.Replace("{EmpName}", tenCbNv);

                strbody = strbody.Replace("{EmpID}", maCbNv);
                strbody = strbody.Replace("{EmpName}", tenCbNv);
                strbody = strbody.Replace("{EmpDept}", tenBp);
                strbody = strbody.Replace("{DenyReason}", DenyReason);
                strbody = strbody.Replace("{LeaveFlowID}", LeaveFlowID);

                var smtpClient = new SmtpClient(host, post)
                {
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(fromEmail, password),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = true,
                    Timeout = 10000
                };

                var mail = new MailMessage
                {
                    Body = strbody,
                    Subject = strTitle,
                    From = new MailAddress(fromEmail, tenCbNv)
                };

                mail.To.Add(toEmail);
                if (CcEmail != string.Empty)
                    mail.CC.Add(CcEmail);
                mail.BodyEncoding = System.Text.Encoding.UTF8;
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
