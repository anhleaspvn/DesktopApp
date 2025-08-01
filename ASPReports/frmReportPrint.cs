using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataDynamics.ActiveReports;
using DataDynamics;
using DataDynamics.ActiveReports.Export;
using System.Reflection;

using LinkQ.Systems.Librarys;
using LinkQ.Systems.Commons;
using LinkQ.Systems.Customizes;
using LinkQ.Systems;
using LinkQ.Systems.Data;
using LinkQ.Systems.Elements;



namespace LinkQ.Reports
{
    public partial class frmReportPrint : LinkQ.Systems.Controls.frmBase
    {
        private rptFileReport repFile = new rptFileReport();
        public DataRow drPrintColumnsList;
        public DataRow drReport;
        public DataRow drFilter;
        public DataSet dsResult;
        DataRow drPhView = null;
        public DataTable dtDetail;
        public Dictionary<string, ColumnInfo> columnInfos;
        public Dictionary<string, string> dicHeader = new Dictionary<string, string>();
        public Dictionary<string, decimal> dicLuyKe = new Dictionary<string, decimal>();
        List<string> listKey = new List<string>();
        int dbSttRow = 0;

        public string strPDFFile = string.Empty;
        bool IsExportPDF = false;
        object objFile_Data_Report = null;

        public Assembly asmSystem;
        public Assembly asmElement;
        public Assembly asmLibrary;
        public Assembly asmCommon;
        public Assembly asmData;
        public Assembly asmPublic;

        #region Method

        public frmReportPrint()
        {
            InitializeComponent();

            this.asmSystem = Assembly.Load("LinkQ.Systems");
            this.asmElement = Assembly.Load("LinkQ.Systems.Elements");
            this.asmLibrary = Assembly.Load("LinkQ.Systems.Librarys7.0");
            this.asmCommon = Assembly.Load("LinkQ.Systems.Commons7.0");
            this.asmData = Assembly.Load("LinkQ.Systems.Data");
            this.asmPublic = Assembly.Load("LinkQ.Systems.Publics");

            this.KeyDown += new KeyEventHandler(frmReportPrint_KeyDown);

            //Bi loi khi bop bop cai report
            this.viewReport.ReportViewer.ViewType = DataDynamics.ActiveReports.Viewer.ViewType.ContinuousScroll;
            btExport.Click += new EventHandler(btExport_Click);
            btSendMail.Click += new EventHandler(btSendMail_Click);

            btRefresh.Click += btRefresh_Click;
        }

        new public bool Load(DataRow drReport, DataRow drFilter, DataSet dsResult, bool bPreview)
        {
            return Load(drReport, drFilter, dsResult, bPreview, true);
        }

        new public bool Load(DataRow drReport, DataRow drFilter, DataSet dsResult, bool bPreview, DataRow drPrintColumnsList)
        {
            this.drPrintColumnsList = drPrintColumnsList;
            return Load(drReport, drFilter, dsResult, bPreview, true);
        }

        new public bool Load(DataRow drReport, DataRow drFilter, DataSet dsResult, bool bPreview, bool bShowDialog)
        {
            this.drReport = drReport;
            this.drFilter = drFilter;
            this.dsResult = dsResult;
            this.dtDetail = dsResult.Tables[0];

            //Tu Filter
            foreach (DataColumn dc in drFilter.Table.Columns)
            {
                if (!dicHeader.ContainsKey(dc.ColumnName.ToUpper()))
                    dicHeader[dc.ColumnName.ToUpper()] = drFilter[dc.ColumnName].ToString();
            }

            //Tu Report
            foreach (DataColumn dc in drReport.Table.Columns)
            {
                if (!dicHeader.ContainsKey(dc.ColumnName.ToUpper()))
                    dicHeader[dc.ColumnName.ToUpper()] = drReport[dc.ColumnName].ToString();
            }

            //Tu Header (dsResult.Tables[1])
            if (dsResult.Tables.Count > 1 && dsResult.Tables[1].Rows.Count > 0)
            {
                DataRow drHeader = dsResult.Tables[1].Rows[0];

                foreach (DataColumn dc in drHeader.Table.Columns)
                {
                    dicHeader[dc.ColumnName.ToUpper()] = drHeader[dc.ColumnName].ToString();

                    if (dc.ColumnName.ToUpper().StartsWith("DOC_TIEN"))
                    {
                        if (Element.sysLanguage == enuLanguageType.Vietnamese)
                            dicHeader[dc.ColumnName.ToUpper()] = Common.ReadMoney(Convert.ToDouble(drHeader[dc.ColumnName]), Element.sysMa_Tte.ToString());
                        else
                            dicHeader[dc.ColumnName.ToUpper()] = Common.ReadMoneyE(Convert.ToDouble(drHeader[dc.ColumnName]), Element.sysMa_Tte.ToString());
                    }
                }
            }

            dicHeader["MEMBER_NAME"] = DataTool.SQLGetNameByCode("L00MEMBER", "Member_ID", "Member_Name", Element.sysUser_Id);

            //LinkQ.Systems.Elements.Element.dicReport = dicHeader;
            return Load(dicHeader, dtDetail, bPreview, bShowDialog);
        }

        public bool ExportPDF(DataRow drReport, DataRow drFilter, DataSet dsResult, string strPDFFile)
        {
            this.IsExportPDF = true;
            this.strPDFFile = strPDFFile;
            return Load(drReport, drFilter, dsResult, false, false);
        }

        public bool ExportPDF(DataRow drReport, DataRow drFilter, DataSet dsResult, string strPDFFile, object objFile_Data_Report)
        {
            this.objFile_Data_Report = objFile_Data_Report;
            return ExportPDF(drReport, drFilter, dsResult, strPDFFile);
        }

        new public bool Load(DataRow drHeader, DataTable dtDetail, bool bPreview)
        {
            return Load(drHeader, dtDetail, bPreview, true);
        }

        new public bool Load(DataRow drHeader, DataTable dtDetail, bool bPreview, bool bShowDialog)
        {
            string strMa_Tte = string.Empty;
            if (dtDetail != null && dtDetail.Columns.Contains("Ma_Tte") && dtDetail.Rows.Count > 0)
                strMa_Tte = (string)dtDetail.Rows[0]["Ma_Tte"];

            //Hải kiểm tra tồn tại trường
            if (!drHeader.Table.Columns.Contains("Vnd_Nt"))
            {
                drHeader.Table.Columns.Add(new DataColumn("Vnd_Nt", typeof(string)));

                if (drHeader.Table.Columns.Contains("Is_Vnd"))
                    drHeader["Vnd_Nt"] = (bool)drHeader["Is_Vnd"] ? "0" : "1";
                else
                    drHeader["Vnd_Nt"] = "0";
            }

            Dictionary<string, string> dicHeader0 = new Dictionary<string, string>();
            //
            if (drHeader.Table.Columns.Contains("Ngay_Ct"))
            {
                if (Report.PrintType == PrintType.PrintVoucher)
                    dicHeader0["SUBTITLE1"] = Common.ReadDate((DateTime)drHeader["NGAY_CT"], (DateTime)drHeader["NGAY_CT"], Element.sysLanguage);
                else
                    dicHeader0["SUBTITLE1"] = Common.ReadDate((DateTime)drHeader["NGAY_CT"], (DateTime)drHeader["NGAY_CT"], Report.LanguageType);
            }
            foreach (DataColumn dc in drHeader.Table.Columns)
            {
                string strColumnName = dc.ColumnName.ToUpper();
                string strValue = string.Empty;

                if (drHeader[strColumnName] != DBNull.Value)
                {
                    if (dc.DataType == typeof(DateTime))
                        strValue = Library.DateToStr((DateTime)drHeader[strColumnName]);
                    else if (dc.DataType == typeof(double) || dc.DataType == typeof(decimal))
                    {
                        double dbValue = Convert.ToDouble(drHeader[strColumnName]);

                        if (strColumnName.Contains("_NT"))
                        {
                            if (strMa_Tte == Element.sysMa_Tte || drHeader["Vnd_Nt"].Equals("0"))
                                strValue = dbValue.ToString("N" + Report.Format_Tien);
                            else
                                strValue = dbValue.ToString("N" + Report.Format_Tien_Nt);
                        }
                        else
                            strValue = dbValue.ToString("N" + Report.Format_Tien);

                        if (Common.Inlist(strColumnName, Parameters.GetParaValue("FORMAT_LIST_SOLUONG").ToString()))
                            strValue = dbValue.ToString("N" + Report.Format_So_Luong);

                        if (dbValue == 0)
                            strValue = string.Empty;
                    }
                    else
                        strValue = drHeader[strColumnName].ToString();
                }

                dicHeader0.Add(strColumnName, strValue);
            }

            return this.Load(dicHeader0, dtDetail, bPreview, bShowDialog);
        }

        new public bool Load(DataRow drPhView, DataRow drHeader, DataTable dtDetail, bool bPreview, bool bShowDialog)
        {
            this.drPhView = drPhView;
            return Load(drHeader, dtDetail, bPreview, bShowDialog);
        }

        public bool ExportPDF(DataRow drPhView, DataRow drHeader, DataTable dtDetail, string strPDFFile)
        {
            this.IsExportPDF = true;
            this.strPDFFile = strPDFFile;
            return Load(drHeader, dtDetail, false, false);
        }

        new public bool Load(Dictionary<string, string> dicHeader, DataTable dtDetail, bool bPreview)
        {
            return this.Load(dicHeader, dtDetail, bPreview, true);
        }

        new public bool Load(Dictionary<string, string> dicHeader, DataTable dtDetail, bool bPreview, bool bShowDialog)
        {
            this.dicHeader = dicHeader;
            this.dtDetail = dtDetail;

            if (dicHeader.ContainsKey("REPORT_NAME"))
                this.Text = dicHeader["REPORT_NAME"];


            SetDefault();
            Print();

            if (!IsExportPDF)
            {
                if (bPreview)
                {
                    if (bShowDialog)
                        this.ShowDialog();
                    else
                        this.Show();
                }
                else
                {
                    if (bShowDialog)
                    {
                        return viewReport.Document.Print(true, true);
                    }
                    else
                    {
                        return viewReport.Document.Print(false, true);
                    }
                }
            }

            return true;
        }

        private void SetDefault()
        {
            dicHeader["TEN_DV_CQ"] = (string)Parameters.GetParaValue("TEN_DV_CQ");
            object objTen_Dv = SQLExec.ExecuteReturnValue("SELECT Ten_DvCs FROM L00DMDVCS WHERE Ma_DvCs='" + Element.sysMa_DvCs + "'");
            string strTen_Dv = (objTen_Dv == null) ? "" : objTen_Dv.ToString();

            object objDia_Chi_Dv = SQLExec.ExecuteReturnValue("SELECT Dia_Chi_Dv FROM L00DMDVCS WHERE Ma_DvCs='" + Element.sysMa_DvCs + "'");
            string strDia_Chi_Dv = (objDia_Chi_Dv == null) ? "" : objDia_Chi_Dv.ToString();

            strTen_Dv = (Core.Is_Free()) ? strTen_Dv : Element.sysTen_Dvi;
            strDia_Chi_Dv = (Core.Is_Free()) ? strDia_Chi_Dv : Element.sysDia_Chi_Dv;


            dicHeader["TEN_DV"] = strTen_Dv;
            dicHeader["DIA_CHI_DV"] = strDia_Chi_Dv;//(string)Parameters.GetParaValue("DIA_CHI");Haids
            dicHeader["MA_SO_THUE_DV"] = (string)Parameters.GetParaValue("MA_SO_THUE");
            dicHeader["DAI_LY_THUE"] = (string)Parameters.GetParaValue("DAI_LY_THUE");
            dicHeader["MST_DAI_LY"] = (string)Parameters.GetParaValue("MST_DAI_LY");

            string strQuyetDinh = "QUYET_DINH_" + (string)Parameters.GetParaValue("HTTK").ToString();

            if (Languages.GetLanguage(strQuyetDinh) != strQuyetDinh)
                dicHeader["QUYET_DINH"] = Languages.GetLanguage(strQuyetDinh);
            else if ((string)Parameters.GetParaValue("HTTK").ToString() == "15")
                dicHeader["QUYET_DINH"] = "(Ban hành theo QĐ số: 15/2006/QĐ-BTC\n Ngày 20 tháng 03 năm 2006\n của Bộ trưởng BTC)";
            else if ((string)Parameters.GetParaValue("HTTK").ToString() == "200")
            {
                dicHeader["QUYET_DINH"] = "(Ban hành theo Thông tư số: 200/2014/TT-BTC\n Ngày 22/12/2014 của BTC)";
            }
            else if ((string)Parameters.GetParaValue("HTTK").ToString() == "48")
                dicHeader["QUYET_DINH"] = "(Ban hành theo QĐ số 48/2006/QĐ-BTC ngày 14/9/2006 của Bộ trưởng BTC)";
            else if ((string)Parameters.GetParaValue("HTTK").ToString() == "133")
                dicHeader["QUYET_DINH"] = "(Ban hành theo thông tư số 133/2016/TT-BTC\n Ngày 26/08/2016 của BTC)";

            //
            if (drPhView != null)
            {
                if (drPhView["Ma_Ct"].ToString() == "HD")
                {
                    //int j = Convert.ToInt16((string)Parameters.GetParaValue("PRINT_ROWS").ToString()); 
                    for (int i = 1; i <= 10; i++)
                    {
                        if (i <= dtDetail.Rows.Count)
                        {
                            dicHeader["STT" + i.ToString()] = i.ToString();
                            dicHeader["TEN_VT" + i.ToString()] = dtDetail.Rows[i - 1]["Ten_Vt"].ToString();
                            dicHeader["DVT" + i.ToString()] = dtDetail.Rows[i - 1]["Dvt"].ToString();
                            dicHeader["SO_LUONG" + i.ToString()] = (Convert.ToDouble(dtDetail.Rows[i - 1]["So_Luong"]) == 0) ? "" : (Convert.ToDouble(dtDetail.Rows[i - 1]["So_Luong"])).ToString("n");
                            dicHeader["GIA" + i.ToString()] = (Convert.ToDouble(dtDetail.Rows[i - 1]["Gia_Nt"]) == 0) ? "" : (Convert.ToDouble(dtDetail.Rows[i - 1]["Gia_Nt"])).ToString("n");
                            //dicHeader["TIEN" + i.ToString()] = (Convert.ToDouble(dtDetail.Rows[i - 1]["Tien_Nt"]) == 0) ? "" : 
                            //                                    Math.Round(Convert.ToDouble(dtDetail.Rows[i - 1]["Tien_Nt"]),0).ToString("n");
                            //dicHeader["TIEN" + i.ToString()] = (Convert.ToDouble(dtDetail.Rows[i - 1]["Tien_Nt"]) == 0) ? "" : 
                            //                                        decimal.Round( (decimal)dtDetail.Rows[i - 1]["Tien_Nt"],0).ToString("n");
                            string strTien = decimal.Round((decimal)dtDetail.Rows[i - 1]["Tien_Nt"], 0).ToString("n");
                            dicHeader["TIEN" + i.ToString()] = (Convert.ToDouble(dtDetail.Rows[i - 1]["Tien_Nt"]) == 0) ? "" :
                                                                    strTien.Substring(0, strTien.Length - 3);
                        }
                        else
                        {
                            dicHeader["STT" + i.ToString()] = "";
                            dicHeader["TEN_VT" + i.ToString()] = "";
                            dicHeader["DVT" + i.ToString()] = "";
                            dicHeader["SO_LUONG" + i.ToString()] = "";
                            dicHeader["GIA" + i.ToString()] = "";
                            dicHeader["TIEN" + i.ToString()] = "";
                        }
                    }
                }
            }
        }

        private void Print()
        {
            //Hải kiểm tra tồn tại trường
            if (drReport != null && !drReport.Table.Columns.Contains("Vnd_Nt"))
            {
                drReport.Table.Columns.Add(new DataColumn("Vnd_Nt", typeof(string)));

                if (drReport.Table.Columns.Contains("Is_Vnd"))
                    drReport["Vnd_Nt"] = (bool)drReport["Is_Vnd"] ? "0" : "1";
                else
                    drReport["Vnd_Nt"] = "0";
            }

            string strRepFile = string.Empty;

            if (drReport != null && drReport["Vnd_Nt"].Equals(DBNull.Value))
                drReport["Vnd_Nt"] = "0";

            if (drReport != null)
            {
                if ((string)drReport["Vnd_Nt"] == "2")
                    strRepFile = (string)dicHeader["REPORT_FILE"] + "_NT";
                else
                    strRepFile = (string)dicHeader["REPORT_FILE"];
            }
            else
                strRepFile = (string)dicHeader["REPORT_FILE"];

            strRepFile += ".rpx";

            repFile.SetLicense("RGN,RGN Warez Group,DD-APN-30-C01339,W44SSM949SWJ449HSHMF");

            if (LinkQ.Systems.Elements.Collection.Parameters.ContainsKey("REPORT_ONLINE") && LinkQ.Systems.Elements.Collection.Parameters["REPORT_ONLINE"].Equals("1"))
            {
                object objFile_Data = SQLExec.ExecuteReturnValue("SELECT File_Data FROM L00DMFILE WHERE File_Name = '" + strRepFile + "'");

                if (objFile_Data == null || objFile_Data == DBNull.Value)
                {
                    Common.MsgCancel("File :{" + strRepFile + "} " + Languages.GetLanguage("NOT_FOUND"));
                    return;
                }

                byte[] buff = (byte[])objFile_Data;

                Stream stream = new MemoryStream(buff);

                repFile.LoadLayout(stream);
            }
            else
            {
                if (objFile_Data_Report != null && objFile_Data_Report != DBNull.Value)
                {
                    byte[] buff = (byte[])objFile_Data_Report;

                    Stream stream = new MemoryStream(buff);

                    repFile.LoadLayout(stream);
                }
                else
                {

                    string strFileName = Application.StartupPath + @"\Reports\" + strRepFile;
                    if (!System.IO.File.Exists(strFileName))
                    {
                        Common.MsgCancel("File :{" + strFileName + "} " + Languages.GetLanguage("NOT_FOUND"));
                        return;
                    }

                    repFile.LoadLayout(strFileName);
                }
            }

            repFile.PageSettings.Margins.Left = 0F;
            repFile.PageSettings.Margins.Bottom = 0F;
            repFile.PageSettings.Margins.Left = 0F;
            repFile.PageSettings.Margins.Right = 0F;

            numDetailHeight.Value = Convert.ToDecimal(repFile.detail.Height);
            numBottonMargin.Value = Convert.ToDecimal(repFile.PageSettings.Margins.Bottom);
            numPageFooterHeight.Value = Convert.ToDecimal(repFile.pageFooter.Height);

            repFile.DataSource = dtDetail.DefaultView;
            FillHeaderAndFooterInfo();

            repFile.AddAssembly(asmSystem);
            repFile.AddAssembly(asmElement);
            repFile.AddAssembly(asmLibrary);
            repFile.AddAssembly(asmCommon);
            repFile.AddAssembly(asmData);
            repFile.AddAssembly(asmPublic);

            if (drPhView != null && drPhView.Table.Columns.Contains("Ma_Ct"))
            {
                DataRow drDmCt = DataTool.SQLGetDataRowByID("L00DMCT", "Ma_Ct", (string)drPhView["Ma_Ct"]);

                if ((string)Parameters.GetParaValue("IS_TUINHOADON") == "1" && drDmCt.Table.Columns.Contains("Is_TuInHoaDon") && (bool)drDmCt["Is_TuInHoaDon"])
                {
                    string strReport_File = ((string)dicHeader["REPORT_FILE"]).ToUpper();

                    if (Common.Inlist(strReport_File, "RPTCT_HD_BH2T,RPTCT_HD_BH3T,RPTCT_HD_GTGT1E,RPTCT_HD_GTGT2T,RPTCT_HD_GTGT3T,RPTCT_HD_XKT"))
                    {
                        string strfileWatermark = string.Empty;

                        if (dtDetail.Columns.Contains("Mau_So"))
                        {
                            if (dtDetail.Rows.Count > 0 && (string)dtDetail.Rows[0]["Mau_So"] != string.Empty)
                            {
                                string strMau_So = (string)dtDetail.Rows[0]["Mau_So"];
                                strfileWatermark = DataTool.SQLGetNameByCode("L04MAUHD", "Mau_So", "Logo_Nen", strMau_So);
                            }
                        }

                        if (strfileWatermark != string.Empty)
                        {
                            repFile.WatermarkSizeMode = SizeModes.Clip;
                        }
                        else
                        {
                            strfileWatermark = Application.StartupPath + @"\Images\HD_Mau01_Lien1.png";
                            repFile.WatermarkSizeMode = SizeModes.Zoom;
                        }

                        if (File.Exists(strfileWatermark))
                        {
                            repFile.Watermark = Image.FromFile(strfileWatermark);
                            repFile.WatermarkAlignment = PictureAlignment.Center;
                        }
                    }
                }
            }
            if (Core.Is_Demo())
            {
                if (File.Exists(@"images\cus_background.png"))
                {
                    repFile.Watermark = Image.FromFile(@"images\cus_background.png");
                    repFile.WatermarkAlignment = PictureAlignment.Center;
                    repFile.WatermarkSizeMode = SizeModes.Zoom;
                }
            }

            if (repFile.UserData != null && repFile.UserData.Equals("1"))
            {
                if (File.Exists(Application.StartupPath + @"\Images\Logo_Nen_CUS.png"))
                {
                    repFile.Watermark = Image.FromFile(Application.StartupPath + @"\Images\Logo_Nen_CUS.png");
                    repFile.WatermarkAlignment = PictureAlignment.Center;
                    repFile.WatermarkSizeMode = SizeModes.Zoom;
                }
            }

            repFile.pageHeader.BeforePrint += new EventHandler(pageHeader_BeforePrint);
            repFile.FetchData += RepFile_FetchData;
            //repFile.PageEnd += repFile_PageEnd;
            repFile.PageStart += repFile_PageStart;
            repFile.ReportEnd += RepFile_ReportEnd;
            repFile.groupHeader1.Format += GroupHeader1_Format;

            if (LinkQ.Systems.Librarys.Parameters.GetParaValue("DEFAULT_PRINTERNAME").ToString() == "0")
                repFile.Document.Printer.PrinterName = string.Empty;
            //repFile.Document.Printer.PaperKind = System.Drawing.Printing.PaperKind.Custom;

            repFile.Run();

            if (IsExportPDF)
            {
                string strFileName = strPDFFile;
                DataDynamics.ActiveReports.Export.Pdf.PdfExport pdfExport = new DataDynamics.ActiveReports.Export.Pdf.PdfExport();
                pdfExport.NeverEmbedFonts = "";

                try
                {
                    pdfExport.Export(repFile.Document, strFileName);
                    return;

                }
                catch (Exception ex)
                {
                    Common.MsgCancel(ex.Message);
                    return;
                }
            }

            viewReport.Document = repFile.Document;
            repFile.Document.Printer.EndPrint += new System.Drawing.Printing.PrintEventHandler(Printer_EndPrint);
        }


        void pageHeader_BeforePrint(object sender, EventArgs e)
        {

            if (drPhView != null && drPhView.Table.Columns.Contains("Ma_Ct"))
            {
                DataRow drDmCt = DataTool.SQLGetDataRowByID("L00DMCT", "Ma_Ct", (string)drPhView["Ma_Ct"]);

                if ((string)Parameters.GetParaValue("IS_TUINHOADON") == "1" && drDmCt.Table.Columns.Contains("Is_TuInHoaDon") && (bool)drDmCt["Is_TuInHoaDon"])
                {
                    string strReport_File = ((string)dicHeader["REPORT_FILE"]).ToUpper();

                    if (Common.Inlist(strReport_File, "RPTCT_HD_BH2T,RPTCT_HD_BH3T,RPTCT_HD_GTGT2T,RPTCT_HD_GTGT3T,RPTCT_HD_XKT"))
                    {
                        string strfileWatermark = string.Empty;

                        if (dtDetail.Columns.Contains("Mau_So"))
                        {
                            if (dtDetail.Rows.Count > 0 && (string)dtDetail.Rows[0]["Mau_So"] != string.Empty)
                            {
                                string strMau_So = (string)dtDetail.Rows[0]["Mau_So"];
                                strfileWatermark = DataTool.SQLGetNameByCode("L04MAUHD", "Mau_So", "Logo_Nen", strMau_So);
                            }
                        }

                        if (strfileWatermark == string.Empty)
                        {
                            strfileWatermark = Application.StartupPath + @"\Images\HD_Mau01_Lien" + (repFile.PageNumber + 1) + ".png";

                            if (File.Exists(strfileWatermark))
                            {
                                repFile.Watermark = Image.FromFile(strfileWatermark);
                                repFile.WatermarkAlignment = PictureAlignment.Center;
                                repFile.WatermarkSizeMode = SizeModes.Zoom;
                            }
                        }
                    }
                }
            }

        }

        void Printer_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            if (drPhView == null)
                return;

            if (!(drPhView.Table.Columns.Contains("Ma_Ct") && (string)drPhView["Ma_Ct"] != string.Empty))
                return;

            if (!(drPhView.Table.Columns.Contains("Stt") && (string)drPhView["Stt"] != string.Empty))
                return;

            //Namtv them phan kiem tra hoa don tu in
            DataRow drDmCt = DataTool.SQLGetDataRowByID("L00DMCT", "Ma_Ct", (string)drPhView["Ma_Ct"]);

            //Cập nhật số lần in hóa đơn vào L80PH
            if ((string)Parameters.GetParaValue("IS_TUINHOADON") == "1" && drDmCt.Table.Columns.Contains("IS_TUINHOADON") && (bool)drDmCt["IS_TUINHOADON"])
            {
                string strMau_So = DataTool.SQLGetNameByCode("L04CTHD", "Stt", "Mau_So", (string)drPhView["Stt"]);
                string strMau_Report = DataTool.SQLGetNameByCode("L04MAUHD", "Mau_So", "Mau_Report", strMau_So);

                if (strMau_Report.ToUpper() == ((string)dicHeader["REPORT_FILE"]).ToUpper())
                {
                    SQLExec.Execute("UPDATE L80PH SET PrintTimeHD = PrintTimeHD + 1 WHERE Stt = '" + (string)drPhView["Stt"] + "'");
                }
            }

            if (!drPhView.Table.Columns.Contains("Locked") || (bool)drPhView["Locked"])
                return;

            string strLockedCtAfterPrint = (string)Parameters.GetParaValue("LOCKEDCT_AFTERPRINT");
            if (strLockedCtAfterPrint != string.Empty && strLockedCtAfterPrint != "LOCKEDCT_AFTERPRINT")
            {
                if (Common.Inlist(strLockedCtAfterPrint, (string)drPhView["Ma_Ct"]))
                {
                    string strStt = (string)drPhView["Stt"];

                    if (SQLExec.Execute("UPDATE " + (string)drDmCt["Table_Ph"] + " SET Locked = 1 WHERE Stt = '" + strStt + "'"))
                        drPhView["Locked"] = true;
                }
            }
        }

        string ReplaceRTF(string strRTF)
        {
            strRTF = strRTF.Replace(@"\f2\'dd\'d5", @"\u431?\u416?");//Thay thế chữ {ƯƠ}
            strRTF = strRTF.Replace(@"\f0\'dd\'d5", @"\u431?\u416?\f0");//Thay thế chữ {ƯƠ}
            strRTF = strRTF.Replace(@"\'e3", @"\u259?\f0");//Thay thế chữ {ăn}
            strRTF = strRTF.Replace(@"nh\f0\'fd nh\f0\'fd d\'fd\f1\u7899?i", @"nh\u432?\f0  \f1 d\u432?\u7899?i");//Thay thế chữ {như dưới}
            strRTF = strRTF.Replace(@"S\f0\'d5N", @"S\u416?N\f0");//thay thế chữ {SƠN}
            strRTF = strRTF.Replace(@"l\f2\'fd\f0\u7907?ng", @"l\u432?\u7907?ng");//thay thế chữ {lượng}
            strRTF = strRTF.Replace(@"ng\f2\'fd\f0\u7901?i", @"ng\u432?\u7901?i");//thay thế chữ {người}
            strRTF = strRTF.Replace(@"\u273?\'e3 \u273?\u432?\u7907?c", @"\u273?\'e3  \u273?\u432?\u7907?c");//thay thế chữ {đã được}   
            strRTF = strRTF.Replace(@"PH\f2\'dd\f0\u7898?C", @"PH\u431?\u7898?C");//thay thế chữ {PHƯỚC} 
            strRTF = strRTF.Replace(@"nh\f2\'fd d\'fd\f0\u7899?i", @"nh\u432? d\u432?\u7899?i");//thay thế chữ {như dưới} 
            strRTF = strRTF.Replace(@"\u273?\'e3", @"\u273?\'e3");//thay thế chữ {đã} 
                                                                  //strRTF = strRTF.Replace(@"\f1\'e3", @"\u259?");//Thay thế chữ {ă}
            strRTF = strRTF.Replace(@"\f2\'dd", @"\u431?\f2");//Thay thế chữ {ư}
            strRTF = strRTF.Replace(@"\f0\'fd", @"\u432?\f0  \f1");//Thay thế chữ {như}
            strRTF = strRTF.Replace(@"\'fd\f1\u7899?i", @"\u432?\u7899?i");//Thay thế chữ {dưới}
                                                                           //strRTF = strRTF.Replace(@"\'f5", @"\u417?");//Thay thế chữ {ơ}
            strRTF = strRTF.Replace(@"\f0\'dd", @"\u431?\f0");//Thay thế chữ {TÝ}

            return strRTF;
        }

        private void FillSubReport(DataDynamics.ActiveReports.SubReport subReport)
        {
            if (dsResult.Tables.Contains(subReport.ReportName))
            {
                rptFileReport repFileSubReport = new rptFileReport();
                object objFile_Data = SQLExec.ExecuteReturnValue("SELECT File_Data FROM L00DMFILE WHERE File_Name = '" + subReport.ReportName + ".rpx" + "'");

                if (objFile_Data == null || objFile_Data == DBNull.Value)
                {
                    Common.MsgCancel("File :{" + subReport.ReportName + "} " + Languages.GetLanguage("NOT_FOUND"));
                    return;
                }

                byte[] buff = (byte[])objFile_Data;

                Stream stream = new MemoryStream(buff);
                
                repFileSubReport.LoadLayout(stream);
                repFileSubReport.DataSource = dsResult.Tables[subReport.ReportName];
                subReport.Report = repFileSubReport;
            }
        }

        private void FillHeaderAndFooterInfo()
        {
            //Ten cong ty
            //if((DataDynamics.ActiveReports.Label)repFile.reportHeader.Controls["lbtTen_Dv"])
            object objTen_Dv = SQLExec.ExecuteReturnValue("SELECT Ten_DvCs FROM L00DMDVCS WHERE Ma_DvCs='" + Element.sysMa_DvCs + "'");
            string strTen_Dv = (objTen_Dv == null) ? "" : objTen_Dv.ToString();

            object objDia_Chi_Dv = SQLExec.ExecuteReturnValue("SELECT Dia_Chi_Dv FROM L00DMDVCS WHERE Ma_DvCs='" + Element.sysMa_DvCs + "'");
            string strDia_Chi_Dv = (objDia_Chi_Dv == null) ? "" : objDia_Chi_Dv.ToString();

            strTen_Dv = (Core.Is_Free()) ? strTen_Dv : Element.sysTen_Dvi;
            strDia_Chi_Dv = (Core.Is_Free()) ? strDia_Chi_Dv : Element.sysDia_Chi_Dv;

            if (drPhView != null && drPhView.Table.Columns.Contains("Logo_Goc") && drPhView["Logo_Goc"] != DBNull.Value && drPhView["Logo_Goc"].ToString() != string.Empty)
            {
                dicHeader["LOGO_GOC"] = drPhView["Logo_Goc"].ToString();
            }

            #region Tên Công ty
            try
            {
                DataDynamics.ActiveReports.Label lbtTen_Dv = (DataDynamics.ActiveReports.Label)repFile.reportHeader.Controls["lbtTen_Dv"];
                lbtTen_Dv.Text = Element.sysTen_Dvi;
                lbtTen_Dv.Visible = true;
                lbtTen_Dv.BringToFront();
            }
            catch
            {
                DataDynamics.ActiveReports.Label lbtTen_Dv_Cq = new DataDynamics.ActiveReports.Label();
                lbtTen_Dv_Cq.Location = new PointF(1.0F, 0.13F);

                lbtTen_Dv_Cq.Text = (string)Parameters.GetParaValue("TEN_DV_CQ");
                lbtTen_Dv_Cq.Visible = true;
                lbtTen_Dv_Cq.BringToFront();
                lbtTen_Dv_Cq.Width = 6.0F;
                lbtTen_Dv_Cq.Font = new Font("Arial", 10F, FontStyle.Bold);
                if (!dicHeader["REPORT_FILE"].Contains("UNC"))
                    repFile.reportHeader.Controls.Add(lbtTen_Dv_Cq);

                DataDynamics.ActiveReports.Label lbtTen_Dv = new DataDynamics.ActiveReports.Label();
                lbtTen_Dv.Location = new PointF(0.6F, 0.24F);
                lbtTen_Dv.Size = new SizeF(1.94F, 0.44F);
                lbtTen_Dv.Text = Element.sysTen_Dvi;
                //lbtTen_Dv.Alignment = TextAlignment.Center;
                lbtTen_Dv.Visible = true;
                lbtTen_Dv.BringToFront();
                lbtTen_Dv.Width = 6.0F;
                lbtTen_Dv.Font = new Font("Arial", 9F, FontStyle.Bold);
                repFile.reportHeader.Controls.Add(lbtTen_Dv);
                if (!dicHeader["REPORT_FILE"].Contains("UNC"))
                    repFile.reportHeader.Controls.Add(lbtTen_Dv);

            }
            #endregion

            #region Địa chỉ tên công ty
            try
            {
                DataDynamics.ActiveReports.Label lbtDia_Chi_Dv = (DataDynamics.ActiveReports.Label)repFile.reportHeader.Controls["lbtDia_Chi_Dv"];
                lbtDia_Chi_Dv.Text = Element.sysDia_Chi_Dv;
                lbtDia_Chi_Dv.Visible = true;
                lbtDia_Chi_Dv.BringToFront();
            }
            catch
            {
                DataDynamics.ActiveReports.Label lbtDia_Chi_Dv = new DataDynamics.ActiveReports.Label();
                lbtDia_Chi_Dv.Location = new PointF(0.6F, 0.48F);
                lbtDia_Chi_Dv.Text = Element.sysDia_Chi_Dv;
                lbtDia_Chi_Dv.Visible = true;
                lbtDia_Chi_Dv.BringToFront();
                lbtDia_Chi_Dv.Width = 6.0F;
                lbtDia_Chi_Dv.Height = 0.32F;
                lbtDia_Chi_Dv.Font = new Font("Arial", 9, FontStyle.Bold);
                repFile.reportHeader.Controls.Add(lbtDia_Chi_Dv);

            }
            #endregion

            #region Khai báo tên công ty cho Footter
            DataDynamics.ActiveReports.Label lbtTen_Dv_Cq_ft = new DataDynamics.ActiveReports.Label();
            lbtTen_Dv_Cq_ft.Location = new PointF(0.65F, 0.094F);
            lbtTen_Dv_Cq_ft.Text = (string)Parameters.GetParaValue("TEN_DV_CQ");
            lbtTen_Dv_Cq_ft.Visible = true;
            lbtTen_Dv_Cq_ft.BringToFront();
            lbtTen_Dv_Cq_ft.Width = 4.9F;
            lbtTen_Dv_Cq_ft.Font = new Font("Arial", 10F, FontStyle.Bold);


            DataDynamics.ActiveReports.Label lbtTen_Dv_ft = new DataDynamics.ActiveReports.Label();
            lbtTen_Dv_ft.Location = new PointF(0.65F, 0.304F);
            lbtTen_Dv_ft.Text = Element.sysTen_Dvi;
            lbtTen_Dv_ft.Visible = true;
            lbtTen_Dv_ft.BringToFront();
            lbtTen_Dv_ft.Width = 4.9F;
            lbtTen_Dv_ft.Font = new Font("Arial", 10F, FontStyle.Bold);


            DataDynamics.ActiveReports.Label lbtDia_Chi_Dv_ft = new DataDynamics.ActiveReports.Label();
            lbtDia_Chi_Dv_ft.Location = new PointF(0.65F, 0.504F);
            lbtDia_Chi_Dv_ft.Text = Element.sysDia_Chi_Dv;
            lbtDia_Chi_Dv_ft.Visible = true;
            lbtDia_Chi_Dv_ft.BringToFront();
            lbtDia_Chi_Dv_ft.Width = 4.9F;
            lbtDia_Chi_Dv_ft.Font = new Font("Arial", 10, FontStyle.Bold);

            //if (dicHeader["REPORT_FILE"].StartsWith("rptCT"))
            //    repFile.reportFooter.Controls.AddRange(new ARControl[]{lbtTen_Dv_Cq_ft,lbtTen_Dv_ft, lbtDia_Chi_Dv_ft});
            #endregion

            #region reportHeader
            foreach (ARControl arCtrl in repFile.reportHeader.Controls)
            {

                if (arCtrl.GetType().Name == "Label")
                {
                    if (arCtrl.Tag == null || (string)arCtrl.Tag == string.Empty)
                        continue;

                    string strDataField = ((string)arCtrl.Tag).ToUpper();
                    //if (dicHeader.ContainsKey(strDataField) && dicHeader[strDataField] != string.Empty)
                    if (strDataField.StartsWith("L."))
                        ((DataDynamics.ActiveReports.Label)arCtrl).Text = Languages.GetLanguage(strDataField.Substring(2), Report.LanguageType);
                    else if (dicHeader.ContainsKey(strDataField))
                        ((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader[strDataField];
                    //if (dicHeader.ContainsKey(strDataField))
                    //    ((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader[strDataField];
                    //else
                    //    ((DataDynamics.ActiveReports.Label)arCtrl).Text = Languages.GetLanguage(strDataField);
                }
                else if (arCtrl.GetType().Equals(typeof(DataDynamics.ActiveReports.RichTextBox)))
                {
                    if (arCtrl.Tag == null || (string)arCtrl.Tag == string.Empty)
                        continue;

                    string strDataField = ((string)arCtrl.Tag).ToUpper();

                    if (dicHeader.ContainsKey(strDataField))
                    {
                        ((DataDynamics.ActiveReports.RichTextBox)arCtrl).RTF = ReplaceRTF(dicHeader[strDataField]);
                    }
                }
                else if (arCtrl.GetType() == typeof(DataDynamics.ActiveReports.Picture) && arCtrl.Name.ToUpper() == "LOGO_GOC")
                {
                    if (dicHeader.ContainsKey("LOGO_GOC") && dicHeader["LOGO_GOC"] != string.Empty)
                    {
                        if (File.Exists(dicHeader["LOGO_GOC"]))
                            ((DataDynamics.ActiveReports.Picture)arCtrl).Image = Image.FromFile(dicHeader["LOGO_GOC"]);
                    }
                }

            }

            #endregion

            #region pageHeader
            foreach (ARControl arCtrl in repFile.pageHeader.Controls)
            {
                if (arCtrl.GetType().Name == "Label")
                {
                    if (arCtrl.Tag == null || (string)arCtrl.Tag == string.Empty)
                        continue;

                    string strDataField = ((string)arCtrl.Tag).ToUpper();
                    //if (dicHeader.ContainsKey(strDataField)) //&& dicHeader[strDataField] != string.Empty)
                    //    ((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader[strDataField];
                    //else
                    //    ((DataDynamics.ActiveReports.Label)arCtrl).Text = Languages.GetLanguage(strDataField);
                    if (strDataField.StartsWith("L."))
                        ((DataDynamics.ActiveReports.Label)arCtrl).Text = Languages.GetLanguage(strDataField.Substring(2), Report.LanguageType);
                    else if (dicHeader.ContainsKey(strDataField))
                        ((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader[strDataField];

                }
                else if (arCtrl.GetType().Equals(typeof(DataDynamics.ActiveReports.RichTextBox)))
                {
                    if (arCtrl.Tag == null || (string)arCtrl.Tag == string.Empty)
                        continue;

                    string strDataField = ((string)arCtrl.Tag).ToUpper();

                    if (dicHeader.ContainsKey(strDataField))
                    {
                        ((DataDynamics.ActiveReports.RichTextBox)arCtrl).RTF = ReplaceRTF(dicHeader[strDataField]);
                    }
                }
                else if (arCtrl.GetType() == typeof(DataDynamics.ActiveReports.Picture) && arCtrl.Name.ToUpper() == "LOGO_GOC")
                {
                    if (dicHeader.ContainsKey("LOGO_GOC") && dicHeader["LOGO_GOC"] != string.Empty)
                    {
                        if (File.Exists(dicHeader["LOGO_GOC"]))
                            ((DataDynamics.ActiveReports.Picture)arCtrl).Image = Image.FromFile(dicHeader["LOGO_GOC"]);
                    }
                }
            }

            #endregion

            #region reportFooter
            foreach (ARControl arCtrl in repFile.reportFooter.Controls)
            {
                if (arCtrl.GetType().Name == "Label")
                {
                    if (arCtrl.Tag == null || (string)arCtrl.Tag == string.Empty)
                        continue;

                    string strDataField = ((string)arCtrl.Tag).ToUpper();
                    if (strDataField.StartsWith("L."))
                        ((DataDynamics.ActiveReports.Label)arCtrl).Text = Languages.GetLanguage(strDataField.Substring(2), Report.LanguageType);
                    else if (dicHeader.ContainsKey(strDataField)) //&& dicHeader[strDataField] != string.Empty)
                    {
                        if (strDataField.Contains("SIGN1") && Report.LanguageType == enuLanguageType.English)
                            ((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader["SIGNE1"];
                        else if (strDataField.Contains("SIGN2") && Report.LanguageType == enuLanguageType.English)
                            ((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader["SIGNE2"];
                        else if (strDataField.Contains("SIGN3") && Report.LanguageType == enuLanguageType.English)
                            ((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader["SIGNE3"];
                        else
                            ((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader[strDataField];
                    }
                }
                else if (arCtrl.GetType().Equals(typeof(DataDynamics.ActiveReports.RichTextBox)))
                {
                    if (arCtrl.Tag == null || (string)arCtrl.Tag == string.Empty)
                        continue;

                    string strDataField = ((string)arCtrl.Tag).ToUpper();

                    if (dicHeader.ContainsKey(strDataField))
                        ((DataDynamics.ActiveReports.RichTextBox)arCtrl).RTF = ReplaceRTF(dicHeader[strDataField]);
                }
                else if (arCtrl.GetType().Equals(typeof(DataDynamics.ActiveReports.RichTextBox)))
                {
                    if (arCtrl.Tag == null || (string)arCtrl.Tag == string.Empty)
                        continue;

                    string strDataField = ((string)arCtrl.Tag).ToUpper();

                    if (dicHeader.ContainsKey(strDataField))
                        ((DataDynamics.ActiveReports.RichTextBox)arCtrl).RTF = ReplaceRTF(dicHeader[strDataField]);
                }
                else if (arCtrl.GetType().Equals(typeof(DataDynamics.ActiveReports.SubReport)))
                {
                    FillSubReport((DataDynamics.ActiveReports.SubReport)arCtrl);
                }
            }

            #endregion

            #region pageFooter
            foreach (ARControl arCtrl in repFile.pageFooter.Controls)
            {
                if (arCtrl.GetType().Name == "Label")
                {
                    if (arCtrl.Tag == null || (string)arCtrl.Tag == string.Empty)
                        continue;

                    string strDataField = ((string)arCtrl.Tag).ToUpper();

                    if (strDataField.StartsWith("L."))
                        ((DataDynamics.ActiveReports.Label)arCtrl).Text = Languages.GetLanguage(strDataField.Substring(2), Report.LanguageType);
                    else if (dicHeader.ContainsKey(strDataField))
                        ((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader[strDataField];
                }
                else if (arCtrl.GetType().Equals(typeof(DataDynamics.ActiveReports.RichTextBox)))
                {
                    if (arCtrl.Tag == null || (string)arCtrl.Tag == string.Empty)
                        continue;

                    string strDataField = ((string)arCtrl.Tag).ToUpper();

                    if (dicHeader.ContainsKey(strDataField))
                        ((DataDynamics.ActiveReports.RichTextBox)arCtrl).RTF = dicHeader[strDataField];
                }
                if (arCtrl.GetType().Equals(typeof(DataDynamics.ActiveReports.ReportInfo)))
                {
                    DataDynamics.ActiveReports.ReportInfo reportInfo = (DataDynamics.ActiveReports.ReportInfo)arCtrl;
                    if (Report.PrintType == PrintType.PrintReport && Report.LanguageType == enuLanguageType.English)
                        reportInfo.FormatString = reportInfo.FormatString.Replace("Trang", "Page");

                }
                if (arCtrl.GetType().Name == "picSigned" && drPhView != null && drPhView["Ma_Ct"].ToString() == "HT")
                {
                    if (drPhView["Ky_So"].Equals(false))
                        arCtrl.Visible = false;
                }
            }

            #endregion

            #region groupHeader1
            foreach (ARControl arCtrl in repFile.groupHeader1.Controls)
            {
                if (arCtrl.GetType().Name == "Label")
                {
                    if (arCtrl.Tag == null || (string)arCtrl.Tag == string.Empty)
                        continue;

                    string strDataField = ((string)arCtrl.Tag).ToUpper();
                    if (strDataField.StartsWith("L."))
                        ((DataDynamics.ActiveReports.Label)arCtrl).Text = Languages.GetLanguage(strDataField.Substring(2), Report.LanguageType);
                    else if (dicHeader.ContainsKey(strDataField)) //&& dicHeader[strDataField] != string.Empty)
                        ((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader[strDataField];
                }
                else if (arCtrl.GetType().Equals(typeof(DataDynamics.ActiveReports.RichTextBox)))
                {
                    if (arCtrl.Tag == null || (string)arCtrl.Tag == string.Empty)
                        continue;

                    string strDataField = ((string)arCtrl.Tag).ToUpper();

                    if (dicHeader.ContainsKey(strDataField))
                        ((DataDynamics.ActiveReports.RichTextBox)arCtrl).RTF = dicHeader[strDataField];
                }
                else if (arCtrl.GetType() == typeof(DataDynamics.ActiveReports.Picture) && arCtrl.Name.ToUpper() == "LOGO_GOC")
                {
                    if (dicHeader.ContainsKey("LOGO_GOC") && dicHeader["LOGO_GOC"] != string.Empty)
                    {
                        if (File.Exists(dicHeader["LOGO_GOC"]))
                            ((DataDynamics.ActiveReports.Picture)arCtrl).Image = Image.FromFile(dicHeader["LOGO_GOC"]);
                    }
                }
                else if (arCtrl.GetType() == typeof(DataDynamics.ActiveReports.Picture) && arCtrl.Name.ToUpper() == "BAN_SAO")
                {
                    if (drPhView == null)
                        return;

                    if (!(drPhView.Table.Columns.Contains("Ma_Ct") && (string)drPhView["Ma_Ct"] != string.Empty))
                        return;

                    if (!(drPhView.Table.Columns.Contains("Stt") && (string)drPhView["Stt"] != string.Empty))
                        return;

                    //Cập nhật số lần in hóa đơn vào L80PH
                    if ((string)Parameters.GetParaValue("IS_TUINHOADON") == "1" && (string)drPhView["Ma_Ct"] == "HD")
                    {
                        object objPrintTimeHd = SQLExec.ExecuteReturnValue("SELECT PrintTimeHd FROM L80PH WHERE Stt = '" + (string)drPhView["Stt"] + "'");

                        if ((byte)objPrintTimeHd > 0)
                            arCtrl.Visible = true;
                    }
                }
            }

            #endregion

            #region groupFooter1
            foreach (ARControl arCtrl in repFile.groupFooter1.Controls)
            {
                if (arCtrl.GetType().Name == "Label")
                {
                    if (arCtrl.Tag == null || (string)arCtrl.Tag == string.Empty)
                        continue;

                    string strDataField = ((string)arCtrl.Tag).ToUpper();
                    if (strDataField.StartsWith("L."))
                        ((DataDynamics.ActiveReports.Label)arCtrl).Text = Languages.GetLanguage(strDataField.Substring(2), Report.LanguageType);
                    else if (dicHeader.ContainsKey(strDataField)) //&& dicHeader[strDataField] != string.Empty)
                    {
                        if (strDataField.Contains("SIGN1") && Report.LanguageType == enuLanguageType.English)
                            ((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader["SIGNE1"];
                        else if (strDataField.Contains("SIGN2") && Report.LanguageType == enuLanguageType.English)
                            ((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader["SIGNE2"];
                        else if (strDataField.Contains("SIGN3") && Report.LanguageType == enuLanguageType.English)
                            ((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader["SIGNE3"];
                        else
                            ((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader[strDataField];
                    }
                }
                else if (arCtrl.GetType().Equals(typeof(DataDynamics.ActiveReports.RichTextBox)))
                {
                    if (arCtrl.Tag == null || (string)arCtrl.Tag == string.Empty)
                        continue;

                    string strDataField = ((string)arCtrl.Tag).ToUpper();

                    if (dicHeader.ContainsKey(strDataField))
                        ((DataDynamics.ActiveReports.RichTextBox)arCtrl).RTF = dicHeader[strDataField];
                }
                else if (arCtrl.GetType().Equals(typeof(DataDynamics.ActiveReports.SubReport)))
                {
                    FillSubReport((DataDynamics.ActiveReports.SubReport)arCtrl);
                }
                else if (arCtrl.Name == "picSigned")
                {
                    if (drPhView != null && drPhView["Ma_Ct"].ToString() == "HT" && drPhView["Is_KySo"].Equals(false))
                        arCtrl.Visible = false;
                }
            }

            #endregion

            #region groupHeader2
            foreach (ARControl arCtrl in repFile.groupHeader2.Controls)
            {
                if (arCtrl.GetType().Name == "Label")
                {
                    if (arCtrl.Tag == null || (string)arCtrl.Tag == string.Empty)
                        continue;

                    string strDataField = ((string)arCtrl.Tag).ToUpper();

                    if (strDataField.StartsWith("L."))
                        ((DataDynamics.ActiveReports.Label)arCtrl).Text = Languages.GetLanguage(strDataField.Substring(2), Report.LanguageType);
                    else if (dicHeader.ContainsKey(strDataField))
                        ((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader[strDataField];
                }
                else if (arCtrl.GetType().Equals(typeof(DataDynamics.ActiveReports.RichTextBox)))
                {
                    if (arCtrl.Tag == null || (string)arCtrl.Tag == string.Empty)
                        continue;

                    string strDataField = ((string)arCtrl.Tag).ToUpper();

                    if (dicHeader.ContainsKey(strDataField))
                        ((DataDynamics.ActiveReports.RichTextBox)arCtrl).RTF = dicHeader[strDataField];
                }
            }

            #endregion

            #region groupFooter2
            foreach (ARControl arCtrl in repFile.groupFooter2.Controls)
            {
                if (arCtrl.GetType().Name == "Label")
                {
                    if (arCtrl.Tag == null || (string)arCtrl.Tag == string.Empty)
                        continue;

                    string strDataField = ((string)arCtrl.Tag).ToUpper();

                    if (strDataField.StartsWith("L."))
                        ((DataDynamics.ActiveReports.Label)arCtrl).Text = Languages.GetLanguage(strDataField.Substring(2), Report.LanguageType);
                    else if (dicHeader.ContainsKey(strDataField))
                        ((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader[strDataField];
                }
                else if (arCtrl.GetType().Equals(typeof(DataDynamics.ActiveReports.RichTextBox)))
                {
                    if (arCtrl.Tag == null || (string)arCtrl.Tag == string.Empty)
                        continue;

                    string strDataField = ((string)arCtrl.Tag).ToUpper();

                    if (dicHeader.ContainsKey(strDataField))
                        ((DataDynamics.ActiveReports.RichTextBox)arCtrl).RTF = dicHeader[strDataField];
                }
            }

            #endregion

            #region detail            

            foreach (ARControl arCtrl in repFile.detail.Controls)
            {
                if (arCtrl.GetType().Name == "TextBox")
                {
                    if (arCtrl.DataField == null || (string)arCtrl.DataField == string.Empty)
                        continue;

                    string strDataField = ((string)arCtrl.DataField).ToUpper();
                    if (Report.LanguageType == enuLanguageType.English)
                    {
                        if (strDataField.ToUpper() == "CHI_TIEU" && dtDetail.Columns.Contains("CHI_TIEUE"))
                            arCtrl.DataField = "CHI_TIEUE";
                        if (strDataField.ToUpper() == "TEN_TK" && dtDetail.Columns.Contains("TEN_TKE"))
                            arCtrl.DataField = "TEN_TKE";
                    }
                    else if (Report.LanguageType == enuLanguageType.Other)
                    {
                        if (strDataField.ToUpper() == "CHI_TIEU" && dtDetail.Columns.Contains("CHI_TIEUO"))
                            arCtrl.DataField = "CHI_TIEUO";
                        if (strDataField.ToUpper() == "TEN_TK" && dtDetail.Columns.Contains("TEN_TKO"))
                            arCtrl.DataField = "TEN_TKO";
                    }

                    if (dtDetail.Columns.Contains(strDataField) && dtDetail.Columns[strDataField].DataType == typeof(decimal))
                    {
                        dicLuyKe[strDataField] = 0;
                        listKey.Add(strDataField);
                    }
                }
            }

            #endregion
            // Xu ly trong truong hop in nhieu lan
            #region
            if (drPrintColumnsList != null)
            {
                string[] strArrColumnPrintList = ((string)drPrintColumnsList["ColumnPrintList"]).Replace(" ", "").Split(',');
                string[] strArrColumnDetailList = ((string)drPrintColumnsList["ColumnDetailList"]).Replace(" ", "").Split(',');

                Dictionary<string, string> dicDataField = new Dictionary<string, string>();
                Dictionary<string, string> dicText = new Dictionary<string, string>();

                for (int i = 0; i <= strArrColumnDetailList.Length - 1; i++)
                {
                    string strHeaderName = strArrColumnPrintList[i].ToUpper();
                    dicDataField[strArrColumnDetailList[i].ToUpper()] = strHeaderName;

                    if (strHeaderName.StartsWith("NO_"))
                        strHeaderName = "Nợ " + strHeaderName.Substring(3);
                    else if (strHeaderName.StartsWith("CO_"))
                        strHeaderName = "Có " + strHeaderName.Substring(3);

                    dicText[strArrColumnDetailList[i].ToUpper()] = strHeaderName;

                }

                foreach (ARControl arCtrl in repFile.detail.Controls)
                {
                    if (arCtrl.GetType().Name == "TextBox")
                    {
                        if (arCtrl.DataField == null || (string)arCtrl.DataField == string.Empty)
                            continue;

                        if (dicDataField.ContainsKey(arCtrl.Name.Substring(3).ToUpper()))
                            arCtrl.DataField = dicDataField[arCtrl.Name.Substring(3).ToUpper()];
                        else
                            ((DataDynamics.ActiveReports.TextBox)arCtrl).Text = string.Empty;
                    }
                }

                foreach (ARControl arCtrl in repFile.pageHeader.Controls)
                {
                    if (arCtrl.GetType().Name == "Label")
                    {
                        if (dicText.ContainsKey(arCtrl.Name.Substring(3).ToUpper()))
                            ((DataDynamics.ActiveReports.Label)arCtrl).Text = dicText[arCtrl.Name.Substring(3).ToUpper()];
                        //((DataDynamics.ActiveReports.Label)arCtrl).Text = LinkQ.Systems.Librarys.Languages.GetLanguage(dicText[arCtrl.Name.Substring(3).ToUpper()]);
                        else if (arCtrl.Name.ToUpper().StartsWith("LBL"))
                            ((DataDynamics.ActiveReports.Label)arCtrl).Text = string.Empty;
                    }
                }
            }

            #endregion

            #region Đổi trường ngoại tệ
            if (drReport != null && (string)drReport["Vnd_Nt"] == "1")
            {
                //Label
                foreach (ARControl arCtrl in repFile.pageHeader.Controls)
                {
                    if (arCtrl.GetType().Name == "Label")
                    {
                        if (arCtrl.Tag == null || (string)arCtrl.Tag == string.Empty)
                            continue;

                        string strDataField = ((string)arCtrl.Tag).ToUpper();
                        if (strDataField.Contains("TIEN") || strDataField.Contains("PS_") || strDataField.Contains("DU_") || strDataField.StartsWith("GIA"))
                            strDataField = strDataField + "_NT";

                        //if (dicHeader.ContainsKey(strDataField) && dicHeader[strDataField] != string.Empty)
                        if (dicHeader.ContainsKey(strDataField))
                            ((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader[strDataField];
                        else
                        {
                            if (strDataField.StartsWith("L."))
                                ((DataDynamics.ActiveReports.Label)arCtrl).Text = Languages.GetLanguage(strDataField.Substring(2), Report.LanguageType);
                            else if (dicHeader.ContainsKey(strDataField))
                                ((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader[strDataField];
                        }
                    }
                }

                //TextBox
                foreach (ARControl arCtrl in repFile.detail.Controls)
                {
                    if (arCtrl.GetType().Name == "TextBox")
                    {
                        if (arCtrl.Tag != null && arCtrl.Tag.ToString() != string.Empty)
                            arCtrl.DataField = arCtrl.Tag.ToString();

                        string strkey = (string)drReport["Report_ID"] + "." + arCtrl.DataField.ToUpper();
                        if (columnInfos != null && columnInfos.ContainsKey(strkey) && columnInfos[strkey].Type == enuColumnType.Numeric)
                        {
                            ColumnInfo columnInfo = columnInfos[strkey];
                            if (columnInfo.Scale == 0)
                                ((DataDynamics.ActiveReports.TextBox)arCtrl).OutputFormat = "#,##0";
                            else
                                ((DataDynamics.ActiveReports.TextBox)arCtrl).OutputFormat = "#,##0." + "0".PadLeft(columnInfo.Scale, '0');
                        }
                    }
                }
            }
            #endregion
        }

        #endregion

        #region Events

        void frmReportPrint_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    return;

                case Keys.F3:
                    return;

                default:
                    break;
            }

            if (e.Control && e.KeyCode == Keys.E)
                this.btExport.PerformClick();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            this.viewReport.Focus();
        }

        void btExport_Click(object sender, EventArgs e)
        {
            string strTitle = this.Text;
            frmExport frm = new frmExport();

            frm.chkKetXuatDinhDang.Visible = false;
            frm.chkOpenFile.Visible = false;

            frm.Load(strTitle);

            if (!frm.isAccept)
                return;

            string strPath = frm.strPath;
            string strExportType = frm.cboExportType.Text;

            switch (strExportType.Substring(0, 1))
            {
                case "1": //Excel					
                    strExportType = "xls";
                    break;
                case "2": //enuExportType.Word:					
                    strExportType = "doc";
                    break;
                case "3": //enuExportType.PDF:					
                    strExportType = "pdf";
                    break;
                case "4": //enuExportType.Htmls:
                    strExportType = "Html";
                    break;
            }

            Report.ExportReport(strExportType, frm.strPath, repFile, dtDetail);
            if (File.Exists(frm.strPath))
                Process.Start(frm.strPath);
        }
        void btSendMail_Click(object sender, EventArgs e)
        {
            Report.SendMail(dtDetail, repFile, dicHeader["TITLE"]);

        }

        void btRefresh_Click(object sender, EventArgs e)
        {
            repFile.detail.Height = (float)Convert.ToDouble(numDetailHeight.Value);
            repFile.PageSettings.Margins.Bottom = (float)Convert.ToDouble(numBottonMargin.Value);
            repFile.pageFooter.Height = (float)Convert.ToDouble(numPageFooterHeight.Value);

            repFile.Restart();
            repFile.Run();
            viewReport.Document = repFile.Document;
        }

        #endregion

        #region RepFile_FetchData
        private void RepFile_FetchData(object sender, ActiveReport3.FetchEventArgs eArgs)
        {
            try
            {
                foreach (string strKey in listKey)
                {
                    if (dbSttRow <= dtDetail.Rows.Count - 1)
                    {
                        if (this.dtDetail.Columns.Contains("Bold") && Convert.ToBoolean(dtDetail.Rows[dbSttRow]["Bold"]))
                        {
                            continue;
                        }

                        decimal dcValue = dicLuyKe[strKey];
                        dcValue += (decimal)dtDetail.Rows[dbSttRow][strKey];
                        dicLuyKe[strKey] = dcValue;
                        //((DataDynamics.ActiveReports.TextBox)repFile.Sections["pageFooter"].Controls["lbf" + strKey]).Text = dicLuyKe[strKey].ToString("N0");

                        foreach (ARControl arCtrlpf in repFile.pageFooter.Controls)
                        {
                            if (arCtrlpf.Name.ToUpper().Contains(strKey.ToUpper()) && arCtrlpf.GetType() == typeof(DataDynamics.ActiveReports.TextBox))
                                ((DataDynamics.ActiveReports.TextBox)arCtrlpf).Text = dicLuyKe[strKey].ToString("N0");
                        }
                        foreach (ARControl arCtrlgf in repFile.groupFooter1.Controls)
                        {
                            if (arCtrlgf.Name.ToUpper().Contains(strKey.ToUpper()) && arCtrlgf.GetType() == typeof(DataDynamics.ActiveReports.TextBox))
                                ((DataDynamics.ActiveReports.TextBox)arCtrlgf).Text = dicLuyKe[strKey].ToString("N0");
                        }
                        foreach (ARControl arCtrlgf in repFile.groupFooter2.Controls)
                        {
                            if (arCtrlgf.Name.ToUpper().Contains(strKey.ToUpper()) && arCtrlgf.GetType() == typeof(DataDynamics.ActiveReports.TextBox))
                                ((DataDynamics.ActiveReports.TextBox)arCtrlgf).Text = dicLuyKe[strKey].ToString("N0");
                        }
                        foreach (ARControl arCtrlpf in repFile.reportFooter.Controls)
                        {
                            if (arCtrlpf.Name.ToUpper().Contains(strKey.ToUpper()) && arCtrlpf.GetType() == typeof(DataDynamics.ActiveReports.TextBox))
                                ((DataDynamics.ActiveReports.TextBox)arCtrlpf).Text = dicLuyKe[strKey].ToString("N0");
                        }
                    }

                    if (dbSttRow == dtDetail.Rows.Count - 1 || dbSttRow == dtDetail.Rows.Count)
                    {
                        foreach (ARControl arCtrlpf in repFile.pageFooter.Controls)
                        {
                            if (arCtrlpf.Name.ToUpper().Contains(strKey.ToUpper()) && arCtrlpf.GetType() == typeof(DataDynamics.ActiveReports.TextBox))
                                ((DataDynamics.ActiveReports.TextBox)arCtrlpf).Text = string.Empty;

                            if (arCtrlpf.Name.ToUpper().Contains("lbLk_Trang_Sau".ToUpper()) && arCtrlpf.GetType() == typeof(DataDynamics.ActiveReports.Label))
                                ((DataDynamics.ActiveReports.Label)arCtrlpf).Text = string.Empty;
                        }
                    }
                }
                if (dbSttRow <= dtDetail.Rows.Count - 1)
                    foreach (ARControl arCtrlpf in repFile.detail.Controls)
                    {
                        if (arCtrlpf.GetType().Equals(typeof(DataDynamics.ActiveReports.Picture)))
                        {
                            if (dtDetail.Columns.Contains(arCtrlpf.DataField) && dtDetail.Rows[dbSttRow][arCtrlpf.DataField] != DBNull.Value && ((byte[])dtDetail.Rows[dbSttRow][arCtrlpf.DataField]).Length == 0)
                                arCtrlpf.Visible = false;
                            else
                                arCtrlpf.Visible = true;
                        }
                    }

                dbSttRow++;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region repFile_PageStart
        void repFile_PageStart(object sender, EventArgs e)
        {
            try
            {
                if (repFile.PageNumber == 1)
                {
                    foreach (string strKey in listKey)
                    {
                        foreach (ARControl arCtrl in repFile.pageHeader.Controls)
                        {
                            if (arCtrl.Name.ToUpper().Contains(strKey.ToUpper()) && arCtrl.GetType() == typeof(DataDynamics.ActiveReports.TextBox))
                                ((DataDynamics.ActiveReports.TextBox)arCtrl).Text = string.Empty;
                        }
                        foreach (ARControl arCtrl in repFile.groupHeader1.Controls)
                        {
                            if (arCtrl.Name.ToUpper().Contains(strKey.ToUpper()) && arCtrl.GetType() == typeof(DataDynamics.ActiveReports.TextBox))
                                ((DataDynamics.ActiveReports.TextBox)arCtrl).Text = string.Empty;
                        }
                        foreach (ARControl arCtrl in repFile.groupHeader2.Controls)
                        {
                            if (arCtrl.Name.ToUpper().Contains(strKey.ToUpper()) && arCtrl.GetType() == typeof(DataDynamics.ActiveReports.TextBox))
                                ((DataDynamics.ActiveReports.TextBox)arCtrl).Text = string.Empty;
                        }
                    }
                }
                else if (repFile.PageNumber > 1)
                    foreach (string strKey in listKey)
                    {
                        foreach (ARControl arCtrl in repFile.pageHeader.Controls)
                        {
                            if (arCtrl.Name.ToUpper().Contains(strKey.ToUpper()) && arCtrl.GetType() == typeof(DataDynamics.ActiveReports.TextBox))
                                ((DataDynamics.ActiveReports.TextBox)arCtrl).Text = dicLuyKe[strKey].ToString("N0");
                        }
                        foreach (ARControl arCtrl in repFile.groupHeader1.Controls)
                        {
                            if (arCtrl.Name.ToUpper().Contains(strKey.ToUpper()) && arCtrl.GetType() == typeof(DataDynamics.ActiveReports.TextBox))
                                ((DataDynamics.ActiveReports.TextBox)arCtrl).Text = dicLuyKe[strKey].ToString("N0");
                        }
                        foreach (ARControl arCtrl in repFile.groupHeader2.Controls)
                        {
                            if (arCtrl.Name.ToUpper().Contains(strKey.ToUpper()) && arCtrl.GetType() == typeof(DataDynamics.ActiveReports.TextBox))
                                ((DataDynamics.ActiveReports.TextBox)arCtrl).Text = dicLuyKe[strKey].ToString("N0");
                        }
                    }
            }
            catch (Exception ex)
            {
                Common.MsgOk(ex.Message);
            }
        }
        #endregion

        private void GroupHeader1_Format(object sender, EventArgs e)
        {
            if (repFile.PageNumber == 1)
            {
                try
                {
                    if (repFile.groupHeader1.Controls["rifHD_NhieuTrang"] != null)
                    {
                        ReportInfo rifHD_NhieuTrang = (ReportInfo)repFile.groupHeader1.Controls["rifHD_NhieuTrang"];
                        rifHD_NhieuTrang.Visible = false;
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                try
                {
                    if (repFile.groupHeader1.Controls["rifHD_NhieuTrang"] != null)
                    {
                        ReportInfo rifHD_NhieuTrang = (ReportInfo)repFile.groupHeader1.Controls["rifHD_NhieuTrang"];
                        rifHD_NhieuTrang.Visible = true;
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
        private void RepFile_ReportEnd(object sender, EventArgs e)
        {
            foreach (string strKey in listKey)
            {
                foreach (ARControl arCtrlpf in repFile.pageFooter.Controls)
                {
                    if (arCtrlpf.Name.ToUpper().Contains(strKey.ToUpper()) && arCtrlpf.GetType() == typeof(DataDynamics.ActiveReports.TextBox))
                        ((DataDynamics.ActiveReports.TextBox)arCtrlpf).Text = string.Empty;

                    if (arCtrlpf.Name.ToUpper().Contains("lblCong_Trang".ToUpper()) && arCtrlpf.GetType() == typeof(DataDynamics.ActiveReports.Label))
                        ((DataDynamics.ActiveReports.Label)arCtrlpf).Text = string.Empty;
                }
            }
        }
    }
}