using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Globalization;
using Microsoft.Win32;
using System.IO;
using System.Reflection;

using LinkQ.Systems;
using LinkQ.Systems.Data;
using LinkQ.Systems.Librarys;
using LinkQ.Systems.Elements;
using LinkQ.Systems.Commons;
using LinkQ.Systems.Customizes;
//using Microsoft.Office.Core;

using DataDynamics.ActiveReports;
using DataDynamics;
using DataDynamics.ActiveReports.Export;

using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;


namespace LinkQ.Reports
{
    public class Report
    {
        public static DataRow drPrintColumnsList;
        public static DataRow drReport;
        public static Dictionary<string, ColumnInfo> columnInfos;
        public static Dictionary<string, string> dicHeader = new Dictionary<string, string>();
        private rptFileReport repFile = new rptFileReport();

        public static void RunReport(frmReport frmReport)
        {
            if (frmReport.bdsReport.Current == null || frmReport.bdsReport.Position < 0)
                return;

            drReport = ((DataRowView)frmReport.bdsReport.Current).Row;
            DataRow drFilter;

            string strReport_ID = ((string)drReport["Report_ID"]).Trim();

            //if (!Common.CheckPermission(strReport_ID, "REPORT", enuPermission_Type.Allow_Access))
            //{
            //    Common.MsgCancel(Languages.GetLanguage("No_Permission"));
            //    return;
            //}


            //Tao tham so bao cao
            drFilter = GetdrFilter(frmReport, drReport);

            //Tao form Filter
            frmReportFilter frmFilter = new frmReportFilter();
            frmFilter.Load(drReport, drFilter);

            if (!frmFilter.isAccept)
                return;

            //Tạo các tham số
            if (!drFilter.Table.Columns.Contains("Title"))
                drFilter.Table.Columns.Add(new DataColumn("Title", typeof(string)));

            if (!drFilter.Table.Columns.Contains("SubTitle1"))
                drFilter.Table.Columns.Add(new DataColumn("SubTitle1", typeof(string)));

            if (!drFilter.Table.Columns.Contains("SubTitle2"))
                drFilter.Table.Columns.Add(new DataColumn("SubTitle2", typeof(string)));

            drFilter["Title"] = GetTitle(drFilter);
            drFilter["SubTitle1"] = GetSubTitle1(drReport, drFilter);

            drFilter["SubTitle2"] = GetSubTitle2(drReport, drFilter);

            //Haids: Tự tạo file temp
            string strFolder = @"C:\Temp";
            if (!Directory.Exists(strFolder))
                Directory.CreateDirectory(strFolder);

            string strFileName = string.Empty;

            //In ra word
            if ((string)drReport["Report_ID"] == "QTTC04A" || (string)drReport["Report_ID"] == "QTTC04C")
            {
                //Huands - 14/11/2016: sữa lại mẫu thuyết mình xuất ra Excel
                if (Common.Inlist(Parameters.GetParaValue("HTTK").ToString(), "200,133"))
                {
                    strFileName = "B09_DN_TMBCTC_" + Parameters.GetParaValue("HTTK").ToString() + ".xls";

                    string strFileName2 = @"C:\Temp\" + strFileName;

                    File.Copy(Application.StartupPath + @"\Template\" + strFileName, strFileName2, true);

                    WriteToExcelTMBCTC(drFilter, strFileName2);
                }
                else
                {
                    strFileName = "QD15-2006-QTTC04.doc";
                    object objFile_Data = SQLExec.ExecuteReturnValue("SELECT File_Data FROM L00DMFILE WHERE File_Name = '" + strFileName + "'");
                    byte[] buff = (byte[])objFile_Data;

                    strFileName = @"C:\Temp\" + strFileName;
                    System.IO.File.WriteAllBytes(strFileName, buff);
                }
            }
            else if ((string)drReport["Report_ID"] == "QTTC04B")
            {
                if (Common.Inlist(Parameters.GetParaValue("HTTK").ToString(), "200,133"))
                {
                    strFileName = "B09_DN_TMBCTC_" + Parameters.GetParaValue("HTTK").ToString() + ".xls";

                    string strFileName2 = @"C:\Temp\" + strFileName;

                    File.Copy(Application.StartupPath + @"\Template\" + strFileName, strFileName2, true);

                    WriteToExcelTMBCTC(drFilter, strFileName2);
                }
                else
                {
                    strFileName = "QD48-2006-QTTC04.doc";
                    string strFileName2 = string.Empty;

                    object objFile_Data = SQLExec.ExecuteReturnValue("SELECT File_Data FROM L00DMFILE WHERE File_Name = '" + strFileName + "'");
                    if (objFile_Data != DBNull.Value && objFile_Data != null)
                    {
                        byte[] buff = (byte[])objFile_Data;

                        strFileName2 = @"C:\Temp\" + strFileName;
                        System.IO.File.WriteAllBytes(strFileName2, buff);
                    }
                    else
                    {
                        strFileName2 = @"C:\Temp\" + strFileName;
                        Common.MsgOk(strFileName2);
                        File.Copy(Application.StartupPath + @"\Template\" + strFileName, strFileName2, true);

                    }
                    string strSQLProc = (string)drReport["SQLProc"];
                    DataTable dtResult = SQLExec.ExecuteReturnDt(strSQLProc, drFilter, CommandType.StoredProcedure);
                    WriteToWordQTTC04(dtResult, drFilter, drReport, strFileName2);
                }
            }
            else//In ra Datagrid, ActiveReport
            {
                frmReportResult frmResult = new frmReportResult();
                frmResult.MdiParent = frmReport.MdiParent;

                frmResult.Load(drReport, drFilter);
            }
        }

        public static void RunReport(frmReportResult frmReportResult)
        {
            if (frmReportResult.bdsResult.Current == null || frmReportResult.bdsResult.Position < 0)
                return;

            DataRow drReport = ((DataRowView)frmReportResult.bdsResult.Current).Row;
            DataRow drFilter;

            string strReport_ID = ((string)drReport["Report_ID"]).Trim();

            //if (!Common.CheckPermission(strReport_ID, "REPORT", enuPermission_Type.Allow_Access))
            //{
            //    Common.MsgCancel(Languages.GetLanguage("No_Permission"));
            //    return;
            //}


            //Tao tham so bao cao
            frmReport frmReport = new frmReport();
            drFilter = GetdrFilter(frmReport, drReport);

            //Tao form Filter
            frmReportFilter frmFilter = new frmReportFilter();
            frmFilter.Load(drReport, drFilter);

            if (!frmFilter.isAccept)
                return;

            //Tạo các tham số
            if (!drFilter.Table.Columns.Contains("Title"))
                drFilter.Table.Columns.Add(new DataColumn("Title", typeof(string)));

            if (!drFilter.Table.Columns.Contains("SubTitle1"))
                drFilter.Table.Columns.Add(new DataColumn("SubTitle1", typeof(string)));

            if (!drFilter.Table.Columns.Contains("SubTitle2"))
                drFilter.Table.Columns.Add(new DataColumn("SubTitle2", typeof(string)));

            drFilter["Title"] = GetTitle(drFilter);
            drFilter["SubTitle1"] = GetSubTitle1(drReport, drFilter);

            drFilter["SubTitle2"] = GetSubTitle2(drReport, drFilter);

            string strFileName = string.Empty;
            //In ra word
            if ((string)drReport["Report_ID"] == "QTTC04A")
            {
                strFileName = "QD15-2006-QTTC04.doc";
                object objFile_Data = SQLExec.ExecuteReturnValue("SELECT File_Data FROM L00DMFILE WHERE File_Name = '" + strFileName + "'");
                byte[] buff = (byte[])objFile_Data;

                strFileName = @"C:\Temp\" + strFileName;
                System.IO.File.WriteAllBytes(strFileName, buff);

                string strSQLProc = (string)drReport["SQLProc"];
                DataTable dtResult = SQLExec.ExecuteReturnDt(strSQLProc, drFilter, CommandType.StoredProcedure);
                WriteToWordQTTC04(dtResult, drFilter, drReport, strFileName);
            }
            else if ((string)drReport["Report_ID"] == "QTTC04B")
            {
                strFileName = "QD48-2006-QTTC04.doc";
                object objFile_Data = SQLExec.ExecuteReturnValue("SELECT File_Data FROM L00DMFILE WHERE File_Name = '" + strFileName + "'");
                byte[] buff = (byte[])objFile_Data;

                strFileName = @"C:\Temp\" + strFileName;
                System.IO.File.WriteAllBytes(strFileName, buff);

                string strSQLProc = (string)drReport["SQLProc"];
                DataTable dtResult = SQLExec.ExecuteReturnDt(strSQLProc, drFilter, CommandType.StoredProcedure);
                WriteToWordQTTC04(dtResult, drFilter, drReport, strFileName);
            }

            //if ((string)drReport["Report_ID"] == "QTTC04A")
            //{
            //    string strSQLProc = (string)drReport["SQLProc"];
            //    DataTable dtResult = SQLExec.ExecuteReturnDt(strSQLProc, drFilter, CommandType.StoredProcedure);
            //    WriteToWordQTTC04(dtResult, drFilter, drReport, Application.StartupPath + @"\Template\QD15-2006-QTTC04.doc");
            //}
            //else if ((string)drReport["Report_ID"] == "QTTC04B")
            //{
            //    string strSQLProc = (string)drReport["SQLProc"];
            //    DataTable dtResult = SQLExec.ExecuteReturnDt(strSQLProc, drFilter, CommandType.StoredProcedure);
            //    WriteToWordQTTC04(dtResult, drFilter, drReport, Application.StartupPath + @"\Template\QD48-2006-QTTC04.doc");
            //}
            else//In ra Datagrid, ActiveReport
            {
                frmReportResult frmResult = new frmReportResult();
                frmResult.MdiParent = frmResult.MdiParent;
                frmResult.Load(drReport, drFilter);
            }
        }

        private static DataRow GetdrFilter(frmReport frmReport, DataRow drReport)
        {//Tra ve DataRow chua cac tham so cua Report

            string strReport_ID = (string)drReport["Report_ID"];
            string strReport_ID_Filter = (string)drReport["Report_ID_Filter"]; //Kế thừa ReportFilter của 1 report khác

            DataTable dtFilter = SQLExec.ExecuteReturnDt("sp_GetFormLayout '" + strReport_ID + "', '" + strReport_ID_Filter + "', '2'");

            DataTable dtTemp = new DataTable();
            DataColumn dcFilter;
            DataRow drFilter;

            foreach (DataRow dr in dtFilter.Rows)
            {
                string strColumn_ID = (string)dr["Column_ID"];

                switch ((string)dr["Column_Type"])
                {
                    case "chkControl":
                        dcFilter = new DataColumn(strColumn_ID, typeof(bool));
                        break;
                    case "numControl":
                        dcFilter = new DataColumn(strColumn_ID, typeof(double));
                        break;
                    case "txtDateTime":
                    case "dtpDateTimePicker":
                        dcFilter = new DataColumn(strColumn_ID, typeof(DateTime));
                        break;
                    case "uctDateSelect":
                        dcFilter = new DataColumn("DateSelect", typeof(string));
                        dtTemp.Columns.Add(dcFilter);
                        dcFilter = new DataColumn("Ngay_Ct1", typeof(DateTime));
                        dtTemp.Columns.Add(dcFilter);
                        dcFilter = new DataColumn("Ngay_Ct2", typeof(DateTime));
                        break;
                    default:
                        dcFilter = new DataColumn(strColumn_ID, typeof(string));
                        break;
                }

                dtTemp.Columns.Add(dcFilter);
            }

            //Set Dafault value			
            dcFilter = new DataColumn("Ma_DvCs", typeof(string));
            dtTemp.Columns.Add(dcFilter);

            dcFilter = new DataColumn("Is_Vnd", typeof(bool));
            dtTemp.Columns.Add(dcFilter);

            dcFilter = new DataColumn("Language_Type", typeof(string));
            dtTemp.Columns.Add(dcFilter);

            dcFilter = new DataColumn("Table_Formula", typeof(string));
            dtTemp.Columns.Add(dcFilter);

            dcFilter = new DataColumn("Login_User", typeof(string));
            dtTemp.Columns.Add(dcFilter);

            drFilter = dtTemp.NewRow();


            DataRow[] arrDrNotVisible = dtFilter.Select("Visible = 0");
            foreach (DataRow dr in arrDrNotVisible)
            {
                string strColumnID = (string)dr["Column_ID"];
                if ((string)dr["Column_Type"] == "chkControl" && (string)dr["Default_Value"] != string.Empty && drFilter.Table.Columns.Contains(strColumnID))
                {
                    drFilter[strColumnID] = ((string)dr["Default_Value"]).StartsWith("1");
                }
                else if ((string)dr["Default_Value"] != string.Empty && drFilter.Table.Columns.Contains(strColumnID))
                {
                    drFilter[strColumnID] = (string)dr["Default_Value"];
                }
            }

            if (Report.PrintType == PrintType.PrintVoucher)
            {
                drFilter["Title"] = Element.sysLanguage == enuLanguageType.Vietnamese ? drReport["Title"] : Element.sysLanguage == enuLanguageType.English ? drReport["TitleE"] : drReport["TitleO"];
                drFilter["Language_Type"] = (char)Element.sysLanguage;
            }
            else
            {
                drFilter["Title"] = Report.LanguageType == enuLanguageType.Vietnamese ? drReport["Title"] : Report.LanguageType == enuLanguageType.English ? drReport["TitleE"] : drReport["TitleO"];
                drFilter["Language_Type"] = (char)Report.LanguageType;
            }

            drFilter["Ma_DvCs"] = Element.sysMa_DvCs;
            drFilter["Is_Vnd"] = frmReport.strVnd_Nt == "0" ? true : false;
            drFilter["Table_Formula"] = drReport["Table_Formula"];
            drFilter["Login_User"] = Element.sysUser_Id;

            if (dtTemp.Columns.Contains("Ngay_Ct0"))
                drFilter["Ngay_Ct0"] = Element.sysNgay_Ct1;

            if (dtTemp.Columns.Contains("Ngay_Ct"))
                //drFilter["Ngay_Ct"] = Element.sysNgay_Ct1;
                drFilter["Ngay_Ct"] = DateTime.Today;


            DataRow[] drFilterDateSelect = dtFilter.Select("Column_Type = 'uctDateSelect'");

            if (!(dtTemp.Columns.Contains("DateSelect") && drFilterDateSelect.Length > 0 && drFilterDateSelect[0]["Default_Value"].ToString() != String.Empty))
            {
                if (dtTemp.Columns.Contains("Ngay_Ct1"))
                    drFilter["Ngay_Ct1"] = Element.sysNgay_Ct1;

                if (dtTemp.Columns.Contains("Ngay_Ct2"))
                    drFilter["Ngay_Ct2"] = Element.sysNgay_Ct2;
            }

            if (dtTemp.Columns.Contains("DateSelect"))
                drFilter["DateSelect"] = Element.sysDateSelect;

            return drFilter;
        }

        public static void ViewDetail(DataRow drReport, DataRow drFilter, DataRow drCurrent, Form frmParent)
        {
            DataRow drFilterDetail = drFilter.Table.NewRow();

            //Them vao drFilterDetail nhung truong ma drCurrent co nhung drFilter khong co
            SqlCommand sqlCom = SQLExec.GetSQLCommand();
            SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCom);

            string strSqlProc = (string)drReport["SqlProc"];
            sqlCom.CommandText = strSqlProc;
            sqlCom.CommandType = CommandType.StoredProcedure;

            string strKey = "Object_id = Object_id('" + strSqlProc + "')";
            DataTable dtSqlProcPara = DataTool.SQLGetDataTable("Sys.Parameters", "Name", strKey, null);

            //Add Parameter Into sqlProc
            foreach (DataRow dr in dtSqlProcPara.Rows)
            {
                string strColumnName = ((string)dr["Name"]).Replace("@", "");

                if (!drFilterDetail.Table.Columns.Contains(strColumnName))
                {
                    if (drCurrent.Table.Columns.Contains(strColumnName))
                        drFilterDetail.Table.Columns.Add(strColumnName, drCurrent.Table.Columns[strColumnName].DataType);
                    else
                        drFilterDetail.Table.Columns.Add(strColumnName, typeof(string));
                }
            }

            Common.CopyDataRow(drFilter, drFilterDetail);

            for (int i = 0; i <= drCurrent.Table.Columns.Count - 1; i++)
            {
                string strColumn = drCurrent.Table.Columns[i].ColumnName;

                if (drFilterDetail.Table.Columns.Contains(strColumn))
                {
                    //if ((drFilterDetail.Table.Columns[strColumn].DataType.Name == "DateTime" && ((DateTime)drFilterDetail[strColumn]).ToString("dd/MM/yyyy") == "01/01/1900") ||
                    //    drCurrent[strColumn].ToString() != string.Empty)
                    drFilterDetail[strColumn] = drCurrent[strColumn];
                }
            }

            //Common.CopyDataRow(drCurrent, drFilterDetail);

            // Mot so trường hop dac biệt
            if (drCurrent.Table.Columns.Contains("Bold") && (bool)drCurrent["Bold"] == true)
            {
                if (drFilterDetail.Table.Columns.Contains("Ma_Dt") && drFilterDetail.Table.Columns.Contains("Ma_Nh_Dt"))
                {
                    drFilterDetail["Ma_Nh_Dt"] = drFilterDetail["Ma_Dt"];
                    drFilterDetail["Ma_Dt"] = "";
                }
                if (drFilterDetail.Table.Columns.Contains("Ma_Vt") && drFilterDetail.Table.Columns.Contains("Ma_Nh_Vt"))
                {
                    drFilterDetail["Ma_Nh_Vt"] = drFilterDetail["Ma_Vt"];
                    drFilterDetail["Ma_Vt"] = "";
                }
            }

            frmReportResult frm = new frmReportResult();
            frm.MdiParent = frmParent;
            frm.Load(drReport, drFilterDetail);
        }

        public static void WriteToWordQTTC04(DataTable dtResult, DataRow drFilter, DataRow drReport, string strFileTemplate)
        {
            string strSaveFile = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", "Local Settings", @"C:\") + @"\Temp\" + (string)drReport["Report_ID"] + ".doc";
            System.IO.File.Copy(strFileTemplate, strSaveFile, true);

            object missing = System.Reflection.Missing.Value;
            object newTemplate = false;
            object docType = 0;
            object confirm = false;
            object myTrue = false; // mở file word với readonly = false

            Word.Application wrdApp = new Word.Application();
            wrdApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;
            wrdApp.UserName = Environment.UserName;

            object fileName = strSaveFile;
            Word.Document docOpen = wrdApp.Documents.Open(ref fileName, ref confirm, ref myTrue, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

            wrdApp.Selection.Find.ClearFormatting();
            wrdApp.Selection.Find.Replacement.ClearFormatting();

            CultureInfo cti = new CultureInfo("en-GB");

            cti.NumberFormat.NumberGroupSeparator = ",";
            cti.NumberFormat.NumberGroupSizes = new int[] { 3, 3, 3, 3, 3 };
            cti.NumberFormat.NumberDecimalSeparator = ".";

            cti.NumberFormat.CurrencyGroupSeparator = ",";
            cti.NumberFormat.CurrencyGroupSizes = new int[] { 3, 3, 3, 3, 3 };
            cti.NumberFormat.CurrencyDecimalSeparator = ".";

            object replaceAll = Word.WdReplace.wdReplaceAll;

            //Replace Header
            wrdApp.Selection.Find.Text = "[TEN_DV]";
            wrdApp.Selection.Find.Replacement.Text = Element.sysTen_Dvi.ToUpper();
            wrdApp.Selection.Find.Execute(ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceAll, ref missing, ref missing, ref missing, ref missing);

            wrdApp.Selection.Find.Text = "[DIA_CHI_DV]";
            wrdApp.Selection.Find.Replacement.Text = LinkQ.Systems.Elements.Element.sysDia_Chi_Dv;//(string)Parameters.GetParaValue("DIA_CHI");Haids
            wrdApp.Selection.Find.Execute(ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceAll, ref missing, ref missing, ref missing, ref missing);

            wrdApp.Selection.Find.Text = "[SUBTITLE1]";
            wrdApp.Selection.Find.Replacement.Text = ((DateTime)drFilter["Ngay_Ct2"]).Year.ToString();
            wrdApp.Selection.Find.Execute(ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceAll, ref missing, ref missing, ref missing, ref missing);

            //Replace Detail
            foreach (DataRow dr in dtResult.Rows)
            {
                string strMa_So = (string)dr["Ma_So"];
                string strDu_Dau;

                if ((string)drReport["Vnd_Nt"] == "1")
                    strDu_Dau = Convert.ToDouble(dr["Du_Dau_Nt"]).ToString("N2", cti);
                else
                    strDu_Dau = Convert.ToDouble(dr["Du_Dau"]).ToString("N0", cti);

                if (strDu_Dau == "0")
                    strDu_Dau = string.Empty;

                string strDu_Cuoi;

                if ((string)drReport["Vnd_Nt"] == "1")
                    strDu_Cuoi = Convert.ToDouble(dr["Du_Cuoi_Nt"]).ToString("N2", cti);
                else
                    strDu_Cuoi = Convert.ToDouble(dr["Du_Cuoi"]).ToString("N0", cti);

                if (strDu_Cuoi == "0")
                    strDu_Cuoi = string.Empty;

                wrdApp.Selection.Find.Text = "[" + strMa_So + "_Du_Dau]";
                wrdApp.Selection.Find.Replacement.Text = strDu_Dau;
                wrdApp.Selection.Find.Execute(ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceAll, ref missing, ref missing, ref missing, ref missing);

                wrdApp.Selection.Find.Text = "[" + strMa_So + "_Du_Cuoi]";
                wrdApp.Selection.Find.Replacement.Text = strDu_Cuoi;
                wrdApp.Selection.Find.Execute(ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceAll, ref missing, ref missing, ref missing, ref missing);
            }

            object saveChanges = Word.WdSaveOptions.wdSaveChanges;
            object originalFormat = Word.WdOriginalFormat.wdWordDocument;
            object routeDocument = true;

            docOpen.Save();
            wrdApp.Visible = true;
            wrdApp.ShowMe();
        }

        public static void WriteToExcelTMBCTC(DataRow drFilter, string strFileName)
        {
            Excel.ApplicationClass excel = new Excel.ApplicationClass();
            excel.DisplayAlerts = false;

            if (!File.Exists(strFileName))
            {
                MessageBox.Show("Không tìm thấy File mẫu");
                return;
            }

            Excel.Workbook wBook = excel.Application.Workbooks.Open(strFileName, Missing.Value, false, Missing.Value, Missing.Value, Missing.Value, true,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

            //Excel.Worksheet wSheet = (Excel.Worksheet)wBook.Sheets[1];

            Excel.Worksheet wSheet = (Microsoft.Office.Interop.Excel.Worksheet)wBook.ActiveSheet;

            Excel.Range range = (Excel.Range)wSheet.UsedRange;

            range.Replace("[Ten_Dvi]", Element.sysTen_DvCs, Excel.XlLookAt.xlWhole, Excel.XlSearchOrder.xlByRows, true, Type.Missing, Type.Missing, Type.Missing);
            range.Replace("[Dia_Chi_Dvi]", Element.sysDia_Chi_Dv, Excel.XlLookAt.xlWhole, Excel.XlSearchOrder.xlByRows, true, Type.Missing, Type.Missing, Type.Missing);

            Hashtable ht = new Hashtable();
            ht["NGAY_CT1"] = drFilter["NGAY_CT1"];
            ht["NGAY_CT2"] = drFilter["NGAY_CT2"];
            ht["MA_DVCS"] = drFilter["MA_DVCS"];
            ht["Language_Type".ToUpper()] = drFilter["Language_Type"];
            ht["Is_Vnd".ToUpper()] = drFilter["Is_Vnd"];

            //Lấy bảng CĐPS			
            ht["Is_Can_Tru".ToUpper()] = false;
            DataTable dtCDPS = SQLExec.ExecuteReturnDt("sp_rptQTTC00", ht, CommandType.StoredProcedure);

            //Lấy bảng DMTK
            DataTable dtDmTk = SQLExec.ExecuteReturnDt("SELECT Tk FROM L81DMTK", ht, CommandType.Text);

            DataRow drNewRow = null;
            foreach (DataRow drDmTk in dtDmTk.Rows)
            {
                if (dtCDPS.Select("Tk = '" + (string)drDmTk["Tk"] + "'").Length == 0)
                {
                    drNewRow = dtCDPS.NewRow();
                    Common.SetDefaultDataRow(ref drNewRow);
                    drNewRow["Tk"] = drDmTk["Tk"];

                    dtCDPS.Rows.Add(drNewRow);
                }

            }

            //Lấy bảng chi phí			
            ht["Kieu_Nhom".ToUpper()] = "1";
            ht["Kieu_Th".ToUpper()] = "1";
            DataTable dtChiPhi = SQLExec.ExecuteReturnDt("sp_rptCFT01", ht, CommandType.StoredProcedure);

            //Lấy bảng chi phí năm trước			
            ht["NGAY_CT1"] = ((DateTime)drFilter["NGAY_CT1"]).AddYears(-1);
            ht["NGAY_CT2"] = ((DateTime)drFilter["NGAY_CT2"]).AddYears(-1);

            DataTable dtChiPhi1 = SQLExec.ExecuteReturnDt("sp_rptCFT01", ht, CommandType.StoredProcedure);

            drNewRow = null;
            DataRow[] arrDdrDmTkChiPhi = dtDmTk.Select("SUBSTRING(Tk, 1, 1) IN ('6', '8')");

            foreach (DataRow drDmTk in arrDdrDmTkChiPhi)
            {
                if (dtChiPhi.Select("Tk = '" + (string)drDmTk["Tk"] + "'").Length == 0)
                {
                    drNewRow = dtChiPhi.NewRow();
                    Common.SetDefaultDataRow(ref drNewRow);
                    drNewRow["Tk"] = drDmTk["Tk"];

                    dtChiPhi.Rows.Add(drNewRow);
                }
            }

            foreach (DataRow drDmTk in arrDdrDmTkChiPhi)
            {
                if (dtChiPhi1.Select("Tk = '" + (string)drDmTk["Tk"] + "'").Length == 0)
                {
                    drNewRow = dtChiPhi1.NewRow();
                    Common.SetDefaultDataRow(ref drNewRow);
                    drNewRow["Tk"] = drDmTk["Tk"];

                    dtChiPhi1.Rows.Add(drNewRow);
                }
            }

            //Lấy bảng KQKD
            ht["NGAY_CT1"] = drFilter["NGAY_CT1"];
            ht["NGAY_CT2"] = drFilter["NGAY_CT2"];
            ht["Table_Formula".ToUpper()] = (string)drReport["Report_ID"] == "QTTC04C" ? "L82QTTC02_133" : "L82QTTC02_200";
            DataTable dtKQKD = SQLExec.ExecuteReturnDt("sp_rptQTTC02", ht, CommandType.StoredProcedure);

            //Lấy bảng TSCĐ HH			
            ht["Table_Formula".ToUpper()] = "L82TST10A";
            DataTable dtTSCDHH = SQLExec.ExecuteReturnDt("sp_rptTST10A", ht, CommandType.StoredProcedure);

            //Lấy bảng TSCĐ Thuê TC			
            ht["Table_Formula".ToUpper()] = "L82TST10B";
            DataTable dtTSCDTTC = SQLExec.ExecuteReturnDt("sp_rptTST10B", ht, CommandType.StoredProcedure);

            //Lấy bảng TSCĐ VH			
            ht["Table_Formula".ToUpper()] = "L82TST10C";
            DataTable dtTSCDVH = SQLExec.ExecuteReturnDt("sp_rptTST10C", ht, CommandType.StoredProcedure);

            //CDPS
            foreach (DataRow drCDPS in dtCDPS.Rows)
            {
                range.Replace("[DU_NO1_" + drCDPS["Tk"] + "]", drCDPS["Du_No1"], Excel.XlLookAt.xlWhole, Excel.XlSearchOrder.xlByRows, true, Type.Missing, Type.Missing, Type.Missing);
                range.Replace("[DU_CO1_" + drCDPS["Tk"] + "]", drCDPS["Du_Co1"], Excel.XlLookAt.xlWhole, Excel.XlSearchOrder.xlByRows, true, Type.Missing, Type.Missing, Type.Missing);
                range.Replace("[DU_NO_CO1_" + drCDPS["Tk"] + "]", (Decimal)drCDPS["Du_No1"] - (Decimal)drCDPS["Du_Co1"], Excel.XlLookAt.xlWhole, Excel.XlSearchOrder.xlByRows, true, Type.Missing, Type.Missing, Type.Missing);
                range.Replace("[DU_CO_NO1_" + drCDPS["Tk"] + "]", (Decimal)drCDPS["Du_Co1"] - (Decimal)drCDPS["Du_No1"], Excel.XlLookAt.xlWhole, Excel.XlSearchOrder.xlByRows, true, Type.Missing, Type.Missing, Type.Missing);

                range.Replace("[DU_NO2_" + drCDPS["Tk"] + "]", drCDPS["Du_No2"], Excel.XlLookAt.xlWhole, Excel.XlSearchOrder.xlByRows, true, Type.Missing, Type.Missing, Type.Missing);
                range.Replace("[DU_CO2_" + drCDPS["Tk"] + "]", drCDPS["Du_Co2"], Excel.XlLookAt.xlWhole, Excel.XlSearchOrder.xlByRows, true, Type.Missing, Type.Missing, Type.Missing);
                range.Replace("[DU_NO_CO2_" + drCDPS["Tk"] + "]", (Decimal)drCDPS["Du_No2"] - (Decimal)drCDPS["Du_Co2"], Excel.XlLookAt.xlWhole, Excel.XlSearchOrder.xlByRows, true, Type.Missing, Type.Missing, Type.Missing);
                range.Replace("[DU_CO_NO2_" + drCDPS["Tk"] + "]", (Decimal)drCDPS["Du_Co2"] - (Decimal)drCDPS["Du_No2"], Excel.XlLookAt.xlWhole, Excel.XlSearchOrder.xlByRows, true, Type.Missing, Type.Missing, Type.Missing);

                range.Replace("[PS_NO_" + drCDPS["Tk"] + "]", drCDPS["PS_No"], Excel.XlLookAt.xlWhole, Excel.XlSearchOrder.xlByRows, true, Type.Missing, Type.Missing, Type.Missing);
                range.Replace("[PS_CO_" + drCDPS["Tk"] + "]", drCDPS["PS_Co"], Excel.XlLookAt.xlWhole, Excel.XlSearchOrder.xlByRows, true, Type.Missing, Type.Missing, Type.Missing);
                range.Replace("[PS_NO_CO_" + drCDPS["Tk"] + "]", (Decimal)drCDPS["PS_No"] - (Decimal)drCDPS["PS_Co"], Excel.XlLookAt.xlWhole, Excel.XlSearchOrder.xlByRows, true, Type.Missing, Type.Missing, Type.Missing);
                range.Replace("[PS_CO_NO_" + drCDPS["Tk"] + "]", (Decimal)drCDPS["PS_Co"] - (Decimal)drCDPS["Ps_No"], Excel.XlLookAt.xlWhole, Excel.XlSearchOrder.xlByRows, true, Type.Missing, Type.Missing, Type.Missing);
            }

            //ChiPhi năm nay
            foreach (DataRow drChiPhi in dtChiPhi.Rows)
            {
                range.Replace("[CHIPHI_" + drChiPhi["Tk"] + "]", drChiPhi["Tien"], Excel.XlLookAt.xlWhole, Excel.XlSearchOrder.xlByRows, true, Type.Missing, Type.Missing, Type.Missing);
            }

            //ChiPhi năm trước
            foreach (DataRow drChiPhi1 in dtChiPhi1.Rows)
            {
                range.Replace("[CHIPHI1_" + drChiPhi1["Tk"] + "]", drChiPhi1["Tien"], Excel.XlLookAt.xlWhole, Excel.XlSearchOrder.xlByRows, true, Type.Missing, Type.Missing, Type.Missing);
            }

            //KQKD
            foreach (DataRow drKQKD in dtKQKD.Rows)
            {
                range.Replace("[KQKD_" + drKQKD["Ma_So"] + "]", drKQKD["Nam_Nay"], Excel.XlLookAt.xlWhole, Excel.XlSearchOrder.xlByRows, true, Type.Missing, Type.Missing, Type.Missing);
                range.Replace("[KQKD1_" + drKQKD["Ma_So"] + "]", drKQKD["Nam_Truoc"], Excel.XlLookAt.xlWhole, Excel.XlSearchOrder.xlByRows, true, Type.Missing, Type.Missing, Type.Missing);
            }

            //TSCĐ HH
            string strColumnName = string.Empty;
            foreach (DataRow drTSCDHH in dtTSCDHH.Rows)
            {
                for (int i = 1; i <= 8; i++)
                {
                    strColumnName = "TIEN_TSA" + i.ToString();
                    if (dtTSCDHH.Columns.Contains(strColumnName))
                        range.Replace("[HH_" + drTSCDHH["Ma_So"] + "_" + i.ToString() + "]", drTSCDHH[strColumnName], Excel.XlLookAt.xlWhole, Excel.XlSearchOrder.xlByRows, true, Type.Missing, Type.Missing, Type.Missing);
                }
            }

            //TSCĐ HH
            strColumnName = string.Empty;
            foreach (DataRow drTSCDTTC in dtTSCDTTC.Rows)
            {
                for (int i = 1; i <= 8; i++)
                {
                    strColumnName = "TIEN_TSB" + i.ToString();
                    if (dtTSCDTTC.Columns.Contains(strColumnName))
                        range.Replace("[TTC_" + drTSCDTTC["Ma_So"] + "_" + i.ToString() + "]", drTSCDTTC[strColumnName], Excel.XlLookAt.xlWhole, Excel.XlSearchOrder.xlByRows, true, Type.Missing, Type.Missing, Type.Missing);
                }
            }

            //TSCĐ HH
            strColumnName = string.Empty;
            foreach (DataRow drTSCDVH in dtTSCDVH.Rows)
            {
                for (int i = 1; i <= 8; i++)
                {
                    strColumnName = "TIEN_TSC" + i.ToString();
                    if (dtTSCDVH.Columns.Contains(strColumnName))
                        range.Replace("[VH_" + drTSCDVH["Ma_So"] + "_" + i.ToString() + "]", drTSCDVH[strColumnName], Excel.XlLookAt.xlWhole, Excel.XlSearchOrder.xlByRows, true, Type.Missing, Type.Missing, Type.Missing);
                }
            }

            wBook.Save();
            excel.Visible = true;
        }

        public static void WriteToExcel(DataTable dtData, string strSubTitle, string strFileName, string strDestFont)
        {
            Excel.ApplicationClass excel = new Excel.ApplicationClass();
            if (!File.Exists(strFileName))
            {
                MessageBox.Show("Không tìm thấy File mẫu");
                return;
            }
            Excel.Workbook wBook = excel.Application.Workbooks.Open(strFileName, Missing.Value, false, Missing.Value, Missing.Value, Missing.Value, true,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            Excel.Worksheet wSheet = (Excel.Worksheet)wBook.Sheets[1];

            //wBook = excel.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            wSheet = (Microsoft.Office.Interop.Excel.Worksheet)wBook.ActiveSheet;
            excel.Visible = true;
            //Write Lao động tăng
            DataTable dtTang = (new DataView(dtData, "Type_Data='TANG'", "", DataViewRowState.CurrentRows)).ToTable();
            int iCountTang = dtTang.Rows.Count;
            InsertRow(11, iCountTang - 1, wSheet);
            SetValue(wSheet, dtTang, 11);

            //Write Lao động Giam
            DataTable dtGiam = (new DataView(dtData, "Type_Data='GIAM'", "", DataViewRowState.CurrentRows)).ToTable();
            int iCountGiam = dtGiam.Rows.Count;
            int iRowGiam = GetRow("Lao động giảm", 2, wSheet) + 1;
            InsertRow(iRowGiam, iCountGiam - 1, wSheet);
            SetValue(wSheet, dtGiam, iRowGiam);

            //Write Thay doi Lao động
            DataTable dtThayDoi = (new DataView(dtData, "Type_Data='THAYDOI'", "", DataViewRowState.CurrentRows)).ToTable();
            int iCountThayDoi = dtThayDoi.Rows.Count;
            int iRowThayDoi = GetRow("Thay đổi lương, chức danh công việc", 2, wSheet) + 1;
            InsertRow(iRowThayDoi, iCountThayDoi - 1, wSheet);
            SetValue(wSheet, dtThayDoi, iRowThayDoi);

            //Write BHYT
            DataTable dtBHYT = (new DataView(dtData, "Type_Data='BHYT'", "", DataViewRowState.CurrentRows)).ToTable();
            int iCountBHYT = dtBHYT.Rows.Count;
            int iRowBHYT = GetRow("Bổ sung BHYT", 2, wSheet) + 1;
            InsertRow(iRowBHYT, iCountBHYT - 1, wSheet);
            SetValue(wSheet, dtBHYT, iRowBHYT);

            //Write BHTN
            DataTable dtBHTN = (new DataView(dtData, "Type_Data='BHTN'", "", DataViewRowState.CurrentRows)).ToTable();
            int iCountBHTN = dtBHTN.Rows.Count;
            int iRowBHTN = GetRow("Bổ sung BH thất nghiệp", 2, wSheet) + 1;
            //int iRowTongHop = GetRow("* TỔNG HỢP CHUNG:", 3,wSheet);
            InsertRow(iRowBHTN, iCountBHTN - 1, wSheet);
            SetValue(wSheet, dtBHTN, iRowBHTN);

            wBook.SaveCopyAs(@"e:\01.Source Control\LinkQ\Template\03a-TBH_3.xls");
            excel.Visible = true;

        }
        public static void SetValue(Excel.Worksheet wSheet, DataTable dtData, int iRowBegin)
        {
            int iRowFormat = iRowBegin;
            for (int i = 0; i < dtData.Rows.Count; i++)
            {
                DataRow dr = dtData.Rows[i];
                wSheet.Cells[iRowBegin, 1] = dr["Stt"].ToString();
                wSheet.Cells[iRowBegin, 2] = dr["Ten_CbNv"].ToString();
                wSheet.Cells[iRowBegin, 3] = "'" + dr["So_BHXH"].ToString();
                wSheet.Cells[iRowBegin, 4] = "'" + Library.StrToDate(dr["Ngay_Sinh"].ToString()).ToShortDateString();
                wSheet.Cells[iRowBegin, 5] = float.Parse(dr["Luong_BHXH_Cu"].ToString());
                wSheet.Cells[iRowBegin, 10] = Convert.ToDouble(dr["Luong_BHXH_Moi"]);
                wSheet.Cells[iRowBegin, 15] = Library.StrToDate(dr["Tu_Thang"].ToString());
                if (dr["Den_Thang"].ToString().Trim() != "")
                    wSheet.Cells[iRowBegin, 16] = Library.StrToDate(dr["Den_Thang"].ToString());
                wSheet.Cells[iRowBegin, 17] = Math.Round(decimal.Parse(dr["Ty_Le_Dong"].ToString()) / 100, 2);
                wSheet.Cells[iRowBegin, 18] = dr["Thay_Doi_Cd"].ToString();
                wSheet.Cells[iRowBegin, 19] = (dr["Tra_The"].ToString().ToUpper() == "TRUE") ? "X" : "";
                wSheet.Cells[iRowBegin, 20] = dr["Noi_Dung"].ToString();
                //for (int j = 0; j < dtData.Columns.Count;j++ )
                //{
                //    DataColumn dc = dtData.Columns[j];
                //    wSheet.Cells[iRowBegin, j+1] = dr[dc.ColumnName].ToString();
                //}			

                for (int k = 22; k < 39; k++)
                {
                    Excel.Range rgCopy = (Excel.Range)wSheet.Cells[iRowBegin - 1, k];
                    Excel.Range rgDes = (Excel.Range)wSheet.Cells[iRowBegin, k];
                    rgDes.FillDown();
                    //wSheet.Cells[iRowBegin, k] = rgCopy.fil.FillDown(); 
                }
                iRowBegin = iRowBegin + 1;
            }
            Excel.Range rgFormat = wSheet.get_Range("A" + iRowFormat, "T" + iRowBegin);
            rgFormat.Font.Bold = false;
            rgFormat.Font.Italic = false;
            //Fill công thức
        }
        public static int GetRow(string strFindText, int iCol, Excel.Worksheet wSheet)
        {
            int ikq = 0;
            for (int i = 10; i < wSheet.Rows.Count; i++)
            {
                Excel.Range range = (Excel.Range)wSheet.Cells[i, iCol];
                if (range.Text.ToString().ToUpper() == strFindText.ToUpper())
                {
                    ikq = i;
                    break;
                }
            }
            return ikq;
        }
        public static void InsertRow_old(int iRowBegin, int iRowInsert, Excel.Worksheet wSheet)
        {
            object obj = wSheet.Cells[iRowInsert + iRowBegin, 1];
            int iRowEnd = GetRow("Cán bộ BHXH", 2, wSheet);
            Excel.Range range = wSheet.get_Range("A" + iRowBegin.ToString(), "T" + iRowEnd.ToString());
            range.UnMerge();
            range.Cut(obj);
        }
        public static void InsertRow(int iRowBegin, int iRowInsert, Excel.Worksheet wSheet)
        {
            for (int i = 0; i < iRowInsert; i++)
            {
                Excel.Range range = wSheet.get_Range("A" + iRowBegin.ToString(), "AL" + iRowBegin.ToString());
                range.Insert(Excel.XlInsertShiftDirection.xlShiftDown, Excel.XlInsertFormatOrigin.xlFormatFromLeftOrAbove);
            }
        }



        public static string GetTitle(DataRow drFilter)
        {
            return drFilter["Title"].ToString().ToUpper();
        }

        public static string GetSubTitle1(DataRow drReport, DataRow drFilter)
        {
            if ((string)drReport["SubTitle1"] != string.Empty)
            {
                string strSubTitle1 = (Report.LanguageType == enuLanguageType.English) ? (string)drReport["SubTitle1E"] : (Report.LanguageType == enuLanguageType.Vietnamese) ? (string)drReport["SubTitle1"] : (string)drReport["SubTitle1O"]; ;

                string strDay1 = string.Empty, strDay2 = string.Empty;
                string strMonth1 = string.Empty, strMonth2 = string.Empty;
                string strYear1 = string.Empty, strYear2 = string.Empty;
                string strDate1 = string.Empty, strDate2 = string.Empty;

                if (drFilter.Table.Columns.Contains("NGAY_CT1"))
                {
                    DateTime dteNgay_Ct1 = (DateTime)drFilter["NGAY_CT1"];

                    strDay1 = dteNgay_Ct1.Day.ToString();
                    strMonth1 = dteNgay_Ct1.Month.ToString();
                    strYear1 = dteNgay_Ct1.Year.ToString();
                    strDate1 = dteNgay_Ct1.ToString("dd/MM/yyyy");

                    if (strSubTitle1.Contains("DAY(NGAY_CT1)") && strDay1 != string.Empty)
                        strSubTitle1 = strSubTitle1.Replace("DAY(NGAY_CT1)", strDay1);

                    if (strSubTitle1.Contains("MONTH(NGAY_CT1)") && strMonth1 != string.Empty)
                        strSubTitle1 = strSubTitle1.Replace("MONTH(NGAY_CT1)", strMonth1);

                    if (strSubTitle1.Contains("YEAR(NGAY_CT1)") && strYear1 != string.Empty)
                        strSubTitle1 = strSubTitle1.Replace("YEAR(NGAY_CT1)", strYear1);

                    if (strSubTitle1.Contains("DATE(NGAY_CT1)") && strDate1 != string.Empty)
                        strSubTitle1 = strSubTitle1.Replace("DATE(NGAY_CT1)", strDate1);
                }

                if (drFilter.Table.Columns.Contains("NGAY_CT2"))
                {
                    DateTime dteNgay_Ct2 = (DateTime)drFilter["NGAY_CT2"];

                    strDay2 = dteNgay_Ct2.Day.ToString();
                    strMonth2 = dteNgay_Ct2.Month.ToString();
                    strYear2 = dteNgay_Ct2.Year.ToString();
                    strDate2 = dteNgay_Ct2.ToString("dd/MM/yyyy");

                    if (strSubTitle1.Contains("DAY(NGAY_CT2)") && strDay2 != string.Empty)
                        strSubTitle1 = strSubTitle1.Replace("DAY(NGAY_CT2)", strDay2);

                    if (strSubTitle1.Contains("MONTH(NGAY_CT2)") && strMonth2 != string.Empty)
                        strSubTitle1 = strSubTitle1.Replace("MONTH(NGAY_CT2)", strMonth2);

                    if (strSubTitle1.Contains("YEAR(NGAY_CT2)") && strYear2 != string.Empty)
                        strSubTitle1 = strSubTitle1.Replace("YEAR(NGAY_CT2)", strYear2);

                    if (strSubTitle1.Contains("DATE(NGAY_CT2)") && strDate2 != string.Empty)
                        strSubTitle1 = strSubTitle1.Replace("DATE(NGAY_CT2)", strDate2);
                }

                return strSubTitle1;

            }
            else if (drFilter.Table.Columns.Contains("NGAY_CT1") && drFilter.Table.Columns.Contains("NGAY_CT2"))
            {
                if (drFilter["NGAY_CT1"].ToString() != string.Empty && drFilter["NGAY_CT2"].ToString() != string.Empty)
                    return Report.PrintType == PrintType.PrintVoucher ? Common.ReadDate((DateTime)drFilter["NGAY_CT1"], (DateTime)drFilter["NGAY_CT2"], Element.sysLanguage) : Common.ReadDate((DateTime)drFilter["NGAY_CT1"], (DateTime)drFilter["NGAY_CT2"], Report.LanguageType);
                else
                    return string.Empty;
            }
            else if (drFilter.Table.Columns.Contains("NGAY_CT"))
            {
                return Report.PrintType == PrintType.PrintVoucher ? Common.ReadDate((DateTime)drFilter["NGAY_CT"], (DateTime)drFilter["NGAY_CT"], Element.sysLanguage) : Common.ReadDate((DateTime)drFilter["NGAY_CT"], (DateTime)drFilter["NGAY_CT"], Report.LanguageType);
            }

            return string.Empty;
        }

        public static string GetSubTitle2(DataRow drReport, DataRow drFilter)
        {
            string strSubTitle = string.Empty;
            string strSubTileList = (string)drReport["SubTitle_List"];

            strSubTileList = strSubTileList.Replace(" ", "");
            if (strSubTileList == string.Empty)
                return string.Empty;

            string[] strArrSubTile = strSubTileList.Split(',');

            Hashtable htFilterInfo = new Hashtable();
            htFilterInfo.Add("FORM_ID", drReport["Report_ID"]);
            htFilterInfo.Add("FORM_ID_FILTER", drReport["Report_ID_Filter"]);

            DataTable dtFilterInfo = SQLExec.ExecuteReturnDt("sp_GetReportFilterInfo", htFilterInfo, CommandType.StoredProcedure);

            foreach (string strColumn_ID in strArrSubTile)
            {
                if (!drFilter.Table.Columns.Contains(strColumn_ID) || (string)drFilter[strColumn_ID] == string.Empty)
                    continue;

                DataRow[] drArr = dtFilterInfo.Select("Column_ID = '" + strColumn_ID + "'");
                if (drArr.Length <= 0)
                    continue;

                DataRow drFilterInfo = drArr[0];

                string strColumn_ID_Value = (string)drFilter[strColumn_ID];
                string strFilter_Name = (string)drFilterInfo["Filter_Name"];

                //HuanDS Filter_Label lấy từ ngôn ngữ ra
                string strLabel = string.Empty;
                string strLabel0 = Report.PrintType == PrintType.PrintVoucher ? LinkQ.Systems.Librarys.Languages.GetLanguage(strColumn_ID) : LinkQ.Systems.Librarys.Languages.GetLanguage(strColumn_ID, Report.LanguageType);

                if (strLabel0 != strColumn_ID)
                    strLabel = strLabel0;
                //else
                //    strLabel = (string)drFilterInfo["Filter_Label"];

                string strTable_Lookup = (string)drFilterInfo["Table_Lookup"];

                DataTable dtLooup = SQLExec.ExecuteReturnDt("SELECT ColumnID_Lookup, ColumnName_Lookup FROM L00LOOKUP WHERE ColumnID = '" + strColumn_ID + "'");
                string strColumn_ID_Lookup = string.Empty;
                string strFilter_Name_Lookup = string.Empty;

                if (dtLooup.Rows.Count >= 1)
                {
                    strColumn_ID_Lookup = dtLooup.Rows[0]["ColumnID_Lookup"].ToString();
                    strFilter_Name_Lookup = dtLooup.Rows[0]["ColumnName_Lookup"].ToString();
                }
                else
                {
                    strColumn_ID_Lookup = strColumn_ID;
                    strFilter_Name_Lookup = strFilter_Name;
                }

                DataRow dr = DataTool.SQLGetDataRowByID(strTable_Lookup, strColumn_ID_Lookup, strColumn_ID_Value);
                if (dr == null)
                    return string.Empty;

                string strFilter_Name_Value = string.Empty;

                if (Element.sysLanguage == enuLanguageType.English && dr.Table.Columns.Contains(strFilter_Name_Lookup + "E"))
                    strFilter_Name_Value = (string)dr[strFilter_Name_Lookup + "E"];

                else if (Report.LanguageType == enuLanguageType.Other && dr.Table.Columns.Contains(strFilter_Name_Lookup + "O"))
                    strFilter_Name_Value = (string)dr[strFilter_Name_Lookup + "O"];

                else
                    strFilter_Name_Value = (string)dr[strFilter_Name_Lookup];

                if (strSubTitle == string.Empty)
                    strSubTitle = strLabel + ": " + strColumn_ID_Value + " - " + strFilter_Name_Value;
                else
                    strSubTitle = strSubTitle + "\n" + strLabel + ": " + strColumn_ID_Value + " - " + strFilter_Name_Value;
            }

            return strSubTitle;
        }

        public static void ExportReport(string strFileType, string strPath, rptFileReport repFile, DataTable dtDetail)
        {

            switch (strFileType)
            {
                case "xls": //enuExportType.Excel:
                    DataDynamics.ActiveReports.Export.Xls.XlsExport xlsExport = new DataDynamics.ActiveReports.Export.Xls.XlsExport();

                    //xlsExport.MinRowHeight = 1;
                    //xlsExport.MultiSheet = true;
                    //xlsExport.RemoveVerticalSpace = true;
                    xlsExport.UseCellMerging = false;

                    xlsExport.MinColumnWidth = 0.25f;
                    xlsExport.FileFormat = DataDynamics.ActiveReports.Export.Xls.FileFormat.Xls97Plus;
                    xlsExport.AutoRowHeight = true;
                    xlsExport.DisplayGridLines = true;

                    repFile.pageHeader.Visible = true;

                    xlsExport.Export(repFile.Document, strPath);

                    repFile.pageFooter.Visible = true;
                    repFile.pageFooter.Visible = true;

                    break;
                case "doc": //enuExportType.Word:
                    DataDynamics.ActiveReports.Export.Rtf.RtfExport rftExport = new DataDynamics.ActiveReports.Export.Rtf.RtfExport();
                    repFile.DataSource = dtDetail;
                    rftExport.Export(repFile.Document, strPath);
                    break;
                case "Html": //enuExportType.Html:
                    DataDynamics.ActiveReports.Export.Html.HtmlExport htmlExport = new DataDynamics.ActiveReports.Export.Html.HtmlExport();
                    htmlExport.Export(repFile.Document, strPath);
                    break;
                case "pdf": //enuExportType.PDF:
                    DataDynamics.ActiveReports.Export.Pdf.PdfExport pdfExport = new DataDynamics.ActiveReports.Export.Pdf.PdfExport();
                    pdfExport.NeverEmbedFonts = "";
                    pdfExport.Export(repFile.Document, strPath);
                    break;
            }

        }

        public static void SendMail(DataTable dtDetail, rptFileReport repfile, string strTen_Bc)
        {
            frmSendMail frmSM = new frmSendMail();
            frmSM.Load(strTen_Bc);
            string str = ConvertFont.RemoveMark(frmSM.strFileName);
            if (!Directory.Exists(@"C:\Temp"))
                Directory.CreateDirectory(@"C:\Temp");
            string strPath = @"C:\Temp\" + str;
            if (!frmSM.isAccept)
                return;
            ExportReport(frmSM.strFileType, strPath, repfile, dtDetail);
            MAPI mapi = new MAPI();
            if (!File.Exists(strPath))
            {
                MessageBox.Show("Sorry");
                return;
            }
            mapi.AddAttachment(strPath);
            mapi.SendMailPopup("", "Dear ");
            if (File.Exists(strPath))
                File.Delete(strPath);
        }

        public static void FillFileReport(rptFileReport repFile, DataRow drReport, DataRow drFilter, DataTable dtDetail, DataSet dsResult)
        {
            if (drReport != null && !drReport.Table.Columns.Contains("Vnd_Nt"))
            {
                drReport.Table.Columns.Add(new DataColumn("Vnd_Nt", typeof(string)));

                if (drReport.Table.Columns.Contains("Is_Vnd"))
                    drReport["Vnd_Nt"] = (bool)drReport["Is_Vnd"] ? "0" : "1";
                else
                    drReport["Vnd_Nt"] = "0";
            }

            #region Create Dictionary Header
            //Tu Filter
            dicHeader.Clear();
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
            dicHeader["TEN_DV_CQ"] = (string)Parameters.GetParaValue("TEN_DV_CQ");
            dicHeader["TEN_DV"] = LinkQ.Systems.Elements.Element.sysTen_Dvi.ToUpper();
            dicHeader["DIA_CHI_DV"] = LinkQ.Systems.Elements.Element.sysDia_Chi_Dv;//(string)Parameters.GetParaValue("DIA_CHI");Haids
                                                                                   //dicHeader["MAU_SO"] = "Mẫu số: 01-TT";
            dicHeader["QUYET_DINH"] = "(Ban hành theo QĐ số: 15/2006/QĐ-BTC\n Ngày 20 tháng 03 năm 2006\n của Bộ trưởng BTC)";

            #endregion
            string strRepFile = string.Empty;


            if (drReport != null)
            {
                if (drReport["Vnd_Nt"] != null)
                {
                    if (drReport["Vnd_Nt"].ToString() == "2")
                        strRepFile = (string)dicHeader["REPORT_FILE"] + "_NT";
                    else
                        strRepFile = (string)dicHeader["REPORT_FILE"];
                }
            }
            else
                strRepFile = (string)dicHeader["REPORT_FILE"];

            strRepFile += ".rpx";

            repFile.SetLicense("RGN,RGN Warez Group,DD-APN-30-C01339,W44SSM949SWJ449HSHMF");
            string strFileName = Application.StartupPath + @"\Reports\" + strRepFile;
            if (!System.IO.File.Exists(strFileName))
            {
                Common.MsgCancel("File :{" + strFileName + "} " + Languages.GetLanguage("NOT_FOUND"));
                return;
            }

            repFile.LoadLayout(strFileName);

            repFile.PageSettings.Margins.Left = 0F;
            repFile.PageSettings.Margins.Bottom = 0F;
            repFile.PageSettings.Margins.Left = 0F;
            repFile.PageSettings.Margins.Right = 0F;

            repFile.DataSource = dtDetail;

            FillHeaderAndFooterInfo(repFile, dicHeader, dtDetail);
            repFile.Run();
            repFile.AddAssembly(Assembly.Load("LinkQ.Systems"));
            repFile.AddAssembly(Assembly.Load("LinkQ.Systems.Elements"));
            repFile.AddAssembly(Assembly.Load("LinkQ.Systems.Librarys7.0"));
            repFile.AddAssembly(Assembly.Load("LinkQ.Systems.Commons7.0"));
            repFile.AddAssembly(Assembly.Load("LinkQ.Systems.Data"));
            repFile.AddAssembly(Assembly.Load("LinkQ.Systems.Publics"));
        }

        public static void FillHeaderAndFooterInfo(rptFileReport repFile, Dictionary<string, string> dicHeader, DataTable dtDetail)
        {
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

                }
            }

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
            }


            foreach (ARControl arCtrl in repFile.reportFooter.Controls)
            {
                if (arCtrl.GetType().Name == "Label")
                {
                    if (arCtrl.Tag == null || (string)arCtrl.Tag == string.Empty)
                        continue;

                    string strDataField = ((string)arCtrl.Tag).ToUpper();
                    if (dicHeader.ContainsKey(strDataField)) //&& dicHeader[strDataField] != string.Empty)
                    {
                        if (strDataField.Contains("SIGN1") && Element.sysLanguage == enuLanguageType.English)
                            ((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader["SIGNE1"];
                        else if (strDataField.Contains("SIGN2") && Element.sysLanguage == enuLanguageType.English)
                            ((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader["SIGNE2"];
                        else if (strDataField.Contains("SIGN3") && Element.sysLanguage == enuLanguageType.English)
                            ((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader["SIGNE3"];
                        else
                            ((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader[strDataField];
                    }
                    else
                        ((DataDynamics.ActiveReports.Label)arCtrl).Text = Languages.GetLanguage(strDataField, Report.LanguageType);
                }
            }

            foreach (ARControl arCtrl in repFile.pageFooter.Controls)
            {
                if (arCtrl.GetType().Name == "Label")
                {
                    if (arCtrl.Tag == null || (string)arCtrl.Tag == string.Empty)
                        continue;

                    string strDataField = ((string)arCtrl.Tag).ToUpper();
                    if (dicHeader.ContainsKey(strDataField)) //&& dicHeader[strDataField] != string.Empty)
                        ((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader[strDataField];
                    else
                        ((DataDynamics.ActiveReports.Label)arCtrl).Text = Languages.GetLanguage(strDataField, Report.LanguageType);
                }
            }

            foreach (ARControl arCtrl in repFile.groupHeader1.Controls)
            {
                if (arCtrl.GetType().Name == "Label")
                {
                    if (arCtrl.Tag == null || (string)arCtrl.Tag == string.Empty)
                        continue;

                    string strDataField = ((string)arCtrl.Tag).ToUpper();
                    if (dicHeader.ContainsKey(strDataField)) //&& dicHeader[strDataField] != string.Empty)
                        ((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader[strDataField];
                    else
                        ((DataDynamics.ActiveReports.Label)arCtrl).Text = Languages.GetLanguage(strDataField, Report.LanguageType);
                }
            }

            foreach (ARControl arCtrl in repFile.groupFooter1.Controls)
            {
                if (arCtrl.GetType().Name == "Label")
                {
                    if (arCtrl.Tag == null || (string)arCtrl.Tag == string.Empty)
                        continue;

                    string strDataField = ((string)arCtrl.Tag).ToUpper();
                    if (dicHeader.ContainsKey(strDataField)) //&& dicHeader[strDataField] != string.Empty)
                        ((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader[strDataField];
                    else
                        ((DataDynamics.ActiveReports.Label)arCtrl).Text = Languages.GetLanguage(strDataField, Report.LanguageType);
                }
            }

            foreach (ARControl arCtrl in repFile.detail.Controls)
            {
                if (arCtrl.GetType().Name == "TextBox")
                {
                    if (arCtrl.DataField == null || (string)arCtrl.DataField == string.Empty)
                        continue;

                    string strDataField = ((string)arCtrl.DataField).ToUpper();

                    if (Element.sysLanguage == enuLanguageType.English)
                    {
                        if (strDataField.ToUpper() == "CHI_TIEU" && dtDetail.Columns.Contains("CHI_TIEUE"))
                            arCtrl.DataField = "CHI_TIEUE";
                        if (strDataField.ToUpper() == "TEN_TK" && dtDetail.Columns.Contains("TEN_TKE"))
                            arCtrl.DataField = "TEN_TKE";
                    }
                    else if (Element.sysLanguage == enuLanguageType.Other)
                    {
                        if (strDataField.ToUpper() == "CHI_TIEU" && dtDetail.Columns.Contains("CHI_TIEUO"))
                            arCtrl.DataField = "CHI_TIEUO";
                        if (strDataField.ToUpper() == "TEN_TK" && dtDetail.Columns.Contains("TEN_TKO"))
                            arCtrl.DataField = "TEN_TKO";
                    }
                }
            }

            // Xu ly trong truong hop in nhieu lan
            #region
            //if (drPrintColumnsList != null)
            //{
            //    string[] strArrColumnPrintList = ((string)drPrintColumnsList["ColumnPrintList"]).Replace(" ", "").Split(',');
            //    string[] strArrColumnDetailList = ((string)drPrintColumnsList["ColumnDetailList"]).Replace(" ", "").Split(',');

            //    Dictionary<string, string> dic = new Dictionary<string, string>();

            //    for (int i = 0; i <= strArrColumnDetailList.Length - 1; i++)
            //    {
            //        dic[strArrColumnDetailList[i].ToUpper()] = strArrColumnPrintList[i].ToUpper();
            //    }

            //    foreach (ARControl arCtrl in repFile.detail.Controls)
            //    {
            //        if (arCtrl.GetType().Name == "TextBox")
            //        {
            //            if (arCtrl.DataField == null || (string)arCtrl.DataField == string.Empty)
            //                continue;

            //            if (dic.ContainsKey(arCtrl.Name.Substring(3).ToUpper()))
            //                arCtrl.DataField = dic[arCtrl.Name.Substring(3).ToUpper()];
            //            else
            //                ((DataDynamics.ActiveReports.TextBox)arCtrl).Text = string.Empty;
            //        }
            //    }

            //    foreach (ARControl arCtrl in repFile.pageHeader.Controls)
            //    {
            //        if (arCtrl.GetType().Name == "Label")
            //        {
            //            if (dic.ContainsKey(arCtrl.Name.Substring(3).ToUpper()))
            //                ((DataDynamics.ActiveReports.Label)arCtrl).Text = LinkQ.Systems.Librarys.Languages.GetLanguage(dic[arCtrl.Name.Substring(3).ToUpper()]);
            //            else if (arCtrl.Name.ToUpper().StartsWith("LBL"))
            //                ((DataDynamics.ActiveReports.Label)arCtrl).Text = string.Empty;
            //        }
            //    }
            //}

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
                        if (strDataField.Contains("TIEN") || strDataField.Contains("PS_") || strDataField.Contains("DU_") || strDataField.Contains("GIA"))
                            strDataField = strDataField + "_NT";

                        //if (dicHeader.ContainsKey(strDataField) && dicHeader[strDataField] != string.Empty)
                        if (dicHeader.ContainsKey(strDataField))
                            ((DataDynamics.ActiveReports.Label)arCtrl).Text = dicHeader[strDataField];
                        else
                            ((DataDynamics.ActiveReports.Label)arCtrl).Text = Languages.GetLanguage(strDataField, Report.LanguageType);
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

        private static int _Format_Tien = -1;
        public static int Format_Tien
        {
            get
            {
                if (_Format_Tien == -1)
                {
                    object strValue = Parameters.GetParaValue("FORMAT_TIEN");
                    if (strValue != string.Empty && (string)strValue != "FORMAT_TIEN")
                    {
                        _Format_Tien = Convert.ToInt16(strValue);
                    }
                    else
                        _Format_Tien = 0;
                }

                return _Format_Tien;
            }
        }

        private static int _Format_Tien_Nt = -1;
        public static int Format_Tien_Nt
        {
            get
            {
                if (_Format_Tien_Nt == -1)
                {
                    object strValue = Parameters.GetParaValue("FORMAT_TIEN_NT");
                    if (strValue != string.Empty && (string)strValue != "FORMAT_TIEN_NT")
                    {
                        _Format_Tien_Nt = Convert.ToInt16(strValue);
                    }
                    else
                        _Format_Tien_Nt = 2;
                }

                return _Format_Tien_Nt;
            }
        }

        private static int _Format_Gia = -1;
        public static int Format_Gia
        {
            get
            {
                if (_Format_Gia == -1)
                {
                    object strValue = Parameters.GetParaValue("FORMAT_GIA");
                    if (strValue != string.Empty && (string)strValue != "FORMAT_GIA")
                    {
                        _Format_Gia = Convert.ToInt16(strValue);
                    }
                    else
                        _Format_Gia = 2;
                }

                return _Format_Gia;
            }
        }

        private static int _Format_Gia_Nt = -1;
        public static int Format_Gia_Nt
        {
            get
            {
                if (_Format_Gia_Nt == -1)
                {
                    object strValue = Parameters.GetParaValue("FORMAT_GIA_NT");
                    if (strValue != string.Empty && (string)strValue != "FORMAT_GIA_NT")
                    {
                        _Format_Gia_Nt = Convert.ToInt16(strValue);
                    }
                    else
                        _Format_Gia_Nt = 2;
                }

                return _Format_Gia_Nt;
            }
        }

        private static int _Format_So_Luong = -1;
        public static int Format_So_Luong
        {
            get
            {
                if (_Format_So_Luong == -1)
                {
                    object strValue = Parameters.GetParaValue("FORMAT_SO_LUONG");
                    if (strValue != string.Empty && (string)strValue != "FORMAT_SO_LUONG")
                    {
                        _Format_So_Luong = Convert.ToInt16(strValue);
                    }
                    else
                        _Format_So_Luong = 2;
                }

                return _Format_So_Luong;
            }
        }

        private static enuLanguageType _LanguageType = enuLanguageType.Vietnamese;
        public static enuLanguageType LanguageType
        {
            get
            {
                return _LanguageType;
            }
            set
            {
                _LanguageType = value;
            }
        }

        private static PrintType _PrintType = PrintType.PrintVoucher;
        public static PrintType PrintType
        {
            get
            {
                return _PrintType;
            }
            set
            {
                _PrintType = value;
            }
        }
    }

    public enum PrintType { PrintVoucher, PrintReport };
}
