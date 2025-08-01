using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;
using DataDynamics.ActiveReports;

using LinkQ.Systems;
using LinkQ.Systems.Librarys;
using LinkQ.Systems.Commons;
using LinkQ.Systems.Controls;
using LinkQ.Systems.Data;
using LinkQ.Systems.Customizes;
using LinkQ.Systems.Elements;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;

namespace LinkQ.Reports
{
    public partial class frmReportResult : LinkQ.Systems.Controls.frmBase
    {
        #region Variable
        private int iPrintTime = 0;
        private DataTable dtDetail;
        private DataTable dtHeader;
        private DataSet dsResult;

        public BindingSource bdsResult = new BindingSource();
        private rptFileReport repFile = new rptFileReport();

        private dgvReport dgvResult;
        private tlReport tlResult;

        //Các thuộc tính tìm kiếm
        public frmSearch frmsearch = new frmSearch();

        private DataRow drReport;
        private DataRow drFilter;
        public frmMain frmMain = null;

        string strVnd_Nt = "0";

        #endregion

        #region Method

        public frmReportResult()
        {
            InitializeComponent();
            
            this.KeyDown += new KeyEventHandler(frmResult_KeyDown);
            this.KeyPreview = true;
        }               

        public void Load(DataRow drReport, DataRow drFilter)
        {
            this.drReport = drReport;
            this.drFilter = drFilter;
            this.strVnd_Nt = (string)drReport["Vnd_Nt"];

            if (drReport.Table.Columns.Contains("Title"))
                this.Text = (string)drReport["Title"];

            this.Build();
            this.FillData();
            AddContextMenu();

            //DockContent

            WeifenLuo.WinFormsUI.Docking.DockContent dockContent = new WeifenLuo.WinFormsUI.Docking.DockContent();

            this.TopLevel = false;
            this.Parent = dockContent;
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.WindowState = FormWindowState.Maximized;
            this.Dock = DockStyle.Fill;

            if (this.Text.Split(',').Length > 0)
                dockContent.TabText = this.Text.Split(',')[0];

            this.Text = string.Empty;

            dockContent.Show(frmMain.GetfrmMain().dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.Document);

			if ((string)Parameters.GetParaValue("HIEN_TIEU_DE_BAOCAO") == "0")
				tblLayoutPanel.RowStyles[0].Height = 0;

            this.Show();
            dgvResult.Select();
        }

        void Build()
        {
            if ((string)drReport["Report_Control"] == "G")
            {
                dgvResult = new dgvReport();
                dgvResult.ReadOnly = true;
                dgvResult.Dock = DockStyle.Fill;
                dgvResult.drReport = drReport;
                dgvResult.bVnd_Nt = strVnd_Nt == "0" ? true : false;
                dgvResult.strVnd_Nt = (string)drReport["Vnd_Nt"];
				tblLayoutPanel.Controls.Add(dgvResult, 0, 1);
                //dgvResult.Parent = this;				

                if (!(bool)drReport["Auto_Build"])
                {
                    dgvResult.strZone = (string)drReport["Report_ID"];
                    dgvResult.BuildGridViewReport();
                }
                else
                {
                    dgvResult.AutoGenerateColumns = true;
                    //dgvResult.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
					
					dgvResult.AutoResizeColumns();
					//dgvResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
				}

                dgvResult.MouseDoubleClick += new MouseEventHandler(dgvResult_MouseDoubleClick);
            }
            else
            {
                tlResult = new tlReport();
                tlResult.Dock = DockStyle.Fill;
                tlResult.drReport = drReport;
                tlResult.bVnd_Nt = strVnd_Nt == "0" ? true : false;
                tlResult.strZone = (string)drReport["Report_ID"];
                tlResult.BuildTreeListReport();
                tlResult.Parent = this;

                tlResult.MouseDoubleClick += new MouseEventHandler(tlResult_MouseDoubleClick);
            }
        }

		private void FillData()
		{
			string strSQLProc = (string)drReport["SQLProc"];
			string strSp_Filter = SQLExec.ExecuteReturnValue("SELECT Parameter_Value FROM L00PARAMETERS WHERE Parameter_Id='SP_FILTER'").ToString();
			bool bFilter = (strSp_Filter.Contains(",")) ? Library.Inlist(strSQLProc.ToUpper(), strSp_Filter.ToUpper()) : (strSQLProc == strSp_Filter);
			DataTable dtmember = SQLExec.ExecuteReturnDt("SELECT Member_ID FROM L00Member WHERE Member_ID = '" + Element.sysUser_Id + "' AND Is_MemberID = 1");
			if (bFilter)
			{
				if (dtmember.Rows.Count > 0)
				{
					bool bCheck = false;
					DataTable dtPara = SQLExec.ExecuteReturnDt("SELECT * FROM Sys.Parameters WHERE Object_Id = Object_Id('" + strSQLProc + "')");
					foreach (DataRow drPara in dtPara.Rows)
						if (drPara["NAME"].ToString().Replace("@", "").ToUpper() == "MA_CBNV")
						{
							bCheck = true;
							break;
						}
					if (bCheck)
					{
						if (!Element.sysIs_Admin)
							drFilter["Ma_CbNv"] = Element.sysUser_Id;
					}
				}
			}

			dsResult = SQLExec.ExecuteReturnDs(strSQLProc, drFilter, CommandType.StoredProcedure, true);

			dtDetail = dsResult.Tables[0];
			dtHeader = dsResult.Tables.Count > 1 ? dsResult.Tables[1] : null;

			if (dtHeader != null) //Hải: xuất hiện thông điệp lỗi
			{
				if (dtHeader.Rows.Count == 1 && dtHeader.Columns.Contains("Error_Msg"))
				{
					string strError_Msg = (string)dtHeader.Rows[0]["Error_Msg"];

					if (strError_Msg != string.Empty)
						Common.MsgCancel(strError_Msg);
				}
			}

			bdsResult.DataSource = dtDetail;

			foreach (DataGridViewColumn dgvc in dgvResult.Columns)
				if (!dtDetail.Columns.Contains(dgvc.DataPropertyName))
				{
					dgvc.Width = 0;
					dgvc.Visible = false;

				}

			if (dgvResult.Columns.Contains("CHI_TIEU") && Element.sysLanguage == enuLanguageType.English && dtDetail.Columns.Contains("CHI_TIEUE"))
				dgvResult.Columns["CHI_TIEU"].DataPropertyName = "CHI_TIEUE";

			if (dgvResult.Columns.Contains("TEN_TK") && Element.sysLanguage == enuLanguageType.English && dtDetail.Columns.Contains("TEN_TKE"))
				dgvResult.Columns["TEN_TK"].DataPropertyName = "TEN_TKE";

            //Haids thêm tiếng trung
            if (dgvResult.Columns.Contains("CHI_TIEU") && Element.sysLanguage == enuLanguageType.Other && dtDetail.Columns.Contains("CHI_TIEUO"))
                dgvResult.Columns["CHI_TIEU"].DataPropertyName = "CHI_TIEUO";

            if (dgvResult.Columns.Contains("TEN_TK") && Element.sysLanguage == enuLanguageType.Other && dtDetail.Columns.Contains("TEN_TKO"))
                dgvResult.Columns["TEN_TK"].DataPropertyName = "TEN_TKO";

			if ((string)drReport["Report_Control"] == "G")
			{
				dgvResult.DataSource = bdsResult;
				ExportControl = dgvResult;
			}
			else
			{
				tlResult.DataSource = bdsResult;
				ExportControl = tlResult;
			}

			frmsearch.bdsSearch = bdsResult;

			if ((bool)drReport["Auto_Build"])
			{
				this.BindingLanguage();

				foreach (DataGridViewColumn dgvc in dgvResult.Columns)
				{
					if (dgvc.DataPropertyName == "BOLD" || dgvc.DataPropertyName == "STATUS")
					{
						dgvResult.Columns[dgvc.DataPropertyName].Visible = false;

					}
					else if (dgvc.DataPropertyName == "DIEN_GIAI")
						dgvc.Width = 300;
					else if (dgvc.DataPropertyName == "CHI_TIEU")
						dgvc.Width = 300;
					else if (dgvc.DataPropertyName == "CHI_TIEUE")
						dgvc.Width = 300;
					else if (dgvc.DataPropertyName.Contains("TEN_"))
						dgvc.Width = 300;

					else if (Common.Inlist(dtDetail.Columns[dgvc.DataPropertyName].DataType.ToString(), "System.Boolean,System.Byte,System.Int16,System.Int32,System.Int64,System.Decimal,System.Double"))
						dgvc.DefaultCellStyle.Format = "N0";
				}
			}

			//Hải: Gán caption cho những cột
			if (dtHeader != null)
			{
				foreach (DataColumn dc in dtHeader.Columns)
				{
					if (dc.ColumnName.StartsWith("LABEL_"))
					{
						string strColumnName = dc.ColumnName.Substring(6);

						if (dgvResult.Columns.Contains(strColumnName))
						{
							dgvResult.Columns[strColumnName].HeaderText = dtHeader.Rows[0][dc].ToString();
						}
					}
				}
			}

			if ((bool)drReport["Auto_Build"])
			{
				//dgvResult.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders);
				//dgvResult.AutoResizeColumns();
				//dgvResult.AutoSizeColumnsMode =DataGridViewAutoSizeColumnsMode.DisplayedCells;

				foreach (DataGridViewColumn dgvc in dgvResult.Columns)
				{
					if(dtDetail.Columns.Contains(dgvc.Name) && dtDetail.Columns[dgvc.Name].DataType.Equals(typeof(decimal)))
						dgvc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				}
			}

            lblTitle.Text = (Element.sysLanguage == enuLanguageType.Vietnamese ? (string)drReport["Title"] : Element.sysLanguage == enuLanguageType.English ? (string)drReport["TitleE"] : (string)drReport["TitleO"]).ToUpper();
            
            if (drFilter.Table.Columns.Contains("SubTitle1") && ((string)drFilter["SubTitle1"]) != string.Empty)
                lblSubTile1.Text = (string)drFilter["SubTitle1"];

			lblSubTile2.Text = string.Empty;

			if (drFilter.Table.Columns.Contains("SubTitle2") && ((string)drFilter["SubTitle2"]) != string.Empty)
                lblSubTile2.Text = (string)drFilter["SubTitle2"];

			string[] strarr = lblSubTile2.Text.Split(new string[] { char.ConvertFromUtf32(10) }, StringSplitOptions.None);

			lblSubTile2.Height = lblSubTile2.Text == string.Empty ? 0 : strarr.Length * 20;
			tblLayoutPanel.RowStyles[0].Height = lblSubTile2.Location.Y + lblSubTile2.Height + 3;
		}

        private void AddContextMenu()
        {
            ToolStripMenuItem tsmiSendMail = new ToolStripMenuItem();
            tsmiSendMail.Name = "SendMail";
            tsmiSendMail.Text = "&3. " + Languages.GetLanguage("Send_Mail");
            tsmiSendMail.Click += new EventHandler(tsmiSendMail_Click);

            dgvResult.cmsOption.Items.AddRange(new ToolStripItem[] { tsmiSendMail });
        }

        void tsmiSendMail_Click(object sender, EventArgs e)
        {
            if (dsResult.Tables.Count >= 3 && dsResult.Tables[2].Rows.Count > 0)
            {
                if (iPrintTime <= dsResult.Tables[2].Rows.Count - 1)
                {
                    Report.FillFileReport(repFile, drReport, drFilter, dtDetail, dsResult);
                }
            }
            else
                Report.FillFileReport(repFile, drReport, drFilter, dtDetail, dsResult);

            Report.SendMail(dtDetail, repFile, this.Text);
        }
        public void PreviewReport()
        {
            frmReportPrint frmPrint = new frmReportPrint();
            frmPrint.MdiParent = this.MdiParent;
            frmPrint.columnInfos = dgvResult.ColumnInfos;

            if (dsResult.Tables.Count >= 3 && dsResult.Tables[2].Rows.Count > 0)
            {
                if (iPrintTime <= dsResult.Tables[2].Rows.Count - 1)
                {
					frmPrint.FormClosed += new FormClosedEventHandler(frmPreview_FormClosed);
                    frmPrint.Load(drReport, drFilter, dsResult, true, dsResult.Tables[2].Rows[iPrintTime]);                    
                }
                else
                {
                    frmPrint.FormClosed -= new FormClosedEventHandler(frmPreview_FormClosed);
                    iPrintTime = 0;
                }
            }
            else
                frmPrint.Load(drReport, drFilter, dsResult, true);
        }

        public void Export_Excel()
        {
            if (ExportControl == null)
                return;

            string strSubTitle = string.Empty;

            if (drFilter.Table.Columns.Contains("SubTitle1") && ((string)drFilter["SubTitle1"]) != string.Empty)
                strSubTitle += (string)drFilter["SubTitle1"] + "|";

            if (drFilter.Table.Columns.Contains("SubTitle2") && ((string)drFilter["SubTitle2"]) != string.Empty)
                strSubTitle += (string)drFilter["SubTitle2"] + "|";

            if (drFilter.Table.Columns.Contains("SubTitle3") && ((string)drFilter["SubTitle3"]) != string.Empty)
                strSubTitle += (string)drFilter["SubTitle3"] + "|";

            string strTitle = Element.sysLanguage == enuLanguageType.Vietnamese ? (string)drReport["Title"] : (string)drReport["TitleE"];

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.Commercial;
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            ExcelPackage wBook = new ExcelPackage();
            FolderBrowserDialog ofdlg = new FolderBrowserDialog();
            if (ofdlg.ShowDialog() != DialogResult.OK)
                return;

            string strFileName = ofdlg.SelectedPath + "\\" + strTitle + ".xlsx";
            ExcelWorksheet excel = wBook.Workbook.Worksheets.Add("Sheet1");

            string strValue;

            #region Header

            //Dòng Ten_Dvi
            excel.Cells[1, 1].Value = LinkQ.Systems.Elements.Element.sysTen_Dvi.ToUpper();
            excel.Cells[2, 1].Value = LinkQ.Systems.Elements.Element.sysDia_Chi_Dv;//(string)Parameters.GetParaValue("DIA_CHI");Haids
            excel.Cells[3, 1].Value = strTitle;

            string[] strArrSubTitle = strSubTitle.Split('|');
            int iSubTitleLen = strArrSubTitle.Length;
            for (int j = 0; j < iSubTitleLen; j++) //SubTitle
            {
                excel.Cells[4 + j, 1].Value = strArrSubTitle[j];
            }

            excel.Cells[1, 1].Style.Font.Bold = true;
            excel.Cells[2, 1].Style.Font.Bold = true;
            excel.Cells[3, 1].Style.Font.Bold = true;
            excel.Cells[1, 1].Style.Font.Size = 10;
            excel.Cells[2, 1].Style.Font.Size = 10;
            excel.Cells[3, 1].Style.Font.Size = 18;

            for (int i = 0; i < iSubTitleLen; i++)//SubTitle
            {
                excel.Cells[4 + i, 1].Style.Font.Bold = true;
                excel.Cells[4 + i, 1].Style.Font.Italic = true;
                excel.Cells[4 + i, 1].Style.Font.Size = 10;
            }

            int columnCount = 0;
            DataTable dt;
            if (Common.Inlist(ExportControl.GetType().Name, "tlControl,tlReport"))
            {
                tlControl tl = (tlControl)ExportControl;
                BindingSource bds = (BindingSource)tl.DataSource;

                if (bds.Filter != null && bds.Filter != string.Empty)
                {
                    dt = ((DataTable)bds.DataSource).Clone();
                    DataRow[] arrRow = ((DataTable)bds.DataSource).Select(bds.Filter);
                    foreach (DataRow dr in arrRow)
                        dt.ImportRow(dr);
                }
                else
                    dt = (DataTable)bds.DataSource;

                for (int i = 1; i <= tl.Columns.Count - 1; i++)
                {
                    columnCount++;
                }
            }
            else
            {

                dgvControl dgv = (dgvControl)ExportControl;
                BindingSource bds = (BindingSource)dgv.DataSource;

                if (bds.Filter != null && bds.Filter != string.Empty)
                {
                    dt = ((DataTable)bds.DataSource).Clone();
                    DataRow[] arrRow = ((DataTable)bds.DataSource).Select(bds.Filter);
                    foreach (DataRow dr in arrRow)
                        dt.ImportRow(dr);
                }
                else
                    dt = (DataTable)bds.DataSource;

                for (int i = 0; i <= dt.Columns.Count - 1; i++)
                {
                    DataColumn dc = dt.Columns[i];
                    if (!(dgv.Columns.Contains(dc.ColumnName) && dgv.Columns[dc.ColumnName].Visible && dgv.Columns[dc.ColumnName].Width > 5))
                        continue;

                    columnCount++;
                }
            }

            excel.Cells[1, 1, 1, columnCount].Merge = true;
            excel.Cells[2, 1, 2, columnCount].Merge = true;
            excel.Cells[3, 1, 3, columnCount].Merge = true;

            for (int j = 0; j < iSubTitleLen; j++) //SubTitle
                excel.Cells[4 + j, 1, 4 + j, columnCount].Merge = true;

            excel.Cells[3, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            for (int j = 0; j < iSubTitleLen; j++) //SubTitle
            {
                excel.Cells[4 + j, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            }
            #endregion

            #region tlControl
            if (Common.Inlist(ExportControl.GetType().Name, "tlControl,tlReport"))
            {
                tlControl tl = (tlControl)ExportControl;

                //verfying the datagridview having data or not
                if (((tl.Columns.Count == 0) | (tl.Nodes.Count == 0)))
                {
                    string strMsg = Element.sysLanguage == enuLanguageType.English ? "Have not data to export" : "Không có dữ liệu để kết xuất";
                    Common.MsgCancel(strMsg);
                    return;
                }

                for (int i = 1; i <= tl.Columns.Count - 1; i++)
                {
                    excel.Cells[1, 1, 1, i + 1].Merge = true;
                    excel.Cells[2, 1, 2, i + 1].Merge = true;
                    excel.Cells[3, 1, 3, i + 1].Merge = true;

                    for (int j = 0; j < iSubTitleLen; j++) //SubTitle
                    {
                        excel.Cells[4 + j, 1, 4 + j, i + 1].Merge = true;
                    }
                }

                excel.Cells[3, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                for (int j = 0; j < iSubTitleLen; j++) //SubTitle
                {
                    excel.Cells[4 + j, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }

                //Bắt đầu gán nội dung
                int colIndex = 0;
                int rowIndex = 4 + iSubTitleLen;

                foreach (DevExpress.XtraTreeList.Columns.TreeListColumn tlc in tl.Columns)
                {
                    colIndex = colIndex + 1;
                    excel.Cells[rowIndex, colIndex].Value = tlc.Caption;

                    ExcelRange range = (ExcelRange)excel.Cells[rowIndex, colIndex];

                    range.Style.Font.Bold = true;
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }

                foreach (DataRow dr in dt.Rows)
                {
                    rowIndex = rowIndex + 1;
                    colIndex = 0;

                    foreach (DevExpress.XtraTreeList.Columns.TreeListColumn tlc in tl.Columns)
                    {
                        colIndex = colIndex + 1;

                        if (!tlc.Visible || !dt.Columns.Contains(tlc.FieldName))
                            continue;

                        object objValue = dr[tlc.FieldName];
                        ExcelRange range = (ExcelRange)excel.Cells[rowIndex, colIndex];

                        if (objValue != DBNull.Value && objValue != null)
                        {
                            if (objValue.GetType().Name == "String")
                            {
                                /*if (strDestFont == "T")
                                    strValue = ConvertFont.UnicodeToTCVN3(objValue.ToString()).ToString();
                                else if ((strDestFont == "V"))
                                    strValue = ConvertFont.UNICODEToVNI(objValue.ToString()).ToString();
                                else*/
                                strValue = objValue.ToString();

                                /* if (strValue.Length > 0 && "0123456789".Contains(strValue.Substring(0, 1)))
                                     strValue = "'" + strValue;*/

                                excel.Cells[rowIndex, colIndex].Value = strValue;
                            }
                            else if (objValue.GetType().Name == "DateTime" && objValue != null && objValue != DBNull.Value)
                                excel.Cells[rowIndex, colIndex].Value = /*"'" +*/ Library.DateToStr((DateTime)objValue);
                            else
                                excel.Cells[rowIndex, colIndex].Value = objValue;

                            if (dt.Columns.Contains("Bold") && (bool)dr["Bold"])
                                range.Style.Font.Bold = true;
                        }

                        range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    }
                }
            }
            #endregion

            #region DataGridView
            else
            {
                DataGridView dgv = (DataGridView)ExportControl;

                //verfying the datagridview having data or not
                if (((dgv.Columns.Count == 0) | (dgv.Rows.Count == 0)))
                {
                    string strMsg = Element.sysLanguage == enuLanguageType.English ? "Have not data to export" : "Không có dữ liệu để kết xuất";
                    Common.MsgCancel(strMsg);
                    return;
                }

                //Bắt đầu gán nội dung			
                columnCount = 0;
                int colIndex = 0;
                int rowIndex = 4 + iSubTitleLen;

                //Header
                for (int i = 0; i <= dgv.Columns.Count - 1; i++)
                {
                    if (!(dt.Columns.Contains(dgv.Columns[i].Name) && dgv.Columns[i].Visible && dgv.Columns[i].Width > 5))
                        continue;

                    DataColumn dc = dt.Columns[dgv.Columns[i].Name];

                    columnCount++;
                    excel.Cells[rowIndex, columnCount].Value = dgv.Columns[dc.ColumnName].HeaderText;
                    excel.Cells[rowIndex, columnCount].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }

                #region Ket xuat tu DataTable
                columnCount = 0;
                rowIndex = 5 + iSubTitleLen;

                for (int i = 0; i <= dgv.Columns.Count - 1; i++)
                {
                    if (!((dt.Columns.Contains(dgv.Columns[i].Name)) && dgv.Columns[i].Visible && dgv.Columns[i].Width > 5))
                        continue;

                    DataColumn dc = dt.Columns.Contains(dgv.Columns[i].DataPropertyName) ? dt.Columns[dgv.Columns[i].DataPropertyName] : dt.Columns[dgv.Columns[i].Name];

                    columnCount++;
                    if (dc.DataType.Name == "String")
                        for (int j = 0; j <= dt.Rows.Count - 1; j++)
                        {
                            /*if (strDestFont == "T")
                                strValue = ConvertFont.UnicodeToTCVN3(dt.Rows[j][dc].ToString()).ToString();
                            else if ((strDestFont == "V"))
                                strValue = ConvertFont.UNICODEToVNI(dt.Rows[j][dc].ToString()).ToString();
                            else*/
                            strValue = dt.Rows[j][dc].ToString();

                            /*if (strValue.Length > 0 && "0123456789".Contains(strValue.Substring(0, 1)))
                                strValue = "'" + strValue;*/

                            excel.Cells[j + rowIndex, columnCount].Value = strValue;

                        }
                    else if (dc.DataType.Name == "DateTime")
                        for (int j = 0; j <= dt.Rows.Count - 1; j++)
                        {
                            if (dt.Rows[j][dc] != DBNull.Value && (((DateTime)dt.Rows[j][dc])).ToString("dd/MM/yyyy") != "01/01/1900")
                                excel.Cells[j + rowIndex, columnCount].Value = /*"'" +*/ (((DateTime)dt.Rows[j][dc])).ToString("dd/MM/yyyy");
                        }
                    else
                    {
                        for (int j = 0; j <= dt.Rows.Count - 1; j++)
                            if (!dt.Rows[j][dc].Equals((Decimal)0))
                            {
                                if (dt.Rows[j][dc].GetType().Equals(typeof(Decimal)))
                                    //excel.Cells[j + rowIndex, columnCount] = ((Decimal)dt.Rows[j][dc]).ToString(((DataGridViewTextBoxColumn)dgv.Columns[i]).DefaultCellStyle.Format);
                                    excel.Cells[j + rowIndex, columnCount].Value = (Decimal)dt.Rows[j][dc];
                                else
                                    excel.Cells[j + rowIndex, columnCount].Value = dt.Rows[j][dc];
                            }

                        int iScale = 0;
                        if (dgv.Columns[i].GetType().Name == "dgvNumericColumn")
                            iScale = ((dgvNumericColumn)dgv.Columns[i]).Scale;

                        ExcelRange rangeDecimal = (ExcelRange)excel.Cells[rowIndex, columnCount, rowIndex + dt.Rows.Count - 1, columnCount];
                        rangeDecimal.Style.Numberformat.Format = "#,##0" + (iScale != 0 ? "." + "0".PadLeft(iScale, '0') : string.Empty);
                    }
                }


                ExcelRange range = (ExcelRange)excel.Cells[5 + iSubTitleLen - 1, 1, 5 + iSubTitleLen + dt.Rows.Count - 1, columnCount];
                range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                range.AutoFitColumns();
                //range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                //range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                #endregion

                //Set Bold
                rowIndex = 5 + iSubTitleLen;
                excel.Cells[rowIndex - 1, 1, rowIndex - 1, columnCount].Style.Font.Bold = true;

                if (dt.Columns.Contains("Bold"))
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        if ((bool)dt.Rows[i]["Bold"])
                            excel.Cells[rowIndex + i, 1, rowIndex + i, columnCount].Style.Font.Bold = true;
            }

            #endregion

            //Ghi file lên đĩa
            try
            {
                if (System.IO.File.Exists(strFileName))
                {
                    if (Common.MsgYes_No("File đã tồn tại, có chắc chắn ghi đè file?", "Y"))
                    {
                        System.IO.File.Delete(strFileName);
                    }
                }

                wBook.SaveAs(new FileInfo(strFileName));
            }
            catch (Exception ex)
            {
                Common.MsgCancel("Không thể kết xuất được dữ liệu!");
                return;
            }

            Common.MsgOk("Kết xuất thành công.");

        }

        public void PrintReport()
        {
            frmReportPrint frmPrint = new frmReportPrint();
            frmPrint.MdiParent = this.MdiParent;
            frmPrint.columnInfos = dgvResult.ColumnInfos;

            if (dsResult.Tables.Count >= 3 && dsResult.Tables[2].Rows.Count > 0)
            {
                if (iPrintTime <= dsResult.Tables[2].Rows.Count - 1)
                {
                    frmPrint.Load(drReport, drFilter, dsResult, false, dsResult.Tables[2].Rows[iPrintTime]);
                    frmPrint.FormClosed += new FormClosedEventHandler(frmPrint_FormClosed);
                }
                else
                {
                    frmPrint.FormClosed -= new FormClosedEventHandler(frmPrint_FormClosed);
                    iPrintTime = 0;
                }
            }
            else
                frmPrint.Load(drReport, drFilter, dsResult, false);
        }

        void frmPrint_FormClosed(object sender, FormClosedEventArgs e)
        {
            iPrintTime++;
            PrintReport();
        }

        void frmPreview_FormClosed(object sender, FormClosedEventArgs e)
        {
            iPrintTime++;
            PreviewReport();
        }

        public void DesignReport()
        {
            frmReportDesign frmDesign = new frmReportDesign();
            frmDesign.MdiParent = this.MdiParent;
            frmDesign.Load(drReport, dtDetail);
        }

        public void RunChart()
        {
            if ((bool)drReport["Have_Chart"])
            {
                frmChart frm = new frmChart();
                frm.MdiParent = this.MdiParent;
                frm.Load(drReport, drFilter, dtDetail, dgvResult);
            }
        }

        public void Refresh()
        {
            FillData();
        }

        private void ViewDetail()
        {
            if (bdsResult.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsResult.Current).Row;
            string strReport_ID = (string)drReport["Report_ID"];

            DataTable dtReportDetail = DataTool.SQLGetDataTable("L00ReportDETAIL", "Report_Detail_ID, Condition", "Report_ID = '" + strReport_ID + "'", "");

            if (dtReportDetail.Rows.Count == 0 && (string)drReport["Report_ID_Detail"] != string.Empty)
            {
                strReport_ID = (string)drReport["Report_ID_Detail"];
                dtReportDetail = DataTool.SQLGetDataTable("L00ReportDETAIL", "Report_Detail_ID, Condition", "Report_ID = '" + strReport_ID + "'", "");
            }

            //Nếu không vào chi tiết thì F3 chứng từ gốc
            if (dtReportDetail.Rows.Count == 0)
            {
                this.Edit();
                return;
            }

            string strCondition = string.Empty;
            string strReport_Detail_ID = string.Empty;
            foreach (DataRow dr in dtReportDetail.Rows)
            {
                strCondition = (string)dr["CONDITION"];

                DataTable dtTemp = dtDetail.Clone();
                dtTemp.ImportRow(drCurrent);

                if ((dtTemp.Select(strCondition)).Length == 1)
                {
                    strReport_Detail_ID = (string)dr["Report_Detail_ID"];
                    DataRow drReportDetail = DataTool.SQLGetDataRowByID("L00Report", "Report_ID", strReport_Detail_ID);
                    drReportDetail["Vnd_Nt"] = drReport["Vnd_Nt"];

                    DataRow drReportDetail0 = DataTool.SQLGetDataRowByID("L00ReportDetail", "Report_ID", strReport_Detail_ID);
                    DataRow drFilterDetail = drFilter.Table.NewRow();
                    DataTool.CopyDataRow(drFilter, drFilterDetail);

                    Common.SetDefaultDataRow(ref drReportDetail);
                    Common.SetDefaultDataRow(ref drFilterDetail);

                    //Đưa dữ liệu trên dòng hiện hành vào Filter
                    foreach (DataColumn dc in drFilterDetail.Table.Columns)
                    {
                        if (dc.DataType == typeof(string) && drCurrent.Table.Columns.Contains(dc.ColumnName))
                            if (drCurrent.Table.Columns[dc.ColumnName].DataType == typeof(string))
                                drFilterDetail[dc.ColumnName] = (string)drCurrent[dc.ColumnName];
                    }

                    drFilterDetail["Title"] = Report.GetTitle(drReportDetail);
                    drFilterDetail["SubTitle1"] = Report.GetSubTitle1(drReportDetail, drFilterDetail);
                    drFilterDetail["SubTitle2"] = Report.GetSubTitle2(drReportDetail, drFilterDetail);

                    string strCurentColumn = string.Empty;
                    if (dgvResult.CurrentCell != null)
                        strCurentColumn = dgvResult.CurrentCell.OwningColumn.Name;

                    if (!drFilterDetail.Table.Columns.Contains("CURRENT_COLUMN"))
                        drFilterDetail.Table.Columns.Add("CURRENT_COLUMN", typeof(string));

                    drFilterDetail["CURRENT_COLUMN"] = strCurentColumn;

                    Report.ViewDetail(drReportDetail, drFilterDetail, drCurrent, this.MdiParent);
                }
            }
        }

        public void Edit()
        {
            if (bdsResult.Position < 0)
                return;

            if (!dtDetail.Columns.Contains("Stt") || !dtDetail.Columns.Contains("Ma_Ct"))
                return;

            DataRow drCurrent = ((DataRowView)bdsResult.Current).Row;

            if (((string)drCurrent["Stt"]).Trim() == string.Empty || ((string)drCurrent["Ma_Ct"]).Trim() == string.Empty)
                return;

            DataRow drDmCt = DataTool.SQLGetDataRowByID("L00DMCT", "Ma_Ct", (string)drCurrent["Ma_Ct"]);

            string strObject_Id = drDmCt["Object_Id"].ToString();

            if (!Common.CheckPermission(strObject_Id, enuPermission_Type.Allow_Access))
            {
                MessageBox.Show("Ban không được quyền truy cập");
                return;
            }
            string strMethodName = (string)drDmCt["Edit_Voucher_Method"];

            string[] arrStr = strMethodName.Split(':');
            if (arrStr.Length != 3)
            {
                Common.MsgCancel("Định dạng MethodName = " + strMethodName + " không đúng");
                return;
            }

            string strAssembly = string.Empty;
            string strType = string.Empty;

            strAssembly = arrStr[0];
            strType = "LinkQ." + arrStr[1];

            Assembly asl = Assembly.Load(strAssembly);
            Type type = asl.GetType(strType);

            Form frm = (Form)Activator.CreateInstance(type);

            object[] objPara = new object[] { enuEdit.Edit, drCurrent, null };

            type.InvokeMember(arrStr[2], BindingFlags.InvokeMethod, null, frm, objPara);
        }

        public void EditHanTt()
        {
            if (bdsResult.Count <= 0)
                return;

            string strStt = string.Empty;
            string strTk = string.Empty;
            string strMa_Dt = string.Empty;
            DateTime dtNgay_Ct = DateTime.MinValue;

            DataRow drCurrent = ((DataRowView)bdsResult.Current).Row;

            if (!dtDetail.Columns.Contains("Stt") || (string)drCurrent["Stt"] == string.Empty)
                return;

            strStt = (string)drCurrent["Stt"];

            if (!dtDetail.Columns.Contains("Tk") || (string)drCurrent["Tk"] == string.Empty)
                return;

            strTk = (string)drCurrent["Tk"];
            string strTkCongNoList = (string)Parameters.GetParaValue("TK_CONGNO_LIST");
            strTkCongNoList = strTkCongNoList.Trim();

            if (!Common.InlistLike(strTk, strTkCongNoList))
                return;

            if (dtDetail.Columns.Contains("Ma_Dt"))
                strMa_Dt = (string)drCurrent["Ma_Dt"];

            if (dtDetail.Columns.Contains("Ngay_Ct"))
                dtNgay_Ct = (DateTime)drCurrent["Ngay_Ct"];

            string strAssembly = "LinkQ.Modules7.0";
            string strType = "LinkQ.Modules.frmHanTt_View";

            Assembly asl = Assembly.Load(strAssembly);
            Type type = asl.GetType(strType);

            Form frm = (Form)Activator.CreateInstance(type);
            frm.MdiParent = this.MdiParent;

            object[] objPara = new object[] { dtNgay_Ct, strTk, strMa_Dt, strStt, "" };

            type.InvokeMember("Load", BindingFlags.InvokeMethod, null, frm, objPara);
        }

        public void Export() //Phục vụ cho việc gọi Assemply từ ToolStrip
        {
            if (ExportControl == null)
                return;

            string strSubtitle = string.Empty;

            if (drFilter.Table.Columns.Contains("SubTitle1") && ((string)drFilter["SubTitle1"]) != string.Empty)
                strSubtitle += (string)drFilter["SubTitle1"] + "|";

            if (drFilter.Table.Columns.Contains("SubTitle2") && ((string)drFilter["SubTitle2"]) != string.Empty)
                strSubtitle += (string)drFilter["SubTitle2"] + "|";

            if (drFilter.Table.Columns.Contains("SubTitle3") && ((string)drFilter["SubTitle3"]) != string.Empty)
                strSubtitle += (string)drFilter["SubTitle3"] + "|";

            string strTitle = Element.sysLanguage == enuLanguageType.Vietnamese ? (string)drReport["Title"] : (string)drReport["TitleE"];
            //Common.Export(ExportControl, strTitle, strSubtitle);
            Common.Export(ExportControl, strTitle, strSubtitle, drReport["Report_ID"].ToString(), drFilter);
        }

		public void SetVisibleTitle()
		{
			if (tblLayoutPanel.RowStyles[0].Height == 0)
				tblLayoutPanel.RowStyles[0].Height = lblSubTile2.Location.Y + lblSubTile2.Height + 3;
			else
				tblLayoutPanel.RowStyles[0].Height = 0;
		}

        #endregion

        #region Event

        void frmResult_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F3:
                    Edit();
                    break;
				case Keys.F4:
					SetVisibleTitle();
					break;
                case Keys.F9:
                    object obj = Parameters.GetParaValue("FILE_BHXH");
                    if (obj != null)
                        Report.WriteToExcel(dtDetail, "", Application.StartupPath + @"\Template\" + obj.ToString(), "");
                    else
                        Report.WriteToExcel(dtDetail, "", @"e:\01.Source Control\LinkQ\Template\03a-TBH_Tem.xls", "");
                    break;
                case Keys.F10:
                    RunChart();
                    break;

                case Keys.F11:
                    EditHanTt();
                    break;

                case Keys.F12:
                    if (e.Control)
                    {
                        frmView frm = new frmView();
                        frm.WindowState = FormWindowState.Maximized;
                        frm.MdiParent = this.MdiParent;

                        DataGridView dgvShowAll = new DataGridView();
                        dgvShowAll.Dock = DockStyle.Fill;
                        frm.Controls.Add(dgvShowAll);

                        dgvShowAll.DataSource = dtDetail;

                        foreach (DataGridViewColumn dgvc in dgvShowAll.Columns)
                        {
                            if (dgvc.ValueType == typeof(System.Byte[]))
                                dgvc.Visible = false;
                        }

                        frm.Show();
                    }
                    else //Vào chi tiết
                    {
                        ViewDetail();
                    }

                    break;

                case Keys.Escape:
                    this.Close();
                    break;

                case Keys.F7:
                    switch (e.Modifiers)
                    {
                        case Keys.Shift:
							if (!Element.sysIs_Admin && Common.CheckPermission("DENY_EDITREPORT", enuPermission_Type.Allow_Access))
							{
								Common.MsgCancel(Element.sysLanguage == enuLanguageType.Vietnamese ? "Bạn không có quyền sửa mẫu báo cáo" : "You do not have permission to design report");
								return;
							}
                            DesignReport();
                            break;

                        case Keys.Control:
							if (!Element.sysIs_Admin && Common.CheckPermission("DENY_PRINTREPORT", enuPermission_Type.Allow_Access))
							{
								Common.MsgCancel(Element.sysLanguage == enuLanguageType.Vietnamese ? "Bạn không có quyền xem báo cáo" : "You do not have permission to preview report");
								return;
							}

                            PreviewReport();
                            break;

                        case Keys.None:
							if (!Element.sysIs_Admin && Common.CheckPermission("DENY_PRINTREPORT", enuPermission_Type.Allow_Access))
							{
								Common.MsgCancel(Element.sysLanguage == enuLanguageType.Vietnamese ? "Bạn không có quyền in báo cáo" : "You do not have permission to print report");
								return;
							}
                            PrintReport();
                            break;
                    }

                    break;

                case Keys.F:
                    if (e.Control)
                    {
                        frmsearch.iCurrentPotition = frmsearch.bdsSearch.Position;
                        frmsearch.Show(this);
                    }
                    break;

                case Keys.G:
                    if (e.Control)
                    {
                        frmsearch.GoNext();
                    }
                    break;
                case Keys.F6:
                    frmReportFilter frmFilter = new frmReportFilter();
                    frmFilter.Load(drReport, drFilter);

					if (!drFilter.Table.Columns.Contains("Title"))
		                drFilter.Table.Columns.Add(new DataColumn("Title", typeof(string)));

					if (!drFilter.Table.Columns.Contains("SubTitle1"))
						drFilter.Table.Columns.Add(new DataColumn("SubTitle1", typeof(string)));

					if (!drFilter.Table.Columns.Contains("SubTitle2"))
						drFilter.Table.Columns.Add(new DataColumn("SubTitle2", typeof(string)));

					drFilter["Title"] = Report.GetTitle(drFilter);
					drFilter["SubTitle1"] = Report.GetSubTitle1(drReport, drFilter);

					drFilter["SubTitle2"] = Report.GetSubTitle2(drReport, drFilter);

                    if (frmFilter.isAccept)
                        this.FillData();

                    break;

                case Keys.F2:
                    Export_Excel();
                    break;
            }
        }

        void dgvResult_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ViewDetail();
        }

        void tlResult_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ViewDetail();
        }

        protected override void OnEnter(EventArgs e)
        {
            if (this.MdiParent != null && this.MdiParent.IsMdiContainer)
            {
                ((LinkQ.Systems.Customizes.frmMain)this.MdiParent).tsView.Visible = true;
                ((LinkQ.Systems.Customizes.frmMain)this.MdiParent).tsReport.Visible = true;
            }

            else if (this.FindForm().Parent != null && this.FindForm().Parent.Parent != null && this.FindForm().Parent.Parent.FindForm().GetType().Name == "frmMain")
            {
                LinkQ.Systems.Customizes.frmMain frm = (LinkQ.Systems.Customizes.frmMain)this.FindForm().Parent.Parent.FindForm();
                frm.tsView.Visible = true;
                frm.tsReport.Visible = true;
            }

            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            if (this.MdiParent != null && this.MdiParent.IsMdiContainer)
            {
                ((LinkQ.Systems.Customizes.frmMain)this.MdiParent).tsView.Visible = false;
                ((LinkQ.Systems.Customizes.frmMain)this.MdiParent).tsReport.Visible = false;
            }

            else if (this.FindForm().Parent != null && this.FindForm().Parent.Parent != null && this.FindForm().Parent.Parent.FindForm().GetType().Name == "frmMain")
            {
                LinkQ.Systems.Customizes.frmMain frm = (LinkQ.Systems.Customizes.frmMain)this.FindForm().Parent.Parent.FindForm();
                frm.tsView.Visible = false;
                frm.tsReport.Visible = false;
            }

            base.OnLeave(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (this.MdiParent != null && this.MdiParent.IsMdiContainer)
            {
                ((LinkQ.Systems.Customizes.frmMain)this.MdiParent).tsView.Visible = false;
                ((LinkQ.Systems.Customizes.frmMain)this.MdiParent).tsReport.Visible = false;
            }

            else if (this.FindForm().Parent != null && this.FindForm().Parent.Parent != null && this.FindForm().Parent.Parent.FindForm().GetType().Name == "frmMain")
            {
                LinkQ.Systems.Customizes.frmMain frm = (LinkQ.Systems.Customizes.frmMain)this.FindForm().Parent.Parent.FindForm();
                frm.tsView.Visible = false;
                frm.tsReport.Visible = false;
            }

            if (this.Parent != null && this.Parent.GetType().Name == "DockContent")
            {
                WeifenLuo.WinFormsUI.Docking.DockContent dockContent = (WeifenLuo.WinFormsUI.Docking.DockContent)this.Parent;
                int iIndex = frmMain.GetfrmMain().dockPanel.ActiveDocumentPane.Contents.IndexOf(dockContent);
                if (iIndex >= 1)
                    ((WeifenLuo.WinFormsUI.Docking.DockContent)frmMain.GetfrmMain().dockPanel.ActiveDocumentPane.Contents[iIndex - 1]).Activate();

            }

            base.OnClosing(e);
        }

        #endregion
    }
}