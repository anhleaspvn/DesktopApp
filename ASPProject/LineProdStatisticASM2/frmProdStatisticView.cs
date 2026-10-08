using ASPData;
using ASPData.ASPDAO;
using ASPData.ASPDTO;
using ASPData.ProdStatisticDTO;
using ASPProject.Losstime;
using DevExpress.Data;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace ASPProject.LineProdStatisticASM2
{
    public partial class frmProdStatisticView : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration
        public frmMain frm;
        public delegate void _deDongTab();
        public _deDongTab deDongTab;
        public int iNgonNgu;
        public string userName;
        private DataTable dtPS = new DataTable();
        private DataTable dtSOP = new DataTable();
        private DataSet dsDetailPS = new DataSet();
        private BindingSource bdsPSHeader = new BindingSource();
        private BindingSource bdsPSDetailEmp = new BindingSource();
        private BindingSource bdsEmpScan = new BindingSource();
        private BindingSource bdsPSDetailDF = new BindingSource();
        private BindingSource bdsPSDetailMachine = new BindingSource();
        private BindingSource bdsPSDetailLoss = new BindingSource();
        private BindingSource bdsPSDetailExWork = new BindingSource();
        private BindingSource bdsPSDetailWOSOP = new BindingSource();
        private BindingSource bdsPSDetailA = new BindingSource();
        private BindingSource bdsPSDetailP = new BindingSource();
        private DataRow drCurrent, drEmpCurrent, drDefectCurrent, drMachineCurrent, drLosstimeCurrent, drExWorkCurrent, drWOSOP, drA, drP;
        public int curIndex, empIndexCur, defectIndexCur, machineIndexCur, losstimeIndexCur, exWorkIndexCur, wosopIndexCur, aIndexCur, pIndexCur;

        public long HeaderID;
        public string fieldID, shift, WODocNo, productID, prodStatus;
        public double prodStatisticQuantity, prodStatisticEmpQuantity;
        public Boolean QRStart;
        private double outputRateVN = 0;
        private double outputRateDG = 0;
        public DateTime statisticDate, prodBeginDate;
        List<int> lstGridEmpSelect = new List<int>();
        List<int> lstGridMaChine = new List<int>();
        List<int> lstGridDF = new List<int>();
        List<int> lstGridExWork = new List<int>();
        private readonly SQLHelper _sqlHelper = new SQLHelper();

        ProdStatisticASM2DAO prodStatisticDAO = new ProdStatisticASM2DAO();
        ProdStatisticDTO prodStatisticDTO = new ProdStatisticDTO();
        PSDetailDefect detailDefectDto = new PSDetailDefect();
        PSDetailMachine detailMCDto = new PSDetailMachine();
        PSDetailLosstime detailLTDto = new PSDetailLosstime();
        PSDetailEmp detailEmp = new PSDetailEmp();
        PSDetailExProdWork detailExWork = new PSDetailExProdWork();
        TimekeepingDAO timekeepDao = new TimekeepingDAO();
        WOSOPDTO wosoDto = new WOSOPDTO();
        WOSOPDAO wosoDao = new WOSOPDAO();
        #endregion

        #region Constructor
        public void InitGridView()
        {
            lstGridEmpSelect = gridEmpStatView.GetSelectedRows().ToList();
            lstGridMaChine = gridMachineTimeView.GetSelectedRows().ToList();
            lstGridDF = gridDFStatView.GetSelectedRows().ToList();
            lstGridExWork = gridExWorkView.GetSelectedRows().ToList();

            new GridviewCheckbox(gridMachineTimeView, this, lstGridMaChine);
            new GridviewCheckbox(gridDFStatView, this, lstGridDF);
            new GridviewCheckbox(gridExWorkView, this, lstGridExWork);
            new GridviewCheckbox(gridLosstimeView, this, gridLosstimeView.GetSelectedRows().ToList());

            gridProdStatView.BestFitColumns();
        }
        public frmProdStatisticView()
        {
            InitializeComponent();

            //InitGridView();

            //default value
            dtpFromDate.EditValue = DateTime.Now;
            dtpToDate.EditValue = DateTime.Now;
            cboStatus.EditValue = cbWODocNo.EditValue = "All";

            RepositoryItemComboBox resCbo = new RepositoryItemComboBox();
            resCbo.Items.Add("All");
            resCbo.Items.Add("Đang sản xuất");
            resCbo.Items.Add("Hoàn thành");

            cboStatus.Edit = resCbo;

            //lenh sx
            RepositoryItemComboBox resCboWO = new RepositoryItemComboBox();
            resCboWO.Items.Add("All");
            ProdStatisticASM2DAO prodStatDao = new ProdStatisticASM2DAO();

            DataTable dtWODocNoList = new DataTable();
            dtWODocNoList = prodStatDao.GetWODocNoListForView(userName, string.Empty, 1);
            foreach (DataRow dr in dtWODocNoList.Rows)
            {
                resCboWO.Items.Add((string)dr["So_Ct"]);
            }

            cbWODocNo.Edit = resCboWO;

            //event
            this.Load += FrmProdStatisticView_Load;
            this.tabPageProdStatDetail.SelectedPageChanged += ProdStatDetail_SelectedPageChanged;
            this.bdsPSHeader.PositionChanged += BdsPSHeader_PositionChanged;
            this.barXoa.ItemClick += BarXoa_ItemClick;
            this.barNapLai.ItemClick += BarNapLai_ItemClick;
            this.barIn.ItemClick += BarIn_ItemClick;
            this.barXuat.ItemClick += BarXuat_ItemClick;
            this.barThoat.ItemClick += BarThoat_ItemClick;
            this.barThem.ItemClick += BarThem_ItemClick;
            this.barSua.ItemClick += BarSua_ItemClick;
            this.gridProdStatView.RowClick += GridProdStatView_RowClick;
            this.gridProdStatView.DoubleClick += GridProdStatView_DoubleClick;
            this.barLocNgay.ItemClick += BarLocNgay_ItemClick;
            this.gridProdStatView.CustomSummaryCalculate += GridProdStatView_CustomSummaryCalculate;

            //detail
            this.gridEmpStatView.RowClick += GridEmpStatView_RowClick;
            this.gridDFStatView.RowClick += GridDFStatView_RowClick;
            this.gridEmpStatView.DoubleClick += GridEmpStatView_DoubleClick;
            this.gridDFStatView.DoubleClick += GridDFStatView_DoubleClick;
            this.gridMachineTimeView.RowClick += GridMachineTimeView_RowClick;
            this.gridMachineTimeView.DoubleClick += GridMachineTimeView_DoubleClick;
            this.gridLosstimeView.RowClick += GridLosstimeView_RowClick;
            this.gridLosstimeView.DoubleClick += GridLosstimeView_DoubleClick;
            this.gridExWorkView.RowClick += GridExWorkView_RowClick;
            this.gridExWorkView.DoubleClick += GridExWorkView_DoubleClick;
            this.gridAView.DoubleClick += GridAView_DoubleClick;
            this.gridAView.RowClick += GridAView_RowClick;
            this.gridPView.RowClick += GridPView_RowClick;
            this.gridPView.DoubleClick += GridPView_DoubleClick;
            this.btStatAdd.Click += BtStatAdd_Click;
            this.btStatEdit.Click += BtStatEdit_Click;
            this.btStatDelete.Click += BtStatDelete_Click;
            this.btStatEmpMulti.Click += BtStatEmpMulti_Click;
            this.gridEmpStatView.RowStyle += GridEmpStatView_RowStyle;
            this.btOverall.Click += BtOverall_Click;
            this.gridDetailEmpScanView.RowCellClick += GridDetailEmpScanView_RowCellClick;
            this.bdsEmpScan.PositionChanged += BdsEmpScan_PositionChanged;
            this.btStageRefresh.Click += BtStageRefresh_Click;
            this.btDeleteStageTime.Click += BtDeleteStageTime_Click;
            this.btDelEmpStage.Click += BtDelEmpStage_Click;
        }

        #endregion

        #region Load
        private void FrmProdStatisticView_Load(object sender, EventArgs e)
        {
            frm.LoadVI += new frmMain.Translate(LoadTV);
            frm.LoadEN += new frmMain.Translate(LoadEL);

            LoadData();

            if (iNgonNgu == 1)
            {
                LoadEL();
            }
            else
            {
                LoadTV();
            }

            if (tabPageProdStatDetail.SelectedTabPage.Name == "tabEmpStat" || tabPageProdStatDetail.SelectedTabPage.Name == "tabExWork")
            {
                btStatDelete.Visible = true;
            }
            else
            {
                btStatDelete.Visible = false;
            }
        }

        public void LoadTV()
        {
            iNgonNgu = 0;
            CultureInfo objCultureInfo = Thread.CurrentThread.CurrentCulture;
        }
        public void LoadEL()
        {
            iNgonNgu = 1;
            CultureInfo objCultureInfo = Thread.CurrentThread.CurrentCulture;
        }
        private void LoadData()
        {
            //header
            dtPS = prodStatisticDAO.GetAllProductionStatistic(userName, Convert.ToDateTime(dtpFromDate.EditValue).Date, Convert.ToDateTime(dtpToDate.EditValue).Date, Convert.ToString(cboStatus.EditValue), Convert.ToString(cbWODocNo.EditValue));

            bdsPSHeader.DataSource = dtPS;
            gridProdStat.DataSource = bdsPSHeader;

            if (drCurrent != null)
            {
                long HeaderID = (long)Convert.ToDouble(drCurrent["HeaderID"]);

                LoadDataDetail(HeaderID);
            }
            gridProdStatView.SelectRow(curIndex);
        }

        private void LoadDataDetail(long HeaderID)
        {
            //detail
            dsDetailPS = prodStatisticDAO.GetAllDetailProdStatistic(HeaderID);

            if (dsDetailPS.Tables.Count >= 1)
            {
                bdsPSDetailEmp.DataSource = dsDetailPS.Tables[0];
                gridEmpStat.DataSource = bdsPSDetailEmp;
                UnselectedAllRows(gridEmpStatView);
                gridEmpStatView.ClearSelection();

                bdsEmpScan.DataSource = dsDetailPS.Tables[0];
                gridEmpScan.DataSource = bdsEmpScan;
            }

            if (dsDetailPS.Tables.Count >= 2)
            {
                bdsPSDetailDF.DataSource = dsDetailPS.Tables[1];
                gridDFStat.DataSource = bdsPSDetailDF;
                UnselectedAllRows(gridDFStatView);
                gridDFStatView.ClearSelection();
            }

            if (dsDetailPS.Tables.Count >= 3)
            {
                bdsPSDetailMachine.DataSource = dsDetailPS.Tables[2];
                gridMachineTime.DataSource = bdsPSDetailMachine;
                UnselectedAllRows(gridMachineTimeView);
                gridMachineTimeView.ClearSelection();
            }

            if (dsDetailPS.Tables.Count >= 4)
            {
                bdsPSDetailLoss.DataSource = dsDetailPS.Tables[3];
                gridLosstime.DataSource = bdsPSDetailLoss;
            }

            if (dsDetailPS.Tables.Count >= 5)
            {
                bdsPSDetailExWork.DataSource = dsDetailPS.Tables[4];
                gridExWork.DataSource = bdsPSDetailExWork;
            }


            if (dsDetailPS.Tables.Count >= 8)
            {
                bdsPSDetailA.DataSource = dsDetailPS.Tables[7];
                gridA.DataSource = bdsPSDetailA;
            }

            if (dsDetailPS.Tables.Count >= 9)
            {
                bdsPSDetailP.DataSource = dsDetailPS.Tables[8];
                gridP.DataSource = bdsPSDetailP;
            }
        }

        private void LoadDataDetailSOP(long EmpHeaderID, string EmpID)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@EmpHeaderID", EmpHeaderID },
                { "@EmpID", EmpID }
            };

            dtSOP = _sqlHelper.ExecProcedureDataAsDataTable("sp_ASPLoadDataDetailSOP", dicParams);

            bdsPSDetailWOSOP.DataSource = dtSOP;
            gridDetailEmpScan.DataSource = bdsPSDetailWOSOP;

            gridDetailEmpScanView.TopRowIndex = wosopIndexCur;
            gridDetailEmpScanView.FocusedRowHandle = wosopIndexCur;
        }

        private void UnselectedAllRows(GridView gridView)
        {
            for (int i = 0; i <= gridView.GetSelectedRows().Length - 1; i++)
            {
                gridView.UnselectRow(i);
            }
        }
        #endregion

        #region Event
        private void ProdStatDetail_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page.Name == "tabEmpStat" || e.Page.Name == "tabExWork")
            {
                btStatDelete.Visible = true;
            }
            else
            {
                btStatDelete.Visible = false;
            }

            if (e.Page.Name == "tabEmpScanBarcode")
            {
                btStageRefresh.Visible = true;
                btDeleteStageTime.Visible = true;
                btDelEmpStage.Visible = true;
            }
            else
            {
                btStageRefresh.Visible = false;
                btDeleteStageTime.Visible = false;
                btDelEmpStage.Visible = false;
            }
        }

        private void BdsPSHeader_PositionChanged(object sender, EventArgs e)
        {
            if (bdsPSHeader.Position < 0)
                return;

            drCurrent = ((DataRowView)bdsPSHeader.Current).Row;

            LoadDataDetail(Convert.ToInt32(drCurrent["HeaderID"]));

            BdsEmpScan_PositionChanged(sender, e);
        }

        private void BdsEmpScan_PositionChanged(object sender, EventArgs e)
        {
            if (bdsEmpScan.Position < 0)
                return;

            drEmpCurrent = ((DataRowView)bdsEmpScan.Current).Row;

            LoadDataDetailSOP(Convert.ToInt32(drEmpCurrent["HeaderID"]), Convert.ToString(drEmpCurrent["EmpID"]));
        }

        private void BtStageRefresh_Click(object sender, EventArgs e)
        {
            if (HeaderID == 0)
            {
                XtraMessageBox.Show("Vui lòng click chọn LSX ở lưới trên.");
                return;
            }
            try
            {
                wosoDto.EmpHeaderID = HeaderID;

                wosoDao.LoadDataDetailSOPAll(wosoDto);

                BdsEmpScan_PositionChanged(sender, e);

                XtraMessageBox.Show("Tải thành công.");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void BtDeleteStageTime_Click(object sender, EventArgs e)
        {
            if (bdsEmpScan.Position < 0)
                return;

            if (string.IsNullOrEmpty(WODocNo))
            {
                XtraMessageBox.Show("Vui lòng chọn lệnh sản xuất.");
                return;
            }

            try
            {
                drEmpCurrent = ((DataRowView)bdsEmpScan.Current).Row;

                wosoDto.HeaderID = (long)Convert.ToDouble(drEmpCurrent["HeaderID"]);
                wosoDto.EmpID = string.Empty;
                wosoDto.Type = true;

                wosoDao.DeleteStageTimeByEmp(wosoDto);

                BdsEmpScan_PositionChanged(sender, e);

                XtraMessageBox.Show("Đã xoá thành công.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtDelEmpStage_Click(object sender, EventArgs e)
        {
            if (bdsEmpScan.Position < 0)
                return;

            if (string.IsNullOrEmpty(WODocNo))
            {
                XtraMessageBox.Show("Vui lòng chọn lệnh sản xuất.");
                return;
            }    
                

            try
            {
                drEmpCurrent = ((DataRowView)bdsEmpScan.Current).Row;

                if (drEmpCurrent == null)
                    return;

                if (string.IsNullOrEmpty(drEmpCurrent["EmpID"].ToString()))
                {
                    XtraMessageBox.Show("Vui lòng chọn nhân viên.");
                    return;
                }

                wosoDto.HeaderID = (long)Convert.ToDouble(drEmpCurrent["HeaderID"]);
                wosoDto.EmpID = Convert.ToString(drEmpCurrent["EmpID"]);
                wosoDto.Type = false;

                wosoDao.DeleteStageTimeByEmp(wosoDto);

                BdsEmpScan_PositionChanged(sender, e);

                XtraMessageBox.Show("Đã xoá thành công.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BarXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có chắn chắn xoá thống kê của LSX này không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
                prodStatisticDAO.DeleteProdStatistic((long)drCurrent["HeaderID"]);
            else return;

            LoadData();
        }

        private void BarNapLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }

        private void BarIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridProdStat.ShowPrintPreview();
        }

        private void BarXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel|*.xlsx";
            saveFileDialog1.Title = "Save an File";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                gridProdStatView.ExportToXlsx(saveFileDialog1.FileName);
            }
        }

        private void BarThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            deDongTab();
        }

        private void BarThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmProdStatisticEdit th = new frmProdStatisticEdit();
            th.editType = 1;
            th.userName = userName;
            th.ShowDialog();
            LoadData();
        }

        private void BarSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(WODocNo))
            {
                if (iNgonNgu == 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn thông tin cần sửa.");
                }
                if (iNgonNgu == 1)
                {
                    XtraMessageBox.Show("Please select information to edit.");
                }
            }
            else
            {
                frmProdStatisticEdit th = new frmProdStatisticEdit();
                th.editType = 0;
                th.userName = userName;
                th.HeaderID = HeaderID;
                th.fieldID = fieldID;
                th.statisticDate = statisticDate;
                th.prodBeginDate = prodBeginDate;
                th.shift = shift;
                th.prodStatus = prodStatus;
                th.prodStatisticQuantity = prodStatisticQuantity;
                th.prodStatisticEmpQuantity = prodStatisticEmpQuantity;
                th.WODocNo = WODocNo;
                th.IschkQRStart = QRStart;
                th.ShowDialog();
                LoadData();
            }
        }

        private void barEditItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void GridProdStatView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (bdsPSHeader.Position < 0)
                return;

            drCurrent = gridProdStatView.GetDataRow(e.RowHandle);
            curIndex = e.RowHandle;

            HeaderID = (long)Convert.ToDouble(drCurrent["HeaderID"]);
            fieldID = Convert.ToString(drCurrent["FieldID"]);
            statisticDate = Convert.ToDateTime(drCurrent["StatisticDate"]);
            prodBeginDate = Convert.ToDateTime(drCurrent["ProdBeginDate"]);
            shift = Convert.ToString(drCurrent["ProdShift"]);
            prodStatus = Convert.ToString(drCurrent["ProdStatus"]);
            prodStatisticQuantity = Convert.ToDouble(drCurrent["ProdStatisticQuantity"]);
            prodStatisticEmpQuantity = Convert.ToDouble(drCurrent["ProdStatisticEmpQuantity"]);
            WODocNo = Convert.ToString(drCurrent["WODocNo"]);
            QRStart = Convert.ToBoolean(drCurrent["QRStart"]);
        }

        private void GridProdStatView_DoubleClick(object sender, EventArgs e)
        {
            BarSua_ItemClick(sender, null);
        }
        private void BarLocNgay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }

        private void GridProdStatView_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                // Get the summary ID. 
                int summaryID = Convert.ToInt32((e.Item as GridSummaryItem).Tag);
                DataTable dtSource = new DataTable();

                if (gridProdStatView.GetDataRow(0) == null)
                    return;

                dtSource = gridProdStatView.GetDataRow(0).Table.Clone();

                for (int i = 0; i <= gridProdStatView.RowCount - 1; i++)
                {
                    dtSource.ImportRow(gridProdStatView.GetDataRow(i));
                }


                if (dtSource.Rows.Count == 0)
                    return;

                double sumQuanity = Convert.ToDouble(dtSource.Compute("SUM(ProdStatisticQuantity)", string.Empty));
                double sumTimeVN = Convert.ToDouble(dtSource.Compute("SUM(TimeVN)", string.Empty));
                double sumTimeDG = Convert.ToDouble(dtSource.Compute("SUM(TimeDG)", string.Empty));

                // Initialization. 
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    outputRateVN = 0;
                    outputRateDG = 0;
                }
                // Calculation.
                if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    switch (summaryID)
                    {
                        case 1: // The total summary calculated against the 'UnitPrice' column. 
                            outputRateVN = sumTimeVN > 0 ? sumQuanity / sumTimeVN : 0;
                            break;
                        case 2: // The group summary. 
                            outputRateDG = sumTimeDG > 0 ? sumQuanity / sumTimeDG : 0;
                            break;
                    }
                }
                // Finalization. 
                if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    switch (summaryID)
                    {
                        case 1:
                            e.TotalValue = outputRateVN;
                            break;
                        case 2:
                            e.TotalValue = outputRateDG;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GridEmpStatView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            drEmpCurrent = gridEmpStatView.GetDataRow(e.RowHandle);
            empIndexCur = e.RowHandle;

            if (gridEmpStatView.IsRowSelected(e.RowHandle) == false)
            {
                gridEmpStatView.SelectRow(e.RowHandle);
            }
            else
            {
                gridEmpStatView.UnselectRow(e.RowHandle);
            }

            //InitGridView();
        }

        private void GridAView_RowClick(object sender, RowClickEventArgs e)
        {
            drA = gridAView.GetDataRow(e.RowHandle);
            aIndexCur = e.RowHandle;

            if (gridAView.IsRowSelected(e.RowHandle) == false)
            {
                gridAView.SelectRow(e.RowHandle);
            }
            else
            {
                gridAView.UnselectRow(e.RowHandle);
            }
        }

        private void GridPView_RowClick(object sender, RowClickEventArgs e)
        {
            drP = gridPView.GetDataRow(e.RowHandle);
            pIndexCur = e.RowHandle;

            if (gridPView.IsRowSelected(e.RowHandle) == false)
            {
                gridPView.SelectRow(e.RowHandle);
            }
            else
            {
                gridPView.UnselectRow(e.RowHandle);
            }
        }

        private void GridEmpStatView_DoubleClick(object sender, EventArgs e)
        {
            BtStatEdit_Click(sender, e);
        }
        private void GridDFStatView_DoubleClick(object sender, EventArgs e)
        {
            BtStatEdit_Click(sender, e);
        }
        private void GridDFStatView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            drDefectCurrent = gridDFStatView.GetDataRow(e.RowHandle);
            defectIndexCur = e.RowHandle;

            if (gridDFStatView.IsRowSelected(e.RowHandle) == false)
                gridDFStatView.SelectRow(e.RowHandle);
            else
                gridDFStatView.UnselectRow(e.RowHandle);
        }
        private void GridMachineTimeView_DoubleClick(object sender, EventArgs e)
        {
            BtStatEdit_Click(sender, e);
        }
        private void GridMachineTimeView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            drMachineCurrent = gridMachineTimeView.GetDataRow(e.RowHandle);
            machineIndexCur = e.RowHandle;

            if (gridMachineTimeView.IsRowSelected(e.RowHandle) == false)
                gridMachineTimeView.SelectRow(e.RowHandle);
            else
                gridMachineTimeView.UnselectRow(e.RowHandle);
        }
        private void GridLosstimeView_DoubleClick(object sender, EventArgs e)
        {
            BtStatEdit_Click(sender, e);
        }
        private void GridLosstimeView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            drLosstimeCurrent = gridLosstimeView.GetDataRow(e.RowHandle);
            losstimeIndexCur = e.RowHandle;
        }

        private void GridExWorkView_DoubleClick(object sender, EventArgs e)
        {
            BtStatEdit_Click(sender, e);
        }

        private void GridAView_DoubleClick(object sender, EventArgs e)
        {
            BtStatEdit_Click(sender, e);
        }

        private void GridPView_DoubleClick(object sender, EventArgs e)
        {
            BtStatEdit_Click(sender, e);
        }


        private void GridExWorkView_RowClick(object sender, RowClickEventArgs e)
        {
            drExWorkCurrent = gridExWorkView.GetDataRow(e.RowHandle);
            exWorkIndexCur = e.RowHandle;
        }
        private void BtStatAdd_Click(object sender, EventArgs e)
        {
            switch (tabPageProdStatDetail.SelectedTabPage.Name)
            {
                case "tabEmpStat":
                    if (HeaderID == 0)
                    {
                        XtraMessageBox.Show("Vui lòng click chọn LSX ở lưới trên.");
                        return;
                    }

                    frmPSDetailEmpEdit frmEmp = new frmPSDetailEmpEdit();
                    frmEmp.userName = userName;
                    frmEmp.editType = 1;
                    frmEmp.HeaderID = (long)Convert.ToDouble(drCurrent["HeaderID"]);
                    frmEmp.lineID = Convert.ToString(drCurrent["LineID"]);
                    frmEmp.ShowDialog();

                    LoadData();

                    break;
                case "tabDFStat":

                    if (HeaderID == 0)
                    {
                        XtraMessageBox.Show("Vui lòng click chọn LSX ở lưới trên.");
                        return;
                    }

                    frmPSDetailDefectEdit frm = new frmPSDetailDefectEdit();
                    frm.userName = userName;
                    frm.editType = 1;
                    frm.HeaderID = (long)Convert.ToDouble(drCurrent["HeaderID"]);
                    frm.ShowDialog();

                    LoadData();
                    break;
                case "tabMachineTime":
                    if (HeaderID == 0)
                    {
                        XtraMessageBox.Show("Vui lòng click chọn LSX ở lưới trên.");
                        return;
                    }

                    frmPSDetailMachineEdit frmMC = new frmPSDetailMachineEdit();
                    frmMC.userName = userName;
                    frmMC.editType = 1;
                    frmMC.HeaderID = (long)Convert.ToDouble(drCurrent["HeaderID"]);
                    frmMC.ShowDialog();

                    LoadData();

                    break;
                case "tabLosstime":
                    if (HeaderID == 0)
                    {
                        XtraMessageBox.Show("Vui lòng click chọn LSX ở lưới trên.");
                        return;
                    }

                    frmPSDetailLosstimeEdit frmLT = new frmPSDetailLosstimeEdit();
                    frmLT.userName = userName;
                    frmLT.editType = 1;
                    frmLT.HeaderID = (long)Convert.ToDouble(drCurrent["HeaderID"]);
                    frmLT.ShowDialog();

                    LoadData();

                    break;

                case "tabExWork":
                    if (HeaderID == 0)
                    {
                        XtraMessageBox.Show("Vui lòng click chọn LSX ở lưới trên.");
                        return;
                    }

                    frmProdPSDetailExWork frmExwork = new frmProdPSDetailExWork();
                    frmExwork.userName = userName;
                    frmExwork.editType = 1;
                    frmExwork.HeaderID = (long)Convert.ToDouble(drCurrent["HeaderID"]);
                    frmExwork.ShowDialog();

                    LoadData();

                    break;

                case "tabA":
                    if (HeaderID == 0)
                    {
                        XtraMessageBox.Show("Vui lòng click chọn LSX ở lưới trên.");
                        return;
                    }

                   


                    frmPSDetailAPEdit frmA = new frmPSDetailAPEdit();
                    frmA.userName = userName;
                    frmA.editType = 1;
                    frmA.HeaderID = (long)Convert.ToDouble(drCurrent["HeaderID"]);
                   
                    frmA.ShowDialog();

                    LoadData();

                    gridAView.TopRowIndex = aIndexCur;
                    gridAView.FocusedRowHandle = (int)aIndexCur;

                    break;
                case "tabP":
                    if (HeaderID == 0)
                    {
                        XtraMessageBox.Show("Vui lòng click chọn LSX ở lưới trên.");
                        return;
                    }

                   


                    frmPSDetailAPEdit frmB = new frmPSDetailAPEdit();
                    frmB.userName = userName;
                    frmB.editType = 1;
                    frmB.HeaderID = (long)Convert.ToDouble(drCurrent["HeaderID"]);

                    frmB.ShowDialog();

                    LoadData();

                    gridPView.TopRowIndex = pIndexCur;
                    gridPView.FocusedRowHandle = (int)pIndexCur;

                    break;
                default:
                    break;
            }
        }

        private void BtStatEdit_Click(object sender, EventArgs e)
        {
            switch (tabPageProdStatDetail.SelectedTabPage.Name)
            {
                case "tabEmpStat":
                    if (HeaderID == 0)
                    {
                        XtraMessageBox.Show("Vui lòng click chọn LSX ở lưới trên.");
                        return;
                    }

                    if (drEmpCurrent == null || string.IsNullOrEmpty(drEmpCurrent["EmpID"].ToString()))
                    {
                        XtraMessageBox.Show("Vui lòng click chọn nhân viên cần sửa.");
                        return;
                    }

                    frmPSDetailEmpEdit frmPsEmp = new frmPSDetailEmpEdit();
                    frmPsEmp.editType = 0;
                    frmPsEmp.saveMulti = 0;
                    frmPsEmp.userName = userName;
                    frmPsEmp.HeaderID = HeaderID;
                    frmPsEmp.lineID = Convert.ToString(drEmpCurrent["LineID"]);
                    frmPsEmp.empID = Convert.ToString(drEmpCurrent["EmpID"]);
                    frmPsEmp.empWorktime = Convert.ToDouble(drEmpCurrent["EmpWorktime"]);
                    frmPsEmp.empOvertime = Convert.ToDouble(drEmpCurrent["EmpOvertime"]);
                    frmPsEmp.empRework = Convert.ToDouble(drEmpCurrent["EmpRework"]);
                    frmPsEmp.empSorting = Convert.ToDouble(drEmpCurrent["EmpSorting"]);
                    frmPsEmp.empOverRework = Convert.ToDouble(drEmpCurrent["EmpOverRework"]);
                    frmPsEmp.empOverSorting = Convert.ToDouble(drEmpCurrent["EmpOverSorting"]);

                    frmPsEmp.ShowDialog();

                    LoadData();

                    gridEmpStatView.TopRowIndex = empIndexCur;
                    gridEmpStatView.FocusedRowHandle = empIndexCur;

                    break;
                case "tabDFStat":
                    if (HeaderID == 0)
                    {
                        XtraMessageBox.Show("Vui lòng click chọn LSX ở lưới trên.");
                        return;
                    }
                    if (drDefectCurrent == null || string.IsNullOrEmpty(drDefectCurrent["DefectID"].ToString()))
                    {
                        XtraMessageBox.Show("Vui lòng click chọn Defect mode cần sửa.");
                        return;
                    }

                    frmPSDetailDefectEdit frm = new frmPSDetailDefectEdit();
                    frm.editType = 0;
                    frm.userName = userName;
                    frm.HeaderID = HeaderID;
                    frm.defectID = Convert.ToString(drDefectCurrent["DefectID"]);
                    frm.fqcQuantity = Convert.ToDouble(drDefectCurrent["FQCDFQuantity"]);
                    frm.scrapFQCQuantity = Convert.ToDouble(drDefectCurrent["FQCScrapQuantity"]);
                    frm.prevFQCQuantity = Convert.ToDouble(drDefectCurrent["PrevFQCDFQuantity"]);
                    frm.remainDFQuantity = Convert.ToDouble(drDefectCurrent["RemainDFQuantity"]);
                    frm.reworkFQCQuantity = Convert.ToDouble(drDefectCurrent["FQCReworkQuantity"]);
                    frm.ShowDialog();

                    LoadData();

                    gridDFStatView.TopRowIndex = defectIndexCur;
                    gridDFStatView.FocusedRowHandle = defectIndexCur;

                    break;
                case "tabMachineTime":
                    if (HeaderID == 0)
                    {
                        XtraMessageBox.Show("Vui lòng click chọn LSX ở lưới trên.");
                        return;
                    }
                    if (drMachineCurrent == null || string.IsNullOrEmpty(drMachineCurrent["MachineID"].ToString()))
                    {
                        XtraMessageBox.Show("Vui lòng click chọn máy cần sửa.");
                        return;
                    }

                    frmPSDetailMachineEdit frmMC = new frmPSDetailMachineEdit();
                    frmMC.editType = 0;
                    frmMC.saveMulti = 0;
                    frmMC.userName = userName;
                    frmMC.HeaderID = HeaderID;
                    frmMC.machineID = Convert.ToString(drMachineCurrent["MachineID"]);
                    frmMC.machineTime = Convert.ToDouble(drMachineCurrent["MachineTime"]);

                    frmMC.ShowDialog();

                    LoadData();

                    gridMachineTimeView.TopRowIndex = machineIndexCur;
                    gridMachineTimeView.FocusedRowHandle = machineIndexCur;

                    break;
                case "tabLosstime":

                    if (HeaderID == 0)
                    {
                        XtraMessageBox.Show("Vui lòng click chọn LSX ở lưới trên.");
                        return;
                    }
                    if (drLosstimeCurrent == null || string.IsNullOrEmpty(drLosstimeCurrent["LosstimeID"].ToString()))
                    {
                        XtraMessageBox.Show("Vui lòng click chọn losstime cần sửa.");
                        return;
                    }


                    frmPSDetailLosstimeEdit frmLT = new frmPSDetailLosstimeEdit();
                    frmLT.editType = 0;
                    frmLT.userName = userName;
                    frmLT.HeaderID = HeaderID;
                    frmLT.losstimeID = Convert.ToString(drLosstimeCurrent["LosstimeID"]);
                    frmLT.losstimeNum = Convert.ToDouble(drLosstimeCurrent["LosstimeNum"]);

                    frmLT.ShowDialog();

                    LoadData();

                    gridLosstimeView.TopRowIndex = losstimeIndexCur;
                    gridLosstimeView.FocusedRowHandle = losstimeIndexCur;

                    break;
                case "tabExWork":

                    if (HeaderID == 0)
                    {
                        XtraMessageBox.Show("Vui lòng click chọn LSX ở lưới trên.");
                        return;
                    }

                    if (drExWorkCurrent == null || string.IsNullOrEmpty(drExWorkCurrent["ExProdWorkID"].ToString()))
                    {
                        XtraMessageBox.Show("Vui lòng click chọn Sub Job cần sửa.");
                        return;
                    }


                    frmProdPSDetailExWork frmExwork = new frmProdPSDetailExWork();
                    frmExwork.userName = userName;
                    frmExwork.editType = 0;
                    frmExwork.HeaderID = HeaderID;
                    frmExwork.empID = Convert.ToString(drExWorkCurrent["EmpID"]);
                    frmExwork.exProdWorkID = Convert.ToString(drExWorkCurrent["ExProdWorkID"]);
                    frmExwork.exProdWorkTime = Convert.ToDouble(drExWorkCurrent["ExProdWorkTime"]);
                    frmExwork.exProdWorkTimeTC = Convert.ToDouble(drExWorkCurrent["ExProdWorkTimeTC"]);
                    frmExwork.ShowDialog();

                    LoadData();

                    gridExWorkView.TopRowIndex = exWorkIndexCur;
                    gridExWorkView.FocusedRowHandle = (int)exWorkIndexCur;

                    break;
                case "tabA":
                    if (HeaderID == 0)
                    {
                        XtraMessageBox.Show("Vui lòng click chọn LSX ở lưới trên.");
                        return;
                    }

                    if (drA == null || string.IsNullOrEmpty(drA["DefectID"].ToString()))
                    {
                        XtraMessageBox.Show("Vui lòng click chọn mode cần sửa.");
                        return;
                    }


                    frmPSDetailAPEdit frmA = new frmPSDetailAPEdit();
                    frmA.userName = userName;
                    frmA.editType = 0;
                    frmA.HeaderID = HeaderID;
                    frmA.defectID = Convert.ToString(drA["DefectID"]);
                    frmA.numOfTime = Convert.ToDouble(drA["NumOfTime"]);
                   
                    frmA.ShowDialog();

                    LoadData();

                    gridAView.TopRowIndex = aIndexCur;
                    gridAView.FocusedRowHandle = (int)aIndexCur;

                    break;
                case "tabP":
                    if (HeaderID == 0)
                    {
                        XtraMessageBox.Show("Vui lòng click chọn LSX ở lưới trên.");
                        return;
                    }

                    if (drP == null || string.IsNullOrEmpty(drP["DefectID"].ToString()))
                    {
                        XtraMessageBox.Show("Vui lòng click chọn mode cần sửa.");
                        return;
                    }


                    frmPSDetailAPEdit frmB = new frmPSDetailAPEdit();
                    frmB.userName = userName;
                    frmB.editType = 0;
                    frmB.HeaderID = HeaderID;
                    frmB.defectID = Convert.ToString(drP["DefectID"]);
                    frmB.numOfTime = Convert.ToDouble(drP["NumOfTime"]);

                    frmB.ShowDialog();

                    LoadData();

                    gridPView.TopRowIndex = pIndexCur;
                    gridPView.FocusedRowHandle = (int)pIndexCur;

                    break;
                default:
                    break;
            }
        }

        private void BtStatEmpMulti_Click(object sender, EventArgs e)
        {
            switch (tabPageProdStatDetail.SelectedTabPage.Name)
            {
                case "tabEmpStat":
                    if (HeaderID == 0)
                    {
                        XtraMessageBox.Show("Vui lòng click chọn LSX ở lưới trên.");
                        return;
                    }

                    if (gridEmpStatView.SelectedRowsCount > 1)
                    {
                        frmPSDetailEmpEdit frmPsEmp = new frmPSDetailEmpEdit();
                        frmPsEmp.editType = 0;
                        frmPsEmp.saveMulti = 1;
                        frmPsEmp.userName = userName;
                        frmPsEmp.dtSaveMulti = gridEmpStatView.GetDataRow(0).Table.Clone(); //gridEmpStatView.GetDataRow(gridEmpStatView.GetSelectedRows());
                        foreach (var iRow in gridEmpStatView.GetSelectedRows())
                        {
                            frmPsEmp.dtSaveMulti.ImportRow(gridEmpStatView.GetDataRow(iRow));
                        }
                        frmPsEmp.ShowDialog();

                        LoadDataDetail((long)Convert.ToDouble(drCurrent["HeaderID"]));

                        gridEmpStatView.TopRowIndex = empIndexCur;
                        gridEmpStatView.FocusedRowHandle = empIndexCur;
                    }
                    break;
                case "tabMachineTime":
                    if (HeaderID == 0)
                    {
                        XtraMessageBox.Show("Vui lòng click chọn LSX ở lưới trên.");
                        return;
                    }

                    if (gridMachineTimeView.SelectedRowsCount > 1)
                    {
                        frmPSDetailMachineEdit frmPsMC = new frmPSDetailMachineEdit();
                        frmPsMC.editType = 0;
                        frmPsMC.saveMulti = 1;
                        frmPsMC.userName = userName;
                        frmPsMC.dtSaveMulti = gridMachineTimeView.GetDataRow(0).Table.Clone(); //gridEmpStatView.GetDataRow(gridEmpStatView.GetSelectedRows());
                        foreach (var iRow in gridMachineTimeView.GetSelectedRows())
                        {
                            frmPsMC.dtSaveMulti.ImportRow(gridMachineTimeView.GetDataRow(iRow));
                        }
                        frmPsMC.ShowDialog();

                        LoadDataDetail((long)Convert.ToDouble(drCurrent["HeaderID"]));

                        gridMachineTimeView.TopRowIndex = machineIndexCur;
                        gridMachineTimeView.FocusedRowHandle = machineIndexCur;
                    }
                    break;
                case "tabDFStat":
                    if (HeaderID == 0)
                    {
                        XtraMessageBox.Show("Vui lòng click chọn LSX ở lưới trên.");
                        return;
                    }

                    if (gridDFStatView.SelectedRowsCount > 1)
                    {
                        frmPSDetailDefectEdit frmDF = new frmPSDetailDefectEdit();
                        frmDF.editType = 0;
                        frmDF.saveMulti = 1;
                        frmDF.userName = userName;
                        frmDF.dtSaveMulti = gridDFStatView.GetDataRow(0).Table.Clone();
                        foreach (var iRow in gridDFStatView.GetSelectedRows())
                        {
                            frmDF.dtSaveMulti.ImportRow(gridDFStatView.GetDataRow(iRow));
                        }
                        frmDF.ShowDialog();

                        LoadDataDetail((long)Convert.ToDouble(drCurrent["HeaderID"]));

                        gridDFStatView.TopRowIndex = defectIndexCur;
                        gridDFStatView.FocusedRowHandle = defectIndexCur;
                    }
                    break;
                case "tabLosstime":
                    if (HeaderID == 0)
                    {
                        XtraMessageBox.Show("Vui lòng click chọn LSX ở lưới trên.");
                        return;
                    }

                    if (gridLosstimeView.SelectedRowsCount > 1)
                    {
                        frmPSDetailLosstimeEdit frmLt = new frmPSDetailLosstimeEdit();
                        frmLt.editType = 0;
                        frmLt.saveMulti = 1;
                        frmLt.userName = userName;
                        frmLt.dtSaveMulti = gridLosstimeView.GetDataRow(0).Table.Clone();
                        foreach (var iRow in gridLosstimeView.GetSelectedRows())
                        {
                            frmLt.dtSaveMulti.ImportRow(gridLosstimeView.GetDataRow(iRow));
                        }
                        frmLt.ShowDialog();

                        LoadDataDetail((long)Convert.ToDouble(drCurrent["HeaderID"]));

                        gridLosstimeView.TopRowIndex = losstimeIndexCur;
                        gridLosstimeView.FocusedRowHandle = losstimeIndexCur;
                    }
                    break;
                default:
                    break;
            }
        }

        private void BtUpdateStageTime_Click(object sender, EventArgs e)
        {
            if (HeaderID == 0)
            {
                XtraMessageBox.Show("Vui lòng chọn Lệnh sản xuất.");
                return;
            }

            prodStatisticDTO.HeaderID = HeaderID;
            prodStatisticDAO.UpdateStageTime(prodStatisticDTO);

            XtraMessageBox.Show("Đã cập nhật thành công.");
        }

        private void GridEmpStatView_RowStyle(object sender, RowStyleEventArgs e)
        {
            double timekeepHours = Convert.ToDouble(gridEmpStatView.GetRowCellValue(e.RowHandle, "TimekeepHours"));

            double EmpWorkTime = Convert.ToDouble(gridEmpStatView.GetRowCellValue(e.RowHandle, "GeneralEmpWorktime")) +
                                    Convert.ToDouble(gridEmpStatView.GetRowCellValue(e.RowHandle, "GeneralEmpOvertime"));

            string timekeepID = Convert.ToString(gridEmpStatView.GetRowCellValue(e.RowHandle, "TimekeepID"));

            DataTable dtChkTimekeepID = new DataTable();
            dtChkTimekeepID = timekeepDao.CheckWorkhoursTimekeep(timekeepID);

            //if exist timekeep without workhours then mark yellow color
            if (dtChkTimekeepID.Rows.Count > 0)
            {
                e.Appearance.BackColor = Color.Yellow;
            }

            if (timekeepHours < EmpWorkTime)
            {
                e.Appearance.BackColor = Color.Red;
            }
        }

        private void BtOverall_Click(object sender, EventArgs e)
        {
            frmPSDataSummaryByDay frmDp = new frmPSDataSummaryByDay();
            frmDp.statisticDate = statisticDate;
            frmDp.lineID = (string)_sqlHelper.ExecQuerySacalar("SELECT ISNULL(LineID, '') FROM ASPEmployee WHERE EmpID = '" + userName + "'");
            frmDp.username = userName;
            frmDp.ShowDialog();
        }

        private void GridDetailEmpScanView_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (gridEmpScanView.GetSelectedRows().ToList().Count == 0)
            {
                XtraMessageBox.Show("Vui lòng chọn nhân viên.");
                return;
            }

            drWOSOP = ((DataRowView)bdsPSDetailWOSOP.Current).Row;

            if (e.Column.Name == "colAssigned")
            {
                bool assigned = (bool)drWOSOP["Assigned"];

                foreach (int iRow in gridEmpScanView.GetSelectedRows().ToList())
                {
                    DataRow empRow = gridEmpStatView.GetDataRow(iRow);
                    wosoDto.EmpHeaderID = (long)Convert.ToDouble(empRow["HeaderID"]);
                    wosoDto.EmpID = Convert.ToString(empRow["EmpID"]);
                    wosoDto.StageID = Convert.ToString(drWOSOP["StageID"]);
                    wosoDto.Assigned = !assigned;

                    wosoDao.AddRemoveSOPStageByEmp(wosoDto);
                }

                DataRow[] arrDrAs = dtSOP.Select("EmpID = '" + Convert.ToString(drWOSOP["EmpID"]) + "' AND EmpHeaderID = " + Convert.ToString(drWOSOP["EmpHeaderID"]) + " AND StageID = '" + Convert.ToString(drWOSOP["StageID"]) + "'");

                for (int i = 0; i <= arrDrAs.Length - 1; i++)
                {
                    DataRow drAs = arrDrAs[i];

                    drAs["Assigned"] = !assigned;
                }    
            }
            else
            {
                frmPSDetailEmpScanEdit frm = new frmPSDetailEmpScanEdit();
                frm.EmpHeaderID = (long)Convert.ToDouble(drWOSOP["EmpHeaderID"]);
                frm.EmpID = Convert.ToString(drWOSOP["EmpID"]);
                frm.StageID = Convert.ToString(drWOSOP["StageID"]);
                frm.MaterialID = Convert.ToString(drWOSOP["MaterialID"]);
                frm.MachineID = Convert.ToString(drWOSOP["MachineID"]);
                frm.checkinDt = Convert.ToDateTime(drWOSOP["CheckInDt"]);
                frm.checkoutDt = Convert.ToDateTime(drWOSOP["CheckOutDt"]);
                frm.Quantity = Convert.ToInt32(drWOSOP["Quantity"]);
                frm.Show();
            }

            wosopIndexCur = e.RowHandle;

            LoadDataDetailSOP((long)Convert.ToDouble(drWOSOP["EmpHeaderID"]), Convert.ToString(drWOSOP["EmpID"]));
        }

        private void BtStatDelete_Click(object sender, EventArgs e)
        {
            switch (tabPageProdStatDetail.SelectedTabPage.Name)
            {
                case "tabEmpStat":
                    if (HeaderID == 0)
                    {
                        XtraMessageBox.Show("Vui lòng click chọn LSX ở lưới trên.");
                        return;
                    }
                    if (drEmpCurrent == null || string.IsNullOrEmpty(drEmpCurrent["EmpID"].ToString()))
                    {
                        XtraMessageBox.Show("Vui lòng click chọn nhân viên cần xoá.");
                        return;
                    }

                    if (XtraMessageBox.Show("Bạn có chắc chắc muốn xoá nhân viên " + Convert.ToString(drEmpCurrent["EmpID"]) + " không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        return;

                    detailEmp.HeaderID = HeaderID;
                    detailEmp.EmpID = Convert.ToString(drEmpCurrent["EmpID"]);
                    prodStatisticDAO.DeletePSDetailEmp(detailEmp);

                    LoadData();

                    XtraMessageBox.Show("Đã xoá thành công.");

                    drMachineCurrent = null;
                    break;
                case "tabDFStat":

                    if (HeaderID == 0)
                    {
                        XtraMessageBox.Show("Vui lòng click chọn LSX ở lưới trên.");
                        return;
                    }

                    if (drDefectCurrent == null || string.IsNullOrEmpty(drDefectCurrent["DefectID"].ToString()))
                    {
                        XtraMessageBox.Show("Vui lòng click chọn Defect mode cần xoá.");
                        return;
                    }

                    if (XtraMessageBox.Show("Bạn có chắc chắc muốn xoá Defect mode " + Convert.ToString(drDefectCurrent["DefectID"]) + " không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        return;

                    detailDefectDto.HeaderID = HeaderID;
                    detailDefectDto.DefectID = Convert.ToString(drDefectCurrent["DefectID"]);
                    prodStatisticDAO.DeletePSDetailDefect(detailDefectDto);

                    LoadData();

                    XtraMessageBox.Show("Đã xoá thành công.");

                    drDefectCurrent = null;

                    break;
                case "tabMachineTime":
                    if (HeaderID == 0)
                    {
                        XtraMessageBox.Show("Vui lòng click chọn LSX ở lưới trên.");
                        return;
                    }
                    if (drMachineCurrent == null || string.IsNullOrEmpty(drMachineCurrent["MachineID"].ToString()))
                    {
                        XtraMessageBox.Show("Vui lòng click chọn máy cần xoá.");
                        return;
                    }

                    if (XtraMessageBox.Show("Bạn có chắc chắc muốn xoá máy " + Convert.ToString(drMachineCurrent["MachineID"]) + " không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        return;

                    detailMCDto.HeaderID = HeaderID;
                    detailMCDto.MachineID = Convert.ToString(drMachineCurrent["MachineID"]);
                    prodStatisticDAO.DeletePSDetailMachine(detailMCDto);

                    LoadData();

                    XtraMessageBox.Show("Đã xoá thành công.");

                    drMachineCurrent = null;

                    break;
                case "tabLosstime":

                    if (HeaderID == 0)
                    {
                        XtraMessageBox.Show("Vui lòng click chọn LSX ở lưới trên.");
                        return;
                    }
                    if (drLosstimeCurrent == null || string.IsNullOrEmpty(drLosstimeCurrent["LosstimeID"].ToString()))
                    {
                        XtraMessageBox.Show("Vui lòng click chọn losstime cần xoá.");
                        return;
                    }

                    if (XtraMessageBox.Show("Bạn có chắc chắc muốn xoá losstime " + Convert.ToString(drLosstimeCurrent["LosstimeID"]) + " không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        return;

                    detailLTDto.HeaderID = HeaderID;
                    detailLTDto.LosstimeID = Convert.ToString(drLosstimeCurrent["LosstimeID"]);
                    prodStatisticDAO.DeletePSDetailLosstime(detailLTDto);

                    LoadData();

                    XtraMessageBox.Show("Đã xoá thành công.");

                    drLosstimeCurrent = null;

                    break;

                case "tabExWork":

                    if (HeaderID == 0)
                    {
                        XtraMessageBox.Show("Vui lòng click chọn LSX ở lưới trên.");
                        return;
                    }
                    if (drExWorkCurrent == null || string.IsNullOrEmpty(drExWorkCurrent["ExProdWorkID"].ToString()))
                    {
                        XtraMessageBox.Show("Vui lòng click chọn sub job cần xoá.");
                        return;
                    }

                    if (XtraMessageBox.Show("Bạn có chắc chắc muốn xoá sub job " + Convert.ToString(drExWorkCurrent["ExProdWorkID"]) + " không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        return;

                    PSDetailExProdWork exworkDto = new PSDetailExProdWork();
                    exworkDto.HeaderID = HeaderID;
                    exworkDto.EmpID = (string)drExWorkCurrent["EmpID"];
                    exworkDto.ExProdWorkID = (string)drExWorkCurrent["ExProdWorkID"];
                    prodStatisticDAO.DeletePSDetailExProdWork(exworkDto);

                    LoadData();

                    XtraMessageBox.Show("Đã xoá thành công.");

                    drLosstimeCurrent = null;

                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
