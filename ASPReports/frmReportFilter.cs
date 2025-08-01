using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;

using LinkQ.Systems;
using LinkQ.Systems.Data;
using LinkQ.Systems.Librarys;
using LinkQ.Systems.Controls;
using LinkQ.Systems.Commons;
using LinkQ.Systems.Elements;
using LinkQ.Systems.Customizes;


namespace LinkQ.Reports
{
    public partial class frmReportFilter : LinkQ.Systems.Customizes.frmEdit
    {
        #region Biến

        private DataRow drReport;
        private DataTable dtFilter;
        private DataRow drFilter;
        public string strDateSlect = string.Empty;

        private string strnam1 = string.Empty;
        private string strnam2 = string.Empty;
        private string strnamNamNay = string.Empty;
        private int nam1;
        private int nam2;
        private int namnay;
        txtTextBox txtMa_NhaMay;
        Control ctrl;
        #endregion

        #region Phương thức
        public frmReportFilter()
        {
            InitializeComponent();

            btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
        }

        new public void Load(DataRow drReport, DataRow drFilter)
        {
            this.drReport = drReport;
            this.drFilter = drFilter;
            this.drEdit = drFilter;

            this.strForm_ID = (string)drReport["Report_ID"];
            this.strForm_ID_Inherits = (string)drReport["Report_ID_Filter"]; //Kế thừa ReportFilter của 1 report khác
                                                                             //strDateSelectOld = drFilter["Chon_Ngay"].ToString();
            LoadLayout();
            GetControl();

            Common.ScaterMemvar(this, ref drFilter);
            this.BindingLanguage();
            LoadListName();


            this.ShowDialog();
        }

        private void GetControl()
        {
            this.FindControl("txtMA_NHAMAY", typeof(txtTextBox), ref ctrl);
            if (ctrl != null)
            {
                txtMa_NhaMay = (txtTextBox)ctrl;
                txtMa_NhaMay.Text = Element.sysMa_NhaMay; //(string)SQLExec.ExecuteReturnValue("SELECT Ma_NhaMay_Default FROM L00MEMBER WHERE Member_Id = '" + Element.sysUser_Id + "'");

                if (!Element.sysIs_Admin && !Common.CheckPermission("ALLOW_CHON_NHAMAY", enuPermission_Type.Allow_Access))
                {
                    txtMa_NhaMay.Visible = false;
                    txtMa_NhaMay.Enabled = false;
                }
                else
                {
                    txtMa_NhaMay.Visible = true;
                    txtMa_NhaMay.Enabled = true;
                }
            }
        }

        //private void BuildControl()
        //{
        //    lblControl lblFilter_Label;
        //    Control ctrlFilter_ID;

        //    //Chiều rộng của một col
        //    iCol_Width = iLeft + iFilter_Label_Width + iFilter_ID_Width + iFilter_Name_Width;
        //    int iMaxRow = (int)Common.MaxDCValue(dtFilter, "Row");
        //    int iMaxCol = (int)Common.MaxDCValue(dtFilter, "Col");

        //    foreach (FilterInfo filterInfo in dicFilterInfo.Values)
        //    {
        //        if (filterInfo.Visible == false)
        //            continue;

        //        //Filter_Label
        //        lblFilter_Label = new lblControl();
        //        lblFilter_Label.AutoSize = true;
        //        lblFilter_Label.Parent = this;
        //        lblFilter_Label.Name = "lbl" + filterInfo.Filter_ID;
        //        lblFilter_Label.Text = filterInfo.Filter_Label;
        //        if (filterInfo.Filter_Label != string.Empty) //Hải sửa: nếu không có label thì kô cần Tag
        //            lblFilter_Label.Tag = filterInfo.Filter_ID;

        //        //Filter_ID
        //        switch (Columns.GetColumnType(filterInfo.Type))
        //        {
        //            case enuColumnType.TextBox:
        //                ctrlFilter_ID = new txtTextBox();
        //                ctrlFilter_ID.Name = "txt" + filterInfo.Filter_ID;
        //                ctrlFilter_ID.Enter += new EventHandler(ctrlFilter_Enter);
        //                ctrlFilter_ID.Validating += new CancelEventHandler(ctrlFilter_Validating);
        //                ((txtTextBox)ctrlFilter_ID).UseAutoFilter = true;
        //                break;
        //            case enuColumnType.ComboBox:
        //                ctrlFilter_ID = new cboControl();
        //                ctrlFilter_ID.Name = "cbo" + filterInfo.Filter_ID;
        //                break;
        //            case enuColumnType.CheckBox:
        //                ctrlFilter_ID = new chkControl();
        //                ctrlFilter_ID.Name = "chk" + filterInfo.Filter_ID;
        //                ctrlFilter_ID.Text = string.Empty;
        //                break;
        //            case enuColumnType.Numeric:
        //                ctrlFilter_ID = new numControl();
        //                ctrlFilter_ID.Name = "num" + filterInfo.Filter_ID;
        //                break;
        //            case enuColumnType.DateTime:
        //                ctrlFilter_ID = new txtDateTime();
        //                ctrlFilter_ID.Name = "dte" + filterInfo.Filter_ID;
        //                break;
        //            case enuColumnType.Enum:
        //                ctrlFilter_ID = new txtEnum();
        //                ctrlFilter_ID.Name = "txt" + filterInfo.Filter_ID;
        //                ((txtEnum)ctrlFilter_ID).InputMask = filterInfo.InputMask;
        //                break;
        //            case enuColumnType.LabelName:
        //                ctrlFilter_ID = new lbtControl();
        //                ctrlFilter_ID.Name = "lbt" + filterInfo.Filter_ID;
        //                ctrlFilter_ID.ForeColor = Color.Blue;
        //                break;

        //            default:
        //                ctrlFilter_ID = new txtTextBox();
        //                break;
        //        }

        //        ctrlFilter_ID.Parent = this;

        //        //Hải sửa cho trường hợp CheckBox
        //        if (Columns.GetColumnType(filterInfo.Type) == enuColumnType.CheckBox)
        //        {
        //            ((CheckBox)ctrlFilter_ID).Checked = filterInfo.Default_Value.StartsWith("1");
        //            ((CheckBox)ctrlFilter_ID).AutoSize = true;
        //            ((CheckBox)ctrlFilter_ID).ForeColor = Color.Tomato;
        //            ctrlFilter_ID.Text = filterInfo.Default_Value_Name;
        //            filterInfo.Default_Value_Name = string.Empty;
        //        }
        //        else
        //        {
        //            ctrlFilter_ID.Text = filterInfo.Default_Value;
        //            ctrlFilter_ID.Tag = filterInfo.Filter_ID;
        //        }

        //        ctrlFilter_ID.TabIndex = (filterInfo.Row) * iMaxCol + filterInfo.Col;

        //        //Filter_Name: la 1 phan cua ctrlFilter_ID do can phai lien ket khi Lookup
        //        if (filterInfo.Filter_Name != string.Empty)
        //        {
        //            filterInfo.lbtName.Parent = this;
        //            filterInfo.lbtName.Name = "lbt" + filterInfo.Filter_Name;
        //            //filterInfo.lbtName.Tag = filterInfo.Filter_Name;
        //            filterInfo.lbtName.Text = filterInfo.Default_Value_Name;
        //        }

        //        //Filter_Label
        //        lblFilter_Label.Top = iTop + (filterInfo.Row - 1) * 20 + (filterInfo.Row - 1) * iRow_Distance;//ctrlFilter = 20
        //        lblFilter_Label.Left = iLeft + (filterInfo.Col - 1) * iCol_Width;

        //        //Filter_ID
        //        ctrlFilter_ID.Top = lblFilter_Label.Top;
        //        ctrlFilter_ID.Left = lblFilter_Label.Left + iFilter_Label_Width;
        //        ctrlFilter_ID.Width = filterInfo.Width;

        //        //Filter_Name
        //        filterInfo.lbtName.Top = ctrlFilter_ID.Top + (ctrlFilter_ID.Height - lblFilter_Label.Height) / 2;
        //        filterInfo.lbtName.Left = ctrlFilter_ID.Left + ctrlFilter_ID.Width + 5;

        //        //Neu Filter_Name dai qua thi xuong dong
        //        if (filterInfo.lbtName.Right > this.Right)
        //        {
        //            filterInfo.lbtName.AutoSize = false;
        //            filterInfo.lbtName.Width = this.Right - filterInfo.lbtName.Left - 20;

        //            int iWidth = filterInfo.lbtName.CreateGraphics().MeasureString(filterInfo.lbtName.Text, filterInfo.lbtName.Font).ToSize().Width;
        //            filterInfo.lbtName.Height = filterInfo.lbtName.Font.Height * Convert.ToInt32((float)iWidth / filterInfo.lbtName.Width + 0.499);

        //            filterInfo.lbtName.Top = ctrlFilter_ID.Top + 4;
        //            filterInfo.lbtName.TextAlign = ContentAlignment.TopLeft;
        //            filterInfo.lbtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        //        }

        //        if (iBotton < ctrlFilter_ID.Bottom)
        //            iBotton = ctrlFilter_ID.Bottom;

        //        if (iBotton < filterInfo.lbtName.Bottom)
        //            iBotton = filterInfo.lbtName.Bottom;
        //    }

        //    lblTitle.Left = iLeft;
        //    txtTitle.Left = iLeft + iFilter_Label_Width;

        //    this.Height += iBotton - txtTitle.Top + iRow_Distance;

        //    int iWidth1 = iMaxCol * iCol_Width + iRight;
        //    int iWidth2 = txtTitle.Left + txtTitle.Width + iRight;
        //    this.Width = iWidth1 < iWidth2 ? iWidth2 : iWidth1;
        //}

        private LinkQ.Systems.Customizes.frmView GetLookupForm(string Table_Lookup)
        {
            string strAsl = (string)SQLExec.ExecuteReturnValue("SELECT Assembly FROM L00LOOKUP WHERE Table_Lookup = '" + Table_Lookup + "'");

            string[] arrStr = strAsl.Split(':');

            if (strAsl != string.Empty)
            {
                if (arrStr.Length != 2)
                {
                    Common.MsgCancel("Định dạng Assembly = " + strAsl + " không đúng");
                    return new LinkQ.Systems.Customizes.frmView();
                }

                string strAssembly = string.Empty;
                string strType = string.Empty;

                strAssembly = arrStr[0];
                strType = "LinkQ." + arrStr[1];

                Assembly asl = Assembly.Load(strAssembly);
                Type type = asl.GetType(strType);

                LinkQ.Systems.Customizes.frmView frm = (LinkQ.Systems.Customizes.frmView)Activator.CreateInstance(type);

                return frm;
            }
            else
            {
                return new frmQuickLookup();
            }

            //return new LinkQ.Systems.Customizes.frmView();

            //switch (Table_Lookup)
            //{
            //    case "L81DMBP":
            //        return new frmDmBp();
            //    case "L81DMCBNV":
            //        return new frmDmCbNv();
            //    case "L81DMDTNH":
            //        return new frmDmNhDt();
            //    case "L81DMDT":
            //        return new frmDmDt();
            //    case "L81DMHD":
            //        return new frmDmHd();
            //    case "L81DMSP":
            //        return new frmDmSp();
            //    case "L81DMJOB":
            //        return new frmDmJob();
            //    case "L81DMKHO":
            //        return new frmDmKho();
            //    case "L81DMKM":
            //        return new frmDmKm();
            //    case "L81DMKV":
            //        return new frmDmKv();
            //    case "L81DMNV":
            //        return new frmDmNv();
            //    case "L81DMTHUE":
            //        return new frmDmThue();
            //    case "L81DMTK":
            //        return new frmDmTk();
            //    case "L81DMTTE":
            //        return new frmDmTte();
            //    case "L81DMVTNH":
            //        return new frmDmNhVt();
            //    case "L81DMVT":
            //        return new frmDmVt();
            //    case "L81DMTC":
            //        return new frmDmTc();
            //    case "L81DMSO":
            //        return new frmDmSo();
            //    default:
            //        return new frmQuickLookup();
            //}
        }

        private bool FormCheckValid()
        {
            bool bvalid = true;

            Control ctrl = this.FindInValidControl(this);

            if (ctrl != null)
            {
                if (ctrl.Name.Length > 3)
                    Common.MsgOk(Languages.GetLanguage(ctrl.Name.Substring(3)) + " " +
                                  Languages.GetLanguage("Not_Null"));
                else
                    Common.MsgOk(ctrl.Name + " " +
                                  Languages.GetLanguage("Not_Null"));

                return false;
            }

            /*Haids:Phân quyền chạy báo cáo theo năm, Phân quyền tài khoản
              Thêm đối tượng phần quyền năm trong L00OBJECT với Mã Object = Năm */
            foreach (DataColumn dc in drFilter.Table.Columns)
            {
                if (dc.ColumnName == "Ngay_Ct1" || dc.ColumnName == "Ngay_Ct2" || dc.ColumnName == "NGAY_DN" || dc.ColumnName == "NGAY_CT2")
                {
                    if (drFilter.Table.Columns.Contains("Ngay_Ct1"))
                    {
                        strnam1 = Library.DateToStr((DateTime)drFilter["Ngay_Ct1"]);
                        nam1 = Int32.Parse(strnam1.Split('/')[2]);
                    }
                    if (drFilter.Table.Columns.Contains("Ngay_Ct2"))
                    {
                        strnam2 = Library.DateToStr((DateTime)drFilter["Ngay_Ct2"]);
                        nam2 = Int32.Parse(strnam2.Split('/')[2]);
                    }
                    if (drFilter.Table.Columns.Contains("Ngay_Dn"))
                    {
                        strnamNamNay = Library.DateToStr((DateTime)drFilter["Ngay_Dn"]);
                        namnay = Int32.Parse(strnamNamNay.Split('/')[2]);
                    }
                    if (drFilter[dc] != DBNull.Value)
                    {
                        DataTable dtPermisionNam;
                        dtPermisionNam = SQLExec.ExecuteReturnDt("SELECT * FROM L00PERMISSION WHERE Member_Id = '" + Element.sysUser_Id + "'");
                        if (dtPermisionNam.Rows.Count <= 0)
                            return true;

                        foreach (DataRow dr in dtPermisionNam.Rows)
                        {
                            string strPermisionNam = (string)dr["OBJECT_ID"];

                            if ((nam1.ToString() == strPermisionNam && (bool)dr["ALLOW_ACCESS"]) || (nam2.ToString() == strPermisionNam && (bool)dr["ALLOW_ACCESS"]) || (namnay.ToString() == strPermisionNam && (bool)dr["ALLOW_ACCESS"]))
                            {
                                Common.MsgCancel("Người dùng [" + Element.sysUser_Id + "]: không có dữ liệu năm [" + strPermisionNam + "]");
                                return false;
                            }
                        }

                    }
                }
            }

            //Phân quyền tài khoản. 
            DataTable dtPermisionTK;
            dtPermisionTK = SQLExec.ExecuteReturnDt("SELECT * FROM L00PERMISSIONTK WHERE Member_Id = '" + Element.sysUser_Id + "'");
            if (dtPermisionTK.Rows.Count <= 0)
                return true;

            if (!Element.sysIs_Admin)
                foreach (DataColumn dc in drFilter.Table.Columns)
                {
                    if (dc.ColumnName == "TK" || dc.ColumnName == "TK_NO" || dc.ColumnName == "TK_CO" || dc.ColumnName == "TK_DU")
                    {
                        if (drFilter[dc] != DBNull.Value && (string)drFilter[dc] != string.Empty)
                        {
                            {
                                string strTk = (string)drFilter[dc];

                                foreach (DataRow dr in dtPermisionTK.Rows)
                                {
                                    string strPermisionTK = (string)dr["TK"];

                                    if (strTk == strPermisionTK && (bool)dr["ALLOW_VIEW"])
                                    {
                                        Common.MsgCancel("Người dùng [" + Element.sysUser_Id + "] không được xem tài khoản [" + (string)drFilter[dc] + "]");
                                        return false;
                                    }

                                }
                            }
                        }
                    }
                }

            //if (DataTool.SQLCheckExist("sys.Objects", "Name", "sp_CheckPermissionTk"))
            //{
            //    foreach (DataColumn dc in drFilter.Table.Columns)
            //    {
            //        if (dc.ColumnName == "TK" && drFilter[dc] != DBNull.Value && (string)drFilter[dc] != string.Empty)
            //        {
            //            Hashtable htPara = new Hashtable();
            //            htPara.Add("MEMBER_ID", Element.sysUser_Id);
            //            htPara.Add("TK", drFilter[dc]);

            //            DataTable dtPermissionTk = SQLExec.ExecuteReturnDt("sp_CheckPermissionTk", htPara, CommandType.StoredProcedure);

            //            if (dtPermissionTk.Select("Type = 'VIEW'").Length == 1 && (bool)(dtPermissionTk.Select("Type = 'VIEW'")[0])["Allow"])
            //            {
            //                Common.MsgCancel("Người dùng [" + Element.sysUser_Id + "] không được xem tài khoản [" + (string)drFilter[dc] + "]");
            //                return false;
            //            }
            //        }
            //    }
            //}

            return true;
        }

        #endregion

        #region Sự kiện

        void btAccept_Click(object sender, EventArgs e)
        {
            Common.GatherMemvar(this, ref drFilter);

            if (this.FormCheckValid())
            {
                //foreach (DataColumn dc in drFilter.Table.Columns)
                //{
                //    string strColumnName = dc.ColumnName;
                //    //if (dicFilterInfo.ContainsKey(strColumnName) && dicFilterInfo[strColumnName].Visible == false)
                //    //    drFilter[strColumnName] = dicFilterInfo[strColumnName].Default_Value;
                //}

                isAccept = true;
                if (drFilter.Table.Columns.Contains("Ngay_Ct1"))
                    Element.sysNgay_Ct1 = (DateTime)drFilter["Ngay_Ct1"];

                if (drFilter.Table.Columns.Contains("Ngay_Ct2"))
                    Element.sysNgay_Ct2 = (DateTime)drFilter["Ngay_Ct2"];

                if (drFilter.Table.Columns.Contains("DateSelect"))
                    Element.sysDateSelect = drFilter["DateSelect"].ToString();

                this.Close();
            }
        }

        void btCancel_Click(object sender, EventArgs e)
        {
            isAccept = false;
            this.Close();
        }

        #endregion
    }

    class FilterInfo
    {
        public string Filter_ID = string.Empty;
        public string Filter_Name = string.Empty;
        public string Filter_Label = string.Empty;
        public string Default_Value = string.Empty;
        public string Default_Value_Name = string.Empty;
        public string Type = "T";
        public string InputMask = string.Empty;
        public int Width = 120;
        public int Scale = 0;
        public int Col = 1;
        public int Row = 1;
        public bool Require = true;
        public bool Visible = true;
        public string Table_Lookup = string.Empty;
        public string Column_Lookup = string.Empty;
        public string Column_Lookup_Name = string.Empty;
        public string LookupKeyFilter = string.Empty;
        public string LookupKeyValid = string.Empty;
        public lbtControl lbtName = new lbtControl();

        public FilterInfo()
        {
            lbtName.AutoSize = true;
            lbtName.Text = Default_Value_Name;
        }
    }
}