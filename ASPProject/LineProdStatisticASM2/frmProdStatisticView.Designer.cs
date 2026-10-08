namespace ASPProject.LineProdStatisticASM2
{
    partial class frmProdStatisticView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProdStatisticView));
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gridProdStat = new DevExpress.XtraGrid.GridControl();
            this.gridProdStatView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colQRStart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFieldID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLineID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDocDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatisticDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProdBeginDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProdShift = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWODocNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGWODocNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProdReqQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProdStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProdStatisticQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProdStatisticEmpQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProdWorktime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProdReworkTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProdSortTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SubJobHC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSumPrevFQCDFQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSumFQCDFQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSumFQCReworkQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSumFQCScrapQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOutputRateDG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOutputRateVN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimeDG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimeVN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductivity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYTDProductivity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYieldProdQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabPageProdStatDetail = new DevExpress.XtraTab.XtraTabControl();
            this.tabEmpStat = new DevExpress.XtraTab.XtraTabPage();
            this.gridEmpStat = new DevExpress.XtraGrid.GridControl();
            this.gridEmpStatView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmpID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpPosition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsDirect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLine = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpLine = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpWorktime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpOvertime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpRework = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpSorting = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpOverRework = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpOverSorting = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExLosstimeHC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExLosstimeTC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubJobHC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubJobTC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeneralEmpWorktime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeneralEmpOvertime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimekeepHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimekeepID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimeDifference = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabDFStat = new DevExpress.XtraTab.XtraTabPage();
            this.gridDFStat = new DevExpress.XtraGrid.GridControl();
            this.gridDFStatView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDFGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDFID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDFName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFQCScrapQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabA = new DevExpress.XtraTab.XtraTabPage();
            this.gridA = new DevExpress.XtraGrid.GridControl();
            this.gridAView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView8 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabP = new DevExpress.XtraTab.XtraTabPage();
            this.gridP = new DevExpress.XtraGrid.GridControl();
            this.gridPView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView10 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabMachineTime = new DevExpress.XtraTab.XtraTabPage();
            this.gridMachineTime = new DevExpress.XtraGrid.GridControl();
            this.gridMachineTimeView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMachineID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMachineName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMoldID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMachineTimePlan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMachineTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSettingMoldTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartingTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSettingMachineTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOffMachineTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDownTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCycleTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQtyPlan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQtyFG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQtyNG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCavity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabLosstime = new DevExpress.XtraTab.XtraTabPage();
            this.gridLosstime = new DevExpress.XtraGrid.GridControl();
            this.gridLosstimeView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLosstimeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLosstimeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLosstimeNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabExWork = new DevExpress.XtraTab.XtraTabPage();
            this.gridExWork = new DevExpress.XtraGrid.GridControl();
            this.gridExWorkView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.EmpID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EmpName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ExProdWorkID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ExProdWorkName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ExProdWorkTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ExProdWorkTimeTC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView7 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabEmpScanBarcode = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.gridEmpScan = new DevExpress.XtraGrid.GridControl();
            this.gridEmpScanView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView9 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridDetailEmpScan = new DevExpress.XtraGrid.GridControl();
            this.gridDetailEmpScanView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAssigned = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAssignedOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStageID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStageName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaterialID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MachineID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCheckInDt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCheckOutDt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView11 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btDelEmpStage = new DevExpress.XtraEditors.SimpleButton();
            this.btDeleteStageTime = new DevExpress.XtraEditors.SimpleButton();
            this.btStageRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btOverall = new DevExpress.XtraEditors.SimpleButton();
            this.btStatEmpMulti = new DevExpress.XtraEditors.SimpleButton();
            this.btStatDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btStatEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btStatAdd = new DevExpress.XtraEditors.SimpleButton();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barThem = new DevExpress.XtraBars.BarButtonItem();
            this.barXoa = new DevExpress.XtraBars.BarButtonItem();
            this.barSua = new DevExpress.XtraBars.BarButtonItem();
            this.barNapLai = new DevExpress.XtraBars.BarButtonItem();
            this.barIn = new DevExpress.XtraBars.BarButtonItem();
            this.barXuat = new DevExpress.XtraBars.BarButtonItem();
            this.barNhap = new DevExpress.XtraBars.BarButtonItem();
            this.barThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barLocNgay = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.dtpFromDate = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            this.dtpToDate = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.barStaticItem3 = new DevExpress.XtraBars.BarStaticItem();
            this.cboStatus = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.barStaticItem4 = new DevExpress.XtraBars.BarStaticItem();
            this.cbWODocNo = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBox3 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.barDateFilter = new DevExpress.XtraBars.BarButtonItem();
            this.barCheckItem1 = new DevExpress.XtraBars.BarCheckItem();
            this.barShowAll = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.barCheckItem2 = new DevExpress.XtraBars.BarCheckItem();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colMachineINJ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlanningQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlanningMachineTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPercentLossA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPercentLossP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPercentLossQ = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProdStat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProdStatView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageProdStatDetail)).BeginInit();
            this.tabPageProdStatDetail.SuspendLayout();
            this.tabEmpStat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEmpStat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEmpStatView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            this.tabDFStat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDFStat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDFStatView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.tabA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView8)).BeginInit();
            this.tabP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView10)).BeginInit();
            this.tabMachineTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMachineTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMachineTimeView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.tabLosstime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLosstime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLosstimeView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.tabExWork.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridExWork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridExWorkView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView7)).BeginInit();
            this.tabEmpScanBarcode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEmpScan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEmpScanView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetailEmpScan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetailEmpScanView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView11)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit3.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // textEdit1
            // 
            this.textEdit1.Enabled = false;
            this.textEdit1.Location = new System.Drawing.Point(220, 280);
            this.textEdit1.Margin = new System.Windows.Forms.Padding(4);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(117, 22);
            this.textEdit1.TabIndex = 31;
            this.textEdit1.Visible = false;
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(1791, 54);
            this.barDockControl4.Manager = null;
            this.barDockControl4.Size = new System.Drawing.Size(0, 712);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 54);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1791, 712);
            this.panel1.TabIndex = 27;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridProdStat);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabPageProdStatDetail);
            this.splitContainer1.Size = new System.Drawing.Size(1791, 653);
            this.splitContainer1.SplitterDistance = 210;
            this.splitContainer1.TabIndex = 2;
            // 
            // gridProdStat
            // 
            this.gridProdStat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridProdStat.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridProdStat.Location = new System.Drawing.Point(0, 0);
            this.gridProdStat.MainView = this.gridProdStatView;
            this.gridProdStat.Margin = new System.Windows.Forms.Padding(4);
            this.gridProdStat.Name = "gridProdStat";
            this.gridProdStat.Size = new System.Drawing.Size(1791, 210);
            this.gridProdStat.TabIndex = 26;
            this.gridProdStat.UseEmbeddedNavigator = true;
            this.gridProdStat.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridProdStatView,
            this.gridView5});
            // 
            // gridProdStatView
            // 
            this.gridProdStatView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colQRStart,
            this.colFieldID,
            this.colLineID,
            this.colDocDate,
            this.colStatisticDate,
            this.colProdBeginDate,
            this.colProdShift,
            this.colWODocNo,
            this.colGWODocNo,
            this.colProductID,
            this.colProductType,
            this.colProdReqQuantity,
            this.colProdStatus,
            this.colProdStatisticQuantity,
            this.colProdStatisticEmpQuantity,
            this.colProdWorktime,
            this.colProdReworkTime,
            this.colProdSortTime,
            this.SubJobHC,
            this.colSumPrevFQCDFQuantity,
            this.colSumFQCDFQuantity,
            this.colSumFQCReworkQuantity,
            this.colSumFQCScrapQuantity,
            this.colOutputRateDG,
            this.colOutputRateVN,
            this.colTimeDG,
            this.colTimeVN,
            this.colProductivity,
            this.colYTDProductivity,
            this.colYieldProdQuantity,
            this.colMachineINJ,
            this.colPlanningQty,
            this.colPlanningMachineTime,
            this.colPercentLossA,
            this.colPercentLossP,
            this.colPercentLossQ});
            this.gridProdStatView.DetailHeight = 431;
            this.gridProdStatView.GridControl = this.gridProdStat;
            this.gridProdStatView.Name = "gridProdStatView";
            this.gridProdStatView.OptionsBehavior.Editable = false;
            this.gridProdStatView.OptionsSelection.MultiSelect = true;
            this.gridProdStatView.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.gridProdStatView.OptionsView.ColumnAutoWidth = false;
            this.gridProdStatView.OptionsView.ShowAutoFilterRow = true;
            this.gridProdStatView.OptionsView.ShowFooter = true;
            this.gridProdStatView.OptionsView.ShowGroupPanel = false;
            // 
            // colQRStart
            // 
            this.colQRStart.Caption = "QR Start";
            this.colQRStart.FieldName = "QRStart";
            this.colQRStart.MinWidth = 25;
            this.colQRStart.Name = "colQRStart";
            this.colQRStart.Visible = true;
            this.colQRStart.VisibleIndex = 0;
            this.colQRStart.Width = 94;
            // 
            // colFieldID
            // 
            this.colFieldID.Caption = "Mã ngành";
            this.colFieldID.FieldName = "FieldID";
            this.colFieldID.MinWidth = 25;
            this.colFieldID.Name = "colFieldID";
            this.colFieldID.Visible = true;
            this.colFieldID.VisibleIndex = 1;
            this.colFieldID.Width = 94;
            // 
            // colLineID
            // 
            this.colLineID.Caption = "Mã Line";
            this.colLineID.FieldName = "LineID";
            this.colLineID.MinWidth = 25;
            this.colLineID.Name = "colLineID";
            this.colLineID.Visible = true;
            this.colLineID.VisibleIndex = 2;
            this.colLineID.Width = 94;
            // 
            // colDocDate
            // 
            this.colDocDate.Caption = "Ngày chứng từ";
            this.colDocDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colDocDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colDocDate.FieldName = "DocDate";
            this.colDocDate.MinWidth = 25;
            this.colDocDate.Name = "colDocDate";
            this.colDocDate.Visible = true;
            this.colDocDate.VisibleIndex = 3;
            this.colDocDate.Width = 94;
            // 
            // colStatisticDate
            // 
            this.colStatisticDate.Caption = "Ngày thống kê";
            this.colStatisticDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colStatisticDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colStatisticDate.FieldName = "StatisticDate";
            this.colStatisticDate.MinWidth = 25;
            this.colStatisticDate.Name = "colStatisticDate";
            this.colStatisticDate.Visible = true;
            this.colStatisticDate.VisibleIndex = 4;
            this.colStatisticDate.Width = 94;
            // 
            // colProdBeginDate
            // 
            this.colProdBeginDate.Caption = "Ngày bắt đầu SX";
            this.colProdBeginDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colProdBeginDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colProdBeginDate.FieldName = "ProdBeginDate";
            this.colProdBeginDate.MinWidth = 25;
            this.colProdBeginDate.Name = "colProdBeginDate";
            this.colProdBeginDate.Visible = true;
            this.colProdBeginDate.VisibleIndex = 5;
            this.colProdBeginDate.Width = 94;
            // 
            // colProdShift
            // 
            this.colProdShift.Caption = "Ca sản xuất";
            this.colProdShift.FieldName = "ProdShift";
            this.colProdShift.MinWidth = 25;
            this.colProdShift.Name = "colProdShift";
            this.colProdShift.Visible = true;
            this.colProdShift.VisibleIndex = 6;
            this.colProdShift.Width = 94;
            // 
            // colWODocNo
            // 
            this.colWODocNo.Caption = "Lệnh sản xuất";
            this.colWODocNo.FieldName = "WODocNo";
            this.colWODocNo.MinWidth = 25;
            this.colWODocNo.Name = "colWODocNo";
            this.colWODocNo.Visible = true;
            this.colWODocNo.VisibleIndex = 7;
            this.colWODocNo.Width = 94;
            // 
            // colGWODocNo
            // 
            this.colGWODocNo.Caption = "Lệnh sản xuất cha";
            this.colGWODocNo.FieldName = "GWODocNo";
            this.colGWODocNo.MinWidth = 25;
            this.colGWODocNo.Name = "colGWODocNo";
            this.colGWODocNo.Visible = true;
            this.colGWODocNo.VisibleIndex = 8;
            this.colGWODocNo.Width = 94;
            // 
            // colProductID
            // 
            this.colProductID.Caption = "Mã sản phẩm";
            this.colProductID.FieldName = "ProductID";
            this.colProductID.MinWidth = 25;
            this.colProductID.Name = "colProductID";
            this.colProductID.Visible = true;
            this.colProductID.VisibleIndex = 9;
            this.colProductID.Width = 94;
            // 
            // colProductType
            // 
            this.colProductType.Caption = "Loại sản phẩm";
            this.colProductType.FieldName = "ProductType";
            this.colProductType.MinWidth = 25;
            this.colProductType.Name = "colProductType";
            this.colProductType.Visible = true;
            this.colProductType.VisibleIndex = 10;
            this.colProductType.Width = 94;
            // 
            // colProdReqQuantity
            // 
            this.colProdReqQuantity.Caption = "Số lượng yêu cầu";
            this.colProdReqQuantity.DisplayFormat.FormatString = "#0.00";
            this.colProdReqQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colProdReqQuantity.FieldName = "ProdReqQuantity";
            this.colProdReqQuantity.MinWidth = 25;
            this.colProdReqQuantity.Name = "colProdReqQuantity";
            this.colProdReqQuantity.Visible = true;
            this.colProdReqQuantity.VisibleIndex = 11;
            this.colProdReqQuantity.Width = 111;
            // 
            // colProdStatus
            // 
            this.colProdStatus.Caption = "Tính trạng SX";
            this.colProdStatus.FieldName = "ProdStatus";
            this.colProdStatus.MinWidth = 25;
            this.colProdStatus.Name = "colProdStatus";
            this.colProdStatus.Visible = true;
            this.colProdStatus.VisibleIndex = 12;
            this.colProdStatus.Width = 94;
            // 
            // colProdStatisticQuantity
            // 
            this.colProdStatisticQuantity.Caption = "Số lượng TP/BTP";
            this.colProdStatisticQuantity.DisplayFormat.FormatString = "#0.00";
            this.colProdStatisticQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colProdStatisticQuantity.FieldName = "ProdStatisticQuantity";
            this.colProdStatisticQuantity.MinWidth = 25;
            this.colProdStatisticQuantity.Name = "colProdStatisticQuantity";
            this.colProdStatisticQuantity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ProdStatisticQuantity", "{0:#0.00}")});
            this.colProdStatisticQuantity.Visible = true;
            this.colProdStatisticQuantity.VisibleIndex = 13;
            this.colProdStatisticQuantity.Width = 94;
            // 
            // colProdStatisticEmpQuantity
            // 
            this.colProdStatisticEmpQuantity.Caption = "Số người sản xuất";
            this.colProdStatisticEmpQuantity.DisplayFormat.FormatString = "#0.00";
            this.colProdStatisticEmpQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colProdStatisticEmpQuantity.FieldName = "ProdStatisticEmpQuantity";
            this.colProdStatisticEmpQuantity.MinWidth = 25;
            this.colProdStatisticEmpQuantity.Name = "colProdStatisticEmpQuantity";
            this.colProdStatisticEmpQuantity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ProdStatisticEmpQuantity", "{0:#0.00}")});
            this.colProdStatisticEmpQuantity.Visible = true;
            this.colProdStatisticEmpQuantity.VisibleIndex = 15;
            this.colProdStatisticEmpQuantity.Width = 94;
            // 
            // colProdWorktime
            // 
            this.colProdWorktime.Caption = "Tổng giờ sản xuất";
            this.colProdWorktime.DisplayFormat.FormatString = "#0.00";
            this.colProdWorktime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colProdWorktime.FieldName = "ProdWorktime";
            this.colProdWorktime.MinWidth = 25;
            this.colProdWorktime.Name = "colProdWorktime";
            this.colProdWorktime.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ProdWorktime", "{0:#0.00}")});
            this.colProdWorktime.Visible = true;
            this.colProdWorktime.VisibleIndex = 16;
            this.colProdWorktime.Width = 94;
            // 
            // colProdReworkTime
            // 
            this.colProdReworkTime.Caption = "Tổng giờ sửa hàng";
            this.colProdReworkTime.DisplayFormat.FormatString = "#0.00";
            this.colProdReworkTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colProdReworkTime.FieldName = "ProdReworkTime";
            this.colProdReworkTime.MinWidth = 25;
            this.colProdReworkTime.Name = "colProdReworkTime";
            this.colProdReworkTime.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ProdReworkTime", "{0:#0.00}")});
            this.colProdReworkTime.Visible = true;
            this.colProdReworkTime.VisibleIndex = 17;
            this.colProdReworkTime.Width = 94;
            // 
            // colProdSortTime
            // 
            this.colProdSortTime.Caption = "Tổng giờ Sorting";
            this.colProdSortTime.DisplayFormat.FormatString = "#0.00";
            this.colProdSortTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colProdSortTime.FieldName = "ProdSortTime";
            this.colProdSortTime.MinWidth = 25;
            this.colProdSortTime.Name = "colProdSortTime";
            this.colProdSortTime.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ProdSortTime", "{0:#0.00}")});
            this.colProdSortTime.Visible = true;
            this.colProdSortTime.VisibleIndex = 18;
            this.colProdSortTime.Width = 94;
            // 
            // SubJobHC
            // 
            this.SubJobHC.Caption = "Tổng giờ Sub Job";
            this.SubJobHC.DisplayFormat.FormatString = "#0.00";
            this.SubJobHC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.SubJobHC.FieldName = "SubJobHC";
            this.SubJobHC.MinWidth = 25;
            this.SubJobHC.Name = "SubJobHC";
            this.SubJobHC.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SubJobHC", "{0:#0.00}")});
            this.SubJobHC.Visible = true;
            this.SubJobHC.VisibleIndex = 19;
            this.SubJobHC.Width = 94;
            // 
            // colSumPrevFQCDFQuantity
            // 
            this.colSumPrevFQCDFQuantity.Caption = "Tổng SL lỗi trước FQC";
            this.colSumPrevFQCDFQuantity.DisplayFormat.FormatString = "#0.00";
            this.colSumPrevFQCDFQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSumPrevFQCDFQuantity.FieldName = "PrevFQCDFQuantity";
            this.colSumPrevFQCDFQuantity.MinWidth = 25;
            this.colSumPrevFQCDFQuantity.Name = "colSumPrevFQCDFQuantity";
            this.colSumPrevFQCDFQuantity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PrevFQCDFQuantity", "{0:#0.00}")});
            this.colSumPrevFQCDFQuantity.Visible = true;
            this.colSumPrevFQCDFQuantity.VisibleIndex = 20;
            this.colSumPrevFQCDFQuantity.Width = 94;
            // 
            // colSumFQCDFQuantity
            // 
            this.colSumFQCDFQuantity.Caption = "Tổng SL lỗi tại FQC";
            this.colSumFQCDFQuantity.DisplayFormat.FormatString = "#0.00";
            this.colSumFQCDFQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSumFQCDFQuantity.FieldName = "FQCDFQuantity";
            this.colSumFQCDFQuantity.MinWidth = 25;
            this.colSumFQCDFQuantity.Name = "colSumFQCDFQuantity";
            this.colSumFQCDFQuantity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "FQCDFQuantity", "{0:#0.00}")});
            this.colSumFQCDFQuantity.Visible = true;
            this.colSumFQCDFQuantity.VisibleIndex = 21;
            this.colSumFQCDFQuantity.Width = 94;
            // 
            // colSumFQCReworkQuantity
            // 
            this.colSumFQCReworkQuantity.Caption = "Tổng SL sửa hàng OK";
            this.colSumFQCReworkQuantity.DisplayFormat.FormatString = "#0.00";
            this.colSumFQCReworkQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSumFQCReworkQuantity.FieldName = "FQCReworkQuantity";
            this.colSumFQCReworkQuantity.MinWidth = 25;
            this.colSumFQCReworkQuantity.Name = "colSumFQCReworkQuantity";
            this.colSumFQCReworkQuantity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "FQCReworkQuantity", "{0:#0.00}")});
            this.colSumFQCReworkQuantity.Visible = true;
            this.colSumFQCReworkQuantity.VisibleIndex = 22;
            this.colSumFQCReworkQuantity.Width = 94;
            // 
            // colSumFQCScrapQuantity
            // 
            this.colSumFQCScrapQuantity.Caption = "Tổng SL huỷ";
            this.colSumFQCScrapQuantity.DisplayFormat.FormatString = "#0.00";
            this.colSumFQCScrapQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSumFQCScrapQuantity.FieldName = "FQCScrapQuantity";
            this.colSumFQCScrapQuantity.MinWidth = 25;
            this.colSumFQCScrapQuantity.Name = "colSumFQCScrapQuantity";
            this.colSumFQCScrapQuantity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "FQCScrapQuantity", "{0:#0.00}")});
            this.colSumFQCScrapQuantity.Visible = true;
            this.colSumFQCScrapQuantity.VisibleIndex = 23;
            this.colSumFQCScrapQuantity.Width = 94;
            // 
            // colOutputRateDG
            // 
            this.colOutputRateDG.Caption = "Output rate Cost Bom";
            this.colOutputRateDG.DisplayFormat.FormatString = "#0.00";
            this.colOutputRateDG.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOutputRateDG.FieldName = "OutputRateDG";
            this.colOutputRateDG.MinWidth = 25;
            this.colOutputRateDG.Name = "colOutputRateDG";
            this.colOutputRateDG.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OutputRateDG", "{0:#0.00}", "2")});
            this.colOutputRateDG.Visible = true;
            this.colOutputRateDG.VisibleIndex = 24;
            this.colOutputRateDG.Width = 94;
            // 
            // colOutputRateVN
            // 
            this.colOutputRateVN.Caption = "Output rate VN";
            this.colOutputRateVN.DisplayFormat.FormatString = "#0.00";
            this.colOutputRateVN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOutputRateVN.FieldName = "OutputRateVN";
            this.colOutputRateVN.MinWidth = 25;
            this.colOutputRateVN.Name = "colOutputRateVN";
            this.colOutputRateVN.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OutputRateVN", "{0:#0.00}", "1")});
            this.colOutputRateVN.Visible = true;
            this.colOutputRateVN.VisibleIndex = 25;
            this.colOutputRateVN.Width = 94;
            // 
            // colTimeDG
            // 
            this.colTimeDG.Caption = "Thời gian Cost Bom";
            this.colTimeDG.DisplayFormat.FormatString = "#0.00";
            this.colTimeDG.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTimeDG.FieldName = "TimeDG";
            this.colTimeDG.MinWidth = 25;
            this.colTimeDG.Name = "colTimeDG";
            this.colTimeDG.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TimeDG", "{0:#0.00}")});
            this.colTimeDG.Visible = true;
            this.colTimeDG.VisibleIndex = 26;
            this.colTimeDG.Width = 94;
            // 
            // colTimeVN
            // 
            this.colTimeVN.Caption = "Thời gian VN";
            this.colTimeVN.DisplayFormat.FormatString = "#0.00";
            this.colTimeVN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTimeVN.FieldName = "TimeVN";
            this.colTimeVN.MinWidth = 25;
            this.colTimeVN.Name = "colTimeVN";
            this.colTimeVN.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TimeVN", "{0:#0.00}")});
            this.colTimeVN.Visible = true;
            this.colTimeVN.VisibleIndex = 27;
            this.colTimeVN.Width = 94;
            // 
            // colProductivity
            // 
            this.colProductivity.Caption = "Năng suất";
            this.colProductivity.DisplayFormat.FormatString = "#0.00";
            this.colProductivity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colProductivity.FieldName = "Productivity";
            this.colProductivity.MinWidth = 25;
            this.colProductivity.Name = "colProductivity";
            this.colProductivity.Visible = true;
            this.colProductivity.VisibleIndex = 28;
            this.colProductivity.Width = 94;
            // 
            // colYTDProductivity
            // 
            this.colYTDProductivity.Caption = "Năng suất tích luỹ";
            this.colYTDProductivity.DisplayFormat.FormatString = "#0.00";
            this.colYTDProductivity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colYTDProductivity.FieldName = "YTDProductivity";
            this.colYTDProductivity.MinWidth = 25;
            this.colYTDProductivity.Name = "colYTDProductivity";
            this.colYTDProductivity.Visible = true;
            this.colYTDProductivity.VisibleIndex = 29;
            this.colYTDProductivity.Width = 94;
            // 
            // colYieldProdQuantity
            // 
            this.colYieldProdQuantity.Caption = "SL Tích Luỹ";
            this.colYieldProdQuantity.FieldName = "YieldProdQuantity";
            this.colYieldProdQuantity.MinWidth = 25;
            this.colYieldProdQuantity.Name = "colYieldProdQuantity";
            this.colYieldProdQuantity.Visible = true;
            this.colYieldProdQuantity.VisibleIndex = 14;
            this.colYieldProdQuantity.Width = 94;
            // 
            // gridView5
            // 
            this.gridView5.GridControl = this.gridProdStat;
            this.gridView5.Name = "gridView5";
            // 
            // tabPageProdStatDetail
            // 
            this.tabPageProdStatDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPageProdStatDetail.Location = new System.Drawing.Point(0, 0);
            this.tabPageProdStatDetail.Name = "tabPageProdStatDetail";
            this.tabPageProdStatDetail.SelectedTabPage = this.tabEmpStat;
            this.tabPageProdStatDetail.Size = new System.Drawing.Size(1791, 439);
            this.tabPageProdStatDetail.TabIndex = 0;
            this.tabPageProdStatDetail.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabEmpStat,
            this.tabDFStat,
            this.tabA,
            this.tabP,
            this.tabMachineTime,
            this.tabLosstime,
            this.tabExWork,
            this.tabEmpScanBarcode});
            // 
            // tabEmpStat
            // 
            this.tabEmpStat.Controls.Add(this.gridEmpStat);
            this.tabEmpStat.Name = "tabEmpStat";
            this.tabEmpStat.Size = new System.Drawing.Size(1785, 409);
            this.tabEmpStat.Text = "Thống kê nhân viên";
            // 
            // gridEmpStat
            // 
            this.gridEmpStat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEmpStat.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridEmpStat.EmbeddedNavigator.ShowToolTips = false;
            this.gridEmpStat.Location = new System.Drawing.Point(0, 0);
            this.gridEmpStat.MainView = this.gridEmpStatView;
            this.gridEmpStat.Margin = new System.Windows.Forms.Padding(4);
            this.gridEmpStat.Name = "gridEmpStat";
            this.gridEmpStat.Size = new System.Drawing.Size(1785, 409);
            this.gridEmpStat.TabIndex = 29;
            this.gridEmpStat.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridEmpStatView,
            this.gridView4});
            // 
            // gridEmpStatView
            // 
            this.gridEmpStatView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEmpID,
            this.colEmpName,
            this.colEmpPosition,
            this.colIsDirect,
            this.colLine,
            this.colEmpLine,
            this.colEmpWorktime,
            this.colEmpOvertime,
            this.colEmpRework,
            this.colEmpSorting,
            this.colEmpOverRework,
            this.colEmpOverSorting,
            this.colExLosstimeHC,
            this.colExLosstimeTC,
            this.colSubJobHC,
            this.colSubJobTC,
            this.colGeneralEmpWorktime,
            this.colGeneralEmpOvertime,
            this.colTimekeepHours,
            this.colTimekeepID,
            this.colTimeDifference});
            this.gridEmpStatView.DetailHeight = 431;
            this.gridEmpStatView.GridControl = this.gridEmpStat;
            this.gridEmpStatView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridEmpStatView.Name = "gridEmpStatView";
            this.gridEmpStatView.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.gridEmpStatView.OptionsBehavior.Editable = false;
            this.gridEmpStatView.OptionsBehavior.SummariesIgnoreNullValues = true;
            this.gridEmpStatView.OptionsClipboard.AllowExcelFormat = DevExpress.Utils.DefaultBoolean.False;
            this.gridEmpStatView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridEmpStatView.OptionsFilter.AllowMRUFilterList = false;
            this.gridEmpStatView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel;
            this.gridEmpStatView.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText;
            this.gridEmpStatView.OptionsFilter.FilterEditorAllowCustomExpressions = DevExpress.Utils.DefaultBoolean.True;
            this.gridEmpStatView.OptionsFilter.FilterEditorUseMenuForOperandsAndOperators = true;
            this.gridEmpStatView.OptionsFilter.InHeaderSearchMode = DevExpress.XtraGrid.Views.Grid.GridInHeaderSearchMode.Disabled;
            this.gridEmpStatView.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gridEmpStatView.OptionsFilter.ShowCustomFunctions = DevExpress.Utils.DefaultBoolean.False;
            this.gridEmpStatView.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.True;
            this.gridEmpStatView.OptionsMenu.ShowFooterItem = true;
            this.gridEmpStatView.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.gridEmpStatView.OptionsMenu.ShowSummaryItemMode = DevExpress.Utils.DefaultBoolean.True;
            this.gridEmpStatView.OptionsPrint.AutoWidth = false;
            this.gridEmpStatView.OptionsSelection.MultiSelect = true;
            this.gridEmpStatView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridEmpStatView.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.gridEmpStatView.OptionsView.ColumnAutoWidth = false;
            this.gridEmpStatView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gridEmpStatView.OptionsView.ShowAutoFilterRow = true;
            this.gridEmpStatView.OptionsView.ShowFooter = true;
            this.gridEmpStatView.OptionsView.ShowGroupPanel = false;
            this.gridEmpStatView.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            // 
            // colEmpID
            // 
            this.colEmpID.Caption = "Mã nhân viên";
            this.colEmpID.FieldName = "EmpID";
            this.colEmpID.MinWidth = 25;
            this.colEmpID.Name = "colEmpID";
            this.colEmpID.OptionsColumn.AllowEdit = false;
            this.colEmpID.Visible = true;
            this.colEmpID.VisibleIndex = 1;
            this.colEmpID.Width = 94;
            // 
            // colEmpName
            // 
            this.colEmpName.Caption = "Tên nhân viên";
            this.colEmpName.FieldName = "EmpName";
            this.colEmpName.MinWidth = 25;
            this.colEmpName.Name = "colEmpName";
            this.colEmpName.OptionsColumn.AllowEdit = false;
            this.colEmpName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "EmpName", "Số lượng = {0}")});
            this.colEmpName.Visible = true;
            this.colEmpName.VisibleIndex = 2;
            this.colEmpName.Width = 94;
            // 
            // colEmpPosition
            // 
            this.colEmpPosition.Caption = "Chức vụ";
            this.colEmpPosition.FieldName = "EmpPosition";
            this.colEmpPosition.MinWidth = 25;
            this.colEmpPosition.Name = "colEmpPosition";
            this.colEmpPosition.OptionsColumn.AllowEdit = false;
            this.colEmpPosition.Visible = true;
            this.colEmpPosition.VisibleIndex = 3;
            this.colEmpPosition.Width = 94;
            // 
            // colIsDirect
            // 
            this.colIsDirect.Caption = "Direct/Indirect";
            this.colIsDirect.FieldName = "IsDirect";
            this.colIsDirect.MinWidth = 25;
            this.colIsDirect.Name = "colIsDirect";
            this.colIsDirect.OptionsColumn.AllowEdit = false;
            this.colIsDirect.Visible = true;
            this.colIsDirect.VisibleIndex = 4;
            this.colIsDirect.Width = 94;
            // 
            // colLine
            // 
            this.colLine.Caption = "Mã Line";
            this.colLine.FieldName = "LineID";
            this.colLine.MinWidth = 25;
            this.colLine.Name = "colLine";
            this.colLine.OptionsColumn.AllowEdit = false;
            this.colLine.Visible = true;
            this.colLine.VisibleIndex = 5;
            this.colLine.Width = 94;
            // 
            // colEmpLine
            // 
            this.colEmpLine.Caption = "Mã line nhân viên";
            this.colEmpLine.FieldName = "EmpLineID";
            this.colEmpLine.MinWidth = 25;
            this.colEmpLine.Name = "colEmpLine";
            this.colEmpLine.OptionsColumn.AllowEdit = false;
            this.colEmpLine.Visible = true;
            this.colEmpLine.VisibleIndex = 6;
            this.colEmpLine.Width = 94;
            // 
            // colEmpWorktime
            // 
            this.colEmpWorktime.Caption = "Giờ công HC";
            this.colEmpWorktime.DisplayFormat.FormatString = "#0.00";
            this.colEmpWorktime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colEmpWorktime.FieldName = "EmpWorktime";
            this.colEmpWorktime.MinWidth = 25;
            this.colEmpWorktime.Name = "colEmpWorktime";
            this.colEmpWorktime.OptionsColumn.AllowEdit = false;
            this.colEmpWorktime.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EmpWorktime", "{0:#0.00}")});
            this.colEmpWorktime.Visible = true;
            this.colEmpWorktime.VisibleIndex = 7;
            this.colEmpWorktime.Width = 94;
            // 
            // colEmpOvertime
            // 
            this.colEmpOvertime.Caption = "Giờ công TC";
            this.colEmpOvertime.DisplayFormat.FormatString = "#0.00";
            this.colEmpOvertime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colEmpOvertime.FieldName = "EmpOvertime";
            this.colEmpOvertime.MinWidth = 25;
            this.colEmpOvertime.Name = "colEmpOvertime";
            this.colEmpOvertime.OptionsColumn.AllowEdit = false;
            this.colEmpOvertime.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EmpOvertime", "{0:#0.00}")});
            this.colEmpOvertime.Visible = true;
            this.colEmpOvertime.VisibleIndex = 8;
            this.colEmpOvertime.Width = 94;
            // 
            // colEmpRework
            // 
            this.colEmpRework.Caption = "Giờ sửa hàng HC";
            this.colEmpRework.DisplayFormat.FormatString = "#0.00";
            this.colEmpRework.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colEmpRework.FieldName = "EmpRework";
            this.colEmpRework.MinWidth = 25;
            this.colEmpRework.Name = "colEmpRework";
            this.colEmpRework.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EmpRework", "{0:#0.00}")});
            this.colEmpRework.Visible = true;
            this.colEmpRework.VisibleIndex = 9;
            this.colEmpRework.Width = 94;
            // 
            // colEmpSorting
            // 
            this.colEmpSorting.Caption = "Giờ Sorting HC";
            this.colEmpSorting.DisplayFormat.FormatString = "#0.00";
            this.colEmpSorting.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colEmpSorting.FieldName = "EmpSorting";
            this.colEmpSorting.MinWidth = 25;
            this.colEmpSorting.Name = "colEmpSorting";
            this.colEmpSorting.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EmpSorting", "{0:#0.00}")});
            this.colEmpSorting.Visible = true;
            this.colEmpSorting.VisibleIndex = 10;
            this.colEmpSorting.Width = 94;
            // 
            // colEmpOverRework
            // 
            this.colEmpOverRework.Caption = "Giờ sửa hàng TC";
            this.colEmpOverRework.DisplayFormat.FormatString = "#0.00";
            this.colEmpOverRework.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colEmpOverRework.FieldName = "EmpOverRework";
            this.colEmpOverRework.MinWidth = 25;
            this.colEmpOverRework.Name = "colEmpOverRework";
            this.colEmpOverRework.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EmpOverRework", "{0:#0.00}")});
            this.colEmpOverRework.Visible = true;
            this.colEmpOverRework.VisibleIndex = 11;
            this.colEmpOverRework.Width = 94;
            // 
            // colEmpOverSorting
            // 
            this.colEmpOverSorting.Caption = "Giờ Sorting TC";
            this.colEmpOverSorting.DisplayFormat.FormatString = "#0.00";
            this.colEmpOverSorting.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colEmpOverSorting.FieldName = "EmpOverSorting";
            this.colEmpOverSorting.MinWidth = 25;
            this.colEmpOverSorting.Name = "colEmpOverSorting";
            this.colEmpOverSorting.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EmpOverSorting", "{0:#0.00}")});
            this.colEmpOverSorting.Visible = true;
            this.colEmpOverSorting.VisibleIndex = 12;
            this.colEmpOverSorting.Width = 94;
            // 
            // colExLosstimeHC
            // 
            this.colExLosstimeHC.Caption = "Losstime HC";
            this.colExLosstimeHC.DisplayFormat.FormatString = "#0.00";
            this.colExLosstimeHC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colExLosstimeHC.FieldName = "LosstimeNum";
            this.colExLosstimeHC.MinWidth = 25;
            this.colExLosstimeHC.Name = "colExLosstimeHC";
            this.colExLosstimeHC.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "LosstimeNum", "{0:#0.00}")});
            this.colExLosstimeHC.Visible = true;
            this.colExLosstimeHC.VisibleIndex = 13;
            this.colExLosstimeHC.Width = 94;
            // 
            // colExLosstimeTC
            // 
            this.colExLosstimeTC.Caption = "Losstime TC";
            this.colExLosstimeTC.DisplayFormat.FormatString = "#0.00";
            this.colExLosstimeTC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colExLosstimeTC.FieldName = "LosstimeNumTC";
            this.colExLosstimeTC.MinWidth = 25;
            this.colExLosstimeTC.Name = "colExLosstimeTC";
            this.colExLosstimeTC.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "LosstimeNumTC", "{0:#0.00}")});
            this.colExLosstimeTC.Visible = true;
            this.colExLosstimeTC.VisibleIndex = 14;
            this.colExLosstimeTC.Width = 94;
            // 
            // colSubJobHC
            // 
            this.colSubJobHC.Caption = "Sub Job HC";
            this.colSubJobHC.DisplayFormat.FormatString = "#0.00";
            this.colSubJobHC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSubJobHC.FieldName = "SubJobHC";
            this.colSubJobHC.MinWidth = 25;
            this.colSubJobHC.Name = "colSubJobHC";
            this.colSubJobHC.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SubJobHC", "{0:#0.00}")});
            this.colSubJobHC.Visible = true;
            this.colSubJobHC.VisibleIndex = 15;
            this.colSubJobHC.Width = 94;
            // 
            // colSubJobTC
            // 
            this.colSubJobTC.Caption = "Sub Job TC";
            this.colSubJobTC.DisplayFormat.FormatString = "#0.00";
            this.colSubJobTC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSubJobTC.FieldName = "SubJobTC";
            this.colSubJobTC.MinWidth = 25;
            this.colSubJobTC.Name = "colSubJobTC";
            this.colSubJobTC.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SubJobTC", "{0:#0.00}")});
            this.colSubJobTC.Visible = true;
            this.colSubJobTC.VisibleIndex = 16;
            this.colSubJobTC.Width = 94;
            // 
            // colGeneralEmpWorktime
            // 
            this.colGeneralEmpWorktime.Caption = "Tổng giờ HC";
            this.colGeneralEmpWorktime.DisplayFormat.FormatString = "#0.00";
            this.colGeneralEmpWorktime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGeneralEmpWorktime.FieldName = "GeneralEmpWorktime";
            this.colGeneralEmpWorktime.MinWidth = 25;
            this.colGeneralEmpWorktime.Name = "colGeneralEmpWorktime";
            this.colGeneralEmpWorktime.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GeneralEmpWorktime", "{0:#0.00}")});
            this.colGeneralEmpWorktime.Visible = true;
            this.colGeneralEmpWorktime.VisibleIndex = 17;
            this.colGeneralEmpWorktime.Width = 94;
            // 
            // colGeneralEmpOvertime
            // 
            this.colGeneralEmpOvertime.Caption = "Tổng giờ TC";
            this.colGeneralEmpOvertime.DisplayFormat.FormatString = "#0.00";
            this.colGeneralEmpOvertime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGeneralEmpOvertime.FieldName = "GeneralEmpOvertime";
            this.colGeneralEmpOvertime.MinWidth = 25;
            this.colGeneralEmpOvertime.Name = "colGeneralEmpOvertime";
            this.colGeneralEmpOvertime.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GeneralEmpOvertime", "{0:#0.00}")});
            this.colGeneralEmpOvertime.Visible = true;
            this.colGeneralEmpOvertime.VisibleIndex = 18;
            this.colGeneralEmpOvertime.Width = 94;
            // 
            // colTimekeepHours
            // 
            this.colTimekeepHours.Caption = "Giờ điểm danh";
            this.colTimekeepHours.DisplayFormat.FormatString = "#0.00";
            this.colTimekeepHours.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTimekeepHours.FieldName = "TimekeepHours";
            this.colTimekeepHours.MinWidth = 25;
            this.colTimekeepHours.Name = "colTimekeepHours";
            this.colTimekeepHours.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TimekeepHours", "{0:#0.00}")});
            this.colTimekeepHours.Visible = true;
            this.colTimekeepHours.VisibleIndex = 19;
            this.colTimekeepHours.Width = 94;
            // 
            // colTimekeepID
            // 
            this.colTimekeepID.Caption = "Chấm công";
            this.colTimekeepID.FieldName = "TimekeepID";
            this.colTimekeepID.MinWidth = 25;
            this.colTimekeepID.Name = "colTimekeepID";
            this.colTimekeepID.Width = 94;
            // 
            // colTimeDifference
            // 
            this.colTimeDifference.Caption = "Giờ chênh lệch";
            this.colTimeDifference.DisplayFormat.FormatString = "#0.00";
            this.colTimeDifference.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTimeDifference.FieldName = "DifferenceTime";
            this.colTimeDifference.MinWidth = 25;
            this.colTimeDifference.Name = "colTimeDifference";
            this.colTimeDifference.Visible = true;
            this.colTimeDifference.VisibleIndex = 20;
            this.colTimeDifference.Width = 94;
            // 
            // gridView4
            // 
            this.gridView4.GridControl = this.gridEmpStat;
            this.gridView4.Name = "gridView4";
            // 
            // tabDFStat
            // 
            this.tabDFStat.Controls.Add(this.gridDFStat);
            this.tabDFStat.Name = "tabDFStat";
            this.tabDFStat.Size = new System.Drawing.Size(1785, 409);
            this.tabDFStat.Text = "Thống kê Defect mode";
            // 
            // gridDFStat
            // 
            this.gridDFStat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDFStat.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridDFStat.Location = new System.Drawing.Point(0, 0);
            this.gridDFStat.MainView = this.gridDFStatView;
            this.gridDFStat.Margin = new System.Windows.Forms.Padding(4);
            this.gridDFStat.Name = "gridDFStat";
            this.gridDFStat.Size = new System.Drawing.Size(1785, 409);
            this.gridDFStat.TabIndex = 28;
            this.gridDFStat.UseEmbeddedNavigator = true;
            this.gridDFStat.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridDFStatView,
            this.gridView3});
            // 
            // gridDFStatView
            // 
            this.gridDFStatView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDFGroup,
            this.colDFID,
            this.colDFName,
            this.colFQCScrapQuantity});
            this.gridDFStatView.DetailHeight = 431;
            this.gridDFStatView.GridControl = this.gridDFStat;
            this.gridDFStatView.Name = "gridDFStatView";
            this.gridDFStatView.OptionsBehavior.Editable = false;
            this.gridDFStatView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridDFStatView.OptionsSelection.MultiSelect = true;
            this.gridDFStatView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridDFStatView.OptionsView.ShowAutoFilterRow = true;
            this.gridDFStatView.OptionsView.ShowGroupPanel = false;
            // 
            // colDFGroup
            // 
            this.colDFGroup.Caption = "Nhóm Defect";
            this.colDFGroup.FieldName = "DefectGroup";
            this.colDFGroup.MinWidth = 25;
            this.colDFGroup.Name = "colDFGroup";
            this.colDFGroup.Visible = true;
            this.colDFGroup.VisibleIndex = 1;
            this.colDFGroup.Width = 94;
            // 
            // colDFID
            // 
            this.colDFID.Caption = "Mã Defect";
            this.colDFID.FieldName = "DefectID";
            this.colDFID.MinWidth = 25;
            this.colDFID.Name = "colDFID";
            this.colDFID.Visible = true;
            this.colDFID.VisibleIndex = 2;
            this.colDFID.Width = 94;
            // 
            // colDFName
            // 
            this.colDFName.Caption = "Tên Defect";
            this.colDFName.FieldName = "DefectName";
            this.colDFName.MinWidth = 25;
            this.colDFName.Name = "colDFName";
            this.colDFName.Visible = true;
            this.colDFName.VisibleIndex = 3;
            this.colDFName.Width = 94;
            // 
            // colFQCScrapQuantity
            // 
            this.colFQCScrapQuantity.Caption = "Số lượng huỷ";
            this.colFQCScrapQuantity.DisplayFormat.FormatString = "#0.00";
            this.colFQCScrapQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colFQCScrapQuantity.FieldName = "FQCScrapQuantity";
            this.colFQCScrapQuantity.MinWidth = 25;
            this.colFQCScrapQuantity.Name = "colFQCScrapQuantity";
            this.colFQCScrapQuantity.Visible = true;
            this.colFQCScrapQuantity.VisibleIndex = 4;
            this.colFQCScrapQuantity.Width = 94;
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.gridDFStat;
            this.gridView3.Name = "gridView3";
            // 
            // tabA
            // 
            this.tabA.Controls.Add(this.gridA);
            this.tabA.Name = "tabA";
            this.tabA.Size = new System.Drawing.Size(1785, 409);
            this.tabA.Text = "Thống kê A";
            // 
            // gridA
            // 
            this.gridA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridA.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridA.Location = new System.Drawing.Point(0, 0);
            this.gridA.MainView = this.gridAView;
            this.gridA.Margin = new System.Windows.Forms.Padding(4);
            this.gridA.Name = "gridA";
            this.gridA.Size = new System.Drawing.Size(1785, 409);
            this.gridA.TabIndex = 29;
            this.gridA.UseEmbeddedNavigator = true;
            this.gridA.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridAView,
            this.gridView8});
            // 
            // gridAView
            // 
            this.gridAView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10});
            this.gridAView.DetailHeight = 431;
            this.gridAView.GridControl = this.gridA;
            this.gridAView.Name = "gridAView";
            this.gridAView.OptionsBehavior.Editable = false;
            this.gridAView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridAView.OptionsSelection.MultiSelect = true;
            this.gridAView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridAView.OptionsView.ShowAutoFilterRow = true;
            this.gridAView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Nhóm Defect";
            this.gridColumn7.FieldName = "DefectGroup";
            this.gridColumn7.MinWidth = 25;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            this.gridColumn7.Width = 94;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Mã Defect";
            this.gridColumn8.FieldName = "DefectID";
            this.gridColumn8.MinWidth = 25;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 2;
            this.gridColumn8.Width = 94;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Tên Defect";
            this.gridColumn9.FieldName = "DefectName";
            this.gridColumn9.MinWidth = 25;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 3;
            this.gridColumn9.Width = 94;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Số giờ";
            this.gridColumn10.DisplayFormat.FormatString = "#0.00";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn10.FieldName = "NumOfTime";
            this.gridColumn10.MinWidth = 25;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 4;
            this.gridColumn10.Width = 94;
            // 
            // gridView8
            // 
            this.gridView8.GridControl = this.gridA;
            this.gridView8.Name = "gridView8";
            // 
            // tabP
            // 
            this.tabP.Controls.Add(this.gridP);
            this.tabP.Name = "tabP";
            this.tabP.Size = new System.Drawing.Size(1785, 409);
            this.tabP.Text = "Thống kê P";
            // 
            // gridP
            // 
            this.gridP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridP.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridP.Location = new System.Drawing.Point(0, 0);
            this.gridP.MainView = this.gridPView;
            this.gridP.Margin = new System.Windows.Forms.Padding(4);
            this.gridP.Name = "gridP";
            this.gridP.Size = new System.Drawing.Size(1785, 409);
            this.gridP.TabIndex = 30;
            this.gridP.UseEmbeddedNavigator = true;
            this.gridP.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridPView,
            this.gridView10});
            // 
            // gridPView
            // 
            this.gridPView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14});
            this.gridPView.DetailHeight = 431;
            this.gridPView.GridControl = this.gridP;
            this.gridPView.Name = "gridPView";
            this.gridPView.OptionsBehavior.Editable = false;
            this.gridPView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridPView.OptionsSelection.MultiSelect = true;
            this.gridPView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridPView.OptionsView.ShowAutoFilterRow = true;
            this.gridPView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Nhóm Defect";
            this.gridColumn11.FieldName = "DefectGroup";
            this.gridColumn11.MinWidth = 25;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 1;
            this.gridColumn11.Width = 94;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Mã Defect";
            this.gridColumn12.FieldName = "DefectID";
            this.gridColumn12.MinWidth = 25;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 2;
            this.gridColumn12.Width = 94;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Tên Defect";
            this.gridColumn13.FieldName = "DefectName";
            this.gridColumn13.MinWidth = 25;
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 3;
            this.gridColumn13.Width = 94;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Số giờ";
            this.gridColumn14.DisplayFormat.FormatString = "#0.00";
            this.gridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn14.FieldName = "NumOfTime";
            this.gridColumn14.MinWidth = 25;
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 4;
            this.gridColumn14.Width = 94;
            // 
            // gridView10
            // 
            this.gridView10.GridControl = this.gridP;
            this.gridView10.Name = "gridView10";
            // 
            // tabMachineTime
            // 
            this.tabMachineTime.Controls.Add(this.gridMachineTime);
            this.tabMachineTime.Name = "tabMachineTime";
            this.tabMachineTime.Size = new System.Drawing.Size(1785, 409);
            this.tabMachineTime.Text = "Thống kê giờ máy";
            // 
            // gridMachineTime
            // 
            this.gridMachineTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMachineTime.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridMachineTime.Location = new System.Drawing.Point(0, 0);
            this.gridMachineTime.MainView = this.gridMachineTimeView;
            this.gridMachineTime.Margin = new System.Windows.Forms.Padding(4);
            this.gridMachineTime.Name = "gridMachineTime";
            this.gridMachineTime.Size = new System.Drawing.Size(1785, 409);
            this.gridMachineTime.TabIndex = 28;
            this.gridMachineTime.UseEmbeddedNavigator = true;
            this.gridMachineTime.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridMachineTimeView,
            this.gridView2});
            // 
            // gridMachineTimeView
            // 
            this.gridMachineTimeView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMachineID,
            this.colMachineName,
            this.colMoldID,
            this.colMachineTimePlan,
            this.colMachineTime,
            this.colSettingMoldTime,
            this.colStartingTime,
            this.colSettingMachineTime,
            this.colOffMachineTime,
            this.colDownTime,
            this.colCycleTime,
            this.colQtyPlan,
            this.colQtyFG,
            this.colQtyNG,
            this.colCavity});
            this.gridMachineTimeView.DetailHeight = 431;
            this.gridMachineTimeView.GridControl = this.gridMachineTime;
            this.gridMachineTimeView.Name = "gridMachineTimeView";
            this.gridMachineTimeView.OptionsBehavior.Editable = false;
            this.gridMachineTimeView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridMachineTimeView.OptionsSelection.MultiSelect = true;
            this.gridMachineTimeView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridMachineTimeView.OptionsView.ShowAutoFilterRow = true;
            this.gridMachineTimeView.OptionsView.ShowGroupPanel = false;
            // 
            // colMachineID
            // 
            this.colMachineID.Caption = "Mã máy";
            this.colMachineID.FieldName = "MachineID";
            this.colMachineID.MinWidth = 25;
            this.colMachineID.Name = "colMachineID";
            this.colMachineID.Visible = true;
            this.colMachineID.VisibleIndex = 1;
            this.colMachineID.Width = 94;
            // 
            // colMachineName
            // 
            this.colMachineName.Caption = "Tên máy";
            this.colMachineName.FieldName = "MachineName";
            this.colMachineName.MinWidth = 25;
            this.colMachineName.Name = "colMachineName";
            this.colMachineName.Visible = true;
            this.colMachineName.VisibleIndex = 2;
            this.colMachineName.Width = 94;
            // 
            // colMoldID
            // 
            this.colMoldID.Caption = "Mã khuôn";
            this.colMoldID.FieldName = "MoldID";
            this.colMoldID.MinWidth = 25;
            this.colMoldID.Name = "colMoldID";
            this.colMoldID.Visible = true;
            this.colMoldID.VisibleIndex = 3;
            this.colMoldID.Width = 94;
            // 
            // colMachineTimePlan
            // 
            this.colMachineTimePlan.Caption = "Time Plan";
            this.colMachineTimePlan.DisplayFormat.FormatString = "#0.00";
            this.colMachineTimePlan.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMachineTimePlan.FieldName = "MachineTimePlan";
            this.colMachineTimePlan.MinWidth = 25;
            this.colMachineTimePlan.Name = "colMachineTimePlan";
            this.colMachineTimePlan.Visible = true;
            this.colMachineTimePlan.VisibleIndex = 4;
            this.colMachineTimePlan.Width = 94;
            // 
            // colMachineTime
            // 
            this.colMachineTime.Caption = "Machine Time";
            this.colMachineTime.DisplayFormat.FormatString = "#0.00";
            this.colMachineTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMachineTime.FieldName = "MachineTime";
            this.colMachineTime.MinWidth = 25;
            this.colMachineTime.Name = "colMachineTime";
            this.colMachineTime.Visible = true;
            this.colMachineTime.VisibleIndex = 5;
            this.colMachineTime.Width = 94;
            // 
            // colSettingMoldTime
            // 
            this.colSettingMoldTime.Caption = "Setting Mold Time";
            this.colSettingMoldTime.DisplayFormat.FormatString = "#0.00";
            this.colSettingMoldTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSettingMoldTime.FieldName = "SettingMoldTime";
            this.colSettingMoldTime.MinWidth = 25;
            this.colSettingMoldTime.Name = "colSettingMoldTime";
            this.colSettingMoldTime.Visible = true;
            this.colSettingMoldTime.VisibleIndex = 6;
            this.colSettingMoldTime.Width = 94;
            // 
            // colStartingTime
            // 
            this.colStartingTime.Caption = "Starting Time";
            this.colStartingTime.DisplayFormat.FormatString = "#0.00";
            this.colStartingTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colStartingTime.FieldName = "StartingTime";
            this.colStartingTime.MinWidth = 25;
            this.colStartingTime.Name = "colStartingTime";
            this.colStartingTime.Visible = true;
            this.colStartingTime.VisibleIndex = 7;
            this.colStartingTime.Width = 94;
            // 
            // colSettingMachineTime
            // 
            this.colSettingMachineTime.Caption = "Setting Machine Time";
            this.colSettingMachineTime.DisplayFormat.FormatString = "#0.00";
            this.colSettingMachineTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSettingMachineTime.FieldName = "SettingMachineTime";
            this.colSettingMachineTime.MinWidth = 25;
            this.colSettingMachineTime.Name = "colSettingMachineTime";
            this.colSettingMachineTime.Visible = true;
            this.colSettingMachineTime.VisibleIndex = 8;
            this.colSettingMachineTime.Width = 94;
            // 
            // colOffMachineTime
            // 
            this.colOffMachineTime.Caption = "Off Machine Time";
            this.colOffMachineTime.DisplayFormat.FormatString = "#0.00";
            this.colOffMachineTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOffMachineTime.FieldName = "OffMachineTime";
            this.colOffMachineTime.MinWidth = 25;
            this.colOffMachineTime.Name = "colOffMachineTime";
            this.colOffMachineTime.Visible = true;
            this.colOffMachineTime.VisibleIndex = 9;
            this.colOffMachineTime.Width = 94;
            // 
            // colDownTime
            // 
            this.colDownTime.Caption = "Down Time";
            this.colDownTime.DisplayFormat.FormatString = "#0.00";
            this.colDownTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDownTime.FieldName = "DownTime";
            this.colDownTime.MinWidth = 25;
            this.colDownTime.Name = "colDownTime";
            this.colDownTime.Visible = true;
            this.colDownTime.VisibleIndex = 10;
            this.colDownTime.Width = 94;
            // 
            // colCycleTime
            // 
            this.colCycleTime.Caption = "Cycle Time";
            this.colCycleTime.DisplayFormat.FormatString = "#0.00";
            this.colCycleTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCycleTime.FieldName = "CycleTime";
            this.colCycleTime.MinWidth = 25;
            this.colCycleTime.Name = "colCycleTime";
            this.colCycleTime.Visible = true;
            this.colCycleTime.VisibleIndex = 11;
            this.colCycleTime.Width = 94;
            // 
            // colQtyPlan
            // 
            this.colQtyPlan.Caption = "Quantity Plan";
            this.colQtyPlan.DisplayFormat.FormatString = "#0.00";
            this.colQtyPlan.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQtyPlan.FieldName = "QtyPlan";
            this.colQtyPlan.MinWidth = 25;
            this.colQtyPlan.Name = "colQtyPlan";
            this.colQtyPlan.Visible = true;
            this.colQtyPlan.VisibleIndex = 12;
            this.colQtyPlan.Width = 94;
            // 
            // colQtyFG
            // 
            this.colQtyFG.Caption = "Quantity FG";
            this.colQtyFG.DisplayFormat.FormatString = "#0.00";
            this.colQtyFG.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQtyFG.FieldName = "QtyFG";
            this.colQtyFG.MinWidth = 25;
            this.colQtyFG.Name = "colQtyFG";
            this.colQtyFG.Visible = true;
            this.colQtyFG.VisibleIndex = 13;
            this.colQtyFG.Width = 94;
            // 
            // colQtyNG
            // 
            this.colQtyNG.Caption = "Quantity NG";
            this.colQtyNG.DisplayFormat.FormatString = "#0.00";
            this.colQtyNG.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQtyNG.FieldName = "QtyNG";
            this.colQtyNG.MinWidth = 25;
            this.colQtyNG.Name = "colQtyNG";
            this.colQtyNG.Visible = true;
            this.colQtyNG.VisibleIndex = 14;
            this.colQtyNG.Width = 94;
            // 
            // colCavity
            // 
            this.colCavity.Caption = "Cavity";
            this.colCavity.DisplayFormat.FormatString = "#0.00";
            this.colCavity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCavity.FieldName = "Cavity";
            this.colCavity.MinWidth = 25;
            this.colCavity.Name = "colCavity";
            this.colCavity.Visible = true;
            this.colCavity.VisibleIndex = 15;
            this.colCavity.Width = 94;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridMachineTime;
            this.gridView2.Name = "gridView2";
            // 
            // tabLosstime
            // 
            this.tabLosstime.Controls.Add(this.gridLosstime);
            this.tabLosstime.Name = "tabLosstime";
            this.tabLosstime.PageVisible = false;
            this.tabLosstime.Size = new System.Drawing.Size(1785, 409);
            this.tabLosstime.Text = "Thống kê Losstime";
            // 
            // gridLosstime
            // 
            this.gridLosstime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLosstime.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridLosstime.Location = new System.Drawing.Point(0, 0);
            this.gridLosstime.MainView = this.gridLosstimeView;
            this.gridLosstime.Margin = new System.Windows.Forms.Padding(4);
            this.gridLosstime.Name = "gridLosstime";
            this.gridLosstime.Size = new System.Drawing.Size(1785, 409);
            this.gridLosstime.TabIndex = 28;
            this.gridLosstime.UseEmbeddedNavigator = true;
            this.gridLosstime.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridLosstimeView,
            this.gridView1});
            // 
            // gridLosstimeView
            // 
            this.gridLosstimeView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLosstimeID,
            this.colLosstimeName,
            this.colLosstimeNum});
            this.gridLosstimeView.DetailHeight = 431;
            this.gridLosstimeView.GridControl = this.gridLosstime;
            this.gridLosstimeView.Name = "gridLosstimeView";
            this.gridLosstimeView.OptionsBehavior.Editable = false;
            this.gridLosstimeView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridLosstimeView.OptionsSelection.MultiSelect = true;
            this.gridLosstimeView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridLosstimeView.OptionsView.ShowAutoFilterRow = true;
            this.gridLosstimeView.OptionsView.ShowGroupPanel = false;
            // 
            // colLosstimeID
            // 
            this.colLosstimeID.Caption = "Mã Losstime";
            this.colLosstimeID.FieldName = "LosstimeID";
            this.colLosstimeID.MinWidth = 25;
            this.colLosstimeID.Name = "colLosstimeID";
            this.colLosstimeID.Visible = true;
            this.colLosstimeID.VisibleIndex = 1;
            this.colLosstimeID.Width = 94;
            // 
            // colLosstimeName
            // 
            this.colLosstimeName.Caption = "Tên Losstime";
            this.colLosstimeName.FieldName = "LosstimeName";
            this.colLosstimeName.MinWidth = 25;
            this.colLosstimeName.Name = "colLosstimeName";
            this.colLosstimeName.Visible = true;
            this.colLosstimeName.VisibleIndex = 2;
            this.colLosstimeName.Width = 94;
            // 
            // colLosstimeNum
            // 
            this.colLosstimeNum.Caption = "Số giờ";
            this.colLosstimeNum.DisplayFormat.FormatString = "#0.00";
            this.colLosstimeNum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colLosstimeNum.FieldName = "LosstimeNum";
            this.colLosstimeNum.MinWidth = 25;
            this.colLosstimeNum.Name = "colLosstimeNum";
            this.colLosstimeNum.Visible = true;
            this.colLosstimeNum.VisibleIndex = 3;
            this.colLosstimeNum.Width = 94;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridLosstime;
            this.gridView1.Name = "gridView1";
            // 
            // tabExWork
            // 
            this.tabExWork.Controls.Add(this.gridExWork);
            this.tabExWork.Name = "tabExWork";
            this.tabExWork.Size = new System.Drawing.Size(1785, 409);
            this.tabExWork.Text = "Thống kê công việc phụ";
            // 
            // gridExWork
            // 
            this.gridExWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridExWork.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(5);
            this.gridExWork.Location = new System.Drawing.Point(0, 0);
            this.gridExWork.MainView = this.gridExWorkView;
            this.gridExWork.Margin = new System.Windows.Forms.Padding(5);
            this.gridExWork.Name = "gridExWork";
            this.gridExWork.Size = new System.Drawing.Size(1785, 409);
            this.gridExWork.TabIndex = 29;
            this.gridExWork.UseEmbeddedNavigator = true;
            this.gridExWork.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridExWorkView,
            this.gridView7});
            // 
            // gridExWorkView
            // 
            this.gridExWorkView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.EmpID,
            this.EmpName,
            this.ExProdWorkID,
            this.ExProdWorkName,
            this.ExProdWorkTime,
            this.ExProdWorkTimeTC});
            this.gridExWorkView.DetailHeight = 539;
            this.gridExWorkView.GridControl = this.gridExWork;
            this.gridExWorkView.Name = "gridExWorkView";
            this.gridExWorkView.OptionsBehavior.Editable = false;
            this.gridExWorkView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridExWorkView.OptionsSelection.MultiSelect = true;
            this.gridExWorkView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridExWorkView.OptionsView.ShowAutoFilterRow = true;
            this.gridExWorkView.OptionsView.ShowGroupPanel = false;
            // 
            // EmpID
            // 
            this.EmpID.Caption = "Mã nhân viên";
            this.EmpID.FieldName = "EmpID";
            this.EmpID.MinWidth = 25;
            this.EmpID.Name = "EmpID";
            this.EmpID.Visible = true;
            this.EmpID.VisibleIndex = 1;
            this.EmpID.Width = 94;
            // 
            // EmpName
            // 
            this.EmpName.Caption = "Tên nhân viên";
            this.EmpName.FieldName = "EmpName";
            this.EmpName.MinWidth = 25;
            this.EmpName.Name = "EmpName";
            this.EmpName.Visible = true;
            this.EmpName.VisibleIndex = 2;
            this.EmpName.Width = 94;
            // 
            // ExProdWorkID
            // 
            this.ExProdWorkID.Caption = "Mã công việc";
            this.ExProdWorkID.FieldName = "ExProdWorkID";
            this.ExProdWorkID.MinWidth = 25;
            this.ExProdWorkID.Name = "ExProdWorkID";
            this.ExProdWorkID.Visible = true;
            this.ExProdWorkID.VisibleIndex = 3;
            this.ExProdWorkID.Width = 94;
            // 
            // ExProdWorkName
            // 
            this.ExProdWorkName.Caption = "Tên công việc";
            this.ExProdWorkName.FieldName = "ExProdWorkName";
            this.ExProdWorkName.MinWidth = 25;
            this.ExProdWorkName.Name = "ExProdWorkName";
            this.ExProdWorkName.Visible = true;
            this.ExProdWorkName.VisibleIndex = 4;
            this.ExProdWorkName.Width = 94;
            // 
            // ExProdWorkTime
            // 
            this.ExProdWorkTime.Caption = "Số giờ làm HC";
            this.ExProdWorkTime.DisplayFormat.FormatString = "#0.00";
            this.ExProdWorkTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ExProdWorkTime.FieldName = "ExProdWorkTime";
            this.ExProdWorkTime.MinWidth = 25;
            this.ExProdWorkTime.Name = "ExProdWorkTime";
            this.ExProdWorkTime.Visible = true;
            this.ExProdWorkTime.VisibleIndex = 5;
            this.ExProdWorkTime.Width = 94;
            // 
            // ExProdWorkTimeTC
            // 
            this.ExProdWorkTimeTC.Caption = "Số giờ làm TC";
            this.ExProdWorkTimeTC.DisplayFormat.FormatString = "#0.00";
            this.ExProdWorkTimeTC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ExProdWorkTimeTC.FieldName = "ExProdWorkTimeTC";
            this.ExProdWorkTimeTC.MinWidth = 25;
            this.ExProdWorkTimeTC.Name = "ExProdWorkTimeTC";
            this.ExProdWorkTimeTC.Visible = true;
            this.ExProdWorkTimeTC.VisibleIndex = 6;
            this.ExProdWorkTimeTC.Width = 94;
            // 
            // gridView7
            // 
            this.gridView7.DetailHeight = 437;
            this.gridView7.GridControl = this.gridExWork;
            this.gridView7.Name = "gridView7";
            // 
            // tabEmpScanBarcode
            // 
            this.tabEmpScanBarcode.Controls.Add(this.splitContainer3);
            this.tabEmpScanBarcode.Name = "tabEmpScanBarcode";
            this.tabEmpScanBarcode.Size = new System.Drawing.Size(1785, 409);
            this.tabEmpScanBarcode.Text = "Employee Scanner";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.gridEmpScan);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.gridDetailEmpScan);
            this.splitContainer3.Size = new System.Drawing.Size(1785, 409);
            this.splitContainer3.SplitterDistance = 595;
            this.splitContainer3.TabIndex = 1;
            // 
            // gridEmpScan
            // 
            this.gridEmpScan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEmpScan.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridEmpScan.EmbeddedNavigator.ShowToolTips = false;
            this.gridEmpScan.Location = new System.Drawing.Point(0, 0);
            this.gridEmpScan.MainView = this.gridEmpScanView;
            this.gridEmpScan.Margin = new System.Windows.Forms.Padding(4);
            this.gridEmpScan.Name = "gridEmpScan";
            this.gridEmpScan.Size = new System.Drawing.Size(595, 409);
            this.gridEmpScan.TabIndex = 28;
            this.gridEmpScan.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridEmpScanView,
            this.gridView9});
            // 
            // gridEmpScanView
            // 
            this.gridEmpScanView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.gridEmpScanView.DetailHeight = 431;
            this.gridEmpScanView.GridControl = this.gridEmpScan;
            this.gridEmpScanView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridEmpScanView.Name = "gridEmpScanView";
            this.gridEmpScanView.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.gridEmpScanView.OptionsBehavior.Editable = false;
            this.gridEmpScanView.OptionsBehavior.SummariesIgnoreNullValues = true;
            this.gridEmpScanView.OptionsClipboard.AllowExcelFormat = DevExpress.Utils.DefaultBoolean.False;
            this.gridEmpScanView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridEmpScanView.OptionsFilter.AllowMRUFilterList = false;
            this.gridEmpScanView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel;
            this.gridEmpScanView.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText;
            this.gridEmpScanView.OptionsFilter.FilterEditorAllowCustomExpressions = DevExpress.Utils.DefaultBoolean.True;
            this.gridEmpScanView.OptionsFilter.FilterEditorUseMenuForOperandsAndOperators = true;
            this.gridEmpScanView.OptionsFilter.InHeaderSearchMode = DevExpress.XtraGrid.Views.Grid.GridInHeaderSearchMode.Disabled;
            this.gridEmpScanView.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gridEmpScanView.OptionsFilter.ShowCustomFunctions = DevExpress.Utils.DefaultBoolean.False;
            this.gridEmpScanView.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.True;
            this.gridEmpScanView.OptionsMenu.ShowFooterItem = true;
            this.gridEmpScanView.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.gridEmpScanView.OptionsMenu.ShowSummaryItemMode = DevExpress.Utils.DefaultBoolean.True;
            this.gridEmpScanView.OptionsPrint.AutoWidth = false;
            this.gridEmpScanView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridEmpScanView.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.gridEmpScanView.OptionsView.ColumnAutoWidth = false;
            this.gridEmpScanView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gridEmpScanView.OptionsView.ShowAutoFilterRow = true;
            this.gridEmpScanView.OptionsView.ShowFooter = true;
            this.gridEmpScanView.OptionsView.ShowGroupPanel = false;
            this.gridEmpScanView.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã nhân viên";
            this.gridColumn1.FieldName = "EmpID";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 94;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên nhân viên";
            this.gridColumn2.FieldName = "EmpName";
            this.gridColumn2.MinWidth = 25;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "EmpName", "Số lượng = {0}")});
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 180;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Chức vụ";
            this.gridColumn3.FieldName = "EmpPosition";
            this.gridColumn3.MinWidth = 25;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 94;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Direct/Indirect";
            this.gridColumn4.FieldName = "IsDirect";
            this.gridColumn4.MinWidth = 25;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 94;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Mã Line";
            this.gridColumn5.FieldName = "LineID";
            this.gridColumn5.MinWidth = 25;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 94;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Mã line nhân viên";
            this.gridColumn6.FieldName = "EmpLineID";
            this.gridColumn6.MinWidth = 25;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 94;
            // 
            // gridView9
            // 
            this.gridView9.GridControl = this.gridEmpScan;
            this.gridView9.Name = "gridView9";
            // 
            // gridDetailEmpScan
            // 
            this.gridDetailEmpScan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDetailEmpScan.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridDetailEmpScan.EmbeddedNavigator.ShowToolTips = false;
            this.gridDetailEmpScan.Location = new System.Drawing.Point(0, 0);
            this.gridDetailEmpScan.MainView = this.gridDetailEmpScanView;
            this.gridDetailEmpScan.Margin = new System.Windows.Forms.Padding(4);
            this.gridDetailEmpScan.Name = "gridDetailEmpScan";
            this.gridDetailEmpScan.Size = new System.Drawing.Size(1186, 409);
            this.gridDetailEmpScan.TabIndex = 29;
            this.gridDetailEmpScan.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridDetailEmpScanView,
            this.gridView11});
            // 
            // gridDetailEmpScanView
            // 
            this.gridDetailEmpScanView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAssigned,
            this.colAssignedOrder,
            this.colStageID,
            this.colStageName,
            this.colMaterialID,
            this.MachineID,
            this.colCheckInDt,
            this.colCheckOutDt,
            this.colQuantity});
            this.gridDetailEmpScanView.DetailHeight = 431;
            this.gridDetailEmpScanView.GridControl = this.gridDetailEmpScan;
            this.gridDetailEmpScanView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridDetailEmpScanView.Name = "gridDetailEmpScanView";
            this.gridDetailEmpScanView.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.gridDetailEmpScanView.OptionsBehavior.Editable = false;
            this.gridDetailEmpScanView.OptionsBehavior.SummariesIgnoreNullValues = true;
            this.gridDetailEmpScanView.OptionsClipboard.AllowExcelFormat = DevExpress.Utils.DefaultBoolean.False;
            this.gridDetailEmpScanView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridDetailEmpScanView.OptionsFilter.AllowMRUFilterList = false;
            this.gridDetailEmpScanView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel;
            this.gridDetailEmpScanView.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText;
            this.gridDetailEmpScanView.OptionsFilter.FilterEditorAllowCustomExpressions = DevExpress.Utils.DefaultBoolean.True;
            this.gridDetailEmpScanView.OptionsFilter.FilterEditorUseMenuForOperandsAndOperators = true;
            this.gridDetailEmpScanView.OptionsFilter.InHeaderSearchMode = DevExpress.XtraGrid.Views.Grid.GridInHeaderSearchMode.Disabled;
            this.gridDetailEmpScanView.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gridDetailEmpScanView.OptionsFilter.ShowCustomFunctions = DevExpress.Utils.DefaultBoolean.False;
            this.gridDetailEmpScanView.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.True;
            this.gridDetailEmpScanView.OptionsMenu.ShowFooterItem = true;
            this.gridDetailEmpScanView.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.gridDetailEmpScanView.OptionsMenu.ShowSummaryItemMode = DevExpress.Utils.DefaultBoolean.True;
            this.gridDetailEmpScanView.OptionsPrint.AutoWidth = false;
            this.gridDetailEmpScanView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridDetailEmpScanView.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.gridDetailEmpScanView.OptionsView.ColumnAutoWidth = false;
            this.gridDetailEmpScanView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gridDetailEmpScanView.OptionsView.ShowAutoFilterRow = true;
            this.gridDetailEmpScanView.OptionsView.ShowFooter = true;
            this.gridDetailEmpScanView.OptionsView.ShowGroupPanel = false;
            this.gridDetailEmpScanView.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            // 
            // colAssigned
            // 
            this.colAssigned.Caption = "Chọn";
            this.colAssigned.FieldName = "Assigned";
            this.colAssigned.MinWidth = 25;
            this.colAssigned.Name = "colAssigned";
            this.colAssigned.Visible = true;
            this.colAssigned.VisibleIndex = 0;
            this.colAssigned.Width = 70;
            // 
            // colAssignedOrder
            // 
            this.colAssignedOrder.Caption = "Thứ tự";
            this.colAssignedOrder.FieldName = "AssignedOrder";
            this.colAssignedOrder.MinWidth = 25;
            this.colAssignedOrder.Name = "colAssignedOrder";
            this.colAssignedOrder.Visible = true;
            this.colAssignedOrder.VisibleIndex = 1;
            // 
            // colStageID
            // 
            this.colStageID.Caption = "Mã công đoạn";
            this.colStageID.FieldName = "StageID";
            this.colStageID.MinWidth = 25;
            this.colStageID.Name = "colStageID";
            this.colStageID.Visible = true;
            this.colStageID.VisibleIndex = 2;
            this.colStageID.Width = 105;
            // 
            // colStageName
            // 
            this.colStageName.Caption = "Tên công đoạn";
            this.colStageName.FieldName = "StageName";
            this.colStageName.MinWidth = 25;
            this.colStageName.Name = "colStageName";
            this.colStageName.Visible = true;
            this.colStageName.VisibleIndex = 3;
            this.colStageName.Width = 200;
            // 
            // colMaterialID
            // 
            this.colMaterialID.Caption = "NVL";
            this.colMaterialID.FieldName = "MaterialID";
            this.colMaterialID.MinWidth = 25;
            this.colMaterialID.Name = "colMaterialID";
            this.colMaterialID.Visible = true;
            this.colMaterialID.VisibleIndex = 4;
            this.colMaterialID.Width = 94;
            // 
            // MachineID
            // 
            this.MachineID.Caption = "Mã máy";
            this.MachineID.FieldName = "MachineID";
            this.MachineID.MinWidth = 25;
            this.MachineID.Name = "MachineID";
            this.MachineID.Visible = true;
            this.MachineID.VisibleIndex = 5;
            this.MachineID.Width = 94;
            // 
            // colCheckInDt
            // 
            this.colCheckInDt.Caption = "Thời gian Check-in";
            this.colCheckInDt.DisplayFormat.FormatString = "HH:mm:ss";
            this.colCheckInDt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCheckInDt.FieldName = "CheckInDt";
            this.colCheckInDt.MinWidth = 25;
            this.colCheckInDt.Name = "colCheckInDt";
            this.colCheckInDt.Visible = true;
            this.colCheckInDt.VisibleIndex = 6;
            this.colCheckInDt.Width = 135;
            // 
            // colCheckOutDt
            // 
            this.colCheckOutDt.Caption = "Thời gian Check-out";
            this.colCheckOutDt.DisplayFormat.FormatString = "HH:mm:ss";
            this.colCheckOutDt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCheckOutDt.FieldName = "CheckOutDt";
            this.colCheckOutDt.MinWidth = 25;
            this.colCheckOutDt.Name = "colCheckOutDt";
            this.colCheckOutDt.Visible = true;
            this.colCheckOutDt.VisibleIndex = 7;
            this.colCheckOutDt.Width = 135;
            // 
            // colQuantity
            // 
            this.colQuantity.Caption = "Số lượng";
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.MinWidth = 25;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Visible = true;
            this.colQuantity.VisibleIndex = 8;
            this.colQuantity.Width = 100;
            // 
            // gridView11
            // 
            this.gridView11.GridControl = this.gridDetailEmpScan;
            this.gridView11.Name = "gridView11";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btDelEmpStage);
            this.panel2.Controls.Add(this.btDeleteStageTime);
            this.panel2.Controls.Add(this.btStageRefresh);
            this.panel2.Controls.Add(this.btOverall);
            this.panel2.Controls.Add(this.btStatEmpMulti);
            this.panel2.Controls.Add(this.btStatDelete);
            this.panel2.Controls.Add(this.btStatEdit);
            this.panel2.Controls.Add(this.btStatAdd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 653);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1791, 59);
            this.panel2.TabIndex = 29;
            // 
            // btDelEmpStage
            // 
            this.btDelEmpStage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btDelEmpStage.ImageOptions.Image = global::ASPProject.Properties.Resources.close4;
            this.btDelEmpStage.Location = new System.Drawing.Point(1488, 12);
            this.btDelEmpStage.Name = "btDelEmpStage";
            this.btDelEmpStage.Size = new System.Drawing.Size(135, 35);
            this.btDelEmpStage.TabIndex = 7;
            this.btDelEmpStage.Text = "Xoá từng NV";
            this.btDelEmpStage.Visible = false;
            // 
            // btDeleteStageTime
            // 
            this.btDeleteStageTime.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btDeleteStageTime.ImageOptions.Image = global::ASPProject.Properties.Resources.cancel;
            this.btDeleteStageTime.Location = new System.Drawing.Point(1640, 12);
            this.btDeleteStageTime.Name = "btDeleteStageTime";
            this.btDeleteStageTime.Size = new System.Drawing.Size(135, 35);
            this.btDeleteStageTime.TabIndex = 6;
            this.btDeleteStageTime.Text = "Xoá tất cả";
            this.btDeleteStageTime.Visible = false;
            // 
            // btStageRefresh
            // 
            this.btStageRefresh.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btStageRefresh.ImageOptions.Image = global::ASPProject.Properties.Resources.refresh1;
            this.btStageRefresh.Location = new System.Drawing.Point(1340, 12);
            this.btStageRefresh.Name = "btStageRefresh";
            this.btStageRefresh.Size = new System.Drawing.Size(132, 35);
            this.btStageRefresh.TabIndex = 5;
            this.btStageRefresh.Text = "Cập nhật";
            this.btStageRefresh.Visible = false;
            // 
            // btOverall
            // 
            this.btOverall.ImageOptions.Image = global::ASPProject.Properties.Resources.report1;
            this.btOverall.Location = new System.Drawing.Point(498, 11);
            this.btOverall.Name = "btOverall";
            this.btOverall.Size = new System.Drawing.Size(161, 35);
            this.btOverall.TabIndex = 4;
            this.btOverall.Text = "Tổng kết ngày";
            // 
            // btStatEmpMulti
            // 
            this.btStatEmpMulti.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btStatEmpMulti.ImageOptions.Image")));
            this.btStatEmpMulti.Location = new System.Drawing.Point(156, 11);
            this.btStatEmpMulti.Name = "btStatEmpMulti";
            this.btStatEmpMulti.Size = new System.Drawing.Size(161, 35);
            this.btStatEmpMulti.TabIndex = 3;
            this.btStatEmpMulti.Text = "Sửa nhiều dòng";
            // 
            // btStatDelete
            // 
            this.btStatDelete.ImageOptions.Image = global::ASPProject.Properties.Resources.cancel;
            this.btStatDelete.Location = new System.Drawing.Point(337, 11);
            this.btStatDelete.Name = "btStatDelete";
            this.btStatDelete.Size = new System.Drawing.Size(120, 35);
            this.btStatDelete.TabIndex = 2;
            this.btStatDelete.Text = "Xoá";
            // 
            // btStatEdit
            // 
            this.btStatEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btStatEdit.ImageOptions.Image")));
            this.btStatEdit.Location = new System.Drawing.Point(156, 11);
            this.btStatEdit.Name = "btStatEdit";
            this.btStatEdit.Size = new System.Drawing.Size(120, 35);
            this.btStatEdit.TabIndex = 1;
            this.btStatEdit.Text = "Sửa";
            this.btStatEdit.Visible = false;
            // 
            // btStatAdd
            // 
            this.btStatAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btStatAdd.ImageOptions.Image")));
            this.btStatAdd.Location = new System.Drawing.Point(16, 11);
            this.btStatAdd.Name = "btStatAdd";
            this.btStatAdd.Size = new System.Drawing.Size(120, 35);
            this.btStatAdd.TabIndex = 0;
            this.btStatAdd.Text = "Thêm";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Thêm";
            this.barButtonItem3.Id = 0;
            this.barButtonItem3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.Image")));
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Thêm";
            this.barButtonItem2.Id = 0;
            this.barButtonItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 54);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 712);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barThem,
            this.barXoa,
            this.barSua,
            this.barNapLai,
            this.barIn,
            this.barXuat,
            this.barThoat,
            this.barNhap,
            this.barEditItem1,
            this.barDateFilter,
            this.barCheckItem1,
            this.barShowAll,
            this.barCheckItem2,
            this.barLocNgay,
            this.barStaticItem1,
            this.dtpFromDate,
            this.barStaticItem2,
            this.dtpToDate,
            this.barStaticItem3,
            this.cboStatus,
            this.barStaticItem4,
            this.cbWODocNo});
            this.barManager1.MainMenu = this.bar1;
            this.barManager1.MaxItemId = 26;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.repositoryItemCheckEdit1,
            this.repositoryItemDateEdit2,
            this.repositoryItemDateEdit3,
            this.repositoryItemComboBox1,
            this.repositoryItemComboBox2,
            this.repositoryItemComboBox3});
            // 
            // bar1
            // 
            this.bar1.BarName = "Main menu";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barThem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barXoa, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSua, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barNapLai, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barIn, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barXuat, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barNhap, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barThoat, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.barLocNgay),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.dtpFromDate),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.dtpToDate),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem3),
            new DevExpress.XtraBars.LinkPersistInfo(this.cboStatus),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem4),
            new DevExpress.XtraBars.LinkPersistInfo(this.cbWODocNo)});
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Main menu";
            // 
            // barThem
            // 
            this.barThem.Caption = "Thêm";
            this.barThem.Id = 2;
            this.barThem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barThem.ImageOptions.Image")));
            this.barThem.Name = "barThem";
            // 
            // barXoa
            // 
            this.barXoa.Caption = "Xóa";
            this.barXoa.Id = 3;
            this.barXoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barXoa.ImageOptions.Image")));
            this.barXoa.Name = "barXoa";
            // 
            // barSua
            // 
            this.barSua.Caption = "Sửa";
            this.barSua.Id = 4;
            this.barSua.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barSua.ImageOptions.Image")));
            this.barSua.Name = "barSua";
            // 
            // barNapLai
            // 
            this.barNapLai.Caption = "Refresh";
            this.barNapLai.Id = 5;
            this.barNapLai.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barNapLai.ImageOptions.Image")));
            this.barNapLai.Name = "barNapLai";
            // 
            // barIn
            // 
            this.barIn.Caption = "In";
            this.barIn.Id = 6;
            this.barIn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barIn.ImageOptions.Image")));
            this.barIn.Name = "barIn";
            // 
            // barXuat
            // 
            this.barXuat.Caption = "Xuất Dữ Liệu";
            this.barXuat.Id = 7;
            this.barXuat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barXuat.ImageOptions.Image")));
            this.barXuat.Name = "barXuat";
            // 
            // barNhap
            // 
            this.barNhap.Caption = "Nhập Dữ Liệu";
            this.barNhap.Id = 9;
            this.barNhap.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barNhap.ImageOptions.Image")));
            this.barNhap.Name = "barNhap";
            // 
            // barThoat
            // 
            this.barThoat.Caption = "Đóng";
            this.barThoat.Id = 8;
            this.barThoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barThoat.ImageOptions.Image")));
            this.barThoat.Name = "barThoat";
            // 
            // barLocNgay
            // 
            this.barLocNgay.Caption = "Lọc";
            this.barLocNgay.Id = 15;
            this.barLocNgay.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barLocNgay.ImageOptions.Image")));
            this.barLocNgay.Name = "barLocNgay";
            this.barLocNgay.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "Từ ngày";
            this.barStaticItem1.Id = 16;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Caption = "Từ ngày";
            this.dtpFromDate.Edit = this.repositoryItemDateEdit2;
            this.dtpFromDate.Id = 17;
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(100, 0);
            this.dtpFromDate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barEditItem2_ItemClick);
            // 
            // repositoryItemDateEdit2
            // 
            this.repositoryItemDateEdit2.AutoHeight = false;
            this.repositoryItemDateEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit2.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit2.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.repositoryItemDateEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.repositoryItemDateEdit2.Name = "repositoryItemDateEdit2";
            // 
            // barStaticItem2
            // 
            this.barStaticItem2.Caption = "Đến ngày";
            this.barStaticItem2.Id = 18;
            this.barStaticItem2.Name = "barStaticItem2";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Caption = "Đến ngày";
            this.dtpToDate.Edit = this.repositoryItemDateEdit3;
            this.dtpToDate.Id = 19;
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(100, 0);
            // 
            // repositoryItemDateEdit3
            // 
            this.repositoryItemDateEdit3.AutoHeight = false;
            this.repositoryItemDateEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit3.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit3.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.repositoryItemDateEdit3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.repositoryItemDateEdit3.Name = "repositoryItemDateEdit3";
            // 
            // barStaticItem3
            // 
            this.barStaticItem3.Caption = "Tình trạng SX";
            this.barStaticItem3.Id = 20;
            this.barStaticItem3.Name = "barStaticItem3";
            // 
            // cboStatus
            // 
            this.cboStatus.Caption = "barEditItem2";
            this.cboStatus.Edit = this.repositoryItemComboBox1;
            this.cboStatus.Id = 21;
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(100, 0);
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // barStaticItem4
            // 
            this.barStaticItem4.Caption = "Số lệnh SX";
            this.barStaticItem4.Id = 24;
            this.barStaticItem4.Name = "barStaticItem4";
            // 
            // cbWODocNo
            // 
            this.cbWODocNo.Caption = "WO Doc No";
            this.cbWODocNo.Edit = this.repositoryItemComboBox3;
            this.cbWODocNo.Id = 25;
            this.cbWODocNo.Name = "cbWODocNo";
            this.cbWODocNo.Size = new System.Drawing.Size(120, 0);
            // 
            // repositoryItemComboBox3
            // 
            this.repositoryItemComboBox3.AutoHeight = false;
            this.repositoryItemComboBox3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox3.Name = "repositoryItemComboBox3";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlTop.Size = new System.Drawing.Size(1791, 54);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 766);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1791, 0);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1791, 54);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 712);
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "barEditItem1";
            this.barEditItem1.Edit = this.repositoryItemDateEdit1;
            this.barEditItem1.Id = 10;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // barDateFilter
            // 
            this.barDateFilter.Caption = "Lọc ngày";
            this.barDateFilter.Id = 11;
            this.barDateFilter.ImageOptions.Image = global::ASPProject.Properties.Resources.preview_file;
            this.barDateFilter.ImageOptions.LargeImage = global::ASPProject.Properties.Resources.preview_file;
            this.barDateFilter.Name = "barDateFilter";
            // 
            // barCheckItem1
            // 
            this.barCheckItem1.Caption = "barCheckItem1";
            this.barCheckItem1.Id = 12;
            this.barCheckItem1.Name = "barCheckItem1";
            // 
            // barShowAll
            // 
            this.barShowAll.Caption = "Hiển thị tất cả LSX";
            this.barShowAll.Edit = this.repositoryItemCheckEdit1;
            this.barShowAll.Id = 13;
            this.barShowAll.Name = "barShowAll";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Hiện tất cả";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // barCheckItem2
            // 
            this.barCheckItem2.Caption = "Hiện tất cả";
            this.barCheckItem2.CheckBoxVisibility = DevExpress.XtraBars.CheckBoxVisibility.BeforeText;
            this.barCheckItem2.Id = 14;
            this.barCheckItem2.Name = "barCheckItem2";
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            // 
            // colMachineINJ
            // 
            this.colMachineINJ.Caption = "Máy INJ";
            this.colMachineINJ.FieldName = "MachineINJ";
            this.colMachineINJ.MinWidth = 25;
            this.colMachineINJ.Name = "colMachineINJ";
            this.colMachineINJ.Visible = true;
            this.colMachineINJ.VisibleIndex = 30;
            this.colMachineINJ.Width = 94;
            // 
            // colPlanningQty
            // 
            this.colPlanningQty.Caption = "SL Kế hoạch";
            this.colPlanningQty.FieldName = "PlanningQty";
            this.colPlanningQty.MinWidth = 25;
            this.colPlanningQty.Name = "colPlanningQty";
            this.colPlanningQty.Visible = true;
            this.colPlanningQty.VisibleIndex = 31;
            this.colPlanningQty.Width = 94;
            // 
            // colPlanningMachineTime
            // 
            this.colPlanningMachineTime.Caption = "Giờ máy Kế hoạch";
            this.colPlanningMachineTime.FieldName = "PlanningMachineTime";
            this.colPlanningMachineTime.MinWidth = 25;
            this.colPlanningMachineTime.Name = "colPlanningMachineTime";
            this.colPlanningMachineTime.Visible = true;
            this.colPlanningMachineTime.VisibleIndex = 32;
            this.colPlanningMachineTime.Width = 94;
            // 
            // colPercentLossA
            // 
            this.colPercentLossA.Caption = "% Loss A";
            this.colPercentLossA.FieldName = "PercentLossA";
            this.colPercentLossA.MinWidth = 25;
            this.colPercentLossA.Name = "colPercentLossA";
            this.colPercentLossA.Visible = true;
            this.colPercentLossA.VisibleIndex = 33;
            this.colPercentLossA.Width = 94;
            // 
            // colPercentLossP
            // 
            this.colPercentLossP.Caption = "% Loss P";
            this.colPercentLossP.FieldName = "PercentLossP";
            this.colPercentLossP.MinWidth = 25;
            this.colPercentLossP.Name = "colPercentLossP";
            this.colPercentLossP.Visible = true;
            this.colPercentLossP.VisibleIndex = 34;
            this.colPercentLossP.Width = 94;
            // 
            // colPercentLossQ
            // 
            this.colPercentLossQ.Caption = "% Loss Q";
            this.colPercentLossQ.FieldName = "PercentLossQ";
            this.colPercentLossQ.MinWidth = 25;
            this.colPercentLossQ.Name = "colPercentLossQ";
            this.colPercentLossQ.Visible = true;
            this.colPercentLossQ.VisibleIndex = 35;
            this.colPercentLossQ.Width = 94;
            // 
            // frmProdStatisticView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1791, 766);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProdStatisticView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thống kê sản xuất";
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridProdStat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProdStatView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageProdStatDetail)).EndInit();
            this.tabPageProdStatDetail.ResumeLayout(false);
            this.tabEmpStat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEmpStat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEmpStatView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            this.tabDFStat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDFStat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDFStatView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.tabA.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView8)).EndInit();
            this.tabP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView10)).EndInit();
            this.tabMachineTime.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMachineTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMachineTimeView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.tabLosstime.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridLosstime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLosstimeView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.tabExWork.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridExWork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridExWorkView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView7)).EndInit();
            this.tabEmpScanBarcode.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEmpScan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEmpScanView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetailEmpScan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetailEmpScanView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView11)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit3.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem barThem;
        private DevExpress.XtraBars.BarButtonItem barXoa;
        private DevExpress.XtraBars.BarButtonItem barSua;
        private DevExpress.XtraBars.BarButtonItem barNapLai;
        private DevExpress.XtraBars.BarButtonItem barIn;
        private DevExpress.XtraBars.BarButtonItem barXuat;
        private DevExpress.XtraBars.BarButtonItem barNhap;
        private DevExpress.XtraBars.BarButtonItem barThoat;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.GridControl gridProdStat;
        private DevExpress.XtraGrid.Views.Grid.GridView gridProdStatView;
        private DevExpress.XtraGrid.Columns.GridColumn colFieldID;
        private DevExpress.XtraGrid.Columns.GridColumn colLineID;
        private DevExpress.XtraGrid.Columns.GridColumn colDocDate;
        private DevExpress.XtraGrid.Columns.GridColumn colStatisticDate;
        private DevExpress.XtraGrid.Columns.GridColumn colProdShift;
        private DevExpress.XtraGrid.Columns.GridColumn colWODocNo;
        private DevExpress.XtraGrid.Columns.GridColumn colGWODocNo;
        private DevExpress.XtraGrid.Columns.GridColumn colProductID;
        private DevExpress.XtraGrid.Columns.GridColumn colProductType;
        private DevExpress.XtraGrid.Columns.GridColumn colProdReqQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colProdStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colProdStatisticQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colProdStatisticEmpQuantity;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private DevExpress.XtraTab.XtraTabControl tabPageProdStatDetail;
        private DevExpress.XtraTab.XtraTabPage tabEmpStat;
        private DevExpress.XtraTab.XtraTabPage tabDFStat;
        private DevExpress.XtraGrid.GridControl gridDFStat;
        private DevExpress.XtraGrid.Views.Grid.GridView gridDFStatView;
        private DevExpress.XtraGrid.Columns.GridColumn colDFID;
        private DevExpress.XtraGrid.Columns.GridColumn colDFName;
        private DevExpress.XtraGrid.Columns.GridColumn colFQCScrapQuantity;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraTab.XtraTabPage tabMachineTime;
        private DevExpress.XtraGrid.GridControl gridMachineTime;
        private DevExpress.XtraGrid.Views.Grid.GridView gridMachineTimeView;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineID;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineName;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineTime;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraTab.XtraTabPage tabLosstime;
        private DevExpress.XtraGrid.GridControl gridLosstime;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLosstimeView;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btStatDelete;
        private DevExpress.XtraEditors.SimpleButton btStatEdit;
        private DevExpress.XtraEditors.SimpleButton btStatAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colLosstimeID;
        private DevExpress.XtraGrid.Columns.GridColumn colLosstimeName;
        private DevExpress.XtraGrid.Columns.GridColumn colLosstimeNum;
        private DevExpress.XtraGrid.Columns.GridColumn colProdBeginDate;
        private DevExpress.XtraBars.BarButtonItem barDateFilter;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraBars.BarCheckItem barCheckItem1;
        private DevExpress.XtraBars.BarEditItem barShowAll;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraBars.BarCheckItem barCheckItem2;
        private DevExpress.XtraBars.BarButtonItem barLocNgay;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarEditItem dtpFromDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit2;
        private DevExpress.XtraBars.BarStaticItem barStaticItem2;
        private DevExpress.XtraBars.BarEditItem dtpToDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit3;
        private DevExpress.XtraBars.BarStaticItem barStaticItem3;
        private DevExpress.XtraBars.BarEditItem cboStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.SimpleButton btStatEmpMulti;
        private DevExpress.XtraGrid.Columns.GridColumn colDFGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colProdWorktime;
        private DevExpress.XtraGrid.Columns.GridColumn colProdReworkTime;
        private DevExpress.XtraGrid.Columns.GridColumn colSumPrevFQCDFQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colSumFQCDFQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colSumFQCReworkQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colSumFQCScrapQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colProdSortTime;
        private DevExpress.XtraEditors.SimpleButton btOverall;
        private DevExpress.XtraGrid.Columns.GridColumn colOutputRateDG;
        private DevExpress.XtraGrid.Columns.GridColumn colOutputRateVN;
        private DevExpress.XtraGrid.Columns.GridColumn colTimeDG;
        private DevExpress.XtraGrid.Columns.GridColumn colProductivity;
        private DevExpress.XtraGrid.Columns.GridColumn colTimeVN;
        private DevExpress.XtraGrid.Columns.GridColumn colYTDProductivity;
       
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
        private DevExpress.XtraBars.BarStaticItem barStaticItem4;
        private DevExpress.XtraBars.BarEditItem cbWODocNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox3;
        private DevExpress.XtraTab.XtraTabPage tabExWork;
        private DevExpress.XtraGrid.GridControl gridExWork;
        private DevExpress.XtraGrid.Views.Grid.GridView gridExWorkView;
        private DevExpress.XtraGrid.Columns.GridColumn EmpID;
        private DevExpress.XtraGrid.Columns.GridColumn EmpName;
        private DevExpress.XtraGrid.Columns.GridColumn ExProdWorkID;
        private DevExpress.XtraGrid.Columns.GridColumn ExProdWorkName;
        private DevExpress.XtraGrid.Columns.GridColumn ExProdWorkTime;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView7;
        private DevExpress.XtraGrid.Columns.GridColumn ExProdWorkTimeTC;
        private DevExpress.XtraGrid.Columns.GridColumn SubJobHC;
        private DevExpress.XtraGrid.Columns.GridColumn colQRStart;
        private DevExpress.XtraEditors.SimpleButton btStageRefresh;
        private DevExpress.XtraEditors.SimpleButton btDeleteStageTime;
        private DevExpress.XtraTab.XtraTabPage tabEmpScanBarcode;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private DevExpress.XtraGrid.GridControl gridEmpScan;
        private DevExpress.XtraGrid.Views.Grid.GridView gridEmpScanView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView9;
        private DevExpress.XtraGrid.GridControl gridDetailEmpScan;
        private DevExpress.XtraGrid.Views.Grid.GridView gridDetailEmpScanView;
        private DevExpress.XtraGrid.Columns.GridColumn colAssigned;
        private DevExpress.XtraGrid.Columns.GridColumn colStageID;
        private DevExpress.XtraGrid.Columns.GridColumn colStageName;
        private DevExpress.XtraGrid.Columns.GridColumn colMaterialID;
        private DevExpress.XtraGrid.Columns.GridColumn MachineID;
        private DevExpress.XtraGrid.Columns.GridColumn colCheckInDt;
        private DevExpress.XtraGrid.Columns.GridColumn colCheckOutDt;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView11;
        private DevExpress.XtraGrid.GridControl gridEmpStat;
        private DevExpress.XtraGrid.Views.Grid.GridView gridEmpStatView;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpID;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpName;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpPosition;
        private DevExpress.XtraGrid.Columns.GridColumn colIsDirect;
        private DevExpress.XtraGrid.Columns.GridColumn colLine;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpLine;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpWorktime;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpOvertime;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpRework;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpSorting;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpOverRework;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpOverSorting;
        private DevExpress.XtraGrid.Columns.GridColumn colExLosstimeHC;
        private DevExpress.XtraGrid.Columns.GridColumn colExLosstimeTC;
        private DevExpress.XtraGrid.Columns.GridColumn colSubJobHC;
        private DevExpress.XtraGrid.Columns.GridColumn colSubJobTC;
        private DevExpress.XtraGrid.Columns.GridColumn colGeneralEmpWorktime;
        private DevExpress.XtraGrid.Columns.GridColumn colGeneralEmpOvertime;
        private DevExpress.XtraGrid.Columns.GridColumn colTimekeepHours;
        private DevExpress.XtraGrid.Columns.GridColumn colTimekeepID;
        private DevExpress.XtraGrid.Columns.GridColumn colTimeDifference;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Columns.GridColumn colAssignedOrder;
        private DevExpress.XtraEditors.SimpleButton btDelEmpStage;
        private DevExpress.XtraGrid.Columns.GridColumn colMoldID;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineTimePlan;
        private DevExpress.XtraGrid.Columns.GridColumn colSettingMoldTime;
        private DevExpress.XtraGrid.Columns.GridColumn colStartingTime;
        private DevExpress.XtraGrid.Columns.GridColumn colSettingMachineTime;
        private DevExpress.XtraGrid.Columns.GridColumn colOffMachineTime;
        private DevExpress.XtraGrid.Columns.GridColumn colDownTime;
        private DevExpress.XtraGrid.Columns.GridColumn colCycleTime;
        private DevExpress.XtraGrid.Columns.GridColumn colQtyFG;
        private DevExpress.XtraGrid.Columns.GridColumn colQtyNG;
        private DevExpress.XtraGrid.Columns.GridColumn colCavity;
        private DevExpress.XtraGrid.Columns.GridColumn colQtyPlan;
        private DevExpress.XtraGrid.Columns.GridColumn colYieldProdQuantity;
        private DevExpress.XtraTab.XtraTabPage tabA;
        private DevExpress.XtraTab.XtraTabPage tabP;
        private DevExpress.XtraGrid.GridControl gridA;
        private DevExpress.XtraGrid.Views.Grid.GridView gridAView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView8;
        private DevExpress.XtraGrid.GridControl gridP;
        private DevExpress.XtraGrid.Views.Grid.GridView gridPView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView10;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineINJ;
        private DevExpress.XtraGrid.Columns.GridColumn colPlanningQty;
        private DevExpress.XtraGrid.Columns.GridColumn colPlanningMachineTime;
        private DevExpress.XtraGrid.Columns.GridColumn colPercentLossA;
        private DevExpress.XtraGrid.Columns.GridColumn colPercentLossP;
        private DevExpress.XtraGrid.Columns.GridColumn colPercentLossQ;
    }
}