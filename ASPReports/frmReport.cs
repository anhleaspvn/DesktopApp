using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LinkQ.Systems;
using LinkQ.Systems.Data;
using LinkQ.Systems.Controls;
using LinkQ.Systems.Elements;
using LinkQ.Systems.Librarys;
using LinkQ.Systems.Customizes;
using LinkQ.Systems.Commons;

namespace LinkQ.Reports
{
    public partial class frmReport : LinkQ.Systems.Controls.frmBase
    {
        #region Fields

        private int iMenu_ID;
        public BindingSource bdsReport = new BindingSource();
        public DataTable dtReport;
        public DataRow drCurrent;

        #endregion

        #region Method

        public frmReport()
        {
            InitializeComponent();


            tvReport.KeyDown += new KeyEventHandler(tvReport_KeyDown);
            tvReport.DoubleClick += new EventHandler(tvReport_DoubleClick);
            tvReport.AfterExpand += new TreeViewEventHandler(tvReport_AfterExpand);
            tvReport.AfterCollapse += new TreeViewEventHandler(tvReport_AfterCollapse);

            //tvReport.NodeMouseClick += new TreeNodeMouseClickEventHandler(tvReport_NodeMouseClick);
            tvReport.AfterSelect += new TreeViewEventHandler(tvReport_AfterSelect);


            btRun.Click += new EventHandler(btAccept_Click);
            btExit.Click += new EventHandler(btCancel_Click);
            btFormula.Click += new EventHandler(btFormula_Click);

            chkPrint_Sign.CheckedChanged += new EventHandler(chkPrint_Sign_CheckedChanged);
            bdsReport.PositionChanged += new EventHandler(bdsReport_PositionChanged);

            rdbIs_Vnd.CheckedChanged += new EventHandler(rdbIs_Vnd_Nt_CheckedChanged);
            rdbIs_Nt.CheckedChanged += new EventHandler(rdbIs_Vnd_Nt_CheckedChanged);
            rdbIs_Vnd_Nt.CheckedChanged += new EventHandler(rdbIs_Vnd_Nt_CheckedChanged);
        }

        public new void Load(int iMenu_ID)
        {
            this.iMenu_ID = iMenu_ID;

            //Thêm cột dữ liệu phục vụ cho chart
            string strSQLExec =
                "IF COL_LENGTH('L00Report', 'Have_Chart') IS NULL " +
                "	ALTER TABLE L00Report ADD Have_Chart BIT NOT NULL DEFAULT(0) " +
                "IF COL_LENGTH('L00Report', 'SeriesList') IS NULL " +
                "	ALTER TABLE L00Report ADD SeriesList VARCHAR(100) NOT NULL DEFAULT('') " +
                "IF COL_LENGTH('L00Report', 'ColX') IS NULL " +
                "	ALTER TABLE L00Report ADD ColX VARCHAR(50) NOT NULL DEFAULT('') " +
                "IF COL_LENGTH('L00Report', 'ColY') IS NULL " +
                "	ALTER TABLE L00Report ADD ColY VARCHAR(50) NOT NULL DEFAULT('') " +
                "IF COL_LENGTH('L00Report', 'Vnd_Nt') IS NULL " +
                "	ALTER TABLE L00Report ADD Vnd_Nt CHAR(1) NOT NULL DEFAULT('0') ";
            SQLExec.Execute(strSQLExec);

            this.Build();
            this.FillData();
            this.DataBinding();
            this.BindingLanguage();

            if (Element.sysLanguage == enuLanguageType.Vietnamese)
                rdbVietnamese.Checked = true;
            else if (Element.sysLanguage == enuLanguageType.English)
                rdbEnglish.Checked = true;
            else
                rdbOther.Checked = true;

            this.Show();
        }

        private void Build()
        {
            if (Element.sysLanguage == enuLanguageType.Vietnamese)
                tvReport.DisplayFieldName = "Report_Name";
            else if (Element.sysLanguage == enuLanguageType.English)
                tvReport.DisplayFieldName = "Report_NameE";
            else
                tvReport.DisplayFieldName = "Report_NameO";
            //tvReport.DisplayFieldName = Element.sysLanguage == enuLanguageType.Vietnamese ? "Report_Name" : "Report_NameE";
            tvReport.KeyFieldName = "Report_Id";
            tvReport.ParentFieldName = "Report_Parent";
            tvReport.ImageList = imglTree;
            tvReport.ImageIndex = 0;
            tvReport.SelectedImageIndex = 1;
        }

        private void FillData()
        {
            string strKey = "Report_ID IN (SELECT Report_ID FROM L00MENU_REPORT WHERE Menu_ID = " + iMenu_ID.ToString() + ")";

            dtReport = DataTool.SQLGetDataTable("L00Report", "", strKey, "Stt");

            tvReport.VietNameseFieldName = "Report_Name";
            tvReport.EngLishFieldName = "Report_NameE";
            tvReport.OtherFieldName = "Report_NameO";

            bdsReport.DataSource = dtReport;
            tvReport.DataSource = bdsReport;
            tvReport.ImageList = imglTree;
        }

        private void DataBinding()
        {
            chkPrint_Sign.DataBindings.Add("Checked", bdsReport, "Print_Sign");
            //rdbIs_Nt.DataBindings.Add("UnChecked", bdsReport, "Is_Vnd");
            //rdbIs_Vnd.DataBindings.Add("Checked", bdsReport, "Is_Vnd");

            if (Element.sysLanguage == enuLanguageType.Vietnamese)
            {
                txtSign1.DataBindings.Add("Text", bdsReport, "Sign1");
                txtSign2.DataBindings.Add("Text", bdsReport, "Sign2");
                txtSign3.DataBindings.Add("Text", bdsReport, "Sign3");
            }
            else if (Element.sysLanguage == enuLanguageType.English)
            {
                txtSign1.DataBindings.Add("Text", bdsReport, "SignE1");
                txtSign2.DataBindings.Add("Text", bdsReport, "SignE2");
                txtSign3.DataBindings.Add("Text", bdsReport, "SignE3");
            }
            else
            {
                txtSign1.DataBindings.Add("Text", bdsReport, "SignO1");
                txtSign2.DataBindings.Add("Text", bdsReport, "SignO2");
                txtSign3.DataBindings.Add("Text", bdsReport, "SignO3"); 
            }

            txtName1.DataBindings.Add("Text", bdsReport, "Name1");
            txtName2.DataBindings.Add("Text", bdsReport, "Name2");
            txtName3.DataBindings.Add("Text", bdsReport, "Name3");

        }

        public string strVnd_Nt
        {
            get
            {
                if (rdbIs_Vnd.Checked)
                    return "0";
                else if (rdbIs_Nt.Checked)
                    return "1";
                else
                    return "2";
            }
        }

        private void SetVnd_Nt()
        {
            string strVnd_Nt = (string)((DataRowView)bdsReport.Current).Row["Vnd_Nt"];

            if (strVnd_Nt == "0")
                rdbIs_Vnd.Checked = true;
            else if (strVnd_Nt == "1")
                rdbIs_Nt.Checked = true;
            else if (strVnd_Nt == "2")
                rdbIs_Vnd_Nt.Checked = true;
        }

        private void RunReport()
        {
            if (rdbVietnamese.Checked)
                Report.LanguageType = enuLanguageType.Vietnamese;
            else if (rdbEnglish.Checked)
                Report.LanguageType = enuLanguageType.English;
            else
                Report.LanguageType = enuLanguageType.Other;

            Report.PrintType = PrintType.PrintReport;

            bool bHave_Children;
            bHave_Children = (string)((DataRowView)bdsReport.Current).Row["SQLProc"] == string.Empty ? true : false;

            if (bHave_Children)
                if (tvReport.SelectedNode.IsExpanded)
                    tvReport.SelectedNode.Collapse();
                else
                    tvReport.SelectedNode.Expand();
            else
                Report.RunReport(this);
        }

        #endregion

        #region Event

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Tab:
                    switch (this.ActiveControl.Name)
                    {
                        case "tvReport":
                            pnlRunReport.Focus();
                            break;

                        case "pnlRunReport":
                            grbLoai_Tien.Focus();
                            break;

                        case "grbLoai_Tien":
                            grbPrint_Sign.Focus();
                            break;

                        default:
                            tvReport.Focus();
                            break;
                    }
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        void tvReport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                if (this.bdsReport.Current == null || this.bdsReport.Position < 0)
                    return;

                DataRow drReport = ((DataRowView)this.bdsReport.Current).Row;

                frmReport_Edit frmEdit = new frmReport_Edit();
                frmEdit.Load(enuEdit.Edit, drReport);

                if (frmEdit.isAccept)
                {
                    dtReport.AcceptChanges();

                    this.SetVnd_Nt();
                }
                else
                    dtReport.RejectChanges();
            }
        }

        void tvReport_DoubleClick(object sender, EventArgs e)
        {
            bool bHave_Children;
            bHave_Children = (string)((DataRowView)bdsReport.Current).Row["SQLProc"] == string.Empty ? true : false;

            if (!bHave_Children)
                Report.RunReport(this);
        }

        void chkPrint_Sign_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPrint_Sign.Checked == true)
            {
                grbPrint_Sign.Enabled = true;
            }
            else
            {
                grbPrint_Sign.Enabled = false;
            }
        }

        void btAccept_Click(object sender, EventArgs e)
        {
            this.RunReport();
        }

        void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btFormula_Click(object sender, EventArgs e)
        {
            drCurrent = ((DataRowView)bdsReport.Current).Row;

            string strTable_Formula = (string)drCurrent["Table_Formula"];

            if (strTable_Formula != string.Empty)
            {
                frmReportFormula frmFormula = new frmReportFormula();
                frmFormula.MdiParent = this.MdiParent;
                frmFormula.Load(strTable_Formula);
            }
        }

        void bdsReport_PositionChanged(object sender, EventArgs e)
        {
            this.SetVnd_Nt();
        }

        void rdbIs_Vnd_Nt_CheckedChanged(object sender, EventArgs e)
        {
            ((DataRowView)bdsReport.Current).Row["Vnd_Nt"] = strVnd_Nt;
        }

        void tvReport_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            DataRow drCurrent = ((DataRowView)bdsReport.Current).Row;

            if ((string)drCurrent["Picture"] != string.Empty)
            {
                picReport.Image = Image.FromFile(@"ImageReports\" + (string)drCurrent["Picture"]);
            }
            else
                picReport.Image = null;

            //if (e.Node.Name == "TCC01")
            //{
            //    picReport.Image = Image.FromFile(@"C:\Users\Haids\Documents\Soquytienmat.png");                
            //}
            //if (e.Node.Name == "TCC02")
            //{
            //    picReport.Image = Image.FromFile(@"C:\Users\Haids\Documents\Sotienguinganhang.png");
            //}
        }

        void tvReport_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DataRow drCurrent = ((DataRowView)bdsReport.Current).Row;

            if ((string)drCurrent["Picture"] != string.Empty && File.Exists(@"ImageReports\" + (string)drCurrent["Picture"]))
            {
                picReport.Image = Image.FromFile(@"ImageReports\" + (string)drCurrent["Picture"]);
            }
            else
                picReport.Image = null;
        }

        void tvReport_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageIndex = 0;
            e.Node.SelectedImageIndex = 1;
        }

        void tvReport_AfterExpand(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageIndex = 2;
            e.Node.SelectedImageIndex = 3;
        }

        #endregion

    }
}