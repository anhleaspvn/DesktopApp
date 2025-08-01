using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Design;
using DataDynamics.ActiveReports.Design.Toolbox;

using LinkQ.Systems.Data;
using LinkQ.Systems.Commons;
using LinkQ.Systems.Librarys;

namespace LinkQ.Reports
{
	public partial class frmReportDesign : LinkQ.Systems.Controls.frmBase
	{
		private DataRow drReport;
		private DataTable dtResult;
		private string strReportFile = string.Empty;
        private string strFileName = string.Empty;

		public frmReportDesign()
		{
			InitializeComponent();

			arDesigner.SelectionChanged += new SelectionChangedEventHandler(arDesigner_SelectionChanged);
			arDesigner.LayoutChanged += new LayoutChangedEventHandler(arDesigner_LayoutChanged);

			this.KeyDown += new KeyEventHandler(frmReportDesign_KeyDown);


			arDesigner.SetLicense("RGN,RGN Warez Group,DD-APN-30-C01339,W44SSM949SWJ449HSHMF");
			InitDesignReport();
		}

		new public void Load(DataRow drReport, DataTable dtResult)
		{
			this.drReport = drReport;
			this.dtResult = dtResult;

			this.strFileName = (string)drReport["Vnd_Nt"] == "2" ? (string)drReport["REPORT_FILE"] + "_NT" : (string)drReport["REPORT_FILE"];
			this.LoadReport(strFileName);

			this.Show();
		}

		public void Load(string strFileName)
		{
			this.LoadReport(strFileName);

			Show();
		}

		void InitDesignReport()
		{
			this.arDesigner.Toolbox = this.arToolbox;
			this.arReportExplorer.Report = arDesigner.Report;

			//Add Menu and CommandBar to Form
			this.commandBarManager = this.arDesigner.CommandBarManager;

			this.Controls.Add(this.commandBarManager);

			CommandBarMenu menu = this.commandBarManager.CommandBars[0].Items[0] as CommandBarMenu;

			//Chuyển Save thành Save As
			menu.Items[2].Text = "Save &As";

			//Thêm nút Save 
			CommandBarButton cmbb = new CommandBarButton();
			cmbb.Text = "&Save";
			cmbb.Click += new CommandEventHandler(Save_Click);
			menu.Items.Insert(3, cmbb);

			//Nút Exit
			menu.Items.AddSeparator();
			menu.Items.AddButton("Exit", new CommandEventHandler(OnExit), 0);

			//View
			CommandBarMenu cmbm = new CommandBarMenu("View", 0);
			cmbm.Items.AddButton("Toolbox", new CommandEventHandler(Toolbox_OnClick), 1);			
			this.commandBarManager.CommandBars[0].Items.Add(cmbm);

			//Fill Toolbox
			LoadTools(this.arToolbox);
			// Activate default group on the toolbox
			this.arToolbox.SelectedCategory = "ActiveReports 3.0";

			//Setup Status Bar
			this.arStatus.Panels.Add(new StatusBarPanel());
			this.arStatus.Panels.Add(new StatusBarPanel());
			this.arStatus.Panels[0].AutoSize = StatusBarPanelAutoSize.Spring;
			this.arStatus.Panels[1].AutoSize = StatusBarPanelAutoSize.Spring;
			this.arStatus.ShowPanels = true;
		}

		public void LoadReport(string strFileName)
		{
            this.strFileName = strFileName += ".rpx";

            if (LinkQ.Systems.Elements.Collection.Parameters.ContainsKey("REPORT_ONLINE") && LinkQ.Systems.Elements.Collection.Parameters["REPORT_ONLINE"].Equals("1"))
            {
                object objFile_Data = SQLExec.ExecuteReturnValue("SELECT File_Data FROM L00DMFILE WHERE File_Name = '" + strFileName + "'");

                byte[] buff = (byte[])objFile_Data;

                Stream stream = new MemoryStream(buff);

                arDesigner.LoadReport(stream);
            }
            else
            {

                strReportFile = Application.StartupPath + @"\Reports\" + strFileName;

                if (strFileName == string.Empty || !File.Exists(strReportFile))
                {
                    Common.MsgOk("Không có tập tin report: " + strFileName);
                    return;
                }

                arDesigner.LoadReport(strReportFile);
            }

			this.Text = this.Text + " - " + strFileName;
		}

		private void LoadTools(DataDynamics.ActiveReports.Design.Toolbox.Toolbox toolbox)
		{
			//Add Data Providers
			toolbox.AddToolboxItem(new System.Drawing.Design.ToolboxItem(typeof(System.Data.DataSet)), "Data");
			toolbox.AddToolboxItem(new System.Drawing.Design.ToolboxItem(typeof(System.Data.DataView)), "Data");
			toolbox.AddToolboxItem(new System.Drawing.Design.ToolboxItem(typeof(System.Data.OleDb.OleDbConnection)), "Data");
			toolbox.AddToolboxItem(new System.Drawing.Design.ToolboxItem(typeof(System.Data.OleDb.OleDbDataAdapter)), "Data");
			toolbox.AddToolboxItem(new System.Drawing.Design.ToolboxItem(typeof(System.Data.Odbc.OdbcConnection)), "Data");
			toolbox.AddToolboxItem(new System.Drawing.Design.ToolboxItem(typeof(System.Data.Odbc.OdbcDataAdapter)), "Data");
			toolbox.AddToolboxItem(new System.Drawing.Design.ToolboxItem(typeof(System.Data.SqlClient.SqlConnection)), "Data");
			toolbox.AddToolboxItem(new System.Drawing.Design.ToolboxItem(typeof(System.Data.SqlClient.SqlDataAdapter)), "Data");
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (this.arDesigner.CommandBarManager.PreProcessMessage(ref msg))
				return true;

			return base.ProcessCmdKey(ref msg, keyData);
		}

		#region Event

		private void arDesigner_LayoutChanged(object sender, DataDynamics.ActiveReports.Design.LayoutChangedArgs e)
		{
			switch (e.Type)
			{
				case LayoutChangeType.ReportLoad:
				case LayoutChangeType.ReportClear:
					this.arReportExplorer.Report = this.arDesigner.Report;
					break;
				default:
					break;
			}
		}

		private void arDesigner_SelectionChanged()
		{
			string curSelection = "";
			IEnumerator selectionEnum = null;
			if (arDesigner.Selection != null)
				selectionEnum = arDesigner.Selection.GetEnumerator();
			while (selectionEnum != null && selectionEnum.MoveNext())
			{
				if (selectionEnum.Current is Section)
					curSelection = curSelection + (selectionEnum.Current as Section).Name + ", ";
				if (selectionEnum.Current is ARControl)
					curSelection = curSelection + (selectionEnum.Current as ARControl).Name + ", ";
				if (selectionEnum.Current is Field)
					curSelection = curSelection + (selectionEnum.Current as Field).Name + ", ";
				if (selectionEnum.Current is Parameter)
					curSelection = curSelection + (selectionEnum.Current as Parameter).Key + ", ";
				if (selectionEnum.Current is ActiveReport3)
					curSelection = curSelection + (selectionEnum.Current as ActiveReport3).Document.Name + ", ";
			}
			if (this.arStatus.Created && this.arStatus.Panels[1] != null)
			{
				if (curSelection != "")
					this.arStatus.Panels[1].Text = "Current Selection: " + curSelection.Substring(0, curSelection.Length - 2);
				else
					this.arStatus.Panels[1].Text = "No Selection";
			}
		}

        void Save_Click(object sender, CommandEventArgs e)
        {
            arDesigner.SetLicense("RGN,RGN Warez Group,DD-APN-30-C01339,W44SSM949SWJ449HSHMF");

            if (LinkQ.Systems.Elements.Collection.Parameters.ContainsKey("REPORT_ONLINE") && LinkQ.Systems.Elements.Collection.Parameters["REPORT_ONLINE"].Equals("1"))
            {
                Stream stream = new MemoryStream();

                arDesigner.SaveReport(stream);
                byte[] buff = ((MemoryStream)stream).ToArray();

                Hashtable ht = new Hashtable();
                ht["FILE_DATA"] = buff;

                SQLExec.Execute("UPDATE L00DMFILE SET File_Data = @File_Data WHERE File_Name = '" + strFileName + "'", ht, CommandType.Text);
            }
            else
                arDesigner.SaveReport(strReportFile);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            if (!strReportFile.EndsWith(@"\.rpx"))
            {
                DialogResult dlgResult = MessageBox.Show("Bạn có muốn lưu " + strReportFile + " không ?", "", MessageBoxButtons.YesNoCancel);

                if (dlgResult == System.Windows.Forms.DialogResult.Yes)
                {
                    arDesigner.SetLicense("RGN,RGN Warez Group,DD-APN-30-C01339,W44SSM949SWJ449HSHMF");

                    if (LinkQ.Systems.Elements.Collection.Parameters.ContainsKey("REPORT_ONLINE") && LinkQ.Systems.Elements.Collection.Parameters["REPORT_ONLINE"].Equals("1"))
                    {
                        Stream stream = new MemoryStream();

                        arDesigner.SaveReport(stream);
                        byte[] buff = ((MemoryStream)stream).ToArray();

                        Hashtable ht = new Hashtable();
                        ht["FILE_DATA"] = buff;

                        SQLExec.Execute("UPDATE L00DMFILE SET File_Data = @File_Data WHERE File_Name = '" + strFileName + "'", ht, CommandType.Text);
                    }
                    else
                        arDesigner.SaveReport(strReportFile);
                }
                else if (dlgResult == System.Windows.Forms.DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);

            //if (!strReportFile.EndsWith(@"\.rpx"))
            //    if (Common.MsgYes_No(Languages.GetLanguage("Doyouwant") + " " + Languages.GetLanguage("Save") + " " + strReportFile))
            //    {
            //        arDesigner.SetLicense("RGN,RGN Warez Group,DD-APN-30-C01339,W44SSM949SWJ449HSHMF");
            //        arDesigner.SaveReport(strReportFile);
            //    }

			if (LinkQ.Systems.Elements.Element.frmActiveMain != null)
			{
				LinkQ.Systems.Elements.Element.frmActiveMain.Activate();
			}
		}

		private void OnExit(object sender, CommandEventArgs e)
		{
			this.Close();
		}

		private void Toolbox_OnClick(object sender, CommandEventArgs e)
		{
			splitContainer.Panel1Collapsed = !splitContainer.Panel1Collapsed;
		}
		void frmReportDesign_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Escape:
					this.Close();
					break;
				case Keys.F4:
					splitContainer.Panel1Collapsed = !splitContainer.Panel1Collapsed;
					break;
				default:
					break;
			}
		}

		#endregion
		
	}
}